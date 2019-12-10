using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixSorting.DLL
{
    /// <summary>
    /// Basic matrix sorting methods.
    /// </summary>
    public interface ISortArray
    {
        /// <summary>
        /// Sorting in ascending order of the sum of the elements of the matrix rows.
        /// </summary>
        /// <param name="matrix"> Source matix.</param>
        public void SortAscendingRowBySum(ref int[][] matrix);

        /// <summary>
        /// Sorting in descending order of the sum of the elements of the rows of the matrix.
        /// </summary>
        /// <param name="matrix"> Source matix.</param>
        public void SortDescendingRowBySum(ref int[][] matrix);

        /// <summary>
        /// Sin ascending order of the maximum elements of the rows of the matrix.
        /// </summary>
        /// <param name="matrix"> Source matix.</param>
        public void SortAscendingByMaxElemRow(ref int[][] matrix);

        /// <summary>
        /// Sin descending order of the maximum elements of the rows of the matrix.
        /// </summary>
        /// <param name="matrix"> Source matix.</param>
        public void SortDescendingByMaxElemRow(ref int[][] matrix);

        /// <summary>
        /// Sin ascending order of the minimum elements of the rows of the matrix.
        /// </summary>
        /// <param name="matrix"> Source matix.</param>
        public void SortAscendingByMinElemRow(ref int[][] matrix);

        /// <summary>
        /// Sin descending order of the minimum elements of the rows of the matrix.
        /// </summary>
        /// <param name="matrix"> Source matix.</param>
        public void SortDescendingByMinElemRow(ref int[][] matrix);
    }
}
