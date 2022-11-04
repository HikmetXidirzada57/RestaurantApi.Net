using Core.Concrete.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EFMealCategoryDal : EFEntityRepositoryBase<MealCategory, RestaurantDbContext>, IMealCategoryDal
    {
        public async Task<List<MealCategory>> GetAllCategory()
        {
            using RestaurantDbContext context = new();
            return await context.MealCategories.Where(c=>!c.IsDeleted).ToListAsync();
        }
    }
}
