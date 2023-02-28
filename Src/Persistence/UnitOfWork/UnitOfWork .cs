using Microsoft.EntityFrameworkCore;
using Persistence.EntityFramework;
using Persistence.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BlogEngineContext _context;
        private bool disposed = false;
        private readonly IPostRepository _postRepository;
        private readonly IUserRepository _userRepository;
        private readonly IStatusPostRepository _statusPostRepository;
        private readonly ICommentRepository _commentRepository;

        public UnitOfWork(BlogEngineContext context)
        {
            _context = context;
            _postRepository = new PostRepository(_context);
            _userRepository = new UserRepository(_context);
            _statusPostRepository = new StatusPostRepository(_context);
            _commentRepository = new CommentRepository(_context);
        }

        public IPostRepository PostRepository => _postRepository;
        public IUserRepository UserRepository => _userRepository;
        public IStatusPostRepository StatusPostRepository => _statusPostRepository;
        public ICommentRepository CommentRepository => _commentRepository;

        public IRepository<T> GetRepository<T>() where T : class
        {
            return new Repository<T>(_context);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }

}
