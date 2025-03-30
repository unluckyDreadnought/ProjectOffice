using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProjectOffice.logic;
using ProjectOffice.Properties;

namespace ProjectOffice.forms
{
    public partial class ChooseForm : Form
    {
        private Db _db = new Db();
        private ChooseMode _mode;
        private DataGridViewColumnCollection _columns;
        private string[][] _recover = null;
        public string Title = "";
        string allSelected = " [Все]";

        public List<string[]> SelectedIndexes { get; private set; } = new List<string[]>();

        private void ResolveColumnSettings(ref DataGridViewColumn col, ref string columnTitle)
        {
            if (columnTitle.Trim().Length > 0)
            {
                if (columnTitle.Contains("V"))
                {
                    col = new DataGridViewCheckBoxColumn();
                    col.CellTemplate = new DataGridViewCheckBoxCell();
                    columnTitle = columnTitle.Replace("V", "");
                    col.FillWeight = 2;
                }
                else
                {
                    col = new DataGridViewColumn();
                    col.CellTemplate = new DataGridViewTextBoxCell();
                    col.FillWeight = 3;
                }
            }
            else
            {
                col = new DataGridViewImageColumn();
                col.CellTemplate = new DataGridViewImageCell();
                col.FillWeight = 1;
            }
        }

        private void ResolveChooseMode()
        {
            switch (_mode)
            {
                case ChooseMode.Client:
                    {
                        string[] titles = { "id", "Имя", "Телефон", "Адрес", "" };
                        for (int i = 0; i < titles.Length; i++)
                        {
                            DataGridViewColumn temp = null;
                            ResolveColumnSettings(ref temp, ref titles[i]);
                            temp.Name = $"Column{i}";
                            temp.HeaderText = titles[i];
                            temp.Visible = i > 0;
                            chooseObjectsTable.Columns.Add(temp);
                        }
                        break;
                    }
                case ChooseMode.Employee:
                    {
                        string[] titles = { "id", "ФИО", "Специальность", "УчастиеV", "ОтветственныйV" };
                        for (int i = 0; i < titles.Length; i++)
                        {
                            DataGridViewColumn temp = null;
                            ResolveColumnSettings(ref temp, ref titles[i]);
                            temp.Name = $"Column{i}";
                            temp.HeaderText = titles[i];
                            temp.Visible = i > 0;
                            chooseObjectsTable.Columns.Add(temp);
                        }
                        break;
                    }
                case ChooseMode.Stages:
                    {
                        string[] titles = { "id", "Стадия", "ВключитьV" };
                        for (int i = 0; i < titles.Length; i++)
                        {
                            DataGridViewColumn temp = null;
                            ResolveColumnSettings(ref temp, ref titles[i]);
                            temp.Name = $"Column{i}";
                            temp.HeaderText = titles[i];
                            temp.Visible = i > 0;
                            chooseObjectsTable.Columns.Add(temp);
                        }
                        break;
                    }
            }
        }

        public ChooseForm(ChooseMode mode)
        {
            InitializeComponent();
            _mode = mode;
            _columns = new DataGridViewColumnCollection(chooseObjectsTable);
            ResolveChooseMode();
        }

        public ChooseForm(ChooseMode mode, string[][] recoverData)
        {
            InitializeComponent();
            _mode = mode;
            _columns = new DataGridViewColumnCollection(chooseObjectsTable);
            ResolveChooseMode();
            _recover = recoverData;
        }

        private async Task<DataTable> GetClients()
        {
            string query = $@"select  
ClientID, case when ClientOrgTypeID is null then ClientName else concat(ClientOrgTypeID, ' \'', ClientName, '\'') end as `ClientName`, ClientPhone, ClientAddress, ClientPhoto 
from {Db.Name}.client where ClientID > 1;";
            var task = _db.ExecuteReaderAsync(query);
            DataTable dt = await Common.GetAsyncResult(task);
            return dt;
        }

        private async Task<DataTable> GetEmployees()
        {
            string query = $@"select UserID, concat(UserSurname, ' ', substring(UserName, 1, 1), '. ', case when UserPatronymic is null then '' else substring(UserPatronymic, 1, 1) end)  as 'Name',
specialization.SpecializationTitle
from {Db.Name}.`user`
inner join {Db.Name}.specialization on `user`.UserSpecializationID = specialization.SpecializationID
where `user`.UserSpecializationID != 0 and `user`.UserModeID != 2
order by UserSurname ASC;";
            var task = _db.ExecuteReaderAsync(query);
            DataTable dt = await Common.GetAsyncResult(task);
            return dt;
        }

        private async Task<DataTable> GetStages()
        {
            string query = $"select * from {Db.Name}.stage order by StageTitle ASC;";
            var task = _db.ExecuteReaderAsync(query);
            DataTable dt = await Common.GetAsyncResult(task);
            return dt;
        }

        private void InsertRowsInTable(DataTable dt)
        {
            int r = 0;
            while (r < dt.Rows.Count)
            {
                int indx = chooseObjectsTable.Rows.Add();
                int c = 0;
                while (c < dt.Columns.Count)
                {
                    chooseObjectsTable.Rows[indx].Cells[c].Value = dt.Rows[r][c].ToString();
                    c++;
                }
                r++;
            }
        }

        private async Task UpdateList()
        {
            DataTable dt = new DataTable();
            switch (_mode)
            {
                case ChooseMode.Client:
                    {
                        dt = await GetClients();
                        int r = 0;
                        while (r < dt.Rows.Count)
                        {
                            int indx = chooseObjectsTable.Rows.Add();
                            int c = 0;
                            while (c < dt.Columns.Count)
                            {
                                if (c == 1)
                                {
                                    string nameValue = dt.Rows[r][c].ToString();
                                    string[] nameParts = (nameValue.Contains("'")) ? new string[] { nameValue } : nameValue.Split(' ');
                                    int i = 0;
                                    while (i < nameParts.Length)
                                    {
                                        nameParts[i] = (i == 0) ? nameParts[i] : nameParts[i][0].ToString();
                                        i++;
                                    }
                                    nameValue = string.Join(". ", nameParts);
                                    chooseObjectsTable.Rows[indx].Cells[c].Value = nameValue;
                                }
                                else if (c == 3)
                                {
                                    string[] addrParts = dt.Rows[r][c].ToString().Split(',');
                                    chooseObjectsTable.Rows[indx].Cells[c].Value = (addrParts.Length > 1) ? $"{addrParts[0]},{addrParts[1]}" : $"{addrParts[0]}";
                                }
                                else if (c == 4)
                                {
                                    Bitmap curBmp = (dt.Rows[r][c] != null && dt.Rows[r][c] != DBNull.Value) ? logic.Сompressor.DecomoressBytesToBitmap((byte[])dt.Rows[r][c]) : Resources.PLUG_PICTURE;
                                    curBmp = logic.Сompressor.ResizeImage(curBmp, 20, 40);
                                    ((DataGridViewImageCell)chooseObjectsTable.Rows[indx].Cells[c]).ImageLayout = DataGridViewImageCellLayout.Stretch;
                                    ((DataGridViewImageCell)chooseObjectsTable.Rows[indx].Cells[c]).Value = curBmp;
                                }
                                else
                                {
                                    chooseObjectsTable.Rows[indx].Cells[c].Value = dt.Rows[r][c].ToString();
                                }
                                c++;
                            }
                            r++;
                        }
                        break;
                    }
                case ChooseMode.Employee:
                    {
                        dt = await GetEmployees();
                        InsertRowsInTable(dt);
                        break;
                    }
                case ChooseMode.Stages:
                    {
                        dt = await GetStages();
                        InsertRowsInTable(dt);
                        break;
                    }
            }
        }

        /// <summary>
        /// Получает индекс искомого значения в массиве массивов
        /// </summary>
        /// <param name="needed">Строковое искомое значение</param>
        /// <param name="source">Массив массивов - источник поиска</param>
        /// <param name="onlyFirst">Флаг, определяющий будет ли проверяться только первое значение каждого массива. По умолчанию - true</param>
        /// <returns>Возвращает (индекс массива, индекс элемента массива) в случае обнаружения искомого значения. Иначе (-1, -1)</returns>
        private (int, int) FindIndexOf(string needed, string[][] source, bool onlyFirst = true)
        {
            int[] address = new int[] { -1, -1 };
            int arrIndx = 0;
            while (address.Contains(-1) && arrIndx < source.Length)
            {
                int elemIndx = 0;
                while (elemIndx < source[arrIndx].Length)
                {
                    if (source[arrIndx][elemIndx] == needed) address = new int[] { arrIndx, elemIndx };
                    if (onlyFirst) break;
                    else elemIndx++;
                }
                arrIndx++;
            }
            return (address[0], address[1]);
        }

        /// <summary>
        /// Восстанавливает выбранные ранее позиции
        /// </summary>
        /// <param name="data">Массив массивов строк - источник информации о более раннем выборе</param>
        private void RecoverSelected(string[][] data)
        {
            int row = 0;
            while (row < chooseObjectsTable.Rows.Count)
            {
                (int rec, _) = FindIndexOf(chooseObjectsTable.Rows[row].Cells[0].Value.ToString(), data);
                if (rec != -1)
                {
                    if (_mode == ChooseMode.Employee)
                    {
                        ((DataGridViewCheckBoxCell)chooseObjectsTable.Rows[row].Cells[3]).Value = true;
                        ((DataGridViewCheckBoxCell)chooseObjectsTable.Rows[row].Cells[4]).Value = data[rec].Length > 1;
                    }
                    else if (_mode == ChooseMode.Stages)
                    {
                        ((DataGridViewCheckBoxCell)chooseObjectsTable.Rows[row].Cells[2]).Value = true;
                    }
                }
                int col = 2;
                while (col < chooseObjectsTable.Columns.Count)
                {
                    ChangeColumnHeaderText(chooseObjectsTable.Rows[row].Cells[col], allSelected);
                    col++;
                }
                row++;
            }
        }

        private void chooseBtn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private async void ChooseForm_Load(object sender, EventArgs e)
        {
            this.Text = $"{Resources.APP_NAME}: Выбор {Title}";
            await UpdateList();
            if (_recover != null) RecoverSelected(_recover);
        }

        private (bool, bool) IsCheckValuesEqual(int columnIndex)
        {
            int row = 1;
            bool result = true;
            bool value = false;
            if (chooseObjectsTable.Rows[0].Cells[columnIndex] is DataGridViewCheckBoxCell == false) return (false, false);
            value = Convert.ToBoolean(((DataGridViewCheckBoxCell)chooseObjectsTable.Rows[0].Cells[columnIndex]).Value);
            while (result && row < chooseObjectsTable.Rows.Count)
            {
                result = value == Convert.ToBoolean(((DataGridViewCheckBoxCell)chooseObjectsTable.Rows[row].Cells[columnIndex]).Value);
                row++;
            }
            return (result, value);
        }

        private string ChangeColumnHeaderText(DataGridViewCell cell, string addition)
        {
            string oldText =  chooseObjectsTable.Columns[cell.ColumnIndex].HeaderText;
            if (chooseObjectsTable.Rows[0].Cells[cell.ColumnIndex] is DataGridViewCheckBoxCell == false) return null;
            (bool equal, bool res) = IsCheckValuesEqual(cell.ColumnIndex);
            if (equal && res)
            {
                chooseObjectsTable.Columns[cell.ColumnIndex].HeaderText = oldText + addition;
            }
            else
            {
                chooseObjectsTable.Columns[cell.ColumnIndex].HeaderText = oldText.Replace(addition, "");
            }
            return oldText;
        }

        private void ChangeReferencedColumn(bool value, int row, int column, string headerAddition)
        {
            DataGridViewCell cell = null;
            if (column == chooseObjectsTable.ColumnCount - 1 && value)
            {
                cell = chooseObjectsTable.Rows[row].Cells[column - 1];
                ((DataGridViewCheckBoxCell)cell).Value = value;
                ChangeColumnHeaderText(cell, headerAddition);
            }
            if (column == chooseObjectsTable.ColumnCount - 2 && !value)
            {
                cell = chooseObjectsTable.Rows[row].Cells[column + 1];
                ((DataGridViewCheckBoxCell)cell).Value = value;
                ChangeColumnHeaderText(cell, headerAddition);
            }
        }

        private void chooseObjectsTable_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            bool newValue = false;
            int r = e.RowIndex;

            try
            {
                if (chooseObjectsTable.Rows[r].Cells[e.ColumnIndex] is DataGridViewCheckBoxCell == false) return;
                newValue = !Convert.ToBoolean(((DataGridViewCheckBoxCell)chooseObjectsTable.Rows[r].Cells[e.ColumnIndex]).Value);
                ((DataGridViewCheckBoxCell)chooseObjectsTable.Rows[r].Cells[e.ColumnIndex]).Value = newValue;

                if (_mode == ChooseMode.Employee)
                {
                    ChangeReferencedColumn(newValue, r, e.ColumnIndex, allSelected);
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                if (e.RowIndex < 0 && chooseObjectsTable.Rows[0].Cells[e.ColumnIndex] is DataGridViewCheckBoxCell != false)
                {
                    newValue = !ChangeColumnHeaderText(chooseObjectsTable.Rows[0].Cells[e.ColumnIndex], allSelected).Contains(allSelected);
                    r = 0;
                    while (r < chooseObjectsTable.Rows.Count)
                    {
                        ((DataGridViewCheckBoxCell)chooseObjectsTable.Rows[r].Cells[e.ColumnIndex]).Value = newValue;
                        if (_mode == ChooseMode.Employee)
                        {
                            ChangeReferencedColumn(newValue, r, e.ColumnIndex, allSelected);
                        }
                        r++;
                    }
                }
            }
            catch (Exception) { return; }
            ChangeColumnHeaderText(chooseObjectsTable.Rows[0].Cells[e.ColumnIndex], allSelected);
        }

        /// <summary>
        /// Изменяет список выбранных объектов исходя из статуса переключателя
        /// </summary>
        /// <param name="row">Индекс выбранной строки</param>
        /// <param name="colOffset">Смещение до ячейки прожатого переключателя от количества ячеек в строке</param>
        /// <param name="twoValueArray">Определяет имеет ли сохраняемый результат ячейку доп. информации</param>
        /// <param name="checkIndx">
        /// Индекс (0 или 1) колонки переключателя<br></br>
        /// 0 - основное включение<br></br>
        /// 1 - включение дополнительной информации
        /// </param>
        private void ChangeSelectedList(int row, int colOffset, bool twoValueArray = false, int checkIndx = 0)
        {
            string selectedId = chooseObjectsTable.Rows[row].Cells[0].Value.ToString();
            if (Convert.ToBoolean((chooseObjectsTable.Rows[row].Cells[chooseObjectsTable.Columns.Count - colOffset] as DataGridViewCheckBoxCell).Value))
            {
                if (!twoValueArray) SelectedIndexes.Add(new string[] { selectedId });
                else
                {
                    if (checkIndx == 1)
                    {
                        SelectedIndexes.Add(new string[] { selectedId, "1" });
                    }
                    else
                    {
                        SelectedIndexes.Add(new string[] { selectedId });
                    }
                }

            }
            else
            {
                if (SelectedIndexes.Count <= 0) return;
                var employeesGroup = SelectedIndexes.Where(item => item[0] == selectedId).ToArray();
                if (employeesGroup.Length == 0 || employeesGroup[0].Length == 0)
                {
                    return;
                }
                int indx = SelectedIndexes.IndexOf(SelectedIndexes.Where(item => item[0] == selectedId).ToArray()[0]);
                SelectedIndexes.RemoveAt(indx);
                if (twoValueArray)
                {
                    if (checkIndx == 1)
                    {
                        SelectedIndexes.Add(new string[] { selectedId });
                    }
                }
            }
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void ChooseForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            int row = 0;
            while (row < chooseObjectsTable.Rows.Count)
            {
                if (_mode == ChooseMode.Client)
                {
                    if (!chooseObjectsTable.Rows[row].Selected) { row++; continue; }
                    SelectedIndexes.Clear();
                    SelectedIndexes.Add(new string[] { chooseObjectsTable.Rows[row].Cells[0].Value.ToString() });
                }
                else if (_mode == ChooseMode.Employee)
                {
                    // id fio spec part resp
                    if (Convert.ToBoolean(((DataGridViewCheckBoxCell)chooseObjectsTable.Rows[row].Cells[4]).Value)) ChangeSelectedList(row, chooseObjectsTable.Columns.Count - 4, true, 1);
                    else if (Convert.ToBoolean(((DataGridViewCheckBoxCell)chooseObjectsTable.Rows[row].Cells[3]).Value)) ChangeSelectedList(row, chooseObjectsTable.Columns.Count - 3, true, 0);
                }
                else
                {
                    if (Convert.ToBoolean(((DataGridViewCheckBoxCell)chooseObjectsTable.Rows[row].Cells[2]).Value)) ChangeSelectedList(row, chooseObjectsTable.Columns.Count - 2, false);
                }
                row++;
            }
        }

        private void chooseObjectsTable_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) chooseBtn.PerformClick();
        }

        private async void addObject_Click(object sender, EventArgs e)
        {
            if (_mode == ChooseMode.Client)
            {
                ClientEditorForm form = await ClientEditorForm.OpenOrganizationEditor();
                form.ShowDialog();
            }
            else if (_mode == ChooseMode.Stages)
            {
                DictionaryEditForm editForm = null;
                Common.LaunchAddEditForm(ref editForm, "Этапы", "Этапы", new string[] { "", "Название стадии" }, "stage", "StageID", new string[] { "StageTitle" }, "", () => { }, false);
                editForm.ShowDialog();
            }
            chooseObjectsTable.Rows.Clear();
            await UpdateList();
        }
    }
}
