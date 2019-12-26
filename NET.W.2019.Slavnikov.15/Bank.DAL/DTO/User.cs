using Bank.DAL.DTO.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.DAL.DTO
{

    public class User : IBaseEntity
    {
        /// <summary>
        /// Gets or sets Id user.
        /// </summary>
        /// <value>
        /// Id account.
        /// </value>
        public string Id { get; set; }

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

        public virtual ICollection<Account> Accounts { get; set; }
    }
}
