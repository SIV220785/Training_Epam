using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2;

namespace testConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            int[][] array = new int[][] { new int[] { 1, 2, 3 }, new int[] { 4, 2 }, new[] { -10, 5, 20, 20 } };


            SortArray sortArray = new SortArray(array);
            sortArray.SortDescendingRowBySum();
            PrinArray(sortArray);
            Console.WriteLine();
            sortArray.SortAscendingRowBySum();
            PrinArray(sortArray);
            Console.WriteLine();
            sortArray.SortAscendingByMaxElemRow();
            PrinArray(sortArray);
            Console.WriteLine();
            sortArray.SortDescendingByMaxElemRow();
            PrinArray(sortArray);
            Console.WriteLine();
            sortArray.SortAscendingByMinElemRow();
            PrinArray(sortArray);
            Console.WriteLine();
            sortArray.SortDescendingByMinElemRow();
            PrinArray(sortArray);



            Console.ReadKey();
        }

        private static void PrinArray(SortArray sortArray)
        {
            string tmpStr = "";
            foreach (var item in sortArray.Matrix)
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
