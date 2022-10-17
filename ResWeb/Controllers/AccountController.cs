using Business.Abstract;
using Core.Entity.Models;
using Core.Security.Hasing;
using Core.Security.TokenHandler;
using Entities.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using System.IdentityModel.Tokens.Jwt;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ResWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccaountService _service;
        private readonly IRoleService _roleService;
        private readonly TokenGenerator _tokenGenerator;
        private readonly HasingHandler _hasingHandler;

        public AccountController(IAccaountService service, TokenGenerator tokenGenerator, HasingHandler hasingHandler, IRoleService roleService)
        {
            _service = service;
            _tokenGenerator = tokenGenerator;
            _hasingHandler = hasingHandler;
            _roleService = roleService;
        }

        // GET: api/<AccountController>
        [HttpGet("getAllUsers")]
        public  List<User> GetAll()
        {
            return  _service.GetAllUsers();
        }

        [Authorize]
        [HttpGet("getUserByEmail")]
        public async Task<IActionResult> GetByEmail()
        {
            var _bearer_token = Request.Headers[HeaderNames.Authorization].ToString().Replace("Bearer ", "");
            var handler = new JwtSecurityTokenHandler();
            var jwtSecurityTeam = handler.ReadJwtToken(_bearer_token);
            var email = jwtSecurityTeam.Claims.FirstOrDefault(x => x.Type == "email").Value;

            var user=_service.FindUserByEmail(email);
            var res = new UserDTO(user.Id, user.FullName, user.Password);
            return Ok(res);
        }
        // GET api/<AccountController>/5


        // POST api/<AccountController>
        [HttpPost("registerUser")]
        public async Task<IActionResult>Register([FromBody] RegisterDTO value)
        {
            var user =_service.FindUserByEmail(value.Email);
            if (user != null)
            {
                return Ok(new { status = 201, message = "Email already exist" });
            }
            var password=value.Password;
            if (password != null && password.Length >= 5)
            {
                _service.Register(value);
                return Ok(new { status = 200, message = "user registered" });
            }

            return Ok(new { status = "The length of the password should not be less than 5" });
        }

        // PUT api/<AccountController>/5
        [HttpPut("login")]
        public  async Task<IActionResult> Login([FromBody] LoginDTO value)
        {
            var user = _service.Login(value.Email);

            if (user == null)
            {
                return Unauthorized();

            }
           
            if (user.Email==value.Email && user.Password==_hasingHandler.PasswordHash(value.Password))
            {
                var role = _roleService.GetRole(user.Id);
                var result = new UserDTO(user.Id, user.FullName, user.Email);
                result.Token = _tokenGenerator.Token(user, role.Name);
                return Ok(new { status = 200, message = result });
            }

            return Ok(new { status = 404, message = "email or password is incorrect!" });

        }

        // DELETE api/<AccountController>/5


        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
