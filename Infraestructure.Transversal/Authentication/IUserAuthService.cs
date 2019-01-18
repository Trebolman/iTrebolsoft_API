using Application.DTOs;
using System.Threading.Tasks;

namespace Infraestructure.Transversal.Authentication
{
    public interface IUserAuthService
    {
        Task<UserDTO> AuthenticateAsync(string username, string password);
    }
}
