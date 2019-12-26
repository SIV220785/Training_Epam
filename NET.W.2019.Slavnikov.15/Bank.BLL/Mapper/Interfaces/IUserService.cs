using Bank.BLL.Entities.Base;
using System.Collections.Generic;

namespace Bank.BLL.Mapper.Interfaces
{
    public interface IUserService
    {
        public IEnumerable<IUserInfo> GetAll();
        public void Add(IUserInfo item);
        public void Update(IUserInfo item);
        public void Delete(int itemId);
        public void Create(IUserInfo itemInfo);
    }
}
