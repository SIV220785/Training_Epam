using Bank.BLL.Service.Base;

namespace Bank.BLL.Service.Bonus
{
    /// <summary>
    /// Class for replenishment bonuses PlattinumAccount.
    /// </summary>
    public class BonusPlattinumAccount : IBonus
    {

        /// <inheritdoc/>
        public decimal ReplenishmentBonuses(decimal amount)
        {
            decimal resultBonus = 0M;

            if (amount < 1000)
            {
                if (amount <= 499)
                {
                    resultBonus = amount * 0.003M;
                    return resultBonus;
                }
            }
            else if (amount >= 1000)
            {
                if (amount >= 500 && amount <= 999)
                {
                    resultBonus = amount * 0.004M;
                    return resultBonus;
                }
                else if (amount >= 1000 && amount <= 1999)
                {
                    resultBonus = amount * 0.005M;
                    return resultBonus;
                }
                else if (amount >= 2000 && amount <= 2999)
                {
                    resultBonus = amount * 0.006M;
                    return resultBonus;
                }
                else if (amount >= 3000)
                {
                    resultBonus += amount * 0.007M;
                    return resultBonus;
                }
            }

            return resultBonus;
        }
    }
}
