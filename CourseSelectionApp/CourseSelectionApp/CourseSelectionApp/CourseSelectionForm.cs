using System;
using System.Windows.Forms;

namespace CourseSelectionApp
{
    public partial class CourseSelectionForm : Form
    {
        private const string DATA_PROPERTY_SEPARATOR = ".";
        private readonly CourseSelectionPresentationModel _courseSelectionPresentationModel;

        public CourseSelectionForm(CourseSelectionPresentationModel courseSelectionPresentationModel)
        {
            _courseSelectionPresentationModel = courseSelectionPresentationModel;
            InitializeComponent();
            _courseSelectionGrid.AutoGenerateColumns = false;
            _courseSelectionGrid.AutoSize = true;
            _courseSelectionGrid.CellFormatting += MapCellDataToPropertyValue;
            _courseSelectionGrid.CellValueChanged += ListenCourseDataGridOnCellValueChanged;
            _courseSelectionGrid.CellMouseUp += ListenCourseDataGridOnCellMouseUp;
            _courseSelectionGrid.CellContentClick += ListenCourseDataGridOnCellContentClick;
            
            this.Load += LoadCourseSelectionForm;

            _courseSubmitButton.DataBindings.Add("Enabled", _courseSelectionPresentationModel, "IsAnyCourseSelected");
        }

        /// <summary>
        /// 載入階段
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoadCourseSelectionForm(object sender, EventArgs e)
        {
            _courseSelectionPresentationModel.LoadCourses();
            _courseSelectionGrid.DataSource = _courseSelectionPresentationModel.Courses;
        }

        /// <summary>
        /// 監聽數值變動
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListenCourseDataGridOnCellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            // Click CheckBox Event
            if (IsCourseCheckBoxColumn(e.ColumnIndex) && e.RowIndex != -1)
            {
                _courseSelectionPresentationModel.ClickCourseCheckBox();
            }
        }

        /// <summary>
        /// 監聽滑鼠點擊釋放
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListenCourseDataGridOnCellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            // Click CheckBox Event
            if (IsCourseCheckBoxColumn(e.ColumnIndex) && e.RowIndex != -1)
            {
                _courseSelectionGrid.EndEdit();
            }
        }

        /// <summary>
        /// 監聽點擊 Cell 內容
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListenCourseDataGridOnCellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == _courseSyllabusLink.Index && e.RowIndex != -1)
            {
                var uri = _courseSelectionGrid.Rows[e.RowIndex].Cells[_courseSyllabusLink.Index].FormattedValue.ToString();
                _courseSelectionPresentationModel.ClickCourseSyllabusLink(uri);
            }
        }

        /// <summary>
        /// 是否為 CheckBox Column
        /// </summary>
        /// <param name="columnIndex"></param>
        /// <returns></returns>
        private bool IsCourseCheckBoxColumn(int columnIndex)
        {
            return columnIndex == _courseCheckBox.Index;
        }

        /// <summary>
        /// Mapping 對應 Property 資料
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MapCellDataToPropertyValue(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if ((_courseSelectionGrid.Rows[e.RowIndex].DataBoundItem != null) &&
                (_courseSelectionGrid.Columns[e.ColumnIndex].DataPropertyName.Contains(DATA_PROPERTY_SEPARATOR)))
            {
                e.Value = GetPropertyValue(
                    _courseSelectionGrid.Rows[e.RowIndex].DataBoundItem,
                    _courseSelectionGrid.Columns[e.ColumnIndex].DataPropertyName
                );
            }
        }

        /// <summary>
        /// 取得 Property 對應資料
        /// </summary>
        /// <param name="property"></param>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        private object GetPropertyValue(object property, string propertyName)
        {
            if (propertyName.Contains(DATA_PROPERTY_SEPARATOR))
            {
                var leftPropertyName = propertyName.Substring(0, propertyName.IndexOf(DATA_PROPERTY_SEPARATOR));

                foreach (var propertyInfo in property.GetType().GetProperties())
                {
                    if (propertyInfo.Name == leftPropertyName)
                    {
                        return GetPropertyValue(
                            propertyInfo.GetValue(property, null),
                            propertyName.Substring(propertyName.IndexOf(DATA_PROPERTY_SEPARATOR) + 1));
                    }
                }
            }

            return property.GetType().GetProperty(propertyName).GetValue(property, null);
        }
    }
}
