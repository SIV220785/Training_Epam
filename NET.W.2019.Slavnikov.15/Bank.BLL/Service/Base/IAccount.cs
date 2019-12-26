using System;
using Bank.BLL.Entities.Base;

namespace Bank.BLL.Service.Base
{
    /// <summary>
    /// Interface IAccountService.
    /// </summary>
    public interface IAccount
    {
        /// <summary>
        /// Deposit to the account.
        /// </summary>
        /// <param name="account"> Account for deposit.</param>
        /// <param name="amount"> Amount for deposit to the account.</param>
        public void Deposit(IAccountInfo account, decimal amount);

        /// <summary>
        /// Write-off bank account.
        /// </summary>
        /// <param name="account"> Account for write-off.</param>
        /// <param name="amount"> Amount for write-off bank account.</param>
        public void Withdraw(IAccountInfo account, decimal amount);

        /// <summary>
        /// Write-off bank account with bonuses.
        /// </summary>
        /// <param name="account"> Account for write-off.</param>
        /// <param name="amount"> Amount for write-off bank account.</param>
        /// <param name="bonus"> Bonus.</param>
        public void WithdrawWithBonuses(IAccountInfo account, decimal amount, decimal bonus);

        /// <summary>
        /// Check for amount.
        /// </summary>
        /// <param name="amount"> Amount.</param>
        /// <returns> False - insufficient funds in the account. True - enough funds in a bank account.</returns>
        public bool IsCheckAmount(decimal amount);

        /// <summary>
        /// Check for bonuses.
        /// </summary>
        /// <param name="bonus"> bonus amount.</param>
        /// <returns> False - no so many bonuses. True - there are so many bonuses.</returns>
        public bool IsCheckBonuses(decimal bonus);
    }
}
