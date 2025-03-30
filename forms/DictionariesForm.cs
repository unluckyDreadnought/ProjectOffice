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
using ProjectOffice.logic.app;
using ProjectOffice.Properties;

namespace ProjectOffice.forms
{
    public partial class DictionariesForm : Form
    {
        Db _db = new Db();
        string currentDictionary = "";
        DictionaryEditForm addObjectForm = null;

        string table = "";
        string columnIdName = "";
        string[] columnsToUpdate = null;

        private void HideButtons()
        {
            foreach (object item in toolStrip1.Items)
            {
                if (item is ToolStripButton == false) continue;
                if (!((ToolStripButton)item).Name.Contains("Check")) continue;
                ((ToolStripButton)item).Enabled = false;
                ((ToolStripButton)item).Visible = false;
            }
        }

        private void ShowButtons(params Dictionaries[] dicts)
        {
            foreach (Dictionaries d in dicts)
            {
                switch (d)
                {
                    case Dictionaries.Specializations:
                        {
                            specCheckBtn.Enabled = true;
                            specCheckBtn.Visible = true;
                            break;
                        }
                    //case Dictionaries.Status:
                    //    {
                    //        statusCheckBtn.Enabled = true;
                    //        statusCheckBtn.Visible = true;
                    //        break;
                    //    }
                    case Dictionaries.Stages:
                        {
                            stagesCheckBtn.Enabled = true;
                            stagesCheckBtn.Visible = true;
                            break;
                        }
                    case Dictionaries.OrganizationTypes:
                        {
                            typesCheckBtn.Enabled = true;
                            typesCheckBtn.Visible = true;
                            break;
                        }
                    case Dictionaries.Subtasks:
                        {
                            subtasksCheckBtn.Enabled = true;
                            subtasksCheckBtn.Visible = true;
                            break;
                        }
                }
            }
        }

        private void ActivateFirstCheckBtn()
        {
            int i = 0;
            while (i < toolStrip1.Items.Count)
            {
                if (toolStrip1.Items[i] is ToolStripButton && toolStrip1.Items[i].Name.Contains("Check") && ((ToolStripButton)toolStrip1.Items[i]).Enabled)
                {
                    ((ToolStripButton)toolStrip1.Items[i]).Checked = true;
                    break;
                }
                i++;
            }
        }

        public DictionariesForm(params Dictionaries[] displayed)
        {
            InitializeComponent();
            HideButtons();
            ShowButtons(displayed);
            ActivateFirstCheckBtn();
            editorPanel.Hide();
        }

        private void DictionariesForm_Load(object sender, EventArgs e)
        {
            this.Text = $"{Resources.APP_NAME}: Справочники";
            this.Icon = Resources.PROJECT_OFFICE_ICON;
            userPhotoPic.Image = AppUser.Photo;
            usrSnpLbl.Text = AppUser.Snp;
        }

        private void ClearTable()
        {
            objectTable.Columns.Clear();
            objectTable.DataSource = null;
        }

        private void CheckNeedToClearTable()
        {
            bool dictOpen = false;
            foreach (object item in toolStrip1.Items)
            {
                if (item is ToolStripButton == false) continue;
                if (((ToolStripButton)item).Checked)
                {
                    dictOpen = true;
                    break;
                }
            }
            if (!dictOpen)
            {
                ClearTable();
            }
        }

        private void UncheckOtherBtns(object sender)
        {
            foreach (object item in toolStrip1.Items)
            {
                if (item is ToolStripButton == false) continue;
                if ((ToolStripButton)item != (ToolStripButton)sender) ((ToolStripButton)item).Checked = false;
            }
            CheckNeedToClearTable();

        }

        private async Task<DataTable> GetDictionaryRows(string table, string orderColumn) {
            string query = $"desc {table};";
            DataTable dt = await Common.GetAsyncResult(_db.ExecuteReaderAsync(query));
            int row = 0;
            string idCol = "";
            while (row < dt.Rows.Count)
            {
                if (dt.Rows[row][0].ToString().Contains("ID") || dt.Rows[row][0].ToString().Contains("Id"))
                {
                    idCol = dt.Rows[row][0].ToString();
                    break;
                }
                row++;
            }
            query = $"select * from {table} where {idCol} != 0 order by {orderColumn};";
            var task = _db.ExecuteReaderAsync(query);
            return await Common.GetAsyncResult(task);
        }

        private void UpdateTableBy(DataTable src, params string[] headers)
        {
            ClearTable();
            if (src == null)
            {
                MessageBox.Show("Не удалось загрузить данные", $"Словарь \"{currentDictionary}\"", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            objectTable.DataSource = src;
            int i = 0;
            while (i < objectTable.Columns.Count)
            {
                if (i == headers.Length) { break; }
                if (headers[i] == "") objectTable.Columns[i].Visible = false;
                objectTable.Columns[i].HeaderText = headers[i];
                i++;
            }
            //objectTable.Columns[0].HeaderCell.Selected = false;
            objectTable.AllowUserToOrderColumns = false;
        }

        private async void UpdateTable()
        {
            int i = 0;

            while (i < toolStrip1.Items.Count)
            {
                if (toolStrip1.Items[i] is ToolStripButton && toolStrip1.Items[i].Name.Contains("Check") && ((ToolStripButton)toolStrip1.Items[i]).Checked)
                {
                    currentDictionary = ((ToolStripButton)toolStrip1.Items[i]).Text;
                    break;
                }
                i++;
            }
            switch (currentDictionary)
            {
                case "Специальности": 
                    { 
                        UpdateTableBy(await GetDictionaryRows(Db.GetTableName(Db.Tables.Specialization), "SpecializationTitle"), new string[] { "", "Название специальности" }); 
                        break; 
                    }
                case "Этапы":
                    {
                        UpdateTableBy(await GetDictionaryRows(Db.GetTableName(Db.Tables.Stage), "StageTitle"), new string[] { "", "Название стадии" });
                        break;
                    }
                case "Статусы":
                    {
                        UpdateTableBy(await GetDictionaryRows(Db.GetTableName(Db.Tables.Status), "StatusTitle"), new string[] { "", "Статус" });
                        break;
                    }
                case "Типы организаций":
                    {
                        UpdateTableBy(await GetDictionaryRows(Db.GetTableName(Db.Tables.OrgType), "OrganitationTypeDescription"), new string[] { "Аббревиатура", "Полное наименование" });
                        break;
                    }
                case "Подзадачи":
                    {
                        UpdateTableBy(await GetDictionaryRows(Db.GetTableName(Db.Tables.Subtask), "SubtaskTitle"), new string[] { "", "Подзадача" });
                        break;
                    }
            }
        }

        private string GetCheckedText()
        {
            string checkedText = "";
            int i = 0;
            while (i < toolStrip1.Items.Count)
            {
                if (toolStrip1.Items[i] is ToolStripButton && toolStrip1.Items[i].Name.Contains("Check") && ((ToolStripButton)toolStrip1.Items[i]).Checked)
                {
                    checkedText = ((ToolStripButton)toolStrip1.Items[i]).Text;
                    break;
                }
                i++;
            }
            return checkedText;
        }

        private async Task DeleteRow(string table, string idColumn)
        {
            int temp = 0;
            string key = (int.TryParse(objectTable.SelectedRows[0].Cells[0].Value.ToString(), out temp)) ? 
                objectTable.SelectedRows[0].Cells[0].Value.ToString() : $"'{objectTable.SelectedRows[0].Cells[0].Value.ToString()}'";
            object res = null;

            (int refsDeletedCount, bool isErrorEnd) = await Db.CascadeReferenceDictionaryDelete(key, table);
            if (!isErrorEnd && refsDeletedCount > 0)
            {
                MessageBox.Show($"Удалено {refsDeletedCount} связанных записей", $"Удаление записи из справочника \"{currentDictionary}\"", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (isErrorEnd)
            {
                MessageBox.Show("Не удалось удалить ссылку на удаляемую запись из связанной таблицы", $"Удаление записи из справочника \"{currentDictionary}\"", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string query = $"delete from {Db.Name}.{table} where {idColumn} = {key};";
            res = await _db.GetAsynNonReaderResult(_db.ExecuteNoDataResultAsync(query));

            if (res == null) return;
            if (res is int && (int)res > 0) MessageBox.Show("Запись успешно удалена", $"Удаление записи из справочника \"{currentDictionary}\"", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (res is string) MessageBox.Show((string)res, $"Удаление записи из справочника \"{currentDictionary}\"", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void SetDbEntityProperties(string tblName, string colIdName, string[] colsToUpdate)
        {
            table = tblName;
            columnIdName = colIdName;
            columnsToUpdate = colsToUpdate;
        }

        private void specCheckBtn_CheckedChanged(object sender, EventArgs e)
        {
            UncheckOtherBtns(sender);
            if (specCheckBtn.Checked)
            {
                SetDbEntityProperties("specialization", "SpecializationID", new string[] { "SpecializationTitle" });
                UpdateTable();
            }
        }

        //private void statusCheckBtn_CheckedChanged(object sender, EventArgs e)
        //{
        //    UncheckOtherBtns(sender);
        //    if (statusCheckBtn.Checked)
        //    {
        //        SetDbEntityProperties("status", "StatusID", new string[] { "StatusTitle" });
        //        UpdateTable();

        //    }
        //}

        private void stagesCheckBtn_CheckedChanged(object sender, EventArgs e)
        {
            UncheckOtherBtns(sender);
            if (stagesCheckBtn.Checked)
            {
                SetDbEntityProperties("stage", "StageID", new string[] { "StageTitle" });
                UpdateTable();

            };
        }

        private void typesCheckBtn_CheckedChanged(object sender, EventArgs e)
        {
            UncheckOtherBtns(sender);
            if (typesCheckBtn.Checked) 
            {
                SetDbEntityProperties("organitationtype", "OrganitationTypeName", new string[] { "OrganitationTypeDescription" });
                UpdateTable();

            };
        }

        private void subtasksCheckBtn_CheckedChanged(object sender, EventArgs e)
        {
            UncheckOtherBtns(sender);
            if (subtasksCheckBtn.Checked) 
            {
                SetDbEntityProperties("subtask", "SubtaskID", new string[] { "SubtaskTitle" });
                UpdateTable();

            };
        }

        private void hideEditorPanelBtn_Click(object sender, EventArgs e)
        {
            editorPanel.Hide();
        }

        private void LaunchAddEditForm(string title, string[] fieldsText, string id, bool edit = false) {
            if (addObjectForm == null || addObjectForm.IsDisposed)
            {
                addObjectForm = new DictionaryEditForm(title, fieldsText, table, columnIdName, columnsToUpdate, id, edit);
                addObjectForm.tableName = GetCheckedText();
                addObjectForm.FormClosed += (addObjectForm, _) => { 
                    ((Form)addObjectForm).Dispose();
                    UpdateTable();
                };
            }
            addObjectForm.Show();
        }

        private string[] GetPlaceholders()
        {
            string[] placeholders = null;
            switch (currentDictionary)
            {
                case "Специальности": placeholders = new string[] { "", "Название специальности" }; break;
                case "Этапы": placeholders = new string[] { "", "Название стадии" }; break;
                case "Статусы": placeholders = new string[] { "", "Статус" }; break;
                case "Типы организаций": placeholders = new string[] { "Аббревиатура", "Полное наименование" }; break;
                case "Подзадачи": placeholders = new string[] { "", "Подзадача" }; break;
            }
            return placeholders;
        }

        private void addObject_Click(object sender, EventArgs e)
        {
            //editorPanel.Show();
            string id = (objectTable.SelectedRows.Count > 0) ? objectTable.SelectedRows[0].Cells[0].Value.ToString() : "";
            LaunchAddEditForm(GetCheckedText(), GetPlaceholders(), id);
        }

        private void editObject_Click(object sender, EventArgs e)
        {
            //editorPanel.Show();
            string id = (objectTable.SelectedRows.Count > 0) ? objectTable.SelectedRows[0].Cells[0].Value.ToString() : "";
            LaunchAddEditForm(GetCheckedText(), GetPlaceholders(), id, true);
        }

        private void backToMenuBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStripBtn_Click(object sender, EventArgs e)
        {
            ((ToolStripButton)sender).Checked = !((ToolStripButton)sender).Checked;
            if (!((ToolStripButton)sender).Checked)
            {
                ActivateFirstCheckBtn();
            }
        }

        private async void deleteObject_Click(object sender, EventArgs e)
        {
            if (objectTable.SelectedRows.Count == 0) return;
            if (MessageBox.Show("Вы уверены, что хотите удалить запись?\nЕсли значение где-то применено, связанные записи тоже будут удалены.", "Подтверждение удаления", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                await DeleteRow(table, columnIdName);
                UpdateTable();
            }
        }
    }
}
