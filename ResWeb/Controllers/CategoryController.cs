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
    public class CategoryController : ControllerBase
    {

        private readonly IMealCategoryService _service;
        private readonly IMapper _mapper;
        public CategoryController(IMealCategoryService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        // GET: api/<CategoryController>
        [HttpGet]
        public async Task<List<MealCategory>> GetAll()
        {
            return await _service.GetAll();
        }

        // GET api/<CategoryController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/<CategoryController>
        [HttpPost("Add")]
        public JsonResult Post([FromBody] MealCategoryDTO dto)
        {
            JsonResult res = new(new { });

            try
            {
                var mapperCat = _mapper.Map<MealCategoryDTO>(dto);
                _service.Add(mapperCat);
                res.Value = new { status = 200, message = dto.Name + " succesfully added :)" };
            }
            catch (Exception e)
            {
                res.Value = new { status = 403, message = e.Message };
            }
            return res;
        }

        // PUT api/<CategoryController>/5
        [HttpPut("{id}")]
        public async Task<JsonResult> UpdateCategory(int? id,MealCategoryDTO category)
        {
            JsonResult res = new(new { });
            if (!id.HasValue)
            {
                res.Value = new { status = 404, message = "category  was not found !!!" };
                return res;
            }

            var categoryMapper = _mapper.Map<MealCategory>(category);

            _service.Update(categoryMapper);
            res.Value = new { category };
            return res;
        }

        // DELETE api/<CategoryController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _service.Delete(id);
            return Ok(new { status = 200, message = "deleted" });
        }
    }
}
