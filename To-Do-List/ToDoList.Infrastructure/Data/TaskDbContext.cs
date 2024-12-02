using Microsoft.EntityFrameworkCore;
using ToDoList.Domain.Entities;

namespace ToDoList.Infrastructure.Data
{
    public class TaskDbContext : DbContext
    {
        public TaskDbContext(DbContextOptions<TaskDbContext> options) : base(options) {}
        public DbSet<TaskItem> TaskItems { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
