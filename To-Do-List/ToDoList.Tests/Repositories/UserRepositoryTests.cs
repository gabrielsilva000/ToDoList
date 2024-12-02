using Microsoft.EntityFrameworkCore;
using ToDoList.Domain.Entities;
using ToDoList.Infrastructure.Data;

namespace ToDoList.Tests.Repositories
{
    public class UserRepositoryTests
    {
        private readonly UserRepository _userRepository;
        private readonly DbContextOptions<TaskDbContext> _dbContextOptions;

        public UserRepositoryTests()
        {
            _dbContextOptions = new DbContextOptionsBuilder<TaskDbContext>()
                .UseInMemoryDatabase("UserRepositoryTestDb")
                .Options;

            var dbContext = new TaskDbContext(_dbContextOptions);
            _userRepository = new UserRepository(dbContext);
        }

        [Fact]
        public async Task GetByUsername_ReturnUser()
        {
            // Arrange
            var username = "testuser";
            using (var context = new TaskDbContext(_dbContextOptions))
            {
                context.Users.Add(new User { Username = username, Password = "password" });
                await context.SaveChangesAsync();
            }

            // Act
            var user = await _userRepository.GetByUsername(username);

            // Assert
            Assert.NotNull(user);
            Assert.Equal(username, user.Username);
        }
    }
}
