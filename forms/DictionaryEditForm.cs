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
    public partial class DictionaryEditForm : Form
    {
        public string tableName = "";

        string table = "";
        /// <summary>
        /// Набор полей для обновления
        /// </summary>
        string[] columns = null;
        /// <summary>
        /// Набор значений
        /// </summary>
        string[] val = null;

        Db _db = null;
        string[] placeholders = null;
        private string updateId = "";
        bool editMode = false;
        bool[] fieldsFilled = null;
        string[] storedData = null;

        private async Task<(bool, bool)> FindSame()
        {
            bool sameKey = false;
            bool sameValue = false;

            string query = $"select {columns.Last()} from {Db.Name}.{table} where {columns.Last()} != {val.Last()};";
            var task = _db.ExecuteReaderAsync(query);
            DataTable dt = await Common.GetAsyncResult(task);
            if (dt != null)
            {
                sameKey = Common.DataTableToStringArray(dt).Contains(val[0] == null ? val[0] : val[0].Trim('\''));
            }
            query = $"select {columns[0]} from {Db.Name}.{table} where {columns.Last()} != {val.Last()};";
            task = _db.ExecuteReaderAsync(query);
            dt = await Common.GetAsyncResult(task);
            if (dt != null)
            {
                sameValue = Common.DataTableToStringArray(dt).Contains(val.Last().Trim('\''));
            }
            return (sameKey, sameValue);
        }
        
        private async void InsertRecord(params string[] val)
        {
            string query = $"insert into {Db.Name}.{table} value (";
            query += string.Join(", ", val) + ");";
            var task = _db.ExecuteNoDataResultAsync(query);
            object res = await _db.GetAsynNonReaderResult(task);
            if (res == null)
            {
                MessageBox.Show("При добавлении возникла ошибка", $"Справочник \"{tableName}\"", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (res is int && (int)res > 0) MessageBox.Show("Запись успешно добавлена.", $"Справочник \"{tableName}\"", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private async void UpdateRecord(string[] cols, params string[] val)
        {
            string query = $"update {Db.Name}.{table} set ";
            int cntr = 0;
            while (cntr < cols.Length)
            {
                query += $"{cols[cntr]} = {val[cntr]}";
                if (cntr <= cols.Length - 2) query += ", ";
                cntr++;
            }
            int temp = 0;
            string id = (int.TryParse(updateId, out temp)) ? updateId : $"'{updateId}'";
            query += $" where {cols[cols.Length-1]} = {id};";
            var task = _db.ExecuteNoDataResultAsync(query);
            object res = await _db.GetAsynNonReaderResult(task);
            if (res == null)
            {
                MessageBox.Show("При изменении возникла ошибка", $"Справочник \"{tableName}\"", MessageBoxButtons.OK, MessageBoxIcon.Error); ;
            }
            else if (res is int && (int)res > 0) MessageBox.Show("Запись успешно добавлена.", $"Справочник \"{tableName}\"", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void CreateInputControls(string[] fieldDescriptions)
        {
            fieldsFilled = new bool[fieldDescriptions.Length];

            int xPosition = (panel1.Width - (int)(panel1.Width * 0.8)) / 2;
            int yPosition = 10;
            int cntr = 0;

            List<string> list = new List<string>();
            while (cntr < fieldDescriptions.Length)
            {
                if (fieldDescriptions[cntr] != "") list.Add(fieldDescriptions[cntr]);
                cntr++;
            }
            fieldDescriptions = list.ToArray();

            cntr = 0;

            while (cntr < fieldDescriptions.Length)
            {
                TextBox newText = new TextBox();
                newText.ForeColor = Color.Gray;
                newText.Text = fieldDescriptions[cntr];
                newText.Anchor = AnchorStyles.Left | AnchorStyles.Right;
                newText.Size = new Size((int)(panel1.Width * 0.8), 34);
                newText.Location = new Point(xPosition, yPosition);

                newText.LostFocus += TextBox_FocusLeave;
                newText.Click += TextBox_Click;
                newText.KeyPress += TextBox_KeyPressed;
                newText.TextChanged += TextBox_TextChanged;

                panel1.Controls.Add(newText);

                yPosition += newText.Height + 20;
                cntr++;
            }

            cancelBtn.Focus();
        }

        private async Task<string[]> GetDataAboutObject(string id, bool keyNeeded)
        {
            string fields = (keyNeeded) ? $"{string.Join(", ", columns)}" : $"{string.Join(", ", columns, 0, columns.Length - 1)}";
            int temp = 0;
            id = (int.TryParse(id, out temp)) ? id : $"'{id}'";
            string query = $"select {fields} from {Db.Name}.{table} where {columns.Last()} = {id};";

            var task = _db.ExecuteReaderAsync(query);
            DataTable data = await Common.GetAsyncResult(task);
            if (data == null) return null;
            List<string> response = new List<string>();

            int i = 0;
            while (i < data.Columns.Count)
            {
                response.Add(data.Rows[0][i].ToString());
                i++;
            }
            response.Reverse();

            return response.ToArray();
        }

        private async void FillFields()
        {
            var task = GetDataAboutObject(updateId, (panel1.Controls.Count > 1) ? true : false);
            storedData = await task;
            int i = 0;
            while (i < panel1.Controls.Count)
            {
                ((TextBox)panel1.Controls[i]).Text = storedData[i];
                i++;
            }
            EnableButton();
        }

        private bool CompareValuesWithDbData()
        {
            bool res = false;
            int i = 0;
            while (i < panel1.Controls.Count)
            {
                res = ((TextBox)panel1.Controls[i]).Text != storedData[i];
                if (res) break;
                i++;
            }
            return res;
        }

        private bool CheckFieldsFilling()
        {
            bool res = false;
            int i = 0;
            while (i < panel1.Controls.Count)
            {
                res = ((TextBox)panel1.Controls[i]).Text.Trim().Length > 0 && !placeholders.Contains(((TextBox)panel1.Controls[i]).Text.Trim());
                if (!res) break;
                i++;
            }
            return res;
        }

        private void EnableButton()
        {
            if (editMode) addBtn.Enabled = CompareValuesWithDbData();
            else addBtn.Enabled = CheckFieldsFilling();
        }

        private void GetValues()
        {
            if (val == null)
            {
                val = new string[2];
            }

            int i = (panel1.Controls.Count > 1) ? 0 : -1;
            while (i < val.Length)
            {
                if (i == -1)
                {
                    val[i + 1] = (editMode) ? $"{storedData[i+1]}" : "null";
                    val[i + 2] = (editMode) ? $"{storedData[i+1]}" : "null";
                }
                if (i >= 0 && i < panel1.Controls.Count)
                {
                    val[i] = $"'{((TextBox)panel1.Controls[i]).Text.Trim()}'";
                }
                i++;
            }
        }

        private void ClearFields()
        {
            int i = 0;
            while (i < panel1.Controls.Count)
            {
                ((TextBox)panel1.Controls[i]).Text = "";
                i++;
            }
        }

        public DictionaryEditForm(string title, string[] fieldsPlaceholders, string tbl, string colIdName, string[] colsToUpdate, string objectId = "", bool edit = false)
        {
            InitializeComponent();
            string text = "";
            string[] parts = title.Split(' ');
            parts[0] = (parts[0] == "") ? title.Substring(0, title.Length-1) : parts[0].Substring(0, parts[0].Length - 1);
            text = string.Join(" ", parts);
            this.Text = $"Новый элемент - {text}";
            placeholders = fieldsPlaceholders;
            _db = new Db();
            table = tbl;
            List<string> cols = colsToUpdate.ToList();
            cols.Add(colIdName);
            columns = cols.ToArray();
            updateId = objectId;
            editMode = edit;
        }

        private void DictionaryEditForm_Load(object sender, EventArgs e)
        {
            this.Icon = Resources.PROJECT_OFFICE_ICON;
            CreateInputControls(placeholders);
            addBtn.Text = (editMode) ? "Изменить" : "Добавить";
            if (editMode) FillFields();
        }

        private void RightColor(object sender)
        {
            TextBox textControl = (TextBox)sender;
            if (placeholders.Contains(textControl.Text.Trim()))
            {
                textControl.ForeColor = Color.Gray;
            }
            else
            {
                textControl.ForeColor = Color.Black;
            }
        }

        private void TextBox_Click(object sender, EventArgs e) {
            TextBox textControl = ((TextBox)sender);
            int indx = panel1.Controls.IndexOf(textControl);
            if (placeholders.Contains(textControl.Text.Trim()))
            {
                ((TextBox)panel1.Controls[indx]).Clear();
                ((TextBox)panel1.Controls[indx]).Text = "";
            }
        }

        private void TextBox_FocusLeave(object sender, EventArgs e)
        {
            TextBox textControl = ((TextBox)sender);
            if (textControl.Text.Trim() == "")
            {
                textControl.Text = placeholders[panel1.Controls.IndexOf(textControl)];
            }
            RightColor(sender);
            EnableButton();
        }

        private void TextBox_KeyPressed(object sender, KeyPressEventArgs e)
        {
            if (Symbols.ru_alp.Contains(Char.ToLower(e.KeyChar)) || e.KeyChar == 8 || e.KeyChar == 127 || e.KeyChar == ' ' || e.KeyChar == '-') return;
            else e.Handled = true;
        }

        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            RightColor(sender);
            EnableButton();
        }

        private async void addBtn_Click(object sender, EventArgs e)
        {
            GetValues();

            if (val[val.Length - 1] == null && updateId == "") val[val.Length - 1] = "null";
            else if (editMode && (val[val.Length - 1] == null || val[val.Length - 1] == "null") && updateId != "") val[val.Length - 1] = updateId;
            if (panel1.Controls.Count < 2)
            {
                val = val.Reverse().ToArray();
            }

            (bool key, bool value) = await FindSame();
            if (key && !editMode)
            {
                MessageBox.Show("Такой ключ уже существует в базе данных. Запись не будет добавлена.", $"Справочник \"{tableName}\"", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (value && !editMode)
            {
                MessageBox.Show("Такое значение уже существует в базе данных. Запись не будет добавлена.", $"Справочник \"{tableName}\"", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (!editMode)
            {
                InsertRecord(val);
            }
            else
            {
                UpdateRecord(columns, val.ToList().Reverse<string>().ToArray());
            }
            ClearFields();
        }

        private void cancelBtn_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
