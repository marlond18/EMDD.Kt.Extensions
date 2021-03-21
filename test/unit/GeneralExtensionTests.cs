using System;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using KtExtensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KtExtensionsTests
{
    [TestClass]
    public class NumericExtensionTest
    {
        [TestMethod]
        public void Rounding9sAnd0sTest()
        {
            var d = -12312.99999421321E12;
            Assert.AreEqual(d.SmartRoundSignificantValue(), -1.2313E16);
            d = -12312.000421321E12;
            Assert.AreEqual(d.SmartRoundSignificantValue(), -1.2312E16);
            d = 2.000000000001;
            Assert.AreEqual(d.SmartRoundSignificantValue(), 2);
            d = -2.000000000001;
            Assert.AreEqual(d.SmartRoundSignificantValue(), -2);
            d = -1.00000000572272;
            Assert.AreEqual(d.SmartRoundSignificantValue(), -1);
            d = -4.9225700000000007E-09;
            Assert.AreEqual(Math.Round(-4.9225700000000007, 6), -4.92257);
            Assert.AreEqual(d.SmartRoundSignificantValue(), -4.922570000000000E-09);
        }

        [TestMethod]
        public void Deconstruct()
        {
            const double d = -1.00000000572272;
            var dec = d.Store15DecimalsToArray();
            const double e = -4.9225700000000007;
            var ee = e.Store15DecimalsToArray();
            Assert.AreEqual(dec.Length, 15);
            Assert.IsTrue(d.Store15DecimalsToArray().SequenceEqual(new long[] { 0, 0, 0, 0, 0, 0, 0, 0, 5, 7, 2, 2, 7, 2, 0 }));
            Assert.AreEqual(ee.Length, 15);
            Assert.IsTrue(e.Store15DecimalsToArray().SequenceEqual(new long[] { 9, 2, 2, 5, 7, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }));
        }

        [TestMethod]
        public void IntToArrayTest()
        {
            const long d = 1234567890L;
            var arr = d.IntToArray();
            Assert.AreEqual(arr.Length, 10);
            Assert.IsTrue(arr.SequenceEqual(new long[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 }));
        }

        [TestMethod]
        public void ToDouble()
        {
            const string stringNumber = "2";
            Assert.AreEqual(stringNumber.ToDouble(), 2);
            Assert.AreEqual("2.4123".ToDouble(), 2.4123);
            Assert.AreEqual("ssdasda".ToDouble(), 0);
        }

        [TestMethod]
        public void NoFloatTest()
        {
            const double test1 = 1.9999999999999999999;
            Assert.IsTrue(test1.NoFloat());
            const double test2 = 1.000000000000001;
            Assert.IsTrue(test2.NoFloat());
        }

        [TestMethod]
        public void ScientificNotationTest()
        {
            var d = 193123123123.123123123123E12;
            var scientific = d.ScientificNotation();
            Assert.AreEqual(scientific.Exp, 23);
            d = 193123123123.123123123123E-12;
            scientific = d.ScientificNotation();
            Assert.AreEqual(scientific.Exp, -1);
            d = -193123123123.123123123123E12;
            scientific = d.ScientificNotation();
            Assert.AreEqual(scientific.Exp, 23);
            d = -193123123123.123123123123E-13;
            scientific = d.ScientificNotation();
            Assert.AreEqual(scientific.Exp, -2);
        }
    }

    [TestClass]
    public class GeneralExtensionTests
    {
        [TestMethod]
        public void HasTest()
        {
            var temp = "a+b-c";
            Assert.IsTrue(temp.Has("+", "-", "*"));
            temp = "a+b-c";
            Assert.IsTrue(temp.Has("a", "-", "*"));
            temp = "a+b-c";
            Assert.IsFalse(temp.Has("d", "e", "*"));
            temp = "a+b-c";
            Assert.IsFalse(temp.Has("d", "e", "f"));
            const double d = double.NaN;
            Assert.AreEqual(d.ToString(CultureInfo.InvariantCulture), "NaN");
            var e = "NaN".ToDouble();
            Assert.AreEqual(e, double.NaN);
            Assert.IsTrue("NaN".IsNumeric());
        }

        [TestMethod]
        public void RegressTest()
        {
            var list = new[] { 1, 2, 3, 4, 5 };
            Assert.IsTrue(list.Reverse().SequenceEqual(list.Reverse()));
        }
    }
}