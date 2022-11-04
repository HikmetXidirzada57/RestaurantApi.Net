using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO
{
    public class MealCategoryDTO
    {
        public string Name { get; set; } = null!;
        public string? IconUrl { get; set; }
        //public bool IsDeleted { get; set; }
    }
}
