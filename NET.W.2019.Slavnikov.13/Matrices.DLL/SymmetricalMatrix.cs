using System;

namespace Matrices.DLL
{
    /// <summary>
    /// Class that describes symmetrical matrix of T type elements and event.
    /// </summary>
    /// <typeparam name="T">Parameter type.</typeparam>
    public class SymmetricalMatrix<T> : SquareMatrix<T>
        where T : IComparable<T>
    {
        private readonly int size;
        private readonly T[,] symmetricalMatrix;

        /// <summary>
        /// Initializes a new instance of the <see cref="SymmetricalMatrix{T}"/> class.
        /// </summary>
        /// <param name="sideOfMatrix">Matrix rank.</param>
        public SymmetricalMatrix(int sideOfMatrix)
            : base(sideOfMatrix)
        {
            if (sideOfMatrix <= 0)
            {
                throw new ArgumentException($"{nameof(sideOfMatrix)} must be greater than 0.");
            }

            this.size = sideOfMatrix;
            this.symmetricalMatrix = new T[this.size, this.size];
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SymmetricalMatrix{T}"/> class.
        /// </summary>
        /// <param name="array">Accepted symmetrical array.</param>
        public SymmetricalMatrix(T[,] array)
        {
            if (array is null)
            {
                throw new ArgumentNullException(nameof(array));
            }

            if (this.IsArraySymmetrical(array))
            {
                this.symmetricalMatrix = new T[array.GetLength(0), array.GetLength(0)];
                for (int i = 0; i < array.GetLength(0); i++)
                {
                    for (int j = 0; j < array.GetLength(1); j++)
                    {
                        this.symmetricalMatrix[i, j] = array[i, j];
                    }
                }

                this.size = array.GetLength(0);
            }
            else
            {
                throw new ArgumentException("Array is not symmetrical");
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
                return this.symmetricalMatrix[i, j];
            }

            set
            {
                this.IndicesValidation(i, j);
                this.symmetricalMatrix[i, j] = value;
                this.OnChanging(this, new ChangingMatrixElementEventArgs<T>(i, j));
            }
        }

        /// <inheritdoc/>
        public override T[,] GetMatrix() => this.symmetricalMatrix;

        private bool IsArraySymmetrical(T[,] array)
        {
            bool isSymm = true;
            for (int i = 0; i < array.GetLength(0); ++i)
            {
                for (int j = 0; j < array.GetLength(1); ++j)
                {

                    if (array[i, j].CompareTo(array[j, i]) != 0)
                    {
                        isSymm = false;
                        break;
                    }
                }

                if (!isSymm)
                {
                    break;
                }
            }

            return isSymm;
        }
    }
}
