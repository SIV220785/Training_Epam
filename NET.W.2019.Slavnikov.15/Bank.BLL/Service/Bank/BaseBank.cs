using System;
using System.Collections.Generic;
using Bank.BLL.Entities.Base;
using Bank.BLL.Service.Base;
using Bank.BLL.Service.Bonus;
using Ninject;

namespace Bank.BLL.Service.Bank
{
    /// <summary>
    /// BankService.
    /// </summary>
    public class BaseBank : IBank, IAccount
    {
        private List<IAccountInfo> accountInfos;
        private BonusBaseAccount bonusBaseAccount;
        private BonusGoldAccount bonusGoldAccount;
        private BonusPlattinumAccount bonusPlattinumAccount;

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseBank"/> class.
        /// </summary>
        public BaseBank()
        {
            this.accountInfos = new List<IAccountInfo>();
            this.bonusBaseAccount = new BonusBaseAccount();
            this.bonusGoldAccount = new BonusGoldAccount();
            this.bonusPlattinumAccount = new BonusPlattinumAccount();
        }

        /// <inheritdoc/>
        public virtual List<IAccountInfo> GetAccounts() => this.accountInfos;

        /// <inheritdoc/>
        public void AddBankAccount(IAccountInfo account)
        {
            if (account == null)
            {
                throw new ArgumentNullException(nameof(account), "Account is null");
            }

            this.accountInfos.Add(account);
        }

        /// <inheritdoc/>
        public void Close(IAccountInfo account)
        {
            if (account == null)
            {
                throw new ArgumentNullException(nameof(account), "Account is null");
            }

            for (int i = 0; i < this.accountInfos.Count; i++)
            {
                if (this.accountInfos[i].Id == account.Id)
                {
                    this.accountInfos[i].Status = false;
                    break;
                }
            }
        }

        /// <inheritdoc/>
        public void Deposit(IAccountInfo account, decimal amount)
        {
            if (account == null)
            {
                throw new ArgumentNullException(nameof(account), "Account is null");
            }

            if (amount <= 0 || amount >= decimal.MaxValue)
            {
                throw new ArgumentException($"Amount is`n correct...");
            }

            foreach (var accountinfo in this.accountInfos)
            {
                if (accountinfo.Id.Equals(account.Id, StringComparison.CurrentCulture))
                {
                    accountinfo.Amount += amount;
                    switch (accountinfo.TypeAccount)
                    {
                        case TypeAccount.BaseAccount:
                            accountinfo.BonusPoints += this.bonusBaseAccount.ReplenishmentBonuses(amount);
                            break;
                        case TypeAccount.GoldAccount:
                            accountinfo.BonusPoints += this.bonusGoldAccount.ReplenishmentBonuses(amount);
                            break;
                        case TypeAccount.PlattinumAccount:
                            accountinfo.BonusPoints += this.bonusPlattinumAccount.ReplenishmentBonuses(amount);
                            break;
                    }
                }
            }
        }

        /// <inheritdoc/>
        public void Withdraw(IAccountInfo account, decimal amount)
        {
            if (account == null)
            {
                throw new ArgumentNullException(nameof(account), "Account is null");
            }

            if (amount <= 0 || amount >= decimal.MaxValue)
            {
                throw new ArgumentException($"Amount is`n correct...");
            }

            foreach (var accountinfo in this.accountInfos)
            {
                if (accountinfo.Id.Equals(account.Id, StringComparison.CurrentCulture))
                {
                    if (accountinfo.Amount >= amount)
                    {
                        accountinfo.Amount -= amount;
                    }
                }
            }
        }

        /// <inheritdoc/>
        public void WithdrawWithBonuses(IAccountInfo account, decimal amount, decimal bonus)
        {
            if (account == null)
            {
                throw new ArgumentNullException(nameof(account), "Account is null");
            }

            if (amount <= 0 || amount >= decimal.MaxValue || account.Amount < amount + bonus || bonus < 0)
            {
                throw new ArgumentException($"Amount of bonus is`n correct...");
            }

            foreach (var accountinfo in this.accountInfos)
            {
                if (accountinfo.Id.Equals(account.Id, StringComparison.CurrentCulture))
                {
                    if (account.Amount >= amount + bonus || account.BonusPoints >= bonus)
                    {
                        accountinfo.Amount -= amount + bonus;
                        account.BonusPoints -= bonus;
                        break;
                    }
                }
            }
        }

        /// <inheritdoc/>
        public bool IsCheckAmount(decimal amount)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public bool IsCheckBonuses(decimal bonus)
        {
            throw new NotImplementedException();
        }
    }
}
