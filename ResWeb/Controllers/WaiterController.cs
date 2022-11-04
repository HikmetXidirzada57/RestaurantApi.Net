using Business.Abstract;
using Entities.Concrete;
using Entities.DTO;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ResWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WaiterController : ControllerBase
    {

        private readonly IWaiterService _service;

        public WaiterController(IWaiterService service)
        {
            _service = service;
        }

        // GET: api/<WaiterController>
        [HttpGet]
        public async Task<List<Waiter>> Get()
        {
            return await  _service.GetAll();
        }

        // GET api/<WaiterController>/5
        [HttpGet("{id}")]
        public Task<Waiter> Get(int? id)
        {
            return _service.GetById(id.Value);
        }

        // POST api/<WaiterController>
        [HttpPost]
        public IActionResult Post([FromBody] AddWaiterDTO dto)
        {
            try
            {
                _service.Add(dto);
                return Ok(dto);
            }
            catch (Exception e)
            {
                return Ok(new { status = 400, message = e.Message });
            }
        }

        // PUT api/<WaiterController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] WaiterDTO waiter)
        {
            if (id == null)
            {
                return NotFound();
            }
            try
            {
                _service.UpdateWaiter(waiter, id);
                return Ok(new { status = 200, message = "updated" });
            }
            catch (Exception)
            {
                return Ok(new { status =403,message = "something went wrong!" });

            }
          
        }

        // DELETE api/<WaiterController>/5b
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _service.Delete(id);
            return Ok(new { status = 200, message = "deleted" });
        }
    }
}
