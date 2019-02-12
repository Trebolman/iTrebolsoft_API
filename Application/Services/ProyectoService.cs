using Application.DTOs;
using Application.IServices;
using Domain;
using Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Application.Services
{
    public class ProyectoService : IProyectoService
    {
        IProyectoRepository repository;
        public ProyectoService(IProyectoRepository repository)
        {
            this.repository = repository;
        }
        public void Delete(Guid entityId)
        {
            repository.Delete(entityId);
        }

        public IList<ProyectoDTO> GetAll()
        {
            IQueryable<TProyectos> ProductEntities = repository.Items;
            return Builders.GenericBuilder.builderListEntityDTO<ProyectoDTO, TProyectos>(ProductEntities);
        }

        public ProyectoDTO GetProyecto(Guid entityId)
        {
            var entities = repository.Items;
            var elemento = repository.Items.Where(x => x.ProyId == entityId).FirstOrDefault();
            return Builders.GenericBuilder.builderEntityDTO<ProyectoDTO, TProyectos>(elemento);
        }

        public Guid Insert(ProyectoDTO entityDTO)
        {
            TProyectos entity = Builders.
                        GenericBuilder.
                        builderDTOEntity<TProyectos, ProyectoDTO>
                        (entityDTO);
            return repository.Save(entity);
        }

        public Guid Update(ProyectoDTO entityDTO)
        {
            var entity = Builders.
                GenericBuilder.
                builderDTOEntity<TProyectos, ProyectoDTO>
                (entityDTO);
            return repository.Save(entity);
        }
    }
}
