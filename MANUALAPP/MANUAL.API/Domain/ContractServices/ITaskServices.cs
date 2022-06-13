using MANUAL.API.DTOResources;
using MANUAL.API.ServicesResponder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MANUAL.API.Domain.ContractServices
{
    public interface ITaskServices
        
    {
        /// <sumary>
        /// Return list of task
        /// </sumary>
        /// <return>List of TaskDto</return>
        Task<ServiceResponse<List<TaskDto>>> GetListTasksAsync();
        
        /// <summary>
        /// Return company record.
        /// </summary>
        /// <param ="TaskId"></param>
        /// <returns>TaskDto</returns>
        Task<ServiceResponse<TaskDto>> GetTaskByIdAsync(int taskId);

        //GUID no included in Model/Entity would be added later and this method will be implemented as well.
        /// <summary>
        /// Return company record.
        /// </summary>
        /// <param name="TaskGuid"></param>
        /// <returns>TaskDto</returns>


        /// <summary>
        /// Add new Task Record record in db
        /// </summary>
        /// <param name="createTaskDto"></param>
        /// <returns>TaskDto</returns>
        /// 
        Task<ServiceResponse<TaskDto>> AddTaskAsync(CreateTaskDto createTaskDto);

        /// <summary>
        /// Update Task record
        /// </summary>
        /// <param name="updateTaskDto"></param>
        /// <returns>CompanyDto</returns>
        Task<ServiceResponse<TaskDto>> UpdateTaskAsync(UpdateTaskDto updateTaskDto);

        /// <summary>
        /// Delete Task record
        /// </summary>
        /// <param name="TaskId"></param>
        /// <returns>bool</returns>
        Task<ServiceResponse<string>> DeleteTaskAsync(int taskId);
    }
}
