using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace KtExtensions
{
    /// <summary>
    /// Extensions for Ienumerable
    /// </summary>
    public static class EnumerableExtensions
    {
        /// <summary>
        /// Get the Underlaying type of items inside an Ilist
        /// </summary>
        /// <param name="myList"></param>
        /// <returns></returns>
        public static Type HeuristicallyDetermineType(this IList myList)
        {
            var enumerable_type = myList.GetType().GetInterfaces().Where(i => i.IsGenericType && i.GenericTypeArguments.Length == 1).FirstOrDefault(i => i.GetGenericTypeDefinition() == typeof(IEnumerable<>));
            if (enumerable_type != null) return enumerable_type.GenericTypeArguments[0];
            if (myList.Count == 0) return null;
            return myList[0].GetType();
        }

        /// <summary>
        /// Use the whole word as suggestion
        /// </summary>
        /// <param name="items"></param>
        /// <param name="keyword"></param>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        public static IEnumerable FilterSuggestion(this IEnumerable items, string keyword, string propertyName = null)
        {
            if (string.IsNullOrEmpty(keyword)) return items;
            var propertykey = keyword.ToLower();
            if (propertyName.IsNullOrEmpty()) return items.Cast<object>().WhereNot(o => o is null).Where(o => o.ToString().ToLower().StartsWith(propertykey)).ToList();
            return items.Cast<object>().WhereNot(o => o is null).Where(o => o.PropertyValueString(propertyName).ToLower().StartsWith(propertykey)).ToList();
        }

        /// <summary>
        /// Search filter ienumerable
        /// </summary>
        /// <param name="items"></param>
        /// <param name="keyword"></param>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        public static IEnumerable FilterSuggestions(this IEnumerable items, string keyword, string propertyName = null)
        {
            if (string.IsNullOrEmpty(keyword)) return items;
            return InnerFilter(items, new string[] { keyword }, propertyName);
        }

        private static IEnumerable<object> InnerFilter(this IEnumerable items, string[] keywords, string propertyName)
        {
            if (propertyName.IsNullOrEmpty())
                return items.Cast<object>().WhereNot(o => o is null).Where(o => keywords.All(o.ToString().ToLower().StartsWith)).ToList();
            return items.Cast<object>().WhereNot(o => o is null).Where(o => keywords.All(o.PropertyValueString(propertyName).ToLower().StartsWith)).ToList();
        }

        /// <summary>
        /// 3 boolean type
        /// </summary>
        ///
        public enum Ternary
        {
            /// <summary>
            /// false
            /// </summary>
            False = -1,

            /// <summary>
            /// nuetral
            /// </summary>
            Neutral = 0,

            /// <summary>
            /// true
            /// </summary>
            True = 1
        }

        /// <summary>
        /// Determine if two collections have the same content
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool ContentEquals<T>(this IEnumerable<T> a, IEnumerable<T> b)
        {
            if (a.IsEmpty() && b.IsEmpty()) return true;
            if (a.IsEmpty() || b.IsEmpty() || a.Count() != b.Count()) return false;
            return a.All(b.Contains) && b.All(a.Contains);
        }

        /// <summary>
        /// Ienumerable.OfType but takes two type signature
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <param name="main"></param>
        /// <returns></returns>
        public static (IEnumerable<T1> enum1, IEnumerable<T2> enum2) OfType<T1, T2>(this IEnumerable main)
        {
            var list1 = new List<T1>();
            var list2 = new List<T2>();
            foreach (var item in main)
            {
                if (item is T1 t1) list1.Add(t1);
                if (item is T2 t2) list2.Add(t2);
            }
            return (list1, list2);
        }

        /// <summary>
        /// Ienumerable.OfType but takes three type signature
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <param name="main"></param>
        /// <returns></returns>
        public static (IEnumerable<T1> enum1, IEnumerable<T2> enum2, IEnumerable<T3> enum3) OfType<T1, T2, T3>(this IEnumerable main)
        {
            var list1 = new List<T1>();
            var list2 = new List<T2>();
            var list3 = new List<T3>();
            foreach (var item in main)
            {
                if (item is T1 t1) list1.Add(t1);
                if (item is T2 t2) list2.Add(t2);
                if (item is T3 t3) list3.Add(t3);
            }
            return (list1, list2, list3);
        }

        /// <summary>
        /// Ienumerable.OfType but takes four type signature
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <param name="main"></param>
        /// <returns></returns>
        public static (IEnumerable<T1> enum1, IEnumerable<T2> enum2, IEnumerable<T3> enum3, IEnumerable<T4> enum4) OfType<T1, T2, T3, T4>(this IEnumerable main)
        {
            var list1 = new List<T1>();
            var list2 = new List<T2>();
            var list3 = new List<T3>();
            var list4 = new List<T4>();
            foreach (var item in main)
            {
                if (item is T1 t1) list1.Add(t1);
                if (item is T2 t2) list2.Add(t2);
                if (item is T3 t3) list3.Add(t3);
                if (item is T4 t4) list4.Add(t4);
            }
            return (list1, list2, list3, list4);
        }

        /// <summary>
        /// Ienumerable.OfType but takes five type signature
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="T5"></typeparam>
        /// <param name="main"></param>
        /// <returns></returns>
        public static (IEnumerable<T1> enum1, IEnumerable<T2> enum2, IEnumerable<T3> enum3, IEnumerable<T4> enum4, IEnumerable<T5> enum5) OfType<T1, T2, T3, T4, T5>(this IEnumerable main)
        {
            var list1 = new List<T1>();
            var list2 = new List<T2>();
            var list3 = new List<T3>();
            var list4 = new List<T4>();
            var list5 = new List<T5>();
            foreach (var item in main)
            {
                if (item is T1 t1) list1.Add(t1);
                if (item is T2 t2) list2.Add(t2);
                if (item is T3 t3) list3.Add(t3);
                if (item is T4 t4) list4.Add(t4);
                if (item is T5 t5) list5.Add(t5);
            }
            return (list1, list2, list3, list4, list5);
        }

        /// <summary>
        /// Ienumerable.OfType but takes six type signature
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="T5"></typeparam>
        /// <typeparam name="T6"></typeparam>
        /// <param name="main"></param>
        /// <returns></returns>
        public static (IEnumerable<T1> enum1, IEnumerable<T2> enum2, IEnumerable<T3> enum3, IEnumerable<T4> enum4, IEnumerable<T5> enum5, IEnumerable<T6> enum6) OfType<T1, T2, T3, T4, T5, T6>(this IEnumerable main)
        {
            var list1 = new List<T1>();
            var list2 = new List<T2>();
            var list3 = new List<T3>();
            var list4 = new List<T4>();
            var list5 = new List<T5>();
            var list6 = new List<T6>();
            foreach (var item in main)
            {
                if (item is T1 t1) list1.Add(t1);
                if (item is T2 t2) list2.Add(t2);
                if (item is T3 t3) list3.Add(t3);
                if (item is T4 t4) list4.Add(t4);
                if (item is T5 t5) list5.Add(t5);
                if (item is T6 t6) list6.Add(t6);
            }
            return (list1, list2, list3, list4, list5, list6);
        }

        /// <summary>
        /// Ienumerable.OfType but takes 7 type signature
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="T5"></typeparam>
        /// <typeparam name="T6"></typeparam>
        /// <typeparam name="T7"></typeparam>
        /// <param name="main"></param>
        /// <returns></returns>
        public static (IEnumerable<T1> enum1, IEnumerable<T2> enum2, IEnumerable<T3> enum3, IEnumerable<T4> enum4, IEnumerable<T5> enum5, IEnumerable<T6> enum6, IEnumerable<T7> enum7) OfType<T1, T2, T3, T4, T5, T6, T7>(this IEnumerable main)
        {
            var list1 = new List<T1>();
            var list2 = new List<T2>();
            var list3 = new List<T3>();
            var list4 = new List<T4>();
            var list5 = new List<T5>();
            var list6 = new List<T6>();
            var list7 = new List<T7>();
            foreach (var item in main)
            {
                if (item is T1 t1) list1.Add(t1);
                if (item is T2 t2) list2.Add(t2);
                if (item is T3 t3) list3.Add(t3);
                if (item is T4 t4) list4.Add(t4);
                if (item is T5 t5) list5.Add(t5);
                if (item is T6 t6) list6.Add(t6);
                if (item is T7 t7) list7.Add(t7);
            }
            return (list1, list2, list3, list4, list5, list6, list7);
        }

        /// <summary>
        /// Ienumerable.OfType but takes 8 type signature
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="T5"></typeparam>
        /// <typeparam name="T6"></typeparam>
        /// <typeparam name="T7"></typeparam>
        /// <typeparam name="T8"></typeparam>
        /// <param name="main"></param>
        /// <returns></returns>
        public static (IEnumerable<T1> enum1, IEnumerable<T2> enum2, IEnumerable<T3> enum3, IEnumerable<T4> enum4, IEnumerable<T5> enum5, IEnumerable<T6> enum6, IEnumerable<T7> enum7, IEnumerable<T8> enum8) OfType<T1, T2, T3, T4, T5, T6, T7, T8>(this IEnumerable main)
        {
            var list1 = new List<T1>();
            var list2 = new List<T2>();
            var list3 = new List<T3>();
            var list4 = new List<T4>();
            var list5 = new List<T5>();
            var list6 = new List<T6>();
            var list7 = new List<T7>();
            var list8 = new List<T8>();
            foreach (var item in main)
            {
                if (item is T1 t1) list1.Add(t1);
                if (item is T2 t2) list2.Add(t2);
                if (item is T3 t3) list3.Add(t3);
                if (item is T4 t4) list4.Add(t4);
                if (item is T5 t5) list5.Add(t5);
                if (item is T6 t6) list6.Add(t6);
                if (item is T7 t7) list7.Add(t7);
                if (item is T8 t8) list8.Add(t8);
            }
            return (list1, list2, list3, list4, list5, list6, list7, list8);
        }

        /// <summary>
        /// Partition collection and aggregate Results stored in a dictionary
        /// </summary>
        /// <typeparam name="TBase"></typeparam>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TComparer"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="collection"></param>
        /// <param name="getKey"></param>
        /// <param name="comparer"></param>
        /// <param name="getValue"></param>
        /// <param name="func"></param>
        /// <returns></returns>
        public static Dictionary<TKey, TValue> AggregatePartition<TBase, TKey, TComparer, TValue>(this IEnumerable<TBase> collection, Func<TBase, TKey> getKey, TComparer comparer, Func<TBase, TValue> getValue, Func<TValue, TValue, TValue> func) where TComparer : IEqualityComparer<TKey>
        {
            var p = new Dictionary<TKey, TValue>(comparer);
            foreach (var item in collection)
            {
                var key = getKey(item);
                var value = getValue(item);
                if (p.TryGetValue(key, out TValue oldValue))
                {
                    p[key] = func(oldValue, value);
                }
                else
                {
                    p.Add(key, value);
                }
            }
            return p;
        }

        /// <summary>
        /// Partition collection and aggregate Results stored in a dictionary
        /// </summary>
        /// <typeparam name="TBase"></typeparam>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="collection"></param>
        /// <param name="getKey"></param>
        /// <param name="getValue"></param>
        /// <param name="func"></param>
        /// <returns></returns>
        public static Dictionary<TKey, TValue> AggregatePartition<TBase, TKey, TValue>(this IEnumerable<TBase> collection, Func<TBase, TKey> getKey, Func<TBase, TValue> getValue, Func<TValue, TValue, TValue> func)
        {
            var p = new Dictionary<TKey, TValue>();
            foreach (var item in collection)
            {
                var key = getKey(item);
                var value = getValue(item);
                if (p.TryGetValue(key, out TValue oldValue))
                {
                    p[key] = func(oldValue, value);
                }
                else
                {
                    p.Add(key, value);
                }
            }
            return p;
        }

        /// <summary>
        /// Partition collection and aggregate Results
        /// </summary>
        /// <typeparam name="TBase"></typeparam>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="collection"></param>
        /// <param name="getKey"></param>
        /// <param name="getValue"></param>
        /// <param name="func"></param>
        /// <param name="getOutput"></param>
        /// <returns></returns>
        public static IEnumerable<TResult> AggregatePartition<TBase, TKey, TValue, TResult>(this IEnumerable<TBase> collection, Func<TBase, TKey> getKey, Func<TBase, TValue> getValue, Func<TValue, TValue, TValue> func, Func<TKey, TValue, TResult> getOutput) =>
            collection.AggregatePartition(getKey, getValue, func).Select(item =>
            getOutput(item.Key, item.Value));

        /// <summary>
        /// Partition collection and aggregate Results
        /// </summary>
        /// <typeparam name="TBase"></typeparam>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TComparer"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="collection"></param>
        /// <param name="getKey"></param>
        /// <param name="comparer"></param>
        /// <param name="getValue"></param>
        /// <param name="func"></param>
        /// <param name="getOutput"></param>
        /// <returns></returns>
        public static IEnumerable<TResult> AggregatePartition<TBase, TKey, TComparer, TValue, TResult>(this IEnumerable<TBase> collection, Func<TBase, TKey> getKey, TComparer comparer, Func<TBase, TValue> getValue, Func<TValue, TValue, TValue> func, Func<TKey, TValue, TResult> getOutput) where TComparer : IEqualityComparer<TKey> =>
            collection.AggregatePartition(getKey, comparer, getValue, func).Select(item => getOutput(item.Key, item.Value));

        /// <summary>
        /// Get the minimum and maximum value of enumerable based on <paramref name="IsLesser"/> and <paramref name="IsGreater"/>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="enumerable"></param>
        /// <param name="IsLesser"> Check if a value is lesser that another</param>
        /// <param name="IsGreater">Check if a value is greater that another</param>
        /// <returns></returns>
        public static (T, T) MinMax<T>(this IEnumerable<T> enumerable, Func<T, T, bool> IsLesser, Func<T, T, bool> IsGreater)
        {
            T lesser = default;
            T greater = default;
            foreach (var item in enumerable)
            {
                if (IsGreater(item, greater)) greater = item;
                if (IsLesser(item, lesser)) lesser = item;
            }
            return (lesser, greater);
        }

        /// <summary>
        /// Determine where the min and max value of <typeparamref name="T"/> resulting to double, from an ienumerable <paramref name="enumerable"/>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="enumerable"></param>
        /// <param name="func"> function to convert the item <typeparamref name="T"/> to a <see cref="double"/> </param>
        /// <returns></returns>
        public static (double min, double max) MinMax<T>(this IEnumerable<T> enumerable, Func<T, double> func)
        {
            double lesser = 0;
            double greater = 0;
            foreach (var item in enumerable)
            {
                var itemVal = func(item);
                if (itemVal < lesser) lesser = itemVal;
                if (itemVal > greater) greater = itemVal;
            }
            return (lesser, greater);
        }

        /// <summary>
        /// Determine where the min and max value of <typeparamref name="T"/> resulting to double, from an ienumerable <paramref name="enumerable"/>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="enumerable"></param>
        /// <param name="func"> function to convert the item <typeparamref name="T"/> to a <see cref="int"/> </param>
        /// <returns></returns>
        public static (int min, int max) MinMax<T>(this IEnumerable<T> enumerable, Func<T, int> func)
        {
            int lesser = 0;
            int greater = 0;
            foreach (var item in enumerable)
            {
                var itemVal = func(item);
                if (itemVal < lesser) lesser = itemVal;
                if (itemVal > greater) greater = itemVal;
            }
            return (lesser, greater);
        }

        /// <summary>
        /// IEnumerable Select But using successive pairs
        /// </summary>
        /// <param name="inum"></param>
        /// <param name="method"></param>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TD"></typeparam>
        /// <returns></returns>
        /// <exception cref="NullReferenceException">method cannot be null</exception>
        public static IEnumerable<TD> SelectPair<T, TD>(this IEnumerable<T> inum, Func<T, T, TD> method)
        {
            var list = inum.ToList();
            if (method == null) throw new NullReferenceException("Method is null");
            if (list.Count < 2)
            {
                yield return default;
                yield break;
            }
            for (var i = 1; i < list.Count; i++)
            {
                yield return method(list[i - 1], list[i]);
            }
        }

        /// <summary>
        /// same Linq -Where but the predicate is negated
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="enumerable"></param>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public static IEnumerable<T> WhereNot<T>(this IEnumerable<T> enumerable, Predicate<T> predicate) =>
            enumerable.Where(elem => !predicate(elem));

        /// <summary>
        /// Exclude <paramref name="other"/> from the query
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="enumerable"></param>
        /// <param name="other"></param>
        /// <returns></returns>
        public static IEnumerable<T> WhereNot<T>(this IEnumerable<T> enumerable, T other) => enumerable.Where(elem => !elem.DefaultEquals(other));

        /// <summary>
        /// Exclude <paramref name="others"/> from the query
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="enumerable"></param>
        /// <param name="others"></param>
        /// <returns></returns>
        public static IEnumerable<T> WhereNot<T>(this IEnumerable<T> enumerable, IEnumerable<T> others) => enumerable.WhereNot(others.Contains);

        /// <summary>
        /// Partition
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <param name="enumerable"></param>
        /// <param name="func"></param>
        /// <returns></returns>
        public static Partition<T1, T2> Partition<T1, T2>(this IEnumerable<T2> enumerable, Func<T2, T1> func)
        {
            var partition = new Partition<T1, T2>();
            if (enumerable == null || func == null) return partition;
            foreach (var item in enumerable)
            {
                partition[func(item)].Add(item);
            }
            return partition;
        }

        /// <summary>
        /// Extended Concat Method where the enumerable to be concatenated is params
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="enumerable"></param>
        /// <param name="toConCat"></param>
        /// <returns></returns>
        public static IEnumerable<T> Concat<T>(this IEnumerable<T> enumerable, params IEnumerable<T>[] toConCat) =>
            enumerable?.Union(toConCat.SelectMany(d => d));

        /// <summary>
        /// Get the first item on both enumerable that satifies the boolean function
        /// </summary>
        /// <typeparam name="Tfirst"></typeparam>
        /// <typeparam name="Tsecond"></typeparam>
        /// <param name="pair"></param>
        /// <param name="func"></param>
        /// <returns></returns>
        public static (Tfirst first1, Tsecond first2) FirstOfBoth<Tfirst, Tsecond>(this (IEnumerable<Tfirst> a, IEnumerable<Tsecond> b) pair, Func<Tfirst, Tsecond, bool> func)
        {
            foreach (var a in pair.a)
            {
                foreach (var b in pair.b)
                {
                    if (func(a, b)) return (a, b);
                }
            }
            return (default(Tfirst), default(Tsecond));
        }

        /// <summary>
        /// Check if a collection contains any data
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="enumerable"></param>
        /// <returns></returns>
        public static bool IsEmpty<T>(this IEnumerable<T> enumerable) => enumerable?.Any() != true;

        /// <summary>
        /// Combined Aggregate and Select
        /// </summary>
        /// <typeparam name="TBase"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="enumerable"></param>
        /// <param name="seed"></param>
        /// <param name="func"></param>
        /// <returns></returns>
        public static IEnumerable<TResult> AggregateSelect<TBase, TResult>(this IEnumerable<TBase> enumerable, TResult seed, Func<TResult, TBase, TResult> func)
        {
            if (enumerable == null || func == null) yield break;
            yield return seed;
            var initResult = seed;
            foreach (var item in enumerable)
            {
                initResult = func(initResult, item);
                yield return initResult;
            }
        }

        /// <summary>
        /// Return an ienumerable of a tuple paired for a successive items
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="inum"></param>
        /// <returns></returns>
        public static IEnumerable<(T first, T second)> SelectPair<T>(this IEnumerable<T> inum)
        {
            var list = inum.ToList();
            if (list.Count < 2) yield break;
            for (var i = 1; i < list.Count; i++)
            {
                yield return (list[i - 1], list[i]);
            }
        }

        /// <summary>
        /// Exclusion Inclusion of Elements of two collections
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="ienums"></param>
        /// <param name="comparer"></param>
        /// <returns></returns>
        public static (IEnumerable<T> OnlyA, IEnumerable<T> AandB, IEnumerable<T> OnlyB) Venn<T>(this (IEnumerable<T> A, IEnumerable<T> B) ienums, IEqualityComparer<T> comparer)
        {
            var onlyA = new List<T>();
            var AandB = new List<T>();
            var A = ienums.A.ToList();
            var B = ienums.B.ToList();
            for (int i = 0; i < A.Count; i++)
            {
                var a = A[i];
                var (found, foundAt) = B.FoundAt(a, comparer);
                if (found)
                {
                    B.RemoveAt(foundAt);
                    AandB.Add(a);
                }
                else
                {
                    onlyA.Add(a);
                }
            }
            return (onlyA, AandB, B);
        }

        /// <summary>
        /// Venn Group Elements of two enumerables based on venn diagram rep
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="AA"></param>
        /// <param name="BB"></param>
        /// <returns></returns>
        public static (IEnumerable<T> OnlyA, IEnumerable<T> AandB, IEnumerable<T> OnlyB) Venn<T>(this IEnumerable<T> AA, IEnumerable<T> BB)
        {
            var onlyA = new List<T>();
            var AandB = new List<T>();
            var A = AA.ToList();
            var B = BB.ToList();
            for (int i = 0; i < A.Count; i++)
            {
                var a = A[i];
                var (found, foundAt) = B.FoundAt(a);
                if (found)
                {
                    B.RemoveAt(foundAt);
                    AandB.Add(a);
                }
                else
                {
                    onlyA.Add(a);
                }
            }
            return (onlyA, AandB, B);
        }

        /// <summary>
        /// Splits an ienumerable in two based on the boolean condition stated,
        /// <para /> Reference:
        /// <para /> Byers, M (2010,December 28) C#: Can I split an IEnumerable into two by a boolean criteria without two queries? [Online forum comment].Message to
        ///        posted to https://stackoverflow.com/questions/4549339/can-i-split-an-ienumerable-into-two-by-a-boolean-criteria-without-two-queries
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="source">the Ienumerable to be split</param>
        /// <param name="pred">boolean condition</param>
        /// <returns>value tuple 2 two groups</returns>
        public static (IEnumerable<T> matches, IEnumerable<T> nonMatches) Fork<T>(this IEnumerable<T> source, Func<T, bool> pred)
        {
            var listTrue = new List<T>();
            var listFalse = new List<T>();
            if (pred == null) throw new NullReferenceException("The Predicate is missing");
            foreach (var item in source)
            {
                if (pred(item)) listTrue.Add(item);
                else listFalse.Add(item);
            }
            return (listTrue, listFalse);
        }

        /// <summary>
        /// Two way fork by using Ternary conditions
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="pred"></param>
        /// <returns></returns>
        public static (IEnumerable<T> False, IEnumerable<T> Neutral, IEnumerable<T> True) Fork<T>(this IEnumerable<T> source, Func<T, Ternary> pred)
        {
            var listTrue = new List<T>();
            var listNeutral = new List<T>();
            var listFalse = new List<T>();
            if (pred == null) throw new NullReferenceException("The Predicate is missing");
            foreach (var item in source)
            {
                if (pred(item) == Ternary.True) listTrue.Add(item);
                else if (pred(item) == Ternary.False) listFalse.Add(item);
                else listNeutral.Add(item);
            }
            return (listTrue, listNeutral, listFalse);
        }

        /// <summary>
        /// Divide an ienumerable into two; first value's size is based on Count.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public static (IEnumerable<T> Take, IEnumerable<T> Throw) SplitTake<T>(this IEnumerable<T> source, int count) =>
            (source.Take(count), source.Skip(count));

        /// <summary>
        /// Works like LInq Contains
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="enumerable"></param>
        /// <param name="itemToFind"></param>
        /// <returns></returns>
        public static bool Has<T>(this IEnumerable<T> enumerable, T itemToFind)
        {
            foreach (var item in enumerable)
            {
                if (Equals(item, itemToFind)) return true;
            }
            return false;
        }

        /// <summary>
        /// boxing of any enumerable to it's interface equivalence
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="enumerable"></param>
        /// <returns></returns>
        public static IEnumerable<T> MakeEnumerable<T>(this IEnumerable<T> enumerable)
        {
            return enumerable;
        }

        /// <summary>
        /// Find First and split it from the main enumerable
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public static (T take, IEnumerable<T> remaining) SplitFirst<T>(this IEnumerable<T> source, Func<T, bool> predicate = null)
        {
            if (predicate == null) return (source.FirstOrDefault(), source.Skip(1));
            var found = default(T);
            var notIncluded = new List<T>();
            using (var enumerator = source.GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    if (predicate(enumerator.Current))
                    {
                        found = enumerator.Current;
                        break;
                    }
                    notIncluded.Add(enumerator.Current);
                }
                while (enumerator.MoveNext())
                {
                    notIncluded.Add(enumerator.Current);
                }
            }
            return (found, notIncluded);
        }

        /// <summary>
        /// Similar to Ienumerable.Any() but excludes checking a certain element
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="except">Excluded Element</param>
        /// <param name="func"></param>
        /// <returns></returns>
        public static bool AnyExcept<T>(this IEnumerable<T> source, T except, Func<T, bool> func)
        {
            if (func == null) throw new ArgumentNullException($"{func} Function cannot be null on an AnyExcept Extension");
            foreach (var item in source)
            {
                if (item.Equals(except)) continue;
                if (func(item)) return true;
            }
            return false;
        }

        /// <summary>
        /// Select + Select Many/ Nested Linq from - operator for two collections
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="col1"></param>
        /// <param name="col2"></param>
        /// <param name="func"></param>
        /// <returns></returns>
        public static IEnumerable<TResult> Cross<T1, T2, TResult>(this IEnumerable<T1> col1, IEnumerable<T2> col2, Func<T1, T2, TResult> func) =>
            func is null ? null :
            from t1 in col1
            from t2 in col2
            select func(t1, t2);

        /// <summary>
        ///Reverse Select an Array
        /// </summary>
        /// <typeparam name="TBase"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="source"></param>
        /// <param name="conversion"></param>
        /// <returns></returns>
        public static TResult[] ReverseSelect<TBase, TResult>(this TBase[] source, Func<TBase, TResult> conversion)
        {
            var stack = new Stack<TResult>();
            for (int i = source.Length - 1; i >= 0; i--)
            {
                stack.Push(conversion(source[i]));
            }
            return stack.ToArray();
        }

        /// <summary>
        ///Reverse Select an Array
        /// </summary>
        /// <typeparam name="TBase"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="source"></param>
        /// <param name="conversion"></param>
        /// <param name="break"></param>
        /// <param name="continue"></param>
        /// <returns></returns>
        public static TResult[] ReverseSelect<TBase, TResult>(this TBase[] source, Func<TBase, TResult> conversion, Func<TBase, bool> @break, Func<TBase, bool> @continue)
        {
            var stack = new Stack<TResult>();
            if (conversion is null)
            {
                return stack.ToArray();
            }

            if (@break is null)
            {
                return stack.ToArray();
            }

            if (@continue is null)
            {
                return stack.ToArray();
            }
            //todo: not yet done
            for (int i = source.Length - 1; i >= 0; i--)
            {
#pragma warning disable IDE0059 // Unnecessary assignment of a value
                var digit = source[i];
#pragma warning restore IDE0059 // Unnecessary assignment of a value
                               //stack.Push(digit);
                               //stack.Push(conversion(source[i]));
            }
            return stack.ToArray();
        }
    }
}