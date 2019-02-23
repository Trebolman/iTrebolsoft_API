using Application.DTOs;
using Application.IServices;
using Domain;
using Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Application.Services
{
    public class ProductoService : IProductoService
    {
        IProductRepository repository;
        public ProductoService(IProductRepository repository)
        {
            this.repository = repository;
        }
        public void Delete(Guid entityId)
        {
            repository.Delete(entityId);
        }

        public IList<ProductoDTO> GetAll()
        {
            IQueryable<TProducto> ProductEntities = repository.Items;
            return Builders.GenericBuilder.builderListEntityDTO<ProductoDTO, TProducto>(ProductEntities);
        }

        public IList<ProductoDTO> GetProdFromUser(Guid UserId)
        {
            var elementos = repository.Items.Where(x => x.ProdId == UserId);
            return Builders.GenericBuilder.builderListEntityDTO<ProductoDTO, TProducto>(elementos);
        }

        public ProductoDTO GetProduct(Guid entityId)
        {
            var elemento = repository.Items.Where(x => x.ProdId == entityId).FirstOrDefault();
            return Builders.GenericBuilder.builderEntityDTO<ProductoDTO, TProducto>(elemento);
        }

        public Guid Insert(ProductoDTO entityDTO)
        {
            TProducto entity = Builders.
                        GenericBuilder.
                        builderDTOEntity<TProducto, ProductoDTO>
                        (entityDTO);
            return repository.Save(entity);
        }

        public Guid Update(ProductoDTO entityDTO)
        {
            var entity = Builders.
                GenericBuilder.
                builderDTOEntity<TProducto, ProductoDTO>
                (entityDTO);
            return repository.Save(entity);
        }
    }
}
