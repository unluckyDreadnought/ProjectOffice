using System;
using System.Configuration;
using System.Reflection;
using ProjectOffice.logic;

namespace ProjectOffice.logic.app
{
    // Класс для доступа к настройкам приложения в App.config-файле
    public class AppSettings
    {
        private Configuration _config;

        public AppSettings()
        {
            _config = ConfigurationManager.OpenExeConfiguration(Assembly.GetExecutingAssembly().Location);
        }

        // Функция получения значения настройки по ключу
        private string GetSetting(string key)
        {
            ConfigurationManager.RefreshSection("appSettings");
            return _config.AppSettings.Settings[key].Value.ToString();
        }

        // Функция установки значения по ключу
        private void SetSetting(string key, string value)
        {
            _config.AppSettings.Settings[key].Value = value;
        }

        // Возвращает / Устанавливает пароль к настройкам подключения
        public string settingsPswd
        {
            get { return GetSetting("dbSettingsPassword");  }
            set { SetSetting("dbSettingsPassword", Security.hashMd5(value, "D1n5altn")); }
        }

        // Возвращает / Устанавливает адрес размещения БД
        public string dbHost
        {
            get { return GetSetting("host"); }
            set { SetSetting("host", value); }
        }

        // Возвращает / Устанавливает пользователя БД
        public string dbUser
        {
            get { return GetSetting("user"); }
            set { SetSetting("user", value); }
        }

        // Возвращает / Устанавливает пароль пользователя БД
        public string dbUserPass
        {
            get { return GetSetting("usrpswd"); }
            set { SetSetting("usrpswd", value); }
        }

        // Возвращает имя базы данных
        public string dbName
        {
            get { return "project_office"; }
        }

        // Функция для записи изменений настроек в файл
        public void SaveModified()
        {
            _config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
        }
    }
}
