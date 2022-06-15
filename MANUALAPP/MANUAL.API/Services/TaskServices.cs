
using AutoMapper;
using MANUAL.API.Domain.ContractServices;
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
        private readonly ITaskRepository _taskRepository;
        private readonly IUnityOfWork _unityOfWork;

        public TaskServices(IMapper imapper, ITaskRepository taskRepository, IUnityOfWork unityOfWork)
        {
            _mapper = imapper;
            _taskRepository = taskRepository;
            _unityOfWork = unityOfWork;
        }

        public async Task<ServiceResponse<List<TaskDto>>> GetListTasksAsync()
        {
            var _response = new ServiceResponse<List<TaskDto>>();


            try
            {
                var tasksList = await _taskRepository.GetTasksAsync();
                var tasksListDto = new List<TaskDto>();

                foreach (var task in tasksList)
                {
                    tasksListDto.Add(_mapper.Map<TaskDto>(task));
                }

                _response.Success = true;
                _response.Message = "Response Ok";
                _response.Data = tasksListDto;

            }
            catch (Exception ex)
            {
                _response.Success = false;
                _response.Data = null;
                _response.Message = "API response NOT OK";
                _response.ErrorMessages = new List<string> { Convert.ToString(ex.Message) };
                
            }

            return _response;
        }

        public async Task<ServiceResponse<TaskDto>> GetTaskByIdAsync(int taskId)
        {
            var _response = new ServiceResponse<TaskDto>();
            
            try
            {
                var _task = await _taskRepository.FindTaskByIdAsync(taskId);

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
                _response.Message = "API response NOT OK";
                _response.ErrorMessages = new List<string>{ Convert.ToString(ex.Message)};
            }

            return _response;
        }

        public async Task<ServiceResponse<TaskDto>> AddTaskAsync(CreateTaskDto createTaskDto)
        {
            var _response = new ServiceResponse<TaskDto>();

            try
            {
                //Checking if the company already exist.
                if ( await _taskRepository.TaskExistAsync(createTaskDto.Description))
                {
                    _response.Message = "The Task exist";
                    _response.Success = false;
                    _response.Data = null;

                    return _response;
                }

                
                var _newTask = new Domain.Models.TaskEntity()
                {
                      Description = createTaskDto.Description
                    , DateOfTaskCreation = createTaskDto.DateOfTaskCreation
                    , CompletedDate = createTaskDto.CompletedDate
                    , DueDate = createTaskDto.DueDate
                    , IsCompleted = createTaskDto.IsCompleted
                    , IsEnable = createTaskDto.IsEnable
                    , StartedOn = createTaskDto.StartedOn

                    //*Here check if do I need to add a list of employees when I am crating a new Taks.
                };

            }
            catch (Exception ex)
            {

                _response.Success = false;
                _response.Data = null;
                _response.Message = "API response NOT OK";
                _response.ErrorMessages = new List<string> { Convert.ToString(ex.Message) };
            }

            return _response;
        }

        public async Task<ServiceResponse<string>> DeleteTaskAsync(int taskId)
        {
            var _response = new ServiceResponse<string>();

            try
            {
                //checking if Task exist

                var _existingTask = _taskRepository.FindTaskByIdAsync(taskId);
                if (_existingTask == null)
                {
                    _response.Success = false;
                    _response.Message = "API response NOT OK";
                    _response.Data = null;

                    return _response;
                }

                if (await _taskRepository.)
                {

                }
            }
            catch (Exception ex)
            {

                throw;
            }

            return _response;
        }

        public Task<ServiceResponse<TaskDto>> UpdateTaskAsync(UpdateTaskDto updateTaskDto)
        {
            throw new NotImplementedException();
        }
    }
}
