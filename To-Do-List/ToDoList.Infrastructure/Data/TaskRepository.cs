using Microsoft.EntityFrameworkCore;
using ToDoList.Domain.Entities;
using ToDoList.Domain.Interfaces;

namespace ToDoList.Infrastructure.Data
{
    public class TaskRepository : ITaskRepository
    {
        private readonly TaskDbContext _context;

        public TaskRepository(TaskDbContext context) {
            _context = context;
        }
        public async Task<List<TaskItem>> GetAll()
        {
            return await _context.TaskItems.ToListAsync();
        }
        public async Task<TaskItem> GetById(int id)
        {
            return await _context.TaskItems.FindAsync(id);
        }
        public async Task Add(TaskItem taskItem)
        {
            await _context.TaskItems.AddAsync(taskItem);
            await _context.SaveChangesAsync();
        }
        public async Task Update(TaskItem taskItem)
        {
            _context.TaskItems.Update(taskItem);
            await _context.SaveChangesAsync();
        }
        public async Task Delete(int id)
        {
            var task = await _context.TaskItems.FindAsync(id);
            if (task != null)
            {
                _context.TaskItems.Remove(task);
                await _context.SaveChangesAsync();
            }
        }
    }
}
