using System;
using System.Collections.Generic;
using System.Linq;

using KtExtensions;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KtExtensions.Tests
{
    [TestClass]
    public class StringManipulationTest2
    {
        [TestMethod]
        public void ArrayOnStackTest()
        {
            var stack = new Stack<char>();
            stack.Push('A');
            stack.Push('B');
            stack.Push('C');
            //stack
            //C
            //B
            //A
            // outcome is C B A in array form
            //last push is first in enumerability
            Console.WriteLine(new string(stack.ToArray()));
        }

        [TestMethod]
        public void SingleElementTest()
        {
            var test = new[] { 1 };
            Assert.AreEqual(test.BuildString(""), "1");
            var test2 = new uint[] { 1 };
            Assert.AreEqual(test2.BuildString(""), "1");
        }

        [TestMethod]
        public void RemoveVowelsTest()
        {
            const string test = "Monkey";
            var result = test.RemoveVowels();
            Assert.AreEqual("Mnky", result);
            var e = result.Take(3).Count();
            Console.WriteLine(new string(result.Take(3).ToArray()));
            Console.WriteLine(e);
        }

        [TestMethod]
        public void SmartConcatTest()
        {
            Assert.AreEqual("a".SmartConcat("b"), "a b");
            Assert.AreEqual("".SmartConcat("b"), "b");
            Assert.AreEqual("a".SmartConcat(""), "a");
            Assert.AreEqual(string.Empty.SmartConcat(string.Empty), "");
            Assert.AreEqual("test".SmartConcat(new[] { "a", "", "b", "", "", "c", "d" }), "test a b c d");
        }

        [TestMethod]
        public void SplitStringAndNumber()
        {
            var (text, number) = "a- (1)".SplitTextAndNumber();
            Assert.AreEqual(number, 1);
            Assert.AreEqual(text, "a- ");
        }

        [TestMethod]
        public void MakeStringUniqueTest()
        {
            var test = "a".MakeUniqueFrom(new[] { "a", "a(1)", "a(2)" });
            Assert.AreEqual(test, "a(3)");
        }

        [TestMethod]
        public void MakeStringUniqueWithLimitsTest()
        {
            var test = "aaaaaaaaaaa".MakeUniqueFrom(new[] { "aaaaaaaaaaa", "aaa...(1)", "aa...(12)" }, 9);
            Assert.AreEqual(test, "aaa...(2)");
            var test2 = "aa...(12)".MakeUniqueFrom(new[] { "aaaaaaaaaaa", "aaa...(1)", "aa...(12)" }, 9);
            Assert.AreEqual(test2, "aa...(13)");
        }
    }
}