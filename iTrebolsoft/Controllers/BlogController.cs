using System;
using System.Collections.Generic;
using System.Linq;
using Application.DTOs;
using Application.IServices;
using Microsoft.AspNetCore.Mvc;

namespace iTrebolsoft.Controllers
{
    [Route("api/[controller]")]
    public class BlogController : Controller
    {
        IBlogService Service;
        public BlogController(IBlogService service)
        {
            Service = service;
        }

        [HttpGet]
        public IList<BlogDTO> Get()
        {
            return Service.GetAll();
        }

        // GET api/<controller>/5
        [HttpGet("{PublId}")]
        public BlogDTO Get(Guid PublId)
        {
            return Service.GetAll()
                .Where(b => b.PublId == PublId)
                .FirstOrDefault();
        }

        // POST api/<controller>
        [HttpPost]
        public IActionResult Post([FromBody]BlogDTO publ)
        {
            Service.Insert(publ);
            return Ok(true);
        }

        // PUT api/<controller>/5
        [HttpPut("{PublId}")]
        public IActionResult Put(Guid PublId, [FromBody]BlogDTO Publ)
        {
            Publ.PublId = PublId;
            Service.Update(Publ);
            return Ok(true);
        }

        // DELETE api/<controller>/5
        [HttpDelete("{PublId}")]
        public IActionResult Delete(Guid PublId)
        {
            Service.Delete(PublId);
            return Ok(true);
        }
    }
}