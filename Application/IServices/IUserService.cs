using Application.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.IServices
{
    public interface IUserService
    {
        Guid Insert(UserDTO entityDTO);
        void InsertWithID(UserDTO entityDTO);
        IList<UserDTO> GetAll();
        Guid Update(UserDTO entityDTO);
        void Delete(Guid entityId);
        UserDTO GetUser(Guid entityId);
    }
}
