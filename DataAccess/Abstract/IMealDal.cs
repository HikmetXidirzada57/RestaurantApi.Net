using Core.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IMealDal : IEntityRepository<Meal>
    {
        Task<List<Meal>> GetMealByCategory(int categoryId);
        Task<List<Meal>> GetAllMenu();
        Task<Meal> GetById(int id);
        Task<Meal> AddMeal(Meal meal);
        //void Update(Meal meal,int id);
    }
}
