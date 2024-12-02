using Microsoft.EntityFrameworkCore;
using ToDoList.Domain.Entities;
using ToDoList.Infrastructure.Data;

namespace ToDoList.Tests.Repositories
{
    public class TaskRepositoryTests
    {
        private readonly TaskRepository _taskRepository;
        private readonly DbContextOptions<TaskDbContext> _dbContextOptions;

        public TaskRepositoryTests()
        {
            _dbContextOptions = new DbContextOptionsBuilder<TaskDbContext>()
                .UseInMemoryDatabase("TaskRepositoryTestDb")
                .Options;

            var dbContext = new TaskDbContext(_dbContextOptions);
            _taskRepository = new TaskRepository(dbContext);
        }

        [Fact]
        public async Task GetAllTasks_ReturnTasks()
        {
            using (var context = new TaskDbContext(_dbContextOptions))
            {
                context.TaskItems.Add(new TaskItem
                {
                    Title = "Tarefa 1",
                    Description = "Descrição da Tarefa 1"
                });
                context.TaskItems.Add(new TaskItem
                {
                    Title = "Tarefa 2",
                    Description = "Descriçao da Tarefa 2"
                });
                await context.SaveChangesAsync();
            }

            var tasks = await _taskRepository.GetAll();

            Assert.NotNull(tasks);
            Assert.Equal(2, tasks.Count());
        }

        [Fact]
        public async Task AddTask_AddTaskToDatabase()
        {
            var newTask = new TaskItem
            {
                Title = "Nova Tarefa",
                Description = "Tarefa Descrição"
            };

            await _taskRepository.Add(newTask);

            using (var context = new TaskDbContext(_dbContextOptions))
            {
                Assert.Equal(1, context.TaskItems.Count());
                var addedTask = context.TaskItems.First();
                Assert.Equal("Nova Tarefa", addedTask.Title);
                Assert.Equal("Tarefa Descrição", addedTask.Description);
            }
        }
    }
}
