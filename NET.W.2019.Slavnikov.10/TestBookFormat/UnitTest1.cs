using Book.DLL.Entities;
using NUnit.Framework;

namespace TestBookFormat
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void BookTest()
        {
            BookInfo bookInfo = new BookInfo() { ISBN = "978-0-7356-6745-7", Author = "Jeffrey Richter", BookTitle = "CLR via C#",
                Publishing = "Microsoft Press", YearPublishing = 2012, NumberOfPages = 826, Price = 59.99M};
            string format1 = "Book: CLR via C#, Author: Jeffrey Richter.";
            string format2 = "ISBN: 978-0-7356-6745-7, Book: CLR via C#, Author: Jeffrey Richter.";
            string format3 = "ISBN: 978-0-7356-6745-7, Book: CLR via C#, Author: Jeffrey Richter, Publishing: Microsoft Press.";
            string format4 = "ISBN: 978-0-7356-6745-7, Book: CLR via C#, Author: Jeffrey Richter, Publishing: Microsoft Press, " +
                "The year of publishing: 2012.";
            string format5 = "ISBN: 978-0-7356-6745-7, Book: CLR via C#, Author: Jeffrey Richter, Publishing: Microsoft Press, " +
                "The year of publishing: 2012, The number of pages: 826.";
            string format6 = "ISBN: 978-0-7356-6745-7, Book: CLR via C#, Author: Jeffrey Richter, Publishing: Microsoft Press, " +
                "The year of publishing: 2012, The number of pages: 826, Price: 59,99.";


            Assert.AreEqual(format1, bookInfo.ToString("1", null));
            Assert.AreEqual(format2, bookInfo.ToString("2", null));
            Assert.AreEqual(format3, bookInfo.ToString("3", null));
            Assert.AreEqual(format4, bookInfo.ToString("4", null));
            Assert.AreEqual(format5, bookInfo.ToString("5", null));
            Assert.AreEqual(format6, bookInfo.ToString("6", null));


        }
    }
}