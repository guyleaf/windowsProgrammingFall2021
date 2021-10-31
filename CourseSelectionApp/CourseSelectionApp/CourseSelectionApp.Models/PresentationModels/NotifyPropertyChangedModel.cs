using System.ComponentModel;

namespace CourseSelectionApp.Models.PresentationModels
{
    public class NotifyPropertyChangedModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// 通知 Property Update
        /// </summary>
        /// <param name="propertyName"></param>
        protected void NotifyOnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
