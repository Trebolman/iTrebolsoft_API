using Application.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.IServices
{
    public interface IUserService
    {
        void Insert(UserDTO entityDTO);
        IList<UserDTO> GetAll();
        void Update(UserDTO entityDTO);
        void Delete(Guid entityId);
        UserDTO GetUser(Guid entityId);
    }
}
