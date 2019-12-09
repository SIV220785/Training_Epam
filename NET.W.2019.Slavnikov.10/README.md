1. Для объектов класса Book (ISBN, автор, название, издательство, год издания, количество страниц, цена) (домашнее задание 8-ого дня)
●	реализовать возможность строкового представления различного вида. Например, для объекта со значениями ISBN = 978-0-7356-6745-7, AuthorName  = Jeffrey Richter, Title = CLR via C#, Publisher = Microsoft Press, Year = 2012, NumberOPpages = 826, Price = 59.99$, могут быть следующие варианты:
-	Jeffrey Richter, CLR via C#
-	Jeffrey Richter, CLR via C#, "Microsoft Press", 2012
-	ISBN 13: 978-0-7356-6745-7, Jeffrey Richter, CLR via C#, "Microsoft Press", 2012, P. 826.
-	Jeffrey Richter, CLR via C#, "Microsoft Press", 2012
-	ISBN 13: 978-0-7356-6745-7, Jeffrey Richter, CLR via C#, "Microsoft Press", 2012, P. 826., 59.99$.
и т.д. 
2. Не изменяя класс Book, добавить для объектов данного класса дополнительную возможность форматирования, изначально не предусмотренную классом. 
<a href="https://github.com/SIV220785/Training_Epam/tree/master/NET.W.2019.Slavnikov.10/Book.DLL">Bool.DLL</a>
3. Для реализованных в пп. 1, 2 функциональностей разработать модульные тесты.
<a href = "https://github.com/SIV220785/Training_Epam/tree/master/NET.W.2019.Slavnikov.10/TestBookFormat">TestBook</a>
4. Выполнить рефакторинг класса (с целью сокращения повторного кода) в алгоритмах Евклида (для рефакторинга использовать делегаты, рефакторинг возможен только в случае, когда все метод находятся в одном классе!). Интерфейс класса измениться не должен.
<a href="https://github.com/SIV220785/Training_Epam/tree/master/NET.W.2019.Slavnikov.10/EuclidAlgorithms.DLL">EuclidAlgorithms.DLL</a>

