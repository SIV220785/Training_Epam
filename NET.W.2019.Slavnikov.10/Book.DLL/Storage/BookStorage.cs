using System;
using System.Collections.Generic;
using System.IO;
using Book.DLL.Entities;

namespace Book.DLL.Storage
{
    /// <summary>
    /// Class for saving and reading a book to a file.
    /// </summary>
    public class BookStorage : IStorage
    {
        private readonly string path;

        /// <summary>
        /// Initializes a new instance of the <see cref="BookStorage"/> class.
        /// </summary>
        /// <param name="path"> The path to the file.</param>
        public BookStorage(string path)
        {
            if (string.IsNullOrWhiteSpace(path))
            {
                throw new ArgumentNullException($"{path} is not correct!");
            }

            this.path = path;
        }

        /// <summary>
        /// Loding collection books.
        /// </summary>
        /// <returns> Collection Books.</returns>
        public IEnumerable<BookInfo> Load()
        {
            List<BookInfo> books = new List<BookInfo>();
            using (var binaryReader = new BinaryReader(File.Open(this.path, FileMode.OpenOrCreate, FileAccess.Read, FileShare.Read)))
            {
                while (binaryReader.BaseStream.Position != binaryReader.BaseStream.Length)
                {
                    BookInfo bookInfo = new BookInfo
                    {
                        ISBN = binaryReader.ReadString(),
                        Author = binaryReader.ReadString(),
                        BookTitle = binaryReader.ReadString(),
                        Publishing = binaryReader.ReadString(),
                        YearPublishing = binaryReader.ReadInt32(),
                        NumberOfPages = binaryReader.ReadInt32(),
                        Price = binaryReader.ReadDecimal(),
                    };

                    books.Add(bookInfo);
                }
            }

            return books;
        }

        /// <summary>
        /// Method for save collection a book to a file.
        /// </summary>
        /// <param name="books"> Saving collection.</param>
        public void Save(IEnumerable<BookInfo> books)
        {
            if (books == null)
            {
                throw new ArgumentNullException($"Books is null");
            }

            using var binaryWriter = new BinaryWriter(File.Open(this.path, FileMode.Create, FileAccess.Write, FileShare.None));
            foreach (BookInfo book in books)
            {
                Writer(binaryWriter, book);
            }
        }

        /// <summary>
        /// Add book to file.
        /// </summary>
        /// <param name="book"> Adding book.</param>
        public void AppendBookToFile(BookInfo book)
        {
            if (book == null)
            {
                throw new ArgumentNullException($"Book is null");
            }

            using var binaryWriter = new BinaryWriter(File.Open(this.path, FileMode.Append, FileAccess.Write, FileShare.None));
            Writer(binaryWriter, book);
        }

        private static void Writer(BinaryWriter binaryWriter, BookInfo book)
        {
            binaryWriter.Write(book.ISBN);
            binaryWriter.Write(book.Author);
            binaryWriter.Write(book.BookTitle);
            binaryWriter.Write(book.Publishing);
            binaryWriter.Write(book.YearPublishing.Value);
            binaryWriter.Write(book.NumberOfPages.Value);
            binaryWriter.Write(book.Price.Value);
        }
    }
}
