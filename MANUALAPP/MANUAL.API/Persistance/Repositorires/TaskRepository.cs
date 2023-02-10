using MANUAL.API.Domain.Repository;
using MANUAL.API.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MANUAL.API.Domain.Models;
using Microsoft.EntityFrameworkCore;
using CloudinaryDotNet.Actions;

namespace MANUAL.API.Data.Repositorires
{
    public class TaskRepository : BaseRepository, ITaskRepository
    {


        public TaskRepository(ManualAPIDBContext manualAPIDBContext) : base(manualAPIDBContext)
        {

        }

        public async Task<bool> AddAsync(TaskEntity task)
        {
            var _addingResult = await _manualAPIDBContext.Tasks.AddAsync(task);

            if (_addingResult != null)
            {
                return true;
            }

            return false;
        }

        public bool HardDeleteTask(TaskEntity task)
        {
            var _hardDeleteResult = _manualAPIDBContext.Tasks.Remove(task);

            if (_hardDeleteResult.Entity != null)
            {
                return true;
            }

            return false;
        }


        public async Task<bool> SoftDeleteTaskAsync(int taskId)
        {
            var _existTask = await FindByIdAsync(taskId);

            if (_existTask == null)
            {
                _existTask.IsDeleted = true;
            }

            return false;
        }

        public async Task<TaskEntity> FindByIdAsync(int id)
        {
            //return  await _manualAPIDBContext.Tasks.FindAsync(id);
            return await _manualAPIDBContext.Tasks.Include( et => et.EmployeesTasks).ThenInclude(e => e.Employee).FirstAsync( t => t.TaskId == id);
        }

        public async Task<IEnumerable<TaskEntity>> GetAllTasksAsync()
        {
            return await _manualAPIDBContext.Tasks.ToListAsync();
        }


        public async Task<IEnumerable<TaskEntity>> GetTasksAsync()
        {
            return await _manualAPIDBContext.Tasks.Where(t => t.IsDeleted == false || t.IsEnable == true).Include(et => et.EmployeesTasks).ThenInclude(e => e.Employee).ToListAsync();
        }

        public async Task<bool> TaskExistAsync(string description)
        {
            if (await _manualAPIDBContext.Tasks.AnyAsync(t => t.Description == description))
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

        public bool UpdateTask(TaskEntity task)
        {
            var _updatedTask = _manualAPIDBContext.Tasks.Update(task);

            if (_updatedTask != null)
            {
                return true;
            }

            return false;
        }


        public async Task<IEnumerable<TaskEntity>> GetDeletedTasksAsync()
        {
            return await _manualAPIDBContext.Tasks.Where(t => t.IsDeleted == true).ToListAsync();
        }

        public async Task<IEnumerable<TaskEntity>> GetDisabledTasksAsync()
        {
            return await _manualAPIDBContext.Tasks.Where(t => t.IsEnable == false).ToListAsync();
        }



    }
}
