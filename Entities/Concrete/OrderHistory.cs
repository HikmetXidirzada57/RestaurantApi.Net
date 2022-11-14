using Core.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class OrderHistory:IEntity
    {
        public int Id { get; set; } 
        public int OrderId { get; set; } 
        public int OrderStatus { get; set; }
        public string? Note { get; set; }
    }  
}
