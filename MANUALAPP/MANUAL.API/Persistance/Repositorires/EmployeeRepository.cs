using MANUAL.API.Domain.Models;
using MANUAL.API.Domain.Repository;
using MANUAL.API.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task = System.Threading.Tasks.Task;

namespace MANUAL.API.Data.Repositorires
{
    public class EmployeeRepository : BaseRepository, IEmployeeRepository
    {
        public EmployeeRepository(ManualAPIDBContext manualAPIDBContext) : base(manualAPIDBContext)
        {
        }

        public async Task AddAsync(EmployeeEntity employee)
        {
            await _manualAPIDBContext.Employees.AddAsync(employee);
        }

        public void Delete(EmployeeEntity employee)
        {
            _manualAPIDBContext.Employees.Remove(employee);
        }

        public async Task<bool> EmployeeExistAsync(string name)
        {
            if (await _manualAPIDBContext.Employees.AnyAsync( e => e.Name == name))
            {
                return true;
            }

            return false;
        }

        public async Task<EmployeeEntity> FindByIdAsync(int id)
        {
           var employee = await _manualAPIDBContext.Employees.FindAsync(id);

            return employee;
        }

        public async Task<IEnumerable<EmployeeEntity>> ListAsync()
        {
            return await _manualAPIDBContext.Employees.ToListAsync();
        }

        public void Update(EmployeeEntity employee)
        {
             _manualAPIDBContext.Employees.Update(employee);
        }
    }
}
