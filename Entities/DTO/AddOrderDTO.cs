using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO
{
    public class AddOrderDTO
    {
        public DateTime PurchaseDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public decimal TotalPrice { get; set; }
        public int TableId { get; set; }
        public int WaiterId { get; set; }

        //public virtual List<OrderInfo> OrderItem { get; set; }
    }
}
