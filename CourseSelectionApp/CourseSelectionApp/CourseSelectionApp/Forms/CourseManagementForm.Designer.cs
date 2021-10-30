
namespace CourseSelectionApp.Forms
{
    partial class CourseManagementForm
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
            this._tabControl = new System.Windows.Forms.TabControl();
            this._courseManagementPage = new System.Windows.Forms.TabPage();
            this._horizontalSplitContainer = new System.Windows.Forms.SplitContainer();
            this._verticalSplitContainer = new System.Windows.Forms.SplitContainer();
            this._courseList = new System.Windows.Forms.ListBox();
            this._courseEditor = new System.Windows.Forms.GroupBox();
            this._classManagementPage = new System.Windows.Forms.TabPage();
            this._classHintLabel = new System.Windows.Forms.Label();
            this._newCourseButton = new System.Windows.Forms.Button();
            this._saveCourseButton = new System.Windows.Forms.Button();
            this._courseEditorSplitContainer = new System.Windows.Forms.SplitContainer();
            this._courseEditorFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this._courseEditorLine1 = new System.Windows.Forms.FlowLayoutPanel();
            this._courseActivateComboBox = new System.Windows.Forms.ComboBox();
            this._courseIdLabel = new System.Windows.Forms.Label();
            this._courseNameLabel = new System.Windows.Forms.Label();
            this._courseEditorLine2 = new System.Windows.Forms.FlowLayoutPanel();
            this._courseStageLabel = new System.Windows.Forms.Label();
            this._courseStageTextBox = new System.Windows.Forms.TextBox();
            this._courseCreditLabel = new System.Windows.Forms.Label();
            this._courseCreditTextBox = new System.Windows.Forms.TextBox();
            this._courseTeacherLabel = new System.Windows.Forms.Label();
            this._courseTeacherTextBox = new System.Windows.Forms.TextBox();
            this._courseElectiveLabel = new System.Windows.Forms.Label();
            this._courseElectiveComboBox = new System.Windows.Forms.ComboBox();
            this._courseEditorLine3 = new System.Windows.Forms.FlowLayoutPanel();
            this._courseTeachingAssistantLabel = new System.Windows.Forms.Label();
            this._courseTeachingAssistantTextBox = new System.Windows.Forms.TextBox();
            this._courseLanguageLabel = new System.Windows.Forms.Label();
            this._courseLanguageTextBox = new System.Windows.Forms.TextBox();
            this._courseEditorLine4 = new System.Windows.Forms.FlowLayoutPanel();
            this._courseNoteLabel = new System.Windows.Forms.Label();
            this._courseNoteTextBox = new System.Windows.Forms.TextBox();
            this._courseEditorLine5 = new System.Windows.Forms.FlowLayoutPanel();
            this._courseHoursLabel = new System.Windows.Forms.Label();
            this._courseHoursComboBox = new System.Windows.Forms.ComboBox();
            this._classLabel = new System.Windows.Forms.Label();
            this._classComboBox = new System.Windows.Forms.ComboBox();
            this._courseTimeSelectionGrid = new System.Windows.Forms.DataGridView();
            this._courseIdTextBox = new System.Windows.Forms.TextBox();
            this._courseNameTextBox = new System.Windows.Forms.TextBox();
            this._courseSectionColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._courseSundayColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this._courseMondayColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this._courseTuesdayColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this._courseWednesdayColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this._courseThursdayColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this._courseFridayColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this._courseSaturdayColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this._tabControl.SuspendLayout();
            this._courseManagementPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._horizontalSplitContainer)).BeginInit();
            this._horizontalSplitContainer.Panel1.SuspendLayout();
            this._horizontalSplitContainer.Panel2.SuspendLayout();
            this._horizontalSplitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._verticalSplitContainer)).BeginInit();
            this._verticalSplitContainer.Panel1.SuspendLayout();
            this._verticalSplitContainer.Panel2.SuspendLayout();
            this._verticalSplitContainer.SuspendLayout();
            this._courseEditor.SuspendLayout();
            this._classManagementPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._courseEditorSplitContainer)).BeginInit();
            this._courseEditorSplitContainer.Panel1.SuspendLayout();
            this._courseEditorSplitContainer.Panel2.SuspendLayout();
            this._courseEditorSplitContainer.SuspendLayout();
            this._courseEditorFlowLayoutPanel.SuspendLayout();
            this._courseEditorLine1.SuspendLayout();
            this._courseEditorLine2.SuspendLayout();
            this._courseEditorLine3.SuspendLayout();
            this._courseEditorLine4.SuspendLayout();
            this._courseEditorLine5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._courseTimeSelectionGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // _tabControl
            // 
            this._tabControl.Controls.Add(this._courseManagementPage);
            this._tabControl.Controls.Add(this._classManagementPage);
            this._tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this._tabControl.Location = new System.Drawing.Point(0, 0);
            this._tabControl.Name = "_tabControl";
            this._tabControl.SelectedIndex = 0;
            this._tabControl.Size = new System.Drawing.Size(1059, 600);
            this._tabControl.TabIndex = 0;
            // 
            // _courseManagementPage
            // 
            this._courseManagementPage.Controls.Add(this._horizontalSplitContainer);
            this._courseManagementPage.Location = new System.Drawing.Point(4, 25);
            this._courseManagementPage.Name = "_courseManagementPage";
            this._courseManagementPage.Padding = new System.Windows.Forms.Padding(5);
            this._courseManagementPage.Size = new System.Drawing.Size(1051, 571);
            this._courseManagementPage.TabIndex = 0;
            this._courseManagementPage.Text = "課程管理";
            this._courseManagementPage.UseVisualStyleBackColor = true;
            // 
            // _horizontalSplitContainer
            // 
            this._horizontalSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this._horizontalSplitContainer.Location = new System.Drawing.Point(5, 5);
            this._horizontalSplitContainer.Name = "_horizontalSplitContainer";
            this._horizontalSplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // _horizontalSplitContainer.Panel1
            // 
            this._horizontalSplitContainer.Panel1.Controls.Add(this._verticalSplitContainer);
            // 
            // _horizontalSplitContainer.Panel2
            // 
            this._horizontalSplitContainer.Panel2.Controls.Add(this._saveCourseButton);
            this._horizontalSplitContainer.Panel2.Controls.Add(this._newCourseButton);
            this._horizontalSplitContainer.Panel2.Padding = new System.Windows.Forms.Padding(0, 3, 5, 0);
            this._horizontalSplitContainer.Size = new System.Drawing.Size(1041, 561);
            this._horizontalSplitContainer.SplitterDistance = 495;
            this._horizontalSplitContainer.TabIndex = 0;
            // 
            // _verticalSplitContainer
            // 
            this._verticalSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this._verticalSplitContainer.Location = new System.Drawing.Point(0, 0);
            this._verticalSplitContainer.Name = "_verticalSplitContainer";
            // 
            // _verticalSplitContainer.Panel1
            // 
            this._verticalSplitContainer.Panel1.Controls.Add(this._courseList);
            // 
            // _verticalSplitContainer.Panel2
            // 
            this._verticalSplitContainer.Panel2.Controls.Add(this._courseEditor);
            this._verticalSplitContainer.Size = new System.Drawing.Size(1041, 495);
            this._verticalSplitContainer.SplitterDistance = 248;
            this._verticalSplitContainer.TabIndex = 0;
            // 
            // _courseList
            // 
            this._courseList.Dock = System.Windows.Forms.DockStyle.Fill;
            this._courseList.FormattingEnabled = true;
            this._courseList.ItemHeight = 16;
            this._courseList.Location = new System.Drawing.Point(0, 0);
            this._courseList.Name = "_courseList";
            this._courseList.Size = new System.Drawing.Size(248, 495);
            this._courseList.TabIndex = 0;
            // 
            // _courseEditor
            // 
            this._courseEditor.AutoSize = true;
            this._courseEditor.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this._courseEditor.Controls.Add(this._courseEditorSplitContainer);
            this._courseEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            this._courseEditor.Location = new System.Drawing.Point(0, 0);
            this._courseEditor.Name = "_courseEditor";
            this._courseEditor.Padding = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this._courseEditor.Size = new System.Drawing.Size(789, 495);
            this._courseEditor.TabIndex = 0;
            this._courseEditor.TabStop = false;
            this._courseEditor.Text = "編輯課程";
            // 
            // _classManagementPage
            // 
            this._classManagementPage.Controls.Add(this._classHintLabel);
            this._classManagementPage.Location = new System.Drawing.Point(4, 25);
            this._classManagementPage.Name = "_classManagementPage";
            this._classManagementPage.Padding = new System.Windows.Forms.Padding(3);
            this._classManagementPage.Size = new System.Drawing.Size(1051, 571);
            this._classManagementPage.TabIndex = 1;
            this._classManagementPage.Text = "班級管理";
            this._classManagementPage.UseVisualStyleBackColor = true;
            // 
            // _classHintLabel
            // 
            this._classHintLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this._classHintLabel.Font = new System.Drawing.Font("微軟正黑體", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this._classHintLabel.Location = new System.Drawing.Point(3, 3);
            this._classHintLabel.Name = "_classHintLabel";
            this._classHintLabel.Size = new System.Drawing.Size(1045, 565);
            this._classHintLabel.TabIndex = 0;
            this._classHintLabel.Text = "Comming Soon";
            this._classHintLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _newCourseButton
            // 
            this._newCourseButton.AutoSize = true;
            this._newCourseButton.Dock = System.Windows.Forms.DockStyle.Left;
            this._newCourseButton.Location = new System.Drawing.Point(0, 3);
            this._newCourseButton.Name = "_newCourseButton";
            this._newCourseButton.Size = new System.Drawing.Size(248, 59);
            this._newCourseButton.TabIndex = 0;
            this._newCourseButton.Text = "新增課程";
            this._newCourseButton.UseVisualStyleBackColor = true;
            // 
            // _saveCourseButton
            // 
            this._saveCourseButton.Dock = System.Windows.Forms.DockStyle.Right;
            this._saveCourseButton.Location = new System.Drawing.Point(863, 3);
            this._saveCourseButton.Name = "_saveCourseButton";
            this._saveCourseButton.Size = new System.Drawing.Size(173, 59);
            this._saveCourseButton.TabIndex = 1;
            this._saveCourseButton.Text = "儲存";
            this._saveCourseButton.UseVisualStyleBackColor = true;
            // 
            // _courseEditorSplitContainer
            // 
            this._courseEditorSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this._courseEditorSplitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this._courseEditorSplitContainer.Location = new System.Drawing.Point(3, 21);
            this._courseEditorSplitContainer.Name = "_courseEditorSplitContainer";
            this._courseEditorSplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // _courseEditorSplitContainer.Panel1
            // 
            this._courseEditorSplitContainer.Panel1.Controls.Add(this._courseEditorFlowLayoutPanel);
            // 
            // _courseEditorSplitContainer.Panel2
            // 
            this._courseEditorSplitContainer.Panel2.Controls.Add(this._courseTimeSelectionGrid);
            this._courseEditorSplitContainer.Size = new System.Drawing.Size(783, 471);
            this._courseEditorSplitContainer.SplitterDistance = 190;
            this._courseEditorSplitContainer.TabIndex = 26;
            // 
            // _courseEditorFlowLayoutPanel
            // 
            this._courseEditorFlowLayoutPanel.AutoSize = true;
            this._courseEditorFlowLayoutPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this._courseEditorFlowLayoutPanel.Controls.Add(this._courseEditorLine1);
            this._courseEditorFlowLayoutPanel.Controls.Add(this._courseEditorLine2);
            this._courseEditorFlowLayoutPanel.Controls.Add(this._courseEditorLine3);
            this._courseEditorFlowLayoutPanel.Controls.Add(this._courseEditorLine4);
            this._courseEditorFlowLayoutPanel.Controls.Add(this._courseEditorLine5);
            this._courseEditorFlowLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this._courseEditorFlowLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this._courseEditorFlowLayoutPanel.Name = "_courseEditorFlowLayoutPanel";
            this._courseEditorFlowLayoutPanel.Size = new System.Drawing.Size(783, 190);
            this._courseEditorFlowLayoutPanel.TabIndex = 1;
            // 
            // _courseEditorLine1
            // 
            this._courseEditorLine1.AutoSize = true;
            this._courseEditorLine1.Controls.Add(this._courseActivateComboBox);
            this._courseEditorLine1.Controls.Add(this._courseIdLabel);
            this._courseEditorLine1.Controls.Add(this._courseIdTextBox);
            this._courseEditorLine1.Controls.Add(this._courseNameLabel);
            this._courseEditorLine1.Controls.Add(this._courseNameTextBox);
            this._courseEditorLine1.Dock = System.Windows.Forms.DockStyle.Fill;
            this._courseEditorLine1.Location = new System.Drawing.Point(3, 3);
            this._courseEditorLine1.Margin = new System.Windows.Forms.Padding(3, 3, 3, 5);
            this._courseEditorLine1.Name = "_courseEditorLine1";
            this._courseEditorLine1.Size = new System.Drawing.Size(779, 30);
            this._courseEditorLine1.TabIndex = 10;
            this._courseEditorLine1.WrapContents = false;
            // 
            // _courseActivateComboBox
            // 
            this._courseActivateComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._courseActivateComboBox.FormattingEnabled = true;
            this._courseActivateComboBox.Location = new System.Drawing.Point(3, 3);
            this._courseActivateComboBox.Name = "_courseActivateComboBox";
            this._courseActivateComboBox.Size = new System.Drawing.Size(91, 24);
            this._courseActivateComboBox.TabIndex = 0;
            // 
            // _courseIdLabel
            // 
            this._courseIdLabel.AutoSize = true;
            this._courseIdLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this._courseIdLabel.Location = new System.Drawing.Point(100, 0);
            this._courseIdLabel.MinimumSize = new System.Drawing.Size(60, 0);
            this._courseIdLabel.Name = "_courseIdLabel";
            this._courseIdLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._courseIdLabel.Size = new System.Drawing.Size(60, 30);
            this._courseIdLabel.TabIndex = 9;
            this._courseIdLabel.Text = "課號(*)";
            this._courseIdLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _courseNameLabel
            // 
            this._courseNameLabel.AutoSize = true;
            this._courseNameLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this._courseNameLabel.Location = new System.Drawing.Point(355, 0);
            this._courseNameLabel.MinimumSize = new System.Drawing.Size(60, 0);
            this._courseNameLabel.Name = "_courseNameLabel";
            this._courseNameLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._courseNameLabel.Size = new System.Drawing.Size(69, 30);
            this._courseNameLabel.TabIndex = 10;
            this._courseNameLabel.Text = "課程名稱(*)";
            this._courseNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _courseEditorLine2
            // 
            this._courseEditorLine2.AutoSize = true;
            this._courseEditorLine2.Controls.Add(this._courseStageLabel);
            this._courseEditorLine2.Controls.Add(this._courseStageTextBox);
            this._courseEditorLine2.Controls.Add(this._courseCreditLabel);
            this._courseEditorLine2.Controls.Add(this._courseCreditTextBox);
            this._courseEditorLine2.Controls.Add(this._courseTeacherLabel);
            this._courseEditorLine2.Controls.Add(this._courseTeacherTextBox);
            this._courseEditorLine2.Controls.Add(this._courseElectiveLabel);
            this._courseEditorLine2.Controls.Add(this._courseElectiveComboBox);
            this._courseEditorLine2.Dock = System.Windows.Forms.DockStyle.Fill;
            this._courseEditorLine2.Location = new System.Drawing.Point(3, 41);
            this._courseEditorLine2.Margin = new System.Windows.Forms.Padding(3, 3, 3, 5);
            this._courseEditorLine2.Name = "_courseEditorLine2";
            this._courseEditorLine2.Size = new System.Drawing.Size(779, 30);
            this._courseEditorLine2.TabIndex = 12;
            this._courseEditorLine2.WrapContents = false;
            // 
            // _courseStageLabel
            // 
            this._courseStageLabel.AutoSize = true;
            this._courseStageLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this._courseStageLabel.Location = new System.Drawing.Point(3, 0);
            this._courseStageLabel.MinimumSize = new System.Drawing.Size(60, 0);
            this._courseStageLabel.Name = "_courseStageLabel";
            this._courseStageLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._courseStageLabel.Size = new System.Drawing.Size(60, 30);
            this._courseStageLabel.TabIndex = 9;
            this._courseStageLabel.Text = "階段(*)";
            this._courseStageLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _courseStageTextBox
            // 
            this._courseStageTextBox.Location = new System.Drawing.Point(69, 3);
            this._courseStageTextBox.Name = "_courseStageTextBox";
            this._courseStageTextBox.Size = new System.Drawing.Size(115, 23);
            this._courseStageTextBox.TabIndex = 20;
            // 
            // _courseCreditLabel
            // 
            this._courseCreditLabel.AutoSize = true;
            this._courseCreditLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this._courseCreditLabel.Location = new System.Drawing.Point(190, 0);
            this._courseCreditLabel.MinimumSize = new System.Drawing.Size(60, 0);
            this._courseCreditLabel.Name = "_courseCreditLabel";
            this._courseCreditLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._courseCreditLabel.Size = new System.Drawing.Size(60, 30);
            this._courseCreditLabel.TabIndex = 10;
            this._courseCreditLabel.Text = "學分(*)";
            this._courseCreditLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _courseCreditTextBox
            // 
            this._courseCreditTextBox.Location = new System.Drawing.Point(256, 3);
            this._courseCreditTextBox.Name = "_courseCreditTextBox";
            this._courseCreditTextBox.Size = new System.Drawing.Size(131, 23);
            this._courseCreditTextBox.TabIndex = 18;
            // 
            // _courseTeacherLabel
            // 
            this._courseTeacherLabel.AutoSize = true;
            this._courseTeacherLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this._courseTeacherLabel.Location = new System.Drawing.Point(393, 0);
            this._courseTeacherLabel.MinimumSize = new System.Drawing.Size(60, 0);
            this._courseTeacherLabel.Name = "_courseTeacherLabel";
            this._courseTeacherLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._courseTeacherLabel.Size = new System.Drawing.Size(60, 30);
            this._courseTeacherLabel.TabIndex = 12;
            this._courseTeacherLabel.Text = "教師(*)";
            this._courseTeacherLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _courseTeacherTextBox
            // 
            this._courseTeacherTextBox.Location = new System.Drawing.Point(459, 3);
            this._courseTeacherTextBox.Name = "_courseTeacherTextBox";
            this._courseTeacherTextBox.Size = new System.Drawing.Size(131, 23);
            this._courseTeacherTextBox.TabIndex = 19;
            // 
            // _courseElectiveLabel
            // 
            this._courseElectiveLabel.AutoSize = true;
            this._courseElectiveLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this._courseElectiveLabel.Location = new System.Drawing.Point(596, 0);
            this._courseElectiveLabel.MinimumSize = new System.Drawing.Size(60, 0);
            this._courseElectiveLabel.Name = "_courseElectiveLabel";
            this._courseElectiveLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._courseElectiveLabel.Size = new System.Drawing.Size(60, 30);
            this._courseElectiveLabel.TabIndex = 16;
            this._courseElectiveLabel.Text = "修(*)";
            this._courseElectiveLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _courseElectiveComboBox
            // 
            this._courseElectiveComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._courseElectiveComboBox.FormattingEnabled = true;
            this._courseElectiveComboBox.Location = new System.Drawing.Point(662, 3);
            this._courseElectiveComboBox.Name = "_courseElectiveComboBox";
            this._courseElectiveComboBox.Size = new System.Drawing.Size(114, 24);
            this._courseElectiveComboBox.TabIndex = 17;
            // 
            // _courseEditorLine3
            // 
            this._courseEditorLine3.AutoSize = true;
            this._courseEditorLine3.Controls.Add(this._courseTeachingAssistantLabel);
            this._courseEditorLine3.Controls.Add(this._courseTeachingAssistantTextBox);
            this._courseEditorLine3.Controls.Add(this._courseLanguageLabel);
            this._courseEditorLine3.Controls.Add(this._courseLanguageTextBox);
            this._courseEditorLine3.Dock = System.Windows.Forms.DockStyle.Fill;
            this._courseEditorLine3.Location = new System.Drawing.Point(3, 79);
            this._courseEditorLine3.Margin = new System.Windows.Forms.Padding(3, 3, 3, 5);
            this._courseEditorLine3.Name = "_courseEditorLine3";
            this._courseEditorLine3.Size = new System.Drawing.Size(779, 29);
            this._courseEditorLine3.TabIndex = 21;
            this._courseEditorLine3.WrapContents = false;
            // 
            // _courseTeachingAssistantLabel
            // 
            this._courseTeachingAssistantLabel.AutoSize = true;
            this._courseTeachingAssistantLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this._courseTeachingAssistantLabel.Location = new System.Drawing.Point(3, 0);
            this._courseTeachingAssistantLabel.MinimumSize = new System.Drawing.Size(75, 0);
            this._courseTeachingAssistantLabel.Name = "_courseTeachingAssistantLabel";
            this._courseTeachingAssistantLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._courseTeachingAssistantLabel.Size = new System.Drawing.Size(75, 29);
            this._courseTeachingAssistantLabel.TabIndex = 9;
            this._courseTeachingAssistantLabel.Text = "教學助理";
            this._courseTeachingAssistantLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _courseTeachingAssistantTextBox
            // 
            this._courseTeachingAssistantTextBox.Location = new System.Drawing.Point(84, 3);
            this._courseTeachingAssistantTextBox.Name = "_courseTeachingAssistantTextBox";
            this._courseTeachingAssistantTextBox.Size = new System.Drawing.Size(303, 23);
            this._courseTeachingAssistantTextBox.TabIndex = 20;
            // 
            // _courseLanguageLabel
            // 
            this._courseLanguageLabel.AutoSize = true;
            this._courseLanguageLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this._courseLanguageLabel.Location = new System.Drawing.Point(393, 0);
            this._courseLanguageLabel.MinimumSize = new System.Drawing.Size(60, 0);
            this._courseLanguageLabel.Name = "_courseLanguageLabel";
            this._courseLanguageLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._courseLanguageLabel.Size = new System.Drawing.Size(60, 29);
            this._courseLanguageLabel.TabIndex = 12;
            this._courseLanguageLabel.Text = "授課語言";
            this._courseLanguageLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _courseLanguageTextBox
            // 
            this._courseLanguageTextBox.Location = new System.Drawing.Point(459, 3);
            this._courseLanguageTextBox.Name = "_courseLanguageTextBox";
            this._courseLanguageTextBox.Size = new System.Drawing.Size(317, 23);
            this._courseLanguageTextBox.TabIndex = 19;
            // 
            // _courseEditorLine4
            // 
            this._courseEditorLine4.AutoSize = true;
            this._courseEditorLine4.Controls.Add(this._courseNoteLabel);
            this._courseEditorLine4.Controls.Add(this._courseNoteTextBox);
            this._courseEditorLine4.Dock = System.Windows.Forms.DockStyle.Fill;
            this._courseEditorLine4.Location = new System.Drawing.Point(3, 116);
            this._courseEditorLine4.Margin = new System.Windows.Forms.Padding(3, 3, 3, 5);
            this._courseEditorLine4.Name = "_courseEditorLine4";
            this._courseEditorLine4.Size = new System.Drawing.Size(779, 29);
            this._courseEditorLine4.TabIndex = 22;
            this._courseEditorLine4.WrapContents = false;
            // 
            // _courseNoteLabel
            // 
            this._courseNoteLabel.AutoSize = true;
            this._courseNoteLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this._courseNoteLabel.Location = new System.Drawing.Point(3, 0);
            this._courseNoteLabel.MinimumSize = new System.Drawing.Size(60, 0);
            this._courseNoteLabel.Name = "_courseNoteLabel";
            this._courseNoteLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._courseNoteLabel.Size = new System.Drawing.Size(60, 29);
            this._courseNoteLabel.TabIndex = 9;
            this._courseNoteLabel.Text = "備註";
            this._courseNoteLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _courseNoteTextBox
            // 
            this._courseNoteTextBox.Location = new System.Drawing.Point(69, 3);
            this._courseNoteTextBox.Name = "_courseNoteTextBox";
            this._courseNoteTextBox.Size = new System.Drawing.Size(707, 23);
            this._courseNoteTextBox.TabIndex = 20;
            // 
            // _courseEditorLine5
            // 
            this._courseEditorLine5.AutoSize = true;
            this._courseEditorLine5.Controls.Add(this._courseHoursLabel);
            this._courseEditorLine5.Controls.Add(this._courseHoursComboBox);
            this._courseEditorLine5.Controls.Add(this._classLabel);
            this._courseEditorLine5.Controls.Add(this._classComboBox);
            this._courseEditorLine5.Dock = System.Windows.Forms.DockStyle.Fill;
            this._courseEditorLine5.Location = new System.Drawing.Point(3, 153);
            this._courseEditorLine5.Margin = new System.Windows.Forms.Padding(3, 3, 3, 5);
            this._courseEditorLine5.Name = "_courseEditorLine5";
            this._courseEditorLine5.Size = new System.Drawing.Size(326, 30);
            this._courseEditorLine5.TabIndex = 23;
            this._courseEditorLine5.WrapContents = false;
            // 
            // _courseHoursLabel
            // 
            this._courseHoursLabel.AutoSize = true;
            this._courseHoursLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this._courseHoursLabel.Location = new System.Drawing.Point(3, 0);
            this._courseHoursLabel.MinimumSize = new System.Drawing.Size(60, 0);
            this._courseHoursLabel.Name = "_courseHoursLabel";
            this._courseHoursLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._courseHoursLabel.Size = new System.Drawing.Size(60, 30);
            this._courseHoursLabel.TabIndex = 9;
            this._courseHoursLabel.Text = "時數(*)";
            this._courseHoursLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _courseHoursComboBox
            // 
            this._courseHoursComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._courseHoursComboBox.FormattingEnabled = true;
            this._courseHoursComboBox.Location = new System.Drawing.Point(69, 3);
            this._courseHoursComboBox.Name = "_courseHoursComboBox";
            this._courseHoursComboBox.Size = new System.Drawing.Size(91, 24);
            this._courseHoursComboBox.TabIndex = 21;
            // 
            // _classLabel
            // 
            this._classLabel.AutoSize = true;
            this._classLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this._classLabel.Location = new System.Drawing.Point(166, 0);
            this._classLabel.MinimumSize = new System.Drawing.Size(60, 0);
            this._classLabel.Name = "_classLabel";
            this._classLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._classLabel.Size = new System.Drawing.Size(60, 30);
            this._classLabel.TabIndex = 22;
            this._classLabel.Text = "班級(*)";
            this._classLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _classComboBox
            // 
            this._classComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._classComboBox.FormattingEnabled = true;
            this._classComboBox.Location = new System.Drawing.Point(232, 3);
            this._classComboBox.Name = "_classComboBox";
            this._classComboBox.Size = new System.Drawing.Size(91, 24);
            this._classComboBox.TabIndex = 23;
            // 
            // _courseTimeSelectionGrid
            // 
            this._courseTimeSelectionGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this._courseTimeSelectionGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._courseTimeSelectionGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this._courseSectionColumn,
            this._courseSundayColumn,
            this._courseMondayColumn,
            this._courseTuesdayColumn,
            this._courseWednesdayColumn,
            this._courseThursdayColumn,
            this._courseFridayColumn,
            this._courseSaturdayColumn});
            this._courseTimeSelectionGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this._courseTimeSelectionGrid.Location = new System.Drawing.Point(0, 0);
            this._courseTimeSelectionGrid.Name = "_courseTimeSelectionGrid";
            this._courseTimeSelectionGrid.RowHeadersVisible = false;
            this._courseTimeSelectionGrid.RowTemplate.Height = 24;
            this._courseTimeSelectionGrid.Size = new System.Drawing.Size(783, 277);
            this._courseTimeSelectionGrid.TabIndex = 26;
            // 
            // _courseIdTextBox
            // 
            this._courseIdTextBox.Location = new System.Drawing.Point(166, 3);
            this._courseIdTextBox.Name = "_courseIdTextBox";
            this._courseIdTextBox.Size = new System.Drawing.Size(183, 23);
            this._courseIdTextBox.TabIndex = 21;
            // 
            // _courseNameTextBox
            // 
            this._courseNameTextBox.Location = new System.Drawing.Point(430, 3);
            this._courseNameTextBox.Name = "_courseNameTextBox";
            this._courseNameTextBox.Size = new System.Drawing.Size(346, 23);
            this._courseNameTextBox.TabIndex = 22;
            // 
            // _courseSectionColumn
            // 
            this._courseSectionColumn.HeaderText = "節數";
            this._courseSectionColumn.Name = "_courseSectionColumn";
            // 
            // _courseSundayColumn
            // 
            this._courseSundayColumn.FalseValue = "false";
            this._courseSundayColumn.HeaderText = "日";
            this._courseSundayColumn.Name = "_courseSundayColumn";
            this._courseSundayColumn.TrueValue = "true";
            // 
            // _courseMondayColumn
            // 
            this._courseMondayColumn.FalseValue = "false";
            this._courseMondayColumn.HeaderText = "一";
            this._courseMondayColumn.Name = "_courseMondayColumn";
            this._courseMondayColumn.TrueValue = "true";
            // 
            // _courseTuesdayColumn
            // 
            this._courseTuesdayColumn.FalseValue = "false";
            this._courseTuesdayColumn.HeaderText = "二";
            this._courseTuesdayColumn.Name = "_courseTuesdayColumn";
            this._courseTuesdayColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this._courseTuesdayColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this._courseTuesdayColumn.TrueValue = "true";
            // 
            // _courseWednesdayColumn
            // 
            this._courseWednesdayColumn.FalseValue = "false";
            this._courseWednesdayColumn.HeaderText = "三";
            this._courseWednesdayColumn.Name = "_courseWednesdayColumn";
            this._courseWednesdayColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this._courseWednesdayColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this._courseWednesdayColumn.TrueValue = "true";
            // 
            // _courseThursdayColumn
            // 
            this._courseThursdayColumn.FalseValue = "false";
            this._courseThursdayColumn.HeaderText = "四";
            this._courseThursdayColumn.Name = "_courseThursdayColumn";
            this._courseThursdayColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this._courseThursdayColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this._courseThursdayColumn.TrueValue = "true";
            // 
            // _courseFridayColumn
            // 
            this._courseFridayColumn.FalseValue = "false";
            this._courseFridayColumn.HeaderText = "五";
            this._courseFridayColumn.Name = "_courseFridayColumn";
            this._courseFridayColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this._courseFridayColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this._courseFridayColumn.TrueValue = "true";
            // 
            // _courseSaturdayColumn
            // 
            this._courseSaturdayColumn.FalseValue = "false";
            this._courseSaturdayColumn.HeaderText = "六";
            this._courseSaturdayColumn.Name = "_courseSaturdayColumn";
            this._courseSaturdayColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this._courseSaturdayColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this._courseSaturdayColumn.TrueValue = "true";
            // 
            // CourseManagementForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1059, 600);
            this.Controls.Add(this._tabControl);
            this.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "CourseManagementForm";
            this.Text = "課程管理";
            this._tabControl.ResumeLayout(false);
            this._courseManagementPage.ResumeLayout(false);
            this._horizontalSplitContainer.Panel1.ResumeLayout(false);
            this._horizontalSplitContainer.Panel2.ResumeLayout(false);
            this._horizontalSplitContainer.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._horizontalSplitContainer)).EndInit();
            this._horizontalSplitContainer.ResumeLayout(false);
            this._verticalSplitContainer.Panel1.ResumeLayout(false);
            this._verticalSplitContainer.Panel2.ResumeLayout(false);
            this._verticalSplitContainer.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._verticalSplitContainer)).EndInit();
            this._verticalSplitContainer.ResumeLayout(false);
            this._courseEditor.ResumeLayout(false);
            this._classManagementPage.ResumeLayout(false);
            this._courseEditorSplitContainer.Panel1.ResumeLayout(false);
            this._courseEditorSplitContainer.Panel1.PerformLayout();
            this._courseEditorSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._courseEditorSplitContainer)).EndInit();
            this._courseEditorSplitContainer.ResumeLayout(false);
            this._courseEditorFlowLayoutPanel.ResumeLayout(false);
            this._courseEditorFlowLayoutPanel.PerformLayout();
            this._courseEditorLine1.ResumeLayout(false);
            this._courseEditorLine1.PerformLayout();
            this._courseEditorLine2.ResumeLayout(false);
            this._courseEditorLine2.PerformLayout();
            this._courseEditorLine3.ResumeLayout(false);
            this._courseEditorLine3.PerformLayout();
            this._courseEditorLine4.ResumeLayout(false);
            this._courseEditorLine4.PerformLayout();
            this._courseEditorLine5.ResumeLayout(false);
            this._courseEditorLine5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._courseTimeSelectionGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl _tabControl;
        private System.Windows.Forms.TabPage _courseManagementPage;
        private System.Windows.Forms.TabPage _classManagementPage;
        private System.Windows.Forms.Label _classHintLabel;
        private System.Windows.Forms.SplitContainer _horizontalSplitContainer;
        private System.Windows.Forms.SplitContainer _verticalSplitContainer;
        private System.Windows.Forms.GroupBox _courseEditor;
        private System.Windows.Forms.Button _saveCourseButton;
        private System.Windows.Forms.Button _newCourseButton;
        private System.Windows.Forms.SplitContainer _courseEditorSplitContainer;
        private System.Windows.Forms.FlowLayoutPanel _courseEditorLine1;
        private System.Windows.Forms.ComboBox _courseActivateComboBox;
        private System.Windows.Forms.Label _courseIdLabel;
        private System.Windows.Forms.Label _courseNameLabel;
        private System.Windows.Forms.FlowLayoutPanel _courseEditorLine2;
        private System.Windows.Forms.Label _courseStageLabel;
        private System.Windows.Forms.TextBox _courseStageTextBox;
        private System.Windows.Forms.Label _courseCreditLabel;
        private System.Windows.Forms.TextBox _courseCreditTextBox;
        private System.Windows.Forms.Label _courseTeacherLabel;
        private System.Windows.Forms.TextBox _courseTeacherTextBox;
        private System.Windows.Forms.Label _courseElectiveLabel;
        private System.Windows.Forms.ComboBox _courseElectiveComboBox;
        private System.Windows.Forms.FlowLayoutPanel _courseEditorLine3;
        private System.Windows.Forms.Label _courseTeachingAssistantLabel;
        private System.Windows.Forms.TextBox _courseTeachingAssistantTextBox;
        private System.Windows.Forms.Label _courseLanguageLabel;
        private System.Windows.Forms.TextBox _courseLanguageTextBox;
        private System.Windows.Forms.FlowLayoutPanel _courseEditorLine4;
        private System.Windows.Forms.Label _courseNoteLabel;
        private System.Windows.Forms.TextBox _courseNoteTextBox;
        private System.Windows.Forms.FlowLayoutPanel _courseEditorLine5;
        private System.Windows.Forms.Label _courseHoursLabel;
        private System.Windows.Forms.ComboBox _courseHoursComboBox;
        private System.Windows.Forms.Label _classLabel;
        private System.Windows.Forms.ComboBox _classComboBox;
        private System.Windows.Forms.TextBox _courseIdTextBox;
        private System.Windows.Forms.TextBox _courseNameTextBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn _courseSectionColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn _courseSundayColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn _courseMondayColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn _courseTuesdayColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn _courseWednesdayColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn _courseThursdayColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn _courseFridayColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn _courseSaturdayColumn;
        private System.Windows.Forms.ListBox _courseList;
        private System.Windows.Forms.DataGridView _courseTimeSelectionGrid;
        private System.Windows.Forms.FlowLayoutPanel _courseEditorFlowLayoutPanel;
    }
}