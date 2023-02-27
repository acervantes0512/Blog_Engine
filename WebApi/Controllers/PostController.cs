using Application.DTOs;
using Application.Implementations;
using Application.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IGenericService<Post> _genericService;
        private readonly IPostService _postService;

        public PostController(IGenericService<Post> genericService, IPostService postService)
        {
            this._genericService = genericService;
            this._postService = postService;
        }

        [HttpGet]
        [Route("GetByUserId")]
        [Authorize(Roles = nameof(Constants.UserRoles.Editor) + "," + nameof(Constants.UserRoles.Writer))]
        public async Task<ActionResult<IEnumerable<Post>>> GetByUserId(int id)
        {
            IEnumerable<Post> rta = await _postService.getPostsByUserId(id);

            if (rta == null)
            {
                return NotFound();
            }

            return rta.ToList();
        }

        [HttpGet]
        [Route("GetPostsEditedByUserId")]
        [Authorize(Roles = nameof(Constants.UserRoles.Editor))]
        public async Task<ActionResult<IEnumerable<Post>>> GetPostsEditedByUserId(int id)
        {
            IEnumerable<Post> rta = await _postService.getPostsEditedByUserId(id);

            if (rta == null)
            {
                return NotFound();
            }

            return rta.ToList();
        }

        [HttpGet]
        [Route("GetPostsByStatus")]
        [Authorize(Roles = nameof(Constants.UserRoles.Editor))]
        public async Task<ActionResult<IEnumerable<Post>>> GetPostsByStatus(int id)
        {
            IEnumerable<Post> rta = await _postService.GetPostsByStatus(id);

            if (rta == null)
            {
                return NotFound();
            }

            return rta.ToList();
        }

        /// <summary>
        /// Obtener todos los registros
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Authorize(Roles = nameof(Constants.UserRoles.Editor) + "," + nameof(Constants.UserRoles.Writer) + "," + nameof(Constants.UserRoles.Public))]
        public async Task<ActionResult<IEnumerable<Post>>> Get()
        {
            return (await _genericService.GetAllAsync()).ToList();
        }
        
        [HttpGet("{id}")]
        [Authorize(Roles = nameof(Constants.UserRoles.Editor) + "," + nameof(Constants.UserRoles.Writer) + "," + nameof(Constants.UserRoles.Public))]
        public async Task<ActionResult<Post>> Get(int id)
        {
            var entity = await _genericService.GetByIdAsync(id);

            if (entity == null)
            {
                return NotFound();
            }

            return entity;
        }

        
        [HttpDelete("{id}")]
        [Authorize(Roles = nameof(Constants.UserRoles.Editor))]
        public async Task<IActionResult> Delete(int id)
        {
            await _genericService.DeleteAsync(id);
            return NoContent();
        }

        [HttpPut]
        [Authorize(Roles = nameof(Constants.UserRoles.Editor) + "," + nameof(Constants.UserRoles.Writer))]
        public async Task<IActionResult> Put(Post entity)
        {
            Post updatedEntity = await _genericService.UpdateAsync(entity);

            return Ok(updatedEntity);
        }

        [HttpPost]
        [Authorize(Roles = nameof(Constants.UserRoles.Editor) + "," + nameof(Constants.UserRoles.Writer))]
        public async Task<ActionResult> Post(Post entity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var createdEntity = await _postService.CreatePost(entity);
            return Ok(createdEntity);
        }

    }
}
