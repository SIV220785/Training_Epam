namespace Bank.DLL.Entities
{
    /// <summary>
    /// nterface IAccount.
    /// </summary>
    public interface IAccount
    {
        /// <summary>
        /// Gets or sets Id account.
        /// </summary>
        /// <value>
        /// Id account.
        /// </value>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets type account.
        /// </summary>
        /// <value>
        /// Type account.
        /// </value>
        public string TypeAccount { get; set; }

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

        /// <summary>
        /// Gets or sets Client.
        /// </summary>
        /// <value>
        /// Client.
        /// </value>
        public IUser Client { get; set; }

        /// <summary>
        /// Calculate bonus points when crediting to a current account.
        /// </summary>
        /// <param name="amount"> Amount credited.</param>
        public void ReplenishmentBonuses(decimal amount);

        /// <summary>
        /// Use of bonuses.
        /// </summary>
        /// <param name="amount"> Amount deducted without bonuses.</param>
        /// <param name="bonus"> Bonus amount.</param>
        /// <returns> Operation result.</returns>
        public decimal UseBonuses(decimal amount, decimal bonus);

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
