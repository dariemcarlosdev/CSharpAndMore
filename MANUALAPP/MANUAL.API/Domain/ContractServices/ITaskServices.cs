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
        /// Return list of task which are not marked as deleted.
        /// </sumary>
        /// <return>Instance of type List of TaskDto</return>
        Task<ServiceResponse<List<TaskDto>>> GetTasksAsync();

        /// <summary>
        /// Return company record.
        /// </summary>
        /// <param ="TaskId"></param>
        /// <returns>Instance of type TaskDto</returns>
        Task<ServiceResponse<TaskDto>> GetByIdAsync(int taskId);

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
        /// <returns>Instance of type TaskDto</returns>
        /// 
        Task<ServiceResponse<TaskDto>> AddTaskAsync(CreateTaskDto createTaskDto);

        /// <summary>
        /// Update Task record
        /// </summary>
        /// <param name="updateTaskDto"></param>
        /// <returns>Instance of type CompanyDto</returns>
        Task<ServiceResponse<TaskDto>> UpdateTaskAsync(UpdateTaskDto updateTaskDto);

        /// <summary>
        /// Delete Task record
        /// </summary>
        /// <param name="TaskId"></param>
        /// <returns>an instance of string type</returns>
        Task<ServiceResponse<string>> SoftDeleteTaskAsync(int taskId);
    }
}
