using Moq;
using ToDoList.Application.DTOs;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Application.Interfaces;
using ToDoList.Controllers;

namespace ToDoList.Tests.Controllers
{
    public class TaskControllerTests
    {
        private readonly Mock<ITaskService> _taskServiceMock;
        private readonly TaskController _taskController;

        public TaskControllerTests()
        {
            _taskServiceMock = new Mock<ITaskService>();
            _taskController = new TaskController(_taskServiceMock.Object);
        }

        [Fact]
        public async Task GetAllTasks_ReturnOk()
        {
            var tasks = new List<TaskDTO>
            {
                new TaskDTO { Id = 1, Title = "Tarefa 1" },
                new TaskDTO { Id = 2, Title = "Tarefa 2" }
            };

            _taskServiceMock
                .Setup(service => service.GetAllTasks())
                .ReturnsAsync(tasks);

            var result = await _taskController.GetAllTasks();


            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnedTasks = Assert.IsType<List<TaskDTO>>(okResult.Value);
            Assert.Equal(2, returnedTasks.Count);
        }

        [Fact]
        public async Task AddTask_CreatedResult()
        {
            var newTask = new TaskDTO { Title = "Nova Tarefa" };

            _taskServiceMock
                .Setup(service => service.AddTask(It.IsAny<TaskDTO>()))
                .Returns(Task.CompletedTask);


            var result = await _taskController.AddTask(newTask);

            var createdResult = Assert.IsType<CreatedAtActionResult>(result);
            Assert.Equal(201, createdResult.StatusCode);
            Assert.Equal(newTask, createdResult.Value);

            _taskServiceMock.Verify(service => service.AddTask(It.IsAny<TaskDTO>()), Times.Once);
        }
    }
}
