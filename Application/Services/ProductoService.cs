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

        public ProductoDTO GetProduct(Guid entityId)
        {
            var entities = repository.Items;
            var elemento = repository.Items.Where(x => x.ProdId == entityId).FirstOrDefault();
            return Builders.GenericBuilder.builderEntityDTO<ProductoDTO, TProducto>(elemento);
        }

        public void Insert(ProductoDTO entityDTO)
        {
            TProducto entity = Builders.
                        GenericBuilder.
                        builderDTOEntity<TProducto, ProductoDTO>
                        (entityDTO);
            repository.Save(entity);
        }

        public void Update(ProductoDTO entityDTO)
        {
            var entity = Builders.
                GenericBuilder.
                builderDTOEntity<TProducto, ProductoDTO>
                (entityDTO);
            repository.Save(entity);
        }
    }
}
