using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Persistence.Repository
{
    public interface IPostRepository : IRepository<Post>
    {
        Task<IEnumerable<Post>> GetByUserIdAsync(int userId);
        Task<IEnumerable<Post>> GetEditedByUserIdAsync(int userId);
        Task<IEnumerable<Post>> GetPostsByStatus(int statusId);
    }
}