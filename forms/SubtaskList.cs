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
    public partial class SubtaskList : Form
    {
        public SubtaskList()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SubtaskEditor subtaskEdit = new SubtaskEditor();
            subtaskEdit.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ControlPointEditor cpEditor = new ControlPointEditor();
            cpEditor.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SubtaskList_Load(object sender, EventArgs e)
        {
            this.Text = $"{Resources.APP_NAME}: Список этапов и подзадач";
        }
    }
}
