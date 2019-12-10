using System;
using System.Linq;

namespace MatrixSorting.DLL.Sorting
{
    /// <summary>
    /// ...
    /// </summary>
    public class SortAscendingByMaxElemRow : IArrayCompare
    {
        /// <inheritdoc/>
        public int Compare(int[] arrayA, int[] arrayB)
        {
            if (arrayA is null)
            {
                throw new ArgumentNullException(nameof(arrayA));
            }

            if (arrayB is null)
            {
                throw new ArgumentNullException(nameof(arrayB));
            }

            return arrayA.Max() - arrayB.Max();
        }
    }
}
