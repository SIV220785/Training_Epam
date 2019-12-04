using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.DLL.Entities
{
    /// <summary>
    /// GoldAccount.
    /// </summary>
    public class GoldAccount : IAccount
    {
        private int id;
        private decimal amount;
        private decimal bonusPoints;
        private UserInfo client;

        /// <summary>
        /// Initializes a new instance of the <see cref="GoldAccount"/> class.
        /// </summary>
        public GoldAccount()
        {
            this.bonusPoints = 0;
            this.client = new UserInfo();
            this.TypeAccount = "GoldAccount";
        }

        /// <inheritdoc/>
        public int Id
        {
            get => this.id;
            set
            {
                if (value <= 0 || value >= int.MaxValue)
                {
                    throw new ArgumentException("Id Acoount id should`t be less than 1.");
                }

                this.id = value;
            }
        }

        /// <inheritdoc/>
        public decimal Amount
        {
            get => this.amount;
            set
            {
                if (value <= 0 || value >= decimal.MaxValue)
                {
                    throw new ArgumentException($"Amount id should`t be less than 0.");
                }

                this.amount = value;
            }
        }

        /// <inheritdoc/>
        public decimal BonusPoints
        {
            get => this.bonusPoints;
            set
            {
                if (value <= 0 || value >= decimal.MaxValue)
                {
                    throw new ArgumentException($"Bonus points id should`t be less than 0.");
                }

                this.bonusPoints = value;
            }
        }

        /// <inheritdoc/>
        public bool Status { get; set; }

        /// <inheritdoc/>
        public IUser Client
        {
            get => this.client;
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Client", "Client is null");
                }

                this.client = (UserInfo)value;
            }
        }

        /// <inheritdoc/>
        public string TypeAccount { get; set; }

        /// <inheritdoc/>
        public void ReplenishmentBonuses(decimal amount)
        {
            if (this.amount < 500)
            {
                if (amount <= 299)
                {
                    this.bonusPoints += amount * 0.003M;
                }

                return;
            }
            else if (this.amount >= 500)
            {
                if (amount >= 300 && amount <= 599)
                {
                    this.bonusPoints += amount * 0.0035M;
                }
                else if (amount >= 600 && amount <= 999)
                {
                    this.bonusPoints += amount * 0.004M;
                }
                else if (amount >= 1000 && amount <= 1999)
                {
                    this.bonusPoints += amount * 0.0045M;
                }
                else if (amount >= 2000)
                {
                    this.bonusPoints += amount * 0.005M;
                }
            }
        }

        /// <inheritdoc/>
        public decimal UseBonuses(decimal amount, decimal bonus)
        {
            if (bonus <= 0 || bonus > this.bonusPoints)
            {
                throw new ArgumentException("No so many bonuses.");
            }

            if (amount <= 0 || amount > this.amount - bonus)
            {
                throw new ArgumentException("Insufficient funds considering bonuses.");
            }

            return this.amount - this.amount - bonus;
        }

        /// <inheritdoc/>
        public bool IsCheckBonuses(decimal bonus)
        {
            if (bonus <= 0 || bonus > this.bonusPoints)
            {
                return true;
            }

            return false;
        }

        /// <inheritdoc/>
        public bool IsCheckAmount(decimal amount)
        {
            if (amount <= 0 || amount > this.amount)
            {
                return true;
            }

            return false;
        }

        /// <inheritdoc/>
        public override string ToString() => $"Id {this.Id}, Amount {this.Amount}, BonusPoints {this.BonusPoints}, Status{this.Status}, Client: {this.Client}.";
    }
}
