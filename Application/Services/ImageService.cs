using Application.DTOs;
using Application.IServices;
using Domain;
using Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;


namespace Application.Services
{
    public class ImageService : IImageService
    {
        IImageRepository repository;
        public ImageService(IImageRepository repository)
        {
            this.repository = repository;
        }

        public void Delete(Guid entityId)
        {
            repository.Delete(entityId);
        }

        public IList<ImagesDTO> GetAll()
        {
            IQueryable<TImages> Entities = repository.Items;
            return Builders.GenericBuilder.builderListEntityDTO<ImagesDTO, TImages>(Entities);
        }

        public IList<ImagesDTO> GetAllImageFromPublish(Guid entityId)
        {
            var elementos = repository.Items.Where(x => x.FkTBlogPublId == entityId);
            return Builders.GenericBuilder.builderListEntityDTO<ImagesDTO,TImages>(elementos);

        }

        public IList<ImagesDTO> GetAllImagesFromProduct(Guid entityId)
        {
            var elements = repository.Items.Where(x => x.FkTProductoProdId == entityId);
            return Builders.GenericBuilder.builderListEntityDTO<ImagesDTO, TImages>(elements);
        }

        public IList<ImagesDTO> GetAllImagesFromProyect(Guid entityId)
        {
            var elements = repository.Items.Where(x => x.FkTProyProyId == entityId);
            return Builders.GenericBuilder.builderListEntityDTO<ImagesDTO, TImages>(elements);
        }

        public ImagesDTO GetImage(Guid entityId)
        {
            var entities = repository.Items;
            var elemento = repository.Items.Where(x => x.ImageId == entityId).FirstOrDefault();
            return Builders.GenericBuilder.builderEntityDTO<ImagesDTO, TImages>(elemento);
        }

        public Guid Insert(ImagesDTO entityDTO)
        {
            TImages entity = Builders.
                        GenericBuilder.
                        builderDTOEntity<TImages, ImagesDTO>
                        (entityDTO);
            return repository.Save(entity);
        }

        public Guid Update(ImagesDTO entityDTO)
        {
            var entity = Builders.
                GenericBuilder.
                builderDTOEntity<TImages, ImagesDTO>
                (entityDTO);
            return repository.Save(entity);
        }
    }
}
