using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repository
{
    public class PostRepository : Repository<Post>, IPostRepository
    {
        private readonly BlogEngineContext _context;

        public PostRepository(BlogEngineContext context) : base(context)
        {
            this._context = context;
        }
        public async Task<IEnumerable<Post>> GetByUserIdAsync(int userId)
        {
            return await _context.Set<Post>()
                .Where(p => p.UserAuthor.Id == userId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Post>> GetEditedByUserIdAsync(int userId)
        {
            return await _context.Set<Post>()
                .Where(p => p.EditPostUsers.Any(postEdited => postEdited.UserAuthorId == userId))
                .ToListAsync();
        }

        public async Task<IEnumerable<Post>> GetPostsByStatus(int statusId)
        {
            return await _context.Set<Post>()
                .Where(p => p.StatusPostId == statusId)
                .ToListAsync();
        }
    }
}
