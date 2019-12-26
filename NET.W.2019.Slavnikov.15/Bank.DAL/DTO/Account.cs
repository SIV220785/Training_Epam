using Bank.DAL.DTO.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bank.DAL.DTO
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

    public class Account : IBaseEntity
    {
        /// <summary>
        /// Gets or sets Id account.
        /// </summary>
        /// <value>
        /// Id account.
        /// </value>
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Id { get; set; }

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


        public int UserId { get; set; }
        public virtual User User { get; set; }

    }
}
