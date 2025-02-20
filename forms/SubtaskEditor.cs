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
    public partial class SubtaskEditor : Form
    {
        public SubtaskEditor()
        {
            InitializeComponent();
        }

        private void subtaskNumber_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SubtaskEditor_Load(object sender, EventArgs e)
        {
            this.Text = $"{Resources.APP_NAME}:  Добавление подзадачи";
        }
    }
}
