using System;

namespace Matrices.DLL
{
    /// <summary>
    /// Abstract class BaseMatrix.
    /// </summary>
    /// <typeparam name="T"> Parameter type.</typeparam>
    internal abstract class BaseMatrix<T>
    {
        private int size;
        private T[,] baseMatrix;

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseMatrix{T}"/> class.
        /// Constructor without parameters.
        /// </summary>
        public BaseMatrix()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseMatrix{T}"/> class.
        /// Base constructor for matrix types.
        /// </summary>
        /// <param name="size"> Matrix rank.</param>
        public BaseMatrix(int size)
        {
            if (size <= 0)
            {
                throw new ArgumentException($"{nameof(size)} must be greater than 0.");
            }

            this.size = size;
            this.baseMatrix = new T[this.size, this.size];
        }

        /// <summary>
        /// Delegate for handling event.
        /// </summary>
        /// <param name="sender"> Name of event broadcaster.</param>
        /// <param name="e"> Information about event.</param>
        public delegate void ChangingMatrixElementEventHandler(object sender, ChangingMatrixElementEventArgs<T> e);

        /// <summary>
        /// Event member
        /// </summary>
        public event ChangingMatrixElementEventHandler Changing;

        /// <summary>
        /// Gets size of square matrix.
        /// </summary>
        /// <value>
        /// Size of square matrix.
        /// </value>
        public virtual int Size => this.size;

        /// <summary>
        /// Indexer for Square matrix, also initiates event and sends information in it.
        /// </summary>
        /// <param name="i">Index i of square matrix.</param>
        /// <param name="j">Index j of square matrix.</param>
        /// <returns>Access to matrix elements by indices.</returns>
        public virtual T this[int i, int j]
        {
            get
            {
                this.IndicesValidation(i, j);
                return this.baseMatrix[i, j];
            }

            set
            {
                this.IndicesValidation(i, j);
                this.baseMatrix[i, j] = value;
                this.OnChanging(this, new ChangingMatrixElementEventArgs<T>(i, j));
            }
        }

        protected virtual void OnChanging(object sender, ChangingMatrixElementEventArgs<T> e) => this.Changing?.Invoke(sender, e);

        protected abstract void IndicesValidation(int i, int j);
    }
}
