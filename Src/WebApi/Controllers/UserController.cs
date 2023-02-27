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
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IGenericService<Post> genericService, IUserService userService)
        {
            this._userService = userService;
        }

        [HttpPost]
        [Route("CreateUser")]        
        public async Task<ActionResult> CreateUser(User user)
        {
            UserControllerDto createdUser = await _userService.CreateUserAsync(user);

            return Ok(createdUser);
        }

        [HttpGet]
        [Route("GetByUsername")]
        [Authorize(Roles = nameof(Constants.UserRoles.Editor) + "," + nameof(Constants.UserRoles.Writer) + "," + nameof(Constants.UserRoles.Public))]
        public async Task<ActionResult> GetByUsername(string username)
        {
            UserControllerDto createdUser = await _userService.GetByUsernameAsync(username);

            return Ok(createdUser);
        }

    }
}
