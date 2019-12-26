using Bank.DAL.DTO;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.DAL.Contexts
{
    public class BankContext : DbContext
    {
        public BankContext() : base("BankConnectionString")
        {
        }

        static BankContext()
        {
            Database.SetInitializer<BankContext>(new BankContextInitializer());
        }
        public virtual void Save()
        {
            base.SaveChanges();
        }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
