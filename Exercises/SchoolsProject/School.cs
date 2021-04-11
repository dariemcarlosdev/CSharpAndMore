using System.Collections.Generic;

namespace SchoolsProject
{

        public class School
        {
        public School(string schoolName, List<Course> courses)
        {
            SchoolName = schoolName;
            Courses = courses;
        }

        public string SchoolName { get; set; }
            public int ZipCode { get; set; }
            public int RegioCode { get; set; }
            public string PrincipalName { get; set; }
            public List<Course> Courses { get; set; }

   

        }


}
