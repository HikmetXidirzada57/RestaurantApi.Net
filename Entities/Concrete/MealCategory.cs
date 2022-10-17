using Core.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class MealCategory: IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? IconUrl { get; set; };
        public bool IsDeleted { get; set; }
    } 
}
