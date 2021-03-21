using Microsoft.VisualStudio.TestTools.UnitTesting;
using KtExtensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace KtExtensions.Tests
{
    public abstract class TrialClass : IEquatable<TrialClass>
    {
        protected TrialClass(int value)
        {
            Value = value;
        }

        public int Value { get; }

        public abstract bool Equals(TrialClass other);

        public abstract override bool Equals(object obj);

        public abstract override int GetHashCode();
    }

    public class DerivedTrialClassA : TrialClass, IEquatable<DerivedTrialClassA>
    {
        public DerivedTrialClassA(int value, string value2) : base(value)
        {
            Value2 = value2;
        }

        public string Value2 { get; }

        public override bool Equals(TrialClass other) => Equals(other as DerivedTrialClassA);

        public override int GetHashCode() => unchecked(1944619720.ChainHashCode(Value).ChainHashCode(Value2));

        public override bool Equals(object obj) => Equals(obj as DerivedTrialClassA);

        public bool Equals(DerivedTrialClassA other) => this.TestNullBeforeEquals(other, () => Value == other.Value && Value2 == other.Value2);

        public static bool operator ==(DerivedTrialClassA a1, DerivedTrialClassA a2) => a1.DefaultEquals(a2);

        public static bool operator !=(DerivedTrialClassA a1, DerivedTrialClassA a2) => !(a1 == a2);
    }

    public class DerivedTrialClassB : TrialClass, IEquatable<DerivedTrialClassB>
    {
        public DerivedTrialClassB(int value, int value2) : base(value)
        {
            Value2 = value2;
        }

        public int Value2 { get; }

        public bool Equals(DerivedTrialClassB other) => this.TestNullBeforeEquals(other, () => Value == other.Value && Value2 == other.Value2);

        public override bool Equals(TrialClass other) => Equals(other is DerivedTrialClassB);

        public override int GetHashCode() => unchecked(1944619720.ChainHashCode(Value).ChainHashCode(Value2));

        public override bool Equals(object obj) => Equals(obj as DerivedTrialClassB);

        public static bool operator ==(DerivedTrialClassB b1, DerivedTrialClassB b2) => b1.DefaultEquals(b2);

        public static bool operator !=(DerivedTrialClassB b1, DerivedTrialClassB b2) => !(b1 == b2);
    }

    public class DerivedTrialClassC : TrialClass, IEquatable<DerivedTrialClassC>
    {
        public DerivedTrialClassC(int value, double value2) : base(value)
        {
            Value2 = value2;
        }

        public double Value2 { get; }

        public override bool Equals(TrialClass other) => Equals(other as DerivedTrialClassC);

        public bool Equals(DerivedTrialClassC other) => this.TestNullBeforeEquals(other, () => Value == other.Value && Value2.NearEqual(other.Value2));

        public override int GetHashCode() => unchecked(1944619720.ChainHashCode(Value).ChainHashCode(Value2));

        public override bool Equals(object obj) => Equals(obj as DerivedTrialClassC);

        public static bool operator ==(DerivedTrialClassC c1, DerivedTrialClassC c2) => c1.DefaultEquals(c2);

        public static bool operator !=(DerivedTrialClassC c1, DerivedTrialClassC c2) => !(c1 == c2);
    }

    [TestClass]
    public class EqualityExtensions
    {
        [TestMethod]
        public void DefaultEqualityTest()
        {
            var trial1 = new DerivedTrialClassB(10, 10);
            var trial2 = new DerivedTrialClassB(10, 10);
            var trial3 = trial1;
            var trial4 = new DerivedTrialClassB(5, 5);
            Assert.IsTrue(trial1.DefaultEquals(trial2));
            Assert.IsTrue(trial1.DefaultEquals(trial3));
            Assert.IsFalse(trial1.DefaultEquals(trial4));
            trial1 = null;
            Assert.IsTrue(trial1.DefaultEquals(null));
        }

        [TestMethod]
        public void CheckNullTest()
        {
            TrialClass t = null;
            Assert.IsTrue(t.TestNullBeforeEquals(null, () => false));
            TrialClass t2 = null;
            Assert.IsTrue(t.TestNullBeforeEquals(t2, () => false));
            t2 = new DerivedTrialClassB(10, 10);
            Assert.IsFalse(t.TestNullBeforeEquals(t2, () => true));
            t = t2;
            Assert.IsTrue(t.TestNullBeforeEquals(t2, () => false));
            t = new DerivedTrialClassB(2, 2);
            Assert.IsTrue(t.TestNullBeforeEquals(t2, () => true));
        }
    }

    [TestClass]
    public class Array2DTests
    {
        [TestMethod]
        public void SelectRowsTest()
        {
            var array = new double[5, 5];
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    array[i, j] = (i / 10).RaiseTo(j);
                }
            }
            var expected = new List<double>();
            var expected2 = new List<double>();
            for (int i = 0; i < 5; i++)
            {
                var init = 0.0;
                var init2 = 0.0;
                for (int j = 0; j < 5; j++)
                {
                    init += array[i, j];
                    init2 += array[i, j] + 1;
                }
                expected.Add(init);
                expected2.Add(init2);
            }
            Assert.IsTrue(array.SelectRows(ienumerable => ienumerable.Sum()).SequenceEqual(expected));
            Assert.IsTrue(array.SelectRows(elem => elem + 1, ienumerable => ienumerable.Sum()).SequenceEqual(expected2));
        }

        [TestMethod]

        public void SelectColsTest()
        {
            var array = new double[5, 5];
            for (int j = 0; j < 5; j++)
            {
                for (int i = 0; i < 5; i++)
                {
                    array[i, j] = (i / 10).RaiseTo(j);
                }
            }
            var expected = new List<double>();
            var expected2 = new List<double>();
            for (int j = 0; j < 5; j++)
            {
                var init = 0.0;
                var init2 = 0.0;
                for (int i = 0; i < 5; i++)
                {
                    init += array[i, j];
                    init2 += array[i, j] + 1;
                }
                expected.Add(init);
                expected2.Add(init2);
            }
            Assert.IsTrue(array.SelectCols(ienumerable => ienumerable.Sum()).SequenceEqual(expected));
            Assert.IsTrue(array.SelectCols(elem => elem + 1, ienumerable => ienumerable.Sum()).SequenceEqual(expected2));
        }

        [TestMethod]
        public void TestRemoveMultipleRow()
        {
            var array = new double[5, 5];
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    array[i, j] = (i * i) + j;
                }
            }
            var actualArray = array.DeleteRow(new long[] { 1, 3 });
            var expectedArray = new double[,] { { 0, 1, 2, 3, 4 }, { 4, 5, 6, 7, 8 }, { 16, 17, 18, 19, 20 } };
            var expectedArray2 = array.DeleteRow(new long[] { 3, 1 });
            Console.WriteLine(actualArray.TabbedToString());
            Console.WriteLine(expectedArray.TabbedToString());
            Assert.IsTrue(actualArray.SequenceEqual(expectedArray));
            Assert.IsTrue(actualArray.SequenceEqual(expectedArray2));
        }

        [TestMethod]
        public void TestRemoveMultipleCol()
        {
            var array = new double[10, 10];
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    array[i, j] = (i * i) + j;
                }
            }
            var actualArray = array.DeleteCol(new long[] { 1, 5, 3, 7 });
            var expectedArray = new double[10, 6];
            for (int i = 0; i < 10; i++)
            {
                expectedArray[i, 0] = i * i;
                expectedArray[i, 1] = (i * i) + 2;
                expectedArray[i, 2] = (i * i) + 4;
                expectedArray[i, 3] = (i * i) + 6;
                expectedArray[i, 4] = (i * i) + 8;
                expectedArray[i, 5] = (i * i) + 9;
            }
            var expectedArray2 = array.DeleteCol(new long[] { 5, 3, 1, 7 });
            Console.WriteLine(actualArray.TabbedToString());
            Console.WriteLine(expectedArray.TabbedToString());
            Assert.IsTrue(actualArray.SequenceEqual(expectedArray));
            Assert.IsTrue(actualArray.SequenceEqual(expectedArray2));
        }
    }
}