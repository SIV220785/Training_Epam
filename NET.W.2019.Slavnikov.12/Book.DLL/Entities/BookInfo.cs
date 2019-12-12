using System;
using System.Text.RegularExpressions;

namespace Book.DLL.Entities
{
    /// <summary>
    /// Book Information Class.
    /// </summary>
    public class BookInfo : IComparable, IComparable<BookInfo>, IEquatable<BookInfo>, IFormattable
    {
        private string isbn;
        private string author;
        private string bookTitle;
        private string publishing;
        private int? yearPublishing;
        private int? numberOfPages;
        private decimal? price;

        /// <summary>
        /// Gets or sets Numbers Book.
        /// </summary>
        /// <value>
        /// Numbers Book.
        /// </value>
        public string ISBN
        {
            get => this.isbn;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException($"ISBN is not correct...");
                }

                var regex = new Regex("(ISBN[-]*(1[03])*[ ]*(: ){0,1})*(([0-9Xx][- ]*){13}|([0-9Xx][- ]*){10})");

                if (!regex.IsMatch(value))
                {
                    throw new ArgumentException($"Invalid {nameof(value)}");
                }

                this.isbn = value;
            }
        }

        /// <summary>
        /// Gets or sets Author.
        /// </summary>
        /// <value>
        /// Author.
        /// </value>
        public string Author
        {
            get => this.author;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException($"Author is not correct...");
                }

                this.author = value;
            }
        }

        /// <summary>
        /// Gets or sets book title.
        /// </summary>
        /// <value>
        /// Book title.
        /// </value>
        public string BookTitle
        {
            get => this.bookTitle;

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException($"Book title is not correct...");
                }

                this.bookTitle = value;
            }
        }

        /// <summary>
        /// Gets or sets publishing.
        /// </summary>
        /// <value>
        /// Publishing.
        /// </value>
        public string Publishing
        {
            get => this.publishing;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException($"Publishing title is not correct...");
                }

                this.publishing = value;
            }
        }

        /// <summary>
        /// Gets or sets the year of publishing.
        /// </summary>
        /// <value>
        /// The year of publishing.
        /// </value>
        public int? YearPublishing
        {
            get => this.yearPublishing;

            set
            {
                if (value == null || value <= 1980 || value > DateTime.Now.Year)
                {
                    throw new ArgumentNullException($"Year of publishing is not correct...");
                }

                this.yearPublishing = value;
            }
        }

        /// <summary>
        /// Gets or sets the number of pages.
        /// </summary>
        /// <value>
        /// The number of pages.
        /// </value>
        public int? NumberOfPages
        {
            get => this.numberOfPages;

            set
            {
                if (value == null || value <= 0 || value >= 5000)
                {
                    throw new ArgumentNullException($"Year of publishing is not correct...");
                }

                this.numberOfPages = value;
            }
        }

        /// <summary>
        /// Gets or sets price.
        /// </summary>
        /// <value>
        /// Price.
        /// </value>
        public decimal? Price
        {
            get => this.price;
            set
            {
                if (value == null || value <= 0 || value >= decimal.MaxValue)
                {
                    throw new ArgumentNullException($"Price is not correct...");
                }

                this.price = value;
            }
        }

        /// <summary>
        /// Override ToString() methods.
        /// </summary>
        /// <returns> String representation.</returns>
        public override string ToString() => $"ISBN 13: {this.Price}, Author: {this.Author}, Book title: {this.BookTitle}," +
            $" Publishing {this.Publishing}, The year of publishing: {this.YearPublishing.Value}," +
            $" The number of pages: {this.NumberOfPages}, Price: {this.Price}.";

        /// <summary>
        /// override Equals() methods.
        /// </summary>
        /// <param name="obj">object to compare.</param>
        /// <returns>True if objects are equivalent, false otherwise.</returns>
        public override bool Equals(object obj)
        {
            if (obj is null)
            {
                return false;
            }

            if (ReferenceEquals(obj, this))
            {
                return true;
            }

            if (obj.GetType() == this.GetType())
            {
                BookInfo book = obj as BookInfo;
                return this.Equals(book);
            }

            return false;
        }

        /// <summary>
        /// override GetHashCode() methods.
        /// </summary>
        /// <returns>Hash code with isbn, author and book title.</returns>
        public override int GetHashCode() => this.ISBN.GetHashCode() + this.Author.GetHashCode() + this.BookTitle.GetHashCode();

        /// <inheritdoc/>
        public int CompareTo(object obj)
        {
            if (obj is null)
            {
                return 1;
            }

            var book = (BookInfo)obj;
            return this.CompareTo(book);
        }

        /// <inheritdoc/>
        public int CompareTo(BookInfo other)
        {
            if (other is null)
            {
                return 1;
            }

            return string.Compare(this.BookTitle, other.BookTitle, StringComparison.Ordinal);
        }

        /// <inheritdoc/>
        public bool Equals(BookInfo other)
        {
            var book = (BookInfo)other;
            if (book == null)
            {
                return false;
            }

            return this.ISBN == book.ISBN && this.Author == book.Author && this.BookTitle == book.BookTitle
                   && this.Publishing == book.Publishing && this.YearPublishing == book.YearPublishing
                   && this.NumberOfPages == book.NumberOfPages && this.Price == book.Price;
        }

        /// <inheritdoc/>
        public string ToString(string format, IFormatProvider formatProvider)
        {
            if (string.IsNullOrWhiteSpace(format))
            {
                format = "6";
            }

            return format switch
            {
                "1" => $"Book: {this.BookTitle},  Author: {this.Author}.",
                "2" => $"ISBN: {this.ISBN}, Book: {this.BookTitle},  Author: {this.Author}.",
                "3" => $"ISBN: {this.ISBN}, Book: {this.BookTitle},  Author: {this.Author}, Publishing: {this.Publishing}.",
                "4" => $"ISBN 13: {this.ISBN}, Book: {this.BookTitle}, Author: {this.Author}, Publishing: {this.Publishing}," +
                           $" The year of publishing: {this.YearPublishing.Value}",
                "5" => $"ISBN 13: {this.ISBN}, Book: {this.BookTitle}, Author: {this.Author}, Publishing: {this.Publishing}," +
                           $" The year of publishing: {this.YearPublishing.Value}," +
                           $" The number of pages: {this.NumberOfPages}.",
                "6" => $"ISBN 13: {this.ISBN}, Book: {this.BookTitle}, Author: {this.Author}, Publishing: {this.Publishing}," +
                           $" The year of publishing: {this.YearPublishing.Value}," +
                           $" The number of pages: {this.NumberOfPages}., Price: {this.Price}.",
                _ => throw new FormatException($"The {format} format string is not supported."),
            };
        }
    }
}
