using Entities.Concrete;
using Entities.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IMealCategoryService
    {
        Task<List<MealCategory>> GetAll();
        void Add(MealCategoryDTO mealCategory);
        void Update(MealCategory mealCategory); 
        void Delete(int id); 
    }
}
