using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

using CourseSelectionApp.Models;
using CourseSelectionApp.Models.CourseObjects;
using CourseSelectionApp.Models.Dto;
using CourseSelectionApp.Models.PresentationModels;
using CourseSelectionApp.Commons;

namespace CourseSelectionApp.Forms
{
    public partial class CourseManagementForm : Form
    {
        private const int DEFAULT_INDEX_FOR_COMBO_BOX = -1;
        private readonly CourseManagementFormPresentationModel _courseManagementFormPresentationModel;
        private readonly CourseManagementModel _courseManagementModel;

        public CourseManagementForm(
            CourseManagementFormPresentationModel courseManagementFormPresentationModel, CourseManagementModel courseManagementModel, ControlCommons controlCommons)
        {
            InitializeComponent();
            Load += LoadDataSource;
            _courseManagementFormPresentationModel = courseManagementFormPresentationModel;
            _courseManagementModel = courseManagementModel;

            InitializeUserDefinedComponents(controlCommons);
            _courseEditorErrorProvider.DataSource = _courseManagementFormPresentationModel;
        }

        /// <summary>
        /// 載入資料
        /// </summary>
        private void LoadDataSource(object sender, EventArgs e)
        {
            _courseList.DataSource = _courseManagementModel.CourseList;
            _courseList.SelectedIndex = DEFAULT_INDEX_FOR_COMBO_BOX;
            _courseList.SelectedValueChanged += ListenCourseListOnSelectedValueChanged;
            _classComboBox.DataSource = _courseManagementModel.ClassList;
            _classComboBox.SelectedIndex = DEFAULT_INDEX_FOR_COMBO_BOX;
            _classComboBox.SelectedValueChanged += ListenClassComboBoxOnSelectedValueChanged;
            _courseTimeGrid.DataSource = _courseManagementFormPresentationModel.CourseTimeGrid;
            _courseTimeGrid.CellMouseUp += ListenCourseTimeGridOnCellMouseUp;
            _courseTimeGrid.CellValueChanged += ListenCourseTimeGridOnCellValueChanged;
        }

        /// <summary>
        /// 監聽 CourseList 的選擇變更事件
        /// </summary>
        private void ListenCourseListOnSelectedValueChanged(object sender, EventArgs e)
        {
            _courseManagementFormPresentationModel.EditCourse(_courseList.SelectedValue as CourseWithActivateAndClass);
        }

        /// <summary>
        /// 監聽 CourseIdTextBox 的 TextChanged 事件
        /// </summary>
        private void ListenCourseIdTextBoxOnTextChanged(object sender, EventArgs e)
        {
            _courseManagementFormPresentationModel.CourseId = _courseIdTextBox.Text;
        }

        /// <summary>
        /// 監聽 CourseNameTextBox 的 TextChanged 事件
        /// </summary>
        private void ListenCourseNameTextBoxOnTextChanged(object sender, EventArgs e)
        {
            _courseManagementFormPresentationModel.CourseName = _courseNameTextBox.Text;
        }

        /// <summary>
        /// 監聽 CourseStageTextBox 的 TextChanged 事件
        /// </summary>
        private void ListenCourseStageTextBoxOnTextChanged(object sender, EventArgs e)
        {
            _courseManagementFormPresentationModel.CourseStage = _courseStageTextBox.Text;
        }

        /// <summary>
        /// 監聽 CourseCreditsTextBox 的 TextChanged 事件
        /// </summary>
        private void ListenCourseCreditsTextBoxOnTextChanged(object sender, EventArgs e)
        {
            _courseManagementFormPresentationModel.CourseCredits = _courseCreditsTextBox.Text;
        }

        /// <summary>
        /// 監聽 CourseNoteTextBox 的 TextChanged 事件
        /// </summary>
        private void ListenCourseNoteTextBoxOnTextChanged(object sender, EventArgs e)
        {
            _courseManagementFormPresentationModel.CourseNote = _courseNoteTextBox.Text;
        }

        /// <summary>
        /// 監聽 CourseLanguageTextBox 的 TextChanged 事件
        /// </summary>
        private void ListenCourseLanguageTextBoxOnTextChanged(object sender, EventArgs e)
        {
            _courseManagementFormPresentationModel.CourseLanguage = _courseLanguageTextBox.Text;
        }

        /// <summary>
        /// 監聽 CourseTeachingAssistantTextBox 的 TextChanged 事件
        /// </summary>
        private void ListenCourseTeachingAssistantTextBoxOnTextChanged(object sender, EventArgs e)
        {
            _courseManagementFormPresentationModel.CourseTeachingAssistant = _courseTeachingAssistantTextBox.Text;
        }

        /// <summary>
        /// 監聽 CourseTeacherTextBox 的 TextChanged 事件
        /// </summary>
        private void ListenCourseTeacherTextBoxOnTextChanged(object sender, EventArgs e)
        {
            _courseManagementFormPresentationModel.CourseTeacher = _courseTeacherTextBox.Text;
        }

        /// <summary>
        /// 監聽 CourseActivateComboBox 的 TextChanged 事件
        /// </summary>
        private void ListenCourseActivateComboBoxOnTextChanged(object sender, EventArgs e)
        {
            _courseManagementFormPresentationModel.CourseActivateOrNot = _courseActivateComboBox.Text;
        }

        /// <summary>
        /// 監聽 CourseElectiveComboBox 的 TextChanged 事件
        /// </summary>
        private void ListenCourseElectiveComboBoxOnTextChanged(object sender, EventArgs e)
        {
            _courseManagementFormPresentationModel.CourseRequiredOrElective = _courseElectiveComboBox.Text;
        }

        /// <summary>
        /// 監聽 CourseHoursComboBox 的 TextChanged 事件
        /// </summary>
        private void ListenCourseHoursComboBoxOnTextChanged(object sender, EventArgs e)
        {
            _courseManagementFormPresentationModel.CourseHours = _courseHoursComboBox.Text;
        }

        /// <summary>
        /// 監聽 ClassComboBox 的 SelectedValueChanged 事件
        /// </summary>
        private void ListenClassComboBoxOnSelectedValueChanged(object sender, EventArgs e)
        {
            _courseManagementFormPresentationModel.Class = _classComboBox.SelectedValue as Class;
        }

        /// <summary>
        /// 監聽滑鼠點擊釋放
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListenCourseTimeGridOnCellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            // Click CheckBox Event
            if (_courseTimeGrid.Columns[e.ColumnIndex] is DataGridViewCheckBoxColumn && e.RowIndex != -1)
            {
                _courseTimeGrid.EndEdit();
            }
        }

        /// <summary>
        /// 監聽數值變動
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListenCourseTimeGridOnCellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            // Click CheckBox Event
            if (_courseTimeGrid.Columns[e.ColumnIndex] is DataGridViewCheckBoxColumn && e.RowIndex != -1)
            {
                _courseManagementFormPresentationModel.UpdateCourseTimeGridStatus();
            }
        }

        /// <summary>
        /// 監聽 NewCourseButton 的 Click 事件
        /// </summary>
        private void ListenNewCourseButtonOnClick(object sender, EventArgs e)
        {
            _courseManagementFormPresentationModel.CreateNewCourse();
            _courseList.ClearSelected();
        }

        /// <summary>
        /// 監聽 CreateOrSaveButton 的 Click 事件
        /// </summary>
        private void ListenCreateOrSaveButtonOnClick(object sender, EventArgs e)
        {
            _courseManagementFormPresentationModel.ClickCreateOrSaveButton();
            var selectedValue = _courseList.SelectedValue;
            _courseList.ClearSelected();
            if (_courseManagementFormPresentationModel.EditMode == Models.Enums.CourseEditMode.Edit)
            {
                _courseList.SelectedValue = selectedValue;
            }
        }

        /// <summary>
        /// 修改 Resize 重繪方式，改善調整視窗大小時 lag
        /// </summary>
        protected override void OnResizeBegin(EventArgs e)
        {
            SuspendLayout();
            base.OnResizeBegin(e);
        }

        /// <summary>
        /// 修改 Resize 重繪方式，改善調整視窗大小時 lag
        /// </summary>
        protected override void OnResizeEnd(EventArgs e)
        {
            ResumeLayout();
            base.OnResizeEnd(e);
        }
    }
}
