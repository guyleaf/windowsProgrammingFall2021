
namespace CourseSelectionApp.UserControls
{
    partial class CourseDataGridComponent
    {
        /// <summary> 
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 元件設計工具產生的程式碼

        /// <summary> 
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this._courseDataGridView = new System.Windows.Forms.DataGridView();
            this._courseIdTextBox = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._courseNameTextBox = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._courseStageTextBox = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._courseCreditsTextBox = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._courseHoursTextBox = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._courseRequiredOrElectiveTextBox = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._courseTeacherTextBox = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._courseTimeForSundayTextBox = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._courseTimeForMondayTextBox = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._courseTimeForTuesdayTextBox = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._courseTimeForWednesdayTextBox = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._courseTimeForThursdayTextBox = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._courseTimeForFridayTextBox = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._courseTimeForSaturdayTextBox = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._courseClassRoomTextBox = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._courseNumberOfStudentsTextBox = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._courseNumberOfDropStudentsTextBox = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._courseTeachingAssistantTextBox = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._courseLanguageTextBox = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._courseSyllabusLink = new System.Windows.Forms.DataGridViewLinkColumn();
            this._courseNoteTextBox = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._courseAuditTextBox = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._courseExperimentTextBox = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._panel = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this._courseDataGridView)).BeginInit();
            this._panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // _courseDataGridView
            // 
            this._courseDataGridView.AllowUserToAddRows = false;
            this._courseDataGridView.AllowUserToDeleteRows = false;
            this._courseDataGridView.AllowUserToOrderColumns = true;
            this._courseDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this._courseDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._courseDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this._courseIdTextBox,
            this._courseNameTextBox,
            this._courseStageTextBox,
            this._courseCreditsTextBox,
            this._courseHoursTextBox,
            this._courseRequiredOrElectiveTextBox,
            this._courseTeacherTextBox,
            this._courseTimeForSundayTextBox,
            this._courseTimeForMondayTextBox,
            this._courseTimeForTuesdayTextBox,
            this._courseTimeForWednesdayTextBox,
            this._courseTimeForThursdayTextBox,
            this._courseTimeForFridayTextBox,
            this._courseTimeForSaturdayTextBox,
            this._courseClassRoomTextBox,
            this._courseNumberOfStudentsTextBox,
            this._courseNumberOfDropStudentsTextBox,
            this._courseTeachingAssistantTextBox,
            this._courseLanguageTextBox,
            this._courseSyllabusLink,
            this._courseNoteTextBox,
            this._courseAuditTextBox,
            this._courseExperimentTextBox});
            this._courseDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this._courseDataGridView.Location = new System.Drawing.Point(0, 0);
            this._courseDataGridView.Margin = new System.Windows.Forms.Padding(0);
            this._courseDataGridView.Name = "_courseDataGridView";
            this._courseDataGridView.RowTemplate.Height = 24;
            this._courseDataGridView.Size = new System.Drawing.Size(1302, 648);
            this._courseDataGridView.TabIndex = 2;
            // 
            // _courseIdTextBox
            // 
            this._courseIdTextBox.DataPropertyName = "Id";
            this._courseIdTextBox.HeaderText = "課號";
            this._courseIdTextBox.Name = "_courseIdTextBox";
            this._courseIdTextBox.ReadOnly = true;
            this._courseIdTextBox.Width = 53;
            // 
            // _courseNameTextBox
            // 
            this._courseNameTextBox.DataPropertyName = "Info.Name";
            this._courseNameTextBox.HeaderText = "課程名稱";
            this._courseNameTextBox.Name = "_courseNameTextBox";
            this._courseNameTextBox.ReadOnly = true;
            this._courseNameTextBox.Width = 64;
            // 
            // _courseStageTextBox
            // 
            this._courseStageTextBox.DataPropertyName = "Info.Stage";
            this._courseStageTextBox.HeaderText = "階段";
            this._courseStageTextBox.Name = "_courseStageTextBox";
            this._courseStageTextBox.ReadOnly = true;
            this._courseStageTextBox.Width = 53;
            // 
            // _courseCreditsTextBox
            // 
            this._courseCreditsTextBox.DataPropertyName = "SelectionInfo.Credits";
            this._courseCreditsTextBox.HeaderText = "學分";
            this._courseCreditsTextBox.Name = "_courseCreditsTextBox";
            this._courseCreditsTextBox.ReadOnly = true;
            this._courseCreditsTextBox.Width = 53;
            // 
            // _courseHoursTextBox
            // 
            this._courseHoursTextBox.DataPropertyName = "SelectionInfo.Hours";
            this._courseHoursTextBox.HeaderText = "時數";
            this._courseHoursTextBox.Name = "_courseHoursTextBox";
            this._courseHoursTextBox.ReadOnly = true;
            this._courseHoursTextBox.Width = 53;
            // 
            // _courseRequiredOrElectiveTextBox
            // 
            this._courseRequiredOrElectiveTextBox.DataPropertyName = "Info.RequiredOrElectiveCourse";
            this._courseRequiredOrElectiveTextBox.HeaderText = "必/選修";
            this._courseRequiredOrElectiveTextBox.Name = "_courseRequiredOrElectiveTextBox";
            this._courseRequiredOrElectiveTextBox.ReadOnly = true;
            this._courseRequiredOrElectiveTextBox.Width = 58;
            // 
            // _courseTeacherTextBox
            // 
            this._courseTeacherTextBox.DataPropertyName = "Info.Teacher";
            this._courseTeacherTextBox.HeaderText = "教師";
            this._courseTeacherTextBox.Name = "_courseTeacherTextBox";
            this._courseTeacherTextBox.ReadOnly = true;
            this._courseTeacherTextBox.Width = 53;
            // 
            // _courseTimeForSundayTextBox
            // 
            this._courseTimeForSundayTextBox.DataPropertyName = "CourseTime.Sunday";
            this._courseTimeForSundayTextBox.HeaderText = "日";
            this._courseTimeForSundayTextBox.Name = "_courseTimeForSundayTextBox";
            this._courseTimeForSundayTextBox.ReadOnly = true;
            this._courseTimeForSundayTextBox.Width = 45;
            // 
            // _courseTimeForMondayTextBox
            // 
            this._courseTimeForMondayTextBox.DataPropertyName = "CourseTime.Monday";
            this._courseTimeForMondayTextBox.HeaderText = "一";
            this._courseTimeForMondayTextBox.Name = "_courseTimeForMondayTextBox";
            this._courseTimeForMondayTextBox.ReadOnly = true;
            this._courseTimeForMondayTextBox.Width = 45;
            // 
            // _courseTimeForTuesdayTextBox
            // 
            this._courseTimeForTuesdayTextBox.DataPropertyName = "CourseTime.Tuesday";
            this._courseTimeForTuesdayTextBox.HeaderText = "二";
            this._courseTimeForTuesdayTextBox.Name = "_courseTimeForTuesdayTextBox";
            this._courseTimeForTuesdayTextBox.ReadOnly = true;
            this._courseTimeForTuesdayTextBox.Width = 45;
            // 
            // _courseTimeForWednesdayTextBox
            // 
            this._courseTimeForWednesdayTextBox.DataPropertyName = "CourseTime.Wednesday";
            this._courseTimeForWednesdayTextBox.HeaderText = "三";
            this._courseTimeForWednesdayTextBox.Name = "_courseTimeForWednesdayTextBox";
            this._courseTimeForWednesdayTextBox.ReadOnly = true;
            this._courseTimeForWednesdayTextBox.Width = 45;
            // 
            // _courseTimeForThursdayTextBox
            // 
            this._courseTimeForThursdayTextBox.DataPropertyName = "CourseTime.Thursday";
            this._courseTimeForThursdayTextBox.HeaderText = "四";
            this._courseTimeForThursdayTextBox.Name = "_courseTimeForThursdayTextBox";
            this._courseTimeForThursdayTextBox.ReadOnly = true;
            this._courseTimeForThursdayTextBox.Width = 45;
            // 
            // _courseTimeForFridayTextBox
            // 
            this._courseTimeForFridayTextBox.DataPropertyName = "CourseTime.Friday";
            this._courseTimeForFridayTextBox.HeaderText = "五";
            this._courseTimeForFridayTextBox.Name = "_courseTimeForFridayTextBox";
            this._courseTimeForFridayTextBox.ReadOnly = true;
            this._courseTimeForFridayTextBox.Width = 45;
            // 
            // _courseTimeForSaturdayTextBox
            // 
            this._courseTimeForSaturdayTextBox.DataPropertyName = "CourseTime.Saturday";
            this._courseTimeForSaturdayTextBox.HeaderText = "六";
            this._courseTimeForSaturdayTextBox.Name = "_courseTimeForSaturdayTextBox";
            this._courseTimeForSaturdayTextBox.ReadOnly = true;
            this._courseTimeForSaturdayTextBox.Width = 45;
            // 
            // _courseClassRoomTextBox
            // 
            this._courseClassRoomTextBox.DataPropertyName = "Info.ClassRoom";
            this._courseClassRoomTextBox.HeaderText = "教室";
            this._courseClassRoomTextBox.Name = "_courseClassRoomTextBox";
            this._courseClassRoomTextBox.ReadOnly = true;
            this._courseClassRoomTextBox.Width = 53;
            // 
            // _courseNumberOfStudentsTextBox
            // 
            this._courseNumberOfStudentsTextBox.DataPropertyName = "Status.NumberOfStudents";
            this._courseNumberOfStudentsTextBox.HeaderText = "修課人數";
            this._courseNumberOfStudentsTextBox.Name = "_courseNumberOfStudentsTextBox";
            this._courseNumberOfStudentsTextBox.ReadOnly = true;
            this._courseNumberOfStudentsTextBox.Width = 64;
            // 
            // _courseNumberOfDropStudentsTextBox
            // 
            this._courseNumberOfDropStudentsTextBox.DataPropertyName = "Status.NumberOfDropStudents";
            this._courseNumberOfDropStudentsTextBox.HeaderText = "徹選人數";
            this._courseNumberOfDropStudentsTextBox.Name = "_courseNumberOfDropStudentsTextBox";
            this._courseNumberOfDropStudentsTextBox.ReadOnly = true;
            this._courseNumberOfDropStudentsTextBox.Width = 64;
            // 
            // _courseTeachingAssistantTextBox
            // 
            this._courseTeachingAssistantTextBox.DataPropertyName = "Info.TeachingAssistant";
            this._courseTeachingAssistantTextBox.HeaderText = "教學助理";
            this._courseTeachingAssistantTextBox.Name = "_courseTeachingAssistantTextBox";
            this._courseTeachingAssistantTextBox.ReadOnly = true;
            this._courseTeachingAssistantTextBox.Width = 64;
            // 
            // _courseLanguageTextBox
            // 
            this._courseLanguageTextBox.DataPropertyName = "OtherInfo.Language";
            this._courseLanguageTextBox.HeaderText = "授課語言";
            this._courseLanguageTextBox.Name = "_courseLanguageTextBox";
            this._courseLanguageTextBox.ReadOnly = true;
            this._courseLanguageTextBox.Width = 64;
            // 
            // _courseSyllabusLink
            // 
            this._courseSyllabusLink.DataPropertyName = "OtherInfo.Syllabus";
            this._courseSyllabusLink.HeaderText = "教學大綱與進度表";
            this._courseSyllabusLink.Name = "_courseSyllabusLink";
            this._courseSyllabusLink.ReadOnly = true;
            this._courseSyllabusLink.Text = "查詢";
            this._courseSyllabusLink.Width = 67;
            // 
            // _courseNoteTextBox
            // 
            this._courseNoteTextBox.DataPropertyName = "OtherInfo.Note";
            this._courseNoteTextBox.HeaderText = "備註";
            this._courseNoteTextBox.Name = "_courseNoteTextBox";
            this._courseNoteTextBox.ReadOnly = true;
            this._courseNoteTextBox.Width = 53;
            // 
            // _courseAuditTextBox
            // 
            this._courseAuditTextBox.DataPropertyName = "OtherInfo.Audit";
            this._courseAuditTextBox.HeaderText = "隨班附讀";
            this._courseAuditTextBox.Name = "_courseAuditTextBox";
            this._courseAuditTextBox.ReadOnly = true;
            this._courseAuditTextBox.Width = 64;
            // 
            // _courseExperimentTextBox
            // 
            this._courseExperimentTextBox.DataPropertyName = "OtherInfo.Experiment";
            this._courseExperimentTextBox.HeaderText = "實驗實習";
            this._courseExperimentTextBox.Name = "_courseExperimentTextBox";
            this._courseExperimentTextBox.ReadOnly = true;
            this._courseExperimentTextBox.Width = 64;
            // 
            // _panel
            // 
            this._panel.Controls.Add(this._courseDataGridView);
            this._panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this._panel.Location = new System.Drawing.Point(0, 0);
            this._panel.Name = "_panel";
            this._panel.Size = new System.Drawing.Size(1302, 648);
            this._panel.TabIndex = 1;
            // 
            // CourseDataGridComponent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this._panel);
            this.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "CourseDataGridComponent";
            this.Size = new System.Drawing.Size(1302, 648);
            ((System.ComponentModel.ISupportInitialize)(this._courseDataGridView)).EndInit();
            this._panel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        protected System.Windows.Forms.DataGridViewTextBoxColumn _courseIdTextBox;
        protected System.Windows.Forms.DataGridViewTextBoxColumn _courseNameTextBox;
        protected System.Windows.Forms.DataGridViewTextBoxColumn _courseStageTextBox;
        protected System.Windows.Forms.DataGridViewTextBoxColumn _courseCreditsTextBox;
        protected System.Windows.Forms.DataGridViewTextBoxColumn _courseHoursTextBox;
        protected System.Windows.Forms.DataGridViewTextBoxColumn _courseRequiredOrElectiveTextBox;
        protected System.Windows.Forms.DataGridViewTextBoxColumn _courseTeacherTextBox;
        protected System.Windows.Forms.DataGridViewTextBoxColumn _courseTimeForSundayTextBox;
        protected System.Windows.Forms.DataGridViewTextBoxColumn _courseTimeForMondayTextBox;
        protected System.Windows.Forms.DataGridViewTextBoxColumn _courseTimeForTuesdayTextBox;
        protected System.Windows.Forms.DataGridViewTextBoxColumn _courseTimeForWednesdayTextBox;
        protected System.Windows.Forms.DataGridViewTextBoxColumn _courseTimeForThursdayTextBox;
        protected System.Windows.Forms.DataGridViewTextBoxColumn _courseTimeForFridayTextBox;
        protected System.Windows.Forms.DataGridViewTextBoxColumn _courseTimeForSaturdayTextBox;
        protected System.Windows.Forms.DataGridViewTextBoxColumn _courseClassRoomTextBox;
        protected System.Windows.Forms.DataGridViewTextBoxColumn _courseNumberOfStudentsTextBox;
        protected System.Windows.Forms.DataGridViewTextBoxColumn _courseNumberOfDropStudentsTextBox;
        protected System.Windows.Forms.DataGridViewTextBoxColumn _courseTeachingAssistantTextBox;
        protected System.Windows.Forms.DataGridViewTextBoxColumn _courseLanguageTextBox;
        protected System.Windows.Forms.DataGridViewLinkColumn _courseSyllabusLink;
        protected System.Windows.Forms.DataGridViewTextBoxColumn _courseNoteTextBox;
        protected System.Windows.Forms.DataGridViewTextBoxColumn _courseAuditTextBox;
        protected System.Windows.Forms.DataGridViewTextBoxColumn _courseExperimentTextBox;
        protected System.Windows.Forms.DataGridView _courseDataGridView;
        protected System.Windows.Forms.Panel _panel;
    }
}
