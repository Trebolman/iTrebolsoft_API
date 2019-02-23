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
    public class BlogService : IBlogService
    {
        IBlogRepository repository;
        public BlogService(IBlogRepository repo)
        {
            repository = repo;
        }
        public void Delete(Guid entityId)
        {
            repository.Delete(entityId);
        }

        public IList<BlogDTO> GetAll()
        {
            IQueryable<TBlog> BlogsEntities = repository.Items;

            return Builders.
                   GenericBuilder.
                   builderListEntityDTO<BlogDTO, TBlog>
                   (BlogsEntities);
        }

        public BlogDTO GetBlog(Guid entityId)
        {
            var elemento = repository.Items.Where(x => x.PublId == entityId).FirstOrDefault();
            return Builders.GenericBuilder.builderEntityDTO<BlogDTO, TBlog>(elemento);
        }

        public IList<BlogDTO> GetBlogFromUser(Guid UserId)
        {
            var elementos = repository.Items.Where(x => x.FkTUserUserId == UserId);
            return Builders.GenericBuilder.builderListEntityDTO<BlogDTO, TBlog>(elementos);
        }

        public Guid Insert(BlogDTO entityDTO)
        {
            TBlog entity = Builders.
                        GenericBuilder.
                        builderDTOEntity<TBlog, BlogDTO>
                        (entityDTO);
            return repository.Save(entity);
        }

        public Guid Update(BlogDTO entityDTO)
        {
            var entity = Builders.
                GenericBuilder.
                builderDTOEntity<TBlog, BlogDTO>
                (entityDTO);
            return repository.Save(entity);
        }
    }
}
