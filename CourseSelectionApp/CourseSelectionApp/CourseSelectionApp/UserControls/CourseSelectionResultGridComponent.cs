using System.Windows.Forms;

using CourseSelectionApp.Commons;

namespace CourseSelectionApp.UserControls
{
    public partial class CourseSelectionResultGridComponent : CourseDataGridComponent
    {
        private const string HEADER_TEXT_OF_DROP_BUTTON_COLUMN = "退";
        private const string NAME_OF_DROP_BUTTON_COLUMN = "_courseDropButton";
        private const string TEXT_OF_DROP_BUTTON_COLUMN = "退選";
        private const int WIDTH_OF_DROP_BUTTON_COLUMN = 40;
        protected DataGridViewButtonColumn _courseDropButton;

        public CourseSelectionResultGridComponent() : base(new ControlCommons())
        {
            InitializeComponent();
            _courseDataGridView.AutoGenerateColumns = false;

            _courseDropButton = new DataGridViewButtonColumn()
            {
                HeaderText = HEADER_TEXT_OF_DROP_BUTTON_COLUMN,
                Name = NAME_OF_DROP_BUTTON_COLUMN,
                Text = TEXT_OF_DROP_BUTTON_COLUMN,
                Width = WIDTH_OF_DROP_BUTTON_COLUMN,
                UseColumnTextForButtonValue = true
            };

            _courseDataGridView.Columns.Insert(0, _courseDropButton);
        }
    }
}
