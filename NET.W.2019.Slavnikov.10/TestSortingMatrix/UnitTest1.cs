using MatrixSorting.DLL;
using MatrixSorting.DLL.Sorting;
using NUnit.Framework;
using System;

namespace TestSortMatrix
{
    [TestFixture]
    public class Tests
    {


        [TestCase(null)]
        public void BubbleSortTest_AcceptsEmptyArray_ThrowsException(int[][] array)
        {
            Assert.Throws<ArgumentNullException>(() => SortArray.BubbleSort(array, new SortAscendingByMaxElemRow()));
        }

        [Test]
        public void BubbleSortTest_AcceptsArrayLength_ThrowsException()
        {
            int[][] array1 = new int[1][];
            int[][] array2 = new int[1][];
            int[][] array3 = new int[][] { };
            int[][] array4 = new int[][] { };
            SortArray.BubbleSort(array1, new SortDescendingByMaxElemRow());
            SortArray.BubbleSort(array3, new SortAscendingRowBySum());
            CollectionAssert.AreEquivalent(array1, array2);
            CollectionAssert.AreEquivalent(array3, array4);
        }

        [Test]
        public void BubbleSortByMax_Descending_Test()
        {

            int[][] array1 = new int[][] { new int[] { 5, 12, -3 }, new int[] { 0, 3 }, new int[] { 7, 8, 9, 7 } };
            int[][] sorted = new int[][] { new int[] { 0, 3 }, new int[] { 5, 12, -3 }, new int[] { 7, 8, 9, 7 } };
            SortArray.BubbleSort(array1, new SortDescendingByMaxElemRow());
            CollectionAssert.AreEquivalent(sorted, array1);
        }

        [Test]
        public void BubbleSortByMaxDescending_UsingDelegate_Test()
        {

            int[][] array1 = new int[][] { new int[] { 5, 12, -3 }, new int[] { 0, 3 }, new int[] { 7, 8, 9, 7 } };
            int[][] sorted = new int[][] { new int[] { 0, 3 }, new int[] { 5, 12, -3 }, new int[] { 7, 8, 9, 7 } };
            var comparer = new AdapterForDelegate(new SortDescendingByMaxElemRow().Compare);

            SortArray.BubbleSort(array1, new SortDescendingByMaxElemRow());
            CollectionAssert.AreEquivalent(sorted, array1);
        }

        [Test]
        public void BubbleSortByMax_Ascending_Test()
        {

            int[][] array1 = new int[][] { new int[] { 5, 12, -3 }, new int[] { 0, 3 }, new int[] { 7, 8, 9, 7 } };
            int[][] sorted = new int[][] { new int[] { 7, 8, 9, 7 }, new int[] { 5, 12, -3 }, new int[] { 0, 3 } };
            SortArray.BubbleSort(array1, new SortAscendingByMaxElemRow());
            CollectionAssert.AreEquivalent(sorted, array1);
        }

        [Test]
        public void BubbleSortByMax_Ascending_UsingDelegate_Test()
        {

            int[][] array1 = new int[][] { new int[] { 5, 12, -3 }, new int[] { 0, 3 }, new int[] { 7, 8, 9, 7 } };
            int[][] sorted = new int[][] { new int[] { 7, 8, 9, 7 }, new int[] { 5, 12, -3 }, new int[] { 0, 3 } };
            var comparer = new AdapterForDelegate(new SortAscendingByMaxElemRow().Compare);

            SortArray.BubbleSort(array1, new SortAscendingByMaxElemRow());
            CollectionAssert.AreEquivalent(sorted, array1);
        }

        [Test]
        public void BubbleSortByMin_Ascending_Test()
        {

            int[][] array1 = new int[][] { new int[] { 5, 12, -3 }, new int[] { 0, 3 }, new int[] { 7, 8, 9, 7 } };
            int[][] sorted = new int[][] { new int[] { 0, 3 }, new int[] { 5, 12, -3 }, new int[] { 7, 8, 9, 7 } };
            SortArray.BubbleSort(array1, new SortAscendingByMinElemRow());
            CollectionAssert.AreEquivalent(sorted, array1);
        }

        [Test]
        public void BubbleSortByMin_Ascending_UsingDelegate_Test()
        {

            int[][] array1 = new int[][] { new int[] { 5, 12, -3 }, new int[] { 0, 3 }, new int[] { 7, 8, 9, 7 } };
            int[][] sorted = new int[][] { new int[] { 0, 3 }, new int[] { 5, 12, -3 }, new int[] { 7, 8, 9, 7 } };
            var comparer = new AdapterForDelegate(new SortAscendingByMinElemRow().Compare);

            SortArray.BubbleSort(array1, new SortAscendingByMinElemRow());
            CollectionAssert.AreEquivalent(sorted, array1);
        }

        [Test]
        public void BubbleSortByMin_Descending_Test()
        {

            int[][] array1 = new int[][] { new int[] { 5, 12, -3 }, new int[] { 0, 3 }, new int[] { 7, 8, 9, 7 } };
            int[][] sorted = new int[][] { new int[] { 7, 8, 9, 7 }, new int[] { 5, 12, -3 }, new int[] { 0, 3 } };
            SortArray.BubbleSort(array1, new SortDescendingByMinElemRow());
            CollectionAssert.AreEquivalent(sorted, array1);
        }

        [Test]
        public void BubbleSortByMinDescending_UsingDelegate_Test()
        {

            int[][] array1 = new int[][] { new int[] { 5, 12, -3 }, new int[] { 0, 3 }, new int[] { 7, 8, 9, 7 } };
            int[][] sorted = new int[][] { new int[] { 7, 8, 9, 7 }, new int[] { 5, 12, -3 }, new int[] { 0, 3 } };
            var comparer = new AdapterForDelegate(new SortDescendingByMinElemRow().Compare);

            SortArray.BubbleSort(array1, new SortDescendingByMinElemRow());
            CollectionAssert.AreEquivalent(sorted, array1);
        }

        [Test]
        public void BubbleSortBySum_Descending_Test()
        {

            int[][] array1 = new int[][] { new int[] { 5, 12, -3 }, new int[] { 0, 3 }, new int[] { 7, 8, 9, 7 } };
            int[][] sorted = new int[][] { new int[] { 7, 8, 9, 7 }, new int[] { 5, 12, -3 }, new int[] { 0, 3 } };
            SortArray.BubbleSort(array1, new SortDescendingRowBySum());
            CollectionAssert.AreEquivalent(sorted, array1);
        }

        [Test]
        public void BubbleSortBySumDescending_UsingDelegate_Test()
        {

            int[][] array1 = new int[][] { new int[] { 5, 12, -3 }, new int[] { 0, 3 }, new int[] { 7, 8, 9, 7 } };
            int[][] sorted = new int[][] { new int[] { 7, 8, 9, 7 }, new int[] { 5, 12, -3 }, new int[] { 0, 3 } };
            var comparer = new AdapterForDelegate(new SortDescendingRowBySum().Compare);

            SortArray.BubbleSort(array1, new SortDescendingRowBySum());
            CollectionAssert.AreEquivalent(sorted, array1);
        }

        [Test]
        public void BubbleSortBySum_Ascending_Test()
        {

            int[][] array1 = new int[][] { new int[] { 5, 12, -3 }, new int[] { 0, 3 }, new int[] { 7, 8, 9, 7 } };
            int[][] sorted = new int[][] { new int[] { 7, 8, 9, 7 }, new int[] { 5, 12, -3 }, new int[] { 0, 3 } };
            SortArray.BubbleSort(array1, new SortDescendingRowBySum());
            CollectionAssert.AreEquivalent(sorted, array1);
        }

        [Test]
        public void BubbleSortBySum_Ascending_UsingDelegate_Test()
        {

            int[][] array1 = new int[][] { new int[] { 5, 12, -3 }, new int[] { 0, 3 }, new int[] { 7, 8, 9, 7 } };
            int[][] sorted = new int[][] { new int[] { 0, 3 }, new int[] { 5, 12, -3 }, new int[] { 7, 8, 9, 7 } };
            var comparer = new AdapterForDelegate(new SortDescendingRowBySum().Compare);

            SortArray.BubbleSort(array1, new SortDescendingRowBySum());
            CollectionAssert.AreEquivalent(sorted, array1);
        }

    }
}