using System;
using System.Windows.Forms;

using CourseSelectionApp.Models;
using CourseSelectionApp.Models.PresentationModels;

namespace CourseSelectionApp.Forms
{
    public partial class CourseSelectionResultForm : Form
    {
        private readonly CourseSelectionResultFormPresentationModel _courseSelectionResultFormPresentationModel;
        private readonly CourseSelectionModel _courseSelectionModel;

        public CourseSelectionResultForm(
            CourseSelectionResultFormPresentationModel courseSelectionResultFormPresentationModel, CourseSelectionModel courseSelectionModel)
        {
            InitializeComponent();
            Load += LoadDataSource;
            _courseSelectionResultGridComponent.DataGridViewCellContentClick += ListenDataGridViewOnCellContentClick;

            _courseSelectionResultFormPresentationModel = courseSelectionResultFormPresentationModel;
            _courseSelectionModel = courseSelectionModel;
        }

        /// <summary>
        /// 載入資料
        /// </summary>
        private void LoadDataSource(object sender, EventArgs e)
        {
            _courseSelectionResultGridComponent.DataGridViewDataSource = _courseSelectionModel.SelectedCourses;
        }

        /// <summary>
        /// 監聽點擊 Cell 內容
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListenDataGridViewOnCellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var grid = (DataGridView)sender;
            // 點擊退選按鈕的 Event
            if (grid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex != -1)
            {
                _courseSelectionModel.DropCourse(e.RowIndex);
            }
            // 點擊 Syllabus 連結的 Event
            else if (grid.Columns[e.ColumnIndex] is DataGridViewLinkColumn && e.RowIndex != -1)
            {
                _courseSelectionResultFormPresentationModel.ClickCourseSyllabusLink(e.RowIndex);
            }
        }
    }
}
