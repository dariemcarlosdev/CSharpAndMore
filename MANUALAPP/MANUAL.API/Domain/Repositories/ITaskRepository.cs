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

        public Task<IEnumerable<TaskEntity>> ListAsync();
        public Task<TaskEntity> FindByIdAsync(int id);
        public System.Threading.Tasks.Task AddAsync(TaskEntity task);
        public Task<bool> TaskExistAsync(string description);
        public void Update(TaskEntity task);
        public void Delete(Domain.Models.TaskEntity task);
    }
}
