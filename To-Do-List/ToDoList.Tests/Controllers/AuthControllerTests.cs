using Microsoft.AspNetCore.Mvc;
using Moq;
using ToDoList.Application.DTOs;
using ToDoList.Application.Interfaces;
using ToDoList.Presentation.Controllers;

namespace ToDoList.Tests.Controllers
{
    public class AuthControllerTests
    {
        private readonly Mock<IAuthService> _authServiceMock;
        private readonly AuthController _authController;

        public AuthControllerTests()
        {
            _authServiceMock = new Mock<IAuthService>();
            _authController = new AuthController(_authServiceMock.Object);
        }

        [Fact]
        public async Task Login_ValidCredentials()
        {
            var loginDto = new LoginDTO
            {
                Username = "testuser",
                Password = "password123"
            };

            _authServiceMock
                .Setup(service => service.Login(It.Is<LoginDTO>(dto =>
                    dto.Username == loginDto.Username && dto.Password == loginDto.Password)))
                .ReturnsAsync("token_valido");

            var result = await _authController.Login(loginDto);

            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal("token_valido", okResult.Value);
        }

        [Fact]
        public async Task Login_InvalidCredentials()
        {
            var loginDto = new LoginDTO
            {
                Username = "invaliduser",
                Password = "invalpassword"
            };

            _authServiceMock
                .Setup(service => service.Login(It.IsAny<LoginDTO>()))
                .ThrowsAsync(new UnauthorizedAccessException("Credenciais Invalidas."));

            var result = await _authController.Login(loginDto);

            var unauthorizedResult = Assert.IsType<UnauthorizedObjectResult>(result);
            Assert.Equal("Credenciais Invalidas.", unauthorizedResult.Value);
        }
    }
}
