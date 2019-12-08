using System;
using System.Collections.Generic;
using System.Globalization;
using Book.DLL.Entities;
using Book.DLL.Storage;

namespace Book.DLL.BookService
{
    /// <summary>
    /// Class o perform basic book list operations.
    /// </summary>
    public class BookListService : IBookService
    {
        private List<BookInfo> books;
        private BookStorage bookStorage;

        /// <summary>
        /// Initializes a new instance of the <see cref="BookListService"/> class.
        /// </summary>
        public BookListService()
        {
            this.books = new List<BookInfo>();
            this.bookStorage = new BookStorage("Book.bin");
        }

        /// <summary>
        /// Search criteria.
        /// </summary>
        public enum TegFind
        {
            /// <summary>
            /// Teg for find numbers book.
            /// </summary>
            ISBN,

            /// <summary>
            /// Teg for find author.
            /// </summary>
            Author,

            /// <summary>
            /// Teg for find Book Title.
            /// </summary>
            BookTitle,

            /// <summary>
            /// Teg for find Publishing.
            /// </summary>
            Publishing,

            /// <summary>
            /// Teg for find Year of Publishing
            /// </summary>
            YearPublishing,
        }

        /// <summary>
        /// Gets Collection Books.
        /// </summary>
        /// <value>
        /// Collection Books.
        /// </value>
        public List<BookInfo> Books
        {
            get { return this.books; }
            private set { this.books = value ?? new List<BookInfo>(); }
        }

        /// <inheritdoc/>
        public void AddBook(BookInfo book)
        {
            if (book == null)
            {
                throw new ArgumentNullException(nameof(book), "Argument is null");
            }

            foreach (var itemBook in this.books)
            {
                if (book.Equals(itemBook))
                {
                    throw new ArgumentException($"The book is in the collection");
                }
            }

            this.Books.Add(book);
        }

        /// <summary>
        /// Remove book from collection.
        /// </summary>
        /// <param name="book"> Deleted book.</param>
        public void RemoveBook(BookInfo book)
        {
            if (book == null)
            {
                throw new ArgumentNullException(nameof(book), "Argument is null");
            }

            this.Books.Remove(book);
        }

        /// <inheritdoc/>
        public List<BookInfo> FindBookByTag(object findParameter, object tegFind)
        {
            List<BookInfo> listResult = new List<BookInfo>();
            bool isCheckEnum = findParameter is TegFind;
            bool isCheckInt = tegFind is int;

            if (findParameter == null)
            {
                throw new ArgumentNullException((string)findParameter, "Arguments is not correct....");
            }
            else if (tegFind == null)
            {
                throw new ArgumentNullException((string)tegFind, "Arguments is not correct....");
            }

            switch ((TegFind)findParameter)
            {
                case TegFind.ISBN:
                    {
                        if (!isCheckEnum)
                        {
                            throw new ArgumentException("ISBN is not correct....");
                        }

                        foreach (var book in this.books)
                        {
                            if (book.ISBN.ToUpper(CultureInfo.CurrentCulture).Equals(tegFind))
                            {
                                listResult.Add(book);
                            }
                        }

                        break;
                    }

                case TegFind.Author:
                    {
                        if (!isCheckEnum)
                        {
                            throw new ArgumentException("Author is not correct....");
                        }

                        foreach (var book in this.books)
                        {
                            if (book.Author.ToUpper(CultureInfo.CurrentCulture).Equals(tegFind))
                            {
                                listResult.Add(book);
                            }
                        }

                        break;
                    }

                case TegFind.BookTitle:
                    {
                        if (!isCheckEnum)
                        {
                            throw new ArgumentException("Book title is not correct....");
                        }

                        foreach (var book in this.books)
                        {
                            if (book.BookTitle.ToUpper(CultureInfo.CurrentCulture).Equals(tegFind))
                            {
                                listResult.Add(book);
                            }
                        }

                        break;
                    }

                case TegFind.Publishing:
                    {
                        if (!isCheckEnum)
                        {
                            throw new ArgumentException("Publishing is not correct....");
                        }

                        foreach (var book in this.books)
                        {
                            if (book.Publishing.ToUpper(CultureInfo.CurrentCulture).Equals(tegFind))
                            {
                                listResult.Add(book);
                            }
                        }

                        break;
                    }

                case TegFind.YearPublishing:
                    {
                        if (!isCheckInt)
                        {
                            throw new ArgumentException("Year of publishing is not correct....");
                        }

                        foreach (var book in this.books)
                        {
                            if (book.YearPublishing == (int)tegFind)
                            {
                                listResult.Add(book);
                            }
                        }

                        break;
                    }

                default:
                    break;
            }

            return listResult;
        }

        /// <summary>
        /// Read from file.
        /// </summary>
        public void ReadFile()
        {
            this.books.Clear();
            this.books = (List<BookInfo>)this.bookStorage.Load();
        }

        /// <summary>
        /// Save collection in storage.
        /// </summary>
        public void SaveToFile()
        {
            this.bookStorage.Save(this.books);
        }

        /// <inheritdoc/>
        public void AppendBookToFile(object book)
        {
            if (book == null)
            {
                throw new ArgumentNullException((string)book, "Arguments is null....");
            }

            foreach (var itemBook in this.books)
            {
                if (book.Equals(itemBook))
                {
                    throw new ArgumentException($"The book is in the collection");
                }
            }

            if (book is BookInfo)
            {
                this.bookStorage.AppendBookToFile((BookInfo)book);
            }
            else
            {
                throw new ArgumentException("book is not type BookInfo!!!");
            }
        }
    }
}
