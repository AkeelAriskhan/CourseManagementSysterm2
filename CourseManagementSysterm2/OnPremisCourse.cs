using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseManagementSysterm2
{
    internal class OnPremisCourse:Course
    {
        public  string Schedule {  get; set; }
        public int ClassroomCapacity { get; set; }

        public OnPremisCourse(int CourseId ,string Title,string Duration, decimal Price, string schedule, int classroomCapacity):base (CourseId, Title, Duration, Price)
        {
            Schedule = schedule;
            ClassroomCapacity = classroomCapacity;
        }
        public override string DisplayCourseInfo()
        {
            return base.DisplayCourseInfo()+$"Schedule:{Schedule}  ClassroomCapacity:{ClassroomCapacity}";
        }
    }
}
