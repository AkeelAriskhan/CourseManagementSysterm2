using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseManagementSysterm2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var coursemanager=new CourseManager();
            var CourseRepository=new CourseRepository();
            bool exit = true;
            while (exit)
            {
                Console.Clear();
                Console.WriteLine("Course Management System:");
                Console.WriteLine("1. Add a Course");
                Console.WriteLine("2. View All Courses:");
                Console.WriteLine("3. Update a Course:");
                Console.WriteLine("4. Delete a Course:");
                Console.WriteLine("5. Exit:");
                Console.Write(" Choose an option:");
                var selectnumber =Convert.ToInt32( Console.ReadLine());

                switch (selectnumber) 
                {
                  case 1:
                        Console.Clear();
                        Console.Write("Enter a Course Title ");
                         var title=Console.ReadLine();
                        Console.Write("Enter a Course Duration ");
                        var Duration = Console.ReadLine();
                      
                        var Price = coursemanager.ValidateCoursePrice();


                        //coursemanager.CreateCourse(title, Duration, Price);
                        CourseRepository.CreateCourse(title, Duration, Price);

                        break;
                  case 2:
                        Console.Clear();
                        coursemanager.ReadCourses();
                        break;

                  case 3:
                        Console.Clear();
                        Console.Write("Enter a Course Id ");
                        var courseid1 = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Enter a Course Title ");
                        var title1 = Console.ReadLine();
                        Console.Write("Enter a Course Duration ");
                        var Duration1 = Console.ReadLine();

                        var Price1 = coursemanager.ValidateCoursePrice();
                        coursemanager.UpdateCourse(courseid1, title1, Duration1, Price1);
                        break;

                    case 4:
                        Console.Clear();
                        Console.Write("Enter a Course Id ");
                        var courseid2 = Convert.ToInt32(Console.ReadLine());
                        coursemanager.DeleteCourse(courseid2);
                        break;
                   case 5:
                        exit = false;
                        return;
                   default:
                        Console.WriteLine("Invaid number  try again");
                        break;
                
                }
                Console.WriteLine("enter any key to continue");
                Console.ReadKey();

            }
        }
    }
}
