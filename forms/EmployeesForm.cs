﻿using System;
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
    public partial class EmployeesForm : Form
    {
        public EmployeesForm(bool canEdit = false)
        {
            InitializeComponent();
            toolStrip1.Enabled = toolStrip1.Visible = canEdit;
            userModeLbl.Text = AppUser.GetUserMode();
            userSnpLbl.Text = AppUser.Snp.Trim('.');
        }

        private void EmployeesForm_Load(object sender, EventArgs e)
        {
            this.Text = $"{Resources.APP_NAME}: Сотрудники";
        }

        private void editEmployeeBtn_Click(object sender, EventArgs e)
        {
            string userId = "";
            UserEditor uEdit = new UserEditor(edit: true);
            uEdit.ShowDialog();
        }

        private void backToMenu_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
