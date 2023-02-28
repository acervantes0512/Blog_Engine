using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Persistence.Repository
{
    public interface ICommentRepository : IRepository<Comment>
    {
        Task<IEnumerable<Comment>> GetCommentsByPost(int postId);
    }
}