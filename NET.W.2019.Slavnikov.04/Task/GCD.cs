using System;
using System.Linq;
using System.Diagnostics;

namespace Task
{
    public class GCD
    {
        /// <summary>
        /// Bit-insert of number from i to j position
        /// </summary>
        /// <param name="numbers">Array of source numbers</param>
        /// <param name="execTime">Executing Time spending on GCD finding</param>
        /// <returns>
        /// Returns GCD by Euclidean Algorithm
        /// </returns>
        public static int EuclideanGCD(out double execTime, params int[] numbers)
        {
            if (numbers.Length == 0) throw new ArgumentNullException("No params");
            if (numbers.Contains(0)) numbers.ToList().RemoveAll(n => n == 0);

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            int res = 0;
            for (int i = 0; i < numbers.Length - 1; i++)
            {
                res = EuclideanAlgorithm(Math.Abs(numbers[i]), Math.Abs(numbers[i + 1]));
                numbers[i + 1] = res;
            }

            stopwatch.Stop();

            TimeSpan timeDiff = stopwatch.Elapsed;
            execTime = timeDiff.TotalMilliseconds;

            return res;
        }

        public static int BinaryGCD(out double execTime, params int[] numbers)
        {
            if (numbers.Length == 0) throw new ArgumentNullException("No params");
            if (numbers.Contains(0)) numbers.ToList().RemoveAll(n => n == 0);

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            int res = 0;
            for (int i = 0; i < numbers.Length - 1; i++)
            {
                res = BinaryAlgorithm(Math.Abs(numbers[i]), Math.Abs(numbers[i + 1]));
                numbers[i + 1] = res;
            }
            stopwatch.Stop();

            TimeSpan timeDiff = stopwatch.Elapsed;
            execTime = timeDiff.TotalMilliseconds;

            return res;
        }

        private static int EuclideanAlgorithm(int a, int b)
        {
            if (a == 0)
            {
                return b;
            }

            if (b == 0)
            {
                return a;
            }

            while (a != b)
            {
                if (a > b)
                {
                    a = a - b;
                }
                else
                {
                    b = b - a;
                }
            }

            return a;
        }

        private static int BinaryAlgorithm(int a, int b)
        {

            if (a == 0)
            {
                return b;
            }

            if (b == 0)
            {
                return a;
            }

            int count = 0;

            while (((a | b) & 1) == 0)
            {
                count++;
                a >>= 1;
                b >>= 1;
            }

            while ((a & 1) == 0)
            {
                a >>= 1;
            }

            do
            {
                while ((b & 1) == 0)
                {
                    b >>= 1;
                }

                if (a > b)
                {
                    (a, b) = (b, a);
                }

                b = b - a;
            } while (b != 0);

            return a << count;
        }
    }
}
