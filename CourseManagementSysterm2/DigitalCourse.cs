using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace CourseManagementSysterm2
{
    internal class DigitalCourse:Course
    {
        public string CourseLink;
        public int FileSize;

        public DigitalCourse(int CourseId, string Title, string Duration, decimal Price, string courseLink, int fileSize) : base(CourseId, Title, Duration, Price)
        {
            CourseLink = courseLink;
            FileSize = fileSize;
        }
        public override string DisplayCourseInfo()
        {
            return base.DisplayCourseInfo() + $" link : {CourseLink} FileSize :{FileSize}  ";
        }
    }
}
