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
    public class PostService : IPostService
    {
        private readonly IUnitOfWork _unitOfWork;

        public PostService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        } 

        public async Task<IEnumerable<Post>> getPostsByUserId(int userId)
        {
            return await _unitOfWork.PostRepository.GetByUserIdAsync(userId);            
        }

        public async Task<IEnumerable<Post>> getPostsEditedByUserId(int userId)
        {
            return await _unitOfWork.PostRepository.GetEditedByUserIdAsync(userId);
        }

        public async Task<IEnumerable<Post>> GetPostsByStatus(int statudId)
        {
            return await _unitOfWork.PostRepository.GetPostsByStatus(statudId);
        }
        public async Task<Post> CreatePost(Post post)
        {
            post.StatusPostId = await GetStatusCodeRegistered();
            Post createdPost = await _unitOfWork.GetRepository<Post>().AddAsync(post);
            _unitOfWork.SaveChanges();
            return await _unitOfWork.GetRepository<Post>().GetByIdAsync(createdPost.Id);
        }

        private async Task<int> GetStatusCodeRegistered()
        {
            StatusPost status = await _unitOfWork.StatusPostRepository.GetByStatusNameAsync(nameof(Constants.StatusPosts.Pending));
            return status.Id;
        }




    }
}
