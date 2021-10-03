
namespace CourseSelectionApp
{
    partial class CourseSelectionForm
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
            this._courseSelectionGrid = new System.Windows.Forms.DataGridView();
            this._courseCheckSelectionResultButton = new System.Windows.Forms.Button();
            this._flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this._courseSubmitButton = new System.Windows.Forms.Button();
            this._courseCheckBox = new System.Windows.Forms.DataGridViewCheckBoxColumn();
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
            ((System.ComponentModel.ISupportInitialize)(this._courseSelectionGrid)).BeginInit();
            this._flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // _courseSelectionGrid
            // 
            this._courseSelectionGrid.AllowUserToAddRows = false;
            this._courseSelectionGrid.AllowUserToDeleteRows = false;
            this._courseSelectionGrid.AllowUserToOrderColumns = true;
            this._courseSelectionGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this._courseSelectionGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._courseSelectionGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this._courseCheckBox,
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
            this._courseSelectionGrid.Location = new System.Drawing.Point(0, 0);
            this._courseSelectionGrid.Name = "_courseSelectionGrid";
            this._courseSelectionGrid.RowTemplate.Height = 24;
            this._courseSelectionGrid.Size = new System.Drawing.Size(1241, 450);
            this._courseSelectionGrid.TabIndex = 0;
            // 
            // _courseCheckSelectionResultButton
            // 
            this._courseCheckSelectionResultButton.Location = new System.Drawing.Point(1022, 6);
            this._courseCheckSelectionResultButton.Name = "_courseCheckSelectionResultButton";
            this._courseCheckSelectionResultButton.Size = new System.Drawing.Size(210, 82);
            this._courseCheckSelectionResultButton.TabIndex = 2;
            this._courseCheckSelectionResultButton.Text = "查看選課結果";
            this._courseCheckSelectionResultButton.UseVisualStyleBackColor = true;
            // 
            // _flowLayoutPanel1
            // 
            this._flowLayoutPanel1.AutoSize = true;
            this._flowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this._flowLayoutPanel1.Controls.Add(this._courseCheckSelectionResultButton);
            this._flowLayoutPanel1.Controls.Add(this._courseSubmitButton);
            this._flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this._flowLayoutPanel1.Location = new System.Drawing.Point(0, 450);
            this._flowLayoutPanel1.Name = "_flowLayoutPanel1";
            this._flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(3);
            this._flowLayoutPanel1.Size = new System.Drawing.Size(1241, 94);
            this._flowLayoutPanel1.TabIndex = 3;
            // 
            // _courseSubmitButton
            // 
            this._courseSubmitButton.Location = new System.Drawing.Point(806, 6);
            this._courseSubmitButton.Name = "_courseSubmitButton";
            this._courseSubmitButton.Size = new System.Drawing.Size(210, 82);
            this._courseSubmitButton.TabIndex = 3;
            this._courseSubmitButton.Text = "確認送出";
            this._courseSubmitButton.UseVisualStyleBackColor = true;
            // 
            // _courseCheckBox
            // 
            this._courseCheckBox.DataPropertyName = "IsCourseSelected";
            this._courseCheckBox.FalseValue = "false";
            this._courseCheckBox.HeaderText = "選擇";
            this._courseCheckBox.Name = "_courseCheckBox";
            this._courseCheckBox.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this._courseCheckBox.TrueValue = "true";
            this._courseCheckBox.Width = 35;
            // 
            // _courseIdTextBox
            // 
            this._courseIdTextBox.DataPropertyName = "Course.Id";
            this._courseIdTextBox.HeaderText = "課號";
            this._courseIdTextBox.Name = "_courseIdTextBox";
            this._courseIdTextBox.ReadOnly = true;
            this._courseIdTextBox.Width = 54;
            // 
            // _courseNameTextBox
            // 
            this._courseNameTextBox.DataPropertyName = "Course.Info.Name";
            this._courseNameTextBox.HeaderText = "課程名稱";
            this._courseNameTextBox.Name = "_courseNameTextBox";
            this._courseNameTextBox.ReadOnly = true;
            this._courseNameTextBox.Width = 78;
            // 
            // _courseStageTextBox
            // 
            this._courseStageTextBox.DataPropertyName = "Course.Info.Stage";
            this._courseStageTextBox.HeaderText = "階段";
            this._courseStageTextBox.Name = "_courseStageTextBox";
            this._courseStageTextBox.ReadOnly = true;
            this._courseStageTextBox.Width = 54;
            // 
            // _courseCreditsTextBox
            // 
            this._courseCreditsTextBox.DataPropertyName = "Course.SelectionInfo.Credits";
            this._courseCreditsTextBox.HeaderText = "學分";
            this._courseCreditsTextBox.Name = "_courseCreditsTextBox";
            this._courseCreditsTextBox.ReadOnly = true;
            this._courseCreditsTextBox.Width = 54;
            // 
            // _courseHoursTextBox
            // 
            this._courseHoursTextBox.DataPropertyName = "Course.SelectionInfo.Hours";
            this._courseHoursTextBox.HeaderText = "時數";
            this._courseHoursTextBox.Name = "_courseHoursTextBox";
            this._courseHoursTextBox.ReadOnly = true;
            this._courseHoursTextBox.Width = 54;
            // 
            // _courseRequiredOrElectiveTextBox
            // 
            this._courseRequiredOrElectiveTextBox.DataPropertyName = "Course.Info.RequiredOrElectiveCourse";
            this._courseRequiredOrElectiveTextBox.HeaderText = "必/選修";
            this._courseRequiredOrElectiveTextBox.Name = "_courseRequiredOrElectiveTextBox";
            this._courseRequiredOrElectiveTextBox.ReadOnly = true;
            this._courseRequiredOrElectiveTextBox.Width = 69;
            // 
            // _courseTeacherTextBox
            // 
            this._courseTeacherTextBox.DataPropertyName = "Course.Info.Teacher";
            this._courseTeacherTextBox.HeaderText = "教師";
            this._courseTeacherTextBox.Name = "_courseTeacherTextBox";
            this._courseTeacherTextBox.ReadOnly = true;
            this._courseTeacherTextBox.Width = 54;
            // 
            // _courseTimeForSundayTextBox
            // 
            this._courseTimeForSundayTextBox.DataPropertyName = "Course.ClassTime.Sunday";
            this._courseTimeForSundayTextBox.HeaderText = "日";
            this._courseTimeForSundayTextBox.Name = "_courseTimeForSundayTextBox";
            this._courseTimeForSundayTextBox.ReadOnly = true;
            this._courseTimeForSundayTextBox.Width = 42;
            // 
            // _courseTimeForMondayTextBox
            // 
            this._courseTimeForMondayTextBox.DataPropertyName = "Course.ClassTime.Monday";
            this._courseTimeForMondayTextBox.HeaderText = "一";
            this._courseTimeForMondayTextBox.Name = "_courseTimeForMondayTextBox";
            this._courseTimeForMondayTextBox.ReadOnly = true;
            this._courseTimeForMondayTextBox.Width = 42;
            // 
            // _courseTimeForTuesdayTextBox
            // 
            this._courseTimeForTuesdayTextBox.DataPropertyName = "Course.ClassTime.Tuesday";
            this._courseTimeForTuesdayTextBox.HeaderText = "二";
            this._courseTimeForTuesdayTextBox.Name = "_courseTimeForTuesdayTextBox";
            this._courseTimeForTuesdayTextBox.ReadOnly = true;
            this._courseTimeForTuesdayTextBox.Width = 42;
            // 
            // _courseTimeForWednesdayTextBox
            // 
            this._courseTimeForWednesdayTextBox.DataPropertyName = "Course.ClassTime.Wednesday";
            this._courseTimeForWednesdayTextBox.HeaderText = "三";
            this._courseTimeForWednesdayTextBox.Name = "_courseTimeForWednesdayTextBox";
            this._courseTimeForWednesdayTextBox.ReadOnly = true;
            this._courseTimeForWednesdayTextBox.Width = 42;
            // 
            // _courseTimeForThursdayTextBox
            // 
            this._courseTimeForThursdayTextBox.DataPropertyName = "Course.ClassTime.Thursday";
            this._courseTimeForThursdayTextBox.HeaderText = "四";
            this._courseTimeForThursdayTextBox.Name = "_courseTimeForThursdayTextBox";
            this._courseTimeForThursdayTextBox.ReadOnly = true;
            this._courseTimeForThursdayTextBox.Width = 42;
            // 
            // _courseTimeForFridayTextBox
            // 
            this._courseTimeForFridayTextBox.DataPropertyName = "Course.ClassTime.Friday";
            this._courseTimeForFridayTextBox.HeaderText = "五";
            this._courseTimeForFridayTextBox.Name = "_courseTimeForFridayTextBox";
            this._courseTimeForFridayTextBox.ReadOnly = true;
            this._courseTimeForFridayTextBox.Width = 42;
            // 
            // _courseTimeForSaturdayTextBox
            // 
            this._courseTimeForSaturdayTextBox.DataPropertyName = "Course.ClassTime.Saturday";
            this._courseTimeForSaturdayTextBox.HeaderText = "六";
            this._courseTimeForSaturdayTextBox.Name = "_courseTimeForSaturdayTextBox";
            this._courseTimeForSaturdayTextBox.ReadOnly = true;
            this._courseTimeForSaturdayTextBox.Width = 42;
            // 
            // _courseClassRoomTextBox
            // 
            this._courseClassRoomTextBox.DataPropertyName = "Course.Info.ClassRoom";
            this._courseClassRoomTextBox.HeaderText = "教室";
            this._courseClassRoomTextBox.Name = "_courseClassRoomTextBox";
            this._courseClassRoomTextBox.ReadOnly = true;
            this._courseClassRoomTextBox.Width = 54;
            // 
            // _courseNumberOfStudentsTextBox
            // 
            this._courseNumberOfStudentsTextBox.DataPropertyName = "Course.Status.NumberOfStudents";
            this._courseNumberOfStudentsTextBox.HeaderText = "修課人數";
            this._courseNumberOfStudentsTextBox.Name = "_courseNumberOfStudentsTextBox";
            this._courseNumberOfStudentsTextBox.ReadOnly = true;
            this._courseNumberOfStudentsTextBox.Width = 78;
            // 
            // _courseNumberOfDropStudentsTextBox
            // 
            this._courseNumberOfDropStudentsTextBox.DataPropertyName = "Course.Status.NumberOfDropStudents";
            this._courseNumberOfDropStudentsTextBox.HeaderText = "徹選人數";
            this._courseNumberOfDropStudentsTextBox.Name = "_courseNumberOfDropStudentsTextBox";
            this._courseNumberOfDropStudentsTextBox.ReadOnly = true;
            this._courseNumberOfDropStudentsTextBox.Width = 78;
            // 
            // _courseTeachingAssistantTextBox
            // 
            this._courseTeachingAssistantTextBox.DataPropertyName = "Course.Info.TeachingAssistant";
            this._courseTeachingAssistantTextBox.HeaderText = "教學助理";
            this._courseTeachingAssistantTextBox.Name = "_courseTeachingAssistantTextBox";
            this._courseTeachingAssistantTextBox.ReadOnly = true;
            this._courseTeachingAssistantTextBox.Width = 78;
            // 
            // _courseLanguageTextBox
            // 
            this._courseLanguageTextBox.DataPropertyName = "Course.OtherInfo.Language";
            this._courseLanguageTextBox.HeaderText = "授課語言";
            this._courseLanguageTextBox.Name = "_courseLanguageTextBox";
            this._courseLanguageTextBox.ReadOnly = true;
            this._courseLanguageTextBox.Width = 78;
            // 
            // _courseSyllabusLink
            // 
            this._courseSyllabusLink.DataPropertyName = "Course.OtherInfo.Syllabus";
            this._courseSyllabusLink.HeaderText = "教學大綱與進度表";
            this._courseSyllabusLink.Name = "_courseSyllabusLink";
            this._courseSyllabusLink.ReadOnly = true;
            this._courseSyllabusLink.Text = "查詢";
            this._courseSyllabusLink.Width = 64;
            // 
            // _courseNoteTextBox
            // 
            this._courseNoteTextBox.DataPropertyName = "Course.OtherInfo.Note";
            this._courseNoteTextBox.HeaderText = "備註";
            this._courseNoteTextBox.Name = "_courseNoteTextBox";
            this._courseNoteTextBox.ReadOnly = true;
            this._courseNoteTextBox.Width = 51;
            // 
            // _courseAuditTextBox
            // 
            this._courseAuditTextBox.DataPropertyName = "Course.OtherInfo.Audit";
            this._courseAuditTextBox.HeaderText = "隨班附讀";
            this._courseAuditTextBox.Name = "_courseAuditTextBox";
            this._courseAuditTextBox.ReadOnly = true;
            this._courseAuditTextBox.Width = 61;
            // 
            // _courseExperimentTextBox
            // 
            this._courseExperimentTextBox.DataPropertyName = "Course.OtherInfo.Experiment";
            this._courseExperimentTextBox.HeaderText = "實驗實習";
            this._courseExperimentTextBox.Name = "_courseExperimentTextBox";
            this._courseExperimentTextBox.ReadOnly = true;
            this._courseExperimentTextBox.Width = 61;
            // 
            // CourseSelectionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.ClientSize = new System.Drawing.Size(1241, 544);
            this.Controls.Add(this._flowLayoutPanel1);
            this.Controls.Add(this._courseSelectionGrid);
            this.Name = "CourseSelectionForm";
            this.Text = "CourseSelectionForm";
            ((System.ComponentModel.ISupportInitialize)(this._courseSelectionGrid)).EndInit();
            this._flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView _courseSelectionGrid;
        private System.Windows.Forms.Button _courseCheckSelectionResultButton;
        private System.Windows.Forms.FlowLayoutPanel _flowLayoutPanel1;
        private System.Windows.Forms.Button _courseSubmitButton;
        private System.Windows.Forms.DataGridViewCheckBoxColumn _courseCheckBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn _courseIdTextBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn _courseNameTextBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn _courseStageTextBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn _courseCreditsTextBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn _courseHoursTextBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn _courseRequiredOrElectiveTextBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn _courseTeacherTextBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn _courseTimeForSundayTextBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn _courseTimeForMondayTextBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn _courseTimeForTuesdayTextBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn _courseTimeForWednesdayTextBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn _courseTimeForThursdayTextBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn _courseTimeForFridayTextBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn _courseTimeForSaturdayTextBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn _courseClassRoomTextBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn _courseNumberOfStudentsTextBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn _courseNumberOfDropStudentsTextBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn _courseTeachingAssistantTextBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn _courseLanguageTextBox;
        private System.Windows.Forms.DataGridViewLinkColumn _courseSyllabusLink;
        private System.Windows.Forms.DataGridViewTextBoxColumn _courseNoteTextBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn _courseAuditTextBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn _courseExperimentTextBox;
    }
}