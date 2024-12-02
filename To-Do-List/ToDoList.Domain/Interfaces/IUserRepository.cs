using ToDoList.Domain.Entities;

namespace ToDoList.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetByUsername(string username);
        Task AddAsync(User user);
    }
}
