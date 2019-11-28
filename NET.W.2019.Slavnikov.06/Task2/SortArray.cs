using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    public class SortArray
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Performance", "CA1819:Свойства не должны возвращать массивы", Justification = "<Ожидание>")]
        public int[][] Matrix { get; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.OrderingRules", "SA1201:Elements should appear in the correct order", Justification = "<Ожидание>")]
        public SortArray(int[][] matrix)
        {
            this.Matrix = matrix ?? throw new ArgumentNullException(nameof(matrix));
        }

        /// <summary>
        /// Sorting in ascending order of the sum of the elements of the matrix rows.
        /// </summary>
        public void SortAscendingRowBySum()
        {
            this.Sum(out int[] rowTotalMatrix);

            for (int i = 0; i < rowTotalMatrix.Length; i++)
            {
                for (int j = i + 1; j < rowTotalMatrix.Length; j++)
                {
                    if (rowTotalMatrix[i] > rowTotalMatrix[j])
                    {
                        this.Swap(rowTotalMatrix, i, j);
                    }
                }
            }
        }

        /// <summary>
        /// Sorting in descending order of the sum of the elements of the rows of the matrix.
        /// </summary>
        public void SortDescendingRowBySum()
        {
            this.Sum(out int[] rowTotalMatrix);

            for (int i = 0; i < rowTotalMatrix.Length; i++)
            {
                for (int j = i + 1; j < rowTotalMatrix.Length; j++)
                {
                    if (rowTotalMatrix[i] < rowTotalMatrix[j])
                    {
                        this.Swap(rowTotalMatrix, i, j);
                    }
                }
            }
        }

        /// <summary>
        /// Sin ascending order of the maximum elements of the rows of the matrix.
        /// </summary>
        public void SortAscendingByMaxElemRow()
        {
            this.Max(out int[] rowArray);

            for (int i = 0; i < rowArray.Length; i++)
            {
                for (int j = i + 1; j < rowArray.Length; j++)
                {
                    if (rowArray[i] > rowArray[j])
                    {
                        this.Swap(rowArray, i, j);
                    }
                }
            }
        }

        /// <summary>
        /// Sin descending order of the maximum elements of the rows of the matrix.
        /// </summary>
        public void SortDescendingByMaxElemRow()
        {
            this.Max(out int[] rowArray);

            for (int i = 0; i < rowArray.Length; i++)
            {
                for (int j = i + 1; j < rowArray.Length; j++)
                {
                    if (rowArray[i] < rowArray[j])
                    {
                        this.Swap(rowArray, i, j);
                    }
                }
            }
        }

        /// <summary>
        /// Sin ascending order of the minimum elements of the rows of the matrix.
        /// </summary>
        public void SortAscendingByMinElemRow()
        {
            this.Min(out int[] rowArray);

            for (int i = 0; i < rowArray.Length; i++)
            {
                for (int j = i + 1; j < rowArray.Length; j++)
                {
                    if (rowArray[i] > rowArray[j])
                    {
                        this.Swap(rowArray, i, j);
                    }
                }
            }
        }

        /// <summary>
        /// Sin descending order of the minimum elements of the rows of the matrix.
        /// </summary>
        public void SortDescendingByMinElemRow()
        {
            this.Min(out int[] rowArray);

            for (int i = 0; i < rowArray.Length; i++)
            {
                for (int j = i + 1; j < rowArray.Length; j++)
                {
                    if (rowArray[i] < rowArray[j])
                    {
                        this.Swap(rowArray, i, j);
                    }
                }
            }
        }

        private void Sum(out int[] rowTotalMatrix)
        {
            rowTotalMatrix = new int[this.Matrix.Length];
            int tmpSumm = 0;
            for (int i = 0; i < this.Matrix.Length; i++)
            {
                for (int j = 0; j < this.Matrix[i].Length; j++)
                {
                    tmpSumm += this.Matrix[i][j];
                }

                rowTotalMatrix[i] = tmpSumm;
                tmpSumm = 0;
            }
        }

        private void Max(out int[] rowArray)
        {
            rowArray = new int[this.Matrix.Length];
            int max = rowArray[0];
            for (int i = 0; i < this.Matrix.Length; i++)
            {
                foreach (var item in this.Matrix[i])
                {
                    if (max < item)
                    {
                        max = item;
                        rowArray[i] = max;
                    }
                }
            }
        }

        private void Min(out int[] rowArray)
        {
            rowArray = new int[this.Matrix.Length];
            int min = rowArray[0];
            for (int i = 0; i < this.Matrix.Length; i++)
            {
                foreach (var item in this.Matrix[i])
                {
                    if (min > item)
                    {
                        min = item;
                        rowArray[i] = min;
                    }
                }
            }
        }

        private void Swap(int[] array, int i, int j)
        {
            int tmp = array[i];
            int[] tmpArr = this.Matrix[i];
            array[i] = array[j];
            this.Matrix[i] = this.Matrix[j];
            array[j] = tmp;
            this.Matrix[j] = tmpArr;
        }
    }
}
