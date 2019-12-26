using Bank.DAL.DTO;
using System.Collections.Generic;
using System.Data.Entity;

namespace Bank.DAL.Contexts
{
    public class BankContextInitializer : DropCreateDatabaseAlways<BankContext>
    {
        protected override void Seed(BankContext context)
        {

            base.Seed(context);
            User user = new User()
            {
                FirstName = "Igor",
                LastName = "Slavnikov",
            };

            Account baseAccount = new Account()
            {
                Id = "!2313",
                Amount = 100M,
                BonusPoints = 10M,
                Status = true,
                //TypeAccount = TypeAccount.BaseAccount,
            };

            Account goldAccount = new Account()
            {
                Id = "dfsdfs",
                Amount = 100M,
                BonusPoints = 10M,
                Status = true,
                //TypeAccount = TypeAccount.GoldAccount,
            };

            user.Accounts = new List<Account>()
            {
                baseAccount,
                goldAccount
            };
            
            context.Users.Add(user);
            context.SaveChanges();
        }
    }
}
