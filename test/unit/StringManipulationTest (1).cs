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
    public class StringManipulationTest
    {
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
            var e=result.Take(3).Count();
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
    }
}