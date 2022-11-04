using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class WaiterManager : IWaiterService
    {

        private readonly IWaiterDal _dal;

        public WaiterManager(IWaiterDal dal)
        {
            _dal = dal;
        }

        public void Add(AddWaiterDTO dto)
        {
            Waiter waiter = new Waiter()
            {
                FullName= dto.FullName,
                Adress= dto.Adress,
                PhoneNumber= dto.PhoneNumber,
                StartDate=DateTime.Now,
                IsDeleted=false
            };
            _dal.Add(waiter);
        }

        public void Delete(int id)
        {
            var waiter=_dal.Get(w=>w.Id==id);
            waiter.IsDeleted=true;
            _dal.Delete(waiter);
        }

        public async Task<List<Waiter>> GetAll()
        {
            return await _dal.GetAll();
        }

        public async Task<Waiter> GetById(int id)
        {
            return await _dal.GetByid(id);
        }

        public void UpdateWaiter(WaiterDTO waiter,int id)
        {
            var currentWaiter = _dal.Get(m => m.Id == id && !m.IsDeleted);
            if (currentWaiter == null)
            {
                currentWaiter.FullName = waiter.FullName;
                currentWaiter.PhoneNumber = waiter.PhoneNumber;
                currentWaiter.Adress = waiter.Adress;
            }
            _dal.Update(currentWaiter);
        }
    }
}
