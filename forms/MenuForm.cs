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

namespace ProjectOffice.forms
{
    public partial class MenuForm : Form
    {
        private delegate void BtnClickHandler(object sender, EventArgs e);
        private List<BtnClickHandler> handlersList = new List<BtnClickHandler>();

        private void ChangeVisibilityToOpenNewForm(Form form)
        {
            this.Hide();
            form.ShowDialog();
            this.Show();
        }

        private void UsersBtn_Click(object sender, EventArgs e)
        {
            UsersForm usersForm = new UsersForm();
            ChangeVisibilityToOpenNewForm(usersForm);
        }
        private void EmployeesBtn_Click(object sender, EventArgs e)
        {
            EmployeesForm employeesForm = new EmployeesForm(AppUser.Role == UserRole.Admin);
            ChangeVisibilityToOpenNewForm(employeesForm);

        }
        private void ClientsFormBtn_Click(object sender, EventArgs e)
        {
            ClientsForm clientsForm = new ClientsForm();
            ChangeVisibilityToOpenNewForm(clientsForm);
        }
        private void DictionariesBtn_Click(object sender, EventArgs e)
        {
            Form dictForm = null;
            switch (AppUser.Role)
            {
                case UserRole.Admin:
                    {
                        dictForm = new DictionariesForm(Dictionaries.Specializations);
                        break;
                    }
                case UserRole.Manager:
                    {
                        dictForm = new DictionariesForm(Dictionaries.Status, Dictionaries.Stages, Dictionaries.OrganizationTypes);
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
        private void ActJournalBtn_Click(object sender, EventArgs e)
        {
            ChangeVisibilityToOpenNewForm(new ActJournal());
        }
        private void ProjectManamentBtn_Click(object sender, EventArgs e)
        {
            ChangeVisibilityToOpenNewForm(new ProjectsForm());
        }
        private void PlanningBtn_Click(object sender, EventArgs e)
        {
            ChangeVisibilityToOpenNewForm(new PlannigForm());
        }
        private void StatsBtn_Click(object sender, EventArgs e)
        {
            ChangeVisibilityToOpenNewForm(new StatisticForm());
        }
        private void ShowProjects_Click(object sender, EventArgs e)
        {
            ChangeVisibilityToOpenNewForm(new ProjectsForm());
        }
        private void SettingsBtn_Click(object sender, EventArgs e)
        {
            AppSettingsForm settingsForm = new AppSettingsForm();
            ChangeVisibilityToOpenNewForm(settingsForm);
        }

        // common
        private void LogoutBtn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
        private void ExitBtn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Abort;
            this.Close();
        }

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
                case "Планирование": handler = PlanningBtn_Click; break;
                case "Статистика": handler = StatsBtn_Click; break;
                case "Проекты": handler = ShowProjects_Click; break;
                case "Настройки": handler = SettingsBtn_Click; break;
                case "Покинуть личный кабинет": handler = LogoutBtn_Click; break;
                case "Выход": handler = ExitBtn_Click; break;
            }
            return handler;
        }

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
                        btnTexts = new string[] { "Учёт проектов", "Сотрудники", "Справочники", "Планирование", "Статистика", "Покинуть личный кабинет", "Выход" };
                        break;
                    }
                case UserRole.Employee:
                    {
                        btnTexts = new string[] { "Проекты", "Справочники", "Покинуть личный кабинет", "Выход" };
                        break;
                    }
            }

            foreach (string text in btnTexts)
            {
                handlersList.Add(GetHandlerByBtnText(text));
            }

            return btnTexts;
        }

        private Control[] CreateButtonsAccordingToRole()
        {
            List<Control> controls = new List<Control>();
            string[] btnSet = GetUserControls();
            foreach (string title in btnSet)
            {
                Button temp = new Button();
                temp.Size = new Size(300, 51);
                temp.Text = title;
                if (Array.IndexOf(btnSet, title) < btnSet.Length - 2)
                {
                    temp.BackColor = Color.FromArgb(192, 217, 246);
                    temp.FlatStyle = FlatStyle.Flat;
                    temp.FlatAppearance.BorderColor = Color.FromArgb(229, 239, 251);
                }
                controls.Add(temp);
            }
            return controls.ToArray();
        }

        private void CenterHorizontally(Control[] controls, Panel container, int margin)
        {
            int tabIndex = 0;
            foreach (Button control in controls)
            {
                int controlPlaceY = (container.Height - margin) / controls.Length;
                int centerX = (container.Width - control.Width) / 2;
                int posY = (controlPlaceY - control.Height) / 2 + controlPlaceY * container.Controls.Count;

                control.Location = new Point(centerX, posY);
                control.Anchor = ((AnchorStyles)((AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top)));
                control.Name = $"generatedBtn{tabIndex}";
                control.Size = control.Size;
                control.TabIndex = tabIndex;
                control.UseVisualStyleBackColor = true;
                control.Click += new EventHandler(handlersList[handlersList.IndexOf(GetHandlerByBtnText(control.Text))]);
                container.Controls.Add(control);
                tabIndex++;
            }

        }

        public MenuForm()
        {
            InitializeComponent();
        }

        private void MenuForm_Load(object sender, EventArgs e)
        {
            CenterHorizontally(CreateButtonsAccordingToRole(), buttonsPanel, 30);
            this.Text = $"{Resources.APP_NAME}";
            usrSnpLbl.Text = AppUser.Snp;
            usrModeLbl.Text = AppUser.GetUserMode();
            splashPicture.Image = Resources.PLUG_PICTURE;
        }
    }
}
