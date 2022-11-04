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
    public class EFMealDal : EFEntityRepositoryBase<Meal, RestaurantDbContext>, IMealDal
    {
        public async Task<List<Meal>> GetAllMenu()
        {
            using RestaurantDbContext context= new();
            return await context.Meals.Where(m => !m.IsDeleted).Include(m => m.MealCategory).ToListAsync();
        }

        public async Task<Meal> GetById(int id)
        {
            using RestaurantDbContext context= new();
            return await context.Meals.Where(m => !m.IsDeleted).Include(m => m.MealCategory).FirstOrDefaultAsync(m=>m.Id==id);
        }

        public async Task<List<Meal>> GetMealByCategory(int categoryId)
        {
            using RestaurantDbContext context = new();
            return await context.Meals.Where(m => !m.IsDeleted && m.MealCategoryId == categoryId).Include(m => m.MealCategory).ToListAsync();
        }

        public async Task<Meal> AddMeal(Meal meal)
        {
            using RestaurantDbContext context = new();
            var addedMeal = await context.Meals.AddAsync(meal);
            await context.SaveChangesAsync();

            return addedMeal.Entity;
        }
    }
}
