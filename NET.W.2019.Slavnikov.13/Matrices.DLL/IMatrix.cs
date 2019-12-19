using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrices.DLL
{
    /// <summary>
    /// Interface of square matrix types.
    /// </summary>
    /// <typeparam name="T"> Parameter type.</typeparam>
    public interface IMatrix<T>
    {
        /// <summary>
        /// Delegate for handling event.
        /// </summary>
        /// <param name="sender">Name of event broadcaster.</param>
        /// <param name="e">Information about event.</param>
        public delegate void ChangingMatrixElementEventHandler(object sender, ChangingMatrixElementEventArgs<T> e);

        /// <summary>
        /// Event member.
        /// </summary>
        public event ChangingMatrixElementEventHandler Changing;

        /// <summary>
        /// Gets size of square matrix.
        /// </summary>
        /// <value>
        /// Size of square matrix.
        /// </value>
        public int Size { get; }

        /// <summary>
        /// Indexer for Square matrix, also initiates event and sends information in it.
        /// </summary>
        /// <param name="i">Index i of square matrix.</param>
        /// <param name="j">Index j of square matrix.</param>
        /// <returns>Access to matrix elements by indices.</returns>
        public T this[int i, int j] { get; set; }

        /// <summary>
        /// Gets size of square matrix.
        /// </summary>
        /// <returns> Matrix.</returns>
        public T[,] GetMatrix();
    }
}
