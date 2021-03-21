using System;
using System.Linq;

namespace KtExtensions
{
    /// <summary>
    /// extending the static methods of Array abstract class
    /// </summary>
    public static class ArrayExtensions
    {
        /// <summary>
        /// extending Find method in Array
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="array"></param>
        /// <param name="match"></param>
        /// <returns></returns>
        public static T Find<T>(this T[] array, Predicate<T> match) => Array.Find(array, match);

        /// <summary>
        /// Add an item to the existing array but creates a new array.
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="toAdd"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T[] Add<T>(this T[] arr, T toAdd)
        {
            if (arr is null) return new[] { toAdd };
            return arr.Concat(new[] { toAdd }).ToArray();
        }

        /// <summary>
        /// Array version of List.RemoveAt
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="index"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// <exception cref="NullReferenceException">throws exception if array is null</exception>
        /// <exception cref="Exception">throws exception of array is of zero length</exception>
        public static T[] RemoveAt<T>(this T[] arr, int index)
        {
            if (arr == null || arr.Length < 1) throw new Exception("Remove at Method for array in not possible since array is null or empty");
            var newArray = new T[arr.Length - 1];
            var j = 0;
            for (var i = 0; i < arr.Length; i++)
            {
                if (i != index)
                {
                    newArray[j] = arr[i];
                    j++;
                }
            }
            return newArray;
        }

        /// <summary>
        /// Deep Clone a array
        /// </summary>
        /// <param name="arrayToClone"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T[] Clone<T>(this T[] arrayToClone) where T : ICloneable => arrayToClone.Select(item => (T)item.Clone()).ToArray();
    }
}