using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProjectOffice.Properties;
using ProjectOffice.logic;
using ProjectOffice.logic.app;

namespace ProjectOffice.forms
{
    public partial class ProjectEditorForm : Form
    {
        Db _db = new Db();

        public ProjectEditorForm()
        {
            InitializeComponent();
        }

        private async Task<int> GetLastProjID()
        {
            string query = $"SELECT ProjectID FROM {Db.Name}.project order by ProjectID DESC limit 1;";
            (object value,  Exception e) = await _db.ExecuteScalarAsync(query);
            int projId = -1;
            if (e != null)
            {
                MessageBox.Show(e.Message, "Не удалось извлечь значение", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (e == null && Convert.ToInt32(value) == -1)
            {
                MessageBox.Show("Не удалось установить подключение к БД.", "Ошибка подключения", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else projId = Convert.ToInt32(value);
            return projId;
        }

        private async void ProjectEditorForm_Load(object sender, EventArgs e)
        {
            this.Text = $"{Resources.APP_NAME}: Редактирование проекта";
            managerLbl.Text = AppUser.Snp;
            startDateLbl.Text = DateTime.Now.ToString("dd.MM.yyyy");
            int projId = await GetLastProjID();
            projectIdLbl.Text = $"Проект #{projId}";
        }

        private void backToProjectListBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void chooseClientBtn_Click(object sender, EventArgs e)
        {
            ChooseForm chooseForm = new ChooseForm(ChooseMode.Client);
            chooseForm.ShowDialog();
        }

        private void chooseStagesBtn_Click(object sender, EventArgs e)
        {
            ChooseForm chooseForm = new ChooseForm(ChooseMode.Stages);
            chooseForm.ShowDialog();
        }

        private void chooseEmployeesBtn_Click(object sender, EventArgs e)
        {
            ChooseForm chooseForm = new ChooseForm(ChooseMode.Employee);
            chooseForm.ShowDialog();
        }

        private void subtaskBtn_Click(object sender, EventArgs e)
        {
            SubtaskList tasksList = new SubtaskList();
            tasksList.ShowDialog();
        }
    }
}
