using System;

namespace Bank.DLL.Entities
{
    /// <summary>
    /// BaseAccount.
    /// </summary>
    public class BaseAccount : IAccount
    {
        private int id;
        private decimal amount;
        private decimal bonusPoints;
        private UserInfo client;

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseAccount"/> class.
        /// </summary>
        public BaseAccount()
        {
            this.bonusPoints = 0;
            this.client = new UserInfo();
            this.TypeAccount = "BaseAccount";
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
            if (this.amount < 100)
            {
                if (amount <= 100)
                {
                    this.bonusPoints = amount * 0.001M;
                }

                return;
            }
            else if (this.amount >= 100)
            {
                if (amount >= 101 && amount <= 299)
                {
                    this.bonusPoints = amount * 0.0015M;
                }
                else if (amount >= 300 && amount <= 499)
                {
                    this.bonusPoints = amount * 0.002M;
                }
                else if (amount >= 500 && amount <= 999)
                {
                    this.bonusPoints = amount * 0.0025M;
                }
                else if (amount >= 1000)
                {
                    this.bonusPoints = amount * 0.003M;
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
