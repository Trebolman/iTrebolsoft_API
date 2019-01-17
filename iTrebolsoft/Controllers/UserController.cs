using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTOs;
using Application.IServices;
using Microsoft.AspNetCore.Mvc;

namespace iTrebolsoft.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        IUserService Service;
        public UserController(IUserService service)
        {
            Service = service;
        }

        [HttpGet]
        public IList<UserDTO> Get()
        {
            return Service.GetAll();
        }

        // GET api/<controller>/5
        [HttpGet("{UserId}")]
        public UserDTO Get(Guid UserId)
        {
            return Service.GetAll()
                .Where(u => u.UserId == UserId)
                .FirstOrDefault();
        }

        // POST api/<controller>
        [HttpPost]
        public IActionResult Post([FromBody]UserDTO user)
        {
            Service.Insert(user);
            return Ok(true);
        }

        // PUT api/<controller>/5
        [HttpPut("{UserId}")]
        public IActionResult Put(Guid UserId, [FromBody]UserDTO user)
        {
            user.UserId = UserId;
            Service.Update(user);
            return Ok(true);
        }

        // DELETE api/<controller>/5
        [HttpDelete("{UserId}")]
        public IActionResult Delete(Guid UserId)
        {
            Service.Delete(UserId);
            return Ok(true);
        }
    }
}