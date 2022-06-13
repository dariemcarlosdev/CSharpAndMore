using MANUAL.API.Domain.ContractServices;
using MANUAL.API.DTOResources.EmployeeDtos;
using MANUAL.API.ServicesResponder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MANUAL.API.Services
{
    public class EmployeeServices : IEmployeeServices
    {
        public Task<ServiceResponse<EmployeeDto>> AddEmployeeAsync(CreateEmployeeDto createEmployeeDto)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<string>> DeleteEmployeeAsync(int employeeId)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<EmployeeDto>> GetEmployeeById(int employeeId)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<List<EmployeeDto>>> GetListEmployeesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<EmployeeDto>> UpdateEmployeeAsync(UpdateEmployeeDto updateEmployeeDto)
        {
            throw new NotImplementedException();
        }
    }
}
