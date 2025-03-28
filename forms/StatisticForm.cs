using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms.DataVisualization.Charting;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProjectOffice.logic;
using ProjectOffice.logic.app;
using ProjectOffice.Properties;

namespace ProjectOffice.forms
{
    public partial class StatisticForm : Form
    {
        private Db _db = null;

        private int active = 0;
        private int completed = 0;
        private int rejected = 0;
        private int outOfDate = 0;

        string baseSavePath = "";

        Project proj = null;

        private void DrawChartOnData(int rejected, int active, int outOfDate, int completed)
        {
            int[] data = new int[] { rejected, active, outOfDate, completed };
            string[] titles = new string[] { "Отклонённые", "Активные", "Просрочные", "Завершённые" };
            allProjectStatsChart.Series.Clear();
            allProjectStatsChart.Series.Add(new Series("DataSeries") {
                ChartType = SeriesChartType.Pie
            });
            //allProjectStatsChart.Series["DataSeries"].LegendText = "Проекты";
            allProjectStatsChart.Series["DataSeries"].Points.DataBindXY(titles, data);
            allProjectStatsChart.Series["DataSeries"].Label = "#PERCENT{P}";
            allProjectStatsChart.Series["DataSeries"].LegendText = "#VALX";
        }

        private async Task<DataTable> GetCommonStats()
        {
            string query = $@"select StatusTitle, case when (StatusTitle != 'Завершено' && StatusTitle != 'Отклонён') && ProjectPlanEndDate < now()  then 1 else 0 end from {Db.Name}.project 
inner join {Db.Name}.status on status.StatusID = project.ProjectStatusID
order by StatusTitle;";
            var task = _db.ExecuteReaderAsync(query);
            DataTable dt = await Common.GetAsyncResult(task);
            return dt;
        }

        private async void FillCommonStats()
        {
            DataTable dt = await GetCommonStats();
            int i = 0, total = 0;

            while (i < dt.Rows.Count)
            {
                switch (dt.Rows[i].ItemArray[0].ToString())
                {
                    case "Новый":
                    case "В работе":
                    case "Подготовка к завершению":
                    case "Согласование":
                        {
                            if (Convert.ToInt32(dt.Rows[i].ItemArray[1]) == 1)
                            {
                                outOfDate++;
                            }
                            active++;
                            break;
                        }
                    case "Отклонён": rejected++; break;
                    case "Завершено": completed++; break;
                }
                total++;
                i++;
            }

            DrawChartOnData(rejected, active, outOfDate, completed);

            activeProjectsCountLbl.Text = $"{active}";
            completedProjectsCountLbl.Text = $"{completed}";
            rejectedProjectsCountLbl.Text = $"{rejected}";
            outOfDateProjectsCount.Text = $"{outOfDate}";
            totalProjectCountLbl.Text = $"{total}";
        }

        public StatisticForm()
        {
            InitializeComponent();
            _db = new Db();
        }

        private void backToMenu_Click(object sender, EventArgs e)
        {
            GC.Collect();
            this.Close();
        }

        private void StatisticForm_Load(object sender, EventArgs e)
        {
            this.Text = $"{Resources.APP_NAME}: Просмотр статистики";
            this.Icon = Resources.PROJECT_OFFICE_ICON;
            FillCommonStats();
        }

        private async Task<string[]> GetActiveProjects()
        {
            string query = "select ProjectTitle from project where ProjectStatusID not in (5,6);";
            return Common.DataTableToStringArray(await Common.GetAsyncResult(_db.ExecuteReaderAsync(query)));
        }

        private async Task FillProjectCombo()
        {
            projectStatsCombo.Items.Clear();
            string[] projectTitles = await GetActiveProjects();
            if (projectTitles.Length > 0)
            {
                projectStatsCombo.Items.AddRange(projectTitles);
            }       
        }

        private async void statsTabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (statsTabControl.SelectedIndex == 0)
            {
                FillCommonStats();
            }
            else {
                await FillProjectCombo();
            }
        }

        private async void statsReportBtn_Click(object sender, EventArgs e)
        {
            if (statsTabControl.SelectedIndex == 1)
            {
                if (projectStatsCombo.SelectedItem == null)
                {
                    MessageBox.Show("Сначала выберите проект", "Создание отчёта", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            SaveFileDialog fileDialog = new SaveFileDialog();
            fileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            fileDialog.Filter = "Электронная таблица Excel (*.xlsx)|*.xlsx";
            fileDialog.DefaultExt = "xlsx";
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                if (fileDialog.FileName != "") baseSavePath = fileDialog.FileName;
            }
            Reports.SetBasePath(baseSavePath);
            MessageBox.Show($"Файл будет сохранён по пути '{Reports.baseSavePath}'", "Сохранение отчёта Excel", MessageBoxButtons.OK, MessageBoxIcon.Information);

            string text = "";
            bool isError = false;
            if (statsTabControl.SelectedIndex == 0) (text, isError) = Reports.SaveCommonStatsReport(rejected, active, outOfDate, completed, Reports.baseSavePath);
            else (text, isError) = await Reports.SaveStatsOnProject(proj, Reports.baseSavePath);
            if (text != null && isError)
            {
                MessageBox.Show(text, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private async Task FillProjectProgress(Project proj)
        {
            proj.Stages = await Stage.GetStages(proj.Id);
            int allSbtskCount = 0;
            int completedSbtsks = 0;
            int stgIndx = 0;
            while (stgIndx < proj.Stages.Count)
            {
                allSbtskCount += proj.Stages[stgIndx].subtasks.Count;
                int sbtskIndx = 0;
                while (sbtskIndx < proj.Stages[stgIndx].subtasks.Count)
                {
                    ControlPoint[] finished = proj.Stages[stgIndx].subtasks[sbtskIndx].points.Where(pnt => pnt.StatusId == ((int)Status.Finish).ToString()).ToArray();
                    if (finished.Length > 0) completedSbtsks++;
                    sbtskIndx++;
                }
                stgIndx++;
            }

            float completePercents = 0;
            try
            {
                completePercents = ((float)completedSbtsks / allSbtskCount)*100;
            }
            catch (DivideByZeroException)
            {
                completePercents = 0;
            }
            completePercents = (completePercents is float.NaN) ? 0 : completePercents;
            projectCompleteStatusBar.Value = Convert.ToInt32(Math.Ceiling(completePercents));
            statusLbl.Text = $"{completedSbtsks}/{allSbtskCount} ({Math.Round(completePercents, 2)}%)";
        }

        private async void projectStatsCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            string query = $"select ProjectID from {Db.Name}.project where ProjectTitle = '{projectStatsCombo.SelectedItem.ToString()}'";
            string[] id = Common.DataTableToStringArray(await Common.GetAsyncResult(_db.ExecuteReaderAsync(query)));
            if (id.Length == 0)
            {
                MessageBox.Show("Проект не найден", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            proj = await Project.InitilazeAsync(id[0]);
            await Common.LoadProjectTree(statsProjectTree, proj);
            await FillProjectProgress(proj);
        }

        private void StatisticForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            GC.Collect();
        }
    }
}
