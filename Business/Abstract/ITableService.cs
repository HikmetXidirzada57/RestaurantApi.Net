using Entities.Concrete;
using Entities.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ITableService
    {
        void Add(TableDTO dto);
        void Update(Table dto);
        void Delete(int id);
        List<Table> GetAll();
         
    }
}
