using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProjectOffice.forms;
using ProjectOffice.Properties;

namespace ProjectOffice.logic.app
{
    public static class AppUser
    {
        public static string Id = null;
        public static string Snp = "<ФИО не указано>";
        public static UserRole Role = UserRole.Employee;
        public static bool confirmAccessToSettings = false;
        private static Bitmap _photo = null;
        public static Bitmap Photo
        {
            get
            {
                if (_photo == null) _photo = Resources.USR_PLUG_PICTURE;
                return _photo;
            }
            set
            {
                _photo = value;
            }
        }

        public static string GetUserMode()
        {
            string mode = "";
            switch (Role)
            {
                case UserRole.Admin: mode = "Администратор"; break;
                case UserRole.Manager: mode = "Менеджер"; break;
                case UserRole.Employee: mode = "Сотрудник"; break;
            }
            return mode;
        }

        public static void ResetUser()
        {
            Snp = "<ФИО не указано>";
            Role = UserRole.Employee;
        }

        public static void LogOut()
        {
            List<Form> openForms = Application.OpenForms.Cast<Form>().ToList();
            foreach (Form form in openForms)
            {
                if (form is AuthorizationForm) continue;
                form.Close();
            }
            openForms.Find(form => form is AuthorizationForm).Show();            
        }
    }
}
