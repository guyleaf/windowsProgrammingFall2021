using System;
using System.Windows.Forms;

using CourseSelectionApp.Models;
using CourseSelectionApp.Models.PresentationModels;
using CourseSelectionApp.Commons;

namespace CourseSelectionApp.Forms
{
    public partial class StartUpForm : Form
    {
        private readonly StartUpFormPresentationModel _startUpFormPresentationModel;
        private readonly CourseSelectionModel _courseSelectionModel;
        private readonly CourseManagementModel _courseManagementModel;
        private readonly ControlCommons _controlCommons;

        public StartUpForm(
            StartUpFormPresentationModel startUpFormPresentationModel,
            CourseSelectionModel courseSelectionModel,
            CourseManagementModel courseManagementModel,
            ControlCommons controlCommons)
        {
            InitializeComponent();

            _courseSelectionButton.Click += ListenCourseSelectionButtonOnClick;
            _courseManagementButton.Click += ListenCourseManagementButtonOnClick;
            _exitButton.Click += ListenExitButtonOnClick;

            _startUpFormPresentationModel = startUpFormPresentationModel;
            _courseSelectionModel = courseSelectionModel;
            _courseManagementModel = courseManagementModel;
            _controlCommons = controlCommons;

            _courseSelectionButton.DataBindings.Add(
                nameof(_courseSelectionButton.Enabled),
                _startUpFormPresentationModel,
                nameof(_startUpFormPresentationModel.IsCourseSelectionButtonEnabled)
            );
            _courseManagementButton.DataBindings.Add(
                nameof(_courseManagementButton.Enabled),
                _startUpFormPresentationModel,
                nameof(_startUpFormPresentationModel.IsCourseManagementButtonEnabled)
            );
        }

        /// <summary>
        /// 監聽 Exit 按鈕點擊事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListenExitButtonOnClick(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// 監聽 CourseSelection 按鈕點擊事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListenCourseSelectionButtonOnClick(object sender, EventArgs e)
        {
            _startUpFormPresentationModel.ClickCourseSelectionButton();
            var courseSelectionForm = new CourseSelectionForm(
                new CourseSelectionFormPresentationModel(_courseSelectionModel), _courseSelectionModel);
            courseSelectionForm.FormClosed += ListenCourseSelectionFormOnFormClosed;
            courseSelectionForm.Show();
        }

        /// <summary>
        /// 監聽 CourseManagement 按鈕點擊事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListenCourseManagementButtonOnClick(object sender, EventArgs e)
        {
            _startUpFormPresentationModel.ClickCourseManagementButton();
            var courseManagementForm = new CourseManagementForm(
                new CourseManagementFormPresentationModel(_courseManagementModel), _courseManagementModel, _controlCommons);
            courseManagementForm.FormClosed += ListenCourseManagementFormOnFormClosed;
            courseManagementForm.Show();
        }

        /// <summary>
        /// 監聽 CourseSelectionForm 關閉事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListenCourseSelectionFormOnFormClosed(object sender, FormClosedEventArgs e)
        {
            _startUpFormPresentationModel.TriggerOnCourseSelectionFormClosed();
        }

        /// <summary>
        /// 監聽 CourseManagementForm 關閉事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListenCourseManagementFormOnFormClosed(object sender, FormClosedEventArgs e)
        {
            _startUpFormPresentationModel.TriggerOnCourseManagementFormClosed();
        }
    }
}
