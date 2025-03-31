using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProjectOffice.Properties;
using ProjectOffice.logic;

namespace ProjectOffice.forms
{
    public partial class ActJournal : Form
    {
        Db _db = new Db();

        // конструктор класса
        public ActJournal()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Загружает режимы пользователей в список выбора
        /// </summary>
        /// <returns></returns>
        private async Task LoadFilterUserModes()
        {
            // очистка прежде существовавших вариантов и установка базового
            filterUserRoleCombo.Items.Clear();
            filterUserRoleCombo.Items.Add("Роль пользователя");
            filterUserRoleCombo.SelectedIndex = 0;
            // получение списка режимов пользователя и их загрузка в список выбора
            string query = $"select UserModeTitle from {Db.Name}.{Db.GetTableName(Db.Tables.UserMode)};";
            string[] modes = Common.DataTableToStringArray(await Common.GetAsyncResult(_db.ExecuteReaderAsync(query)));
            filterUserRoleCombo.Items.AddRange(modes);
        }

        /// <summary>
        /// Загружает типы действий (событий) записываемые в Журнале действий пользователей
        /// </summary>
        /// <returns></returns>
        private async Task LoadFilterEvent()
        {
            // очистка прежде существовавших вариантов и установка базового
            filterEventTypeCombo.Items.Clear();
            filterEventTypeCombo.Items.Add("Событие");
            filterEventTypeCombo.SelectedIndex = 0;
            // получение списка типов действий
            string query = $"select EventTypeID from {Db.Name}.{Db.GetTableName(Db.Tables.EventType)};";
            string[] typeIds = Common.DataTableToStringArray(await Common.GetAsyncResult(_db.ExecuteReaderAsync(query)));
            int indx = 0;
            while (indx < typeIds.Length)
            {
                // преобразование идентификатора в название типа
                // загрузка типов действий в список выбора
                filterEventTypeCombo.Items.Add(EventJournal.GetHumanReadableEventType(EventJournal.GetEventTypeById(typeIds[indx])));
                indx++;
            }
        }

        /// <summary>
        /// Загружает список действий пользователей исходя из заданных параметров фильтрации
        /// </summary>
        /// <param name="modeTitle">Название типа пользователя</param>
        /// <param name="typeId">Назание типа события</param>
        /// <param name="start">Дата начала</param>
        /// <param name="end">Дата конца</param>
        /// <returns>Возвращает асинхронную операцию, результатом которой является массив массивов строк записей действий пользователей</returns>
        private async Task<string[][]> LoadEvents(string modeTitle = null, string typeId = null, string start = null, string end = null)
        {
            List<string> fields = new List<string>();
            // формирование запроса к базе данных
            string query = $@"select EventTypeID, UserSurname, UserName, UserPatronymic, EventDateTime, FormName from {Db.Name}.{Db.GetTableName(Db.Tables.EventJournal)}
inner join {Db.Name}.{Db.GetTableName(Db.Tables.User)} on user.UserID = eventjournal.UserID ";
            if (modeTitle != null || typeId != null || start != null || end != null)
            {
                query += "where ";
                fields.AddRange(new string[] { modeTitle, typeId, start, end });
            }
            if (modeTitle != null)
            {
                query += $"user.UserModeID = (select UserModeID from usermode where UserModeTitle = '{modeTitle}') ";
                fields.Remove(modeTitle);
                if (fields.Where(value => value != null).ToArray().Length > 0) query += "and ";
            }
            if (typeId != null)
            {
                query += $"EventTypeID = {typeId} ";
                fields.Remove(modeTitle);
                if (fields.Where(value => value != null).ToArray().Length > 0) query += "and ";
            }
            if (start != null)
            {
                query += $"EventDateTime >= '{start}' ";
                fields.Remove(modeTitle);
                if (fields.Where(value => value != null).ToArray().Length > 0) query += "and ";
            }
            if (end != null)
            {
                query += $"EventDateTime <= '{end}'";
                fields.Remove(modeTitle);
            }
            query += " order by EventDateTime desc;";
            string[][] events = Common.MultiColumnDataTableToStringArray(await Common.GetAsyncResult(_db.ExecuteReaderAsync(query)));
            return events;
        }

        private async Task UpdateTable(string modeTitle = null, string typeId = null, string start = null, string end = null)
        {
            string[][] events = await LoadEvents(modeTitle, typeId, start, end);
            eventsTable.Rows.Clear();
            if (events.Length == 0) return;

            int row = 0;
            while (row < events.Length)
            {
                string date = DateTime.Parse(events[row][4]).ToString("dd.MM.yyyy HH:mm");
                string userShort = Common.GetShortSnp($"{events[row][1]} {events[row][2]} {events[row][3]}".Trim());
                string eventType = EventJournal.GetHumanReadableEventType(EventJournal.GetEventTypeById(events[row][0]));
                eventsTable.Rows.Add();
                eventsTable.Rows[row].Cells["dateTime"].Value = date;
                eventsTable.Rows[row].Cells["initiator"].Value = userShort;
                eventsTable.Rows[row].Cells["eventType"].Value = eventType;
                eventsTable.Rows[row].Cells["formName"].Value = events[row][5];
                row++;
            }
        }

        private string GetEventTypeId()
        {
            string eventType = "";
            if (filterEventTypeCombo.SelectedIndex <= 0) eventType = null;
            else eventType = EventJournal.GetEventTypeId(filterEventTypeCombo.SelectedItem.ToString());
            return eventType;
        }

        private string GetModeTitle()
        {
            string modeTitle = "";
            if (filterUserRoleCombo.SelectedIndex <= 0) modeTitle = null;
            else modeTitle = filterUserRoleCombo.SelectedItem.ToString();
            return modeTitle;
        }

        private async void ActJournal_Load(object sender, EventArgs e)
        {
            this.Text = $"{Resources.APP_NAME}: Журнал действий пользователей";
            this.Icon = Resources.PROJECT_OFFICE_ICON;
            startRangeDatePicker.MaxDate = DateTime.Now;
            startRangeDatePicker.Value = startRangeDatePicker.MinDate;
            endRangeDatePicker.MinDate = DateTime.Now.AddDays(1);
            await LoadFilterEvent();
            await LoadFilterUserModes();
            await UpdateTable(GetModeTitle(), GetEventTypeId(), startRangeDatePicker.Value.ToString("yyyy.MM.dd"), endRangeDatePicker.Value.AddHours(23).ToString("yyyy.MM.dd HH:mm:ss"));
            reloadDataTimer.Start();
        }

        private async void actionsReportBtn_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            int col = 0;
            while (col < eventsTable.Columns.Count)
            {
                dt.Columns.Add(eventsTable.Columns[col].Name, typeof(string));
                col++;
            }

            int row = 0;
            while (row < eventsTable.Rows.Count)
            {
                string[] rowData = new string[eventsTable.Columns.Count];
                col = 0;
                while (col < eventsTable.Rows[row].Cells.Count)
                {
                    rowData[col] = eventsTable.Rows[row].Cells[col].Value.ToString();
                    col++;
                }
                dt.Rows.Add(rowData);
                row++;
            }

            string[][] data = Common.MultiColumnDataTableToStringArray(dt);
            string path = Common.GetSaveFilePath("txt", "Текстовый документ (*.txt)|*.txt|Файл CSV (Разделитель - точка с запятой)|*.csv");
            if (path == "")
            {
                path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), $"Проектный_офис_Журнал_действий_пользователей_Экспорт_{DateTime.Now.ToString("d")}.txt");
            }
            MessageBox.Show($"Данные будут сохранены в файле по пути \"{path}\"", "Экспорт Журнала действий пользователей", MessageBoxButtons.OK, MessageBoxIcon.Information);
            bool txt = Path.GetExtension(path) == ".txt";
            using (var strWrtr = new StreamWriter(new FileStream(path, FileMode.Open, FileAccess.ReadWrite),Encoding.UTF8))
            {
                if (txt) strWrtr.WriteLine($"Дата и время\tПользователь\tТип действия\tЗаголовок формы");
                else strWrtr.WriteLine($"Дата и время;Пользователь;Тип действия;Заголовок формы");
                int line = 0;
                string separator = (txt) ? "\t" : ";";
                while (line < data.Length)
                {
                    strWrtr.WriteLine(string.Join(separator, data[line]));
                    line++;
                    if (line != 0 && line % 50 == 0) strWrtr.Flush();
                }
                strWrtr.Flush();
            }
        }

        private async void reloadDataTimer_Tick(object sender, EventArgs e)
        {
            await UpdateTable(GetModeTitle(), GetEventTypeId(), startRangeDatePicker.Value.ToString("yyyy.MM.dd"), endRangeDatePicker.Value.AddHours(23).ToString("yyyy.MM.dd HH:mm:ss"));
        }

        private async void control_Changed(object sender, EventArgs e)
        {
            await UpdateTable(GetModeTitle(), GetEventTypeId(), startRangeDatePicker.Value.ToString("yyyy.MM.dd"), endRangeDatePicker.Value.AddHours(23).ToString("yyyy.MM.dd HH:mm:ss"));
        }

        private void backToMenuBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
