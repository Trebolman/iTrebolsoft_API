using System;
using System.Collections.Generic;
using System.Linq;
using Application.DTOs;
using Application.IServices;
using Microsoft.AspNetCore.Mvc;

namespace iTrebolsoft.Controllers
{
    [Route("api/[controller]")]
    public class ImageController : Controller
    {
         IImageService Service;
        public ImageController(IImageService service)
        {
            Service = service;
        }

        [HttpGet]
        public IList<ImagesDTO> Get()
        {
            return Service.GetAll();
        }

        // GET api/<controller>/5
        [HttpGet("{ImageId}")]
        public ImagesDTO Get(Guid ImageId)
        {
            return Service.GetAll()
                .Where(x => x.ImageId == ImageId)
                .FirstOrDefault();
        }

        // POST api/<controller>
        [HttpPost]
        public IActionResult Post([FromBody] ImagesDTO image)
        {
            Service.Insert(image);
            return Ok(true);
        }

        // PUT api/<controller>/5
        [HttpPut("{ImageId}")]
        public IActionResult Put(Guid ImageId, [FromBody] ImagesDTO image)
        {
            image.ImageId = ImageId;
            Service.Update(image);
            return Ok(true);
        }

        // DELETE api/<controller>/5
        [HttpDelete("{ImageId}")]
        public IActionResult Delete(Guid ImageId)
        {
            Service.Delete(ImageId);
            return Ok(true);
        }
    }
}