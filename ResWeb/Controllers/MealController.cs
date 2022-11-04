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
    public class MealController : ControllerBase
    {
        private readonly IMealService _service;
        public MealController(IMealService service)
        {
            _service = service;
            //_mapper = mapper;
        }

        // GET: api/<MealController>
        [HttpGet]
        public async Task<List<Meal>> GetAll()
        {
            return await _service.GetAllMenu();
        }

        [HttpGet("getByCategory/{id}")]
        public async Task<List<Meal>> GetListByCategory(int categoryId)
        {
            return await _service.GetByCategory(categoryId);
        }

        // GET api/<MealController>/5
        [HttpGet("{id}")]
        public async Task<Meal> Get(int id)
        {
            return await _service.GetById(id);
        }

        // POST api/<MealController>
        [HttpPost]
        public JsonResult Post([FromBody] MealDTO dto)
        {
            JsonResult res = new(new { });
            try
            {
                _service.AddMeal(dto);
                res.Value = new { status = 200, success = dto.Name + " added successfully!" };

            }
            catch (Exception ex)
            {
                res.Value = new { status = 400, message = ex.Message };
            }

            return res;
        }

        // PUT api/<MealController>/5
        [HttpPut("update/{id}")]
        public async Task<IActionResult> Update(MealDTO value, int id)
        {
            _service.UpdateMeal(value, id);

            return Ok(new {status=200,mesaage= "updated" });
        }

        //// DELETE api/<MealController>/5
        [HttpDelete("{id}")]
        public JsonResult Delete(int? id)
        {
            JsonResult res = new(new { });

            if (!id.HasValue)
            {
                res.Value = new { status = 404 };
                return res;
            }
            try
            {
                _service.Delete(id.Value);
                res.Value = new { status = 200, message = "menu deleted" };
            }
            catch (Exception e)
            {
                res.Value = new { status = 403, message = e.Message };
                throw;
            }
            return res;
        }
    }
}
