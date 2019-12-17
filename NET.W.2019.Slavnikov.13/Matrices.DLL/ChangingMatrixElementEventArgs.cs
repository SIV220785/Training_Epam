using System;

namespace Matrices.DLL
{
    /// <summary>
    /// Information , which is passed to the subscribers of the event notification.
    /// </summary>
    /// <typeparam name="T"> Parameter type.</typeparam>
    public class ChangingMatrixElementEventArgs<T> : EventArgs
    {
        private readonly int indexI;
        private readonly int indexJ;

        /// <summary>
        /// Initializes a new instance of the <see cref="ChangingMatrixElementEventArgs{T}"/> class.
        /// </summary>
        /// <param name="i">Index i of square matrix.</param>
        /// <param name="j">Index j of square matrix.</param>
        public ChangingMatrixElementEventArgs(int i, int j)
        {
            this.indexI = i;
            this.indexJ = j;
        }

        /// <summary>
        /// Gets index i of square matrix.
        /// </summary>
        /// <value>
        /// Index i of square matrix.
        /// </value>
        public int IndexJ => this.indexJ;

        /// <summary>
        /// Gets index j of square matrix.
        /// </summary>
        /// <value>
        /// Index j of square matrix.
        /// </value>
        public int IndexI => this.indexI;
    }
}
