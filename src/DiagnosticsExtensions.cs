using System;
using System.Diagnostics;

namespace KtExtensions
{
    /// <summary>
    /// Extensions for Diagnostics
    /// </summary>
    public static class DiagnosticsExtensions
    {
        /// <summary>
        /// Get Elapsed time for action
        /// </summary>
        /// <param name="action"></param>
        /// <returns></returns>
        public static long ElapsedTime(this Action action)
        {
            if (action == null) return 0;
            var sw = new Stopwatch();
            sw.Start();
            action();
            sw.Stop();
            return sw.ElapsedMilliseconds;
        }
    }
}
