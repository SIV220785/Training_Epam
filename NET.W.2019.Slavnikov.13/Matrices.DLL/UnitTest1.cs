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
            var squareMatrix = new int[,] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
            var diagonalMatrix = new int[,] { { 1, 0, 0 }, { 0, 1, 0 }, { 0, 0, 1 } };
            var symmetricalMatrix = new int[,] { { 1, 2, 3 }, { 2, 1, 4 }, { 3, 4, 1 } };

            var resultSquareSquare = new[,] { { 2, 4, 6 }, { 8, 10, 12 }, { 14, 16, 18 } };
            var resultSquareDiagonal = new[,] { { 2, 2, 3 }, { 4, 6, 6 }, { 7, 8, 10 } };
            var resultSquareSymmetrical = new[,] { { 2, 4, 6 }, { 6, 6, 10 }, { 10, 12, 10 } };

            var resultDiagonalDiagonal = new[,] { { 2, 0, 0 }, { 0, 2, 0 }, { 0, 0, 2 } };
            var resultDiagonalSquare = new[,] { { 2, 0, 0 }, { 0, 6, 0 }, { 0, 0, 10 } };
            var resultDiagonalSymmetrical = new[,] { { 2, 0, 0 }, { 0, 2, 0 }, { 0, 0, 2 } };

            var resultSymmetricalSymmetrical = new[,] { { 2, 4, 6 }, { 4, 2, 8 }, { 6, 8, 2 } };
            var resultSymmetricalSquare = new[,] { { 2, 4, 6 }, { 6, 6, 10 }, { 10, 12, 10 } };
            var resultSymmetricalDiagonal = new[,] { { 2, 2, 3 }, { 2, 2, 4 }, { 3, 4, 2 } };

            var matrixSquare = new SquareMatrix<int>(squareMatrix);
            var matrixDiagonal = new DiagonalMatrix<int>(diagonalMatrix);
            var matrixSymmetrical = new SymmetricalMatrix<int>(symmetricalMatrix);


            var sumSquareSquare = MatrixExtension<int>.Addition(matrixSquare, matrixSquare);
            var sumSquareDiagonal = MatrixExtension<int>.Addition(matrixSquare, matrixDiagonal);
            var sumSquareSymmetrical = MatrixExtension<int>.Addition(matrixSquare, matrixSymmetrical);

            var sumDiagonalDiagonal = MatrixExtension<int>.Addition(matrixDiagonal, matrixDiagonal);
            var sumDiagonalSquare = MatrixExtension<int>.Addition(matrixDiagonal, matrixSquare);
            var sumDiagonalSymmetrical = MatrixExtension<int>.Addition(matrixDiagonal, matrixSymmetrical);

            var sumSymmetricalSymmetrical = MatrixExtension<int>.Addition(matrixSymmetrical, matrixSymmetrical);
            var sumSymmetricalSquare = MatrixExtension<int>.Addition(matrixSymmetrical, matrixSquare);
            var sumSymmetricalDiagonal = MatrixExtension<int>.Addition(matrixSymmetrical, matrixDiagonal);

            CollectionAssert.AreEqual(resultSquareSquare, sumSquareSquare.GetMatrix());
            CollectionAssert.AreEqual(resultSquareDiagonal, sumSquareDiagonal.GetMatrix());
            CollectionAssert.AreEqual(resultSquareSymmetrical, sumSquareSymmetrical.GetMatrix());

            CollectionAssert.AreEqual(resultDiagonalDiagonal, sumDiagonalDiagonal.GetMatrix());
            CollectionAssert.AreEqual(resultDiagonalSquare, sumDiagonalSquare.GetMatrix());
            CollectionAssert.AreEqual(resultDiagonalSymmetrical, sumDiagonalSymmetrical.GetMatrix());

            CollectionAssert.AreEqual(resultSymmetricalSymmetrical, sumSymmetricalSymmetrical.GetMatrix());
            CollectionAssert.AreEqual(resultSymmetricalSquare, sumSymmetricalSquare.GetMatrix());
            CollectionAssert.AreEqual(resultSymmetricalDiagonal, sumSymmetricalDiagonal.GetMatrix());
        }

    }
}