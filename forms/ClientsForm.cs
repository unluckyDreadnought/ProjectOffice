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
        string clientId = "";

        public ClientsForm()
        {
            InitializeComponent();
            _db = new Db();
        }

        private async Task<DataTable> GetClients()
        {
            string query = @"select  
ClientID, case when ClientOrgTypeID is null then concat(ClientName) else concat(ClientOrgTypeID, ' \'', ClientName, '\'') end as `ClientName`, ClientPhone, ClientEmail, ClientPhoto 
from client where ClientID > 1; ";
            var task = _db.ExecuteReaderAsync(query);
            DataTable dt = await Common.GetAsyncResult(task);
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

        private async void UpdateClientsTable()
        {
            Common.SetSizeForImageRow(ref clientsTable, "clientImgCol", 40, 60);
            clientsTable.Rows.Clear();
            DataTable src = await GetClients();
            int i = 0;
            while (i < src.Rows.Count)
            {
                Bitmap curBmp = null;
                DataRow srcRow = src.Rows[i];
                int indx = clientsTable.Rows.Add();
                DataGridViewCellCollection rowCells = clientsTable.Rows[indx].Cells;
                clientsTable.Rows[indx].Height = 40;
                rowCells["clientIdCol"].Value = srcRow[0].ToString();
                rowCells["clientName"].Value = srcRow[1].ToString();
                rowCells["clientPhone"].Value = $"+{srcRow[2]}";
                rowCells["clientEmail"].Value = srcRow[3].ToString();
                curBmp = (srcRow[4] != null && srcRow[4] != DBNull.Value) ? logic.Сompressor.DecomoressBytesToBitmap((byte[])srcRow[4]) : Resources.PLUG_PICTURE;
                curBmp = Сompressor.ResizeImage(curBmp, 40, 80);
                ((DataGridViewImageCell)rowCells["clientImgCol"]).Value = curBmp;
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

        private async Task OpenEditor(string id = "")
        {
            if (fizSwitchBtn.Checked)
            {
                fizClientEditorPanel.Show();
            }
            else
            {
                fizClientEditorPanel.Hide();
                orgEdit = await OrganizationClientEditorForm.OpenOrganizationEditor(id);
                orgEdit.ShowDialog();
            }
            UpdateClientsTable();
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

        private async void addClientBtn_Click(object sender, EventArgs e)
        {
            await OpenEditor();
        }

        private async void editClientBtn_Click(object sender, EventArgs e)
        {
            if (clientId == "") {
                MessageBox.Show("Сначала выберите запись для редактирования", "Редактирование клиента", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; 
            };
            await OpenEditor(clientId);
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

        private void clientsTable_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                clientId = "";
                return;
            }
            clientId = clientsTable.Rows[e.RowIndex].Cells[0].Value.ToString();
        }

        private async void deleteClientBtn_Click(object sender, EventArgs e)
        {
            if (clientId == "") 
            {
                MessageBox.Show("Сначала выберите запись для удаления", "Удаление клиента", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (MessageBox.Show("Вы действительно хотите удалить выбранного клиента?", "Удаление клиента", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int n = 0;
                bool force = false;
                while (n > 0)
                {
                    (int res, bool haveRefs) = await Common.DeleteClient(clientId, force);
                    if (res == -1)
                    {
                        if (haveRefs)
                        {
                            DialogResult dialogRes = MessageBox.Show("Выбранный клиент задействован в других записях.\n" +
                                "Для удаления клиента потребуется удалить связанные записи.\nВы действительно хотите удалить клиента?", "Удаление клиента", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (dialogRes == DialogResult.Yes)
                            {
                                force = true;
                                n++;
                                continue;
                            }
                            else n = -1; continue;
                        }
                        else
                        {
                            MessageBox.Show("Удаление клиента заверширось неудачей", "Удаление клиента", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            n = -1; continue;
                        }
                    }
                    else if (res > 0)
                    {
                        MessageBox.Show($"Клиент удалён. Удаление клиента вызвало удаление {res} записей.", "Удаление клиента", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        n = -1; continue;
                    }
                }
            }
            UpdateClientsTable();
        }
    }
}
 