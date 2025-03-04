
namespace ProjectOffice.forms
{
    partial class StatisticForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea5 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend5 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.statsTabControl = new System.Windows.Forms.TabControl();
            this.commonStatsTab = new System.Windows.Forms.TabPage();
            this.outOfDateProjectsCount = new System.Windows.Forms.Label();
            this.rejectedProjectsCountLbl = new System.Windows.Forms.Label();
            this.completedProjectsCountLbl = new System.Windows.Forms.Label();
            this.activeProjectsCountLbl = new System.Windows.Forms.Label();
            this.totalProjectCountLbl = new System.Windows.Forms.Label();
            this.allProjectStatsChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.projectStatsTab = new System.Windows.Forms.TabPage();
            this.statsProjectTree = new System.Windows.Forms.TreeView();
            this.statusContainer = new System.Windows.Forms.StatusStrip();
            this.projectCompleteStatusBar = new System.Windows.Forms.ToolStripProgressBar();
            this.statusLbl = new System.Windows.Forms.ToolStripStatusLabel();
            this.projectStatsCombo = new System.Windows.Forms.ComboBox();
            this.projectLbl = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.statsReportBtn = new System.Windows.Forms.Button();
            this.backToMenu = new System.Windows.Forms.Button();
            this.statsTabControl.SuspendLayout();
            this.commonStatsTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.allProjectStatsChart)).BeginInit();
            this.projectStatsTab.SuspendLayout();
            this.statusContainer.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statsTabControl
            // 
            this.statsTabControl.Controls.Add(this.commonStatsTab);
            this.statsTabControl.Controls.Add(this.projectStatsTab);
            this.statsTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.statsTabControl.Location = new System.Drawing.Point(0, 0);
            this.statsTabControl.Name = "statsTabControl";
            this.statsTabControl.SelectedIndex = 0;
            this.statsTabControl.Size = new System.Drawing.Size(677, 430);
            this.statsTabControl.TabIndex = 0;
            this.statsTabControl.SelectedIndexChanged += new System.EventHandler(this.statsTabControl_SelectedIndexChanged);
            // 
            // commonStatsTab
            // 
            this.commonStatsTab.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(239)))), ((int)(((byte)(251)))));
            this.commonStatsTab.Controls.Add(this.outOfDateProjectsCount);
            this.commonStatsTab.Controls.Add(this.rejectedProjectsCountLbl);
            this.commonStatsTab.Controls.Add(this.completedProjectsCountLbl);
            this.commonStatsTab.Controls.Add(this.activeProjectsCountLbl);
            this.commonStatsTab.Controls.Add(this.totalProjectCountLbl);
            this.commonStatsTab.Controls.Add(this.allProjectStatsChart);
            this.commonStatsTab.Controls.Add(this.label5);
            this.commonStatsTab.Controls.Add(this.label4);
            this.commonStatsTab.Controls.Add(this.label3);
            this.commonStatsTab.Controls.Add(this.label2);
            this.commonStatsTab.Controls.Add(this.label1);
            this.commonStatsTab.Location = new System.Drawing.Point(4, 31);
            this.commonStatsTab.Name = "commonStatsTab";
            this.commonStatsTab.Padding = new System.Windows.Forms.Padding(3);
            this.commonStatsTab.Size = new System.Drawing.Size(669, 395);
            this.commonStatsTab.TabIndex = 0;
            this.commonStatsTab.Text = "Общее";
            // 
            // outOfDateProjectsCount
            // 
            this.outOfDateProjectsCount.AutoSize = true;
            this.outOfDateProjectsCount.Location = new System.Drawing.Point(240, 222);
            this.outOfDateProjectsCount.Name = "outOfDateProjectsCount";
            this.outOfDateProjectsCount.Size = new System.Drawing.Size(21, 24);
            this.outOfDateProjectsCount.TabIndex = 7;
            this.outOfDateProjectsCount.Text = "n";
            // 
            // rejectedProjectsCountLbl
            // 
            this.rejectedProjectsCountLbl.AutoSize = true;
            this.rejectedProjectsCountLbl.Location = new System.Drawing.Point(240, 177);
            this.rejectedProjectsCountLbl.Name = "rejectedProjectsCountLbl";
            this.rejectedProjectsCountLbl.Size = new System.Drawing.Size(21, 24);
            this.rejectedProjectsCountLbl.TabIndex = 7;
            this.rejectedProjectsCountLbl.Text = "n";
            // 
            // completedProjectsCountLbl
            // 
            this.completedProjectsCountLbl.AutoSize = true;
            this.completedProjectsCountLbl.Location = new System.Drawing.Point(240, 131);
            this.completedProjectsCountLbl.Name = "completedProjectsCountLbl";
            this.completedProjectsCountLbl.Size = new System.Drawing.Size(21, 24);
            this.completedProjectsCountLbl.TabIndex = 7;
            this.completedProjectsCountLbl.Text = "n";
            // 
            // activeProjectsCountLbl
            // 
            this.activeProjectsCountLbl.AutoSize = true;
            this.activeProjectsCountLbl.Location = new System.Drawing.Point(240, 86);
            this.activeProjectsCountLbl.Name = "activeProjectsCountLbl";
            this.activeProjectsCountLbl.Size = new System.Drawing.Size(21, 24);
            this.activeProjectsCountLbl.TabIndex = 7;
            this.activeProjectsCountLbl.Text = "n";
            // 
            // totalProjectCountLbl
            // 
            this.totalProjectCountLbl.AutoSize = true;
            this.totalProjectCountLbl.Location = new System.Drawing.Point(240, 37);
            this.totalProjectCountLbl.Name = "totalProjectCountLbl";
            this.totalProjectCountLbl.Size = new System.Drawing.Size(21, 24);
            this.totalProjectCountLbl.TabIndex = 7;
            this.totalProjectCountLbl.Text = "n";
            // 
            // allProjectStatsChart
            // 
            chartArea5.Name = "ChartArea1";
            this.allProjectStatsChart.ChartAreas.Add(chartArea5);
            legend5.Name = "Legend1";
            this.allProjectStatsChart.Legends.Add(legend5);
            this.allProjectStatsChart.Location = new System.Drawing.Point(349, 19);
            this.allProjectStatsChart.Name = "allProjectStatsChart";
            this.allProjectStatsChart.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Pastel;
            series5.ChartArea = "ChartArea1";
            series5.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series5.Legend = "Legend1";
            series5.Name = "Series1";
            this.allProjectStatsChart.Series.Add(series5);
            this.allProjectStatsChart.Size = new System.Drawing.Size(300, 300);
            this.allProjectStatsChart.TabIndex = 6;
            this.allProjectStatsChart.Text = "chart1";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(23, 222);
            this.label5.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(148, 24);
            this.label5.TabIndex = 1;
            this.label5.Text = "Просроченных:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(23, 177);
            this.label4.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(137, 24);
            this.label4.TabIndex = 2;
            this.label4.Text = "Отклонённых:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 131);
            this.label3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(139, 24);
            this.label3.TabIndex = 3;
            this.label3.Text = "Выполненных:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 86);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 24);
            this.label2.TabIndex = 4;
            this.label2.Text = "Активных:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 37);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(158, 24);
            this.label1.TabIndex = 5;
            this.label1.Text = "Всего проектов:";
            // 
            // projectStatsTab
            // 
            this.projectStatsTab.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(239)))), ((int)(((byte)(251)))));
            this.projectStatsTab.Controls.Add(this.statsProjectTree);
            this.projectStatsTab.Controls.Add(this.statusContainer);
            this.projectStatsTab.Controls.Add(this.projectStatsCombo);
            this.projectStatsTab.Controls.Add(this.projectLbl);
            this.projectStatsTab.Location = new System.Drawing.Point(4, 31);
            this.projectStatsTab.Name = "projectStatsTab";
            this.projectStatsTab.Padding = new System.Windows.Forms.Padding(3);
            this.projectStatsTab.Size = new System.Drawing.Size(669, 395);
            this.projectStatsTab.TabIndex = 1;
            this.projectStatsTab.Text = "Проекты";
            // 
            // statsProjectTree
            // 
            this.statsProjectTree.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.statsProjectTree.BackColor = System.Drawing.Color.WhiteSmoke;
            this.statsProjectTree.Location = new System.Drawing.Point(8, 154);
            this.statsProjectTree.Name = "statsProjectTree";
            this.statsProjectTree.Size = new System.Drawing.Size(653, 177);
            this.statsProjectTree.TabIndex = 3;
            // 
            // statusContainer
            // 
            this.statusContainer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.statusContainer.Dock = System.Windows.Forms.DockStyle.None;
            this.statusContainer.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.statusContainer.ImageScalingSize = new System.Drawing.Size(40, 40);
            this.statusContainer.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.projectCompleteStatusBar,
            this.statusLbl});
            this.statusContainer.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.statusContainer.Location = new System.Drawing.Point(24, 84);
            this.statusContainer.Name = "statusContainer";
            this.statusContainer.Size = new System.Drawing.Size(572, 34);
            this.statusContainer.SizingGrip = false;
            this.statusContainer.TabIndex = 2;
            this.statusContainer.Text = "Статус выполнения";
            // 
            // projectCompleteStatusBar
            // 
            this.projectCompleteStatusBar.AutoSize = false;
            this.projectCompleteStatusBar.AutoToolTip = true;
            this.projectCompleteStatusBar.Name = "projectCompleteStatusBar";
            this.projectCompleteStatusBar.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this.projectCompleteStatusBar.Size = new System.Drawing.Size(430, 28);
            this.projectCompleteStatusBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.projectCompleteStatusBar.ToolTipText = "Статус выполнения";
            // 
            // statusLbl
            // 
            this.statusLbl.Name = "statusLbl";
            this.statusLbl.Size = new System.Drawing.Size(123, 29);
            this.statusLbl.Text = "n/m (00.00%)";
            // 
            // projectStatsCombo
            // 
            this.projectStatsCombo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.projectStatsCombo.BackColor = System.Drawing.Color.WhiteSmoke;
            this.projectStatsCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.projectStatsCombo.FormattingEnabled = true;
            this.projectStatsCombo.Location = new System.Drawing.Point(152, 24);
            this.projectStatsCombo.Name = "projectStatsCombo";
            this.projectStatsCombo.Size = new System.Drawing.Size(265, 30);
            this.projectStatsCombo.TabIndex = 1;
            // 
            // projectLbl
            // 
            this.projectLbl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.projectLbl.AutoSize = true;
            this.projectLbl.Location = new System.Drawing.Point(45, 27);
            this.projectLbl.Name = "projectLbl";
            this.projectLbl.Size = new System.Drawing.Size(75, 24);
            this.projectLbl.TabIndex = 0;
            this.projectLbl.Text = "Проект";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.statsReportBtn);
            this.panel1.Controls.Add(this.backToMenu);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 375);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(677, 55);
            this.panel1.TabIndex = 1;
            // 
            // statsReportBtn
            // 
            this.statsReportBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.statsReportBtn.Location = new System.Drawing.Point(407, 6);
            this.statsReportBtn.Name = "statsReportBtn";
            this.statsReportBtn.Size = new System.Drawing.Size(258, 43);
            this.statsReportBtn.TabIndex = 3;
            this.statsReportBtn.Text = "Сохранить в отчёт";
            this.statsReportBtn.UseVisualStyleBackColor = true;
            this.statsReportBtn.Click += new System.EventHandler(this.statsReportBtn_Click);
            // 
            // backToMenu
            // 
            this.backToMenu.Location = new System.Drawing.Point(12, 6);
            this.backToMenu.Name = "backToMenu";
            this.backToMenu.Size = new System.Drawing.Size(133, 43);
            this.backToMenu.TabIndex = 4;
            this.backToMenu.Text = "В меню";
            this.backToMenu.UseVisualStyleBackColor = true;
            this.backToMenu.Click += new System.EventHandler(this.backToMenu_Click);
            // 
            // StatisticForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(677, 430);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.statsTabControl);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "StatisticForm";
            this.Text = "StatisticForm";
            this.Activated += new System.EventHandler(this.StatisticForm_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.StatisticForm_FormClosing);
            this.Load += new System.EventHandler(this.StatisticForm_Load);
            this.statsTabControl.ResumeLayout(false);
            this.commonStatsTab.ResumeLayout(false);
            this.commonStatsTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.allProjectStatsChart)).EndInit();
            this.projectStatsTab.ResumeLayout(false);
            this.projectStatsTab.PerformLayout();
            this.statusContainer.ResumeLayout(false);
            this.statusContainer.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl statsTabControl;
        private System.Windows.Forms.TabPage commonStatsTab;
        private System.Windows.Forms.Label outOfDateProjectsCount;
        private System.Windows.Forms.Label rejectedProjectsCountLbl;
        private System.Windows.Forms.Label completedProjectsCountLbl;
        private System.Windows.Forms.Label activeProjectsCountLbl;
        private System.Windows.Forms.Label totalProjectCountLbl;
        private System.Windows.Forms.DataVisualization.Charting.Chart allProjectStatsChart;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage projectStatsTab;
        private System.Windows.Forms.TreeView statsProjectTree;
        private System.Windows.Forms.StatusStrip statusContainer;
        private System.Windows.Forms.ToolStripProgressBar projectCompleteStatusBar;
        private System.Windows.Forms.ToolStripStatusLabel statusLbl;
        private System.Windows.Forms.ComboBox projectStatsCombo;
        private System.Windows.Forms.Label projectLbl;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button statsReportBtn;
        private System.Windows.Forms.Button backToMenu;
    }
}