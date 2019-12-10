using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixSorting.DLL
{
    /// <summary>
    /// Class for adapting delegate to interface.
    /// </summary>
    public class AdapterForDelegate : IArrayCompare
    {
        private Func<int[], int[], int> comparerDelegate;

        /// <summary>
        /// Initializes a new instance of the <see cref="AdapterForDelegate"/> class.
        /// </summary>
        /// <param name="comparer"> Accepted delegate.</param>
        public AdapterForDelegate(Func<int[], int[], int> comparer) => this.comparerDelegate = comparer;

        /// <inheritdoc/>
        public int Compare(int[] array1, int[] array2) => this.comparerDelegate(array1, array2);
    }
}
