using Application.DTOs;
using Application.IServices;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
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

        public async Task AddUserAsync(addUserDTO dto)
        {
            IdentityUser userExist = await userManager.FindByNameAsync(dto.UserName);
            if(userExist == null)
            {
                Guid NewId = Guid.NewGuid();
                userExist = new IdentityUser(dto.UserName);
                userExist.Id = NewId.ToString();
                IdentityResult result = await userManager.CreateAsync(userExist, dto.Password);
                StringBuilder StringError = new StringBuilder();
                foreach(var error in result.Errors)
                {
                    StringError.Append(error.Description);
                    StringError.Append("\n");
                }
                if (result.Errors.Count() > 0)
                {
                    throw new Exception(StringError.ToString());
                }
                else
                {
                    UserDTO userDTO = new UserDTO()
                    {
                        UserId = NewId,
                        UserAddress = dto.UserAddress,
                        UserEmail = dto.UserEmail,
                        UserFirstName = dto.UserFirstName,
                        UserLastname = dto.UserLastname,
                        UserGit = dto.UserGit,
                        UserPhone = dto.UserPhone,
                        UserRole = dto.UserRole,
                        UserWeb = dto.UserWeb
                    };
                    ServiceUser.InsertWithID(userDTO);
                }
            }
            else
            {
                throw new Exception($"The username({dto.UserName}) is being used");
            }
        }

        public class AppSettings
        {
            public string Secret { get; set; }
        }
    }
}