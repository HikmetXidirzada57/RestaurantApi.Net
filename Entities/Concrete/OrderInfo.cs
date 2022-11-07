using Core.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class OrderInfo : IEntity
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public string? MealName { get; set; }
        public int MealId { get; set; }
        public int StatusCode { get; set; } 
        public OrderStatus Status { get; }
        public virtual Meal Meal { get; set; }
    }
}
