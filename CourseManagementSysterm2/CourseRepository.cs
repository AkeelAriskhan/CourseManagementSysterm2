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
                var command = connection.CreateCommand();
                command.CommandText = @"insert into Courses (Title,Duration,Price) values (@Title,@Duration,@Price)";
                command.Parameters.AddWithValue("@Title", Title);
                command.Parameters.AddWithValue("@Duration", Duration);
                command.Parameters.AddWithValue("@Price", Price);
                command.ExecuteNonQuery();


            }
            Console.WriteLine("course added Sucsessfully");
        }
        public void ReadCourses()
        {
            using (var connection = new SqlConnection(connnectionsting))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = @"select * from Courses ";
                using (var reader = command.ExecuteReader())
                {
                    Console.WriteLine("Courses");
                    while (reader.Read())
                    {
                        Console.WriteLine($"CourseId:{reader.GetInt32(0)} Title:{reader.GetString(1)} Duration:{reader.GetString(2)} Price{reader.GetDecimal(3)}");
                    }

                }
            }
        }
        public void Getcoursebyid(int id)
        {
            try
            {
                using (var connection = new SqlConnection(connnectionsting))
                {
                    connection.Open();
                    var command = connection.CreateCommand();
                    command.CommandText = @"select * from Courses where CourseId==@id ";
                    command.Parameters.AddWithValue("@id", id);
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Console.WriteLine($"CourseId:{reader.GetInt32(0)} Title:{reader.GetString(1)} Duration:{reader.GetString(2)} Price{reader.GetDecimal(3)}");
                        }
                        else
                        {
                            Console.WriteLine("Course Not Fount");
                        }
                    }
                }
            }
            catch (Exception error)
            {
                Console.WriteLine($"ErrorMessage: {error.Message}");
            }

        }

        public void UpdateCourse(int CourseId, string Title, string Duration, decimal Price)
        {
            using (var connection = new SqlConnection(connnectionsting))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = @"UPDATE Courses SET Title=@Title ,Duration=@Duration ,Price=@Price where CourseId=@CourseId ";
                command.Parameters.AddWithValue("@Title", Title);
                command.Parameters.AddWithValue("@Duration", Duration);
                command.Parameters.AddWithValue("@Price", Price);
                command.Parameters.AddWithValue("@CourseId", CourseId);
                command.ExecuteNonQuery();

            }
            Console.WriteLine("Course updated Sucsufully");
        }
        public void DeleteCourse(int CourseId)
        {
            using (var connection = new SqlConnection(connnectionsting))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = @"DELETE FROM Courses where CourseId=@CourseId";
                command.Parameters.AddWithValue("@CourseId", CourseId);
                var rowsafected = command.ExecuteNonQuery();
                if (rowsafected > 0)
                {
                    Console.WriteLine("course deleted Succsesfuly");
                }
                else
                {
                    Console.WriteLine("Course not found");

                }

                   
            }
        }
        public string CapitalizeTitle(string title)
        {
            var words= title.Split(' ');
            for (int i = 0; i < words.Length; i++)
            {
                words[i] = char.ToUpper(words[i][0])+words[i].Substring(1).ToLower();
                
            }
            return string.Join(" ", words);

        }
    }


    }

