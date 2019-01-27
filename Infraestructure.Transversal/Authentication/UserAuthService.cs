using Application.DTOs;
using Application.IServices;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Transversal.Authentication
{
    public class UserAuthService : IUserAuthService
    {
        private UserManager<IdentityUser> userManager;
        private SignInManager<IdentityUser> signInManager;
        private IUserService ServiceUser;
        private readonly AppSettings _appSettings;

        public UserAuthService(UserManager<IdentityUser> userMgr,
        SignInManager<IdentityUser> signInMgr,
        IUserService serviceUser,
        IOptions<AppSettings> appSettings)
        {
            userManager = userMgr;
            signInManager = signInMgr;
            ServiceUser = serviceUser;
            _appSettings = appSettings.Value;
        }
        public async Task<UserDTO> AuthenticateAsync(string username, string password)
        {
            IdentityUser Iuser = await userManager.FindByNameAsync(username);
            if(Iuser != null)
            {
                await signInManager.SignOutAsync();
                if ((await signInManager.PasswordSignInAsync(Iuser, password, false, false)).Succeeded)
                {
                    var UserDTO = ServiceUser.GetUser(Guid.Parse(Iuser.Id));

                    var tokenHandler = new JwtSecurityTokenHandler();
                    var key = Encoding.ASCII.GetBytes(_appSettings.Secret);

                    var tokenDescriptor = new SecurityTokenDescriptor
                    {
                        Subject = new ClaimsIdentity(new Claim[] { new Claim(ClaimTypes.Name, UserDTO.UserId.ToString()) }),
                        Expires = DateTime.UtcNow.AddDays(7),
                        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                    };


                    var token = tokenHandler.CreateToken(tokenDescriptor);
                    UserDTO.Token = tokenHandler.WriteToken(token);

                    return UserDTO;
                }
            }
            return null;
        }

        public class AppSettings
        {
            public string Secret { get; set; }
        }
    }
}