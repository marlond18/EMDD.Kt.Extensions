using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace KtExtensions
{
    /// <summary>
    /// String extensions
    /// </summary>
    public static class StringManipulation
    {
        /// <summary>
        /// Similar to <see cref="string.IsNullOrEmpty(string)"/>
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsNullOrEmpty(this string str) => string.IsNullOrEmpty(str);

        /// <summary>
        /// Append A string then add new line
        /// </summary>
        /// <param name="sb"></param>
        /// <param name="str"></param>
        /// <returns></returns>
        public static StringBuilder AppendThenNewLine(this StringBuilder sb, string str) => sb.Append(str).AppendNewLine();

        /// <summary>
        /// Append A string then when
        /// </summary>
        /// <param name="sb"></param>
        /// <param name="str"></param>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public static StringBuilder AppendWhen(this StringBuilder sb, string str, Func<bool> predicate) => predicate != null && predicate() ? sb.Append(str) : sb;

        /// <summary>
        /// Append new line to the string builder
        /// </summary>
        /// <param name="sb"></param>
        /// <returns></returns>
        public static StringBuilder AppendNewLine(this StringBuilder sb) => sb.Append(Environment.NewLine);

        /// <summary>
        /// Concatenate all the element <see  cref="object.ToString()"/> value of an enumerable
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="enumerable"></param>
        /// <param name="separator">String separating each string</param>
        /// <param name="enclosure">strings enclosing the element string</param>
        /// <returns></returns>
        public static string BuildString<T>(this IEnumerable<T> enumerable, string separator, (string prefix, string suffix) enclosure) =>
            enumerable.Aggregate("", (comul, element) => comul.SmartConcat($"{enclosure.prefix}{element}{enclosure.suffix}", separator));

        /// <summary>
        /// Concatenate all the element <see  cref="object.ToString()"/> value of an enumerable
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="enumerable"></param>
        /// <param name="separator">String separating each string</param>
        /// <returns></returns>
        public static string BuildString<T>(this IEnumerable<T> enumerable, string separator) =>
            enumerable.Aggregate("", (comul, element) => comul.SmartConcat(element.ToString(), separator));

        /// <summary>
        /// Concatenate a repeat string at a number of times
        /// </summary>
        /// <param name="str">the string to be repeated</param>
        /// <param name="count">number of times to repeat</param>
        /// <returns></returns>
        public static string RepeatString(this string str, int count)
        {
            var builder = new StringBuilder();
            if (count < 1) return string.Empty;
            for (var i = 0; i < count; i++)
            {
                builder.Append(str);
            }
            return builder.ToString();
        }

        /// <summary>
        /// Remove the last letter of the string
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string RemoveLastChar(this string str)
        {
            if (str == null) return null;
            var strLength = str.Length;
            if (strLength <= 0) return str;
            return str.Remove(strLength - 1);
        }

        /// <summary>
        /// Determine if a character is inside a list of strings
        /// </summary>
        /// <param name="this"></param>
        /// <param name="possibles"></param>
        /// <returns></returns>
        public static bool Has(this string @this, params string[] possibles) =>
            possibles.Any(@this.Contains);

        /// <summary>
        /// Determine if a character is inside a list of characters
        /// </summary>
        /// <param name="this"></param>
        /// <param name="possibles"></param>
        /// <returns></returns>
        public static bool Has(this string @this, params char[] possibles) =>
            possibles.Any(@this.Contains);

        /// <summary>
        /// Make First Letter of a string into lower character
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string FirstCharacterToLower(this string str)
        {
            if (string.IsNullOrEmpty(str) || char.IsLower(str, 0)) return str;
            return char.ToLowerInvariant(str[0]) + str[1..];
        }

        /// <summary>
        /// Make First Letter of a string into upper character
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string FirstCharacterToUpper(this string str)
        {
            if (string.IsNullOrEmpty(str) || char.IsUpper(str, 0)) return str;
            return char.ToUpperInvariant(str[0]) + str[1..];
        }

        /// <summary>
        /// Remove Vowels from strings
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string RemoveVowels(this string str) => new(str.WhereNot("AaEeIiOoUu").ToArray());

        /// <summary>
        /// Be able identify if it is good to prepend a text to the main text
        /// <para/>if str is null or empty then an empty text is returned
        /// </summary>
        /// <param name="str"></param>
        /// <param name="strToPrepend"></param>
        public static string SmartPrepend(this string str, string strToPrepend) =>
            str.IsNullOrEmpty() ? string.Empty : strToPrepend + str;

        /// <summary>
        /// Be able identify if it is good to append a text to the main text
        /// <para/>if str is null or empty then an empty text is returned
        /// </summary>
        /// <param name="str"></param>
        /// <param name="strToAppend"></param>
        public static string SmartAppend(this string str, string strToAppend) =>
            str.IsNullOrEmpty() ? string.Empty : str + strToAppend;

        /// <summary>
        /// Concat Two strings with a filler
        /// </summary>
        /// <param name="str1"></param>
        /// <param name="str2"></param>
        /// <param name="filler"></param>
        /// <returns></returns>
        public static string SmartConcat(this string str1, string str2, string filler = " ") =>
            (str1.IsNullOrEmpty(), str2.IsNullOrEmpty()) switch
            {
                (true, true) => string.Empty,
                (true, false) => str2,
                (false, true) => str1,
                (false, false) => str1 + (filler.IsNullOrEmpty() ? " " : filler) + str2
            };

        /// <summary>
        /// Concat strings with filler
        /// </summary>
        /// <param name="str"></param>
        /// <param name="toConcat"></param>
        /// <param name="filler"></param>
        /// <returns></returns>
        public static string SmartConcat(this string str, string[] toConcat, string filler = " ") =>
            toConcat.Aggregate(str, (fin, cur) => fin.SmartConcat(cur, filler));

        /// <summary>
        /// Separate String and Number, example "text (1)" the text and the number will be extracted
        /// </summary>
        /// <param name="text"></param>
        /// <returns> text and a number, "text (1)" return "text " and "1" </returns>
        public static (string text, int number) SplitTextAndNumber(this string text)
        {
            Match regex = Regex.Match(text, @"(.+)\((\d+)\)");
            if (regex.Success)
            {
                return (regex.Groups[1].Value, int.Parse(regex.Groups[2].Value));
            }
            return (text, 0);
        }

        /// <summary>
        /// Check if string is a duplicate and create new numbered string
        /// </summary>
        /// <param name="str"></param>
        /// <param name="strs"></param>
        /// <returns></returns>
        public static string MakeUniqueFrom(this string str, IEnumerable<string> strs)
        {
            if (strs.Contains(str))
            {
                var (text, num) = str.SplitTextAndNumber();
                return $"{text}({num + 1})".MakeUniqueFrom(strs);
            }
            return str;
        }

        /// <summary>
        /// Check if string is a duplicate and create new numbered string
        /// </summary>
        /// <param name="str"></param>
        /// <param name="strs"></param>
        /// <param name="maxLength"></param>
        /// <returns></returns>
        public static string MakeUniqueFrom(this string str, IEnumerable<string> strs, int maxLength)
        {
            if (strs.Contains(str))
            {
                var (text, num) = str.SplitTextAndNumber();
                text = ClipTextWithNum(text, num, maxLength);
                return $"{text}({num + 1})".MakeUniqueFrom(strs, maxLength);
            }
            return str;
        }

        private static string ClipTextWithNum(string text, int num, int maxLength)
        {
            var diff = $"{text}({num + 1})".Length - maxLength;
            if (diff > 0)
            {
                text = text.Substring(0, text.Length - diff - 3) + "...";
            }
            return text;
        }

        /// <summary>
        /// Guard Claused Equals
        /// </summary>
        /// <param name="str1"></param>
        /// <param name="str2"></param>
        /// <returns></returns>
        public static bool GuardClausedEquals(this string str1, string str2)
        {
            if (ReferenceEquals(str1, str2)) return true;
            if (str1 is null || str2 is null) return false;
            return str1.Equals(str2);
        }

        /// <summary>
        /// Guard Claused Equals w/ string comparison
        /// </summary>
        /// <param name="str1"></param>
        /// <param name="str2"></param>
        /// <param name="stringComparison"></param>
        /// <returns></returns>
        public static bool GuardClausedEquals(this string str1, string str2, StringComparison stringComparison)
        {
            if (ReferenceEquals(str1, str2)) return true;
            if (str1 is null || str2 is null) return false;
            return str1.Equals(str2, stringComparison);
        }

        private static readonly string[] _unitsMap = new[] { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };

        private static readonly string[] tensMap = new[] { "zero", "ten", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };

        /// <summary>
        /// Convert integers to words
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static string ToWords(this int number)
        {
            if (number == 0)
                return "zero";

            if (number < 0)
                return "minus " + ToWords(Math.Abs(number));

            string words = "";

            if ((number / 1000000) > 0)
            {
                words += ToWords(number / 1000000) + " million ";
                number %= 1000000;
            }

            if ((number / 1000) > 0)
            {
                words += ToWords(number / 1000) + " thousand ";
                number %= 1000;
            }

            if ((number / 100) > 0)
            {
                words += ToWords(number / 100) + " hundred ";
                number %= 100;
            }

            if (number > 0)
            {
                if (words != "")
                    words += "and ";

                if (number < 20)
                {
                    words += _unitsMap[number];
                }
                else
                {
                    words += tensMap[number / 10];
                    if ((number % 10) > 0)
                        words += "-" + _unitsMap[number % 10];
                }
            }
            return words;
        }
    }
}