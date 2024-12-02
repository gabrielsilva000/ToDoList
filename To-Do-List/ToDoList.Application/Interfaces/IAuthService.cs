using ToDoList.Application.DTOs;

namespace ToDoList.Application.Interfaces
{
    public interface IAuthService
    {
        Task<string> Login(LoginDTO loginDto);
        Task Register(RegisterDTO registerDto);
    }
}
