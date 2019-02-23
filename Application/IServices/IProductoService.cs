using Application.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.IServices
{
    public interface IProductoService
    {
        Guid Insert(ProductoDTO entityDTO);
        IList<ProductoDTO> GetAll();
        Guid Update(ProductoDTO entityDTO);
        void Delete(Guid entityId);
        ProductoDTO GetProduct(Guid entityId);
        IList<ProductoDTO> GetProdFromUser(Guid UserId);
    }
}
