using Bank.BLL.Entities;
using Bank.BLL.Entities.Base;
using Bank.BLL.Mapper;
using Bank.BLL.Service;
using Bank.BLL.Service.Base;
using Bank.DAL.Contexts;
using DependencyResolver;
using Ninject;
using System.Collections.Generic;

namespace Console.PL
{
    class Program
    {
        private static readonly IKernel resolver;
        private static readonly BaseAccountInfo baseAccount = new BaseAccountInfo()
        {
            Amount = 100M,
            BonusPoints = 10M,
            Client = new UserInfo()
            {
                FirstName = "111",
                Id = 1,
                LastName = "222",
            },
            Status = true,
            TypeAccount = TypeAccount.BaseAccount,
        };
        private static readonly GoldAccountInfo goldAccount = new GoldAccountInfo()
        {
            Amount = 100M,
            BonusPoints = 10M,
            Client = new UserInfo()
            {
                FirstName = "222",
                Id = 2,
                LastName = "333",
            },
            Status = true,
            TypeAccount = TypeAccount.GoldAccount,
        };
        private static readonly BankContext bankContext = new BankContext();
        private static readonly AccountService accountService = new AccountService(bankContext);

        static Program()
        {
            resolver = new StandardKernel();
            resolver.ConfigurateResolver();
        }

        static void Main(string[] args)
        {
            IBank bank = resolver.Get<IBank>();
            IGenerationIdAccount generationId = resolver.Get<IGenerationIdAccount>();
            

            BankLogicService bankLogicService = new BankLogicService(bank, generationId);
            //AddBankAccount ##########################################################
            System.Console.WriteLine("AddBankAccount ##########################################################");

            List<IAccountInfo> list = bankLogicService.GetAccounts();
            bankLogicService.AddBankAccount(baseAccount);
            bankLogicService.AddBankAccount(goldAccount);
            bankLogicService.AddBankAccount(goldAccount);

            foreach (var item in bankLogicService.GetAccounts())
            {
                System.Console.WriteLine(item);
            }
            System.Console.WriteLine();

            //Close ##########################################################
            System.Console.WriteLine("Close ##########################################################");

            bankLogicService.Close(list[2]);

            foreach (var item in bankLogicService.GetAccounts())
            {
                System.Console.WriteLine(item);
            }
            System.Console.WriteLine();

            //Deposit ##########################################################
            System.Console.WriteLine("Deposit ##########################################################");

            bankLogicService.Deposit(list[1], 500M);

            foreach (var item in bankLogicService.GetAccounts())
            {
                System.Console.WriteLine(item);
            }
            System.Console.WriteLine();

            //Withdraw ##########################################################
            System.Console.WriteLine("Withdraw ##########################################################");

            bankLogicService.Withdraw(list[1], 100M);

            foreach (var item in bankLogicService.GetAccounts())
            {
                System.Console.WriteLine(item);
            }
            System.Console.WriteLine();

            //WithdrawWithBonuses##########################################################
            System.Console.WriteLine("WithdrawWithBonuses ##########################################################"); 

            bankLogicService.WithdrawWithBonuses(list[1], 90M, 10M);

            foreach (var item in bankLogicService.GetAccounts())
            {
                System.Console.WriteLine(item);
            }
            System.Console.WriteLine();

            //DB##########################################################
            System.Console.WriteLine("DB ##########################################################");
            list.Clear();

            var tmpList = accountService.GetAll();
            foreach (var item in tmpList)
            {
                list.Add(item);
            }

            foreach (var item in list)
            {
                System.Console.WriteLine(item);
            }
            System.Console.WriteLine();

            System.Console.ReadKey();
        }
    }
}
