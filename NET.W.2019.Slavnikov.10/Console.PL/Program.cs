using MatrixSorting.DLL;

namespace Console.PL
{
    using MatrixSorting.DLL.Sorting;
    using System;
    class Program
    {
        private static int[][] array = new int[][] { new int[] { 5, 12, -3 }, new int[] { 0, 3, 14 }, new int[] { 7, 8, 9 } };
        private static int[][] array1 = new int[][] { new int[] { 5, 12, -3 }, new int[] { 0, 3, 14 }, new int[] { 7, 8, 9 } };
        static void Main()
        {
            SortArray sortArray = new SortArray();

            Console.WriteLine("1");
            sortArray.SortAscendingRowBySum(ref array);
            PrinArray(array);
            Console.WriteLine();

            Console.WriteLine("2");
            sortArray.SortDescendingRowBySum(ref array);
            PrinArray(array);
            Console.WriteLine();

            Console.WriteLine("3");
            sortArray.SortAscendingByMinElemRow(ref array);
            PrinArray(array);
            Console.WriteLine();

            Console.WriteLine("4");
            sortArray.SortDescendingByMinElemRow(ref array);
            PrinArray(array);
            Console.WriteLine();

            Console.WriteLine("5");
            sortArray.SortAscendingByMaxElemRow(ref array);
            PrinArray(array);
            Console.WriteLine();

            Console.WriteLine("6");
            sortArray.SortDescendingByMaxElemRow(ref array);
            PrinArray(array);           
            PrinArray(SortArray.BubbleSort(array1, new SortDescendingByMaxElemRow()));
            Console.WriteLine();


            Console.ReadKey();

        }

        private static void PrinArray(int[][] array)
        {
            string tmpStr = "";
            foreach (var item in array)
            {
                for (int i = 0; i < item.Length; i++)
                {
                    tmpStr += $"{item[i].ToString()} ";
                }
                Console.WriteLine(tmpStr);
                tmpStr = "";
            }
        }
    }

    
}
