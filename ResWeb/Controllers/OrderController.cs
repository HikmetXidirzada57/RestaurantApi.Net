using AutoMapper;
using Business.Abstract;
using Entities.Concrete;
using Entities.DTO;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ResWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {

        private readonly IOrderService _orderServices;
        private readonly IMapper _mapper;

        public OrderController(IOrderService orderServices, IMapper mapper)
        {
            _orderServices = orderServices;
            _mapper = mapper;
        }

        // GET: api/<OrderController>


        [HttpGet]
        public async Task<List<Order>> GetAllOrders()
        {
            return await _orderServices.GetAllOrders();
        }


        [HttpGet("byWaiter/{id}")]
        public async Task<List<Order>> GetAllOrdersByWaiter(int waiterId)
        {
            return await _orderServices.GetAllOrdersByWaiter(waiterId);
        }


        [HttpGet("byTable/{id}")]
        public async Task<List<Order>> GetAllOrdersByTable(int tableId)
        {
            return await _orderServices.GetAllOrdersByTable(tableId);
        }

        // POST api/<OrderController>
        [HttpPost]
        public IActionResult Post([FromBody] AddOrderDTO value)
        {
            try
            {
                _orderServices.Add(value);
                return Ok(new { status = 200, message = "order createdsuccesfully" });
            }
            catch (Exception)
            {
                return BadRequest(new { status = 403, message = "some error happened" });
            }
        }

        // PUT api/<OrderController>/5
        [HttpPut("updateOrder/{orderId}")]
        public IActionResult Put(int orderId)
        {
            var order = _orderServices.GetById(orderId);
            _orderServices.UpdateOrder(order);

            return Ok(new { statis = 200, message = "order updated" });
        }

        // DELETE api/<OrderController>/5
        [HttpDelete("{id}")]
        public JsonResult Delete(Order order)
        {
            JsonResult res = new(new{ });

            try
            {
                _orderServices.Delete(order);
                res.Value = new { status = 200, message = "order deleted" };
            }
            catch (Exception e)
            {
                res.Value = new { status = 400, message = e.Message };
                throw;
            }
            return res;
        }
    }
}
