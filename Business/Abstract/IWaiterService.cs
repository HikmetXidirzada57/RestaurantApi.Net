using Entities.Concrete;
using Entities.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IWaiterService
    {
        void Add(AddWaiterDTO dto);
        void UpdateWaiter(WaiterDTO waiter,int id);
        void Delete(int  id);
        Task<List<Waiter>> GetAll();
        Task<Waiter> GetById(int id); 
    }
}
