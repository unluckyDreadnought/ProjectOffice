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
    public partial class SubtaskEditor : Form
    {
        Db _db = new Db();
        Project proj = null;
        string stgId = null;

        public SubtaskEditor(ref Project project, string stageId)
        {
            InitializeComponent();
            proj = project;
            stgId = stageId;
            _db = new Db();
        }

        private void CheckFieldsFilling()
        {
            bool filled = false;
            filled = true && subtaskCombo.Text.Trim() != "Подзадача не выбрана" && subtaskCombo.Text.Trim().Length > 0;

            addSubtask.Enabled = filled;
        }

        private async Task FillSubtaskCombo()
        {
            subtaskCombo.Items.Clear();
            subtaskCombo.Items.Add("Подзадача не выбрана");
            subtaskCombo.SelectedIndex = 0;

            string query = "select SubtaskTitle from subtask;";
            var task = _db.ExecuteReaderAsync(query);
            string[] titles = Common.DataTableToStringArray(await Common.GetAsyncResult(task));
            if (titles.Length == 0) return;
            subtaskCombo.Items.AddRange(titles);
            subtaskCombo.AutoCompleteCustomSource.AddRange(titles);
        }

        private void SetDescriptionPlaceholder()
        {
            subtaskDescTxt.ForeColor = Color.Gray;
            subtaskDescTxt.Text = "Опишите подзадачу здесь...";
        }

        private void EraseDescriptionPlaceholder()
        {
            if (subtaskDescTxt.Text == "Опишите подзадачу здесь...")
            {
                subtaskDescTxt.ForeColor = Color.Black;
                subtaskDescTxt.Text = "";
            }
            else return;
        }

        private async void SubtaskEditor_Load(object sender, EventArgs e)
        {
            this.Text = $"{Resources.APP_NAME}:  Добавление подзадачи в проект";
            this.Icon = Resources.PROJECT_OFFICE_ICON;
            projectNumLbl.Text = $"Проект #{proj.Id}";
            stageName.Text = proj.Stages.Where(stg => stg.Id == stgId).Select(stg => stg.Title).ToArray()[0];
            await FillSubtaskCombo();
            SetDescriptionPlaceholder();
            CheckFieldsFilling();
        }

        private void backToTree_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void addSubtask_Click(object sender, EventArgs e)
        {
            Stage stgObj = proj.Stages.Where(stg => stg.Id == stgId).ToArray()[0];
            if (subtaskDescTxt.Text == "Опишите подзадачу здесь...")
            {
                await stgObj.AddSubtask(subtaskCombo.Text.Trim());
            }
            else
            {
                await stgObj.AddSubtask(subtaskCombo.Text.Trim(), subtaskDescTxt.Text.Trim());
            }

            subtaskDescTxt.Text = "";
            subtaskCombo.Text = "Подзадача не выбрана";
            this.Close();
        }

        private void subtaskCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckFieldsFilling();
        }

        private void subtaskDescTxt_TextChanged(object sender, EventArgs e)
        {
            CheckFieldsFilling();
        }

        private void subtaskCombo_TextChanged(object sender, EventArgs e)
        {
            CheckFieldsFilling();
        }

        private void subtaskName_KeyPressed(object sender, KeyPressEventArgs e)
        {
            if (Symbols.ru_alp.Contains(Char.ToLower(e.KeyChar)) || e.KeyChar == ' ' || e.KeyChar == 8 || e.KeyChar == 127)
            {
                return;
            }
            else e.Handled = true;
        }

        private void subtaskDesc_KeyPressed(object sender, KeyPressEventArgs e)
        {
            if (Symbols.ru_alp.Concat(Symbols.en_alp).Contains(Char.ToLower(e.KeyChar)) || Char.IsDigit(e.KeyChar) || " -.();,".Contains(e.KeyChar) || e.KeyChar == 8 || e.KeyChar == 127)
            {
                return;
            }
            else e.Handled = true;
        }

        private void subtaskDescTxt_Click(object sender, EventArgs e)
        {
            EraseDescriptionPlaceholder();
            CheckFieldsFilling();
        }

        private void subtaskDescTxt_Leave(object sender, EventArgs e)
        {
            if (subtaskDescTxt.Text.Trim().Length == 0) SetDescriptionPlaceholder();
            CheckFieldsFilling();
        }

        private void subtaskCombo_Click(object sender, EventArgs e)
        {
            if (subtaskCombo.Text.Trim() == "Подзадача не выбрана")
            {
                subtaskCombo.Text = "";
            }
            else return;
        }

        private void subtaskCombo_Leave(object sender, EventArgs e)
        {
            if (subtaskCombo.Text.Trim().Length == 0)
            {
                subtaskCombo.Text = "Подзадача не выбрана";
            }
            else return;
        }
    }
}
