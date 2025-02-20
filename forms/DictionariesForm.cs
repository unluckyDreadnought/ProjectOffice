using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProjectOffice.logic;
using ProjectOffice.Properties;

namespace ProjectOffice.forms
{
    public partial class DictionariesForm : Form
    {
        public DictionariesForm(params Dictionaries[] displayed)
        {
            InitializeComponent();
            HideButtons();
            ShowButtons(displayed);
            editorPanel.Hide();
        }

        private void HideButtons()
        {
            foreach (object item in toolStrip1.Items)
            {
                if (item is ToolStripButton == false) continue;
                if (!((ToolStripButton)item).Name.Contains("Check")) continue;
                ((ToolStripButton)item).Enabled = false;
                ((ToolStripButton)item).Visible = false;
            }
        }

        private void ShowButtons(params Dictionaries[] dicts)
        {
            foreach (Dictionaries d in dicts)
            {
                switch (d)
                {
                    case Dictionaries.Specializations:
                        {
                            specCheckBtn.Enabled = true;
                            specCheckBtn.Visible = true;
                            break;
                        }
                    case Dictionaries.Status:
                        {
                            statusCheckBtn.Enabled = true;
                            statusCheckBtn.Visible = true;
                            break;
                        }
                    case Dictionaries.Stages:
                        {
                            stagesCheckBtn.Enabled = true;
                            stagesCheckBtn.Visible = true;
                            break;
                        }
                    case Dictionaries.OrganizationTypes:
                        {
                            typesCheckBtn.Enabled = true;
                            typesCheckBtn.Visible = true;
                            break;
                        }
                    case Dictionaries.Subtasks:
                        {
                            subtasksCheckBtn.Enabled = true;
                            subtasksCheckBtn.Visible = true;
                            break;
                        }
                }
            }
        }

        private void DictionariesForm_Load(object sender, EventArgs e)
        {
            this.Text = $"{Resources.APP_NAME}: Справочники";
        }

        private void ClearTablePart()
        {
            bool dictOpen = false;
            foreach (object item in toolStrip1.Items)
            {
                if (item is ToolStripButton == false) continue;
                if (((ToolStripButton)item).Checked)
                {
                    dictOpen = true;
                    break;
                }
            }
            if (!dictOpen)
            {
                objectTable.Rows.Clear();
                objectTable.Columns.Clear();
            }
        }

        private void UncheckOtherBtns(object sender)
        {
            foreach (object item in toolStrip1.Items)
            {
                if (item is ToolStripButton == false) continue;
                if ((ToolStripButton)item != (ToolStripButton)sender) ((ToolStripButton)item).Checked = false;
            }
            ClearTablePart();

        }

        private void specCheckBtn_Click(object sender, EventArgs e)
        {
            UncheckOtherBtns(sender);
        }

        private void statusCheckBtn_Click(object sender, EventArgs e)
        {
            UncheckOtherBtns(sender);
        }

        private void stagesCheckBtn_Click(object sender, EventArgs e)
        {
            UncheckOtherBtns(sender);
        }

        private void typesCheckBtn_Click(object sender, EventArgs e)
        {
            UncheckOtherBtns(sender);
        }

        private void subtasksCheckBtn_Click(object sender, EventArgs e)
        {
            UncheckOtherBtns(sender);
        }

        private void hideEditorPanelBtn_Click(object sender, EventArgs e)
        {
            editorPanel.Hide();
        }

        private void addObject_Click(object sender, EventArgs e)
        {
            editorPanel.Show();
        }

        private void editObject_Click(object sender, EventArgs e)
        {
            editorPanel.Show();
        }

        private void backToMenuBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
