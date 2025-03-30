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
        private static Db _db = new Db();
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

        private static Excel.Application excelApp = null;
        private static Excel.Workbooks wbs = null;
        private static Excel.Workbook wb = null;
        private static Excel.Worksheet ws = null;
        private static Excel.Range r = null;

        private static Word.Application wordApp = null;
        private static Word.Documents wrdDcs = null;
        private static Word.Document wrdDc = null;
        private static Word.Range wrdRng = null;
        private static Word.Bookmark bkmk = null;
        private static Word.Table wrdTbl = null;

        private static void PlaceValueToBookmarkRange(string name, string value)
        {
            bkmk = wrdDc.Bookmarks[name];
            wrdRng = bkmk.Range;
            wrdRng.Text = value;
        }

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
            ReleaseObject(excelApp);
            ws = null;
            wbs = null;
            wb = null;
            excelApp = null;
            GC.Collect();
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
            if (excelApp != null)
            {
                excelApp.Application.Quit();
                excelApp.Quit();
            }
            ReleaseExcel();
        }

        private static void ReleaseWord()
        {
            ReleaseObject(wrdDc);
            ReleaseObject(wordApp);
            wrdRng = null;
            wrdTbl = null;
            wrdDc = null;
            wrdDcs = null;
            wordApp = null;
            GC.Collect();
        }

        private static void FullCloseWord()
        {
            if (wrdDc != null)
            {
                wrdDc.Close();
            }
            if (wrdDcs != null)
            {
                wrdDcs = null;
                GC.Collect();
            }
            if (wordApp != null)
            {
                wordApp.Application.Quit();
            }
            ReleaseWord();
        }

        public async static Task<(string, bool)> SaveStatsOnProject(Project project, string notBasePath = null)
        {
            string path = baseSavePath;
            string template = $@"{(Application.StartupPath)}\doc\stats_on_project.xlsx";
            if (notBasePath == null || notBasePath == "")
            {
                path += $"Отчёт_{project.Title}_{DateTime.Now.ToString("d_T")}.xlsx";
            }
            else
            {
                path = notBasePath;
            }

            try
            {
                excelApp = new Excel.Application();

                if (excelApp == null)
                {
                    return ("Не удалось создать отчёт", true);
                }
                excelApp.Visible = true;
                excelApp.Visible = false;

                wbs = excelApp.Workbooks;
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
                excelApp.Visible = true;
                wb.SaveAs(path);
                FullCloseExcel();

                if (excelApp == null) excelApp = new Excel.Application();
                wbs = excelApp.Workbooks;
                wb = wbs.Open(path);
                ws = wb.Worksheets[1];

                excelApp.Visible = true;
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

            if (notBasePath == null || notBasePath == "")
            {
                path += $"Общий_отчёт_по_проектам_{DateTime.Now.ToString("d_T")}.xlsx";
            }
            else
            {
                path = notBasePath;
            }

            try
            {
                excelApp = new Excel.Application();

                if (excelApp == null)
                {
                    return ("Не удалось создать отчёт", true);
                }
                excelApp.Visible = true;
                excelApp.Visible = false;

                wbs = excelApp.Workbooks;
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
                excelApp.Visible = true;
                wb.SaveAs(path);
                FullCloseExcel();

                if (excelApp == null) excelApp = new Excel.Application();
                wbs = excelApp.Workbooks;
                wb = wbs.Open(path);
                ws = wb.Worksheets[1];

                excelApp.Visible = true;
                ReleaseExcel();
            }
            catch (Exception e)
            {
                FullCloseExcel();
                return (e.Message, true);
            }
            return (null, false);
        }

        public async static Task<(string, bool)> MakeDevelopmentDealDocument(Project project, string notBasePath = null)
        {
            string path = baseSavePath;
            string template = $@"{(Application.StartupPath)}\doc\development_deal.docx";

            if (notBasePath == null || notBasePath == "")
            {
                path += $"Договор_на_разработку_{project.Id}_{DateTime.Now.ToString("d_T")}.docx";
            }
            else
            {
                path = notBasePath;
            }

            try
            {
                wordApp = new Word.Application();
                if (wordApp == null)
                {
                    return ("Не удалось создать отчёт", true);
                }
                //wordApp.Visible = true;
                wordApp.Visible = false;

                wrdDcs = wordApp.Documents;
                wrdDc = wrdDcs.Add(template);
                wrdDc.Activate();

                string query = $@"select ClientTypeID from {Db.Name}.client where ClientID = {project.CustomerId};";
                (object objRes, _) = await Common.GetNoScalarResult(_db.GetAsynNonReaderResult(_db.ExecuteScalarAsync(query)));

                string[] clientInfo = new string[] { };
                if (Convert.ToInt32(objRes) == 2)
                {
                    query = $@"select
OrganitationTypeDescription, OrganitationTypeName, ClientName, ClientAddress, 
ClientBankAccount, ClientBank, ClientPhone, ClientEmail, ClientOrgINN, 
ClientOrgKPP, ClientOrgOGRN, ClientOrgBIK, ClientPhoto
from project_office.client 
inner join organitationtype on organitationtype.OrganitationTypeName = ClientOrgTypeID
where ClientID = {project.CustomerId}; ";
                }
                else
                {

                    query = $@"select
ClientName, ClientAddress, ClientBankAccount, 
ClientBank, ClientPhone, ClientEmail
from project_office.client
where ClientID = {project.CustomerId};";
                }
                clientInfo = Common.DataTableToStringArray(await Common.GetAsyncResult(_db.ExecuteReaderAsync(query)));

                string[] companyInfo = new string[] { };
                query = $@"select
OrganitationTypeDescription, OrganitationTypeName, ClientName, ClientAddress, 
ClientBankAccount, ClientBank, ClientPhone, ClientEmail, ClientOrgINN, 
ClientOrgKPP, ClientOrgOGRN, ClientOrgBIK
from project_office.client 
inner join organitationtype on organitationtype.OrganitationTypeName = ClientOrgTypeID
where ClientID = 0; ";
                companyInfo = Common.DataTableToStringArray(await Common.GetAsyncResult(_db.ExecuteReaderAsync(query)));
                string clientName = (clientInfo.Length > 6) ? $"{clientInfo[0]} \"{clientInfo[2]}\"" : clientInfo[0];

                PlaceValueToBookmarkRange("projectID", project.Id);
                DateTime projectStart = DateTime.Parse(project.StartDate);
                PlaceValueToBookmarkRange("day", projectStart.Day.ToString());
                PlaceValueToBookmarkRange("textMonth", projectStart.ToString("MMMM"));
                PlaceValueToBookmarkRange("year", projectStart.Year.ToString());
                PlaceValueToBookmarkRange("clientName", clientName);

                if (companyInfo.Length > 0)
                {
                    string companyFullName = $"{companyInfo[0]} \"{companyInfo[2]}\"";
                    string companyName = $"{companyInfo[1]} \"{companyInfo[2]}\"";
                    string directorShort = Common.GetShortSnp(AppSettings.director);

                    PlaceValueToBookmarkRange("companyAddress", companyInfo[3]);
                    PlaceValueToBookmarkRange("companyFullName", companyFullName);
                    PlaceValueToBookmarkRange("directorFullName", AppSettings.director);
                    PlaceValueToBookmarkRange("directorShortName", directorShort);
                    PlaceValueToBookmarkRange("companyInn", companyInfo[8]);
                    PlaceValueToBookmarkRange("companyKpp", companyInfo[9]);
                    PlaceValueToBookmarkRange("companyOgrn", companyInfo[10]);
                    PlaceValueToBookmarkRange("companyBankAccount", companyInfo[4]);
                    PlaceValueToBookmarkRange("companyBank", companyInfo[5]);
                    PlaceValueToBookmarkRange("companyBik", companyInfo[11]);
                    PlaceValueToBookmarkRange("companyPhone", companyInfo[6]);
                    PlaceValueToBookmarkRange("companyEmail", companyInfo[7]);
                    PlaceValueToBookmarkRange("companyAddress2", companyInfo[3]);
                    PlaceValueToBookmarkRange("companyName2", companyName);
                    PlaceValueToBookmarkRange("companyFullName2", companyFullName);
                    PlaceValueToBookmarkRange("directorShortName2", Common.GetShortSnp(AppSettings.director));
                }
                else
                {
                    PlaceValueToBookmarkRange("companyAddress", "[Юридический адрес Разработчика]");
                    PlaceValueToBookmarkRange("companyFullName", "[Полное название Разработчика]"); 
                    PlaceValueToBookmarkRange("directorFullName", "[ФИО директора Разработчика]");
                    PlaceValueToBookmarkRange("directorShortName", "[Фамилия Инициалы директора Разработчика]");
                    PlaceValueToBookmarkRange("companyInn", "[ИНН Разработчика]");
                    PlaceValueToBookmarkRange("companyKpp", "[КПП Разработчика]");
                    PlaceValueToBookmarkRange("companyOgrn", "[ОГРН Разработчика]");
                    PlaceValueToBookmarkRange("companyBankAccount", "[Р/с Разработчика]");
                    PlaceValueToBookmarkRange("companyBank", "[Банк Разработчика]");
                    PlaceValueToBookmarkRange("companyBik", "[БИК Разработчика]");
                    PlaceValueToBookmarkRange("companyPhone", "[Телефон Разработчика]");
                    PlaceValueToBookmarkRange("companyEmail", "[Почта Разработчика]");
                    PlaceValueToBookmarkRange("companyAddress2", "[Юридический адрес Разработчика]");
                    PlaceValueToBookmarkRange("companyName2", "[Краткое название Разработчика]");
                    PlaceValueToBookmarkRange("companyFullName2", "[Полное название Разработчика]");
                    PlaceValueToBookmarkRange("directorShortName2", "[Фамилия Инициалы директора Разработчика]");
                }

                string[] data = new string[] { };
                string[] titles = new string[] { };
                if (clientInfo.Length > 6)
                {
                    data = new string[] {
                        $"{clientInfo[0]} \"{clientInfo[2]}\"", clientInfo[3], $"{clientInfo[8]}/{clientInfo[9]}",
                        clientInfo[10], clientInfo[4], clientInfo[5], clientInfo[11], clientInfo[6], clientInfo[7], "", 
                        $"{clientInfo[0]} \"{clientInfo[2]}\""
                    };
                    titles = new string[] {
                        "Заказчик:", "Юр. Адрес:", "ИНН/КПП:", "ОГРН:", "Р/с:", "Наименование банка:", "БИК:", "Телефон:",
                        "Электронная почта:", "Заказчик", "", "____________/_______________/", "", 
                        "«     »  ____________ ____ г."
                    };
                }
                else
                {
                    data = new string[] {
                        clientInfo[0], clientInfo[1], clientInfo[2], clientInfo[3], clientInfo[4],
                        clientInfo[5], "", "", "", "", clientInfo[0]
                    };
                    titles = new string[] {
                        "Заказчик:", "Адрес:", "Р/с:", "Наименование банка:", "Телефон:", "Электронная почта:", 
                        "", "", "", "Заказчик", "", "____________/_______________/", "",
                        "«     »  ____________ ____ г."
                    };
                }

                
                wrdTbl = wrdDc.Tables[3];

                int row = 0;
                while (row < wrdTbl.Rows.Count)
                {
                    Word.Cell cell = wrdTbl.Cell(row+1, 2);
                    wrdRng = cell.Range;
                    wrdRng.Font.Bold = 0;
                    var cells = wrdRng.Cells[1];
                    cells.Range.Text = titles[row];
                    cells = null;
                    GC.Collect();
                    if (row < data.Length)
                    {
                        string paste = $"{titles[row]} {data[row]}";
                        wrdRng.Text = paste.Trim();
                    }
                    else
                    {
                        wrdRng.Text = titles[row].Trim();
                    }
                    
                    if (titles[row] != null && titles[row] != "")
                    {
                        object objStart = wrdRng.Start;
                        object objEnd = wrdRng.Start + titles[row].IndexOf(":");
                        Word.Range rngBold = wrdDc.Range(ref objStart, ref objEnd);
                        rngBold.Font.Bold = 1;
                    }
                    row++;
                }

                wrdTbl = wrdDc.Tables[4];

                int indx = row;
                row = 0;
                while (row < wrdTbl.Rows.Count)
                {
                    Word.Cell cell = wrdTbl.Cell(row+1, 2);
                    wrdRng = cell.Range;
                    wrdRng.Font.Bold = (row == 0) ? 1 : 0;
                    wrdRng.Text = (row + indx < data.Length) ? $"{titles[row + indx]}{data[row + indx]}" : titles[row + indx];
                    ReleaseObject(cell);
                    row++;
                }

                wordApp.ActiveDocument.SaveAs2(path);
                FullCloseWord();

                if (wordApp == null) wordApp = new Word.Application();
                wordApp.Visible = true;
                wrdDcs = wordApp.Documents;
                wrdDc = wrdDcs.Open(path);
                wrdDc.Activate();
                ReleaseWord();
                GC.Collect();
            }
            catch (Exception e)
            {
                FullCloseWord();
                return (e.Message, true);
            }
            return (null, false);
        }

        public async static Task<(string, bool)> MakeEndWorkAct(Project project, string notBasePath = null)
        {
            string path = baseSavePath;
            string template = "";
            bool success = (project.Status == ((int)Status.Finish).ToString()) ? true : false;

            if (success) template = $@"{(Application.StartupPath)}\doc\end_act_success.docx";
            else template = $@"{(Application.StartupPath)}\doc\end_act_fail.docx";

            if (notBasePath == null || notBasePath == "")
            {
                path += $"Акт_о_завершении_работ_{project.Id}_{DateTime.Now.ToString("d_T")}.docx";
            }
            else
            {
                path = notBasePath;
            }

            try
            {
                wordApp = new Word.Application();
                if (wordApp == null)
                {
                    return ("Не удалось создать отчёт", true);
                }
                //wordApp.Visible = true;
                wordApp.Visible = false;

                wrdDcs = wordApp.Documents;
                wrdDc = wrdDcs.Add(template);
                wrdDc.Activate();

                string query = $@"select ClientTypeID from {Db.Name}.client where ClientID = {project.CustomerId};";

                string clientName = "";
                (object n, _) = await Common.GetNoScalarResult(_db.GetAsynNonReaderResult(_db.ExecuteScalarAsync(query)));
                if (Convert.ToInt32(n) == 2)
                {
                    query = $@"select OrganitationTypeDescription, ClientName from {Db.Name}.client 
inner join organitationtype on organitationtype.OrganitationTypeName = client.ClientOrgTypeID
where ClientID = {project.CustomerId};";
                    string[] clientInfo = Common.DataTableToStringArray(await Common.GetAsyncResult(_db.ExecuteReaderAsync(query)));
                    if (clientInfo.Length != 0) clientName = $"{clientInfo[0]} \"{clientInfo[1]}\"";
                    else clientName = "[заказчик]";
                }
                else
                {
                    query = $"select ClientName from {Db.Name}.client where ClientID = {project.CustomerId};";
                    (object name, _) = await Common.GetNoScalarResult(_db.GetAsynNonReaderResult(_db.ExecuteScalarAsync(query)));
                    clientName = name.ToString();
                }

                query = $@"select OrganitationTypeName, OrganitationTypeDescription, ClientName, ClientAddress from {Db.Name}.client 
inner join organitationtype on organitationtype.OrganitationTypeName = client.ClientOrgTypeID
where ClientID = 0;";
                string companyFullName = "";
                string companyAddress = "";
                string director = "";

                string[] companyInfo = Common.DataTableToStringArray(await Common.GetAsyncResult(_db.ExecuteReaderAsync(query)));
                if (companyInfo.Length != 0)
                {
                    companyFullName = $"{companyInfo[1]} \"{companyInfo[2]}\"";
                    companyAddress = companyInfo[3];
                    director = AppSettings.director;
                }
                else
                {
                    companyFullName = "[Полное имя Разработчика]";
                    companyAddress = "[Юр. Адрес Разработчика]";
                    director = "[ФИО директора Разработчика]";
                }

                int coeff = Convert.ToInt32(project.Coefficient);
                double costWithCoeff = Convert.ToDouble(project.Cost) * (1 + (coeff / 100));
                double returnMoney = Convert.ToDouble(project.Cost) - costWithCoeff;

                string[] initialCost = Math.Round(Convert.ToDouble(project.Cost), 2).ToString().Split('.');
                string[] withCoeff = Math.Round(costWithCoeff, 2).ToString().Split('.');
                string[] toReturn = Math.Round(returnMoney, 2).ToString().Split('.');

                PlaceValueToBookmarkRange("companyAddress", companyAddress);
                PlaceValueToBookmarkRange("companyFullName", companyFullName);
                PlaceValueToBookmarkRange("companyFullName2", companyFullName);
                PlaceValueToBookmarkRange("directorFullName", director);
                PlaceValueToBookmarkRange("clIentName", clientName);
                PlaceValueToBookmarkRange("clIentName2", clientName);
                PlaceValueToBookmarkRange("projectID", project.Id);
                PlaceValueToBookmarkRange("projectStartDate", DateTime.Parse(project.StartDate).ToString("dd.MM.yyyy"));
                PlaceValueToBookmarkRange("projectTitle", project.Title);
                if (toReturn.Length == 2)
                {
                    PlaceValueToBookmarkRange("intReturn", toReturn[0]);
                    PlaceValueToBookmarkRange("floatReturn", toReturn[1]);
                }
                else
                {
                    PlaceValueToBookmarkRange("intReturn", toReturn[0]);
                    PlaceValueToBookmarkRange("floatReturn", "00");
                }

                if (success)
                {
                    if (initialCost.Length == 2)
                    {
                        PlaceValueToBookmarkRange("intMoneyPart", initialCost[0]);
                        PlaceValueToBookmarkRange("floatMoneyPart", initialCost[1]);
                    }
                    else
                    {
                        PlaceValueToBookmarkRange("intMoneyPart", initialCost[0]);
                        PlaceValueToBookmarkRange("floatMoneyPart", "00");
                    }
                    if (withCoeff.Length == 2)
                    {
                        PlaceValueToBookmarkRange("intWithCoeff", withCoeff[0]);
                        PlaceValueToBookmarkRange("floatWithCoeff", withCoeff[1]);
                    }
                    else
                    {
                        PlaceValueToBookmarkRange("intWithCoeff", withCoeff[0]);
                        PlaceValueToBookmarkRange("floatWithCoeff", "00");
                    }
                    wrdTbl = wrdDc.Tables[2];

                    int stgIndx = 0;
                    List<string> subtaskTitles = new List<string>();
                    while (stgIndx < project.Stages.Count)
                    {
                        int sbtskIndx = 0;
                        while (sbtskIndx < project.Stages[stgIndx].subtasks.Count)
                        {
                            ControlPoint[] finishedPnt = project.Stages[stgIndx].subtasks[sbtskIndx].points.Where(pnt => pnt.StatusId == ((int)Status.Finish).ToString()).ToArray();
                            if (finishedPnt.Length > 0)
                            {
                                subtaskTitles.Add(project.Stages[stgIndx].subtasks[sbtskIndx].Title);
                            }
                            sbtskIndx++;
                        }
                        stgIndx++;
                    }

                    int row = 0;
                    Word.Cell cell = wrdTbl.Cell(row + 1, 1);
                    wrdTbl.Rows.Add(wrdTbl.Rows[wrdTbl.Rows.Count]);
                    cell = wrdTbl.Cell(row + 1, 1);
                    wrdRng = cell.Range;
                    wrdRng.Text = $"№";
                    cell.Borders.OutsideColor = Word.WdColor.wdColorBlack;
                    cell = wrdTbl.Cell(row + 1, 2);
                    wrdRng = cell.Range;
                    wrdRng.Text = "Проведенные работы в ходе реализации проекта";
                    cell.Borders.OutsideLineStyle = Word.WdLineStyle.wdLineStyleSingle;
                    cell.Borders.OutsideColor = Word.WdColor.wdColorBlack;
                    ReleaseObject(cell);
                    while (row < subtaskTitles.Count)
                    {
                        wrdTbl.Rows.Add(wrdTbl.Rows[wrdTbl.Rows.Count]);
                        cell = wrdTbl.Cell(row + 2, 1);
                        wrdRng = cell.Range;
                        wrdRng.Text = $"{row + 1}";
                        cell.Borders.OutsideColor = Word.WdColor.wdColorBlack;
                        cell = wrdTbl.Cell(row + 2, 2);
                        wrdRng = cell.Range;
                        wrdRng.Text = subtaskTitles[row];
                        cell.Borders.OutsideLineStyle = Word.WdLineStyle.wdLineStyleSingle;
                        cell.Borders.OutsideColor = Word.WdColor.wdColorBlack;
                        ReleaseObject(cell);
                        row++;
                    }

                    wrdTbl.Rows[wrdTbl.Rows.Count].Delete();
                }

                wordApp.ActiveDocument.SaveAs2(path);
                FullCloseWord();

                if (wordApp == null) wordApp = new Word.Application();
                wordApp.Visible = true;
                wrdDcs = wordApp.Documents;
                wrdDc = wrdDcs.Open(path);
                wrdDc.Activate();
                ReleaseWord();
                GC.Collect();
            }
            catch (Exception e)
            {
                FullCloseWord();
                return (e.Message, true);
            }
            return (null, false);
        }
    }
}
