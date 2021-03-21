using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace KtExtensions.Tests
{
    [TestClass]
    public class BigIntegerRootTests
    {
        [TestMethod]
        public void CubeRootOf8()
        {
            var arg = new BigInteger(8);
            var result = new BigInteger(2);
            Assert.AreEqual(arg.Root(3), result);
        }
        [TestMethod]
        public void MyTestMethod()
        {
            var arg = new BigInteger(147008443);
            var result = new BigInteger(43);
            Assert.AreEqual(arg.Root(5), result);
        }
        [TestMethod]
        public void MyTestMethod2()
        {
            var arg = new BigInteger(-147008443);
            var result = new BigInteger(-43);
            Assert.AreEqual(arg.Root(5), result);
        }
        [TestMethod]
        public void MyTestMethod3()
        {
            var arg = new BigInteger(39135393);
            var result = new BigInteger(33);
            Assert.AreEqual(arg.Root(5), result);
        }
        [TestMethod]
        public void MyTestMethod4()
        {
            var arg = new BigInteger(-39135393);
            var result = new BigInteger(-33);
            Assert.AreEqual(arg.Root(5), result);
        }

        [TestMethod]
        public void MyTestMethod5()
        {
            var arg = new BigInteger(3521614606208);
            var result = new BigInteger(62);
            Assert.AreEqual(arg.Root(7), result);
        }

        [TestMethod]
        public void MyTestMethod6()
        {
            var arg = new BigInteger(351298031616);
            var result = new BigInteger(84);
            Assert.AreEqual(arg.Root(6), result);
        }

        [TestMethod]
        public void MyTestMethod7()
        {
            var arg = new BigInteger(61);
            var result = new BigInteger(1);
            Assert.AreEqual(arg.Root(0), result);
        }

        [TestMethod]
        public void CubeRootOfNegative8()
        {
            var arg = new BigInteger(-8);
            var result = new BigInteger(-2);
            Assert.AreEqual(arg.Root(3), result);
        }

        [TestMethod]
        public void SqrtOf4BigIntTest()
        {
            var arg = new BigInteger(4);
            var result = new BigInteger(2);
            Assert.AreEqual(arg.Root(2), result);
        }

        [TestMethod]
        public void SqrtOf9BigIntTest()
        {
            var arg = new BigInteger(9);
            var result = new BigInteger(3);
            Assert.AreEqual(arg.Root(2), result);
        }

        [TestMethod]
        public void SqrtOf16BigIntTest()
        {
            var arg = new BigInteger(16);
            var result = new BigInteger(4);
            Assert.AreEqual(arg.Root(2), result);
        }

        [TestMethod]
        public void SqrtOf27625536‬BigIntTest()
        {
            var arg = new BigInteger(27625536);
            var result = new BigInteger(5256);
            Assert.AreEqual(arg.Root(2), result);
        }

        [TestMethod]
        public void SqrtOfZeroBigIntTest()
        {
            var arg = new BigInteger(0);
            var result = new BigInteger(0);
            Assert.AreEqual(arg.Root(2), result);
        }

        [TestMethod]
        public void SqrtOf9801BigIntTest()
        {
            var arg = new BigInteger(9801);
            var result = new BigInteger(99);
            Assert.AreEqual(arg.Root(2), result);
        }

        [TestMethod]
        public void SqrtOf3055325625BigIntTest()
        {
            var arg = new BigInteger(3055325625);
            var result = new BigInteger(55275);
            Assert.AreEqual(arg.Root(2), result);
        }

        [TestMethod]
        public void SqrtOf1BigIntTest()
        {
            var arg = new BigInteger(1);
            var result = new BigInteger(1);
            Assert.AreEqual(arg.Root(2), result);
        }
    }

    [TestClass]
    public class BigIntegerSqrtTests
    {
        [TestMethod]
        public void SqrtOf4BigIntTest()
        {
            var arg = new BigInteger(4);
            var result = new BigInteger(2);
            Assert.AreEqual(arg.Sqrt(), result);
        }

        [TestMethod]
        public void SqrtOf9BigIntTest()
        {
            var arg = new BigInteger(9);
            var result = new BigInteger(3);
            Assert.AreEqual(arg.Sqrt(), result);
        }

        [TestMethod]
        public void SqrtOf16BigIntTest()
        {
            var arg = new BigInteger(16);
            var result = new BigInteger(4);
            Assert.AreEqual(arg.Sqrt(), result);
        }

        [TestMethod]
        public void SqrtOf27625536‬BigIntTest()
        {
            var arg = new BigInteger(27625536);
            var result = new BigInteger(5256);
            Assert.AreEqual(arg.Sqrt(), result);
        }

        [TestMethod]
        public void SqrtOfZeroBigIntTest()
        {
            var arg = new BigInteger(0);
            var result = new BigInteger(0);
            Assert.AreEqual(arg.Sqrt(), result);
        }

        [TestMethod]
        public void SqrtOf9801BigIntTest()
        {
            var arg = new BigInteger(9801);
            var result = new BigInteger(99);
            Assert.AreEqual(arg.Sqrt(), result);
        }

        [TestMethod]
        public void SqrtOf3055325625BigIntTest()
        {
            var arg = new BigInteger(3055325625);
            var result = new BigInteger(55275);
            Assert.AreEqual(arg.Sqrt(), result);
        }

        [TestMethod]
        public void SqrtOf1BigIntTest()
        {
            var arg = new BigInteger(1);
            var result = new BigInteger(1);
            Assert.AreEqual(arg.Sqrt(), result);
        }
    }

    [TestClass]
    public class BigIntegerFactorTests
    {
        [TestMethod]
        public void FactorTest()
        {
            var (product, actual, expected) = GenerateFactorTest(1000, 1, 100);
            ReportResultsToConsole(product, actual, expected);
            Assert.IsTrue(expected.ContentEquals(actual));
        }

        [TestMethod]
        public void FactorTest2()
        {
            var (product, actual, expected) = GenerateFactorTest(100, 1, 10);
            ReportResultsToConsole(product, actual, expected);
            Assert.IsTrue(expected.ContentEquals(actual));
        }

        [TestMethod]
        public void FactorTest3()
        {
            var (product, actual, expected) = GenerateFactorTest(30000, 1, 4);
            ReportResultsToConsole(product, actual, expected);
            Assert.IsTrue(expected.ContentEquals(actual));
        }

        [TestMethod]
        public void FactorTest4()
        {
            var (product, actual, expected) = GenerateFactorNegativeTest(100, 1, 10);
            ReportResultsToConsole(product, actual, expected);
            Assert.IsTrue(expected.ContentEquals(actual));
        }

        private static void ReportResultsToConsole(BigInteger number, IEnumerable<BigInteger> actual, IEnumerable<BigInteger> expected)
        {
            Console.WriteLine(number);
            Console.WriteLine($"actual: {actual.BuildString("*")}");
            Console.WriteLine($"expected: {expected.BuildString("*")}");
        }

        private static (BigInteger number, IEnumerable<BigInteger> actual, IEnumerable<BigInteger> expected) GenerateFactorTest(int range, int min, int max)
        {
            var bigInts = CreateRandomInts(range, min, max).Select(i => (BigInteger)i).ToList();
            var product = bigInts.Aggregate((i1, i2) => i1 * i2);
            var expected = bigInts.Select(i => i.Factor()).SelectMany(i => i);
            var actual = product.Factor();
            return (product, actual, expected);
        }

        private static (BigInteger number, IEnumerable<BigInteger> actual, IEnumerable<BigInteger> expected) GenerateFactorNegativeTest(int range, int min, int max)
        {
            var bigInts = CreateRandomInts(range, min, max).Select(i => (BigInteger)i).ToList();
            bigInts.Add(-1);
            var product = bigInts.Aggregate((i1, i2) => i1 * i2);
            var expected = bigInts.Select(i => i.Factor()).SelectMany(i => i);
            var actual = product.Factor();
            return (product, actual, expected);
        }

        private static IEnumerable<int> CreateRandomInts(int range, int min, int max)
        {
            var r = new Random();
            for (int i = 0; i < range; i++)
            {
                yield return r.Next(min, max);
            }
        }
    }
}