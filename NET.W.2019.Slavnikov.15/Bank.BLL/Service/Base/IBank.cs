using System.Collections.Generic;
using Bank.BLL.Entities.Base;

namespace Bank.BLL.Service.Base
{
    /// <summary>
    /// Interface IBankService.
    /// </summary>
    public interface IBank : IAccount
    {
        /// <summary>
        /// Gets Account collection.
        /// </summary>
        /// <returns> Account collection.</returns>
        public List<IAccountInfo> GetAccounts();

        /// <summary>
        /// Add new Account.
        /// </summary>
        /// <param name="account"> new account.</param>
        public void AddBankAccount(IAccountInfo account);

        /// <summary>
        /// Close account.
        /// </summary>
        /// <param name="account"> Account.</param>
        public void Close(IAccountInfo account);
    }
}
