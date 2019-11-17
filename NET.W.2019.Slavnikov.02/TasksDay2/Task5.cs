using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TasksDay2
{
    public class Task5
    {
        /// <summary>
        /// Finding the root of the n-th degree with Newton method
        /// </summary>
        /// <param name="a">Source number</param>
        /// <param name="n">Degree of Root</param>
        /// <param name="pre">Precision(Accuracy)</param>
        /// <returns>Root of the n-th degree</returns>
        public static double FindNthRoot(double a, int n, double pre)
        {
            if (n <= 0)
                throw new ArgumentOutOfRangeException("Root can't be negative");
            if (pre <= 0 || pre > 1)
                throw new ArgumentOutOfRangeException("Incorrect precision(accuracy)");
            if (a < 0 && n % 2 == 0)
                throw new Exception("Root expresion must be positive!");

            double quot = a / n;
            double point = (1.0 / n) * ((n - 1) * quot + a / Math.Pow(quot, n - 1));
            while (Math.Abs(point - quot) > pre)
            {
                quot = point;
                point = (1.0 / n) * ((n - 1) * quot + a / Math.Pow(quot, n - 1));
            }

            return Math.Round(point, PrecisionDigitsCount(pre), MidpointRounding.AwayFromZero);
        }

        private static int PrecisionDigitsCount(double pre)
        {
            int count = 0;
            while (pre < 1)
            {
                count++;
                pre *= 10;
            }
            return count;
        }
    }
}
