using Application.DTOs;
using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface ICommentService
    {
        Task<IEnumerable<Comment>> getCommentsByPost(int postd);
    }
}