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
        public  List<Order> GetAllOrders()
        {
            return  _orderServices.GetAllOrders();
        }


        [HttpGet("{waiterId}")]
        public async Task<List<Order>> GetAllOrdersByWaiter(int waiterId)
        {
            return await _orderServices.GetAllOrdersByWaiter(waiterId);
        }


        [HttpGet("{tableId}")]
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
                return Ok(new { status = 200, message = "order created succesfully" });
            }
            catch (Exception e)
            {
                return BadRequest(new { status = 403, message = e.Message });
            }
        }

        // PUT api/<OrderController>/5
        [HttpPut("update/{id}")]
        public  IActionResult Update(int? id, OrderDTO  order)
        {
            if (id == null) return NotFound();
            try
            {
                var mappedOrder = _mapper.Map<Order>(order);
                _orderServices.UpdateOrder(id.Value,mappedOrder);
                return Ok(new { statis = 200, message = "order updated" });

            }
            catch (Exception e)
            {
                return BadRequest(new { status = 400, message = e.Message });
            }
          

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
