namespace ArraySorting
{
    public static class Sort
    {
        /// <summary>
        /// QuaickSorts
        /// </summary>
        /// <param name="array">Array of numbers</param>
        public static void QuaickSort(this int[] array)
        {
            if (array == null)
            {
                return;
            }
            QuickSort(array, 0, array.Length - 1);
        }

        /// <summary>
        /// Recursive sorting of each part of the array
        /// </summary>
        /// <param name="array">Array of numbers</param>
        /// <param name="start">Start index</param>
        /// <param name="end">End index</param>
        public static void QuickSort(int[] array, int start, int end)
        {
            if (start < end)
            {
                int pivot = Partition(array, start, end);
                QuickSort(array, start, pivot - 1);
                QuickSort(array, pivot + 1, end);
            }
        }

        /// <summary>
        /// Partitioning an array relative to a support element
        /// </summary>
        /// <param name="array">Array of numbers</param>
        /// <param name="start">Start index</param>
        /// <param name="end">End index</param>
        /// <returns></returns>
        public static int Partition(int[] array, int start, int end)
        {
            int pivot = array[end];
            int pIndex = start;

            for (int i = start; i < end; i++)
            {
                if (array[i] <= pivot)
                {
                    int temp = array[i];
                    array[i] = array[pIndex];
                    array[pIndex] = temp;
                    pIndex++;
                }
            }

            int anotherTemp = array[pIndex];
            array[pIndex] = array[end];
            array[end] = anotherTemp;
            return pIndex;
        }

        /// <summary>
        /// MergeSort
        /// </summary>
        /// <param name="array">Array of numbers</param>
        /// <returns></returns>
        public static void MergeSort(this int[] array)
        {
            if (array.Length <= 1)
                return;
            int midPoint = array.Length / 2;
            int[] leftArr = new int[midPoint];
            int[] rightArr = new int[array.Length - midPoint];

            for (int i = 0; i <= midPoint - 1; i++)
            {
                leftArr[i] = array[i];
            }
            for (int i = midPoint; i <= array.Length - 1; i++)
            {
                rightArr[i - midPoint] = array[i];
            }

            MergeSort(leftArr);
            MergeSort(rightArr);
            Merge(array, leftArr, rightArr);
        }

        /// <summary>
        /// Combining subarrays into one sorted array
        /// </summary>
        /// <param name="array">Array to sort</param>
        /// <param name="leftArr">Left subarray</param>
        /// <param name="rightArr">Right subarray</param>
        public static void Merge(int[] array, int[] leftArr, int[] rightArr)
        {
            int i = 0;
            int j = 0;
            int k = 0;

            while (i < leftArr.Length && j < rightArr.Length)
            {
                if (leftArr[i] <= rightArr[j])
                {
                    array[k] = leftArr[i];
                    i++;
                }
                else
                {
                    array[k] = rightArr[j];
                    j++;
                }
                k++;
            }

            while (i < leftArr.Length)
            {
                array[k] = leftArr[i];
                i++;
                k++;
            }
            while (j < rightArr.Length)
            {
                array[k] = rightArr[j];
                j++;
                k++;
            }
        }
    }
}
