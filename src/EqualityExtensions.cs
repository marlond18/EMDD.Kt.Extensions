using System;
using System.Collections.Generic;
using System.Linq;

namespace KtExtensions
{
    /// <summary>
    /// Collection of methods for equality purposes
    /// </summary>
    public static class EqualityExtensions
    {
        /// <summary>
        /// Chain the hashcode of the new item to the previous
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="hash">initial hash</param>
        /// <param name="other">other item</param>
        /// <param name="multiplier"></param>
        /// <returns></returns>
        public static int ChainHashCode<T>(this int hash, T other, int multiplier) => unchecked((hash * multiplier) + other?.GetHashCode() ?? 0);

        /// <summary>
        /// Chain the hashcode of the new item to the previous
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="hash">initial hash</param>
        /// <param name="other">other item</param>
        /// <returns></returns>
        public static int ChainHashCode<T>(this int hash, T other) => unchecked((hash * -1521134295) + (other.IsNull() ? 0 : other.GetHashCode()));

        /// <summary>
        /// Chain the hashcode of the new item to the previous
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="hash">initial hash</param>
        /// <param name="other">other item</param>
        /// <returns></returns>
        public static int ChainHashCode<T>(this int hash, IEnumerable<T> other) => unchecked((hash * -1521134295) + (other.IsNull() ? 0 : other.GetHashCodeOfEnumerable()));

        /// <summary>
        /// Chain the hashcode of the new item to the previous
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="hash">initial hash</param>
        /// <param name="other">other item</param>
        /// <returns></returns>
        public static int ChainHashCode<T>(this int hash, T[] other) => unchecked((hash * -1521134295) + (other.IsNull() ? 0 : other.GetHashCodeOfArray()));

        /// <summary>
        /// Determine the hashcode of an array using <see cref="ChainHashCode{T}(int, T)"/> method
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="array"></param>
        /// <returns></returns>
        public static int GetHashCodeOfArray<T>(this T[] array) => unchecked(array?.Aggregate(-1211428091, ChainHashCode) ?? 0);

        /// <summary>
        /// Determine the hashcode of an enumerable using <see cref="ChainHashCode{T}(int, T)"/> method
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="array"></param>
        /// <returns></returns>
        public static int GetHashCodeOfEnumerable<T>(this IEnumerable<T> array) => unchecked(array?.Aggregate(-1211428091, ChainHashCode) ?? 0);

        /// <summary>
        /// Shortened <see cref=" EqualityComparer{T}.Default"/>.Equals
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool DefaultEquals<T>(this T a, T b) => EqualityComparer<T>.Default.Equals(a, b);

        /// <summary>
        /// Test for null before doing the final equality check of final
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="final"></param>
        /// <returns></returns>
        public static bool TestNullBeforeEquals<T>(this T a, T b, Func<bool> final) where T : class
        {
            if (ReferenceEquals(a, b)) return true;
            if (a is null || b is null) return false;
            return final != null && final();
        }

        /// <summary>
        /// Test if an element of type <typeparamref name="T"/> is equal to an object
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="a"></param>
        /// <param name="obj"></param>
        /// <param name="final"></param>
        /// <returns></returns>
        public static bool EqualsObject<T>(this T a, object obj, Func<T, bool> final) where T : class
        {
            if (ReferenceEquals(a, obj)) return true;
            if (a is null || obj is null) return false;
            if (obj is not T convert) return false;
            return final != null && final(convert);
        }

        /// <summary>
        /// Test for null before doing the final equality check of final
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="final"></param>
        /// <returns></returns>
        public static bool TestNullBeforeEquals<T>(this T a, T b, Func<T, bool> final) where T : class
        {
            if (ReferenceEquals(a, b)) return true;
            if (a is null || b is null) return false;
            return final != null && final(b);
        }

        /// <summary>
        /// Test for null before doing the final equality check of final
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="final"></param>
        /// <returns></returns>
        public static bool TestNullBeforeEquals<T>(this T a, T b, bool final) where T : class
        {
            if (ReferenceEquals(a, b)) return true;
            if (a is null || b is null) return false;
            return final;
        }
    }
}