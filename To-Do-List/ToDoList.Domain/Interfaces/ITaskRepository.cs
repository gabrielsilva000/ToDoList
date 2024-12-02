using ToDoList.Domain.Entities;
namespace ToDoList.Domain.Interfaces
{
    public interface ITaskRepository
    {
        Task<List<TaskItem>> GetAll();
        Task<TaskItem> GetById(int id);
        Task Add(TaskItem taskItem);
        Task Update(TaskItem taskItem);
        Task Delete(int id);
    }
}
