using System;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

using CourseSelectionApp.Models;
using CourseSelectionApp.Models.CourseObjects;
using CourseSelectionApp.Models.Dto;
using CourseSelectionApp.Models.PresentationModels;

namespace CourseSelectionApp.Forms
{
    public partial class CourseManagementForm : Form
    {
        private readonly CourseManagementFormPresentationModel _courseManagementFormPresentationModel;
        private readonly CourseManagementModel _courseManagementModel;

        public CourseManagementForm(
            CourseManagementFormPresentationModel courseManagementFormPresentationModel, CourseManagementModel courseManagementModel)
        {
            InitializeComponent();
            Load += LoadDataSource;
            _courseManagementFormPresentationModel = courseManagementFormPresentationModel;
            _courseManagementModel = courseManagementModel;

            SetDoubleBuffered(_courseList, true);
            SetDoubleBuffered(_courseTimeSelectionGrid, true);

            _courseList.DisplayMember = nameof(CourseListItem.CourseName);
            _courseList.ValueMember = nameof(CourseListItem.Course);

            _courseList.SelectedValueChanged += ListenCourseListOnSelectedValueChanged;

            var textPropertyName = nameof(Text);
            var enabledPropertyName = nameof(Enabled);
            var isCourseSelectedPropertyName = nameof(_courseManagementFormPresentationModel.IsCourseExisted);

            // 綁定所有輸入元件的 Enabled 狀態
            AddDataBindingsForInputsStatus(_courseEditorLine1, enabledPropertyName, isCourseSelectedPropertyName);
            AddDataBindingsForInputsStatus(_courseEditorLine2, enabledPropertyName, isCourseSelectedPropertyName);
            AddDataBindingsForInputsStatus(_courseEditorLine3, enabledPropertyName, isCourseSelectedPropertyName);
            AddDataBindingsForInputsStatus(_courseEditorLine4, enabledPropertyName, isCourseSelectedPropertyName);
            AddDataBindingsForInputsStatus(_courseEditorLine5, enabledPropertyName, isCourseSelectedPropertyName);

            // _courseActivateComboBox

            // _courseIdTextBox
            _courseIdTextBox.TextChanged += ListenCourseIdTextBoxOnTextChanged;
            AddDataBinding(_courseIdTextBox, textPropertyName, nameof(_courseManagementFormPresentationModel.CourseId));
            // _courseNameTextBox
            _courseNameTextBox.TextChanged += ListenCourseNameTextBoxOnTextChanged;
            AddDataBinding(_courseNameTextBox, textPropertyName, nameof(_courseManagementFormPresentationModel.CourseName));

            // _createOrSaveCourseButton
            _newCourseButton.Click += ListenNewCourseButtonOnClick;
            // _createOrSaveCourseButton
            AddDataBinding(_createOrSaveCourseButton, enabledPropertyName, nameof(_courseManagementFormPresentationModel.IsDataValid));
            AddDataBinding(_createOrSaveCourseButton, textPropertyName, nameof(_courseManagementFormPresentationModel.CreateOrSaveButtonText));
            _createOrSaveCourseButton.Click += ListenCreateOrSaveButtonOnClick;

            _courseEditorErrorProvider.DataSource = _courseManagementFormPresentationModel;
        }

        private void LoadDataSource(object sender, EventArgs e)
        {
            _courseList.DataSource = _courseManagementModel.CourseList;
            _courseList.ClearSelected();
        }

        /// <summary>
        /// 綁定 TextBox/ComboBox 的 Enabled 狀態
        /// </summary>
        /// <param name="control"></param>
        /// <param name="propertyName"></param>
        /// <param name="memberName"></param>
        private void AddDataBindingsForInputsStatus(Control control, string propertyName, string memberName)
        {
            foreach (var input in control.Controls.OfType<TextBox>())
            {
                AddDataBinding(input, propertyName, memberName);
            }

            foreach (var input in control.Controls.OfType<ComboBox>())
            {
                AddDataBinding(input, propertyName, memberName);
            }
        }

        /// <summary>
        /// 綁定 Data
        /// </summary>
        /// <param name="control"></param>
        /// <param name="propertyName"></param>
        /// <param name="memberName"></param>
        private void AddDataBinding(Control control, string propertyName, string memberName)
        {
            control.DataBindings.Add(
                propertyName, _courseManagementFormPresentationModel, memberName);
        }

        /// <summary>
        /// 監聽 CourseList 的選擇變更事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListenCourseListOnSelectedValueChanged(object sender, EventArgs e)
        {
            if (_courseList.SelectedValue != null)
            {
                _courseManagementFormPresentationModel.EditCourse(_courseList.SelectedValue as Course);
            }
        }

        /// <summary>
        /// 監聽 CourseIdTextBox 的 TextChanged 事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListenCourseIdTextBoxOnTextChanged(object sender, EventArgs e)
        {
            _courseManagementFormPresentationModel.CourseId = _courseIdTextBox.Text;
        }

        /// <summary>
        /// 監聽 CourseNameTextBox 的 TextChanged 事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListenCourseNameTextBoxOnTextChanged(object sender, EventArgs e)
        {
            _courseManagementFormPresentationModel.CourseName = _courseNameTextBox.Text;
        }

        /// <summary>
        /// 監聽 NewCourseButton 的 Click 事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListenNewCourseButtonOnClick(object sender, EventArgs e)
        {
            _courseManagementFormPresentationModel.CreateCourse();
            _courseList.ClearSelected();
        }

        /// <summary>
        /// 監聽 CreateOrSaveButton 的 Click 事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListenCreateOrSaveButtonOnClick(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// 修改 Resize 重繪方式，改善調整視窗大小時 lag
        /// </summary>
        /// <param name="e"></param>
        protected override void OnResizeBegin(EventArgs e)
        {
            SuspendLayout();
            base.OnResizeBegin(e);
        }

        /// <summary>
        /// 修改 Resize 重繪方式，改善調整視窗大小時 lag
        /// </summary>
        /// <param name="e"></param>
        protected override void OnResizeEnd(EventArgs e)
        {
            ResumeLayout();
            base.OnResizeEnd(e);
        }

        /// <summary>
        /// 設定 Double Buffered
        /// </summary>
        /// <param name="component"></param>
        /// <param name="status"></param>
        private void SetDoubleBuffered(object component, bool status)
        {
            var type = component.GetType();
            var propertyInfo = type.GetProperty(nameof(DoubleBuffered), BindingFlags.Instance | BindingFlags.NonPublic);
            propertyInfo.SetValue(component, status, null);
        }
    }
}
