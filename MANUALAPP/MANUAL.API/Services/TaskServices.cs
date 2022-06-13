
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
                var tasksList = await _taskRepository.ListAsync();
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
                _response.Message = "Error in response";
                _response.ErrorMessages = new List<string> { Convert.ToString(ex.Message) };
                
            }

            return _response;
        }

        public Task<ServiceResponse<TaskDto>> GetTaskByIdAsync(int taskId)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<TaskDto>> AddTaskAsync(CreateTaskDto createTaskDto)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<string>> DeleteTaskAsync(int taskId)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<TaskDto>> UpdateTaskAsync(UpdateTaskDto updateTaskDto)
        {
            throw new NotImplementedException();
        }
    }
}
