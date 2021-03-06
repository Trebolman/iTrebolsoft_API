﻿using System;
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
        public IList<ImagesDTO> GetImagesFromPublish(Guid PublId)
        {
            return Service.GetAllImageFromPublish(PublId);
        }

        [HttpGet("GetImagesByProyId/{ProyId}")]
        public IList<ImagesDTO> GetImagesFromProyect(Guid ProyId)
        {
            return Service.GetAllImagesFromProyect(ProyId);
        }

        [HttpGet("GetImagesByProductId/{ProductId}")]
        public IList<ImagesDTO> GetImagesFromProduct(Guid ProductId)
        {
            return Service.GetAllImageFromPublish(ProductId);
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

        [HttpDelete("DeleteImageByProyId/{ProyId}")]
        public IActionResult DeleteImageProy(Guid ProyId)
        {
            var ImagesProy = Service.GetAllImagesFromProyect(ProyId);
            foreach (var Image in ImagesProy)
            {
                Service.Delete(Image.ImageId);
            }
            return Ok(true);
        }

        [HttpDelete("DeleteImageByProdId/{ProdId}")]
        public IActionResult DeleteImageProd(Guid ProdId)
        {
            var ImagesProd = Service.GetAllImagesFromProduct(ProdId);
            foreach (var Image in ImagesProd)
            {
                Service.Delete(Image.ImageId);
            }
            return Ok(true);
        }
    }
}