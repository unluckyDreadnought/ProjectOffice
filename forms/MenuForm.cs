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
    public partial class MenuForm : Form
    {
        private Db _db = new Db();
        private delegate void BtnClickHandler(object sender, EventArgs e);
        private List<BtnClickHandler> handlersList = new List<BtnClickHandler>();

        /// <summary>
        /// Изменяет видимость текущей формы и управляет отображением формы из параметров
        /// </summary>
        /// <param name="form">Форма для запуска</param>
        private void ChangeVisibilityToOpenNewForm(Form form)
        {
            this.Hide();
            form.ShowDialog();
            this.Show();
        }

        // Обработчик нажатия на кнопку "Пользователи"
        private void UsersBtn_Click(object sender, EventArgs e)
        {
            UsersForm usersForm = new UsersForm();
            ChangeVisibilityToOpenNewForm(usersForm);
        }
        // Обработчик нажатия на кнопку "Сотрудники"
        private void EmployeesBtn_Click(object sender, EventArgs e)
        {
            EmployeesForm employeesForm = new EmployeesForm(AppUser.Role == UserRole.Admin);
            ChangeVisibilityToOpenNewForm(employeesForm);
        }
        // Обработчик нажатия на кнопку "Клиенты"
        private void ClientsFormBtn_Click(object sender, EventArgs e)
        {
            ClientsForm clientsForm = new ClientsForm();
            ChangeVisibilityToOpenNewForm(clientsForm);
        }
        // Обработчик нажатия на кнопку "Справочники"
        private void DictionariesBtn_Click(object sender, EventArgs e)
        {
            Form dictForm = null;
            // определение какие справочники доступны пользователю с его режимом пользователя
            switch (AppUser.Role)
            {
                case UserRole.Admin:
                    {
                        dictForm = new DictionariesForm(Dictionaries.Specializations);
                        break;
                    }
                case UserRole.Manager:
                    {
                        dictForm = new DictionariesForm(Dictionaries.Stages, Dictionaries.OrganizationTypes);
                        break;
                    }
                case UserRole.Employee:
                    {
                        dictForm = new DictionariesForm(Dictionaries.Subtasks);
                        break;
                    }
            }
            ChangeVisibilityToOpenNewForm(dictForm);
        }
        // Обработчик нажатия на кнопку "Журнал действий"
        private void ActJournalBtn_Click(object sender, EventArgs e)
        {
            ChangeVisibilityToOpenNewForm(new ActJournal());
        }
        // Обработчик нажатия на кнопку "Учёт проектов"
        private void ProjectManamentBtn_Click(object sender, EventArgs e)
        {
            ChangeVisibilityToOpenNewForm(new ProjectsForm());
        }
        // Обработчик нажатия на кнопку "Статистика"
        private void StatsBtn_Click(object sender, EventArgs e)
        {
            ChangeVisibilityToOpenNewForm(new StatisticForm());
        }
        // Обработчик нажатия на кнопку "Проекты"
        private void ShowProjects_Click(object sender, EventArgs e)
        {
            ChangeVisibilityToOpenNewForm(new ProjectsForm());
        }
        // Обработчик нажатия на кнопку "Настройки"
        private void SettingsBtn_Click(object sender, EventArgs e)
        {
            AppSettingsForm settingsForm = new AppSettingsForm();
            ChangeVisibilityToOpenNewForm(settingsForm);
        }
        // Обработчик нажатия на кнопку "Настройка организации"
        private async void OrganizationSettings_Click(object sender, EventArgs e)
        {
            ClientEditorForm orgForm = await ClientEditorForm.OpenOrganizationEditor("0");
            ChangeVisibilityToOpenNewForm(orgForm);
            // загрузка логотипа организации на форму меню, если логотип был установлен
            await SetSplashLogo();
        }

        /// <summary>
        /// Загружает логотип организации-исполнителя вместо стандартного логотипа приложения на форме меню
        /// </summary>
        /// <returns></returns>
        private async Task SetSplashLogo()
        {
            // получение данных о организации-исполнителе
            object[] compInfo = await Common.GetOrgClientInfo("0");
            // проверка обнаружения записи о организации-исполнителе и  проверка, что логотип установлен
            if (compInfo.Length > 0 && compInfo[11] != DBNull.Value)
            {
                splashPicture.Image = (compInfo[11] != DBNull.Value) ? logic.Сompressor.DecomoressBytesToBitmap((byte[])compInfo[11]) : Resources.PROJECT_OFFICE_LOGO;
            }
            // применение стандартного логотипа приложения
            else splashPicture.Image = Resources.PROJECT_OFFICE_LOGO;
        }

        // Обработчик нажатия на кнопку "Покинуть личный кабинет"
        private async void LogoutBtn_Click(object sender, EventArgs e)
        {
            // запись выхода пользователя в систему в "Журнал действий пользователей"
            await _db.LogToEventJournal(EventJournal.EventType.Exit, this);
            AppUser.ResetUser();
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
        // Обработчик нажатия на кнопку "Выход"
        private async void ExitBtn_Click(object sender, EventArgs e)
        {
            // запись выхода пользователя в систему в "Журнал действий пользователей"
            await _db.LogToEventJournal(EventJournal.EventType.Exit, this);
            this.DialogResult = DialogResult.Abort;
            this.Close();
        }
        /// <summary>
        /// Получает метод-обработчик по тексту на кнопке
        /// </summary>
        /// <param name="btnText">Текст на кнопке</param>
        /// <returns>Возвращает делегат метода-обработчика для кнопки или элемента с таким текстовым значением</returns>
        private BtnClickHandler GetHandlerByBtnText(string btnText)
        {
            BtnClickHandler handler = null;
            switch (btnText)
            {
                case "Пользователи": handler = UsersBtn_Click; break;
                case "Сотрудники": handler = EmployeesBtn_Click; break;
                case "Клиенты": handler = ClientsFormBtn_Click; break;
                case "Справочники": handler = DictionariesBtn_Click; break;
                case "Журнал действий": handler = ActJournalBtn_Click; break;
                case "Учёт проектов": handler = ProjectManamentBtn_Click; break;
                case "Статистика": handler = StatsBtn_Click; break;
                case "Проекты": handler = ShowProjects_Click; break;
                case "Настройки": handler = SettingsBtn_Click; break;
                case "Настройка организации": handler = OrganizationSettings_Click; break;
                case "Покинуть личный кабинет": handler = LogoutBtn_Click; break;
                case "Выход": handler = ExitBtn_Click; break;
            }
            return handler;
        }
        
        /// <summary>
        /// Получает надписи на кнопках в зависимости от текущего режима пользователя
        /// </summary>
        /// <returns>Возращает массив надписей на кнопках для генерации интерфейса</returns>
        private string[] GetUserControls()
        {
            string[] btnTexts = null;
            switch (AppUser.Role)
            {
                case UserRole.Admin:
                    {
                        btnTexts = new string[] { "Пользователи", "Сотрудники", "Клиенты", "Справочники", "Журнал действий", "Настройки", "Покинуть личный кабинет", "Выход" };
                        break;
                    }
                case UserRole.Manager:
                    {
                        btnTexts = new string[] { "Учёт проектов", "Сотрудники", "Справочники", "Настройка организации", "Статистика", "Покинуть личный кабинет", "Выход" };
                        break;
                    }
                case UserRole.Employee:
                    {
                        btnTexts = new string[] { "Проекты", "Справочники", "Покинуть личный кабинет", "Выход" };
                        break;
                    }
            }
            // получение и сохранение в список обработчиков метода-обработчика
            foreach (string text in btnTexts)
            {
                handlersList.Add(GetHandlerByBtnText(text));
            }
            return btnTexts;
        }

        /// <summary>
        /// Генерация набора кнопок в зависимости от режима пользователя
        /// </summary>
        /// <returns>Возвращает массив кнопок для данного режима пользователя</returns>
        private Control[] CreateButtonsAccordingToRole()
        {
            List<Control> controls = new List<Control>();
            // получение надписей на кнопках
            string[] btnSet = GetUserControls();
            // создание кнопки с надписью из полученного массива
            foreach (string title in btnSet)
            {
                // применение стандартных настроек размера для кнопок
                Button temp = new Button();
                temp.Size = new Size(300, 51);
                temp.Text = title;
                // проверка, что кнопка не является одной из последних двух
                if (Array.IndexOf(btnSet, title) < btnSet.Length - 2)
                {
                    // применяем цветовое решение для кнопки
                    temp.BackColor = Color.FromArgb(192, 217, 246);
                    temp.FlatStyle = FlatStyle.Flat;
                    temp.FlatAppearance.BorderColor = Color.FromArgb(229, 239, 251);
                }
                controls.Add(temp);
            }
            return controls.ToArray();
        }

        /// <summary>
        /// Центрирование массива элементов управления в контейнере с определённым отступом
        /// </summary>
        /// <param name="controls">Массив элементов управления</param>
        /// <param name="container">Контейнер</param>
        /// <param name="margin">Отступ между элементами</param>
        private void CenterHorizontally(Control[] controls, Panel container, int margin)
        {
            // расстановка элементов управления
            int tabIndex = 0;
            foreach (Button control in controls)
            {
                // определение позиции кнопки по осям X и Y
                int controlPlaceY = (container.Height - margin) / controls.Length;
                int centerX = (container.Width - control.Width) / 2;
                int posY = (controlPlaceY - control.Height) / 2 + controlPlaceY * container.Controls.Count;
                // установка позиции кнопки
                control.Location = new Point(centerX, posY);
                control.Anchor = ((AnchorStyles)((AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top)));
                // генерация уникального имени
                control.Name = $"generatedBtn{tabIndex}";
                control.Size = control.Size;
                control.TabIndex = tabIndex;
                control.UseVisualStyleBackColor = true;
                // добавление соответствующего элементу управления метода-обработчика
                control.Click += new EventHandler(handlersList[handlersList.IndexOf(GetHandlerByBtnText(control.Text))]);
                container.Controls.Add(control);
                tabIndex++;
            }
        }

        // конструктор класса
        public MenuForm()
        {
            InitializeComponent();
        }

        // Обработчик загрузки формы меню
        private async void MenuForm_Load(object sender, EventArgs e)
        {
            // расстановка нужных для текущего типа пользователя кнопок на форме
            CenterHorizontally(CreateButtonsAccordingToRole(), buttonsPanel, 30);
            // установка названия формы и иконки
            this.Icon = Resources.PROJECT_OFFICE_ICON;
            this.Text = $"{Resources.APP_NAME}: Меню";
            // установка данных о пользователе для отображения
            usrSnpLbl.Text = AppUser.Snp;
            userModeTip.SetToolTip(usrSnpLbl, AppUser.GetUserMode());
            userPhotoPic.Image = AppUser.Photo;
            // получение и установка логотипа организации-исполнителя
            await SetSplashLogo();
        }
    }
}
