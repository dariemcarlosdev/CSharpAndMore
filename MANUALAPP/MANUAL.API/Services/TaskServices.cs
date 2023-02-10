
using AutoMapper;
using MANUAL.API.Data.Repositorires;
using MANUAL.API.Domain.ContractServices;
using MANUAL.API.Domain.Models;
using MANUAL.API.Domain.Repository;
using MANUAL.API.DTOResources;
using MANUAL.API.ServicesResponder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MANUAL.API.Services
{

    public class TaskServices : ITaskServices
    {
        //The constructor receives an instance of IMapper implementation. I use these interface methods to use AutoMapper mapping methods.
        private readonly IMapper _mapper;
        //private readonly ITaskRepository _taskRepository;
        private readonly IUnityOfWork _unityOfWork;

        public TaskServices(IMapper imapper
                            , IUnityOfWork unityOfWork
                            )
        {
            _mapper = imapper;
            //_taskRepository = taskRepository;
            _unityOfWork = unityOfWork;
        }

        public async Task<ServiceResponse<List<TaskDto>>> GetTasksAsync()
        {
            var _response = new ServiceResponse<List<TaskDto>>();


            try
            {
                var tasksList = await _unityOfWork._taskRepository.GetTasksAsync();
                var tasksListDto = new List<TaskDto>();

                foreach (var task in tasksList)
                {
                    //_mapper.Map<TDestination>(TSourceObject).
                    tasksListDto.Add(_mapper.Map<TaskDto>(task));
                }

                _response.Success = true;
                _response.Message = "API response OK";
                _response.Data = tasksListDto;

            }
            catch (Exception ex)
            {
                _response.Success = false;
                _response.Data = null;
                _response.Message = "API response with ERROR";
                _response.ErrorMessages = new List<string> { Convert.ToString(ex.Message) };
                
            }

            return _response;
        }

        public async Task<ServiceResponse<TaskDto>> GetByIdAsync(int taskId)
        {
            
            //ServiceResponse<TaskDto> _response = new();
            var _response = new ServiceResponse<TaskDto>();
            
            try
            {
                var _task = await _unityOfWork._taskRepository.FindByIdAsync(taskId);

                if (_task == null)
                {
                    _response.Success = false;
                    _response.Message = "Task not found";
                    return _response;
                }

                var _taskDto = _mapper.Map<TaskDto>(_task);

                _response.Success = true;
                _response.Data = _taskDto;
                _response.Message = "API response OK";
            }

            

            catch (Exception ex)
            {

                _response.Success = false;
                _response.Data = null;
                _response.Message = "API response with ERROR";
                _response.ErrorMessages = new List<string>{ Convert.ToString(ex.Message)};
            }

            return _response;
        }

        public async Task<ServiceResponse<TaskDto>> AddTaskAsync(CreateTaskDto createTaskDto)
        {
            var _response = new ServiceResponse<TaskDto>();
            var _existTask = await _unityOfWork._taskRepository.TaskExistAsync(createTaskDto.Description);

            try
            {
                //Checking if the company already exist.
                if ( _existTask)
                {
                    _response.Message = "The Task already exist";
                    _response.Success = false;
                    _response.Data = null;

                    return _response;
                }


                var _newTask = new TaskEntity()
                {
                    Description = createTaskDto.Description
                    , DateOfTaskCreation = Convert.ToDateTime(DateTime.Now.ToString("MM-dd-yyyy"))
                    , CompletedDate = null
                    , DueDate = createTaskDto.DueDate
                    , IsCompleted = false
                    , IsEnable = true
                    , IsDeleted = false
                    , StartedOn = createTaskDto.StartedOn
                    , Jobs = createTaskDto.Jobs

                    //*Here check if do I need to add a list of employees when I am crating a new Taks.
                };

                //Add new Task record.
                var _addingTask = await _unityOfWork._taskRepository.AddAsync(_newTask);
                await  _unityOfWork.CompleteTransactionAsync();

                if (!_addingTask)
                {
                    _response.Error = "Repo ERROR";
                    _response.Success = false;
                    _response.Data = null;
                    _response.Message = "ERROR creating new Task";
                    
                }

                _response.Success = true;
                _response.Data = _mapper.Map<TaskDto>(_newTask);
                _response.Message = "Task created";
            }
            catch (Exception ex)
            {

                _response.Success = false;
                _response.Data = null;
                _response.Message = "API response with ERROR";
                _response.ErrorMessages = new List<string> { Convert.ToString(ex.Message) };
            }

            return _response;
        }

        public async Task<ServiceResponse<string>> SoftDeleteTaskAsync(int taskId)
        {
            var _response = new ServiceResponse<string>();

            try
            {
                //checking if Task exist
                var _existingTask = _unityOfWork._taskRepository.TaskExistAsync(taskId);
                
                if (_existingTask == null)
                {
                    _response.Success = false;
                    _response.Message = "API response NOT OK, Task NOT FOUND";
                    _response.Data = null;

                    return _response;
                }

                if (!await _unityOfWork._taskRepository.SoftDeleteTaskAsync(taskId))
                {
                    _response.Success = false;
                    _response.Message = "Repo ERROR";

                    return _response;
                }

                _response.Success = true;
                _response.Message = "Task Deleted";
            }
            catch (Exception ex)
            {

                _response.Success = false;
                _response.Data = null;
                _response.Message = "API response with ERROR";
                _response.ErrorMessages = new List<string> { Convert.ToString(ex.Message)};
            }

            return _response;
        }

        public async Task<ServiceResponse<TaskDto>> UpdateTaskAsync(int taskId, UpdateTaskDto updateTaskDto)
        {
            var _response = new ServiceResponse<TaskDto>();

            try
            {
                var _existingTask = await _unityOfWork._taskRepository.FindByIdAsync(taskId);
                //try if Task Exist.                
                if (_existingTask == null)
                {
                    _response.Success = false;
                    _response.Data = null;
                    _response.Message = "Task NOT FOUND";

                    return _response;
                }

                //Update if exist Task.
                _existingTask.Description = updateTaskDto.Description;
                _existingTask.CompletedDate = updateTaskDto.CompletedDate;
                _existingTask.DateOfTaskCreation = updateTaskDto.DateOfTaskCreation;
                _existingTask.DueDate = updateTaskDto.DueDate;
                _existingTask.IsCompleted = updateTaskDto.IsCompleted;
                _existingTask.IsDeleted = updateTaskDto.IsDeleted;
                _existingTask.Jobs = updateTaskDto.Jobs;
                _existingTask.StartedOn = updateTaskDto.StartedOn;
                _existingTask.IsEnable = updateTaskDto.IsEnable;

                if (!_unityOfWork._taskRepository.UpdateTask(_existingTask))
                {
                    _response.Success = false;
                    _response.Data = null;
                    _response.Message = "Repo ERROR";

                    return _response;
                }

                //Mapping Task to TaskDto
                var _taskDto = _mapper.Map<TaskDto>(_existingTask);
                _response.Success = true;
                _response.Data = _taskDto;
                _response.Message = "Task updated";

            }
            catch (Exception ex)
            {
                _response.Success = false;
                _response.Data = null;
                _response.Message = "API response with ERROR";
                _response.ErrorMessages = new List<string> { Convert.ToString(ex.Message) };
            }

            return _response;
        }

    }
}
