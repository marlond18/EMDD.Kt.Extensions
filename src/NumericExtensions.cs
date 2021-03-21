using System;
using System.Collections.Generic;
using System.Linq;

using static KtExtensions.NumericExtensions.NumberSign;

namespace KtExtensions
{
    /// <summary>
    /// Numeric Extensions
    /// </summary>
    public static class NumericExtensions
    {
        /// <summary>
        /// Determine if an integer is Even
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsEven(this int value) => value % 2 == 0;

        /// <summary>
        /// Check if a double value is an integer
        /// </summary>
        /// <param name="val"></param>
        /// <param name="precision"></param>
        /// <returns></returns>
        public static bool NoFloat(this double val, int precision = 12)
        {
            var rounded = Math.Round(val, 0);
            var difference = Math.Abs(rounded - val);
            return difference.NearZero(precision);
        }

        /// <summary>
        /// (v1,v2) => v1.CompareTo(v2)
        /// </summary>
        /// <param name="values"></param>
        /// <returns></returns>
        public static int CompareTo(this (double v1, double v2) values) => values.v1.CompareTo(values.v2);

        /// <summary>
        ///     Return the angle in degrees
        /// </summary>
        /// <param name="y">numerator of the tangent function</param>
        /// <param name="x">denominator of the tangent function</param>
        /// <returns></returns>
#pragma warning disable RCS1224 // Make method an extension method.
        public static double Atan3(double y, double x) => Math.Atan2(y, x) * 180 / Math.PI;
#pragma warning restore RCS1224 // Make method an extension method.

        /// <summary>
        /// Used for looping through circular sequence
        /// </summary>
        /// <param name="val1">The Number that loops</param>
        /// <param name="val2">The Begining of the loop</param>
        /// <param name="val3">The end of the loop</param>
        /// <returns>Looped equivalent of val1</returns>
        public static double CycleWithin(this double val1, double val2, double val3)
        {
            var (minval, maxval) = MinMax(val2, val3);
            var d1 = val1 - minval;
            var d2 = maxval - minval + 1;
            var remainder = d1 % d2;
            var tempval = minval + (remainder < 0 ? d2 : 0) + remainder;
            while (!tempval.IsWithin(minval, maxval))
            {
                d1 = tempval - minval;
                remainder = d1 % d2;
                tempval = minval + (remainder < 0 ? d2 : 0) + remainder;
            }
            if (!tempval.IsWithin(minval, maxval)) tempval = tempval.CycleWithin(minval, maxval);
            return tempval;
        }

#pragma warning disable RCS1224 // Make method an extension method.
        /// <summary>
        /// determine the min or max of two integers
        /// </summary>
        /// <param name="val1"></param>
        /// <param name="val2"></param>
        /// <returns></returns>
        public static (int min, int max) MinMax(int val1, int val2) => (val1 < val2) ? (val1, val2) : (val2, val1);

        /// <summary>
        /// determine the min or max of two doubles
        /// </summary>
        /// <param name="val1"></param>
        /// <param name="val2"></param>
        /// <returns></returns>
        public static (double min, double max) MinMax(double val1, double val2) => (val1 < val2) ? (val1, val2) : (val2, val1);
#pragma warning restore RCS1224 // Make method an extension method.

        /// <summary>
        /// Used for looping through circular sequence
        /// </summary>
        /// <param name="val1">The Number that loops</param>
        /// <param name="val2">The Begining of the loop</param>
        /// <param name="val3">The end of the loop</param>
        /// <returns>Looped equivalent of val1</returns>
        public static int CycleWithin(this int val1, int val2, int val3)
        {
            var (minval, maxval) = MinMax(val2, val3);
            var d1 = val1 - minval;
            var d2 = maxval - minval + 1;
            var remainder = d1 % d2;
            var tempval = minval + (remainder < 0 ? d2 : 0) + remainder;
            if (!tempval.IsWithin(minval, maxval)) tempval = tempval.CycleWithin(minval, maxval);
            return tempval;
        }

        /// <summary>
        /// check if a number is infinity or NaN
        /// </summary>
        /// <param name="val">the value to be tested</param>
        /// <returns>Boolean value</returns>
        public static bool InvalidNumber(this double val)
        {
            return double.IsInfinity(val)
                   || double.IsNaN(val)
                   || double.IsNegativeInfinity(val)
                   || double.IsPositiveInfinity(val);
        }

        /// <summary>
        /// Determine if a string can be converted into a number, Similar VB.net IsNumeric Function
        /// </summary>
        /// <param name="val">The string to be tested</param>
        /// <returns>Boolean Value</returns>
        public static bool IsNumeric(this string val) => double.TryParse(val, out _);

        /// <summary>
        /// Return the scientific notation
        /// </summary>
        /// <param name="val">todo: describe val parameter on ScientificNotation</param>
        /// <returns>return a tuple of significant figure in 1's and the base 10 exponent </returns>
        public static (double SignificantFigure, int Exp) ScientificNotation(this double val)
        {
            var exp = val.Base10Of1stSignificantFigure();
            var signifFig = val / Math.Pow(10, exp);
            return (signifFig, exp);
        }

        /// <summary>
        /// get the decimal place of first significant figure
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        public static int Base10Of1stSignificantFigure(this double val) => (int)Math.Floor(Math.Log10(Math.Abs(val)));

        /// <summary>
        /// Test if a number is inside or exactly on the limits
        /// </summary>
        /// <param name="val1"></param>
        /// <param name="val2">Limit 1</param>
        /// <param name="val3">Limit 2</param>
        /// <returns></returns>
        public static bool IsWithin(this double val1, double val2, double val3)
        {
            var (min, max) = MinMax(val2, val3);
            return !(val1 < min) && !(val1 > max);
        }

        /// <summary>
        /// Test if a number is inside or exactly on the limits
        /// </summary>
        /// <param name="val1"></param>
        /// <param name="limits"></param>
        /// <returns></returns>
        public static bool IsWithin(this double val1, (double lim1, double lim2) limits) => IsWithin(val1, limits.lim1, limits.lim2);

        /// <summary>
        /// Test if a number is inside but should not be on the limits
        /// </summary>
        /// <param name="val1"></param>
        /// <param name="val2">Limit 1</param>
        /// <param name="val3">Limit 2</param>
        /// <returns></returns>
        public static bool IsBetween(this double val1, double val2, double val3) =>
            val1 > Math.Min(val2, val3)
            && val1 < Math.Max(val2, val3);

        /// <summary>
        /// Test if a number is inside or exactly on the limits
        /// </summary>
        /// <param name="val1"></param>
        /// <param name="val2">Limit 1</param>
        /// <param name="val3">Limit 2</param>
        /// <returns></returns>
        public static bool IsWithin(this int val1, int val2, int val3)
        {
            var (min, max) = MinMax(val2, val3);
            return val1 >= min && val1 <= max;
        }

        /// <summary>
        /// Test if a number is inside or exactly on the limits
        /// </summary>
        /// <param name="val1"></param>
        /// <param name="limits"></param>
        /// <returns></returns>
        public static bool IsWithin(this int val1, (int lim1, int lim2) limits) => IsWithin(val1, limits.lim1, limits.lim2);

        /// <summary>
        /// Test if a number is inside but should not be on the limits
        /// </summary>
        /// <param name="val1"></param>
        /// <param name="val2">Limit 1</param>
        /// <param name="val3">Limit 2</param>
        /// <returns></returns>
        public static bool IsBetween(this int val1, int val2, int val3) =>
            (val1 > Math.Min(val2, val3))
            && (val1 < Math.Max(val2, val3));

        /// <summary>
        /// Test if a number is inside but should not be on the limits
        /// </summary>
        /// <param name="val1"></param>
        /// <param name="val2">Limit 1</param>
        /// <param name="val3">Limit 2</param>
        /// <returns></returns>
        public static bool IsBetween(this long val1, long val2, long val3) =>
            (val1 > Math.Min(val2, val3))
            && (val1 < Math.Max(val2, val3));

        /// <summary>
        /// Make a value stay within the limits (Including the limits themselves)
        /// </summary>
        /// <param name="val1"></param>
        /// <param name="val2">Limit 1</param>
        /// <param name="val3">Limit </param>
        /// <returns></returns>
        public static double LimitWithin(this double val1, double val2, double val3)
        {
            var min = Math.Min(val2, val3);
            var max = Math.Max(val2, val3);
            return val1 < min
                ? min
                : val1 > max ? max : val1;
        }

        /// <summary>
        /// Make a value stay within the limits (Including the limits themselves)
        /// </summary>
        /// <param name="val1"></param>
        /// <param name="val2">Limit 1</param>
        /// <param name="val3">Limit </param>
        /// <returns></returns>
        public static int LimitWithin(this int val1, int val2, int val3)
        {
            var min = Math.Min(val2, val3);
            var max = Math.Max(val2, val3);
            return val1 < min ? min : (val1 > max ? max : val1);
        }

        /// <summary>
        /// Make a value stay within the limits (Including the limits themselves)
        /// </summary>
        /// <param name="val1"></param>
        /// <param name="val2">Limit 1</param>
        /// <param name="val3">Limit </param>
        /// <returns></returns>
        public static long LimitWithin(this long val1, long val2, long val3)
        {
            var min = Math.Min(val2, val3);
            var max = Math.Max(val2, val3);
            return val1 < min ? min : (val1 > max ? max : val1);
        }

        /// <summary>
        /// Determine if a double number is almost equal to zero
        /// </summary>
        /// <param name="val"></param>
        /// <param name="accuracy">accuracy to the n'th degree</param>
        /// <returns></returns>
        public static bool NearZero(this double val, int accuracy = 10) =>
            Math.Abs(val) < 10.0.RaiseTo(-accuracy);

        /// <summary>
        /// Acts like an exponent/power
        /// </summary>
        /// <param name="val1"></param>
        /// <param name="val2">exponent</param>
        /// <returns></returns>
        public static double RaiseTo(this double val1, int val2) =>
            Math.Pow(val1, val2);

        /// <summary>
        /// Check if a number is Approximately Equal to the other
        /// </summary>
        /// <param name="val1"></param>
        /// <param name="val2"></param>
        /// <param name="accuracy"></param>
        /// <returns></returns>
        public static bool NearEqual(this double val1, double val2, int accuracy = 12) =>
            val1.InvalidNumber() ? val1.Equals(val2) : (val1 - val2).NearZero(accuracy);

        /// <summary>
        /// multiply a number with 10 raised to ____
        /// </summary>
        /// <param name="val1"></param>
        /// <param name="val2">Power of th multiplyier number "10"</param>
        /// <returns></returns>
        public static double Exp(this double val1, int val2) =>
            val1 * Math.Pow(10, val2);

        /// <summary>
        /// Round for every interval
        /// </summary>
        /// <param name="val1"></param>
        /// <param name="val2">interval</param>
        /// <returns></returns>
        public static double Roundby(this double val1, int val2) =>
            Math.Round(val1 / val2, 0) * val2;

        /// <summary>
        /// Round for every interval
        /// </summary>
        /// <param name="val1"></param>
        /// <param name="val2">interval</param>
        /// <returns></returns>
        public static double Roundby(this double val1, double val2) =>
            Math.Round(val1 / val2, 0) * val2;

        /// <summary>
        /// Round down for every interval
        /// </summary>
        /// <param name="val1"></param>
        /// <param name="val2">interval</param>
        /// <returns></returns>
        public static double RoundDownby(this double val1, int val2) =>
            Math.Round((val1 - (val1 % val2)) / val2, 0) * val2;

        /// <summary>
        /// Round down for every interval
        /// </summary>
        /// <param name="val1"></param>
        /// <param name="val2">interval</param>
        /// <returns></returns>
        public static double RoundDownby(this double val1, double val2) =>
            Math.Round((val1 - (val1 % val2)) / val2, 0) * val2;

        /// <summary>
        /// Roundup for every interval
        /// </summary>
        /// <param name="val1"></param>
        /// <param name="val2">interval</param>
        /// <returns></returns>
        public static double RoundUpby(this double val1, int val2)
        {
            var rem = (val1 % val2);
            if (rem.NearZero()) return val1;
            return Math.Round(((val1 - (val1 % val2)) / val2) + 1, 0) * val2;
        }

        /// <summary>
        /// Roundup for every interval
        /// </summary>
        /// <param name="val1"></param>
        /// <param name="val2">interval</param>
        /// <returns></returns>
        public static double RoundUpby(this double val1, double val2)
        {
            var rem = (val1 % val2);
            if (rem.NearZero()) return val1;
            return Math.Round(((val1 - rem) / val2) + 1, 0) * val2;
        }

        /// <summary>
        /// multiply a number with 10 raised to ____
        /// </summary>
        /// <param name="val1"></param>
        /// <param name="val2">Power of th multiplyier number "10"</param>
        /// <returns></returns>
        public static double Exp(this double val1, double val2) =>
            val1 * Math.Pow(10, val2);

        /// <summary>
        /// Acts like an exponent/power
        /// </summary>
        /// <param name="val1"></param>
        /// <param name="val2">exponent</param>
        /// <returns></returns>
        public static double RaiseTo(this double val1, double val2) =>
            Math.Pow(val1, val2);

        /// <summary>
        /// Acts like an exponent/power
        /// </summary>
        /// <param name="val1"></param>
        /// <param name="val2">exponent</param>
        /// <returns></returns>
        public static double RaiseTo(this int val1, int val2) =>
            Math.Pow(val1, val2);

        /// <summary>
        /// Acts like an exponent/power
        /// </summary>
        /// <param name="val1"></param>
        /// <param name="val2">exponent</param>
        /// <returns></returns>
        public static double RaiseTo(this int val1, double val2) =>
            Math.Pow(val1, val2);

        /// <summary>
        /// Numeric Enumeration
        /// </summary>
        public enum NumberSign
        {
            /// <summary>
            /// Less that 0
            /// </summary>
            Negative = -1,

            /// <summary>
            /// Exactly Zero
            /// </summary>
            Neutral = 0,

            /// <summary>
            /// Greater than 0
            /// </summary>
            Positive = 1
        }

        /// <summary>
        /// Determine the sign of a number
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public static NumberSign Sign(this int num) =>
            num == 0
                ? Neutral
                : num < 0
                    ? Negative
                    : Positive;

        /// <summary>
        /// Desirable tostring of a double data type
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        public static string SmartToString(this double val)
        {
            if (val.NearZero(20)) return "0";
            var expForm = val.ScientificNotation();
            var baseVal = expForm.SignificantFigure.SmartRoundActual();
            if (expForm.Exp.IsWithin(-1, 3)) return val.ToString("#0.0##");
            return $"{ Math.Round(baseVal, 3)}*10^{expForm.Exp} ";
        }

        /// <summary>
        /// Determine the sign of a number
        /// </summary>
        /// <param name="num"></param>
        /// <param name="accuracy"></param>
        /// <returns></returns>
        public static NumberSign Sign(this double num, int accuracy = 5) =>
            num.NearZero(accuracy) ? Neutral : num < 0.0 ? Negative : Positive;

        /// <summary>
        /// Convert a  string to a number, if the string is not numeric then the return value will be zero
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        public static double ToDouble(this string val) => double.TryParse(val, out double result) ? result : 0;

        /// <summary>
        /// Check if string is a number and has float values.
        /// </summary>
        /// <param name="val">string to check</param>
        /// <returns></returns>
        public static bool HasDecimal(this string val) => double.TryParse(val, out double result) && result.HasDecimal();

        /// <summary>
        /// Return if a double value has floating values
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        public static bool HasDecimal(this double val) => !(val % 1).NearZero();

        /// <summary>
        /// Check if a string can potentially be converted into number
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        public static string GetPotentialNumber(this string val)
        {
            if (val == "." || val == "0.") return "0.";
            if (val == "-") return "-";
            if (val == "-." || val == "-0.") return "-0.";
            if (double.TryParse(val, out _)) return val;
            return "";
        }

        /// <summary>
        /// Round The number by finding the first repeated digits from the number;
        /// </summary>
        /// <param name="val"></param>
        /// <param name="digits">digits that are repeated</param>
        /// <returns></returns>
        public static double SmartRoundSignificantValue(this double val, params long[] digits)
        {
            var tempDigits = digits.Length < 1 ? new long[] { 9, 0 } : digits;
            var scientificNotation = val.ScientificNotation();
            var sig = scientificNotation.SignificantFigure;
            var arrOfDigits = sig.Store15DecimalsToArray();
            var roundAt = 14;
            for (var i = 2; i < arrOfDigits.Length - 1; i++)
            {
                var first3 = new[] { arrOfDigits[i - 1], arrOfDigits[i], arrOfDigits[i + 1] };
                if (tempDigits.Any(elem => first3.All(elem2 => elem2 == elem) || AdjacentDigitsAreRoundable(first3)))
                {
                    roundAt = i;
                    break;
                }
            }
            var exp = scientificNotation.Exp;
            return sig.Roundby(Math.Pow(10, -roundAt)).Exp(exp);
        }

        private static bool AdjacentDigitsAreRoundable(long[] digits)
        {
            if (digits[0] == 0 && digits[1] == 0 && digits[2] < 5) return true;
            if (digits[0] == 9 && digits[1] == 9 && digits[2] >= 5) return true;
            return false;
        }

        /// <summary>
        ///Round the value based on the repeated 999's and 000's
        /// </summary>
        /// <param name="val"></param>
        /// <param name="digits"></param>
        /// <returns></returns>
        public static double SmartRoundActual(this double val, params long[] digits)
        {
            var tempDigits = digits.Length < 1 ? new long[] { 9, 0 } : digits;
            var arrOfDigits = val.Store15DecimalsToArray();
            var roundAt = 14;
            for (var i = 2; i < arrOfDigits.Length; i++)
            {
                var first3 = new[] { arrOfDigits[i - 2], arrOfDigits[i - 1], arrOfDigits[i] };
                if (tempDigits.Any(elem => first3.All(elem2 => elem2 == elem) || AdjacentDigitsAreRoundable(first3)))
                {
                    roundAt = i - 1;
                    break;
                }
            }
            return val.Roundby(Math.Pow(10, -roundAt));
        }

        /// <summary>
        /// Convert an integer to an array of single digits
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        public static long[] IntToArray(this long val)
        {
            var list = new Stack<long>();
            var remainder = val;
            do
            {
                list.Push(remainder % 10);
                remainder /= 10;
            } while (remainder != 0);
            return list.ToArray();
        }

        /// <summary>
        /// Make 15 decimals to array
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        public static long[] Store15DecimalsToArray(this double val)
        {
            //Todo: do something about variable amount of decimals
            var excess15Decimals = Math.Abs(val - Math.Truncate(val));
            var tempArray = new List<long>();
            for (var i = 1; i < 16; i++)
            {
                var digit = (int)Math.Truncate(excess15Decimals * 10);
                tempArray.Add(digit);
                excess15Decimals = (excess15Decimals * 10) - digit;
            }
            return tempArray.ToArray();
        }
    }
}