using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTO;

namespace Business.Concrete
{
    public class MealCategoryManager : IMealCategoryService
    {
        private readonly IMealCategoryDal _dal;

        public MealCategoryManager(IMealCategoryDal dal)
        {
            _dal = dal;
        }

        public void Add(MealCategoryDTO mealCategory)
        {
            MealCategory cat = new()
            {
                Name = mealCategory.Name,
                IconUrl = mealCategory.IconUrl,
                IsDeleted = false,
            };
            _dal.Add(cat);
        }

        public void Delete(int id)
        {
            var finCat = _dal.Get(c=>c.Id == id);
            finCat.IsDeleted = true;
            _dal.Update(finCat);
        }

        public async Task<List<MealCategory>> GetAll()
        {
            return await _dal.GetAllCategory();
        }

        public void Update(MealCategory mealCategory)
        {
            _dal.Update(mealCategory);
            
        }
    }
}
