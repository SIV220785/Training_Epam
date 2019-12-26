using Bank.BLL.Service.Base;

namespace Bank.BLL.Service.Bonus
{
    /// <summary>
    /// Class for replenishment bonuses GoldAccount.
    /// </summary>
    public class BonusGoldAccount : IBonus
    {
        /// <inheritdoc/>
        public decimal ReplenishmentBonuses(decimal amount)
        {
            decimal resultBonus = 0M;

            if (amount < 500)
            {
                if (amount <= 299)
                {
                    resultBonus = amount * 0.003M;
                    return resultBonus;
                }
            }
            else if (amount >= 500)
            {
                if (amount >= 300 && amount <= 599)
                {
                    resultBonus = amount * 0.0035M;
                    return resultBonus;
                }
                else if (amount >= 600 && amount <= 999)
                {
                    resultBonus = amount * 0.004M;
                    return resultBonus;
                }
                else if (amount >= 1000 && amount <= 1999)
                {
                    resultBonus = amount * 0.0045M;
                    return resultBonus;
                }
                else if (amount >= 2000)
                {
                    resultBonus = amount * 0.005M;
                    return resultBonus;
                }
            }

            return resultBonus;
        }
    }
}
