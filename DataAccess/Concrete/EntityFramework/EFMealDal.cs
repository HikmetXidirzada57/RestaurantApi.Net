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
        public void Add(Meal entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Meal entity)
        {
            throw new NotImplementedException();
        }

        public Meal Get(Expression<Func<Meal, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Meal> GetAll(Expression<Func<Meal, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public void Update(Meal entity)
        {
            throw new NotImplementedException();
        }
    }
}
