using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MANUAL.API.Domain.Models;
using MANUAL.API.Persistence.Context;
using TaskEntity = MANUAL.API.Domain.Models.TaskEntity; //avoiding name conflict with System.Threading.Task.
using MANUAL.API.Domain.ContractServices;
using MANUAL.API.DTOResources;

namespace MANUAL.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        //private readonly ManualAPIDBContext _context;
        private readonly ITaskServices _taskService;

        public TasksController(ITaskServices taskServices)
        {
            this._taskService = taskServices;
        }

        // GET: api/Tasks
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<TaskDto>))]
        public async Task<ActionResult> TasksAsync()
        {
            var tasks = await _taskService.GetTasksAsync();

            if (tasks.ErrorMessages != null)
            {
                return BadRequest(tasks);
            }
            return Ok(tasks);
        }

        // GET: api/Tasks/5
        [HttpGet("{TaskId}", Name = "GetTaskByID")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TaskDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<TaskDto>> GetByIdAsync(int TaskId)
        {
            var taskFound = await _taskService.GetByIdAsync(TaskId);

            if (TaskId <= 0)
            {
                return BadRequest(taskFound);
            }
            //var taskFound = await _taskService.GetByIdAsync(id);

            if (taskFound.Data == null)
            {
                return NotFound(taskFound);
            }
            else if (taskFound.ErrorMessages != null)
            {
                return BadRequest(taskFound);
            }

            return Ok(taskFound);
        }

        //// PUT: api/Tasks/5
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutTask(int id, TaskEntity task)
        //{
        //    if (id != task.TaskId)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(task).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!TaskExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        /// <summary>
        /// Create new Task Record.
        /// </summary>
        /// <param name="createTaskDto"></param>
        /// <returns></returns>
        // POST: api/Tasks
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TaskDto))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<TaskDto>> CreateTaskAsync([FromBody] CreateTaskDto createTaskDto)
        {
            if (createTaskDto == null)
            {
                return BadRequest(ModelState);
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var newTask = await _taskService.AddTaskAsync(createTaskDto);
            //await _context.SaveChangesAsync();

            if (newTask.Success == false && newTask.Message == "The Task already exist")
            {
                return Ok(newTask);
            }
            if (newTask.Success == false && newTask.Message == "Repo ERROR")
            {
                ModelState.AddModelError("",$"Something was wrong in repository layer when adding company {createTaskDto}");
                return StatusCode(500, newTask);
            }

            //Return new Task Created.Creates a CreatedAtRouteResult object that produces a Status201Created response.
            return CreatedAtRoute("GetTaskByID", new { TaskId = newTask.Data.TaskId }, newTask);
        }

        //// DELETE: api/Tasks/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteTask(int id)
        //{
        //    var task = await _context.Tasks.FindAsync(id);
        //    if (task == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Tasks.Remove(task);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        //private bool TaskExists(int id)
        //{
        //    return _context.Tasks.Any(e => e.TaskId == id);
        //}
    }
}
