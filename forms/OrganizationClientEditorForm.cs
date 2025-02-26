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
    public partial class OrganizationClientEditorForm : Form
    {
        string[] storedOrgInfo = null;
        Db _db = null;
        bool editMode = false;
        string editId = "";
        public OrganizationClientEditorForm(string id = "")
        {
            InitializeComponent();
            _db = new Db();
            editId = id;
            if (editId != "")
            {
                editMode = true;
                storedOrgInfo = GetClientInfo(editId);
            }
        }

        private string[] GetClientInfo(string clientId)
        {
            string query = $@"select ClientID, ClientOrgTypeID, ClientName, ClientAddress, ClientBankAccount, ClientBank, 
ClientPhone, ClientEmail, ClientOrgINN, ClientOrgKPP, ClientOrgOGRN, ClientOrgBIK from client where ClientID = {clientId};";
            DataTable dt = _db.ExecuteReader(query);
            List<string> info = new List<string>();
            int i = 0;
            while (i < dt.Columns.Count)
            {
                info.Add(dt.Rows[0][i].ToString());
                i++;
            }
            return info.ToArray();
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
