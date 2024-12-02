using AutoMapper;
using Moq;
using ToDoList.Application.DTOs;
using ToDoList.Application.Services;
using ToDoList.Domain.Entities;
using ToDoList.Domain.Interfaces;

namespace ToDoList.Tests.Services
{
    public class TaskServiceTests
    {
        private readonly Mock<ITaskRepository> _taskRepositoryMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly TaskService _taskService;

        public TaskServiceTests()
        {
            _taskRepositoryMock = new Mock<ITaskRepository>();
            _mapperMock = new Mock<IMapper>();
            _taskService = new TaskService(_taskRepositoryMock.Object, _mapperMock.Object);
        }

        [Fact]
        public async Task GetAllTasks_ReturnListOfTaskDTOs()
        {
            var taskEntities = new List<TaskItem>
            {
                new TaskItem { Id = 1, Title = "Tarefa 1", Description = "Descrição 1" },
                new TaskItem { Id = 2, Title = "Tarefa 2", Description = "Descrição 2" }
            };
            var taskDtos = new List<TaskDTO>
            {
                new TaskDTO { Id = 1, Title = "Tarefa 1", Description = "Descrição 1" },
                new TaskDTO { Id = 2, Title = "Tarefa 2", Description = "Descrição 2" }
            };

            _taskRepositoryMock.Setup(repo => repo.GetAll()).ReturnsAsync(taskEntities);
            _mapperMock.Setup(mapper => mapper.Map<List<TaskDTO>>(taskEntities)).Returns(taskDtos);

            var result = await _taskService.GetAllTasks();

            Assert.Equal(2, result.Count);
            Assert.Equal("Tarefa 1", result[0].Title);
            Assert.Equal("Tarefa 2", result[1].Title);
        }
    }
}
