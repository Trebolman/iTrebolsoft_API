using Application.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.IServices
{
    public interface IProductoService
    {
        void Insert(ProductoDTO entityDTO);
        IList<ProductoDTO> GetAll();
        void Update(ProductoDTO entityDTO);
        void Delete(Guid entityId);
        ProductoDTO GetProduct(Guid entityId);
    }
}
