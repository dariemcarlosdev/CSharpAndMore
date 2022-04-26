using MANUAL.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MANUAL.API.Domain.Repository
{
    //Implementation Repository Desing Pattern ref https://dotnettutorials.net/lesson/unit-of-work-csharp-mvc/#:~:text=Unit%20of%20Work%20in%20C%23%20Repository%20Pattern,or%20fail%20as%20one%20unit.
    public interface IEmployeeRepository
    {
        //define all possible opperations for this Entity including CRUDS operations and any other one related to this entity

        public Task<IEnumerable<Employee>> ListAsync();
        public Task<Employee> FindByIdAsync(int id);
        public System.Threading.Tasks.Task AddAsync(Employee employee);
        public Task<bool> EmployeeExistAsync(string name);
        public void Update(Employee employee);
        public void Delete(Employee employee);
    }
}
