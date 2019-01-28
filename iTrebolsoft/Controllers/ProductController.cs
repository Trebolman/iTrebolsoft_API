using System;
using System.Collections.Generic;
using System.Linq;
using Application.DTOs;
using Application.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace iTrebolsoft.Controllers
{
    [Route("api/[controller]")]
    //[Authorize]
    public class ProductController : Controller
    {
        IProductoService Service;
        public ProductController(IProductoService service)
        {
            Service = service;
        }

        [HttpGet]
        public IList<ProductoDTO> Get()
        {
            return Service.GetAll();
        }

        // GET api/<controller>/5
        [HttpGet("{ProdId}")]
        public ProductoDTO Get(Guid ProdId)
        {
            return Service.GetAll()
                .Where(x => x.ProdId == ProdId)
                .FirstOrDefault();
        }

        // POST api/<controller>
        [HttpPost]
        public IActionResult Post([FromBody] ProductoDTO producto)
        {
            Service.Insert(producto);
            return Ok(true);
        }

        // PUT api/<controller>/5
        [HttpPut("{ProdId}")]
        public IActionResult Put(Guid ProdId, [FromBody] ProductoDTO producto)
        {
            producto.ProdId = ProdId;
            Service.Update(producto);
            return Ok(true);
        }

        // DELETE api/<controller>/5
        [HttpDelete("{ProdId}")]
        public IActionResult Delete(Guid ProdId)
        {
            Service.Delete(ProdId);
            return Ok(true);
        }
    }
}