using System;

namespace Matrices.DLL
{
    /// <summary>
    /// Describes square matrix of T type elements and event.
    /// </summary>
    /// <typeparam name="T"> Parameter type.</typeparam>
    public class SquareMatrix<T> : IMatrix<T>
    {
        private T[,] squareMatrix;

        /// <summary>
        /// Initializes a new instance of the <see cref="SquareMatrix{T}"/> class.
        /// </summary>
        public SquareMatrix()
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SquareMatrix{T}"/> class.
        /// </summary>
        /// <param name="sideOfMatrix"> Rank matrix.</param>
        public SquareMatrix(int sideOfMatrix)
        {
            if (sideOfMatrix <= 0)
            {
                throw new ArgumentException($"{nameof(sideOfMatrix)} must be greater than 0.");
            }

            this.Size = sideOfMatrix;
            this.squareMatrix = new T[this.Size, this.Size];
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SquareMatrix{T}"/> class.
        /// Constructor for creating instance of Square matrix from accepted array.
        /// </summary>
        /// <param name="array"> Square array.</param>
        public SquareMatrix(T[,] array)
        {
            if (array is null)
            {
                throw new ArgumentNullException(nameof(array));
            }

            if (this.IsArraySquare(array))
            {
                this.squareMatrix = new T[array.GetLength(0), array.GetLength(0)];
                for (int i = 0; i < array.GetLength(0); i++)
                {
                    for (int j = 0; j < array.GetLength(1); j++)
                    {
                        this.squareMatrix[i, j] = array[i, j];
                    }
                }

                this.Size = array.GetLength(0);
            }
            else
            {
                throw new ArgumentException("Array is not square");
            }
        }

        /// <inheritdoc/>
        public virtual event IMatrix<T>.ChangingMatrixElementEventHandler Changing;

        /// <inheritdoc/>
        public virtual int Size { get; }

        /// <inheritdoc/>
        public virtual T this[int i, int j]
        {
            get
            {
                this.IndicesValidation(i, j);
                return this.squareMatrix[i, j];
            }

            set
            {
                this.IndicesValidation(i, j);
                this.squareMatrix[i, j] = value;
                this.OnChanging(this, new ChangingMatrixElementEventArgs<T>(i, j));
            }
        }

        /// <inheritdoc/>
        public virtual T[,] GetMatrix() => this.squareMatrix;

        /// <summary>
        /// Virtual event trigger method.
        /// </summary>
        /// <param name="sender">Name of event broadcaster.</param>
        /// <param name="e">Information about event.</param>
        protected virtual void OnChanging(object sender, ChangingMatrixElementEventArgs<T> e) => this.Changing?.Invoke(sender, e);

        /// <summary>
        /// Virtual method validation params matrix.
        /// </summary>
        /// <param name="i">Index i of square matrix.</param>
        /// <param name="j">Index j of square matrix.</param>
        protected virtual void IndicesValidation(int i, int j)
        {
            if (i < 0 || j < 0 || i >= this.squareMatrix.Length || j >= this.squareMatrix.Length)
            {
                throw new ArgumentOutOfRangeException($"Index cannot be less than zero or more than actual matrix length.");
            }
        }

        private bool IsArraySquare(T[,] array)
        {
            if (array.GetLength(0) != array.GetLength(1))
            {
                return false;
            }

            return true;
        }
    }
}
