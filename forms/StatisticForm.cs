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
        private Db _db = null;

        private int active = 0;
        private int completed = 0;
        private int rejected = 0;
        private int outOfDate = 0;

        Excel.Application app = null;
        Excel.Workbooks wbs = null;
        Excel.Workbook wb = null;
        Excel.Worksheet ws = null;

        string baseSavePath = "";

        private void FullCloseExcel()
        {
            if (wb != null)
            {
                wb.Close();
            }
            if (wbs != null)
            {
                wbs.Close();
            }
            if (app != null)
            {
                app.Application.Quit();
                app.Quit();
            }
            ReleaseExcel();
        }

        private void ReleaseExcel()
        {
            ReleaseObject(ws);
            ReleaseObject(wb);
            ReleaseObject(wbs);
            ReleaseObject(app);
            wbs = null;
            ws = null;
            wb = null;
            app = null;
        }

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
            int[] counts = new int[] { active, rejected, outOfDate, completed, -1, active + rejected + completed };

            string template = $@"{Directory.GetParent(Directory.GetParent(Application.StartupPath).FullName).FullName}\templates\stats.xlsx";

            baseSavePath = $@"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\myfile.xlsx";

            try
            {
                app = new Excel.Application();

                if (app == null)
                {
                    MessageBox.Show("Не удалось создать отчёт", "Отчёт Excel", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                app.Visible = true;
                app.Visible = false;

                wbs = app.Workbooks;
                wb = wbs.Open(template);
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

                app.Visible = true;

                wb.SaveAs(baseSavePath);
                FullCloseExcel();

                if (app == null) app = new Excel.Application();
                wbs = app.Workbooks;
                wb = wbs.Open(baseSavePath);
                ws = wb.Worksheets[1];

                app.Visible = true;

                ReleaseExcel();
            }
            catch (Exception e)
            {
                ;
                FullCloseExcel();
            }
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
            else {; }
        }

        private void statsReportBtn_Click(object sender, EventArgs e)
        {
            SaveReport(rejected, active, outOfDate, completed);
        }


        private void ReleaseObject(object obj)
        {
            try
            {
                Marshal.FinalReleaseComObject(obj);
                Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception e)
            {
                obj = null;
            }
            finally
            {
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
        }
    }
}
