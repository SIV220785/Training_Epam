namespace Bank.BLL.Service.Base
{
    /// <summary>
    /// Interface IBonusService.
    /// </summary>
    public interface IBonus
    {
        /// <summary>
        /// Calculate bonus points when crediting to a current account.
        /// </summary>
        /// <param name="amount"> Amount credited.</param>
        /// <returns> Bonus.</returns>
        public decimal ReplenishmentBonuses(decimal amount);
    }
}
