using Application.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.IServices
{
    public interface IUserService
    {
        Guid Insert(UserDTO entityDTO);
        Task InsertWithID(UserDTO entityDTO);
        IList<UserDTO> GetAll();
        Guid Update(UserDTO entityDTO);
        void Delete(Guid entityId);
        UserDTO GetUser(Guid entityId);
    }
}
