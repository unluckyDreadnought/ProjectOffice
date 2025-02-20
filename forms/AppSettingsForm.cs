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
    public partial class AppSettingsForm : Form
    {
        public AppSettingsForm()
        {
            InitializeComponent();
        }

        private void AppSettingsForm_Load(object sender, EventArgs e)
        {
            this.Text = $"{Resources.APP_NAME}: Настройки";
        }

        private void backToMenuBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
