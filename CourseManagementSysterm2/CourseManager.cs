using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseManagementSysterm2
{
    internal class CourseManager
    {

        public List<Course> CourseList= new List<Course>();

        public void CreateCourse( string Title, string Duration, decimal Price)
        {
            var newcourse=new Course((CourseList.Count+1), Title, Duration, Price);
            CourseList.Add(newcourse);
        }
        public void ReadCourses()
        {
            if (CourseList.Count > 0)
            {
                Console.WriteLine("courses list");
                foreach (var course in CourseList)
                {
                    Console.WriteLine(course);
                }
            }
            else
            {
                Console.WriteLine("course not found");
            }

        }
        public void UpdateCourse( int CourseId, string Title, string Duration, decimal Price )
        {
            var course= CourseList.Find(c=>c.CourseId==CourseId);
            if (course != null)
            {
                course.Title = Title; course.Duration = Duration; course.Price = Price;
                Console.WriteLine("course updated successfully");

            }
            else
            {
                Console.WriteLine("course not foud");
            }
        }
        public void DeleteCourse(int CourseId)
        {
            var course = CourseList.Find(c => c.CourseId == CourseId);

            if (course != null)
            {
                CourseList.Remove(course);
                Console.WriteLine("course updated successfully");

            }
            else
            {
                Console.WriteLine("course not found");
            }

        }
        public decimal ValidateCoursePrice()
        {
            decimal returnprice = 0;
        
            while (true)
            {
                Console.Write("Enter a Course Price ");
                var price = decimal.Parse(Console.ReadLine());

                if (price > 0)
                {
                    returnprice=price;
                    break;
                }
                else
                {
                    Console.WriteLine("invaid price");
                }
                
            }
            return returnprice;

        }
    }
}
