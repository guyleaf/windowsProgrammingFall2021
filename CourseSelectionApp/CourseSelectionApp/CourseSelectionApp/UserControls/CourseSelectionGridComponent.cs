using System.Windows.Forms;

namespace CourseSelectionApp.UserControls
{
    public partial class CourseSelectionGridComponent : CourseDataGridComponent
    {
        private const string HEADER_TEXT_OF_CHECK_BOX_COLUMN = "選";
        private const string NAME_OF_CHECK_BOX_COLUMN = "_courseCheckBox";
        private const int WIDTH_OF_CHECK_BOX_COLUMN = 35;
        protected DataGridViewCheckBoxColumn _courseCheckBox;

        public CourseSelectionGridComponent() : base()
        {
            InitializeComponent();
            _courseDataGridView.AutoGenerateColumns = false;
            _courseDataGridView.CellMouseUp += ListenCourseDataGridOnCellMouseUp;

            _courseCheckBox = new DataGridViewCheckBoxColumn
            {
                FalseValue = bool.FalseString,
                HeaderText = HEADER_TEXT_OF_CHECK_BOX_COLUMN,
                Name = NAME_OF_CHECK_BOX_COLUMN,
                Resizable = DataGridViewTriState.False,
                TrueValue = bool.TrueString,
                Width = WIDTH_OF_CHECK_BOX_COLUMN
            };

            _courseDataGridView.Columns.Insert(0, _courseCheckBox);
        }

        /// <summary>
        /// 是否為 CourseCheckBox 的 Column
        /// </summary>
        /// <returns></returns>
        private bool IsCourseCheckBoxColumn(int columnIndex)
        {
            return columnIndex == _courseCheckBox.Index;
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
                _courseDataGridView.EndEdit();
            }
        }
    }
}
