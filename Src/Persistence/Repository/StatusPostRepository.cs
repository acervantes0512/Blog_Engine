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
    public class StatusPostRepository : Repository<StatusPost>, IStatusPostRepository
    {
        private readonly BlogEngineContext _context;

        public StatusPostRepository(BlogEngineContext context) : base(context)
        {
            this._context = context;
        }
        public async Task<StatusPost> GetByStatusNameAsync(string nameStatus)
        {
            StatusPost rtaEntity = await _context.Set<StatusPost>()
                .Where(p => p.Name == nameStatus)
                .FirstOrDefaultAsync();

            _context.Entry(rtaEntity).State = EntityState.Detached;
            return rtaEntity;
        }
    }
}
