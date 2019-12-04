using Bank.DLL.Entities;

namespace Bank.DLL.Service.Interface
{
    /// <summary>
    /// Interface IBankService.
    /// </summary>
    public interface IBankService
    {
        /// <summary>
        /// Add new Account.
        /// </summary>
        /// <param name="account"> new account.</param>
        public void AddBankAccount(IAccount account);

        /// <summary>
        /// Deposit to the account.
        /// </summary>
        /// <param name="account"> Account for deposit.</param>
        /// <param name="amount"> Amount for deposit to the account.</param>
        /// <returns> Amount account.</returns>
        public decimal Deposit(IAccount account, decimal amount);

        /// <summary>
        /// Write-off bank account.
        /// </summary>
        /// <param name="account"> Account for write-off.</param>
        /// <param name="amount"> Amount for write-off bank account.</param>
        /// <returns> Amount account.</returns>
        public decimal Withdraw(IAccount account, decimal amount);

        /// <summary>
        /// Write-off bank account.
        /// </summary>
        /// <param name="account"> Account for write-off.</param>
        /// <param name="amount"> Amount for write-off bank account.</param>
        /// <param name="bunus"> Bonus.</param>
        /// <returns> Amount account with bonuses.</returns>
        public decimal WithdrawBonuses(IAccount account, decimal amount, decimal bunus);

        /// <summary>
        /// Close account.
        /// </summary>
        /// <param name="account"> Account.</param>
        public void Close(IAccount account);

        /// <summary>
        /// Method Save to storage.
        /// </summary>
        void SaveToFile();

        /// <summary>
        /// Metho reding from storage.
        /// </summary>
        void ReadFile();
    }
}
