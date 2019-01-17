using Application.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.IServices
{
    public interface IBlogService
    {
        void Insert(BlogDTO entityDTO);
        IList<BlogDTO> GetAll();
        void Update(BlogDTO entityDTO);
        void Delete(Guid entityId);
    }
}
