using Microsoft.VisualStudio.TestTools.UnitTesting;
using KtExtensions.NetStandard;
using System.IO;
using System;

namespace KtExtensions.Tests
{
    [TestClass]
    public class FilePathExtensionsTests
    {
        [TestMethod]
        public void GetUniqueFilePath_NewFile_Test()
        {
            const string rawPath = @"D:\work\C#\KtExtensions\KtExtensionsTests\FilePathExtensionsTestsNew.cs";
            var actual = rawPath.GetUniqueFilePath();
            Assert.AreEqual(rawPath, actual);
        }

        [TestMethod]
        public void GetUniqueFilePath_Existing_Test()
        {
            const string rawPath = "FileTest.txt";
            var actual = rawPath.GetUniqueFilePath();
            const string expected = "FileTest (2).txt";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestReferenceEqualityOfBinarySerilization()
        {
            const string rawPath = "FileTest.txt";
            if (File.Exists(rawPath)) File.WriteAllText(rawPath, string.Empty);
            var a = new A();
            var b = new B
            {
                A = a
            };
            SimplifiedFileStream.WriteFileBinary(rawPath, a, b);
            if (SimplifiedFileStream.ReadFileBinary(rawPath, out A ra, out B rb))
            {
                ReferenceEquals(ra, a);
                ReferenceEquals(rb, b);
                ReferenceEquals(rb.A, a);
                ReferenceEquals(rb.A, ra);
            }
        }

        [Serializable]
        protected class A
        {
            public int MyProperty { get; set; }
        }

        [Serializable]
        protected class B
        {
            public string Name { get; set; }
            public A A { get; set; }
        }

        [TestMethod]
        public void GetUniqueFilePath_ExistingNumberExtension_Test()
        {
            const string rawPath = "FileTest (1).txt";
            var actual = rawPath.GetUniqueFilePath();
            const string expected = "FileTest (2).txt";
            Assert.AreEqual(expected, actual);
        }
    }
}