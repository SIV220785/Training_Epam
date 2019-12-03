using Book.DLL.BookService;
using Book.DLL.Entities;
using System.Collections.Generic;

namespace PL.Console
{
    using System;

    public static class Program
    {
        private static BookListService bookListService = new BookListService();
        private static List<BookInfo> books = new List<BookInfo>()
        {
            new BookInfo
            {
                ISBN = "5-318-00453-9",
                Author = "Снейдер",
                BookTitle = "Эффективное программирование TCP/IP",
                Publishing = "Питер",
                YearPublishing = 2000,
                NumberOfPages = 800,
                Price = 60M,
            },

            new BookInfo
            {
                ISBN = "978-5-496-02091-6",
                Author = "Мартин",
                BookTitle = "Идеальный программист",
                Publishing = "Питер",
                YearPublishing = 2016,
                NumberOfPages = 224,
                Price = 76.50M,
            },
        };

        static void Main(string[] args)
        {
            //Check for add entity = null.
            Console.WriteLine();
            Console.WriteLine("########################################");
            Console.WriteLine("Check for add entity = null.");
            try
            {
                bookListService.AddBook(null);
            }
            catch (Exception m)
            {
                Console.WriteLine(m.Message);
            }

            //Add entities
            Console.WriteLine();
            Console.WriteLine("########################################");
            Console.WriteLine("Check for aadd entities.");
            foreach (var book in books)
            {
                bookListService.AddBook(book);
                Console.WriteLine(book);
            }

            //Find by tag string
            Console.WriteLine();
            Console.WriteLine("########################################");
            Console.WriteLine("Find by tag string.");
            var tmpFindBookByString = bookListService.FindBookByTag((BookListService.TegFind.Publishing), "Питер".ToUpper());
            foreach (var book in tmpFindBookByString)
            {
                Console.WriteLine(book.ToString("2", null));
            }

            //Find by tag int
            Console.WriteLine("########################################");
            Console.WriteLine("Find by tag int.");
            var tmpFindBookByInt = bookListService.FindBookByTag((BookListService.TegFind.YearPublishing), 2016);
            foreach (var book in tmpFindBookByInt)
            {
                Console.WriteLine(book.ToString("3", null));
            }

            //Check for another type of search by teg.
            Console.WriteLine();
            Console.WriteLine("########################################");
            Console.WriteLine("Check for another type of search by teg.");
            try
            {
                var tmp = bookListService.FindBookByTag((BookListService.TegFind.YearPublishing), (decimal)44);
            }
            catch (Exception m)
            {
                Console.WriteLine(m.Message);
            }

            //Check remove book.
            Console.WriteLine();
            Console.WriteLine("########################################");
            Console.WriteLine("Check remove book.");
            bookListService.RemoveBook(books[0]);
            foreach (var book in bookListService.Books)
            {
                Console.WriteLine(book.ToString("4",null));
            }

            //Check remove by null.
            Console.WriteLine();
            Console.WriteLine("########################################");
            Console.WriteLine("Check remove by null.");
            try
            {
                bookListService.RemoveBook(null);
            }
            catch (Exception m)
            {
                Console.WriteLine(m.Message);
            }

            //Check add existing book.
            Console.WriteLine();
            Console.WriteLine("########################################");
            Console.WriteLine("Check add existing book.");
            try
            {
                foreach (var book in books)
                {
                    bookListService.AddBook(book);
                }
            }
            catch (Exception m)
            {
                Console.WriteLine(m.Message);
            }

            //Save collection in file.
            Console.WriteLine();
            Console.WriteLine("########################################");
            Console.WriteLine("Save collection in file and read.");
            bookListService.SaveToFile();


            //Read collection in file.
            Console.WriteLine();
            Console.WriteLine("########################################");
            Console.WriteLine("Save collection in file and read.");
            Console.WriteLine();
            foreach (var book in bookListService.Books)
            {
                Console.WriteLine(book.ToString("4", null));
            }           
            bookListService.RemoveBook(books[0]);
            bookListService.ReadFile();
            Console.WriteLine();
            foreach (var book in bookListService.Books)
            {
                Console.WriteLine(book.ToString("4", null));
            }


            //Save in collection new book.
            Console.WriteLine();
            Console.WriteLine("########################################");
            Console.WriteLine("Save in collection new book.");
            try
            {
                bookListService.AppendBookToFile(books[0]);
            }
            catch (Exception m)
            {
                Console.WriteLine(m.Message);
            }

            BookInfo book1 = new BookInfo
            {
                ISBN = "978-5-496-02092-6",
                Author = "Ма",
                BookTitle = "Идеальный программист",
                Publishing = "Питер",
                YearPublishing = 2016,
                NumberOfPages = 224,
                Price = 76.50M,
            };
            bookListService.AppendBookToFile(book1);
            Console.WriteLine();
            bookListService.ReadFile();
            Console.WriteLine();
            foreach (var book in bookListService.Books)
            {
                Console.WriteLine(book.ToString("4", null));
            }

            Console.ReadLine();
        }
    }
}
