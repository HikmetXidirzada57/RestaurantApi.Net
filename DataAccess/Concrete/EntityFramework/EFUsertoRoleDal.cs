using Core.Concrete.EntityFramework;
using Core.Entity.Models;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EFUsertoRoleDal : EFEntityRepositoryBase<UsertoRole, RestaurantDbContext>, IUsertoRoleDal
    {
    }
}
