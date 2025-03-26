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
    public partial class ControlPointEditor : Form
    {
        Db _db = new Db();
        Project proj = null;
        string stageId = null;
        string subtaskId = null;
        Stage st = null;
        Subtask sbt = null;
        ControlPoint point = null;
        string pointId = null;
        string[] titles = null;

        private void GetObjects()
        {
            st = proj.Stages.Where(stg => stg.Id == stageId).ToArray()[0];
            sbt = st.subtasks.Where(sbtsk => sbtsk.Id == subtaskId).ToArray()[0];
            if (pointId != null) point = sbt.points.Where(cp => cp.Id == pointId).ToArray()[0];
        }

        public ControlPointEditor(ref Project project, string stgId, string sbtskId)
        {
            InitializeComponent();
            proj = project;
            stageId = stgId;
            subtaskId = sbtskId;
            GetObjects();
        }

        public ControlPointEditor(ref Project project, string stgId, string sbtskId, string pntId)
        {
            InitializeComponent();
            proj = project;
            stageId = stgId;
            subtaskId = sbtskId;
            pointId = pntId;
            GetObjects();
        }

        private async Task FillByStoredData()
        {
            if (point != null)
            {
                mainTxt.Text = (point.Title != null && point.Title != "") ? point.Title : "";
                descTxt.Text = (point.Description != null && point.Description != "") ? point.Description : "";
                if (point.StatusId == ((int)Status.Work).ToString())
                {
                    statusCombo.SelectedItem = statusCombo.Items[0];
                }
                else
                {
                    statusCombo.SelectedItem = statusCombo.Items[1];
                }
            }
            else 
            {
                if (pointId != null) point = await ControlPoint.GetById(pointId);
                else return;
            }
        }

        private async Task<string> GetStatusId(string statusTitle)
        {
            string query = $"select StatusID from status where StatusTitle = '{statusTitle}';";
            var task = _db.GetAsynNonReaderResult(_db.ExecuteScalarAsync(query));
            (object res, _) = await Common.GetNoScalarResult(task);
            return res.ToString();
        }

        private async Task CheckFieldFilling()
        {
            bool filled = true;

            if (pointId != null)
            {
                string desc = descTxt.Text.Trim().Contains("Опишите проделанные действия...") ? descTxt.Text.Trim().Replace("Опишите проделанные действия...", "") : descTxt.Text.Trim();
                string dbDesc = (point.Description != null && point.Description != "") ? point.Description : "";
                filled = false || mainTxt.Text != point.Title;
                filled = filled || desc != dbDesc;
                filled = filled || await GetStatusId(statusCombo.SelectedItem.ToString()) != point.StatusId;
            }

            filled = filled && mainTxt.Text.Trim().Length > 0;
            filled = filled && Convert.ToInt32(await GetStatusId(statusCombo.SelectedItem.ToString())) > 0;

            addBtn.Enabled = filled;
        }

        private async Task FillStatuses()
        {
            statusCombo.Items.Clear();
            string query = $"select StatusTitle from {Db.Name}.status where StatusID in (2, 5);";
            var task = _db.ExecuteReaderAsync(query);
            DataTable dt = await Common.GetAsyncResult(task);
            if (dt.Rows.Count == 0) return;
            int indx = 0;
            while (indx < dt.Rows.Count)
            {
                statusCombo.Items.Add(dt.Rows[indx][0].ToString());
                indx++;
            }
            statusCombo.SelectedIndex = 0;
        }

        private async void ControlPointEditor_Load(object sender, EventArgs e)
        {
            await FillStatuses();
            if (pointId != null) 
            {
                point = await ControlPoint.GetById(pointId);
                await FillByStoredData();
                titles = new string[] { "Изменение", "Изменить" };
            } 
            else titles = new string[] { "Добавление", "Добавить" };
            this.Text = $"{Resources.APP_NAME} - {titles[0]} контрольной точки";
            this.Icon = Resources.PROJECT_OFFICE_ICON;
            addBtn.Text = titles[1];

            projNumLbl.Text = $"Проект #{proj.Id}";
            stageName.Text = st.Title;
            subtaskTitle.Text = sbt.Title;

            await CheckFieldFilling();
        }

        private void SetDescriptionPlaceholder()
        {
            if (descTxt.Text.Trim().Length == 0)
            {
                descTxt.ForeColor = Color.Gray;
                descTxt.Text = "Опишите проделанные действия...";
            }
            else return;
        }

        private void EraseDescriotionPlaceholder()
        {
            if (descTxt.Text.Trim() == "Опишите проделанные действия...")
            {
                descTxt.ForeColor = Color.Black;
                descTxt.Text = "";
            }
            else return;
        }

        private async void addBtn_Click(object sender, EventArgs e)
        {
            Status s = Convert.ToInt32(await GetStatusId(statusCombo.SelectedItem.ToString())) == (int)Status.Work ? Status.Work : Status.Finish;
            string desc = descTxt.Text.Trim() == "Опишите проделанные действия..." ? null : descTxt.Text.Trim();
            int n = -1;
            if (pointId != null)
            {
                n = await sbt.UpdateControlPoint(point.Id, mainTxt.Text.Trim(), s, desc);
            }
            else
            {
                n = await sbt.AddControlPoint(proj.Id, mainTxt.Text.Trim(), s, desc);
            }
            if (n == -1) return;
            else if (n == 0)
            {
                MessageBox.Show($"{titles[0]} контрольной точки не внесло изменений в проект.");
                await FillByStoredData();
            }
            else
            {
                MessageBox.Show($"{titles[0]} контрольной точки прошло успешно.");
                this.Close();
            }
        }

        private void backToTree_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void control_Changed(object sender, EventArgs e)
        {
            await CheckFieldFilling();
        }

        private void mainTxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Symbols.ru_alp.Contains(Char.ToLower(e.KeyChar)) || e.KeyChar == (int)Keys.Space || e.KeyChar == (int)Keys.Delete || e.KeyChar == (int)Keys.Back)
            {
                return;
            }
            else e.Handled = true;
        }

        private void descTxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar) || "-.,;()\"".Concat(Symbols.ru_alp).Concat(Symbols.en_alp).Contains(Char.ToLower(e.KeyChar)) || 
                e.KeyChar == (int)Keys.Enter || e.KeyChar == (int)Keys.Space || e.KeyChar == (int)Keys.Delete || e.KeyChar == (int)Keys.Back)
            {
                return;
            }
            else e.Handled = true;
        }
    }
}
