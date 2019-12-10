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
        public void BubbleSortByMaxOfRowElementsDescendingTest()
        {
            int[][] array1 = new int[][] { new int[] { 5, 12, -3 }, new int[] { 0, 3, 14 }, new int[] { 7, 8, 9 } };
            int[][] sorted = new int[][] { new int[] { 0, 3, 14 }, new int[] { 5, 12, -3 }, new int[] { 7, 8, 9 } };
            SortArray.BubbleSort(array1, new SortDescendingByMaxElemRow());
            CollectionAssert.AreEquivalent(sorted, array1);
        }

    }
}