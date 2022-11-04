using Entities.Concrete;
using Entities.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IMealService
    {
        Task<List<Meal>> GetAllMenu();
        Task<List<Meal>> GetByCategory(int categoryId);
        Task<Meal> GetById(int id);
        void AddMeal(MealDTO meal);
        void UpdateMeal(MealDTO meal,int id);
        void Delete( int  id);
    }
}
