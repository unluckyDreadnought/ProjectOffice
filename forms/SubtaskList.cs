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
    public partial class SubtaskList : Form
    {
        Db _db = null;
        Project proj = null;
        string stageId = "";
        string subtaskId = "";
        string pointId = "";
        bool isResponsible = false;

        public SubtaskList(ref Project project)
        {
            InitializeComponent();
            proj = project;
            _db = new Db();
        }

        private async Task<bool> IsCurrentUserResponsible()
        {
            bool res = false;
            string query = $@"select IsResponsible from project_office.userproject 
where userproject.ProjectID = {proj.Id} and UserID = {AppUser.Id};";
            var task = _db.GetAsynNonReaderResult(_db.ExecuteScalarAsync(query));
            (object result, _) = await Common.GetNoScalarResult(task);
            if (result == DBNull.Value)
            {
                res = false;
            }
            else
            {
                res = Convert.ToBoolean(result);
            }
            return res;
        }

        private void HideObjectToAddCombo(bool visible = false)
        {
            objAddCombo.Enabled = objAddCombo.Visible = visible;
            objAddCombo.SelectedIndex = !visible ? -1 : 0;
        }

        private async Task CheckUserResponsibility(string clickedNodeName = "")
        {
            HideObjectToAddCombo(false);
            if (clickedNodeName == "")
            {
                isResponsible = await IsCurrentUserResponsible();
                return; 
            }
            if (clickedNodeName.Contains("stg"))
            {
                if (isResponsible) ChangeBtnsClickability(add: true);
                else
                {
                    MessageBox.Show("Взаимодействие со стадиями доступно только сотрудникам, назначенным ответственными.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ChangeBtnsClickability(add: false, edit: false, delete: false);
                    return;
                }
            }
            else if (clickedNodeName.Contains("sbtsk"))
            {
                if (isResponsible)
                {
                    HideObjectToAddCombo(true);
                    ChangeBtnsClickability(add: true, edit: false, delete: true);
                }
                else
                {
                    ChangeBtnsClickability(add: true);
                }
            }
            else if (clickedNodeName.Contains("cp"))
            {
                if (isResponsible) ChangeBtnsClickability(add: true, edit: true, delete: true);
                else
                {
                    Stage stgObj = proj.Stages.Where(stg => stg.Id == stageId).ToArray()[0];
                    Subtask sbtskObj = stgObj.subtasks.Where(sbtsk => sbtsk.Id == subtaskId).ToArray()[0];
                    if (AppUser.Id == sbtskObj.points.Where(p => p.Id == pointId).Select(p => p.AuthorId).ToArray()[0] || isResponsible)
                    {
                        ChangeBtnsClickability(add: true, edit: true, delete: true);
                    }
                    else
                    {
                        ChangeBtnsClickability(add: true);
                    }
                }
            }
            if (proj.Status == ((int)Status.Finish).ToString() || proj.Status == ((int)Status.Rejected).ToString())
            {
                ChangeBtnsClickability(add: false, edit: false, delete: false);
            }

        }

        private void ChangeBtnsClickability(bool add = false, bool edit = false, bool delete = false)
        {
            addBtn.Enabled = add;
            addBtn.Visible = add;
            editBtn.Enabled = edit;
            editBtn.Visible = edit;
            deleteBtn.Enabled = delete;
            deleteBtn.Visible = delete;
        }

        private async Task LoadProjectTree()
        {
            HideObjectToAddCombo(false);
            SetDescriptionVisibility();
            projectTree.Nodes.Clear();
            proj.Stages = await Stage.GetStages(proj.Id);
            int stgIndx = 0; ;
            while (stgIndx < proj.Stages.Count)
            {
                TreeNode stageNode = new TreeNode();
                stageNode.Text = proj.Stages[stgIndx].Title;
                stageNode.ToolTipText = proj.Stages[stgIndx].Title;
                stageNode.Name = $"stg_{proj.Stages[stgIndx].Id}";
                stageNode.Checked = false;

                int subtaskIndx = 0;
                while (subtaskIndx < proj.Stages[stgIndx].subtasks.Count)
                {
                    TreeNode subtaskNode = new TreeNode();
                    subtaskNode.Text = proj.Stages[stgIndx].subtasks[subtaskIndx].Title;
                    string sbtskDesc = proj.Stages[stgIndx].subtasks[subtaskIndx].Description;
                    if (sbtskDesc != "" && sbtskDesc != null) 
                    {
                        subtaskNode.ToolTipText = sbtskDesc;
                    }
                    else subtaskNode.ToolTipText = proj.Stages[stgIndx].subtasks[subtaskIndx].Title;
                    subtaskNode.Name = $"sbtsk_{proj.Stages[stgIndx].subtasks[subtaskIndx].Id}";
                    subtaskNode.Checked = false;
                    stageNode.Nodes.Add(subtaskNode);
                    
                    int cpIndx = 0;
                    while (cpIndx < proj.Stages[stgIndx].subtasks[subtaskIndx].points.Count)
                    {
                        TreeNode cpNode = new TreeNode();
                        string author = await Common.GetEmployee(proj.Stages[stgIndx].subtasks[subtaskIndx].points[cpIndx].AuthorId);
                        cpNode.Text = $"{proj.Stages[stgIndx].subtasks[subtaskIndx].points[cpIndx].Title} ({author})";
                        cpNode.ToolTipText = proj.Stages[stgIndx].subtasks[subtaskIndx].points[cpIndx].Title;
                        cpNode.Name = $"cp_{proj.Stages[stgIndx].subtasks[subtaskIndx].Id}";
                        subtaskNode.Nodes.Add(cpNode);
                        cpIndx++;
                    }

                    subtaskIndx++;
                }
                stgIndx++;
                projectTree.Nodes.Add(stageNode);
            }
            ColorNodes();
        }

        private void ColorNodes()
        {
            List<Stage> stages = proj.Stages;
            List<Stage> started = stages.Where(
                stg => stg.subtasks.Count > 0 && stg.subtasks.Where(sbtsk => sbtsk.points.Count > 0).ToArray().Length > 0
            ).ToList();
            if (started.Count == 0) return;
            List<List<Subtask>> subtasks = started.Select(stg => stg.subtasks).ToList();
            int stgIndx = 0;
            while (stgIndx < subtasks.Count)
            {
                subtasks[stgIndx] = subtasks[stgIndx].Where(stsk => stsk.points.Where(p => p.StatusId == ((int)Status.Finish).ToString()).ToArray().Length > 0).ToList();
                stgIndx++;
            }

            int level0 = 0;
            while (level0 < projectTree.Nodes.Count)
            {
                if (projectTree.Nodes[level0].Nodes.Count == 0)
                {
                    level0++;
                    continue;
                }
                int level1 = 0;
                int completedSbtsk = 0;
                while (level1 < projectTree.Nodes[level0].Nodes.Count)
                {
                    if (subtasks[level0].Select(s => s.Title).ToArray().Contains(projectTree.Nodes[level0].Nodes[level1].Text))
                    {
                        projectTree.Nodes[level0].Nodes[level1].ForeColor = Color.Gray;
                        int cpCount = 0;
                        while (cpCount < projectTree.Nodes[level0].Nodes[level1].Nodes.Count)
                        {
                            projectTree.Nodes[level0].Nodes[level1].Nodes[cpCount].ForeColor = Color.Gray;
                            if (cpCount == projectTree.Nodes[level0].Nodes[level1].Nodes.Count - 1)
                            {
                                projectTree.Nodes[level0].Nodes[level1].Nodes[cpCount].BackColor = Color.LightGray;
                            }
                            cpCount++;
                        }
                        completedSbtsk++;
                    }
                    level1++;
                }
                if (completedSbtsk == projectTree.Nodes[level0].Nodes.Count)
                {
                    projectTree.Nodes[level0].ForeColor = Color.Gray;
                }
                level0++;
            }
        }

        private async void SubtaskList_Load(object sender, EventArgs e)
        {
            this.Text = $"{Resources.APP_NAME}: Список этапов и подзадач";
            this.Icon = Resources.PROJECT_OFFICE_ICON;
            if (AppUser.Role != UserRole.Employee)
            {
                employeePanel.Hide();
            }
            await LoadProjectTree();
            ChangeBtnsClickability();
            await CheckUserResponsibility();
        }

        private void SetDescriptionVisibility(bool visible = false)
        {
            TableLayoutColumnStyleCollection styles = nodesDescLayout.ColumnStyles;
            styles[0].SizeType = SizeType.Percent;
            styles[1].SizeType = SizeType.Percent;

            styles[0].Width = 65;
            styles[1].Width = visible ? 35 : 0;
            if (!visible) descLbl.Text = "";
        }

        private async void projectTree_MouseClick(object sender, MouseEventArgs e)
        {
            SetDescriptionVisibility();
            TreeViewHitTestInfo info = projectTree.HitTest(e.X, e.Y);
            if (info.Location == TreeViewHitTestLocations.PlusMinus) return;
            if (info.Node.Name.Contains("stg"))
            {
                pointId = "";
                subtaskId = "";
                stageId = info.Node.Name.Split('_')[1];
            }
            else if (info.Node.Name.Contains("sbtsk"))
            {
                pointId = "";
                subtaskId = info.Node.Name.Split('_')[1];
                stageId = info.Node.Parent.Name.Split('_')[1];
                if (info.Node.ToolTipText != info.Node.Text)
                {
                    descLbl.Text = info.Node.ToolTipText;
                    SetDescriptionVisibility(true);
                }
            }
            else if (info.Node.Name.Contains("cp"))
            {
                pointId = info.Node.Name.Split('_')[1];
                subtaskId = info.Node.Parent.Name.Split('_')[1];
                stageId = info.Node.Parent.Parent.Name.Split('_')[1];
            }

            await CheckUserResponsibility(info.Node.Name);
            ;
        }

        private async void addBtn_Click(object sender, EventArgs e)
        {
            Form form = null;
            TreeNode node = projectTree.SelectedNode;
            if (node == null) return;
            switch (node.Level)
            {
                case 0:
                    {
                        if (isResponsible)
                        {
                            form = new SubtaskEditor(ref proj, stageId);
                        }
                        break;
                    }
                case 1:
                    {
                        if (isResponsible && objAddCombo.SelectedIndex == 0)
                        {
                            form = new SubtaskEditor(ref proj, stageId);
                        }
                        else
                        {
                            form = new ControlPointEditor(ref proj, stageId, subtaskId);
                        }
                        break;
                    }
                case 2:
                    {
                        form = new ControlPointEditor(ref proj, stageId, subtaskId);
                        break;
                    }
                default: return;
            }
            if (form != null) form.ShowDialog();
            await LoadProjectTree();
        }

        private async void editBtn_Click(object sender, EventArgs e)
        {
            Form form = null;
            TreeNode node = projectTree.SelectedNode;
            if (node == null) return;
            switch (node.Level)
            {
                case 2:
                    {
                        form = new ControlPointEditor(ref proj, stageId, subtaskId, pointId);
                        break;
                    }
                default: return;
            }
            if (form != null) form.ShowDialog();
            await LoadProjectTree();
        }

        private async void deleteBtn_Click(object sender, EventArgs e)
        {
            if (projectTree.SelectedNode == null)
            {
                MessageBox.Show("Выберите объект для удаления из проекта", "Операция удаления", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            switch (projectTree.SelectedNode.Level)
            {
                case 1:
                    {
                        string delMsg = $"Вы действительно хотите удалить узел '{projectTree.SelectedNode.Text}'.";
                        if (projectTree.SelectedNode.Nodes.Count > 0 )
                        {
                            delMsg += "\nЕсли узел содержал дочерние объекты, последние будут безвозвратно стёрты.";
                        }
                            
                        if (DialogResult.OK == MessageBox.Show(delMsg, "Операция удаления", MessageBoxButtons.OK, MessageBoxIcon.Warning))
                        {
                            (object result, _) = await Subtask.UnlinkByStgProjLinks(await Stage.GetStageLinkID(proj.Id, stageId));
                            int r = Convert.ToInt32(result);
                            if (r == 0) 
                            {
                                MessageBox.Show($"Удаление узела из проекта '{projectTree.SelectedNode.Text}' не было произведено", 
                                    "Операция удаления", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                            else if (r > 0)
                            {
                                MessageBox.Show($"Удаление произведено успешно.\nИз проекта удалено {r} объектов", 
                                    "Операция удаления", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                        break;
                    }
                case 2:
                    {
                        string delMsg = $"Вы действительно хотите удалить узел '{projectTree.SelectedNode.Text}'.";

                        if (DialogResult.OK == MessageBox.Show(delMsg, "Операция удаления", MessageBoxButtons.OK, MessageBoxIcon.Warning))
                        {
                            (object result, _) = await ControlPoint.Delete(pointId);
                            int r = Convert.ToInt32(result);
                            if (r == 0)
                            {
                                MessageBox.Show($"Удаление узела из проекта '{projectTree.SelectedNode.Text}' не было произведено",
                                    "Операция удаления", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                            else if (r > 0)
                            {
                                MessageBox.Show($"Удаление произведено успешно.\nИз проекта удалено {r} объектов",
                                    "Операция удаления", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                        break;
                    }
                default: break;
            }
            await LoadProjectTree();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
