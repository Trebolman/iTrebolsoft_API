using System;
using System.Collections.Generic;
using System.Linq;
using Application.DTOs;
using Application.IServices;
using Microsoft.AspNetCore.Mvc;

namespace iTrebolsoft.Controllers
{
    [Route("api/")]
    public class ImageController : Controller
    {
        IImageService Service;
        public ImageController(IImageService service)
        {
            Service = service;
        }

        [HttpGet("GetImages")]
        public IList<ImagesDTO> Get()
        {
            return Service.GetAll();
        }

        [HttpGet("GetImagesByPublId/{PublId}")]
        public IList<ImagesDTO> Post(Guid PublId)
        {
            return Service.GetAllImageFromPublish(PublId);
        }

        // GET api/<controller>/5
        [HttpGet("GetImageById/{ImageId}")]
        public ImagesDTO Get(Guid ImageId)
        {
            return Service.GetAll()
                .Where(x => x.ImageId == ImageId)
                .FirstOrDefault();
        }

        // POST api/<controller>
        [HttpPost("CreateImage")]
        public Guid Post([FromBody] ImagesDTO image)
        {
            return Service.Insert(image);
            //return Ok(true);
        }

        // PUT api/<controller>/5
        [HttpPut("UploadImageById/{ImageId}")]
        public IActionResult Put(Guid ImageId, [FromBody] ImagesDTO image)
        {
            image.ImageId = ImageId;
            Service.Update(image);
            return Ok(true);
        }

        // DELETE api/<controller>/5
        [HttpDelete("DeleteImageById/{ImageId}")]
        public IActionResult Delete(Guid ImageId)
        {
            Service.Delete(ImageId);
            return Ok(true);
        }

        [HttpDelete("DeleteImageByPublId/{PublId}")]
        public IActionResult DeleteImagePubl (Guid PublId)
        {
            var ImagesPubl = Service.GetAllImageFromPublish(PublId);
            foreach (var Image in ImagesPubl)
            {
                Service.Delete(Image.ImageId);
            }
            return Ok(true);
        }
    }
}