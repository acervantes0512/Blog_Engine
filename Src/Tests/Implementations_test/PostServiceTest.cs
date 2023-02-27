using Application.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using Persistence.EntityFramework;
using Persistence.Repository;
using Persistence.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tests.Implementations_test.MoqObjects;

namespace Tests.Implementations_test
{
    public class PostServiceTest
    {
        private readonly Mock<IUnitOfWork> _mockUnitOfWork = new Mock<IUnitOfWork>();
        private readonly Mock<IPostRepository> _mockPostRepository = new Mock<IPostRepository>();
        private readonly Mock<IStatusPostRepository> _mockStatusPostRepository = new Mock<IStatusPostRepository>();
        private readonly Mock<BlogEngineContext> _mockBlogEngineContext = new Mock<BlogEngineContext>();
        private Mock<IRepository<Post>> _mockRepository;

        [SetUp]
        public void Setup()
        {
            _mockBlogEngineContext.Setup(x => x.Set<Post>()).Returns(new Mock<DbSet<Post>>().Object);
           _mockRepository = new Mock<IRepository<Post>>(_mockBlogEngineContext.Object);
        }

        [Test]
        public async Task getPostsByUserId_TestOK()
        {
            // Arrange            
            _mockPostRepository.Setup(x => x.GetByUserIdAsync(It.IsAny<int>())).ReturnsAsync(new List<Post> { new MockPost() });
            _mockUnitOfWork.Setup(x => x.PostRepository).Returns(_mockPostRepository.Object);
            PostService postService = new PostService(_mockUnitOfWork.Object);

            // Act
            IEnumerable<Post> result = await postService.getPostsByUserId(1);

            // Assert
            Assert.NotNull(result);
        }

        [Test]
        public async Task getPostsEditedByUserId_TestOK()
        {
            // Arrange            
            _mockPostRepository.Setup(x => x.GetEditedByUserIdAsync(It.IsAny<int>())).ReturnsAsync(new List<Post> { new MockPost() });
            _mockUnitOfWork.Setup(x => x.PostRepository).Returns(_mockPostRepository.Object);
            PostService postService = new PostService(_mockUnitOfWork.Object);

            // Act
            IEnumerable<Post> result = await postService.getPostsEditedByUserId(1);

            // Assert
            Assert.NotNull(result);
        }

        [Test]
        public async Task GetPostsByStatus_TestOK()
        {
            // Arrange            
            _mockPostRepository.Setup(x => x.GetPostsByStatus(It.IsAny<int>())).ReturnsAsync(new List<Post> { new MockPost() });
            _mockUnitOfWork.Setup(x => x.PostRepository).Returns(_mockPostRepository.Object);
            PostService postService = new PostService(_mockUnitOfWork.Object);

            // Act
            IEnumerable<Post> result = await postService.getPostsEditedByUserId(1);

            // Assert
            Assert.NotNull(result);
        }
    }
}
