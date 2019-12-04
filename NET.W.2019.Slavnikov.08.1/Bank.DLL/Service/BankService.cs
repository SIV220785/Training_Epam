using System;
using System.Collections.Generic;
using Bank.DLL.Entities;
using Bank.DLL.Service.Interface;
using Bank.DLL.Storage;

namespace Bank.DLL.Service
{
    /// <summary>
    /// BankService.
    /// </summary>
    public class BankService : IBankService
    {
        private BankStorage bankStorage;

        /// <summary>
        /// Initializes a new instance of the <see cref="BankService"/> class.
        /// </summary>
        public BankService()
        {
            this.Accounts = new List<IAccount>();
            this.bankStorage = new BankStorage("BankAccounts.bin");
        }

        /// <summary>
        /// Gets Collection Accounts.
        /// </summary>
        /// <value>
        /// Collection Accounts.
        /// </value>
        public List<IAccount> Accounts { get; private set; }

        /// <inheritdoc/>
        public void AddBankAccount(IAccount account)
        {
            if (account == null)
            {
                throw new ArgumentNullException(nameof(account), "Account is null");
            }

            this.Accounts.Add(account);
        }

        /// <inheritdoc/>
        public void Close(IAccount account)
        {
            if (account == null)
            {
                throw new ArgumentNullException(nameof(account), "Account is null");
            }

            for (int i = 0; i < this.Accounts.Count; i++)
            {
                if (this.Accounts[i].Id == account.Id)
                {
                    this.Accounts[i].Status = false;
                    break;
                }
            }
        }

        /// <inheritdoc/>
        public decimal Deposit(IAccount account, decimal amount)
        {
            if (account == null)
            {
                throw new ArgumentNullException(nameof(account), "Account is null");
            }

            if (amount <= 0 || amount >= decimal.MaxValue)
            {
                throw new ArgumentException($"Amount is`n correct...");
            }

            return account.Amount + amount;
        }

        /// <inheritdoc/>
        public void ReadFile()
        {
            this.Accounts.Clear();
            this.Accounts = (List<IAccount>)this.bankStorage.Load();
        }

        /// <inheritdoc/>
        public void SaveToFile()
        {
            this.bankStorage.Save(this.Accounts);
        }

        /// <inheritdoc/>
        public decimal Withdraw(IAccount account, decimal amount)
        {
            if (account == null)
            {
                throw new ArgumentNullException(nameof(account), "Account is null");
            }

            if (amount <= 0 || amount >= decimal.MaxValue)
            {
                throw new ArgumentException($"Amount is`n correct...");
            }

            return account.Amount - amount;
        }

        /// <inheritdoc/>
        public decimal WithdrawBonuses(IAccount account, decimal amount, decimal bonus)
        {
            if (account == null)
            {
                throw new ArgumentNullException(nameof(account), "Account is null");
            }

            if (amount <= 0 || amount >= decimal.MaxValue || account.Amount < amount + bonus || bonus < 0)
            {
                throw new ArgumentException($"Amount of bonus is`n correct...");
            }

            return account.Amount - amount + bonus;
        }
    }
}
