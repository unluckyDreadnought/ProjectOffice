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
        private ChooseMode _mode;
        private DataGridViewColumnCollection _columns;
        public string Title = "";

        public ChooseForm(ChooseMode mode)
        {
            InitializeComponent();
            _mode = mode;
            _columns = new DataGridViewColumnCollection(chooseObjectsTable);
            ResolveChooseMode();
        }

        private void ResolveChooseMode()
        {
            switch (_mode)
            {
                case ChooseMode.Client:
                    {
                        string[] titles = { "Имя", "Реквизиты", "Адрес" };
                        for (int i = 0; i < titles.Length; i++)
                        {
                            DataGridViewColumn temp = new DataGridViewColumn();
                            temp.Name = $"Column{i}";
                            temp.HeaderText = titles[i];
                            chooseObjectsTable.Columns.Add(temp);
                        }
                        break;
                    }
                case ChooseMode.Employee:
                    {
                        string[] titles = { "ФИО", "Должность", "Участие", "Ответственный" };
                        for (int i = 0; i < titles.Length; i++)
                        {
                            DataGridViewColumn temp = null;
                            if (i < 2)
                            {
                                temp = new DataGridViewColumn();
                            }
                            else
                            {
                                temp = new DataGridViewCheckBoxColumn();
                            }
                            temp.Name = $"Column{i}";
                            temp.HeaderText = titles[i];
                            chooseObjectsTable.Columns.Add(temp);
                        }
                        break;
                    }
                case ChooseMode.Stages:
                    {
                        string[] titles = { "Стадия", "Включить" };
                        for (int i = 0; i < titles.Length; i++)
                        {
                            DataGridViewColumn temp = null;
                            if (i < 1)
                            {
                                temp = new DataGridViewColumn();
                            }
                            else
                            {
                                temp = new DataGridViewCheckBoxColumn();
                            }
                            temp.Name = $"Column{i}";
                            temp.HeaderText = titles[i];
                            chooseObjectsTable.Columns.Add(temp);
                        }
                        break;
                    }
            }
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void chooseBtn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void ChooseForm_Load(object sender, EventArgs e)
        {
            this.Text = $"{Resources.APP_NAME}: Выбор {Title}";
        }
    }
}
