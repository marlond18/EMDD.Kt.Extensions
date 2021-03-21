using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;

namespace KtExtensions
{
    /// <summary>
    /// Extensions for System.IO.File and System.IO.Path
    /// </summary>
    public static class FilePathExtensions
    {
        /// <summary>
        /// extension of File.Copy where destination name will be made unique using <see cref="GetUniqueFilePath(string)"/>
        /// </summary>
        /// <param name="source"></param>
        /// <param name="filePathDestination"></param>
        /// <returns></returns>
#pragma warning disable RCS1224 // Make method an extension method.
        public static string CopyToUniqueName(string source, string filePathDestination)
#pragma warning restore RCS1224 // Make method an extension method.
        {
            var uniqueFilePath = filePathDestination.GetUniqueFilePath();
            File.Copy(source, uniqueFilePath);
            return uniqueFilePath;
        }

        /// <summary>
        /// Make file path unique
        /// </summary>
        /// <param name="filepath"></param>
        /// <returns></returns>
        public static string GetUniqueFilePath(this string filepath)
        {
            if (File.Exists(filepath))
            {
                string folder = Path.GetDirectoryName(filepath);
                string filename = Path.GetFileNameWithoutExtension(filepath);
                string extension = Path.GetExtension(filepath);
                int number = 0;
                Match regex = Regex.Match(filepath, @"(.+) \((\d+)\)\.\w+");
                if (regex.Success)
                {
                    filename = regex.Groups[1].Value;
                    number = int.Parse(regex.Groups[2].Value);
                }
                do
                {
                    number++;
                    filepath = Path.Combine(folder, string.Format("{0} ({1}){2}", filename, number, extension));
                }
                while (File.Exists(filepath));
            }
            return filepath;
        }

        private const int ERROR_SHARING_VIOLATION = 32;
        private const int ERROR_LOCK_VIOLATION = 33;

        private static bool IsFileLocked(Exception exception)
        {
            int errorCode = Marshal.GetHRForException(exception) & ((1 << 16) - 1);
            return errorCode == ERROR_SHARING_VIOLATION || errorCode == ERROR_LOCK_VIOLATION;
        }

        /// <summary>
        /// Check if a file can be opened
        /// </summary>
        /// <param name="filePath"></param>
#pragma warning disable RCS1224 // Make method an extension method.
        public static bool CanReadFile(string filePath)
#pragma warning restore RCS1224 // Make method an extension method.
        {
            try
            {
                using FileStream fileStream = File.Open(filePath, FileMode.Open, FileAccess.Read, FileShare.None);
                fileStream?.Close();
            }
            catch (IOException ex)
            {
                if (IsFileLocked(ex))
                {
                    return false;
                }
            }
            return true;
        }
    }
}