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
    public class CommentRepository : Repository<Comment>, ICommentRepository
    {
        private readonly BlogEngineContext _context;

        public CommentRepository(BlogEngineContext context) : base(context)
        {
            this._context = context;
        }
        public async Task<IEnumerable<Comment>> GetCommentsByPost(int postId)
        {
            return await _context.Set<Comment>()
                .Where(p => p.PostId == postId)
                .ToListAsync();
        }
    }
}
