using Application.DTOs;
using Application.Implementations;
using Domain.Entities;
using Persistence.Repository;
using Persistence.UnitOfWork;
using Shared;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public class CommentService : ICommentService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CommentService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        } 

        public async Task<IEnumerable<Comment>> getCommentsByPost(int postd)
        {
            return await _unitOfWork.CommentRepository.GetCommentsByPost(postd);            
        }


    }
}
