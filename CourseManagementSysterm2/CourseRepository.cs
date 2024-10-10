using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseManagementSysterm2
{
    internal class CourseRepository
    {
        static string connnectionsting = "Server=(localdb)\\MSSQLLocalDB;database=CourseManagement2;Trusted_Connection=true;TrustServerCertificate=true";
        public void CreateCourse(string Title, string Duration, decimal Price)
        {
            using (var connection = new SqlConnection(connnectionsting)) 
            {
              connection.Open(); 
                var command= connection.CreateCommand();
                command.CommandText = @"insert into Courses (Title,Duration,Price) values (@Title,@Duration,@Price)";
                command.Parameters.AddWithValue("@Title", Title);
                command.Parameters.AddWithValue("@Duration", Duration);
                command.Parameters.AddWithValue("@Price", Price);
                command.ExecuteNonQuery();


            }
            Console.WriteLine("course added Sucsessfully");
        }
    }
}
