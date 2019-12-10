using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixSorting.DLL
{
    /// <summary>
    /// Comparing array elements.
    /// </summary>
    public interface IArrayCompare
    {
        /// <summary>
        /// Method for comparing array elements.
        /// </summary>
        /// <param name="a"> First element array.</param>
        /// <param name="b"> Second element array.</param>
        /// <returns> Positive integer if 1st is more than 2nd by comparison criterion, 0 if they are equivalent and if otherwise, negative integer.</returns>
        public int Compare(int[] a, int[] b);
    }
}
