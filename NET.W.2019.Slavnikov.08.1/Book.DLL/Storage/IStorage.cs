using System.Collections.Generic;
using Book.DLL.Entities;

namespace Book.DLL.Storage
{
    /// <summary>
    /// interface IStorage.
    /// </summary>
    public interface IStorage
    {
        /// <summary>
        /// Method save to storage.
        /// </summary>
        /// <param name="books"> Collection to save.</param>
        void Save(IEnumerable<BookInfo> books);

        /// <summary>
        /// Methot get collection from storage.
        /// </summary>
        /// <returns>Collection from storage.</returns>
        IEnumerable<BookInfo> Load();
    }
}
