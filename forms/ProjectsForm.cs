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

namespace ProjectOffice.forms
{
    public partial class ProjectsForm : Form
    {
        public ProjectsForm()
        {
            InitializeComponent();
        }

        private void ProjectsForm_Load(object sender, EventArgs e)
        {
            this.Text = $"{Resources.APP_NAME}: Учёт проектов";
        }

        private void backToMenu_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void addProjectBtn_Click(object sender, EventArgs e)
        {
            ProjectEditorForm projEditor = new ProjectEditorForm();
            projEditor.ShowDialog();
        }

        private void editProjectBtn_Click(object sender, EventArgs e)
        {
            ProjectEditorForm projEditor = new ProjectEditorForm();
            projEditor.ShowDialog();
        }
    }
}
