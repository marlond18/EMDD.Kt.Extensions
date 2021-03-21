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
    public class ListTests
    {
        [TestMethod]
        public void ForEachTest()
        {
            var d = new double[,] { { 1, 2 }, { 3, 4 } };
            var e = new double[,] { { 5, 6 }, { 7, 8 } };
            var f = d.Select((elem, i, j) => e[i, j] + elem);
            Assert.IsTrue(f.SequenceEqual(new double[,] { { 6, 8 }, { 10, 12 } }));
        }

        [TestMethod]
        public void DeleteRowTest()
        {
            var d = new double[,] { { 1, 2, 3, 4 }, { 4, 6, 7, 8 }, { 9, 10, 11, 12 } };
            const int i = 0;
            var e = d.DeleteRow(i);
            Assert.IsTrue(e.SequenceEqual(new double[,] { { 4, 6, 7, 8 }, { 9, 10, 11, 12 } }));
            e = e.DeleteRow(-1);
            Assert.IsTrue(e.SequenceEqual(new double[,] { { 4, 6, 7, 8 }, { 9, 10, 11, 12 } }));
            e = e.DeleteRow(2);
            Assert.IsTrue(e.SequenceEqual(new double[,] { { 4, 6, 7, 8 }, { 9, 10, 11, 12 } }));
            e = null;
            e = e.DeleteRow(0);
            Assert.AreEqual(e, null);
            var f = new double[0, 12];
            f = f.DeleteRow(0);
            Assert.AreEqual(f.GetLength(0), 0);
            Assert.AreEqual(f.GetLength(1), 12);
        }

        [TestMethod]
        public void DeleteColTest()
        {
            var d = new double[,] { { 1, 2, 3, 4 }, { 4, 6, 7, 8 }, { 9, 10, 11, 12 } };
            var e = d.DeleteCol(0);
            Assert.IsTrue(e.SequenceEqual(new double[,] { { 2, 3, 4 }, { 6, 7, 8 }, { 10, 11, 12 } }));
            e = e.DeleteCol(-1);
            Assert.IsTrue(e.SequenceEqual(new double[,] { { 2, 3, 4 }, { 6, 7, 8 }, { 10, 11, 12 } }));
            e = e.DeleteCol(3);
            Assert.IsTrue(e.SequenceEqual(new double[,] { { 2, 3, 4 }, { 6, 7, 8 }, { 10, 11, 12 } }));
            e = null;
            e = e.DeleteCol(0);
            Assert.AreEqual(e, null);
            var f = new double[0, 12];
            f = f.DeleteCol(0);
            Assert.AreEqual(f.GetLength(0), 0);
            Assert.AreEqual(f.GetLength(1), 11);
        }

        [TestMethod]
        public void SwapRowTest()
        {
            var d = new double[,] { { 1, 2, 3, 4 }, { 4, 6, 7, 8 }, { 9, 10, 11, 12 } };
            var e = d.SwapRow(0, 1);
            var f = new double[,] { { 4, 6, 7, 8 } , { 1, 2, 3, 4 } , { 9, 10, 11, 12 } };
            Assert.IsTrue(e.SequenceEqual( f));
            d.SwapRowInternal(0, 1);
            Assert.IsTrue(d.SequenceEqual(f));
        }

        [TestMethod]
        public void SwapColTest()
        {
            var d = new double[,] { { 1, 2, 3, 4 }, { 4, 6, 7, 8 }, { 9, 10, 11, 12 } };
            var e = d.SwapCol(0, 1);
            var f = new double[,] { { 2, 1, 3, 4 }, { 6, 4, 7, 8 }, { 10, 9, 11, 12 } };
            Assert.IsTrue(e.SequenceEqual(f));
            d.SwapColInternal(0, 1);
            Assert.IsTrue(d.SequenceEqual(f));
        }

        [TestMethod]
        public void BuildStringTest()
        {
            var list = new[] { "i", "am", "me" };
            var result = list.BuildString(" ");
            Assert.AreEqual("i am me", result);
        }
    }
}