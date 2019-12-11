using System;

namespace MatrixSorting.DLL
{
    /// <summary>
    /// Sorting matrix.
    /// </summary>
    public class SortArray : ISortArray
    {
        /// <summary>
        /// Method that sorts given array by given criterion.
        /// </summary>
        /// <param name="matrix"> Jagged unsorted array.</param>
        /// <param name="comparer"> Criterion of sorting.</param>
        /// <returns> Sorting matrix.</returns>
        public static int[][] BubbleSort(int[][] matrix, IArrayCompare comparer)
        {
            if (matrix == null)
            {
                throw new ArgumentNullException($"{nameof(matrix)} is empty");
            }

            if (matrix.Length == 1)
            {
                return matrix;
            }

            if (comparer is null)
            {
                throw new ArgumentNullException(nameof(comparer));
            }

            var tmpMatrix = (int[][])matrix.Clone();

            for (int j = 0; j < MaxRowLength(tmpMatrix); j++)
            {
                for (int i = 0; i < tmpMatrix.Length - 1; i++)
                {
                    if (comparer.Compare(tmpMatrix[i], tmpMatrix[i + 1]) > 0)
                    {
                        Swap(ref tmpMatrix[i], ref tmpMatrix[i + 1]);
                    }
                }
            }

            return tmpMatrix;
        }

        /// <summary>
        /// Method that sorts given array by given criterion (instance of AdapterForDelegate class).
        /// </summary>
        /// <param name="matrix"> Jagged unsorted array.</param>
        /// <param name="adapterForDelegate"> Instance of Adapter For Delegate class that encapsulates delegate as sorting type.</param>
        /// <returns> Sorting matrix.</returns>
        public static int[][] BubbleSortWithDelegate(int[][] matrix, AdapterForDelegate adapterForDelegate)
        {
            if (matrix == null)
            {
                throw new ArgumentNullException($"{nameof(matrix)} is empty");
            }

            if (matrix.Length == 1)
            {
                return matrix;
            }

            if (adapterForDelegate is null)
            {
                throw new ArgumentNullException(nameof(adapterForDelegate));
            }

            return BubbleSort(matrix, adapterForDelegate);
        }

        /// <inheritdoc/>
        public void SortAscendingRowBySum(ref int[][] matrix)
        {
            if (matrix is null)
            {
                throw new ArgumentNullException(nameof(matrix));
            }

            if (matrix.Length == 1)
            {
                return;
            }

            int[][] tmpArray = (int[][])matrix.Clone();

            this.Sum(out int[] rowTotalMatrix, tmpArray);

            for (int i = 0; i < rowTotalMatrix.Length; i++)
            {
                for (int j = i + 1; j < rowTotalMatrix.Length; j++)
                {
                    if (rowTotalMatrix[i] > rowTotalMatrix[j])
                    {
                        this.Swap(ref tmpArray, rowTotalMatrix, i, j);
                    }
                }
            }

            matrix = (int[][])tmpArray.Clone();
        }

        /// <inheritdoc/>
        public void SortDescendingRowBySum(ref int[][] matrix)
        {
            if (matrix is null)
            {
                throw new ArgumentNullException(nameof(matrix));
            }

            if (matrix.Length == 1)
            {
                return;
            }

            int[][] tmpArray = (int[][])matrix.Clone();

            this.Sum(out int[] rowTotalMatrix, matrix);

            for (int i = 0; i < rowTotalMatrix.Length; i++)
            {
                for (int j = i + 1; j < rowTotalMatrix.Length; j++)
                {
                    if (rowTotalMatrix[i] < rowTotalMatrix[j])
                    {
                        this.Swap(ref tmpArray, rowTotalMatrix, i, j);
                    }
                }
            }

            matrix = (int[][])tmpArray.Clone();
        }

        /// <inheritdoc/>
        public void SortAscendingByMaxElemRow(ref int[][] matrix)
        {
            if (matrix is null)
            {
                throw new ArgumentNullException(nameof(matrix));
            }

            if (matrix.Length == 1)
            {
                return;
            }

            int[][] tmpArray = (int[][])matrix.Clone();

            this.Max(out int[] rowArray, tmpArray);

            for (int i = 0; i < rowArray.Length; i++)
            {
                for (int j = i + 1; j < rowArray.Length; j++)
                {
                    if (rowArray[i] > rowArray[j])
                    {
                        this.Swap(ref tmpArray, rowArray, i, j);
                    }
                }
            }

            matrix = (int[][])tmpArray.Clone();
        }

        /// <inheritdoc/>
        public void SortDescendingByMaxElemRow(ref int[][] matrix)
        {
            if (matrix is null)
            {
                throw new ArgumentNullException(nameof(matrix));
            }

            if (matrix.Length == 1)
            {
                return;
            }

            int[][] tmpArray = (int[][])matrix.Clone();

            this.Max(out int[] rowArray, tmpArray);

            for (int i = 0; i < rowArray.Length; i++)
            {
                for (int j = i + 1; j < rowArray.Length; j++)
                {
                    if (rowArray[i] < rowArray[j])
                    {
                        this.Swap(ref tmpArray, rowArray, i, j);
                    }
                }
            }

            matrix = (int[][])tmpArray.Clone();
        }

        /// <inheritdoc/>
        public void SortAscendingByMinElemRow(ref int[][] matrix)
        {
            if (matrix is null)
            {
                throw new ArgumentNullException(nameof(matrix));
            }

            if (matrix.Length == 1)
            {
                return;
            }

            int[][] tmpArray = (int[][])matrix.Clone();

            this.Min(out int[] rowArray, tmpArray);

            for (int i = 0; i < rowArray.Length; i++)
            {
                for (int j = i + 1; j < rowArray.Length; j++)
                {
                    if (rowArray[i] > rowArray[j])
                    {
                        this.Swap(ref tmpArray, rowArray, i, j);
                    }
                }
            }

            matrix = (int[][])tmpArray.Clone();
        }

        /// <inheritdoc/>
        public void SortDescendingByMinElemRow(ref int[][] matrix)
        {
            if (matrix is null)
            {
                throw new ArgumentNullException(nameof(matrix));
            }

            if (matrix.Length == 1)
            {
                return;
            }

            int[][] tmpArray = (int[][])matrix.Clone();

            this.Min(out int[] rowArray, tmpArray);

            for (int i = 0; i < rowArray.Length; i++)
            {
                for (int j = i + 1; j < rowArray.Length; j++)
                {
                    if (rowArray[i] < rowArray[j])
                    {
                        this.Swap(ref tmpArray, rowArray, i, j);
                    }
                }
            }

            matrix = (int[][])tmpArray.Clone();
        }

        private static void Swap<T>(ref T a, ref T b)
        {
            T temp = a;
            a = b;
            b = temp;
        }

        private static int MaxRowLength(int[][] matrix)
        {
            int maxRowLength = 0;
            for (int i = 0; i < matrix.Length; i++)
            {
                if (matrix[i].Length > maxRowLength)
                {
                    maxRowLength = matrix[i].Length;
                }
            }

            return maxRowLength;
        }

        private void Sum(out int[] rowTotalMatrix, int[][] array)
        {
            rowTotalMatrix = new int[array.Length];
            int tmpSumm = 0;
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array[i].Length; j++)
                {
                    tmpSumm += array[i][j];
                }

                rowTotalMatrix[i] = tmpSumm;
                tmpSumm = 0;
            }
        }

        private void Max(out int[] rowArray, int[][] array)
        {
            rowArray = new int[array.Length];
            int max = rowArray[0];
            for (int i = 0; i < array.Length; i++)
            {
                foreach (var item in array[i])
                {
                    if (max < item)
                    {
                        max = item;
                        rowArray[i] = max;
                    }
                }
            }
        }

        private void Min(out int[] rowArray, int[][] array)
        {
            rowArray = new int[array.Length];
            int min = rowArray[0];
            for (int i = 0; i < array.Length; i++)
            {
                foreach (var item in array[i])
                {
                    if (min > item)
                    {
                        min = item;
                        rowArray[i] = min;
                    }
                }
            }
        }

        private void Swap(ref int[][] matrix, int[] array, int i, int j)
        {
            int tmp = array[i];
            int[] tmpArr = matrix[i];
            array[i] = array[j];
            matrix[i] = matrix[j];
            array[j] = tmp;
            matrix[j] = tmpArr;
        }

    }
}
