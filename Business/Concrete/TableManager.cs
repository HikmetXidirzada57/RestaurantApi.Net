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
    public class TableManager : ITableService
    {
      private readonly  ITableDal _dal;

        public TableManager(ITableDal dal)
        {
            _dal = dal;
        }

        public void Add(TableDTO dto)
        {
            Table table = new()
            {
                Name = dto.Name,
                IsDeleted=false
            };
            _dal.Add(table);
        }

        public void Delete(int id)
        {
            var currentTable = _dal.Get(t=>t.Id==id);
            currentTable.IsDeleted = true;
            _dal.Delete(currentTable);
        }

        public List<Table> GetAll()
        {
           return  _dal.GetAll();
        }

        public void Update(Table dto)
        {
           _dal.Update(dto);
        }
    }
}
