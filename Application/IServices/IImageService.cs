using Application.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.IServices
{
    public interface IImageService
    {
        Guid Insert(ImagesDTO entityDTO);
        IList<ImagesDTO> GetAll();
        IList<ImagesDTO> GetAllImageFromPublish(Guid entityId);
        Guid Update(ImagesDTO entityDTO);
        void Delete(Guid entityId);
        ImagesDTO GetImage(Guid entityId);
    }
}
