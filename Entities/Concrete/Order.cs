using Core.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Order : IEntity
    {
        public int Id { get; set; }
        public DateTime PurchaseDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public decimal TotalPrice { get; set; }
        public int TableId { get; set; }
        public virtual Table Table { get; set; } 
        public bool IsNew { get; set; }
        public bool IsPrepeared { get; set; }
        public bool IsItsOver { get; set; }
    

    }
}
