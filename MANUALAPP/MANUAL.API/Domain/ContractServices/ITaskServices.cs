using MANUAL.API.DTOResources;
using MANUAL.API.ServicesResponder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MANUAL.API.Domain.ContractServices
{
    public interface ITaskServices

    //This class (Interface) define methods to handle some business logic.eg- return all categories.
    //It a common practice create services to handler business Logic such as authentication and authorization, payments, complex data flows, caching and tasks that require some interaction between other services or models.

    //Using services, we can isolate the request and response handling from the real logic needed to complete tasks.

    //The service we’re going to create initially will define a single behavior, or method: a listing method.We expect that this method returns all existing categories in the database.

    /*Important check "data pagination or filtering in this case"*/

    //The Task class, encapsulating the return, indicates asynchrony.We need to think in an asynchronous method due to the fact that we have to wait for the database to complete some operation to return the data.

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
        Task<ServiceResponse<TaskDto>> UpdateTaskAsync(int taskId, UpdateTaskDto updateTaskDto);

        /// <summary>
        /// Delete Task record
        /// </summary>
        /// <param name="TaskId"></param>
        /// <returns>an instance of string type</returns>
        Task<ServiceResponse<string>> SoftDeleteTaskAsync(int taskId);


    }
}
