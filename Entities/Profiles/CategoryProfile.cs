using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Entities.Concrete;
using Entities.DTO;

namespace Entities.Profiles
{
    public class CategoryProfile:Profile
    {
        public CategoryProfile()
        {
            CreateMap<MealCategoryDTO ,MealCategory> ();
        }
    }
}
