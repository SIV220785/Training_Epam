using System;
using System.Collections.Generic;
using static TasksDay2.Task2;

namespace TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Task2");
            var temp = FindNextBiggerNumber(101);
            Console.WriteLine(temp);
            Console.WriteLine();

            Console.WriteLine("Task3");
            var temp1 = TasksDay2.Task3.FindNextBiggerNumber(10);
            Console.WriteLine(temp1);
            Console.WriteLine();

            Console.WriteLine("Task4");
            List<int> listNumbers = new List<int>() {7, 1, 2, 3, 4, 5, 6, 7, 68, 69, 70, 15, 17 };
            var task4 = TasksDay2.Task4.FilterDigit(7, listNumbers);
            foreach (var item in task4)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();

            Console.WriteLine("Task4");
            var task5 = TasksDay2.Task5.FindNthRoot(1, 5, 0.0001);
            Console.WriteLine(task5);
            Console.ReadKey();


        }
    }
}
