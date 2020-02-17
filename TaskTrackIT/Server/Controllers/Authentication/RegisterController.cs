using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TaskTrackIT.Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using TaskTrackIT.Server.DataAccess;

namespace TaskTrackIT.Server.Controllers.Authentication
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public RegisterController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromBody]RegisterModel model)
        {
            var newUser = new ApplicationUser { UserName = model.Email, Email = model.Email, UserType = 3 }; //RSDEBUG UserType needs inputting
            var result = await _userManager.CreateAsync(newUser, model.Password);
            if (!result.Succeeded)
            {
                var errors = result.Errors.Select(x => x.Description);
                var failure = new RegisterResult
                {
                    Successful = false,
                    Errors = errors
                };
                return Ok(failure);
            }
            return Ok(new RegisterResult { Successful = true });
        }
    }
}