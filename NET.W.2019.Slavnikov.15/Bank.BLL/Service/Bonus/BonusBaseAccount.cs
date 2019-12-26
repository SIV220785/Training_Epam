using Bank.BLL.Service.Base;

namespace Bank.BLL.Service.Bonus
{
    /// <summary>
    /// Class for replenishment bonuses BunusBaseAccount.
    /// </summary>
    public class BonusBaseAccount : IBonus
    {
        /// <inheritdoc/>
        public decimal ReplenishmentBonuses(decimal amount)
        {
            decimal resultBonus = 0M;
            if (amount < 100)
            {
                resultBonus = amount * 0.001M;
                return resultBonus;
            }
            else if (amount >= 100)
            {
                if (amount >= 101 && amount <= 299)
                {
                    resultBonus = amount * 0.0015M;
                    return resultBonus;
                }
                else if (amount >= 300 && amount <= 499)
                {
                    resultBonus = amount * 0.002M;
                    return resultBonus;
                }
                else if (amount >= 500 && amount <= 999)
                {
                    resultBonus = amount * 0.0025M;
                    return resultBonus;
                }
                else if (amount >= 1000)
                {
                    resultBonus = amount * 0.003M;
                    return resultBonus;
                }
            }

            return resultBonus;
        }
    }
}
