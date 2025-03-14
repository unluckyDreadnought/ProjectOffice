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
        public List<string[]> SelectedIndexes { get; private set; } = new List<string[]>();

        private void ResolveChooseMode()
        {
            switch (_mode)
            {
                case ChooseMode.Client:
                    {
                        string[] titles = { "id", "Имя", "Телефон", "Адрес" };
                        for (int i = 0; i < titles.Length; i++)
                        {
                            DataGridViewColumn temp = new DataGridViewColumn();
                            temp.Name = $"Column{i}";
                            temp.HeaderText = titles[i];
                            temp.Visible = i > 0;
                            temp.CellTemplate = new DataGridViewTextBoxCell();
                            chooseObjectsTable.Columns.Add(temp);
                        }
                        break;
                    }
                case ChooseMode.Employee:
                    {
                        string[] titles = { "id", "ФИО", "Специальность", "Участие", "Ответственный" };
                        for (int i = 0; i < titles.Length; i++)
                        {
                            DataGridViewColumn temp = null;
                            if (i < 3)
                            {
                                temp = new DataGridViewColumn();
                                temp.CellTemplate = new DataGridViewTextBoxCell();
                            }
                            else
                            {
                                temp = new DataGridViewCheckBoxColumn();
                                temp.CellTemplate = new DataGridViewCheckBoxCell();
                            }
                            temp.Name = $"Column{i}";
                            temp.HeaderText = titles[i];
                            temp.Visible = i > 0;
                            chooseObjectsTable.Columns.Add(temp);
                        }
                        break;
                    }
                case ChooseMode.Stages:
                    {
                        string[] titles = { "id", "Стадия", "Включить" };
                        for (int i = 0; i < titles.Length; i++)
                        {
                            DataGridViewColumn temp = null;
                            if (i < 2)
                            {
                                temp = new DataGridViewColumn();
                                temp.CellTemplate = new DataGridViewTextBoxCell();
                            }
                            else
                            {
                                temp = new DataGridViewCheckBoxColumn();
                                temp.CellTemplate = new DataGridViewCheckBoxCell();
                            }
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
ClientID, case when ClientOrgTypeID is null then ClientName else concat(ClientOrgTypeID, ' \'', ClientName, '\'') end as `ClientName`, ClientPhone, ClientAddress 
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
where `user`.UserSpecializationID != 0
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
                                    chooseObjectsTable.Rows[indx].Cells[c].Value = $"{addrParts[0]},{addrParts[1]}";
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

        private void RecoverSelected(string[][] data)
        {
            int row = 0, rec = 0;
            while (row < chooseObjectsTable.Rows.Count && rec < data.Length)
            {
                if (chooseObjectsTable.Rows[row].Cells[0].Value.ToString() == data[rec][0])
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
                    rec++;
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

        private void chooseObjectsTable_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (chooseObjectsTable.Rows[e.RowIndex].Cells[e.ColumnIndex] is DataGridViewCheckBoxCell == false) return;

            bool newValue = !Convert.ToBoolean(((DataGridViewCheckBoxCell)chooseObjectsTable.Rows[e.RowIndex].Cells[e.ColumnIndex]).Value);
            ((DataGridViewCheckBoxCell)chooseObjectsTable.Rows[e.RowIndex].Cells[e.ColumnIndex]).Value = newValue;

            if (_mode == ChooseMode.Employee)
            {
                if (e.ColumnIndex == chooseObjectsTable.ColumnCount - 1 && newValue) ((DataGridViewCheckBoxCell)chooseObjectsTable.Rows[e.RowIndex].Cells[e.ColumnIndex - 1]).Value = newValue;
                if (e.ColumnIndex == chooseObjectsTable.ColumnCount - 2 && !newValue) ((DataGridViewCheckBoxCell)chooseObjectsTable.Rows[e.RowIndex].Cells[e.ColumnIndex + 1]).Value = newValue;
            }
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
                if (employeesGroup.Length == 0 || employeesGroup[0].Length == 0) ;
                {

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
    }
}
