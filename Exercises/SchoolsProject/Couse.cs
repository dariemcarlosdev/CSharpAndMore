using System;

namespace SchoolsProject
{
        public class Course
        {
     

        public int CourseId { get; set; }
            public string CourseName { get; set; }
            public string TeacherName { get; set; }
            public DateTime CourseDateTime { get; set; }
            public School School { get; set; }
        }
}
