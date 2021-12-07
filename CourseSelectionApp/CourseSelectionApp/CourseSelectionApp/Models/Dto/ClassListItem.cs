namespace CourseSelectionApp.Models.Dto
{
    public class ClassListItem
    {
        public ClassListItem(Class classInfo)
        {
            Class = classInfo;
        }

        public Class Class
        {
            get;
        }

        public string ClassName
        {
            get
            {
                return Class.Name;
            }
        }
    }
}
