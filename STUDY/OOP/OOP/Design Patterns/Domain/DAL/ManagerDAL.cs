using System.Collections.Generic;

namespace OOP.Design_Patterns.DI
{
    class ManagerDAL : IEmployeeDAL
    {
        private List<Employee> ListManagers { get; set; }
        

        public void SetManagers()
        {
            ListManagers = new List<Employee>();
            ListManagers.Add(new Employee() { Name = "Manager1", Address = "dasdad" });
            ListManagers.Add(new Employee() { Name = "Manager2", Address = "ccccccc" });

        }

        public List<Employee> SelectEmployee()
        {
            SetManagers();
            return ListManagers;
        }
    }
}
