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
    public partial class ClientsForm : Form
    {
        OrganizationClientEditorForm orgEdit;

        public ClientsForm()
        {
            InitializeComponent();
        }

        private void ClientsForm_Load(object sender, EventArgs e)
        {
            this.Text = $"{Resources.APP_NAME}: Клиенты";
            fizClientEditorPanel.Hide();
            userModelbl.Text = AppUser.GetUserMode();
            userSnpLbl.Text = AppUser.Snp;
        }

        private void OpenEditor()
        {
            if (fizSwitchBtn.Checked)
            {
                fizClientEditorPanel.Show();
            }
            else
            {
                fizClientEditorPanel.Hide();
                orgEdit = new OrganizationClientEditorForm();
                orgEdit.ShowDialog();
            }
        }

        private void fizSwitchBtn_Click(object sender, EventArgs e)
        {
            if (!fizSwitchBtn.Checked)
            {
                fizClientEditorPanel.Hide();
                urSwitchBtn.Checked = true;
            }
            else
            {
                urSwitchBtn.Checked = false;
            }
        }

        private void urSwitchBtn_Click(object sender, EventArgs e)
        {
            if (!urSwitchBtn.Checked)
            {
                fizSwitchBtn.Checked = true;
            }
            else
            {
                fizClientEditorPanel.Hide();
                fizSwitchBtn.Checked = false;
            }
        }

        private void addClientBtn_Click(object sender, EventArgs e)
        {
            OpenEditor();
        }

        private void editClientBtn_Click(object sender, EventArgs e)
        {
            OpenEditor();
        }

        private void hideEditorPanelBtn_Click(object sender, EventArgs e)
        {
            fizClientEditorPanel.Hide();
            urSwitchBtn.Checked = false;
            fizSwitchBtn.Checked = true;
        }

        private void backToMenuBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
