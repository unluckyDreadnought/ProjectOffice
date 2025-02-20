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

namespace ProjectOffice.forms
{
    public partial class ProjectEditorForm : Form
    {
        public ProjectEditorForm()
        {
            InitializeComponent();
        }

        private void ProjectEditorForm_Load(object sender, EventArgs e)
        {
            this.Text = $"{Resources.APP_NAME}: Редактирование проекта";
            managerLbl.Text = AppUser.Snp;
            startDateLbl.Text = DateTime.Now.ToString("dd.MM.yyyy");
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
