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
    public class UserRepository : Repository<User>, IUserRepository
    {
        private readonly BlogEngineContext _context;

        public UserRepository(BlogEngineContext context) : base(context)
        {
            this._context = context;
        }
        public async Task<User> GetByUsernameAsync(string username)
        {
            return await _context.Set<User>()
                .Where(p => p.Username == username)
                .FirstOrDefaultAsync();
        }
    }
}
