using Application.DTOs;
using Application.IServices;
using Domain;
using Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public Guid Insert(UserDTO entityDTO)
        {
            TUser entity = Builders.
                        GenericBuilder.
                        builderDTOEntity<TUser, UserDTO>
                        (entityDTO);
            return repository.Save(entity);
        }

        public async Task InsertWithID(UserDTO entityDTO)
        {
            TUser entity = Builders.
                            GenericBuilder.
                            builderDTOEntity<TUser, UserDTO>
                            (entityDTO);
            await repository.SaveWithId(entity);
        }

        public Guid Update(UserDTO entityDTO)
        {
            var entity = Builders.
                GenericBuilder.
                builderDTOEntity<TUser, UserDTO>
                (entityDTO);
            return repository.Save(entity);
        }
    }
}
