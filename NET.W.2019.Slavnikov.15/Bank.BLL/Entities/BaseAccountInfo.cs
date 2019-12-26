using System;
using Bank.BLL.Entities.Base;
using Bank.BLL.Service.Base;
using Bank.BLL.Service.Bonus;

namespace Bank.BLL.Entities
{
    /// <summary>
    /// BaseAccount.
    /// </summary>
    public class BaseAccountInfo : IAccountInfo
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BaseAccountInfo"/> class.
        /// </summary>
        public BaseAccountInfo()
        {
            this.Client = new UserInfo();
            this.TypeAccount = TypeAccount.BaseAccount;
        }

        /// <inheritdoc/>
        public string Id { get; set; }

        /// <inheritdoc/>
        public IUserInfo Client { get; set; }

        /// <inheritdoc/>
        public TypeAccount TypeAccount { get; set; }

        /// <inheritdoc/>
        public decimal Amount { get; set; }

        /// <inheritdoc/>
        public bool Status { get; set; }

        /// <inheritdoc/>
        public decimal BonusPoints { get; set; }

        /// <inheritdoc/>
        public override string ToString() => $"Id {this.Id}, Amount {this.Amount}, BonusPoints {this.BonusPoints}, Status{this.Status}, Client: {this.Client}.";
    }
}
