using Business.Abstract;
using Core.Entity.Models;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UserRoleManager : IUsertoRoleService
    {
        private readonly IUsertoRoleDal _userRoleDal;

        public UserRoleManager(IUsertoRoleDal userRoleDal)
        {
            _userRoleDal = userRoleDal;
        }

        public void AddDefaultRole(int userId)
        {
            UsertoRole userRole = new UsertoRole()
            {
                RoleId = 2,
                UserId = userId
            };
            _userRoleDal.Add(userRole);
        }
    }
}
