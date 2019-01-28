using Application.DTOs;
using Infraestructure.Transversal.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTrebolsoft.Controllers
{
    [Route("api/[controller]")]
    //[Authorize]
    public class AuthenticationController : Controller
    {
        IUserAuthService UserAuthService;
        public AuthenticationController(IUserAuthService userService)
        {
            this.UserAuthService = userService;
        }

        [HttpPost("LogIn")]
        [AllowAnonymous]
        public async Task<IActionResult> LogIn([FromBody]LoginDTO login)
        {
            if (ModelState.IsValid)
            {
                var user = await UserAuthService.AuthenticateAsync(login.UserName, login.Password);
                if (user == null)
                    return BadRequest(new { message = "Username or password is incorrect" });
                return Ok(user);
            }
            else
            {
                return BadRequest(new { message = "Model(LoginDTO) is not Valid" });
            }
        }

        [HttpPost]
        public async Task<ActionResult> AddUserAsync(addUserDTO dto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await UserAuthService.AddUserAsync(dto);
                    return Ok(true);
                }
                else
                {
                    IEnumerable<ModelError> allErrors = ModelState.Values.SelectMany(v => v.Errors);
                    StringBuilder sb = new StringBuilder();
                    foreach (var modelState in allErrors)
                    {
                        sb.Append(modelState.ErrorMessage);
                        sb.Append("\n");
                    }
                    throw new Exception(sb.ToString());
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}