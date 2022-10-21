using Core.Concrete.EntityFramework;
using Core.Entity.Models;
using DataAccess.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EFRoleDal : EFEntityRepositoryBase<Role, RestaurantDbContext>, IRoleDal
    {
        public Role GetUserRole(int userId)
        {
            using RestaurantDbContext context = new();

            var roletoUser = context.UsertoRoles.Include(x => x.Role).FirstOrDefault(x => x.UserId == userId);

            var role = new Role()
            {
                Id = roletoUser.RoleId,
                Name = roletoUser.Role.Name
            };

            return role;
        }
    }
}
