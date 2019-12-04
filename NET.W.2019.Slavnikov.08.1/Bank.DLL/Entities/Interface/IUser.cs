﻿namespace Bank.DLL.Entities
{
    /// <summary>
    /// Interface IUser.
    /// </summary>
    public interface IUser
    {
        /// <summary>
        /// Gets or sets Id user.
        /// </summary>
        /// <value>
        /// Id account.
        /// </value>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets first name user.
        /// </summary>
        /// <value>
        /// FirstName.
        /// </value>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets last name user.
        /// </summary>
        /// <value>
        /// LastName.
        /// </value>
        public string LastName { get; set; }
    }
}
