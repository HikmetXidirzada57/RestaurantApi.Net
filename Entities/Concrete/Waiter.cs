using Core.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Waiter: IEntity
    {
        public int Id { get; set; }
        public string FullName { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string Adress { get; set; } = null!;
        public DateTime StartDate { get; set; }
        public bool IsDeleted { get; set; }

    }
}
