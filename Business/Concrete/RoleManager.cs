using Business.Abstract;
using Core.Entity.Models;
using DataAccess.Abstract;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class RoleManager : IRoleService
    {
        private readonly IRoleDal _rolDal;

        public RoleManager(IRoleDal rolDal)
        {
            _rolDal = rolDal;
        }

        public void AddRole(RoleDTO addRoleDTO)
        {
            Role rol = new Role()
            {
                Name = addRoleDTO.Name,
            };
            _rolDal.Add(rol);
        }

        public List<Role> GetAllRoles()
        {
            return _rolDal.GetAll();
        }

        public Role GetRole(int id)
        {
            return _rolDal.Get(x => x.Id == id);
        }

        public Role GetRolebyUserId(int userId)
        {
            return _rolDal.GetUserRole(userId);
        }

        //public Role GetRolebyUserId(int userId)
        //{
        //    return _rolDal.Get(userId);
        //}

        public void Remove(Role role)
        {
           _rolDal.Delete(role);
        }

        public void Update(Role role)
        { 
            _rolDal.Update(role);
        }
    }
}
