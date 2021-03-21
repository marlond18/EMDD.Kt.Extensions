using System;

namespace KtExtensions
{
    /// <summary>
    /// Extensions for converting numeric values to proper string format
    /// </summary>
    public static class NumberDisplayExtensions
    {
        /// <summary>
        /// Convert a number into string exponential form string
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        public static string ToExp(this double val)
        {
            var tostring = $"{val:#.###E0}";
            try
            {
                var strings = tostring.Split('E');
                return $"{strings[0]}×10^{strings[1]}";
            }
            catch (Exception)
            {
                return tostring;
            }
        }
    }
}
