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
        Project proj = null;
        public SubtaskList(Project project)
        {
            InitializeComponent();
            proj = project;
        }

        private async Task LoadProjectTree()
        {
            proj.Stages = await Stage.GetStages(proj.Id);
            int stgIndx = 0;
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
                    subtaskNode.ToolTipText = proj.Stages[stgIndx].subtasks[subtaskIndx].Title;
                    subtaskNode.Name = $"stsk_{proj.Stages[stgIndx].subtasks[subtaskIndx].Id}";
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
                if (projectTree.Nodes[level0].Nodes.Count == 0) continue;
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
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SubtaskEditor subtaskEdit = new SubtaskEditor();
            subtaskEdit.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ControlPointEditor cpEditor = new ControlPointEditor();
            cpEditor.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            Form form = null;
            TreeNode node = projectTree.SelectedNode;
            if (node == null) return;
            switch (node.Level)
            {
                case 0: form = new SubtaskEditor(); break;
                case 1: form = new ControlPointEditor(); break;
                default: return;
            }
            if (form != null) form.ShowDialog();
        }
    }
}
