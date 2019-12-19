using System;

namespace Matrices.DLL
{
    /// <summary>
    /// Class that expand the functionality of Matrix Hierarchy.
    /// </summary>
    /// <typeparam name="T">Parameter type.</typeparam>
    public static class MatrixExtension<T>
        where T : IComparable<T>
    {
        public static SquareMatrix<T> Addition(SquareMatrix<T> matrixA, SquareMatrix<T> matrixB)
        {
            if (matrixA is null)
            {
                throw new ArgumentNullException(nameof(matrixA));
            }

            var newMatrix = new SquareMatrix<T>(matrixA.Size);
            for (int i = 0; i < matrixB.Size; i++)
            {
                for (int j = 0; j < matrixB.Size; j++)
                {
                    newMatrix[i, j] = (dynamic)matrixA[i, j] + (dynamic)matrixB[i, j];
                }
            }

            return newMatrix;
        }

        public static SquareMatrix<T> Addition(SquareMatrix<T> matrixA, DiagonalMatrix<T> matrixB)
        {
            if (matrixA is null)
            {
                throw new ArgumentNullException(nameof(matrixA));
            }

            if (matrixB is null)
            {
                throw new ArgumentNullException(nameof(matrixB));
            }

            var newMatrix = new SquareMatrix<T>(matrixA.Size);
            for (int i = 0; i < matrixB.Size; i++)
            {
                for (int j = 0; j < matrixB.Size; j++)
                {
                    if (i == j)
                    {
                        newMatrix[i, j] = (dynamic)matrixA[i, j] + (dynamic)matrixB[i, j];
                    }
                    else
                    {
                        newMatrix[i, j] = matrixA[i, j];
                    }
                }
            }

            return newMatrix;
        }

        public static SquareMatrix<T> Addition(DiagonalMatrix<T> matrixA, SquareMatrix<T> matrixB)
        {
            if (matrixA is null)
            {
                throw new ArgumentNullException(nameof(matrixA));
            }

            if (matrixB is null)
            {
                throw new ArgumentNullException(nameof(matrixB));
            }

            var newMatrix = new SquareMatrix<T>(matrixA.Size);
            for (int i = 0; i < matrixB.Size; i++)
            {
                for (int j = 0; j < matrixB.Size; j++)
                {
                    if (i == j)
                    {
                        newMatrix[i, j] = (dynamic)matrixA[i, j] + (dynamic)matrixB[i, j];
                    }
                    else
                    {
                        newMatrix[i, j] = matrixB[i, j];
                    }
                }
            }

            return newMatrix;
        }

        public static SquareMatrix<T> Addition(SquareMatrix<T> matrixA, SymmetricalMatrix<T> matrixB)
        {
            if (matrixA is null)
            {
                throw new ArgumentNullException(nameof(matrixA));
            }

            if (matrixB is null)
            {
                throw new ArgumentNullException(nameof(matrixB));
            }

            var newMatrix = new SquareMatrix<T>(matrixA.Size);
            for (int i = 0; i < matrixB.Size; i++)
            {
                for (int j = 0; j < matrixB.Size; j++)
                {
                    newMatrix[i, j] = (dynamic)matrixA[i, j] + (dynamic)matrixB[i, j];
                }
            }

            return newMatrix;
        }

        public static SquareMatrix<T> Addition(SymmetricalMatrix<T> matrixA, SquareMatrix<T> matrixB)
        {
            if (matrixA is null)
            {
                throw new ArgumentNullException(nameof(matrixA));
            }

            if (matrixB is null)
            {
                throw new ArgumentNullException(nameof(matrixB));
            }

            var newMatrix = new SquareMatrix<T>(matrixA.Size);
            for (int i = 0; i < matrixB.Size; i++)
            {
                for (int j = 0; j < matrixB.Size; j++)
                {
                    newMatrix[i, j] = (dynamic)matrixA[i, j] + (dynamic)matrixB[i, j];
                }
            }

            return newMatrix;
        }

        public static SymmetricalMatrix<T> Addition(SymmetricalMatrix<T> matrixA, SymmetricalMatrix<T> matrixB)
        {
            if (matrixA is null)
            {
                throw new ArgumentNullException(nameof(matrixA));
            }

            if (matrixB is null)
            {
                throw new ArgumentNullException(nameof(matrixB));
            }

            var newMatrix = new SymmetricalMatrix<T>(matrixA.Size);
            for (int i = 0; i < matrixB.Size; i++)
            {
                for (int j = 0; j < matrixB.Size; j++)
                {
                    newMatrix[i, j] = (dynamic)matrixA[i, j] + (dynamic)matrixB[i, j];
                }
            }

            return newMatrix;
        }

        public static SymmetricalMatrix<T> Addition(SymmetricalMatrix<T> matrixA, DiagonalMatrix<T> matrixB)
        {
            if (matrixA is null)
            {
                throw new ArgumentNullException(nameof(matrixA));
            }

            if (matrixB is null)
            {
                throw new ArgumentNullException(nameof(matrixB));
            }

            var newMatrix = new SymmetricalMatrix<T>(matrixA.Size);
            for (int i = 0; i < matrixB.Size; i++)
            {
                for (int j = 0; j < matrixB.Size; j++)
                {
                    if (i == j)
                    {
                        newMatrix[i, j] = (dynamic)matrixA[i, j] + (dynamic)matrixB[i, j];
                    }
                    else
                    {
                        newMatrix[i, j] = matrixA[i, j];
                    }
                }
            }

            return newMatrix;
        }

        public static SquareMatrix<T> Addition(DiagonalMatrix<T> matrixA, SymmetricalMatrix<T> matrixB)
        {
            if (matrixA is null)
            {
                throw new ArgumentNullException(nameof(matrixA));
            }

            if (matrixB is null)
            {
                throw new ArgumentNullException(nameof(matrixB));
            }

            var newMatrix = new SymmetricalMatrix<T>(matrixA.Size);
            for (int i = 0; i < matrixB.Size; i++)
            {
                for (int j = 0; j < matrixB.Size; j++)
                {
                    if (i == j)
                    {
                        newMatrix[i, j] = (dynamic)matrixA[i, j] + (dynamic)matrixB[i, j];
                    }
                    else
                    {
                        newMatrix[i, j] = matrixB[i, j];
                    }
                }
            }

            return newMatrix;
        }

        public static DiagonalMatrix<T> Addition(DiagonalMatrix<T> matrixA, DiagonalMatrix<T> matrixB)
        {
            if (matrixA is null)
            {
                throw new ArgumentNullException(nameof(matrixA));
            }

            if (matrixB is null)
            {
                throw new ArgumentNullException(nameof(matrixB));
            }

            var newMatrix = new DiagonalMatrix<T>(matrixA.Size);
            for (int i = 0; i < matrixB.Size; i++)
            {
                for (int j = 0; j < matrixB.Size; j++)
                {
                    if (i == j)
                    {
                        newMatrix[i, j] = (dynamic)matrixA[i, j] + (dynamic)matrixB[i, j];
                    }
                    else
                    {
                        newMatrix[i, j] = default;
                    }
                }
            }

            return newMatrix;
        }
    }
}
