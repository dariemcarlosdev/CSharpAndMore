using MANUAL.API.Domain.Repository;
using MANUAL.API.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MANUAL.API.Domain.Models;
using Microsoft.EntityFrameworkCore;
using TaskEntity = MANUAL.API.Domain.Models.TaskEntity;

namespace MANUAL.API.Data.Repositorires
{
    public class TaskRepository : BaseRepository, ITaskRepository
    {
        public TaskRepository(ManualAPIDBContext manualAPIDBContext) : base(manualAPIDBContext)
        {
        }

        public async System.Threading.Tasks.Task AddAsync(Domain.Models.TaskEntity task)
        {
          await _manualAPIDBContext.Tasks.AddAsync(task);
        }

        public void Delete(Domain.Models.TaskEntity task)
        {
            _manualAPIDBContext.Tasks.Remove(task);
        }

        public async Task<TaskEntity> FindByIdAsync(int id)
        {
          return  await _manualAPIDBContext.Tasks.FindAsync(id);
        }

        public async Task<IEnumerable<TaskEntity>> ListAsync()
        {
           return await _manualAPIDBContext.Tasks.ToListAsync();
        }

        public async Task<bool> TaskExistAsync(string description)
        {
            if ( await _manualAPIDBContext.Tasks.AnyAsync( t => t.Description == description))
            {
                return true;
            }

            return false;
        }

        public void Update(TaskEntity task)
        {
            _manualAPIDBContext.Tasks.Update(task);
        }

       
    }
}
