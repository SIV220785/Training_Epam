using Bank.DAL.Contexts;
using Bank.DAL.DTO;
using Bank.DAL.Repositories.Base;
using System;
using System.Data.Entity;

namespace Bank.DAL.Repositories
{
    public class UserRepository : GenericRepository<User>
    {
        public UserRepository(BankContext db) : base(db)
        {
        }

    }
}
