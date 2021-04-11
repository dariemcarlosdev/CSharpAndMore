namespace SchoolsProject
{
    public partial class Student
    {

        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int HomeSchoolNumber { get; set; }
        public string Gender { get; set; }
        public School Schools { get; set; }


    }
}
