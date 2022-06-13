using MANUAL.API.DTOResources.EmployeeDtos;
using MANUAL.API.ServicesResponder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MANUAL.API.Domain.ContractServices
{
    public interface IEmployeeServices
    {
        /// <sumary>
        /// Return list of Employee
        /// </sumary>
        /// <return>List of EmployeeDto</return>
        Task<ServiceResponse<List<EmployeeDto>>> GetListEmployeesAsync();

        /// <summary>
        /// Return company record.
        /// </summary>
        /// <param ="EmployeeId"></param>
        /// <returns>EmployeeDto</returns>
        Task<ServiceResponse<EmployeeDto>> GetEmployeeById(int employeeId);

        //GUID no included in Model Object/Entity would be added later and this method will be implemented as well.
        /// <summary>
        /// Return Employee record.
        /// </summary>
        /// <param name="EmployeeGuid"></param>
        /// <returns>EmployeeDto</returns>


        /// <summary>
        /// Add new Employee Record record in db
        /// </summary>
        /// <param name="createEmployeeDto"></param>
        /// <returns>EmployeeDto</returns>
        Task<ServiceResponse<EmployeeDto>> AddEmployeeAsync( CreateEmployeeDto createEmployeeDto);

        /// <summary>
        /// Update Employee record
        /// </summary>
        /// <param name="updateEmployeeDto"></param>
        /// <returns>EmployeeDto</returns>
        Task<ServiceResponse<EmployeeDto>> UpdateEmployeeAsync(UpdateEmployeeDto updateEmployeeDto);


        /// <summary>
        /// Delete Employee record
        /// </summary>
        /// <param name="EmployeekId"></param>
        /// <returns>bool</returns>
        Task<ServiceResponse<string>> DeleteEmployeeAsync(int employeeId);
    }
}
