using System.Collections.Generic;
using Book.DLL.Entities;

namespace Book.DLL.BookService
{
    /// <summary>
    /// Interface IBookService.
    /// </summary>
    internal interface IBookService
    {
        /// <summary>
        /// Mothod Add new book.
        /// </summary>
        /// <param name="book"> Add book.</param>
        void AddBook(BookInfo book);

        /// <summary>
        /// Method delete book.
        /// </summary>
        /// <param name="book"> Deleted book.</param>
        void RemoveBook(BookInfo book);

        /// <summary>
        /// Book search by specified criteria.
        /// </summary>
        /// <param name="findParameter"> Search parameter.</param>
        /// <param name="tag"> tag.</param>
        /// <returns> Collection book search by specified criteria.</returns>
        List<BookInfo> FindBookByTag(object findParameter, object tag);

        /// <summary>
        /// Method Save to storage.
        /// </summary>
        void SaveToFile();

        /// <summary>
        /// Metho reding from storage.
        /// </summary>
        void ReadFile();

        /// <summary>
        /// Method append book to file.
        /// </summary>
        /// /// <param name="obj"> Save obj.</param>
        void AppendBookToFile(object obj);
    }
}
