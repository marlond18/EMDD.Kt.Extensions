using System;
using System.Collections.Generic;
using System.Linq;

namespace KtExtensions
{
    /// <summary>
    /// List Extensions
    /// </summary>
    public static class ListExtensions
    {
        /// <summary>
        /// swap elements of a List
        /// </summary>
        /// <param name="list"></param>
        /// <param name="index1">index of row 1</param>
        /// <param name="index2">index of row 2</param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static void Swap<T>(this List<T> list, int index1, int index2)
        {
            if (list == null || index1 == index2) return;
            var count = list.Count;
            if (!index1.IsWithin(0, count)) return;
            if (!index2.IsWithin(0, count)) return;
            var temp = list[index1];
            list[index1] = list[index2];
            list[index2] = temp;
        }

        /// <summary>
        /// Run for loop using <paramref name="action"/> which takes in <see cref="int"/> index and the item of <typeparamref name="T"/>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="action">is null, the method will not run</param>
        public static void IndexedForEach<T>(this List<T> list, Action<T, int> action)
        {
            if (action == null) return;
            for (int i = 0; i < list.Count; i++) { action(list[i], i); }
        }

        /// <summary>
        /// Find the Element and return its index
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="item"></param>
        /// <param name="comparer"></param>
        /// <returns></returns>
        public static (bool found, int index) FoundAt<T>(this List<T> list, T item, IEqualityComparer<T> comparer)
        {
            for (int j = 0; j < list.Count; j++)
            {
                if (comparer.Equals(item, list[j]))
                {
                    return (true, j);
                }
            }
            return (false, -1);
        }

        /// <summary>
        /// Find the Element and return its index using the Default Equality Comparer
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="item"></param>
        /// <returns></returns>
        public static (bool found, int index) FoundAt<T>(this List<T> list, T item)
        {
            for (int j = 0; j < list.Count; j++)
            {
                if (item.DefaultEquals(list[j])) return (true, j);
            }
            return (false, -1);
        }

        /// <summary>
        /// Deep Clone a List
        /// </summary>
        /// <param name="listToClone"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static List<T> Clone<T>(this List<T> listToClone) where T : ICloneable
            => listToClone.ConvertAll(item => (T)item.Clone());

        /// <summary>
        /// Loop through a List using the two consecutive elements
        /// </summary>
        /// <param>
        ///     <name>listToLoop</name>
        /// </param>
        /// <param name="listToLoop">The list for looping, count must be beyond 2</param>
        /// <param name="action"></param>
        /// <typeparam name="T"></typeparam>
        public static void LoopTwoEach<T>(this List<T> listToLoop, Action<T, T> action)
        {
            if (action == null) return;
            if (listToLoop.Count < 2) return;
            for (var i = 0; i < listToLoop.Count - 1; i++)
            {
                var e1 = listToLoop[i];
                var e2 = listToLoop[i + 1];
                action(e1, e2);
            }
        }

        /// <summary>
        /// Determine the first pair in list that passed the test
        /// </summary>
        /// <param name="listToLoop"></param>
        /// <param name="test"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns>if fails it returns null</returns>
        public static T[] FirstPair<T>(this List<T> listToLoop, Func<T, T, bool> test)
        {
            if (test == null) return null;
            if (listToLoop.Count < 2) return null;
            for (var i = 0; i < listToLoop.Count - 1; i++)
            {
                var e1 = listToLoop[i];
                var e2 = listToLoop[i + 1];
                if (test(e1, e2)) return new[] { e1, e2 };
            }
            return null;
        }
    }
}