using NUnit.Framework;
using Task1;

namespace NUnitTestPolynomic
{
    [TestFixture]
    public class Tests
    {
        [TestCase(new double[] { 1, 4, 3, 7, 5 }, 3, ExpectedResult = 7)]
        [TestCase(new double[] { 1, 4, 3, 7, 5 }, 4, ExpectedResult = 5)]
        public static double CeffProperty_PositiveTest(double[] array, int factor)
        {
            Polynomial p = new Polynomial(array);
            return p[factor];
        }

        [TestCase(new double[] { 1, 2 }, ExpectedResult = "1 + 2*x^1")]
        [TestCase(new double[] { 1, 0, 2 }, ExpectedResult = "1 + 2*x^2")]
        public static string ToString_PositiveTest(double[] array)
        {
            Polynomial p = new Polynomial(array);
            return p.ToString();
        }



    }
}