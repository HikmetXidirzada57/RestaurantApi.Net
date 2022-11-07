using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO
{
    public class OrderDTO
    {
        public DateTime ModifiedDate { get; set; }
        public int TableId { get; set; }
        public int WaiterId { get; set; }
    }
}
