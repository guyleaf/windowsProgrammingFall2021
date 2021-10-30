using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

using CourseSelectionApp.Extensions;
using CourseSelectionApp.Models;
using CourseSelectionApp.Models.Enums;
using CourseSelectionApp.UserControls;

namespace CourseSelectionApp.Forms
{
    public partial class CourseSelectionForm : Form
    {
        private const string SUBMIT_SUCCESS_MESSAGE = "加選成功";
        private const string SUBMIT_FAILURE_MESSAGE = "加選失敗";
        private const string MESSAGE_BREAK_LINE_SYMBOL = "\n\n";
        private readonly IDictionary<string, CourseSelectionGridComponent> _gridComponents;
        private readonly CourseSelectionFormPresentationModel _courseSelectionPresentationModel;
        private readonly CourseSelectionAppModel _courseSelectionAppModel;

        public CourseSelectionForm(
            CourseSelectionFormPresentationModel courseSelectionPresentationModel, CourseSelectionAppModel courseSelectionAppModel
        )
        {
            InitializeComponent();
            _gridComponents = new Dictionary<string, CourseSelectionGridComponent>();

            _courseSelectionPresentationModel = courseSelectionPresentationModel;
            _courseSelectionAppModel = courseSelectionAppModel;

            Load += LoadDataSources;
            _courseSubmitButton.DataBindings.Add(
                nameof(_courseSubmitButton.Enabled),
                _courseSelectionPresentationModel,
                nameof(_courseSelectionPresentationModel.IsAnyCourseSelected)
            );
            _courseCheckSelectionResultButton.DataBindings.Add(
                nameof(_courseCheckSelectionResultButton.Enabled),
                _courseSelectionAppModel,
                nameof(_courseSelectionAppModel.IsAnyCoursesSelected)
            );
            _courseSubmitButton.Click += ListenCourseSubmitButtonOnClick;
            _courseCheckSelectionResultButton.Click += ListenCourseCheckSelectionResultButtonOnClick;

            // 生成 TabPages
            var classNames = _courseSelectionAppModel.ClassNames;
            var pages = classNames.Select(name =>
            {
                var page = new TabPage(name)
                { 
                    Text = name, Name = name };

                var component = InitializeCourseSelectionGrid();
                _gridComponents.Add(name, component);
                page.Controls.Add(component);
                return page;
            }).ToArray();

            _tabControl.SuspendLayout();
            _tabControl.TabPages.AddRange(pages);
            _tabControl.SelectedIndex = 0;
            _tabControl.SelectedIndexChanged += ListenTabControlOnSelectedIndexChanged;
            _tabControl.ResumeLayout();
        }

        /// <summary>
        /// 初始化 CourseSelectionGridComponent
        /// </summary>
        /// <returns></returns>
        private CourseSelectionGridComponent InitializeCourseSelectionGrid()
        {
            var component = new CourseSelectionGridComponent();
            component.DataGridViewCellValueChanged += ListenCourseDataGridOnCellValueChanged;
            component.DataGridViewCellContentClick += ListenCourseDataGridOnCellContentClick;

            component.Dock = DockStyle.Fill;

            return component;
        }

        /// <summary>
        /// 載入資料
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoadDataSources(object sender, EventArgs e)
        {
            foreach (TabPage page in _tabControl.TabPages)
            {
                var className = page.Name;

                var component = _gridComponents[className];
                var courses = _courseSelectionAppModel.GetUnselectedCoursesByClassName(className);
                component.DataGridViewDataSource = courses;
            }
        }

        /// <summary>
        /// 監聽 TabControl 切換 TabPage
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListenTabControlOnSelectedIndexChanged(object sender, EventArgs e)
        {
            _courseSelectionPresentationModel.SelectedTabPage = _tabControl.SelectedTab.Text;
        }

        /// <summary>
        /// 監聽數值變動
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListenCourseDataGridOnCellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            var grid = (DataGridView)sender;
            // Click CheckBox Event
            if (grid.Columns[e.ColumnIndex] is DataGridViewCheckBoxColumn && e.RowIndex != -1)
            {
                _courseSelectionPresentationModel.ClickCourseCheckBox(e.RowIndex);
            }
        }

        /// <summary>
        /// 監聽點擊 Cell 內容
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListenCourseDataGridOnCellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var grid = (DataGridView)sender;
            // Click Syllabus Content Event
            if (grid.Columns[e.ColumnIndex] is DataGridViewLinkColumn && e.RowIndex != -1)
            {
                _courseSelectionPresentationModel.ClickCourseSyllabusLink(e.RowIndex);
            }
        }

        /// <summary>
        /// 監聽課程提交按鈕的點擊事件
        /// </summary>
        /// <param name="send"></param>
        /// <param name="e"></param>
        private void ListenCourseSubmitButtonOnClick(object send, EventArgs e)
        {
            if (_courseSelectionPresentationModel.TrySubmitSelectedCourses(out var errorList))
            {
                MessageBox.Show(SUBMIT_SUCCESS_MESSAGE);
            }
            else
            {
                PromptMessageBoxForSelectionError(errorList);
            }
        }

        /// <summary>
        /// 跳出加選失敗提示
        /// </summary>
        /// <param name="errorList"></param>
        private void PromptMessageBoxForSelectionError(
            IDictionary<SelectionErrorCode, IList<string>> errorList)
        {
            var errorMessages = errorList
                .Select(error =>
                error.Key.GetStringValue() + "： " +
                string.Join("、", error.Value.Select(text => string.Format("「{0}」", text))));

            var errorMessage = SUBMIT_FAILURE_MESSAGE + MESSAGE_BREAK_LINE_SYMBOL +
                string.Join(MESSAGE_BREAK_LINE_SYMBOL, errorMessages);
            MessageBox.Show(errorMessage);
        }

        /// <summary>
        /// 監聽查看選課結果按鈕的點擊事件
        /// </summary>
        /// <param name="send"></param>
        /// <param name="e"></param>
        private void ListenCourseCheckSelectionResultButtonOnClick(object sender, EventArgs e)
        {
            var courseSelectionResultPresentationModel = new CourseSelectionResultFormPresentationModel(_courseSelectionAppModel);
            var courseSelectionResultForm = new CourseSelectionResultForm(courseSelectionResultPresentationModel, _courseSelectionAppModel);
            courseSelectionResultForm.Show();
        }
    }
}
