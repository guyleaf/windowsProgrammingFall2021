using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CourseSelectionApp.Attributes;

namespace CourseSelectionApp.Models.Enums
{
    public enum SelectionErrorCode
    {
        [StringValue("課程編號相同")]
        Id,
        [StringValue("課程名稱相同")]
        Name,
        [StringValue("衝堂")]
        Time
    }
}
