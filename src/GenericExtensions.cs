using System.Collections.Generic;

namespace KtExtensions
{
    /// <summary>
    /// Extensions for generic types
    /// </summary>
    public static class GenericExtensions
    {
        /// <summary>
        /// Create an Array using the value with "times" size
        /// </summary>
        /// <param name="val"></param>
        /// <param name="times">size of the array</param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T[] MakeArrayFor<T>(this T val, int times)
        {
            if (times < 0) return System.Array.Empty<T>();
            var temp = new T[times];
            for (var i = 0; i < times; i++)
            {
                temp[i] = val;
            }
            return temp;
        }

        /// <summary>
        /// Create a List using the value with "times" size
        /// </summary>
        /// <param name="val"></param>
        /// <param name="times">size of the list</param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static List<T> MakeListFor<T>(this T val, int times)
        {
            if (times <= 0) return new List<T>();
            var temp = new List<T>();
            for (var i = 0; i < times; i++)
            {
                temp.Add(val);
            }
            return temp;
        }

        /// <summary>
        /// Check if a generic value of type <typeparamref name="T"/> is null
        /// Reference: McGivern, D. (2011,Febuary 10) C#: Alternative to GenericType == null [Online forum comment].Message to
        ///                 posted to https://stackoverflow.com/questions/565564/c-alternative-to-generictype-null
        /// </summary>
        /// modification was done by using IsNullable() Method
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsNull<T>(this T value)
        {
            var type = typeof(T);
            return (!type.IsValueType || type.IsNullable()) && EqualityComparer<T>.Default.Equals(value, default);
        }
    }
}