using Business.Abstract;
using Entities.Concrete;
using Entities.DTO;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ResWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TableController : ControllerBase
    {
       private readonly ITableService _service;

        public TableController(ITableService service)
        {
            _service = service;
        }

        // GET: api/<TableController>
        [HttpGet]
        public List<Table> GetAll()
        {
            return _service.GetAll();
        }

        // GET api/<TableController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<TableController>
        [HttpPost]
        public IActionResult Post([FromBody] TableDTO value)
        {
             _service.Add(value);
            return Ok(new { status = 200, message = value + "succesfully added" });
        }

        // PUT api/<TableController>/5
        [HttpPut("{id}")]
        public IActionResult Put([FromBody] Table value)
        {
            try
            {
                _service.Update(value);
                return Ok(new { status = 200, mesaaege = "updated" });
            }
            catch (Exception e)
            {
                 return BadRequest(new {status=403,message=e.Message}); 
            }
        }

        // DELETE api/<TableController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _service.Delete(id);
            return Ok();
        }
    }
}
