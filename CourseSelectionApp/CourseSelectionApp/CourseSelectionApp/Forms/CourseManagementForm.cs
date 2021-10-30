using System;
using System.Windows.Forms;

namespace CourseSelectionApp.Forms
{
    public partial class CourseManagementForm : Form
    {
        private readonly CourseManagementFormPresentationModel _courseManagementFormPresentationModel;

        public CourseManagementForm(CourseManagementFormPresentationModel courseManagementFormPresentationModel)
        {
            InitializeComponent();
            _courseManagementFormPresentationModel = courseManagementFormPresentationModel;
        }
    }
}
