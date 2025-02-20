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
    public partial class OrganizationClientEditorForm : Form
    {
        public OrganizationClientEditorForm()
        {
            InitializeComponent();
        }

        private void OrganizationClientEditorForm_Load(object sender, EventArgs e)
        {
            this.Text = $"{Resources.APP_NAME}: Редактирование организации";
        }

        private void closeOrgEditorBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
