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
    public class CommentController : ControllerBase
    {
        private readonly IGenericService<Comment> _genericService;

        public CommentController(IGenericService<Comment> genericService)
        {
            this._genericService = genericService;
        }

        [HttpGet("{id}")]
        [Authorize(Roles = nameof(Constants.UserRoles.Editor) + "," + nameof(Constants.UserRoles.Writer) + "," + nameof(Constants.UserRoles.Public))]
        public async Task<ActionResult<Comment>> Get(int id)
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
        public async Task<IActionResult> Put(Comment entity)
        {
            Comment updatedEntity = await _genericService.UpdateAsync(entity);

            return Ok(updatedEntity);
        }

        [HttpPost]
        [Authorize(Roles = nameof(Constants.UserRoles.Editor) + "," + nameof(Constants.UserRoles.Writer) + "," + nameof(Constants.UserRoles.Public))]
        public async Task<ActionResult> Post(Comment entity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Comment createdEntity = await _genericService.CreateAsync(entity);
            return Ok(createdEntity);
        }

    }
}
