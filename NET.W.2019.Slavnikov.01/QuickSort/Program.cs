using ArraySorting;
using System;

namespace QuickSort
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = new int[5] { 6, 4, 2, 5, 7 };
            int[] arr2 = new int[8] { 6, 4, 2, 5, 7, 0, 1, 3 };

            arr.QuaickSort();
            arr2.MergeSort();

            Console.WriteLine("QuackSort:");

            foreach (var item in arr)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine();
            Console.WriteLine("MergeSort:");

            foreach (var item in arr2)
            {
                Console.WriteLine(item);
            }
            Console.ReadLine();
        }


    }


}
