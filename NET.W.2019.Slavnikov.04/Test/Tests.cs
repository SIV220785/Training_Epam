using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task;

namespace Test
{
    [TestFixture]
    public class Tests
    {

        [TestCase(27, 0, 54, ExpectedResult = 27)]
        [TestCase(120, 18, ExpectedResult = 6)]
        public int GCDEuclideanCount(params int[] nums)
        {
            double execTime = 0;
            return GCD.EuclideanGCD(out execTime, nums);
        }

        [Test]
        [TestCase(27, 0, 54, ExpectedResult = 27)]
        [TestCase(120, 18, ExpectedResult = 6)]
        public int GCDBinaryCount(params int[] nums)
        {
            double execTime = 0;
            return GCD.BinaryGCD(out execTime, nums);
        }

        [TestCase(-255.255, ExpectedResult = "1100000001101111111010000010100011110101110000101000111101011100")]
        [TestCase(255.255, ExpectedResult = "0100000001101111111010000010100011110101110000101000111101011100")]
        [TestCase(4294967295.0, ExpectedResult = "0100000111101111111111111111111111111111111000000000000000000000")]
        [TestCase(double.MinValue, ExpectedResult = "1111111111101111111111111111111111111111111111111111111111111111")]
        [TestCase(double.MaxValue, ExpectedResult = "0111111111101111111111111111111111111111111111111111111111111111")]
        [TestCase(double.Epsilon, ExpectedResult = "0000000000000000000000000000000000000000000000000000000000000001")]
        [TestCase(double.NaN, ExpectedResult = "1111111111111000000000000000000000000000000000000000000000000000")]
        [TestCase(double.NegativeInfinity, ExpectedResult = "1111111111110000000000000000000000000000000000000000000000000000")]
        [TestCase(double.PositiveInfinity, ExpectedResult = "0111111111110000000000000000000000000000000000000000000000000000")]
        [TestCase(-0.0, ExpectedResult = "1000000000000000000000000000000000000000000000000000000000000000")]
        [TestCase(0.0, ExpectedResult = "0000000000000000000000000000000000000000000000000000000000000000")]
        public string DoubleToBinaryStringTest(double number) => NumberRepresentationConverter.DoubleToBinaryString(number);
    }
}
