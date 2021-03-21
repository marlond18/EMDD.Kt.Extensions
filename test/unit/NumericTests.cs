using Microsoft.VisualStudio.TestTools.UnitTesting;
using KtExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KtExtensions.Tests
{
    [TestClass]
    public class PartitionClassTest
    {
        [TestMethod]
        public void PartitionTest()
        {
            var d = new List<int>();
            for (int i = 0; i < 10; i++)
            {
                d.Add(i);
            }
            var p = d.Partition(e => e < 5);
            Assert.IsTrue(p[true].SequenceEqual(new[] { 0, 1, 2, 3, 4 }));
            Assert.IsTrue(p[false].SequenceEqual(new[] { 5, 6, 7, 8, 9 }));
        }
    }

    [TestClass]
    public class NumericTests
    {
        [TestMethod]
        public void ToDoubleTest()
        {
            Assert.AreEqual("0.".ToDouble(), 0);
            Assert.AreEqual("-0".ToDouble(), 0);
            Assert.AreEqual(".".ToDouble(), 0);
            Assert.AreEqual("-".ToDouble(), 0);
            Assert.AreEqual("-0.".ToDouble(), 0);
            Assert.AreEqual("-0.0".ToDouble(), 0);
            Assert.AreEqual("10.".ToDouble(), 10);
            Assert.AreEqual("-10.".ToDouble(), -10);
            Assert.AreEqual("-10.01".ToDouble(), -10.01);
        }

        [TestMethod]
        public void IsEvenTest()
        {
            Assert.IsTrue(0.IsEven());
            Assert.IsFalse(1.IsEven());
            Assert.IsTrue(2.IsEven());
            Assert.IsFalse(3.IsEven());
            Assert.IsTrue(4.IsEven());
            Assert.IsFalse(5.IsEven());
            Assert.IsTrue(6.IsEven());
            Assert.IsFalse(7.IsEven());
            Assert.IsTrue(8.IsEven());
        }
    }
}