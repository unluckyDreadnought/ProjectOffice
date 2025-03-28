using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.InteropServices;
using Excel = Microsoft.Office.Interop.Excel;
using Word = Microsoft.Office.Interop.Word;
using ProjectOffice.Properties;
using System.Windows.Forms;
using ProjectOffice.logic.app;


namespace ProjectOffice.logic
{
    public static class Reports
    {
        private static string _basePath = $@"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\";
        public static string baseSavePath {
            get {
                return _basePath;
            } 
        }

        public static void SetBasePath(string path)
        {
            if (Directory.Exists(path.Replace(Path.GetFileName(path), ""))) _basePath = path;
            else _basePath = $@"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\";

        }

        private static Excel.Application app = null;
        private static Excel.Workbooks wbs = null;
        private static Excel.Workbook wb = null;
        private static Excel.Worksheet ws = null;

        private static void ReleaseObject(object obj)
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

        private static void ReleaseExcel()
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

        private static void FullCloseExcel()
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

        // (описание, это_ошибка?)
        public static (string, bool) SaveCommonStatsReport(int rejected, int active, int outOfDate, int completed, string notBasePath = null)
        {
            string path = baseSavePath;
            string[] arr = new string[] { "Активные проекты", "Отменённые проекты", "Просроченные активные проекты", "Завершённые проекты", "", "Всего" };
            int[] counts = new int[] { active, rejected, outOfDate, completed, -1, active + rejected + completed };

            string template = $@"{Directory.GetParent(Directory.GetParent(Application.StartupPath).FullName).FullName}\templates\stats.xlsx";

            if (notBasePath == null)
            {
                path += $"Общий_отчёт_по_проектам_{DateTime.Now.ToString("d_T")}.xlsx";
            }
            else
            {
                path = notBasePath;
            }
            

            try
            {
                app = new Excel.Application();

                if (app == null)
                {
                    return ("Не удалось создать отчёт", true);
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

                ws.Columns.AutoFit();
                app.Visible = true;
                wb.SaveAs(path);
                FullCloseExcel();

                if (app == null) app = new Excel.Application();
                wbs = app.Workbooks;
                wb = wbs.Open(path);
                ws = wb.Worksheets[1];

                app.Visible = true;
                ReleaseExcel();
            }
            catch (Exception e)
            {
                FullCloseExcel();
                return (e.Message, true);
            }
            return (null, false);
        }


    }
}
