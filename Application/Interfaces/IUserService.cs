using Application.DTOs;
using Domain.Entities;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IUserService
    {
        Task<UserControllerDto> CreateUserAsync(User user);
        Task<UserDto> AuthenticateAsync(string username, string password);
        Task<UserControllerDto> GetByUsernameAsync(string username);
    }
}