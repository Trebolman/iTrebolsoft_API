using Application.DTOs;
using System;
using System.Threading.Tasks;

namespace Infraestructure.Transversal.Authentication
{
    public interface IUserAuthService
    {
        Task<UserDTO> AuthenticateAsync(string username, string password);
        Task AddUserAsync (AddUserDTO dto);
    }
}
