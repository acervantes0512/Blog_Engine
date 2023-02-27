using Application.DTOs;
using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IPostService
    {
        Task<IEnumerable<Post>> getPostsByUserId(int userId);
        Task<IEnumerable<Post>> getPostsEditedByUserId(int userId);
        Task<IEnumerable<Post>> GetPostsByStatus(int statudId);
        Task<Post> CreatePost(Post post);
    }
}