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
    public class ReviewController : ControllerBase
    {
        private readonly IGenericService<Review> _genericService;

        public ReviewController(IGenericService<Review> genericService)
        {
            this._genericService = genericService;
        }

        [HttpGet("{id}")]
        [Authorize(Roles = nameof(Constants.UserRoles.Editor) + "," + nameof(Constants.UserRoles.Writer))]
        public async Task<ActionResult<Review>> Get(int id)
        {
            Review entity = await _genericService.GetByIdAsync(id);

            if (entity == null)
            {
                return NotFound();
            }

            return entity;
        }

        [HttpPost]
        [Authorize(Roles = nameof(Constants.UserRoles.Editor))]
        public async Task<ActionResult> Post(Review entity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Review createdEntity = await _genericService.CreateAsync(entity);
            return Ok(createdEntity);
        }
    }
}
