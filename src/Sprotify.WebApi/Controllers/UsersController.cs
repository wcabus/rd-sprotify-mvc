using System;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sprotify.Domain.Services;
using Sprotify.WebApi.Models.Users;

namespace Sprotify.WebApi.Controllers
{
    [Route("[controller]")]
    [Authorize]
    public class UsersController : Controller
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("{id:guid}", Name = Routes.GetUserById)]
        public async Task<IActionResult> GetUserById(Guid id)
        {
            var user = await _userService.GetUserById(id);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(Mapper.Map<User>(user));
        }

        [HttpPost]
        public async Task<IActionResult> RegisterUser([FromBody]UserToRegister model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await _userService.RegisterUser(model.Id, model.Name);
            return CreatedAtRoute(Routes.GetUserById, new { id = user.Id}, Mapper.Map<User>(user));
        }

        private static class Routes
        {
            public const string GetUserById = nameof(GetUserById);
        }
    }
}