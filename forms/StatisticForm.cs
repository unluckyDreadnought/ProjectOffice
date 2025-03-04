using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Windows.Forms.DataVisualization.Charting;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProjectOffice.logic;
using ProjectOffice.logic.app;
using ProjectOffice.Properties;
using Excel = Microsoft.Office.Interop.Excel;

namespace ProjectOffice.forms
{
    public partial class StatisticForm : Form
    {
        private Db _db = null;

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

        private void SaveReport()
        {
            string[] arr;
            string template = $@"{Directory.GetParent(Directory.GetParent(Application.StartupPath).FullName).FullName}\templates\stats.xlsx";
            Excel.Application app = new Excel.Application();
            if (app == null)
            {
                MessageBox.Show("Не удалось создать отчёт", "Отчёт Excel", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            app.Visible = false;
            //Excel.Workbooks workbooks = app.Workbooks;
            //Excel.Workbook book = workbooks.Add(Excel.XlWBATemplate.xlWBATWorksheet);
            Excel.Workbook wb;
            Excel.Worksheet ws;
            wb = app.Workbooks.Open(template);
            ws = wb.Worksheets[1];

            Excel.Range cell = ws.Range["A3:A3"];
            cell.Value = DateTime.Now.ToString("g");
            cell = ws.Range["D3:D3"];
            cell.Value = AppUser.Snp;

            string basePath = $@"C:\Users\{Environment.UserName}\Documents\myfile.xlsx";

            MessageBox.Show($"Файл будет сохранён по пути {basePath}", "Сохранение отчёта Excel", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ws.Columns.AutoFit();

            wb.SaveAs(basePath);
            wb.Close();
            app.Quit();
            ;
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
            int active = 0;
            int completed = 0;
            int rejected = 0;
            int outOfDate = 0;

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
            SaveReport();
        }
    }
}
