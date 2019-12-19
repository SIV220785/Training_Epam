using Matrices.DLL;
using NUnit.Framework;
using System;

namespace TestMatrix
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void CreateNewMatrix_WithZeroOrNegativeSize_ThrowsException()
        {
            Assert.Throws<ArgumentException>(() => new SquareMatrix<short>(0));
            Assert.Throws<ArgumentException>(() => new SquareMatrix<int>(-20));
            Assert.Throws<ArgumentException>(() => new SymmetricalMatrix<double>(0));
            Assert.Throws<ArgumentException>(() => new SymmetricalMatrix<float>(-20));
            Assert.Throws<ArgumentException>(() => new DiagonalMatrix<char>(0));
            Assert.Throws<ArgumentException>(() => new DiagonalMatrix<string>(-20));
            Assert.Throws<ArgumentException>(() => new DiagonalMatrix<decimal>(-20));
            Assert.Throws<ArgumentException>(() => new DiagonalMatrix<bool>(-20));
        }

        [Test]
        public void CreateSquareMatrix_FromNonSquareArray_ThrowsException()
        {
            var array = new int[,] { { 1, 1, 1 }, { 1, 1, 1 }, { 1, 1, 1 }, { 1, 1, 1 } };
            Assert.Throws<ArgumentException>(() => new SquareMatrix<int>(array));
        }

        [Test]
        public void CreateDiagonalMatrix_FromNonSquareArray_ThrowsException()
        {
            var array = new int[,] { { 1, 0, 0 }, { 0, 1, 0 }, { 0, 1, 1 } };
            Assert.Throws<ArgumentException>(() => new DiagonalMatrix<int>(array));
        }

        [Test]
        public void CreateSymmetricalMatrix_FromNonSquareArray_ThrowsException()
        {
            var array = new int[,] { { 1, 1, 2 }, { 1, 1, 3 }, { 2, 4, 1 } };
            Assert.Throws<ArgumentException>(() => new SymmetricalMatrix<int>(array));
        }

        [Test]
        public void MatrixHierarchyAdditionTest1()
        {
            var array1 = new int[,] { { 5, 6, -3 }, { 17, 7, 0 }, { 8, -5, 4 } };
            var array2 = new int[,] { { 2, 3, 0 }, { 6, 11, 1 }, { 3, 3, 7 } };
            var resultArray = new int[,] { { 7, 9, -3 }, { 23, 18, 1 }, { 11, -2, 11 } };
            var matrixA = new SquareMatrix<int>(array1);
            var matrixB = new SquareMatrix<int>(array2);
            var sum = MatrixExtension<int>.Addition(matrixA, matrixB);
            CollectionAssert.AreEqual(resultArray, sum.GetMatrix());
        }

        [Test]
        public void MatrixHierarchyAdditionTest2()
        {
            var array1 = new int[,] { { 1, 0, 0 }, {0, 1, 0 }, { 0, 0, 1 } };
            var array2 = new int[,] { { 0, -3, 0 }, {-3, 0, 100 }, { 0, 100, 50 } };
            var resultArray = new int[,] { { 1, -3, 0 }, { -3, 1, 100 }, { 0, 100, 51 } };
            DiagonalMatrix<int> matrixA = new DiagonalMatrix<int>(array1);
            SymmetricalMatrix<int> matrixB = new SymmetricalMatrix<int>(array2);
            
            var sum = MatrixExtension<int>.Addition(matrixA, matrixB);
            CollectionAssert.AreEqual(resultArray, sum.GetMatrix());
        }

    }
}