using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO
{
    public class MealDTO
    {
        public string Name { get; set; } = null!;
        public string PhotoUrl { get; set; } = null!;
        public string? Description { get; set; }
        public decimal Price { get; set; }
        //public bool IsDeleted { get; set; }
        public int MealCategoryId { get; set; }
        //public virtual MealCategory MealCategory { get; set; }
    }
}
