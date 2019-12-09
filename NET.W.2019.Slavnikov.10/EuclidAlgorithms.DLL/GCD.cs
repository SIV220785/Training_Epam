using System;
using System.Diagnostics;
using System.Linq;

namespace EuclidAlgorithms.DLL
{
    /// <summary>
    /// Class that allows to perform GCD calculations using the Euclidean algorithm.
    /// </summary>
    public class GCD
    {
        /// <summary>
        /// Computation of GCD according to the Euclidean algorithm.
        /// </summary>
        /// <param name="numbers"></param>
        /// <returns></returns>
        public int EuclideanGCD(params int[] numbers) => this.FindGCD(this.EuclideanAlgorithm, numbers);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="numbers"></param>
        /// <returns></returns>
        public int BinaryGCD(params int[] numbers) => this.FindBinaryGCD(this.BinaryAlgorithm, numbers);

        private int FindBinaryGCD(Func<int, int, int> binaryAlgorithm, int[] numbers)
        {
            if (binaryAlgorithm is null)
            {
                throw new ArgumentNullException(nameof(binaryAlgorithm));
            }

            if (numbers is null || numbers.Length == 0)
            {
                throw new ArgumentNullException(nameof(numbers));
            }

            if (numbers.Contains(0))
            {
                _ = numbers.ToList().RemoveAll(n => n == 0);
            }

            int gcd = numbers[0];

            for (int i = 0; i < numbers.Length - 1; i++)
            {
                gcd = binaryAlgorithm(Math.Abs(numbers[i]), Math.Abs(numbers[i + 1]));
                numbers[i + 1] = gcd;
            }

            return gcd;
        }

        private int FindGCD(Func<int, int, int> enclideanAlgorithm, int[] numbers)
        {
            if (enclideanAlgorithm is null)
            {
                throw new ArgumentNullException(nameof(enclideanAlgorithm));
            }

            if (numbers is null)
            {
                throw new ArgumentNullException(nameof(numbers));
            }

            if (numbers.Length == 0)
            {
                throw new ArgumentException("No Arguments!");
            }

            if (numbers.Contains(0))
            {
                _ = numbers.ToList().RemoveAll(n => n == 0);
            }

            int gcd = numbers[0];

            for (int i = 0; i < numbers.Length - 1; i++)
            {
                gcd = enclideanAlgorithm(Math.Abs(numbers[i]), Math.Abs(numbers[i + 1]));
                numbers[i + 1] = gcd;
            }

            return gcd;
        }

        private int EuclideanAlgorithm(int a, int b)
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
                    a -= b;
                }
                else
                {
                    b -= a;
                }
            }

            return a;
        }

        private int BinaryAlgorithm(int a, int b)
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

                b -= a;
            }
            while (b != 0);

            return a << count;
        }
    }
}
