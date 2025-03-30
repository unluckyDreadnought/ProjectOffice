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
            if (proj.Status == ((int)Status.Finish).ToString() || proj.Status == ((int)Status.Rejected).ToString() || proj.Status == ((int)Status.PreparingToEnd).ToString())
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
            await Common.LoadProjectTree(projectTree, proj);
        }

        private async void SubtaskList_Load(object sender, EventArgs e)
        {
            this.Text = $"{Resources.APP_NAME}: Список этапов и подзадач";
            this.Icon = Resources.PROJECT_OFFICE_ICON;
            if (AppUser.Role != UserRole.Employee)
            {
                employeePanel.Hide();
                backBtn.Text = "К проекту";
            }
            backBtn.Text = "К списку проектов";
            await LoadProjectTree();
            ChangeBtnsClickability();
            await CheckUserResponsibility();
            rejectProject.Enabled = rejectProject.Visible = proj.Status == ((int)Status.New).ToString() && DateTime.Now.Subtract(DateTime.Parse(proj.StartDate)).Days < 2;
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
                        string delMsg = $"Вы действительно хотите удалить узел '{projectTree.SelectedNode.Text}'?";
                        if (projectTree.SelectedNode.Nodes.Count > 0 )
                        {
                            delMsg += "\nЕсли узел содержал дочерние объекты, последние будут безвозвратно стёрты.";
                        }
                            
                        if (DialogResult.Yes == MessageBox.Show(delMsg, "Операция удаления", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                        {
                            (object result, _) = await Subtask.UnlinkSubtaskIds(proj.Id, subtaskId);
                            int r = Convert.ToInt32(result);
                            if (r == 0) 
                            {
                                MessageBox.Show($"Удаление узела из проекта '{projectTree.SelectedNode.Text}' не было произведено", 
                                    "Операция удаления", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                            else if (r > 0)
                            {
                                await _db.LogToEventJournal(EventJournal.EventType.DeleteObject, this);
                                MessageBox.Show($"Удаление произведено успешно.\nИз проекта удалено {r} объектов", 
                                    "Операция удаления", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                        break;
                    }
                case 2:
                    {
                        string delMsg = $"Вы действительно хотите удалить узел '{projectTree.SelectedNode.Text}'?";

                        if (DialogResult.Yes == MessageBox.Show(delMsg, "Операция удаления", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
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
                                await _db.LogToEventJournal(EventJournal.EventType.DeleteObject, this);
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

        private async void rejectProject_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы точно хотите отказаться от проекта? Проект бесповоротно будет закрыт.", "Отклонение проекта", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                await proj.Update(new ProjectField[] { ProjectField.Status }, new string[] { ((int)Status.Rejected).ToString() });
                await _db.LogToEventJournal(EventJournal.EventType.ChangeObject, this);
                MessageBox.Show("Проект закрыт по причине отказа.", "Отклонение проекта", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
