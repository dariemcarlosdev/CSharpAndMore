using MANUAL.API.Domain.Repository;
using MANUAL.API.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MANUAL.API.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace MANUAL.API.Data.Repositorires
{
    public class TaskRepository : BaseRepository, ITaskRepository
    {
        public TaskRepository(ManualAPIDBContext manualAPIDBContext) : base(manualAPIDBContext)
        {
        }

        public async Task AddAsync(TaskEntity task)
        {
          await _manualAPIDBContext.Tasks.AddAsync(task);
        }

        public async Task<bool> HardDeleteTaskAsync(TaskEntity task)
        {
            _manualAPIDBContext.Tasks.Remove(task);

            return await SaveAsync();
        }

        public async Task<TaskEntity> FindByIdAsync(int id)
        {
          return  await _manualAPIDBContext.Tasks.FindAsync(id);
        }

        public async Task<IEnumerable<TaskEntity>> GetAllTasksAsync()
        {
           return await _manualAPIDBContext.Tasks.ToListAsync();
        }


        public async Task<IEnumerable<TaskEntity>> GetTasksAsync()
        {
            return await _manualAPIDBContext.Tasks.Where(t => t.IsDeleted == false).ToListAsync();
        }

        public async Task<bool> TaskExistAsync(string description)
        {
            if ( await _manualAPIDBContext.Tasks.AnyAsync( t => t.Description == description))
            {
                return true;
            }

            return false;
        }

        public async Task<bool> TaskExistAsync(int taskId)
        {
            if (await _manualAPIDBContext.Tasks.AnyAsync(t => t.TaskId == taskId))
            {
                return true;
            }

            return false;
        }

        public async Task<bool> UpdateTaskAsync(TaskEntity task)
        {
           _manualAPIDBContext.Tasks.Update(task);
            return await SaveAsync();
        }


        public async Task<IEnumerable<TaskEntity>> GetDeletedTasksAsync()
        {
            return await _manualAPIDBContext.Tasks.Where(t => t.IsDeleted == true).ToListAsync();
        }

        public async Task<IEnumerable<TaskEntity>> GetDisabledTasksAsync()
        {
            return await _manualAPIDBContext.Tasks.Where(t => t.IsEnable == false).ToListAsync();
        }


        public async Task<bool> SoftDeleteTaskAsync(int taskId)
        {
            var _existTask = await FindByIdAsync(taskId);

            if (_existTask == null)
            {
                _existTask.IsDeleted = true;
                return await SaveAsync();
            }

            return false;
        }


        private async Task<bool> SaveAsync()
        {
            return await _manualAPIDBContext.SaveChangesAsync() > 0 ? true : false;
        }
    }
}
