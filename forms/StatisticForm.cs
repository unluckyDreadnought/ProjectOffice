using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProjectOffice.logic;
using ProjectOffice.Properties;

namespace ProjectOffice.forms
{
    public partial class StatisticForm : Form
    {
        private Db _db = null;
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
            int active = 0;
            int completed = 0;
            int rejected = 0;
            int outOfDate = 0;

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
                    case "Завершено": completed++;  break;
                }
                total++;
                i++;
            }

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
            else { ; }
        }
    }
}
