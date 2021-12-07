using System.Reflection;

namespace CourseSelectionApp.Commons
{
    public class ControlCommons
    {
        private const string NAME_OF_DOUBLE_BUFFERED = "DoubleBuffered";

        /// <summary>
        /// 設定 Double Buffered
        /// </summary>
        public void SetDoubleBuffered(object component, bool status)
        {
            var type = component.GetType();
            var propertyInfo = type.GetProperty(NAME_OF_DOUBLE_BUFFERED, BindingFlags.Instance | BindingFlags.NonPublic);
            propertyInfo.SetValue(component, status, null);
        }
    }
}
