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
        private string updateId = "";
        bool editMode = false;
        
        private void InsertRecord(params string[] val)
        {
            string query = $"insert into {Db.Name}.{table} value (";
            query += string.Join(", ", val) + ");";
            _db.ExecuteReader(query);
        }

        private void UpdateRecord(string[] cols, params string[] val)
        {
            string query = $"update {Db.Name}.{table} set ";
            int cntr = 0;
            while (cntr < cols.Length-1)
            {
                query += $"{cols[cntr]} = @updateValue_{cntr}";
                if (cntr < cols.Length - 2) query += ", ";
            }
            query += $" where {cols[cols.Length-1]} = {updateId};";
            _db.ExecuteReader(query, val);
        }

        private void CreateInputControls(string[] fieldDescriptions)
        {
            int xPosition = (panel1.Width - (int)(panel1.Width * 0.8)) / 2;
            int yPosition = 10;
            int cntr = 0;
            while (cntr < fieldDescriptions.Length)
            {
                TextBox newText = new TextBox();
                newText.ForeColor = Color.Gray;
                newText.Text = fieldDescriptions[cntr];
                newText.Anchor = AnchorStyles.Left | AnchorStyles.Right;
                newText.Size = new Size((int)(panel1.Width * 0.8), 34);
                newText.Location = new Point(xPosition, yPosition);
                panel1.Controls.Add(newText);
                yPosition += newText.Height + 20;
                cntr++;
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
            CreateInputControls(fieldsPlaceholders);
            _db = new Db();
            table = tbl;
            List<string> cols = colsToUpdate.ToList();
            cols.Add(colIdName);
            columns = cols.ToArray();
            updateId = objectId;
            editMode = edit;
        }

        // ДОБАВИТЬ ДЛЯ РАБОТЫ:
        // - ВЗЯТИЕ ДАННЫХ ИЗ БД ПО ИД
        // - ПРОВЕРКУ НА НЕРАВЕНСТВО С ДАННЫМИ ИЗ БАЗЫ
        // - ОБРАБОТЧИКИ НАЖАТИЯ НА ПОЛЯ ВВОДА, ПОТЕРИ ФОКУСА (плэйсхолдер); ОБРАБОТЧИК НАЖАТИЯ КЛАВИШИ
        // Ну и проверить работу (добавление и т.д.)

        private void DictionaryEditForm_Load(object sender, EventArgs e)
        {
            this.Icon = Resources.PROJECT_OFFICE_ICON;
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            if (!editMode)
            {
                InsertRecord(val);
            }
            else
            {
                UpdateRecord(columns, val);
            }
        }

        private void cancelBtn_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
