using Business.Abstract;
using Core.Entity.Models;
using Core.Security.Hasing;
using DataAccess.Abstract;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class AccaountManager : IAccaountService
    {

        private readonly IAccauntDal _accaountDal;
        private readonly HasingHandler _hashingHandler;
        private readonly IUsertoRoleService _usertoRoleManager;
        public AccaountManager(IAccauntDal accaountDal, HasingHandler hashingHandler, IUsertoRoleService usertoRoleManager)
        {
            _accaountDal = accaountDal;
            _hashingHandler = hashingHandler;
            _usertoRoleManager = usertoRoleManager;
        }
        
        public User FindUserByEmail(string email)
        {
            return _accaountDal.Get(x=>x.Email==email);
        }

        public List<User> GetAllUsers()
        {
            return _accaountDal.GetAll();
        }

        public User Login(string email)
        {
            var user=_accaountDal.Get(x=>x.Email == email);
            if (user==null) return null;

            return user;
        }

        public void Register(RegisterDTO registerDTO)
        {
            User user = new()
            {
                Email = registerDTO.Email,
                Password = _hashingHandler.PasswordHash(registerDTO.Password),
                FullName = registerDTO.FullName,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
            };
            _accaountDal.Add(user);
            var currentUser = _accaountDal.Get(x => x.Email == user.Email);
            _usertoRoleManager.AddDefaultRole(currentUser.Id);

        }
    }
}
