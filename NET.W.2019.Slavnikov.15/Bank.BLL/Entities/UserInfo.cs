using Bank.BLL.Entities.Base;

namespace Bank.BLL.Entities
{
    /// <summary>
    /// Class UserInfo.
    /// </summary>
    public class UserInfo : IUserInfo
    {
        /// <inheritdoc/>
        public int Id { get; set; }

        /// <inheritdoc/>
        public string FirstName { get; set; }

        /// <inheritdoc/>
        public string LastName { get; set; }

        /// <inheritdoc/>
        public override string ToString() => $"FirstName: {this.FirstName}, LastName: {this.LastName}";
    }
}
