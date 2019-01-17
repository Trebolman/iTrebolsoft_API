using System;
namespace Application.DTOs
{
    public class ImagesDTO
    {
        public Guid ImageId { get; set; }
        public string ImageName { get; set; }
        public string ImageUrl { get; set; }
        public Guid? FkTProductoProdId { get; set; }
        public Guid? FkTBlogPublId { get; set; }
        public Guid? FkTProyProyId { get; set; }
    }
}
