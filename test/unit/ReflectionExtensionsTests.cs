using Microsoft.VisualStudio.TestTools.UnitTesting;
using KtExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace KtExtensions.Tests
{
    [TestClass]
    public class ReflectionExtensionsTests
    {
        public class DummyObj
        {
            public int IntProperty { get; set; }

            public string StringProperty { get; set; }

            public double DoubleProperty { get; set; }
        }

        public class DummyA
        {
            public int Id { get; set; } = 21;
        }

        public class DummyB
        {
            public DummyA Prop { get; set; } = new DummyA();
        }

        public class DummyC
        {
            public DummyB Prop { get; set; } = new DummyB();
        }

        public class DummyD
        {
            public DummyC Prop { get; set; } = new DummyC();
        }

        [TestMethod]
        public void GetCascadedPropertyValueTest()
        {
            object DummyD = new DummyD();
            Assert.AreEqual(DummyD.GetCascadedPropertyValue(new[] { "Prop", "Prop", "Prop", "Id" }), 21);
            Assert.IsNull(DummyD.GetCascadedPropertyValue(new[] { "Prop", "Prop", "Prop", "Id", "NonExistentProperty" }));
            Assert.AreEqual(DummyD.GetCascadedPropertyValue(new[] { "Prop", "Prop", "Prop" }).GetType(), typeof(DummyA));
            Assert.AreEqual(DummyD.GetCascadedPropertyValue(new[] { "Prop", "Prop" }).GetType(), typeof(DummyB));
            Assert.AreEqual(DummyD.GetCascadedPropertyValue(new[] { "Prop" }).GetType(), typeof(DummyC));
            Assert.AreEqual(DummyD.GetCascadedPropertyValue(Array.Empty<string>()).GetType(), typeof(DummyD));
            Assert.AreEqual(DummyD.GetCascadedPropertyValue((string[])null).GetType(), typeof(DummyD));
        }

        [TestMethod]
        public void GetCascadedPropertyValueTest2()
        {
            object DummyD = new DummyD();
            Assert.AreEqual(DummyD.GetCascadedPropertyValue("Prop.Prop.Prop.Id"), 21);
            Assert.IsNull(DummyD.GetCascadedPropertyValue("Prop.Prop.Prop.Id.NonExistentProperty"));
            Assert.AreEqual(DummyD.GetCascadedPropertyValue("Prop.Prop.Prop").GetType(), typeof(DummyA));
            Assert.AreEqual(DummyD.GetCascadedPropertyValue("Prop.Prop").GetType(), typeof(DummyB));
            Assert.AreEqual(DummyD.GetCascadedPropertyValue("Prop").GetType(), typeof(DummyC));
            Assert.AreEqual(DummyD.GetCascadedPropertyValue((string)null).GetType(), typeof(DummyD));
        }

        [TestMethod]
        public void GetPropertyValues_ForIenumerable_Test()
        {
            var dummyObjects = new List<DummyObj>();
            for (int i = 0; i < 20; i++)
            {
                dummyObjects.Add(new DummyObj() { IntProperty = 2 + i, StringProperty = "What" + i, DoubleProperty = 4.1 + i });
            }
            var (headers, content) = dummyObjects.GetPropertyValues();
            var names = headers;
            var vals = content;
            Assert.AreEqual(names.Length, 3);
            Assert.AreEqual(vals.GetLength(0), 20);
            Assert.AreEqual(vals.GetLength(1), 3);

            Assert.AreEqual(names[0], "IntProperty");
            Assert.AreEqual(names[2], "DoubleProperty");
            Assert.AreEqual(names[1], "StringProperty");
            for (int i = 0; i < vals.GetLength(0); i++)
            {
                Assert.AreEqual(vals[i, 0], 2 + i);
            }
            for (int i = 0; i < vals.GetLength(0); i++)
            {
                Assert.AreEqual(vals[i, 1], "What" + i);
            }
            for (int i = 0; i < vals.GetLength(0); i++)
            {
                Assert.AreEqual(vals[i, 2], 4.1 + i);
            }
        }

        [TestMethod]
        public void GetPropertyValuesTest()
        {
            var newDummyObject = new DummyObj() { IntProperty = 2, StringProperty = "What", DoubleProperty = 4.1 };
            var propertyValues = newDummyObject.GetPropertyValues();
            Assert.AreEqual(propertyValues.Count, 3);
            TestPropertyExistence(propertyValues, "IntProperty", 2);
            TestPropertyExistence(propertyValues, "StringProperty", "What");
            TestPropertyExistence(propertyValues, "DoubleProperty", 4.1);
        }

        private static void TestPropertyExistence(IDictionary<string, object> propertyValues, string name, object value)
        {
            Assert.IsTrue(propertyValues.ContainsKey(name));
            Assert.AreEqual(propertyValues[name], value);
        }
    }
}