using System;
using System.Threading;

namespace KtExtensions.Windows
{
    /// <summary>
    /// Extensions to Common Threading
    /// </summary>
    public static class ThreadingExtensions
    {
        /// <summary>
        /// Extension to use to solve STA problems on threading, example is on Clipboard operations like Copy Pasting
        /// </summary>
        /// <param name="action"></param>
        public static void RunThreadOnASTA(this Action<object> action)
        {
            var thread = new Thread(new ParameterizedThreadStart(action));
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
        }
    }
}