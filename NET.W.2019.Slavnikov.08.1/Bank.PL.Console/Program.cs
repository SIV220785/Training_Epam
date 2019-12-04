using Bank.DLL.Entities;
using Bank.DLL.Service;

namespace Bank.PL.Console
{
    using System;
    class Program
    {
        private static UserInfo userInfo = new UserInfo(){Id = 1,FirstName = "Igor",LastName = "Slavnikov"};
        private static BaseAccount baseAccount = new BaseAccount() { Id = 1, Amount = 100M, BonusPoints = 0.1M, Client = userInfo, Status = true };
        private static GoldAccount goldAccount = new GoldAccount() { Id = 2, Amount = 500M, BonusPoints = 10M, Client = userInfo, Status = true };
        private static PlattinumAccount plattinumAccount = new PlattinumAccount() { Id = 3, Amount = 1000M, BonusPoints = 40M, Client = userInfo, Status = true };

        private static BankService bankService = new BankService();

        static void Main(string[] args)
        {
            /// ArgumentNullException Add in collection bank account.
            Console.WriteLine("ArgumentNullException Add in collection bank account.");
            Console.WriteLine();
            try
            {
                bankService.AddBankAccount(null);
            }
            catch (Exception m)
            {
                Console.WriteLine(m.Message);
            }
            Console.WriteLine();

            /// Add new bank account
            Console.WriteLine("####################################################");
            Console.WriteLine();
            Console.WriteLine("Add new bank account");
            Console.WriteLine();
            bankService.AddBankAccount(baseAccount);
            bankService.AddBankAccount(goldAccount);
            bankService.AddBankAccount(plattinumAccount);
            foreach (var account in bankService.Accounts)
            {
                Console.WriteLine(account);
            }
            Console.WriteLine();

            /// Deposit acounts
            Console.WriteLine("####################################################");
            Console.WriteLine();
            Console.WriteLine("Deposit acounts");
            Console.WriteLine();
            decimal amount = 500M;
            for (int i = 0; i < bankService.Accounts.Count; i++)
            {
                bankService.Accounts[i].Amount = bankService.Deposit(bankService.Accounts[i], amount);
                bankService.Accounts[i].ReplenishmentBonuses(amount);
                amount += 500M;
                Console.WriteLine(bankService.Accounts[i]);
            }
            Console.WriteLine();

            /// Write off 
            Console.WriteLine("####################################################");
            Console.WriteLine();
            Console.WriteLine("Write off");
            Console.WriteLine();
            decimal amount1 = 1000M;
            for (int i = 0; i < bankService.Accounts.Count; i++)
            {
                if (bankService.Accounts[i].IsCheckAmount(amount1))
                {
                    Console.WriteLine("insufficient funds in the account!");
                    Console.WriteLine(bankService.Accounts[i]);
                    Console.WriteLine(amount1);
                    continue;
                }
                bankService.Accounts[i].Amount = bankService.Withdraw(bankService.Accounts[i], amount1);
                amount += 200M;
                Console.WriteLine(bankService.Accounts[i]);
            }
            Console.WriteLine();

            /// Write off with bonus
            Console.WriteLine("####################################################");
            Console.WriteLine();
            Console.WriteLine("Write off with bonus");
            Console.WriteLine();
            decimal amount2 = 200M;
            decimal bonus = 20M;
            for (int i = 0; i < bankService.Accounts.Count; i++)
            {

                if (bankService.Accounts[i].IsCheckAmount(amount2))
                {
                    Console.WriteLine("insufficient funds in the account!");
                    Console.WriteLine(bankService.Accounts[i]);
                    Console.WriteLine(amount1);
                    continue;
                }

                if (bankService.Accounts[i].IsCheckBonuses(bonus))
                {
                    Console.WriteLine("insufficient bonuses in the account!");
                    Console.WriteLine(bankService.Accounts[i]);
                    Console.WriteLine(bonus);
                    continue;
                }
                bankService.Accounts[i].Amount = bankService.WithdrawBonuses(bankService.Accounts[i], amount2, bonus);
                bankService.Accounts[i].BonusPoints -= bonus;
                amount += 200M;
                bonus += 10;
                Console.WriteLine(bankService.Accounts[i]);
            }
            Console.WriteLine();

            /// Close acoount
            Console.WriteLine("####################################################");
            Console.WriteLine();
            Console.WriteLine("Write off with bonus");
            Console.WriteLine();
            bankService.Accounts[0].Status = false;
            foreach (var account in bankService.Accounts)
            {
                if (account.Status == false)
                {
                    Console.WriteLine(account);
                }
            }
            Console.WriteLine();

            ///write in file 
            Console.WriteLine("####################################################");
            Console.WriteLine();
            Console.WriteLine("Write in file");
            Console.WriteLine();
            try
            {
                bankService.SaveToFile();
                Console.WriteLine("Save ok!");
            }
            catch (Exception)
            {

            }
            Console.WriteLine();
            Console.WriteLine("Add new bank account");
            Console.WriteLine();
            bankService.AddBankAccount(baseAccount);
            bankService.AddBankAccount(goldAccount);
            Console.WriteLine();
            foreach (var account in bankService.Accounts)
            {
                Console.WriteLine(account);
            }
            Console.WriteLine();
            Console.WriteLine("Read of file");
            try
            {
                bankService.ReadFile();
                Console.WriteLine("Read ok!");
            }
            catch (Exception)
            {

                throw;
            }
            Console.WriteLine();

            foreach (var account in bankService.Accounts)
            {
                Console.WriteLine(account);
            }



            Console.ReadKey();
        }
    }
}
