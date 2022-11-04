using Business.Abstract;
using Core.Entity.Models;
using Entities.DTOs;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ResWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {

        private readonly IRoleService _rolService;

        public RoleController(IRoleService rolService)
        {
            _rolService = rolService;
        }

        // GET: api/<RoleController>
        [HttpGet("getAllRoles")]
        public IActionResult GetAll()
        {
            var rols=_rolService.GetAllRoles();
            if (rols==null)
            {
                return Ok(new { status = 404, message = "There isn't any role" });
            }

            return Ok(new {status=200,message=rols});
        }

        // GET api/<RoleController>/5
        [HttpGet("get/{id}")]
        public IActionResult Get(int id)
        {
            var rol = _rolService.GetRole(id);

            return Ok(new { status = 200, message = rol });
        }

        // POST api/<RoleController>
        [HttpPost("add")]
        public IActionResult Post([FromBody] RoleDTO dto)
        {
            try
            {
                _rolService.AddRole(dto);
            }
            catch (Exception e)
            {
                return Ok(new { status = 400, message = e });
            }
            return Ok(new {status=200,message=dto});
        }

        // PUT api/<RoleController>/5
        [HttpPut("{id}")]
        public IActionResult Put([FromBody] Role value)
        {
            _rolService.Update(value);
            return Ok(new {status=200,message=value});
        }

        // DELETE api/<RoleController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(Role value)
        {
            _rolService.Remove(value);
            return Ok(new { status = 200, message = "Role deleted (:" });
        }
    }
}
