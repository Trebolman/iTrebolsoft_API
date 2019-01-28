using Application.DTOs;
using Application.IServices;
using Domain;
using Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Services
{
    public class UserService : IUserService
    {
        IUserRepository repository;
        public UserService(IUserRepository repository)
        {
            this.repository = repository;
        }
        public void Delete(Guid entityId)
        {
            repository.Delete(entityId);
        }

        public IList<UserDTO> GetAll()
        {
            IQueryable<TUser> UsersEntities = repository.Items;
            return Builders.GenericBuilder.builderListEntityDTO<UserDTO, TUser>(UsersEntities);
        }

        public UserDTO GetUser(Guid entityId)
        {
            var entities = repository.Items;
            var usuario = repository.Items.Where(user => user.UserId == entityId).FirstOrDefault();
            return Builders.GenericBuilder.builderEntityDTO<UserDTO, TUser>(usuario);
        }

        public void Insert(UserDTO entityDTO)
        {
            TUser entity = Builders.
                        GenericBuilder.
                        builderDTOEntity<TUser, UserDTO>
                        (entityDTO);
            repository.Save(entity);
        }

        public void InsertWithID(UserDTO entityDTO)
        {
            TUser entity = Builders.GenericBuilder.builderDTOEntity<TUser, UserDTO>(entityDTO);
            repository.SaveWithId(entity);
        }

        public void Update(UserDTO entityDTO)
        {
            var entity = Builders.
                GenericBuilder.
                builderDTOEntity<TUser, UserDTO>
                (entityDTO);
            repository.Save(entity);
        }
    }
}
