using Core.Concrete.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EFMealDal : EFEntityRepositoryBase<Meal, RestaurantDbContext>, IMealDal
    {
        public  Task<Meal> GetMealByCategory(int categoryId)
        {
            throw new NotImplementedException();
        }
    }
}
