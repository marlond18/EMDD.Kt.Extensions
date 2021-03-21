using System;

namespace KtExtensions
{
    /// <summary>
    /// Extensions for dates
    /// </summary>
    public static class DateExtensions
    {
        /// <summary>
        /// Check if a date is between two spans ( excluding the time)
        /// </summary>
        /// <param name="current"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <param name="excludeBounds"></param>
        /// <returns></returns>
        public static bool IsBetweenDays(this DateTime current, DateTime start, DateTime end, bool excludeBounds = false)
        {
            return !excludeBounds ? current.Date <= end.Date && current.Date >= start.Date : current.Date < end.Date && current.Date > start.Date;
        }

        /// <summary>
        /// Check if a date is between two spans ( including thee relevant time)
        /// </summary>
        /// <param name="current"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <param name="excludeBounds"></param>
        /// <returns></returns>
        public static bool IsTimeSensitiveBetween(this DateTime current, DateTime start, DateTime end, bool excludeBounds = false)
        {
            return !excludeBounds ? current <= end && current >= start : current < end && current > start;
        }

        /// <summary>
        /// Return the total months of a datetime
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static int Months(this DateTime date) => (date.Year * 12) + date.Month;

        /// <summary>
        /// Get Total Weeks of a datetime
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static int Weeks(this DateTime date) => (int)(((date - new DateTime()).TotalDays / 7).RoundUpby(1.0));

        /// <summary>
        /// Get the start date of the week a datetime
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="startOfWeek"></param>
        /// <returns></returns>
        public static DateTime StartOfWeek(this DateTime dt, DayOfWeek startOfWeek = DayOfWeek.Monday)
        {
            int diff = (7 + (dt.DayOfWeek - startOfWeek)) % 7;
            return dt.AddDays(-1 * diff).Date;
        }

        /// <summary>
        /// Get the end date of the week of a datetime
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="endOfWeek"></param>
        /// <returns></returns>
        public static DateTime EndOfWeek(this DateTime dt, DayOfWeek endOfWeek = DayOfWeek.Sunday)
        {
            int diff = (7 + (endOfWeek - dt.DayOfWeek)) % 7;
            return dt.AddDays(diff).Date;
        }
    }
}
