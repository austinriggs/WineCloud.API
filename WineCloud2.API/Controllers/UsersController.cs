using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WineCloud2.Domain.Abstract;
using WineCloud2.Models.ViewModels;

namespace WineCloud2.API.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : Controller
    {
        private readonly Guid _userId;
        private readonly Guid _auth0UserId;

        private IUserService _userService;
        

        public UsersController(IUserService service)
        {
            _userService = service;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(UserVM user)
        {
            try
            {
                var newUser = await _userService.CreateUserAsync(user);

                return Ok(newUser);
            }
            catch
            {
                throw;
            }
            
        }

        [HttpGet]
        [Route("{email}")]
        [Authorize]
        public async Task<IActionResult> GetUser(string email)
        {
            try
            {
                var user = await _userService.GetUserByEmail(email);

                return Ok(user);
            }
            catch
            {
                throw;
            }
        }

    }
}