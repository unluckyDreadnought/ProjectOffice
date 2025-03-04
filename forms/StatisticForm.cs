using System;
using System.Data;
using System.IO;
using System.Windows.Forms.DataVisualization.Charting;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProjectOffice.logic;
using ProjectOffice.logic.app;
using ProjectOffice.Properties;
using Excel = Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace ProjectOffice.forms
{
    public partial class StatisticForm : Form
    {
        private bool _activeted = false;
        private Db _db = null;

        private int active = 0;
        private int completed = 0;
        private int rejected = 0;
        private int outOfDate = 0;

        Excel.Application app = null;
        Excel.Workbook wb = null;
        Excel.Worksheet ws = null;

        string baseSavePath = "";

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

        private void SaveReport(int rejected, int active, int outOfDate, int completed)
        {
            string[] arr = new string[] { "Активные проекты", "Отменённые проекты", "Просроченные активные проекты", "Завершённые проекты", "", "Всего" };
            int[] counts = new int[] { active, rejected, outOfDate, completed, -1, active+rejected+completed };

            string template = $@"{Directory.GetParent(Directory.GetParent(Application.StartupPath).FullName).FullName}\templates\stats.xlsx";

            baseSavePath = $@"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\myfile.xlsx";

            try
            {
                app = new Excel.Application();
                app.WindowDeactivate += App_WindowDeactivate;
                
                app.WorkbookBeforeClose += App_WorkbookBeforeClose;

                if (app == null)
                {
                    MessageBox.Show("Не удалось создать отчёт", "Отчёт Excel", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                app.Visible = false;

                wb = app.Workbooks.Open(template);
                ws = wb.Worksheets[1];

                ws.Range["A3"].Value = DateTime.Now.ToString("g");
                ws.Range["D3"].Value = AppUser.Snp;

                int indx = 0;
                int row = 6;

                // заполнение таблицы количества групп проектов
                while (indx < counts.Length)
                {
                    ws.Range[$"A{row + indx}"].Value = arr[indx];
                    if (counts[indx] >= 0) ws.Range[$"B{row + indx}"].Value = counts[indx];
                    indx++;
                }

                SaveFileDialog fileDialog = new SaveFileDialog();
                fileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                fileDialog.Filter = "Электронная таблица Excel (*.xlsx)|*.xlsx";
                fileDialog.DefaultExt = "xlsx";
                if (fileDialog.ShowDialog() == DialogResult.OK)
                {
                    if (fileDialog.FileName != "") baseSavePath = fileDialog.FileName;
                }

                MessageBox.Show($"Файл будет сохранён по пути '{baseSavePath}'", "Сохранение отчёта Excel", MessageBoxButtons.OK, MessageBoxIcon.Information);

                ws.Columns.AutoFit();
                wb.SaveAs(baseSavePath);
                if (wb != null) wb.Close();
                if (app == null) app = new Excel.Application();
                wb = app.Workbooks.Open(baseSavePath);
                ws = wb.Worksheets[1];

                app.Visible = true;
                _activeted = true;
            }
            catch (Exception)
            {
                if (wb != null) wb.Close();
                if (app != null) app.Quit();
            }
        }

        private void App_WindowDeactivate(Excel.Workbook Wb, Excel.Window Wn)
        {
            if (wb != null)
            {
                wb.Close();
                wb = null;
            }
            if (app != null) app.Quit();
            if (app != null) Marshal.FinalReleaseComObject(app);
            app = null;
        }

        private void App_WorkbookBeforeClose(Excel.Workbook Wb, ref bool Cancel)
        {
            try
            {
                if (wb != null) wb.Save();
            }
            catch (Exception) { ; }
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
                    case "Завершено": completed++;  break;
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
            this.Close();
        }

        private void StatisticForm_Load(object sender, EventArgs e)
        {
            this.Text = $"{Resources.APP_NAME}: Просмотр статистики";
            this.Icon = Resources.PROJECT_OFFICE_ICON;
            FillCommonStats();
            _activeted = true;
        }

        private void statsTabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (statsTabControl.SelectedIndex == 0)
            {
                FillCommonStats();
            }
            else { ; }
        }

        private void statsReportBtn_Click(object sender, EventArgs e)
        {
            SaveReport(rejected, active, outOfDate, completed);
        }

        private void StatisticForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Process[] pro = Process.GetProcessesByName("excel");
            foreach (Process p in pro)
            {
                p.Kill();
            }
        }

        private void StatisticForm_Activated(object sender, EventArgs e)
        {
            if (_activeted) return;
            Process[] pro = Process.GetProcessesByName("excel");
            foreach (Process p in pro)
            {
                try
                {
                    p.Kill();
                }
                catch (Exception) {; }
            }
            _activeted = false;
        }
    }
}
