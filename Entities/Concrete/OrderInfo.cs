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
        public int MealId { get; set; } 
        public int WaiterId { get; set; }
        public int OrderId { get; set; } 
        public int OrderStatus { get; set; } 
        public virtual Meal Meal { get; set; }
        public virtual Waiter Waiter { get; set; }
        public virtual Order Order { get; set; }
    }
}
