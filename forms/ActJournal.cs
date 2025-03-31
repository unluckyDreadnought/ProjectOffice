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
            // если роль пользователя выбрана, добавляем условие в запрос
            if (modeTitle != null)
            {
                query += $"user.UserModeID = (select UserModeID from usermode where UserModeTitle = '{modeTitle}') ";
                fields.Remove(modeTitle);
                if (fields.Where(value => value != null).ToArray().Length > 0) query += "and ";
            }
            // если тип события выбран, добавляем условие в запрос
            if (typeId != null)
            {
                query += $"EventTypeID = {typeId} ";
                fields.Remove(modeTitle);
                if (fields.Where(value => value != null).ToArray().Length > 0) query += "and ";
            }
            // если дата начала периода выбрана, добавляем условие в запрос
            if (start != null)
            {
                query += $"EventDateTime >= '{start}' ";
                fields.Remove(modeTitle);
                if (fields.Where(value => value != null).ToArray().Length > 0) query += "and ";
            }
            // если дата конца периода выбрана, добавляем условие в запрос
            if (end != null)
            {
                query += $"EventDateTime <= '{end}'";
                fields.Remove(modeTitle);
            }
            // применение сортировки по времени (сначало самое новое)
            query += " order by EventDateTime desc;";
            // формирование массива массивов ответа
            string[][] events = Common.MultiColumnDataTableToStringArray(await Common.GetAsyncResult(_db.ExecuteReaderAsync(query)));
            return events;
        }

        /// <summary>
        /// Обновляет данные в таюлице "Журнала действий"
        /// </summary>
        /// <param name="modeTitle">Режим пользователя</param>
        /// <param name="typeId">Тип события</param>
        /// <param name="start">Дата начала</param>
        /// <param name="end">Дата конца</param>
        /// <returns></returns>
        private async Task UpdateTable(string modeTitle = null, string typeId = null, string start = null, string end = null)
        {
            // ожидаем получения новых данных
            string[][] events = await LoadEvents(modeTitle, typeId, start, end);
            // очищает таблицу от предыдущих данных
            eventsTable.Rows.Clear();
            if (events.Length == 0) return;

            // построчно заполняем таблицу новыми данными, пока выполняется условие
            int row = 0;
            while (row < events.Length)
            {
                // преобразование данных к нужному виду
                string date = DateTime.Parse(events[row][4]).ToString("dd.MM.yyyy HH:mm");
                string userShort = Common.GetShortSnp($"{events[row][1]} {events[row][2]} {events[row][3]}".Trim());
                string eventType = EventJournal.GetHumanReadableEventType(EventJournal.GetEventTypeById(events[row][0]));
                // добавление новой строки таблицы и вставка в неё данных
                eventsTable.Rows.Add();
                eventsTable.Rows[row].Cells["dateTime"].Value = date;
                eventsTable.Rows[row].Cells["initiator"].Value = userShort;
                eventsTable.Rows[row].Cells["eventType"].Value = eventType;
                eventsTable.Rows[row].Cells["formName"].Value = events[row][5];
                row++;
            }
        }

        /// <summary>
        /// Определяет по выбранному элементу списка выбора типов действий его идентификатор
        /// </summary>
        /// <returns>Возвращает строку - идентификатор, если индентификатор был найден, иначе null</returns>
        private string GetEventTypeId()
        {
            string eventType = "";
            if (filterEventTypeCombo.SelectedIndex <= 0) eventType = null;
            else eventType = EventJournal.GetEventTypeId(filterEventTypeCombo.SelectedItem.ToString());
            return eventType;
        }

        /// <summary>
        /// Получает текст выбранного элемента списка режимов пользователей
        /// </summary>
        /// <returns>Возвращает строку - текст с элемента списка выбора в случае, если элемент был выбран и не находится по индексу 0, иначе null</returns>
        private string GetModeTitle()
        {
            string modeTitle = "";
            if (filterUserRoleCombo.SelectedIndex <= 0) modeTitle = null;
            else modeTitle = filterUserRoleCombo.SelectedItem.ToString();
            return modeTitle;
        }

        // Обработчик события загрузки формы
        private async void ActJournal_Load(object sender, EventArgs e)
        {
            // установка названия формы и иконки
            this.Text = $"{Resources.APP_NAME}: Журнал действий пользователей";
            this.Icon = Resources.PROJECT_OFFICE_ICON;
            // установка органичений и значений периодов времени
            startRangeDatePicker.MaxDate = DateTime.Now;
            startRangeDatePicker.Value = startRangeDatePicker.MinDate;
            endRangeDatePicker.MinDate = DateTime.Now.AddDays(1);
            // загрузка данных
            await LoadFilterEvent();
            await LoadFilterUserModes();
            await UpdateTable(GetModeTitle(), GetEventTypeId(), startRangeDatePicker.Value.ToString("yyyy.MM.dd"), endRangeDatePicker.Value.AddHours(23).ToString("yyyy.MM.dd HH:mm:ss"));
            // запуск таймера обновления таблицы
            reloadDataTimer.Start();
        }

        // Обработчик события нажатия на кнопку "Экспорт"
        private async void actionsReportBtn_Click(object sender, EventArgs e)
        {
            // выбор всех данных из таблицы
            // формирование структуры таблицы
            DataTable dt = new DataTable();
            int col = 0;
            while (col < eventsTable.Columns.Count)
            {
                dt.Columns.Add(eventsTable.Columns[col].Name, typeof(string));
                col++;
            }
            // построчное заполнение данных в виртуальную таблицу dt
            int row = 0;
            while (row < eventsTable.Rows.Count)
            {
                // формирование строки таблицы dt
                string[] rowData = new string[eventsTable.Columns.Count];
                col = 0;
                while (col < eventsTable.Rows[row].Cells.Count)
                {
                    // заполнение данными строки таблицы rowData
                    rowData[col] = eventsTable.Rows[row].Cells[col].Value.ToString();
                    col++;
                }
                // вставка строки с данными в виртуальную таблицу dt
                dt.Rows.Add(rowData);
                row++;
            }
            // преобразование данных в массив массивов строк
            string[][] data = Common.MultiColumnDataTableToStringArray(dt);
            // получение пути сохранения файла на ЭВМ пользователя, если путь указан, иначе применение шаблонного имени
            string path = Common.GetSaveFilePath("txt", "Текстовый документ (*.txt)|*.txt|Файл CSV (Разделитель - точка с запятой)|*.csv");
            if (path == "")
            {
                path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), $"Проектный_офис_Журнал_действий_пользователей_Экспорт_{DateTime.Now.ToString("d")}.txt");
            }
            MessageBox.Show($"Данные будут сохранены в файле по пути \"{path}\"", "Экспорт Журнала действий пользователей", MessageBoxButtons.OK, MessageBoxIcon.Information);
            bool txt = Path.GetExtension(path) == ".txt";
            // создание файла и записываем в него данные
            try
            {
                using (var strWrtr = new StreamWriter(new FileStream(path, FileMode.OpenOrCreate, FileAccess.ReadWrite), Encoding.UTF8))
                {
                    // вставка заголовка
                    if (txt) strWrtr.WriteLine($"Дата и время\tПользователь\tТип действия\tЗаголовок формы");
                    else strWrtr.WriteLine($"Дата и время;Пользователь;Тип действия;Заголовок формы");
                    int line = 0;
                    // вставка данных с определённым для типа файла разделителем
                    string separator = (txt) ? "\t" : ";";
                    while (line < data.Length)
                    {
                        strWrtr.WriteLine(string.Join(separator, data[line]));
                        line++;
                        if (line != 0 && line % 50 == 0) strWrtr.Flush();
                    }
                    // окончательно записываем данные и очищаем буфер
                    strWrtr.Flush();
                }
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show($"Не удалось получить доступ к файлу для сохранения данных.", "Экспорт Журнала действий пользователей", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (DirectoryNotFoundException)
            {
                MessageBox.Show($"Каталог не найден.", "Экспорт Журнала действий пользователей", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка.\n{ex.Message}", "Экспорт Журнала действий пользователей", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // Обработчик прошествия заданного времени у таймера
        private async void reloadDataTimer_Tick(object sender, EventArgs e)
        {
            // обновление данных в таблице
            await UpdateTable(GetModeTitle(), GetEventTypeId(), startRangeDatePicker.Value.ToString("yyyy.MM.dd"), endRangeDatePicker.Value.AddHours(23).ToString("yyyy.MM.dd HH:mm:ss"));
        }

        // Обработчик изменения значения элементов формы
        private async void control_Changed(object sender, EventArgs e)
        {
            // обновление данных в таблице
            await UpdateTable(GetModeTitle(), GetEventTypeId(), startRangeDatePicker.Value.ToString("yyyy.MM.dd"), endRangeDatePicker.Value.AddHours(23).ToString("yyyy.MM.dd HH:mm:ss"));
        }

        // Обработчик нажатия на кнопку "В меню"
        private void backToMenuBtn_Click(object sender, EventArgs e)
        {
            // закрытие формы
            this.Close();
        }
    }
}
