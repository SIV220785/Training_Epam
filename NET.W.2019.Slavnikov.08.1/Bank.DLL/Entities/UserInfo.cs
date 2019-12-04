using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.DLL.Entities
{
    /// <summary>
    /// Class UserInfo.
    /// </summary>
    public class UserInfo : IUser
    {
        private int id;
        private string firstName;
        private string lastName;

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
        public string FirstName
        {
            get => this.firstName;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(value, "First name is`t correct");
                }

                this.firstName = value;
            }
        }

        /// <inheritdoc/>
        public string LastName
        {
            get => this.lastName;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(value, "Last name is`t correct");
                }

                this.lastName = value;
            }
        }

        /// <inheritdoc/>
        public override string ToString() => $"FirstName: {this.FirstName}, LastName: {this.LastName}";
    }
}
