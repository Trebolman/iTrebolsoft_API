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
    public class ProyectController : Controller
    {
        IProyectoService Service;
        public ProyectController(IProyectoService service)
        {
            Service = service;
        }

        [HttpGet]
        [Authorize]
        public IList<ProyectoDTO> Get()
        {
            return Service.GetAll();
        }

        // GET api/<controller>/5
        [HttpGet("{ProyId}")]
        public ProyectoDTO Get(Guid ProyId)
        {
            return Service.GetAll()
                .Where(x => x.ProyId == ProyId)
                .FirstOrDefault();
        }

        // POST api/<controller>
        [HttpPost]
        public IActionResult Post([FromBody] ProyectoDTO proyecto)
        {
            Service.Insert(proyecto);
            return Ok(true);
        }

        // PUT api/<controller>/5
        [HttpPut("{ProyId}")]
        public IActionResult Put(Guid ProyId, [FromBody] ProyectoDTO proyecto)
        {
            proyecto.ProyId = ProyId;
            Service.Update(proyecto);
            return Ok(true);
        }

        // DELETE api/<controller>/5
        [HttpDelete("{ProyId}")]
        public IActionResult Delete(Guid ProyId)
        {
            Service.Delete(ProyId);
            return Ok(true);
        }
    }
}