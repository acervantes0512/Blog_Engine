using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Persistence.Repository
{
    public interface IUserRepository
    {
        Task<User> GetByUsernameAsync(string username);
    }
}