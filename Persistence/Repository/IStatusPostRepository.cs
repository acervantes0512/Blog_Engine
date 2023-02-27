using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Persistence.Repository
{
    public interface IStatusPostRepository
    {
        Task<StatusPost> GetByStatusNameAsync(string username);
    }
}