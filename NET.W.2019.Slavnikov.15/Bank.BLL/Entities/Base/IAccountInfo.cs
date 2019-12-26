using System;

namespace Bank.BLL.Entities.Base
{
    /// <summary>
    /// Type account.
    /// </summary>
    public enum TypeAccount
    {
        /// <summary>
        /// Base account.
        /// </summary>
        BaseAccount,

        /// <summary>
        /// Gold account.
        /// </summary>
        GoldAccount,

        /// <summary>
        /// Plattinum account.
        /// </summary>
        PlattinumAccount,
    }

    /// <summary>
    /// nterface IAccount.
    /// </summary>
    public interface IAccountInfo
    {
        /// <summary>
        /// Gets or sets Id account.
        /// </summary>
        /// <value>
        /// Id account.
        /// </value>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets Client.
        /// </summary>
        /// <value>
        /// Client.
        /// </value>
        public IUserInfo Client { get; set; }

        /// <summary>
        /// Gets or sets type account.
        /// </summary>
        /// <value>
        /// Type account.
        /// </value>
        public TypeAccount TypeAccount { get; set; }

        /// <summary>
        /// Gets or sets account.
        /// </summary>
        /// <value>
        /// Account.
        /// </value>
        public decimal Amount { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or sets account status.
        /// </summary>
        /// <value>
        /// Account status.
        /// </value>
        public bool Status { get; set; }

        /// <summary>
        /// Gets or sets bonus points.
        /// </summary>
        /// <value>
        /// Bonus points.
        /// </value>
        public decimal BonusPoints { get; set; }
    }
}
