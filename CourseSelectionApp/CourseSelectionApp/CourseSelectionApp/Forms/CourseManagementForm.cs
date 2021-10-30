using System;
using System.Reflection;
using System.Windows.Forms;

using CourseSelectionApp.Models.PresentationModels;

namespace CourseSelectionApp.Forms
{
    public partial class CourseManagementForm : Form
    {
        private readonly CourseManagementFormPresentationModel _courseManagementFormPresentationModel;

        public CourseManagementForm(CourseManagementFormPresentationModel courseManagementFormPresentationModel)
        {
            InitializeComponent();
            _courseManagementFormPresentationModel = courseManagementFormPresentationModel;
            DoubleBuffered = true;

            SetDoubleBuffered(_courseList, true);
            SetDoubleBuffered(_courseTimeSelectionGrid, true);
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
