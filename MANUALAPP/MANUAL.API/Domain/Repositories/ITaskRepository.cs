using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MANUAL.API.Domain.Models;
using Microsoft.EntityFrameworkCore;
using TaskEntity = MANUAL.API.Domain.Models.TaskEntity;

namespace MANUAL.API.Domain.Repository
{
    //Implementation Repository Design Pattern ref https://dotnettutorials.net/lesson/unit-of-work-csharp-mvc/#:~:text=Unit%20of%20Work%20in%20C%23%20Repository%20Pattern,or%20fail%20as%20one%20unit.

    public interface ITaskRepository
    {
        //define all possible opperations for this Entity including CRUDS operations and any other one related to this entity.

        /// <summary>
        /// Return all task including records marked as deleted and disabled
        /// </summary>
        /// <returns>Entites.Company</returns>
        Task<IEnumerable<TaskEntity>> GetAllTasksAsync();

        /// <summary>
        /// Return all Tasks which are not marked as deleted.
        /// </summary>
        /// <returns>Models.Tasks</returns>
        Task<IEnumerable<TaskEntity>> GetTasksAsync();

        /// <summary>
        /// Return list of Tasks which are marked as deleted
        /// </summary>
        /// <returns>Entites.Company</returns>
        Task<IEnumerable<TaskEntity>> GetDeletedTasksAsync();

        /// <summary>
        /// Return list of Tasks which are marked as disabled
        /// </summary>
        /// <returns>Entites.Company</returns>
        Task<IEnumerable<TaskEntity>> GetDisabledTasksAsync();

        /// <summary>
        /// Return a company record
        /// </summary>
        /// <param name="taskId"></param>
        /// <returns>Entites.Company</returns>
       Task<TaskEntity> FindByIdAsync(int taskId);


        /// <summary>
        /// Add a new record for new Task
        /// </summary>
        /// <param name="task"></param>
        /// <returns>bool</returns>
        Task<bool> AddAsync(TaskEntity task);

        /// <summary>
        /// Return True/False if record exist
        /// </summary>
        /// <param name="Description"></param>
        /// <returns>bool</returns>
        Task<bool> TaskExistAsync(string description);
        
        /// <summary>
        /// Return True/False if record exist
        /// </summary>
        /// <param name="taskId"></param>
        /// <returns>bool</returns>
        Task<bool> TaskExistAsync(int taskId);

        /// <summary>
        /// Update a record in db
        /// </summary>
        /// <param name="task"></param>
        /// <returns>bool</returns>
        bool UpdateTask(TaskEntity task);


        /// <summary>
        /// Update a record as Deleted=True
        /// </summary>
        /// <param name="taskId"></param>
        /// <returns>bool: true or false</returns>
        Task<bool> SoftDeleteTaskAsync(int taskId);

        /// <summary>
        /// Permanently remove a record from db
        /// </summary>
        /// <param name="task"></param>
        /// <returns>bool: True or False</returns>
        bool HardDeleteTask(TaskEntity task);
    }
}
