using Bank.DAL.Contexts;
using Bank.DAL.DTO;
using Bank.DAL.Repositories.Base;
using System.Data.Entity;

namespace Bank.DAL.Repositories
{
    public class AccountRepository: GenericRepository<Account>
    {
        public AccountRepository(BankContext db): base(db)
        {
        }
    }
}
