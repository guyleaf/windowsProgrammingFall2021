using System;

namespace CourseSelectionApp.Attributes
{
    public class StringValueAttribute : Attribute
    {
        private readonly string _value;

        public StringValueAttribute(string value)
        {
            _value = value;
        }

        public string Value
        {
            get
            { 
                return _value; 
            }
        }
    }
}
