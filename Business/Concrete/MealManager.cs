using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class MealManager : IMealService
    {

        private readonly IMealDal _dal;

        public MealManager(IMealDal dal)
        {
            _dal = dal;
        }

        public void AddMeal(MealDTO meal)
        {
            Meal menu = new()
            {
                Name = meal.Name,
                Description=meal.Description,
                PhotoUrl = meal.PhotoUrl,
                MealCategoryId= meal.MealCategoryId,
                Price = meal.Price,
                IsDeleted=false
            };
            _dal.Add(menu);
        }

        public  void Delete(int  id)
        {
            var meal =  _dal.Get(m => m.Id == id && !m.IsDeleted);
            if (meal != null)
            {
                meal.IsDeleted = true;
                _dal.Delete(meal);
            }
        }

        public async Task<List<Meal>> GetAllMenu()
        {
            return await _dal.GetAllMenu();
        }

        public async Task<List<Meal>> GetByCategory(int categoryId)
        {
            return await _dal.GetMealByCategory(categoryId);
        }

        public async Task<Meal> GetById(int id)
        {
           return await _dal.GetById(id);
        }

        public void UpdateMeal(MealDTO meal,int id)
        {
            var currentMeal =_dal.Get(m=>m.Id==id && !m.IsDeleted);
            if (currentMeal == null)
            {
                currentMeal.Name = meal.Name;
                currentMeal.Price = meal.Price;
                currentMeal.Description = meal.Description;
                currentMeal.Price = meal.Price;
                currentMeal.MealCategoryId = meal.MealCategoryId;

            }
            _dal.Update(currentMeal);
        }
    }
}
