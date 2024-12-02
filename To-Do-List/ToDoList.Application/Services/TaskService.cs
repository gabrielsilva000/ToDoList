using AutoMapper;
using ToDoList.Application.DTOs;
using ToDoList.Application.Interfaces;
using ToDoList.Domain.Entities;
using ToDoList.Domain.Interfaces;

namespace ToDoList.Application.Services
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _taskRepository;
        private readonly IMapper _mapper;
        public TaskService(ITaskRepository taskRepository, IMapper mapper)
        {
            _taskRepository = taskRepository;
            _mapper = mapper;
        }
        public async Task<List<TaskDTO>> GetAllTasks()
        {
            var tasks = await _taskRepository.GetAll();

            return _mapper.Map<List<TaskDTO>>(tasks);
        }
        public async Task<TaskDTO> GetTaskById(int id)
        {
            var task = await _taskRepository.GetById(id);

            if (task == null)
                throw new KeyNotFoundException("tarefa não encontrado!");

            return _mapper.Map<TaskDTO>(task);
        }
        public async Task AddTask(TaskDTO taskDTO)
        {
            var task = _mapper.Map<TaskItem>(taskDTO);

            await _taskRepository.Add(task);
        }
        public async Task UpdateTask(TaskDTO taskDTO)
        {
            var task = _mapper.Map<TaskItem>(taskDTO);
            await _taskRepository.Update(task);
        }
        public async Task DeleteTask(int id)
        {
            await _taskRepository.Delete(id);
        }
    }
}
