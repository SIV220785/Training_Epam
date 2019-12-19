using System;

namespace Matrices.DLL
{
    /// <summary>
    /// Class that describes diagonal matrix of T type elements and event.
    /// </summary>
    /// <typeparam name="T"> Parameter type.</typeparam>
    public class DiagonalMatrix<T> : SquareMatrix<T>
        where T : IComparable<T>
    {
        private readonly int size;
        private readonly T[,] diagonalMatrix;

        /// <summary>
        /// Initializes a new instance of the <see cref="DiagonalMatrix{T}"/> class.
        /// Constructor for creating instance of Diagonal matrix by accepted rank.
        /// </summary>
        /// <param name="sideOfMatrix"> Matrix rank.</param>
        public DiagonalMatrix(int sideOfMatrix)
            : base(sideOfMatrix)
        {
            this.size = sideOfMatrix;
            this.diagonalMatrix = new T[this.size, this.size];
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DiagonalMatrix{T}"/> class.
        /// Constructor for creating instance of Diagonal matrix from accepted sz-array.
        /// </summary>
        /// <param name="array"> Accepted sz-array.</param>
        public DiagonalMatrix(T[,] array)
        {
            if (array is null)
            {
                throw new ArgumentNullException(nameof(array));
            }

            if (this.IsArrayDiagonal(array))
            {
                this.diagonalMatrix = new T[array.GetLength(0), array.GetLength(0)];
                for (int i = 0; i < array.GetLength(0); i++)
                {
                    for (int j = 0; j < array.GetLength(1); j++)
                    {
                        this.diagonalMatrix[i, j] = array[i, j];
                    }
                }

                this.size = array.GetLength(0);
            }
            else
            {
                throw new ArgumentException("Array is not diagonal");
            }
        }

        /// <inheritdoc/>
        public override int Size => this.size;

        /// <inheritdoc/>
        public override T this[int i, int j]
        {
            get
            {
                this.IndicesValidation(i, j);
                if (i == j)
                {
                    return this.diagonalMatrix[i, j];
                }
                else
                {
                    return default;
                }
            }

            set
            {
                this.IndicesValidation(i, j);
                if (i == j)
                {
                    this.diagonalMatrix[i, j] = value;
                    this.OnChanging(this, new ChangingMatrixElementEventArgs<T>(i, j));
                }
            }
        }

        /// <inheritdoc/>
        public override T[,] GetMatrix() => this.diagonalMatrix;

        private bool IsArrayDiagonal(T[,] array)
        {
            bool isDiagonal = true;
            for (int i = 0; i < array.GetLength(0); ++i)
            {
                for (int j = 0; j < array.GetLength(1); ++j)
                {

                    if (i == j)
                    {
                        continue;
                    }

                    if (0.CompareTo(array[i, j]) != 0)
                    {
                        isDiagonal = false;
                        break;
                    }
                }

                if (!isDiagonal)
                {
                    break;
                }
            }

            return isDiagonal;
        }
    }
}
