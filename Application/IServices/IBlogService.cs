using Application.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.IServices
{
    public interface IBlogService
    {
        Guid Insert(BlogDTO entityDTO);
        IList<BlogDTO> GetAll();
        Guid Update(BlogDTO entityDTO);
        void Delete(Guid entityId);
        BlogDTO GetBlog(Guid entityId);
    }
}
