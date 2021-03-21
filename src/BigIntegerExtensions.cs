using System;

using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace KtExtensions
{
    /// <summary>
    /// Extensions for BigInteger
    /// </summary>
    public static class BigIntegerExtensions
    {
        /// <summary>
        /// Exhaust All Factor of a BigInteger
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public static IEnumerable<BigInteger> Factor(this BigInteger i) => i.InternalFactor().ToList();

        private static IEnumerable<BigInteger> InternalFactor(this BigInteger i)
        {
            BigInteger factor = 2;
            var newI = i;
            if (i < 0)
            {
                yield return -1;
                newI = BigInteger.Abs(i);
            }
            while (factor <= newI)
            {
                if (newI % factor == 0)
                {
                    yield return factor;
                    newI /= factor;
                }
                else
                {
                    factor++;
                }
            }
        }

        /// <summary>
        /// Get the Sqrt of BigInteger
        /// </summary>
        /// <param name="number"> </param>
        /// <exception cref="ArgumentException">number cannot be less than zero</exception>
        public static BigInteger Sqrt(this BigInteger number)
        {
            if (number < 0) throw new ArgumentException($"sqrt of {number}");
            BigInteger a = BigInteger.One, b = (number >> 5) + 8;
            for (var mid = (a + b) >> 1; b >= a; mid = (a + b) >> 1)
            {
                if ((mid * mid) > number)
                {
                    b = mid - 1;
                }
                else
                {
                    a = mid + 1;
                }
            }
            return a - 1;
        }

        /// <summary>
        /// Get the root of a BigInteger
        /// </summary>
        /// <param name="base"></param>
        /// <param name="n"></param>
        /// <exception cref="ArgumentException">root cannot be less than zero</exception>
        /// <exception cref="ArgumentException">negative value root base 2</exception>
        public static BigInteger Root(this BigInteger @base, int n)
        {
            if (n == 0) return 1;
            if (n < 1) throw new ArgumentException("Root cannot be less than 1");
            if (@base < 0 && (n % 2) != 1) throw new ArgumentException($"{n}th root of {@base} is not possible");
            var val = BigInteger.Abs(@base);
            if (@base == 0) return 0;
            int n1 = n - 1;
            BigInteger n2 = n;
            BigInteger n3 = n1;
            BigInteger c = 1;
            BigInteger d = (n3 + val) / n2;
            BigInteger e = ((n3 * d) + (val / BigInteger.Pow(d, n1))) / n2;
            while (c != d && c != e)
            {
                c = d;
                d = e;
                e = ((n3 * e) + (val / BigInteger.Pow(e, n1))) / n2;
            }
            if (d < e)
            {
                return d;
            }
            return @base.Sign * e;
        }

        /// <summary>
        /// Determine if a number is perfect sqaure
        /// </summary>
        /// <param name="A"></param>
        public static bool PerfectSqr(this BigInteger A)
        {
            var B = A.Sqrt();
            var C = B*B;
            return C == A;
        }
    }
}
