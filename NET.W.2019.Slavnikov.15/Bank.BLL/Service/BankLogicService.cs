using System;
using System.Collections.Generic;
using Bank.BLL.Entities;
using Bank.BLL.Entities.Base;
using Bank.BLL.Service.Base;

namespace Bank.BLL.Service
{
    /// <summary>
    /// Class BankLogicService.
    /// </summary>
    public class BankLogicService
    {
        private readonly IBank bank;
        private readonly IGenerationIdAccount generationIdAccount;

        /// <summary>
        /// Initializes a new instance of the <see cref="BankLogicService"/> class.
        /// </summary>
        /// <param name="bank"> bank.</param>
        /// <param name="generationIdAccount"> generationIdAccount.</param>
        public BankLogicService(IBank bank, IGenerationIdAccount generationIdAccount)
        {
            if (bank is null)
            {
                throw new ArgumentNullException(nameof(bank));
            }

            if (generationIdAccount is null)
            {
                throw new ArgumentNullException(nameof(generationIdAccount));
            }

            this.generationIdAccount = generationIdAccount;
            this.bank = bank;
        }

        /// <summary>
        /// Gets Accounts collection.
        /// </summary>
        /// <returns> Accounts collection.</returns>
        public virtual List<IAccountInfo> GetAccounts() => this.bank.GetAccounts();

        /// <summary>
        /// Add account in collection.
        /// </summary>
        /// <param name="account"> Account that need add.</param>
        public virtual void AddBankAccount(IAccountInfo account)
        {
            if (account is null)
            {
                throw new ArgumentNullException(nameof(account));
            }

            switch (account.TypeAccount)
            {
                case TypeAccount.BaseAccount:
                    BaseAccountInfo baseAccountInfo = new BaseAccountInfo()
                    {
                        Id = this.generationIdAccount.GenerationId(),
                        Amount = account.Amount,
                        Client = account.Client,
                        BonusPoints = account.BonusPoints,
                        Status = account.Status,
                        TypeAccount = account.TypeAccount,
                    };
                    this.bank.AddBankAccount(baseAccountInfo);
                    break;

                case TypeAccount.GoldAccount:
                    GoldAccountInfo goldAccountInfo = new GoldAccountInfo()
                    {
                        Id = this.generationIdAccount.GenerationId(),
                        Amount = account.Amount,
                        Client = account.Client,
                        BonusPoints = account.BonusPoints,
                        Status = account.Status,
                        TypeAccount = account.TypeAccount,
                    };
                    this.bank.AddBankAccount(goldAccountInfo);
                    break;

                case TypeAccount.PlattinumAccount:
                    PlattinumAccountInfo plattinumAccountInfo = new PlattinumAccountInfo()
                    {
                        Id = this.generationIdAccount.GenerationId(),
                        Amount = account.Amount,
                        Client = account.Client,
                        BonusPoints = account.BonusPoints,
                        Status = account.Status,
                        TypeAccount = account.TypeAccount,
                    };
                    this.bank.AddBankAccount(plattinumAccountInfo);
                    break;
            }
        }

        /// <summary>
        /// Close account.
        /// </summary>
        /// <param name="account"> Account that need close.</param>
        public virtual void Close(IAccountInfo account)
        {
            if (account is null)
            {
                throw new ArgumentNullException(nameof(account));
            }

            this.bank.Close(account);
        }

        /// <summary>
        /// Add deposit.
        /// </summary>
        /// <param name="account"> Account to add amount.</param>
        /// <param name="amount"> Amount to add in account.</param>
        public virtual void Deposit(IAccountInfo account, decimal amount)
        {
            if (account is null)
            {
                throw new ArgumentNullException(nameof(account));
            }

            this.bank.Deposit(account, amount);
        }

        /// <summary>
        /// Write-off bank account.
        /// </summary>
        /// <param name="account"> Account for write-off.</param>
        /// <param name="amount"> Amount for write-off bank account.</param>
        public virtual void Withdraw(IAccountInfo account, decimal amount)
        {
            if (account is null)
            {
                throw new ArgumentNullException(nameof(account));
            }

            this.bank.Withdraw(account, amount);
        }

        /// <summary>
        /// Write-off bank account with bonuses.
        /// </summary>
        /// <param name="account"> Account for write-off.</param>
        /// <param name="amount"> Amount for write-off bank account.</param>
        /// <param name="bonus"> Bonus.</param>
        public virtual void WithdrawWithBonuses(IAccountInfo account, decimal amount, decimal bonus)
        {
            if (account is null)
            {
                throw new ArgumentNullException(nameof(account));
            }
            this.bank.WithdrawWithBonuses(account, amount, bonus);
        }
    }
}
