using Core.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IWaiterDal:IEntityRepository<Waiter>
    {
        Task<List<Waiter>> GetAll();
        Task<Waiter> GetByid(int id);
    }
}
