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
            try
            {
                if (Directory.Exists(path.Replace(Path.GetFileName(path), ""))) _basePath = path;
                else _basePath = $@"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\";
            }
            catch (Exception)
            {
                _basePath = $@"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\";
            }
        }

        private static Excel.Application app = null;
        private static Excel.Workbooks wbs = null;
        private static Excel.Workbook wb = null;
        private static Excel.Worksheet ws = null;
        private static Excel.Range r = null;

        private static void ReleaseObject(object obj)
        {
            try
            {
                Marshal.ReleaseComObject(obj);
                Marshal.FinalReleaseComObject(obj);
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
            ws = null;
            wbs = null;
            wb = null;
            app = null;
            GC.Collect();
        }

        private static void FullCloseExcel()
        {
            //ReleaseObject(r);
            //ReleaseObject(ws);
            if (wb != null)
            {
                wb.Close();
                //ReleaseObject(wb);
            }
            if (wbs != null)
            {
                wbs.Close();
                //ReleaseObject(wbs);
            }
            if (app != null)
            {
                app.Application.Quit();
                app.Quit();
                //ReleaseObject(app);
            }
            ReleaseExcel();
        }

        public async static Task<(string, bool)> SaveStatsOnProject(Project project, string notBasePath = null)
        {
            Db _db = new Db();

            string path = baseSavePath;
            string template = $@"{(Application.StartupPath)}\doc\stats_on_project.xlsx";
            if (notBasePath == null)
            {
                path += $"Отчёт_{project.Title}_{DateTime.Now.ToString("d_T")}.xlsx";
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

                r = ws.Range["A1"];
                r.Value = $"Отчёт по выполнению проекта №{project.Id}\n({project.Title})";
                r = ws.Range["E3"];
                ws.Range["E3"].Value = DateTime.Now.ToString("g");
                r = ws.Range["A3"];
                ws.Range["A3"].Value = $"Менеджер: {AppUser.Snp}";

                int indx = 0;
                int row = 5;
                int[] count = new int[3];
                string[] arr = new string[] { "этапов", "подзадач", "контрольных точек (КТ)" };

                string query = $@"select count(*) from stage_in_project where ProjectID = {project.Id};";
                (object n, _) = await Common.GetNoScalarResult(_db.GetAsynNonReaderResult(_db.ExecuteScalarAsync(query)));
                count[0] = Convert.ToInt32(n);

                query = $@"select count(*) from subtask_in_project_stage where
StgProjReferenceID in (select StgLinkID from stage_in_project where ProjectID = {project.Id});";
                (n, _) = await Common.GetNoScalarResult(_db.GetAsynNonReaderResult(_db.ExecuteScalarAsync(query)));
                count[1] = Convert.ToInt32(n);

                query = $@"select count(*) from control_point_to_subtask
where SbtskReferenceID in 
(select SbtskLinkID from subtask_in_project_stage
where StgProjReferenceID in 
(select StgLinkID from stage_in_project where ProjectID = {project.Id}));";
                (n, _) = await Common.GetNoScalarResult(_db.GetAsynNonReaderResult(_db.ExecuteScalarAsync(query)));
                count[2] = Convert.ToInt32(n);

                while (indx < count.Length)
                {
                    r = ws.Range[$"A{row + indx}"];
                    r.Value = $"Количество {arr[indx]}:";
                    r = ws.Range[$"B{row + indx}"];
                    r.Value = count[indx];
                    indx++;
                }

                query = $@"
select 
concat(UserSurname, ' ', substring(UserName,1,1), '.', case when UserPatronymic is not null then substring(UserPatronymic,1,1) else '' end),
count(*) as 'count'
from control_point_to_subtask
inner join controlpoint on controlpoint.ControlPointID = control_point_to_subtask.ControlPointID
inner join user on user.UserID = controlpoint.ControlPointAuthorID
where SbtskReferenceID in 
(select SbtskLinkID from subtask_in_project_stage
where StgProjReferenceID in
(select StgLinkID from stage_in_project 
where ProjectID = {project.Id}))
group by controlpoint.ControlPointAuthorID";
                string[][] employees = Common.MultiColumnDataTableToStringArray(await Common.GetAsyncResult(_db.ExecuteReaderAsync(query)));

                row = 11;

                string[] range = new string[2];
                range[0] = $"A{row-1}";

                while ((row-11) < employees.Length)
                {
                    r = ws.Range[$"A{row}"];
                    ws.Range[$"A{row}"].Value = employees[(row - 11)][0];
                    r = ws.Range[$"B{row}"];
                    ws.Range[$"B{row}"].Value = employees[(row - 11)][1];
                    row++;
                }
                range[1] = $"B{row-1}";
                r = ws.Range[$"{range[0]}:{range[1]}"];

                r.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                r.Borders.Weight = Excel.XlBorderWeight.xlThick;
                r.Borders.Color = System.Drawing.Color.Black;

                Marshal.ReleaseComObject(r);
                r = null;
                GC.Collect();
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

        // (описание, это_ошибка?)
        public static (string, bool) SaveCommonStatsReport(int rejected, int active, int outOfDate, int completed, string notBasePath = null)
        {
            string path = baseSavePath;
            string[] arr = new string[] { "Активные проекты", "Отменённые проекты", "Просроченные активные проекты", "Завершённые проекты", "", "Всего" };
            int[] counts = new int[] { active, rejected, outOfDate, completed, -1, active + rejected + completed };

            string template = $@"{(Application.StartupPath)}\doc\stats.xlsx";

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

                r = ws.Range["A3"];
                r.Value = DateTime.Now.ToString("g");
                r = ws.Range["D3"];
                r.Value = AppUser.Snp;

                int indx = 0;
                int row = 6;

                // заполнение таблицы количества групп проектов
                while (indx < counts.Length)
                {
                    r = ws.Range[$"A{row + indx}"];
                    r.Value = arr[indx];
                    if (counts[indx] >= 0)
                    {
                        r = ws.Range[$"B{row + indx}"];
                        r.Value = counts[indx];
                    }
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
