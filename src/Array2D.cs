using System;
using System.Collections.Generic;
using System.Linq;

namespace KtExtensions
{
    /// <summary>
    /// Collection of methods to deal with 2D array
    /// </summary>
    public static class Array2D
    {
        /// <summary>
        /// All - Extension for 2D array
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="array"></param>
        /// <param name="func"></param>
        /// <exception cref="NullReferenceException">Method Cannot be null</exception>
        /// <returns></returns>
        public static bool All<T>(this T[,] array, Func<T, bool> func)
        {
            if (func == null) throw new NullReferenceException("Function cannot be null");
            var rs = array.GetLength(0);
            var cs = array.GetLength(1);
            for (int i = 0; i < rs; i++)
            {
                for (int j = 0; j < cs; j++)
                {
                    if (!func(array[i, j])) return false;
                }
            }
            return true;
        }

        /// <summary>
        /// All - Extension for 2D array
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="array"></param>
        /// <param name="func"></param>
        /// <exception cref="NullReferenceException">Method Cannot be null</exception>
        /// <returns></returns>
        public static bool All<T>(this T[,] array, Func<T, int, int, bool> func)
        {
            if (func == null) throw new NullReferenceException("Function cannot be null");
            var rs = array.GetLength(0);
            var cs = array.GetLength(1);
            for (int i = 0; i < rs; i++)
            {
                for (int j = 0; j < cs; j++)
                {
                    if (!func(array[i, j], i, j)) return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Get the size of a two dimensional array, <paramref name="array"/>, of type <typeparamref name="T"/>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="array"></param>
        /// <returns><see cref="ValueTuple"/> of (<see cref="int"/> row, <see cref="int"/> col) </returns>
        public static (int row, int col) Size<T>(this T[,] array) =>
            array == null ? (-1, -1) : (array.GetLength(0), array.GetLength(1));

        /// <summary>
        /// Check if a 2D array has data
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="matrix"></param>
        /// <returns></returns>
        public static bool HasAny<T>(this T[,] matrix) =>
            matrix?.GetLength(0) > 0 && matrix.GetLength(1) > 0;

        /// <summary>
        /// Check if an index is out of bound from an array 2D
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="matrix"></param>
        /// <param name="index"></param>
        /// <param name="dimension"></param>
        /// <returns></returns>
        public static bool IndexIsOutOfBound<T>(this T[,] matrix, int index, int dimension) =>
            dimension > 1 || index < 0 || index > matrix.GetLength(dimension);

        /// <summary>
        /// Get the row
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="matrix"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public static IEnumerable<T> SelectRow<T>(this T[,] matrix, int index)
        {
            if (!HasAny(matrix) || IndexIsOutOfBound(matrix, index, 0)) yield break;
            foreach (var item in matrix.SelectRowInner(index)) yield return item;
        }

        private static IEnumerable<T> SelectRowInner<T>(this T[,] matrix, int index)
        {
            for (int i = 0; i < matrix.GetLength(1); i++) yield return matrix[index, i];
        }

        private static IEnumerable<T> SelectColumnInner<T>(this T[,] matrix, int index)
        {
            for (int i = 0; i < matrix.GetLength(0); i++) yield return matrix[i, index];
        }

        /// <summary>
        /// Convert Matrix to Dictionary
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="matrix"></param>
        /// <returns>first row is the ket and the rest are stored on an array </returns>
        /// <exception cref="IndexOutOfRangeException">Error for less than 2D Array</exception>
        public static Dictionary<T, T[]> ToDictionary<T>(this T[,] matrix)
        {
            var cols = matrix.Size().col;
            if (cols < 2) throw new IndexOutOfRangeException("The Matrix has any one column, It can't be converted to a Dictionary");
            var dict = matrix.Cast<T>()
            .Select((s, i) => new { s, i })
            .GroupBy(s => s.i / cols)
            .ToDictionary(
              g => g.First().s,
              g => g.Skip(1).Select(i => i.s).ToArray()
            );
            return dict;
        }

        /// <summary>
        /// Get row and apply some modifications
        /// </summary>
        /// <typeparam name="Tresult"></typeparam>
        /// <typeparam name="Tbase"></typeparam>
        /// <param name="matrix"></param>
        /// <param name="index"></param>
        /// <param name="func"></param>
        /// <returns></returns>
        public static IEnumerable<Tresult> SelectRow<Tresult, Tbase>(this Tbase[,] matrix, int index, Func<Tbase, Tresult> func) =>
            matrix.SelectRow(index).Select(func);

        /// <summary>
        /// Get the col
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="matrix"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public static IEnumerable<T> SelectCol<T>(this T[,] matrix, int index)
        {
            if (!HasAny(matrix) || IndexIsOutOfBound(matrix, index, 1)) yield break;
            foreach (var item in matrix.SelectColumnInner(index)) yield return item;
        }

        /// <summary>
        /// Get col and apply some modifications
        /// </summary>
        /// <typeparam name="Tresult"></typeparam>
        /// <typeparam name="Tbase"></typeparam>
        /// <param name="matrix"></param>
        /// <param name="index"></param>
        /// <param name="func"></param>
        /// <returns></returns>
        public static IEnumerable<Tresult> SelectCol<Tresult, Tbase>(this Tbase[,] matrix, int index, Func<Tbase, Tresult> func) =>
            matrix.SelectCol(index).Select(func);

        /// <summary>
        /// Cast the row of the two dimensional array using a function, <paramref name="func"/>
        /// </summary>
        /// <typeparam name="TBase"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="array"></param>
        /// <param name="func"></param>
        /// <returns>The result is an <see cref="IEnumerable{TResult}"/> </returns>
        public static IEnumerable<TResult> SelectRows<TBase, TResult>(this TBase[,] array, Func<IEnumerable<TBase>, TResult> func)
        {
            if (!HasAny(array) || func == null) yield break;
            for (int i = 0; i < array.GetLength(0); i++)
            {
                yield return func(array.SelectRowInner(i));
            }
        }

        /// <summary>
        /// modify element in row, modify row and return as an ienumerable
        /// </summary>
        /// <typeparam name="TBase"></typeparam>
        /// <typeparam name="TInnerResult"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="array"></param>
        /// <param name="InnerFunc"></param>
        /// <param name="func"></param>
        /// <returns></returns>
        public static IEnumerable<TResult> SelectRows<TBase, TInnerResult, TResult>(this TBase[,] array, Func<TBase, TInnerResult> InnerFunc, Func<IEnumerable<TInnerResult>, TResult> func)
        {
            if (!HasAny(array) || func == null) yield break;
            for (int i = 0; i < array.GetLength(0); i++)
            {
                yield return func(array.SelectRowInner(i).Select(InnerFunc));
            }
        }

        ///<summary>
        /// Cast the column of the two dimensional array using a function, <paramref name="func"/>
        /// </summary>
        /// <typeparam name="TBase"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="array"></param>
        /// <param name="func"></param>
        /// <returns>The result is an <see cref="IEnumerable{TResult}"/> </returns>
        public static IEnumerable<TResult> SelectCols<TBase, TResult>(this TBase[,] array, Func<IEnumerable<TBase>, TResult> func)
        {
            if (!HasAny(array) || func == null) yield break;
            for (int j = 0; j < array.GetLength(1); j++)
            {
                yield return func(array.SelectCol(j));
            }
        }

        ///<summary>
        /// Cast the column of the two dimensional array using a function, <paramref name="func"/>
        /// </summary>
        /// <typeparam name="TBase"></typeparam>
        /// <typeparam name="TInnerResult"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="array"></param>
        /// <param name="InnerFunc"></param>
        /// <param name="func"></param>
        /// <returns>The result is an <see cref="IEnumerable{TResult}"/> </returns>
        public static IEnumerable<TResult> SelectCols<TBase, TInnerResult, TResult>(this TBase[,] array, Func<TBase, TInnerResult> InnerFunc, Func<IEnumerable<TInnerResult>, TResult> func)
        {
            if (!HasAny(array) || func == null) yield break;
            for (int j = 0; j < array.GetLength(1); j++)
            {
                yield return func(array.SelectCol(j).Select(InnerFunc));
            }
        }

        /// <summary>
        /// Loop Through a 2d array
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="func"></param>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TQ"></typeparam>
        /// <returns></returns>
        public static TQ[,] Select<T, TQ>(this T[,] arr, Func<T, int, int, TQ> func)
        {
            if (func == null) return new TQ[0, 0];
            var (hSize, wSize) = (arr.GetLength(0), arr.GetLength(1));
            var temp = new TQ[hSize, wSize];
            for (var i = 0; i < hSize; i++)
            {
                for (var j = 0; j < wSize; j++)
                {
                    temp[i, j] = func(arr[i, j], i, j);
                }
            }
            return temp;
        }

        /// <summary>
        /// Loop Through a 2d array
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="func"></param>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TQ"></typeparam>
        /// <returns></returns>
        public static TQ[,] Select<T, TQ>(this T[,] arr, Func<T, TQ> func)
        {
            if (func == null) return new TQ[0, 0];
            var (hSize, wSize) = (arr.GetLength(0), arr.GetLength(1));
            var temp = new TQ[hSize, wSize];
            for (var i = 0; i < hSize; i++)
            {
                for (var j = 0; j < wSize; j++)
                {
                    temp[i, j] = func(arr[i, j]);
                }
            }
            return temp;
        }

        /// <summary>
        /// Loop Through a 2d array
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="initial"></param>
        /// <param name="func"></param>
        /// <typeparam name="T">base</typeparam>
        /// <typeparam name="TQ">target</typeparam>
        /// <returns></returns>
        public static TQ Aggregate<T, TQ>(this T[,] arr, TQ initial, Func<TQ, T, int, int, TQ> func)
        {
            if (func == null) return default;
            var (hSize, wSize) = (arr.GetLength(0), arr.GetLength(1));
            var temp = initial;
            for (var i = 0; i < hSize; i++)
            {
                for (var j = 0; j < wSize; j++)
                {
                    temp = func(temp, arr[i, j], i, j);
                }
            }
            return temp;
        }

        /// <summary>
        /// Loop Through a 2d array
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="initial"></param>
        /// <param name="func"></param>
        /// <typeparam name="T">base</typeparam>
        /// <typeparam name="TQ">target</typeparam>
        /// <returns></returns>
        public static TQ Aggregate<T, TQ>(this T[,] arr, TQ initial, Func<TQ, T, TQ> func)
        {
            if (func == null) return default;
            var hSize = arr.GetLength(0);
            var wSize = arr.GetLength(1);
            var temp = initial;
            for (var i = 0; i < hSize; i++)
            {
                for (var j = 0; j < wSize; j++)
                {
                    temp = func(temp, arr[i, j]);
                }
            }
            return temp;
        }

        /// <summary>
        /// Loop Through a 2d array without any returns
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="action"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static void ForEach<T>(this T[,] arr, Action<T, int, int> action)
        {
            if (action == null) return;
            for (var i = 0; i < arr.GetLength(0); i++)
            {
                for (var j = 0; j < arr.GetLength(1); j++)
                {
                    action(arr[i, j], i, j);
                }
            }
        }

        /// <summary>
        /// Check if Two 2d array are equal
        /// </summary>
        /// <param name="arr1"></param>
        /// <param name="arr2"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static bool SequenceEqual<T>(this T[,] arr1, T[,] arr2)
        {
            var (harr1, warr1) = arr1.Size();
            var (harr2, warr2) = arr2.Size();
            if (harr1 != harr2) return false;
            if (warr1 != warr2) return false;
            for (var i = 0; i < harr1; i++)
            {
                for (var j = 0; j < warr1; j++)
                {
                    if (!EqualityComparer<T>.Default.Equals(arr1[i, j], arr2[i, j])) return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Delete the row of 2 dimensional array
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="index">index of the row</param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T[,] DeleteRow<T>(this T[,] arr, long index)
        {
            if (arr == null) return null;
            var rows = arr.GetLength(0);
            if (index >= rows || index < 0) return arr;
            var cols = arr.GetLength(1);
            var tempArr = new T[rows - 1, cols];
            var rowStep = 0;
            for (var i = 0; i < rows; i++)
            {
                if (i == index) continue;
                for (var j = 0; j < cols; j++)
                {
                    tempArr[rowStep, j] = arr[i, j];
                }
                rowStep++;
            }
            return tempArr;
        }

        /// <summary>
        /// Delete multiple row of a 2d Array
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="arr"></param>
        /// <param name="indices"></param>
        /// <returns></returns>
        public static T[,] DeleteRow<T>(this T[,] arr, long[] indices)
        {
            var indicesFixed = indices.ToList().OrderByDescending(index => index);
            var initial = arr;
            foreach (var index in indicesFixed)
            {
                initial = initial.DeleteRow(index);
            }
            return initial;
        }

        /// <summary>
        /// Delete multiple col of a 2d Array
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="arr"></param>
        /// <param name="indices"></param>
        /// <returns></returns>
        public static T[,] DeleteCol<T>(this T[,] arr, long[] indices)
        {
            var indicesFixed = indices.ToList().OrderByDescending(index => index);
            var initial = arr;
            foreach (var index in indicesFixed)
            {
                initial = initial.DeleteCol(index);
            }
            return initial;
        }

        /// <summary>
        /// Delete the column of an array
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="index">index of column</param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T[,] DeleteCol<T>(this T[,] arr, long index)
        {
            if (arr == null) return null;
            var cols = arr.GetLength(1);
            if (index >= cols || index < 0) return arr;
            var rows = arr.GetLength(0);
            var tempArr = new T[rows, cols - 1];
            var colStep = 0;
            for (var j = 0; j < cols; j++)
            {
                if (j == index) continue;
                for (var i = 0; i < rows; i++)
                {
                    tempArr[i, colStep] = arr[i, j];
                }
                colStep++;
            }
            return tempArr;
        }

        /// <summary>
        /// swap rows of a 2 dimensional matrix
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="index1">index of row 1</param>
        /// <param name="index2">index of row 2</param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T[,] SwapRow<T>(this T[,] arr, long index1, long index2)
        {
            if (arr == null) return null;
            if (index1 == index2) return arr;
            var rows = arr.GetLength(0);
            if (index1 >= rows || index1 < 0 || index1 >= rows || index1 < 0) return arr;
            var cols = arr.GetLength(1);
            var tempArr = new T[rows, cols];
            for (var i = 0; i < rows; i++)
            {
                for (var j = 0; j < cols; j++)
                {
                    tempArr[i == index1 ? index2 : i == index2 ? index1 : i, j] = arr[i, j];
                }
            }
            return tempArr;
        }

        /// <summary>
        /// swap columns of a 2 dimensional matrix
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="index1">index of column 1</param>
        /// <param name="index2">index of column 2</param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T[,] SwapCol<T>(this T[,] arr, long index1, long index2)
        {
            if (arr == null) return null;
            if (index1 == index2) return arr;
            var rows = arr.GetLength(0);
            if (index1 >= rows || index1 < 0 || index1 >= rows || index1 < 0) return arr;
            var cols = arr.GetLength(1);
            var tempArr = new T[rows, cols];
            for (var i = 0; i < rows; i++)
            {
                for (var j = 0; j < cols; j++)
                {
                    tempArr[i, j == index1 ? index2 : j == index2 ? index1 : j] = arr[i, j];
                }
            }
            return tempArr;
        }

        /// <summary>
        /// swap rows of a 2 dimensional matrix
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="index1">index of row 1</param>
        /// <param name="index2">index of row 2</param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static void SwapRowInternal<T>(this T[,] arr, long index1, long index2)
        {
            if (arr == null) return;
            if (index1 == index2) return;
            var rows = arr.GetLength(0);
            if (index1 >= rows || index1 < 0 || index2 >= rows || index2 < 0) return;
            var cols = arr.GetLength(1);
            for (var j = 0; j < cols; j++)
            {
                var temp = arr[index1, j];
                arr[index1, j] = arr[index2, j];
                arr[index2, j] = temp;
            }
        }

        /// <summary>
        /// swap columns of a 2 dimensional matrix
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="index1">index of column 1</param>
        /// <param name="index2">index of column 2</param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static void SwapColInternal<T>(this T[,] arr, long index1, long index2)
        {
            if (arr == null) return;
            if (index1 == index2) return;
            var rows = arr.GetLength(0);
            var cols = arr.GetLength(1);
            if (index1 >= cols || index1 < 0 || index2 >= cols || index2 < 0) return;
            for (var i = 0; i < rows; i++)
            {
                var temp = arr[i, index1];
                arr[i, index1] = arr[i, index2];
                arr[i, index2] = temp;
            }
        }

        /// <summary>
        /// Convert the array in a tabulated string format
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="arr"></param>
        /// <returns></returns>
        public static string TabbedToString<T>(this T[,] arr) => arr.SelectRows(enumerable => enumerable.BuildString("\t")).BuildString("\n");

        /// <summary>
        /// Tranform 2 Column Matrices into Dictionary
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <param name="array1"></param>
        /// <param name="array2"></param>
        /// <returns></returns>
        public static Dictionary<T1, T2> ToDictionary<T1, T2>(object[,] array1, object[,] array2)
        {
            var (lowRow1, highRow1) = array1.GetBounds(0);
            var lowCol1 = array1.GetLowerBound(1);
            var lowRow2 = array2.GetLowerBound(0);
            var lowCol2 = array2.GetLowerBound(1);
            var dict = new Dictionary<T1, T2>();
            for (int i = lowRow1; i <= highRow1; i++)
            {
                var key = array1[i, lowCol1];
                if (key is null) continue;
                if (key is not T1 k) continue;
                var val = array2[i - lowRow1 + lowRow2, lowCol2];
                dict.Add(k, val is T2 v ? v : default);
            }
            return dict;
        }

        /// <summary>
        /// ToDictionary with same return type
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <param name="array1"></param>
        /// <param name="array2"></param>
        /// <returns></returns>
        public static Dictionary<T1, T2> ToDictionary<T1, T2>(T1[,] array1, T2[,] array2)
        {
            var (lowRow1, highRow1) = array1.GetBounds(0);
            var lowCol1 = array1.GetLowerBound(1);
            var lowRow2 = array2.GetLowerBound(0);
            var lowCol2 = array2.GetLowerBound(1);
            var dict = new Dictionary<T1, T2>();
            for (int i = lowRow1; i <= highRow1; i++)
            {
                var key = array1[i, lowCol1];
                if (key is null) continue;
                if (key is not T1 k) continue;
                var val = array2[i - lowRow1 + lowRow2, lowCol2];
                dict.Add(k, val is T2 v ? v : default);
            }
            return dict;
        }

        /// <summary>
        /// Extension of type method of ToDictionary
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <param name="arrays"></param>
        /// <returns></returns>
        public static Dictionary<T1, T2> ToDictionary<T1, T2>(this (T1[,] array1, T2[,] array2) arrays)
        {
            var (array1, array2) = arrays;
            var (lowRow1, highRow1) = array1.GetBounds(0);
            var lowCol1 = array1.GetLowerBound(1);
            var lowRow2 = array2.GetLowerBound(0);
            var lowCol2 = array2.GetLowerBound(1);
            var dict = new Dictionary<T1, T2>();
            for (int i = lowRow1; i <= highRow1; i++)
            {
                var key = array1[i, lowCol1];
                if (key is null) continue;
                if (key is not T1 k) continue;
                var val = array2[i - lowRow1 + lowRow2, lowCol2];
                dict.Add(k, val is T2 v ? v : default);
            }
            return dict;
        }

        /// <summary>
        /// Call a ForEach Row method on Matrix
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="mat"></param>
        /// <param name="colIndex">zero-based index</param>
        /// <param name="action"></param>
        public static void ForEachRow<T>(this T[,] mat, int colIndex, Action<int, T> action)
        {
            if (mat is null) throw new ArgumentNullException(nameof(mat));
            if (action is null) throw new ArgumentNullException(nameof(action));
            var (lowrow, highrow) = mat.GetBounds(0);
            var lowcol = mat.GetLowerBound(1);
            for (int i = lowrow; i <= highrow; i++)
            {
                action(i - lowrow, mat[i, colIndex + lowcol]);
            }
        }

        /// <summary>
        /// Call a Foreach Col method on Matrix
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="mat"></param>
        /// <param name="rowIndex">zero-based index</param>
        /// <param name="action"></param>
        public static void ForEachCol<T>(this T[,] mat, int rowIndex, Action<int, T> action)
        {
            if (mat is null) throw new ArgumentNullException(nameof(mat));
            if (action is null) throw new ArgumentNullException(nameof(action));
            var (lowcol, highcol) = mat.GetBounds(1);
            var lowRow = mat.GetLowerBound(0);
            for (int i = lowcol; i <= highcol; i++)
            {
                action(i - lowcol, mat[rowIndex + lowRow, i]);
            }
        }

        /// <summary>
        /// ForEach Row with return type
        /// </summary>
        /// <typeparam name="Tin"></typeparam>
        /// <typeparam name="Tout"></typeparam>
        /// <param name="mat"></param>
        /// <param name="colIndex">zero-based</param>
        /// <param name="func"></param>
        /// <exception cref="ArgumentNullException"> func can't be null</exception>
        /// <returns></returns>
        public static Tout[,] ForEachRow<Tin, Tout>(this Tin[,] mat, int colIndex, Func<int, Tin, Tout> func)
        {
            if (func is null) throw new ArgumentNullException(nameof(func));
            var result = new Tout[mat.GetLength(0), 1];
            mat.ForEachRow(colIndex, (i, v) => result[i, 0] = func(i, v));
            return result;
        }

        /// <summary>
        /// ForEach Col with return type
        /// </summary>
        /// <typeparam name="Tin"></typeparam>
        /// <typeparam name="Tout"></typeparam>
        /// <param name="mat"></param>
        /// <param name="rowIndex">zero-based index</param>
        /// <param name="func"></param>
        /// <exception cref="ArgumentNullException"> func can't be null</exception>
        /// <returns></returns>
        public static Tout[,] ForEachCol<Tin, Tout>(this Tin[,] mat, int rowIndex, Func<int, Tin, Tout> func)
        {
            if (func is null) throw new ArgumentNullException(nameof(func));
            var result = new Tout[1, mat.GetLength(1)];
            mat.ForEachCol(rowIndex, (i, v) => result[0, i] = func(i, v));
            return result;
        }

        /// <summary>
        /// Get RowBounds
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="mat"></param>
        /// <param name="dimension"></param>
        /// <returns></returns>
        public static (int lowRow, int highRow) GetBounds<T>(this T[,] mat, int dimension) =>
            mat switch
            {
                null => throw new ArgumentNullException(nameof(mat)),
                _ => (mat.GetLowerBound(dimension), mat.GetUpperBound(dimension))
            };
    }
}