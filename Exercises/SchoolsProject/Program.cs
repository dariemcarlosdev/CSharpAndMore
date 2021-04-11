using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace SchoolsProject
{
    class Program
    {
        public static List<School> schoolList { get; set; }
        //public static List<School> schoolList1 { get; set; }

        static void Main(string[] args)
        {
            //IEnumerable<School> schools = Enumerable.Empty<School>();

            //     School school = new School("School1", new List<Course> {
            //     new Course {CourseName = "dasdasdasd" },
            //     new Course { CourseName = "gbgbg"}

            //     });

            //     School school2 = new School("School2", new List<Course> {
            //     new Course {CourseName = "dasdasdasd" }

            //     });

            //     School school3 = new School("School3", new List<Course> {
            //     new Course {CourseName = "dasdasdasd" },
            //     new Course { CourseName = "gbgbg"},
            //     new Course { CourseName = "gbgbg"}

            //     });

            //     if (!schools.Any())
            //     {
            //         schoolList1 = schools.ToList();
            //         schoolList1.Add(school3);
            //         schoolList1.Add(school2);
            //     }


            //     foreach (var item in schoolList1)
            //     {
            //         Console.WriteLine("School Name: " + item.SchoolName + ' ' + "CourseBySchool: " + item.Courses.Count);
            //     }


            Dictionary<string, List<Course>> dictionary = new Dictionary<string, List<Course>>();


            var SourceResult = ReadDataSource();
            foreach (DataTable table in SourceResult.Tables)
            {
                foreach (DataRow row in table.Rows)
                {
                    var schoolname = row["SchoolName"].ToString();
                    if (!dictionary.ContainsKey(schoolname))
                    {
                        dictionary.Add(schoolname, new List<Course>());
                    }
                    dictionary[schoolname].Add( new Course() { CourseId = int.Parse(row["CourseID"].ToString()), CourseName = row["CourseName"].ToString() } );
                  
                }

            }

            var keys = dictionary.Keys;
            Console.WriteLine("School Name " + " Total Courses");
            foreach (var key in keys)
            {
               
                var courses = dictionary[key];
                    Console.WriteLine( key  + "   " + courses.Count);

            }

            Console.ReadLine();


            //var result2 = schoolList.GroupBy(s => s.SchoolName).Select(c => c.Count());

            //foreach (var item in result2)
            //{
            //    Console.WriteLine(item);
            //}
        }

         static DataSet ReadDataSource()
        {
            DataSet Schools = new DataSet();
            try
            {
                string connectionString = "Data Source = DESKTOP-5KUB8GS; Initial Catalog = Schools; User ID = sa; Password = 12345";
                
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter("SELECT School.SchoolName, Course.CourseID, Course.CourseName FROM School INNER JOIN Course ON School.School# = Course.School# ",
                        connection);
                    connection.Open();
                    
                    adapter.Fill(Schools);
                    

                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }

           return Schools;
        }
    }
    
}
