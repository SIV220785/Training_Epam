using Bank.BLL.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.BLL.Mapper.Interfaces
{
    public interface IAccountService
    {
        public IEnumerable<IAccountInfo> GetAll();

        public void Add(IAccountInfo item);

        public void Update(IAccountInfo item);

        public void Delete(int itemId);

        public void Create(IAccountInfo itemInfo);
    }
}
