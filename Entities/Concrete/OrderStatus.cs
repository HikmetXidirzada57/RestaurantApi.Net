using Core.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public  enum OrderStatus
    {
        New=1,
        Processing = 2,
        ItsOver = 3,
        Cancelled=4
    }
}
