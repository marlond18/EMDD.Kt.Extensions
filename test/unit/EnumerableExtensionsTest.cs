using Microsoft.VisualStudio.TestTools.UnitTesting;
using KtExtensions;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace KtExtensions.Tests
{
    [TestClass]
    public class EnumerableExtensionsTest
    {
        private class TestC
        {
            public TestC(string n)
            {
                Name = n;
            }

            public string Name { get; set; }
        }

        [TestMethod]
        public void FilterTest()
        {
            _ = new List<TestC> { new TestC("AAA"), new TestC("BAA") };
        }

        [TestMethod]
        public void TryVenn()
        {
            var list1 = new[] { 4, 5, 6, 7, 1, 2, 3 };
            var list2 = new[] { 8, 9, 10, 6, 7 };
            var (OnlyA, AandB, OnlyB) = list1.Venn(list2);
            var AtAOnly = Enumerable.Range(1, 5);
            var AtAB = Enumerable.Range(6, 2);
            var AtBOnly = Enumerable.Range(8, 3);
            Assert.IsTrue(OnlyA.ContentEquals(AtAOnly));
            Assert.IsTrue(AandB.ContentEquals(AtAB));
            Assert.IsTrue(OnlyB.ContentEquals(AtBOnly));
        }

        [TestMethod]
        public void CrossTest()
        {
            var OneToFive = Enumerable.Range(1, 5);
            var OneToFour = Enumerable.Range(1, 4);
            var result = new[] { 1, 2, 3, 4, 2, 4, 6, 8, 3, 6, 9, 12, 4, 8, 12, 16, 5, 10, 15, 20 };
            Assert.IsTrue(OneToFive.Cross(OneToFour, (n1, n2) => n1 * n2).SequenceEqual(result));
        }
    }
}