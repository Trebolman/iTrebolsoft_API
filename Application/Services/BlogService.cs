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

        public void Insert(BlogDTO entityDTO)
        {
            TBlog entity = Builders.
                        GenericBuilder.
                        builderDTOEntity < TBlog, BlogDTO>
                        (entityDTO);
            repository.Save(entity);
        }

        public void Update(BlogDTO entityDTO)
        {
            var entity = Builders.
                GenericBuilder.
                builderDTOEntity<TBlog, BlogDTO>
                (entityDTO);
            repository.Save(entity);
        }
    }
}
