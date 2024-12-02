using ToDoList.Application.DTOs;

namespace ToDoList.Application.Interfaces
{
    public interface ITaskService
    {
        Task<List<TaskDTO>> GetAllTasks();
        Task<TaskDTO> GetTaskById(int id);
        Task AddTask(TaskDTO taskDTO);
        Task UpdateTask(TaskDTO taskDTO);
        Task DeleteTask(int id);
    }
}
