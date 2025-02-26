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
    public partial class ClientsForm : Form
    {
        OrganizationClientEditorForm orgEdit;
        Db _db = null;

        public ClientsForm()
        {
            InitializeComponent();
            _db = new Db();
        }

        private DataTable GetClients()
        {
            string query = @"select  
ClientID, case when ClientOrgTypeID is null then concat(ClientName) else concat(ClientOrgTypeID, ' \'', ClientName, '\'') end as `ClientName`, ClientPhone, ClientEmail 
from client; ";
            DataTable dt = _db.ExecuteReader(query);
            int indx = 0;
            while (indx < dt.Rows.Count)
            {
                DataRow row = dt.Rows[indx];
                string temp = row[2].ToString();
                string phone = "";
                int cntr = 0;
                while (cntr < temp.Length)
                {
                    if (cntr >= 2 && cntr <= 6) phone += '*';
                    else phone += temp[cntr];
                    cntr++;
                }
                string[] snp = row[1].ToString().Split(' ');
                if (row[1].ToString().Contains("'")) row[1] = row[1].ToString();
                else
                {
                    if (snp.Length > 2) row[1] = $"{snp[0]} {snp[1][0]}. {snp[2][0]}";
                    else row[1] = $"{snp[0]} {snp[1][0]}.";
                }
                row[2] = phone;
                indx++;
            }
            return dt;
        }

        private void UpdateClientsTable()
        {
            DataTable src = GetClients();
            int i = 0;
            while (i < src.Rows.Count)
            {
                DataRow srcRow = src.Rows[i];
                int indx = clientsTable.Rows.Add();
                DataGridViewCellCollection rowCells = clientsTable.Rows[indx].Cells;
                rowCells["clientId"].Value = srcRow[0].ToString();
                rowCells["clientName"].Value = srcRow[1].ToString();
                rowCells["clientPhone"].Value = $"+{srcRow[2]}";
                rowCells["clientEmail"].Value = srcRow[3].ToString();
                i++;
            }
        }

        private void ClientsForm_Load(object sender, EventArgs e)
        {
            this.Text = $"{Resources.APP_NAME}: Клиенты";
            this.Icon = Resources.PROJECT_OFFICE_ICON;
            fizClientEditorPanel.Hide();
            userModelbl.Text = AppUser.GetUserMode();
            userSnpLbl.Text = AppUser.Snp;
            UpdateClientsTable();
        }

        private void OpenEditor(string id = "")
        {
            if (fizSwitchBtn.Checked)
            {
                fizClientEditorPanel.Show();
            }
            else
            {
                fizClientEditorPanel.Hide();
                orgEdit = new OrganizationClientEditorForm(id);
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
            if (clientsTable.SelectedRows.Count == 0) {
                MessageBox.Show("Сначала выберите запись для редактирования", "Редактирование записи", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; 
            }
            string id = clientsTable.SelectedRows[0].Cells["clientId"].Value.ToString();
            OpenEditor(id);
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
