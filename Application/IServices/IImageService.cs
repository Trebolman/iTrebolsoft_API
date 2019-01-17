using Application.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.IServices
{
    public interface IImageService
    {
        void Insert(ImagesDTO entityDTO);
        IList<ImagesDTO> GetAll();
        void Update(ImagesDTO entityDTO);
        void Delete(Guid entityId);
        ImagesDTO GetImage(Guid entityId);
    }
}
