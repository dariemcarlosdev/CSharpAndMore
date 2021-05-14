using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace SchoolApp
{
    class Program
    {
        private static string connString;

        static void Main(string[] args) {



            Dictionary<string, List<School>> _dictionary = new Dictionary<string, List<School>>();

            var SourceResult = ReadDataSource();
            foreach (DataTable table in SourceResult.Tables)
            {
                foreach (DataRow row in table.Rows)
                {
                    var region = row["REGION"].ToString();
                    if (!_dictionary.ContainsKey(region))
                    {
                        _dictionary.Add(region, new List<School>());
                    }
                    _dictionary[region].Add(new School(int.Parse(row["SCHOOL#"].ToString()), row["SCHOOLNAME"].ToString(), row["PRINCIPALNAME"].ToString(), row["ADDRESS"].ToString()));
                }
            }

            var keys = _dictionary.Keys;
            foreach (var key in keys)
            {
                var schools = _dictionary[key];
                foreach (var school in schools)
                {
                    Console.WriteLine(key + " " + schools.Count + " " + school.SchoolName + " " + school.SchoolNumber + " " + school.PrincipalName + " " + school.Address);
                }
            }

            

            static DataSet ReadDataSource()
            {
                connString = "Server = DESKTOP-5KUB8GS; Database = TESTING; Trusted_Connection = True";

                SqlConnection sqlConn = new SqlConnection(connString);
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Schools", sqlConn);
                DataSet schools = new DataSet();
                adapter.Fill(schools, "Schools");
                /*foreach (DataRow row in schools.Tables["Schools"].Rows)
                {
                    Console.WriteLine(row["REGION"] + " " + row["SCHOOL#"] + " " + row["SCHOOLNAME"] + " " + row["SCHOOLNAME"]);
                */
                return schools;
            }
        }
    }
}
