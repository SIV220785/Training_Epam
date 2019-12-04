using System.Collections.Generic;
using Bank.DLL.Entities;

namespace Bank.DLL.Storage
{
    /// <summary>
    /// interface IStorage.
    /// </summary>
    public interface IStorage
    {
        /// <summary>
        /// TypesAccaount.
        /// </summary>
        public enum TypesAccaount
        {
            /// <summary>
            /// Base Account.
            /// </summary>
            BaseAccount,

            /// <summary>
            /// Gold Account.
            /// </summary>
            GoldAccount,

            /// <summary>
            /// Plattinum Account
            /// </summary>
            PlattinumAccount,
        }

        /// <summary>
        /// Method save to storage.
        /// </summary>
        /// <param name="books"> Collection to save.</param>
        void Save(IEnumerable<IAccount> books);

        /// <summary>
        /// Methot get collection from storage.
        /// </summary>
        /// <returns>Collection from storage.</returns>
        IEnumerable<IAccount> Load();
    }
}
