using Core.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Meal:IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string PhotoUrl { get; set; } = null!;
        public decimal Price { get; set; }
        public decimal  Discount { get; set; }
        public bool IsDeleted { get; set; }
        public int MealCategoryId { get; set; }
        public virtual MealCategory MealCategory { get; set; } 

    }
}
