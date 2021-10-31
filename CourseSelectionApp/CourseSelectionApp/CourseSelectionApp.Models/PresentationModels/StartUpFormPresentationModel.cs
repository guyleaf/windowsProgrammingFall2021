using System.ComponentModel;

namespace CourseSelectionApp.Models.PresentationModels
{
    public class StartUpFormPresentationModel : NotifyPropertyChangedModel
    {
        private bool _isCourseSelectionButtonEnabled;
        private bool _isCourseManagementButtonEnabled;

        public StartUpFormPresentationModel()
        {
            _isCourseSelectionButtonEnabled = _isCourseManagementButtonEnabled = true;
        }

        public bool IsCourseSelectionButtonEnabled
        {
            get
            {
                return _isCourseSelectionButtonEnabled;
            }
        }

        public bool IsCourseManagementButtonEnabled
        {
            get
            {
                return _isCourseManagementButtonEnabled;
            }
        }

        /// <summary>
        /// 點擊 CourseSelection 按鈕
        /// </summary>
        public void ClickCourseSelectionButton()
        {
            SetIsCourseSelectionButtonEnabled(false);
        }

        /// <summary>
        /// 點擊 CourseManagement 按鈕
        /// </summary>
        public void ClickCourseManagementButton()
        {
            SetIsCourseManagementButtonEnabled(false);
        }

        /// <summary>
        /// CourseSelectionForm 關閉時觸發
        /// </summary>
        public void TriggerOnCourseSelectionFormClosed()
        {
            SetIsCourseSelectionButtonEnabled(true);
        }

        /// <summary>
        /// CourseManagementForm 關閉時觸發
        /// </summary>
        public void TriggerOnCourseManagementFormClosed()
        {
            SetIsCourseManagementButtonEnabled(true);
        }

        /// <summary>
        /// 設定 CourseSelection 按鈕是否啟用
        /// </summary>
        /// <param name="status"></param>
        private void SetIsCourseSelectionButtonEnabled(bool status)
        {
            _isCourseSelectionButtonEnabled = status;
            NotifyOnPropertyChanged(nameof(IsCourseSelectionButtonEnabled));
        }

        /// <summary>
        /// 設定 CourseManagement 按鈕是否啟用
        /// </summary>
        /// <param name="status"></param>
        private void SetIsCourseManagementButtonEnabled(bool status)
        {
            _isCourseManagementButtonEnabled = status;
            NotifyOnPropertyChanged(nameof(IsCourseManagementButtonEnabled));
        }
    }
}
