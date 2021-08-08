using CsvHelper;
using CsvHelper.Configuration;

using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;

namespace KtExtensions.NetStandard
{
    /// <summary>
    /// File streaming
    /// </summary>
    public static class SimplifiedFileStream
    {
        /// <summary>
        /// Write CSV file
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="filePath"></param>
        /// <param name="elements"></param>
        public static bool WriteFileCSV<T>(string filePath, IEnumerable<T> elements)
        {
            using (var writer = new StreamWriter(filePath))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.WriteRecords(elements);
            }
            return true;
        }

        /// <summary>
        /// Add item to the CSV file
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="path"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static bool AppendFileCSV<T>(string path, IEnumerable<T> obj)
        {
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = false,
            };
            using (var stream = File.Open(path, FileMode.Append))
            using (var writer = new StreamWriter(stream))
            using (var csv = new CsvWriter(writer, config))
            {
                csv.WriteRecords(obj);
            }
            return true;
        }

        /// <summary>
        /// Write CSV File using <see cref="ClassMap{TClass}"/>
        /// </summary>
        /// <typeparam name="TMap"></typeparam>
        /// <typeparam name="T"></typeparam>
        /// <param name="path"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static bool WriteFileCSV<TMap, T>(string path, IEnumerable<T> obj) where TMap : ClassMap<T>
        {
            using (StreamWriter writer = new(path))
            using (CsvWriter csv = new(writer, CultureInfo.InvariantCulture))
            {
                _ = csv.Context.RegisterClassMap<TMap>();
                csv.WriteRecords(obj);
            }
            return true;
        }

        /// <summary>
        /// Read a CSV file
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="path"></param>
        public static IEnumerable<T> ReadFileCSV<T>(string path)
        {
            using var reader = new StreamReader(path);
            using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
            return csv.GetRecords<T>().ToList();
        }

        /// <summary>
        /// Write File XML
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="filePath"></param>
        /// <param name="element"></param>
        public static bool WriteFileXML<T>(string filePath, T element)
        {
            if (filePath == null) return false;
            var formatter = new XmlSerializer(typeof(T));
            using Stream stream = new FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.None);
            try
            {
                formatter.Serialize(stream, element);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Read XML File
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static TResult ReadFileXml<TResult>(string filePath)
        {
            if (filePath == null) return default;
            var formatter = new XmlSerializer(typeof(TResult));
            using Stream stream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read);
            if (formatter.Deserialize(stream) is TResult result)
                return result;
            return default;
        }

        /// <summary>
        /// Read File
        /// </summary>
        /// <typeparam name="TStreamOut"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="filePath"></param>
        /// <param name="func"></param>
        /// <returns></returns>
        public static TResult ReadFileBinary<TStreamOut, TResult>(string filePath, Func<TStreamOut, TResult> func)
        {
            if (filePath == null) return default;
            IFormatter formatter = new BinaryFormatter();
            using Stream stream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read);
            if (formatter.Deserialize(stream) is TStreamOut result)
            {
                return func(result);
            }
            return default;
        }

        /// <summary>
        /// Read File
        /// </summary>
        /// <typeparam name="TStreamOut"></typeparam>
        /// <param name="filePath"></param>
        /// <param name="act"></param>
        public static void ReadFileBinary<TStreamOut>(string filePath, Action<TStreamOut> act)
        {
            if (filePath == null) return;
            IFormatter formatter = new BinaryFormatter();
            using Stream stream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read);
            if (formatter.Deserialize(stream) is TStreamOut result)
            {
                act(result);
            }
        }

        /// <summary>
        /// Read File
        /// </summary>
        /// <typeparam name="TStreamOut1"></typeparam>
        /// <typeparam name="TStreamOut2"></typeparam>
        /// <param name="filePath"></param>
        /// <param name="r1"></param>
        /// <param name="r2"></param>
        public static bool ReadFileBinary<TStreamOut1, TStreamOut2>(string filePath, out TStreamOut1 r1, out TStreamOut2 r2)
        {
            r1 = default;
            r2 = default;
            if (filePath == null) return false;
            IFormatter formatter = new BinaryFormatter();
            using Stream stream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read);
            if (formatter.Deserialize(stream) is TStreamOut1 result1
                && formatter.Deserialize(stream) is TStreamOut2 result2)
            {
                r1 = result1;
                r2 = result2;
                return true;
            }
            return false;
        }

        /// <summary>
        /// Read File
        /// </summary>
        /// <typeparam name="TStreamOut1"></typeparam>
        /// <typeparam name="TStreamOut2"></typeparam>
        /// <typeparam name="TStreamOut3"></typeparam>
        /// <param name="filePath"></param>
        /// <param name="r1"></param>
        /// <param name="r2"></param>
        /// <param name="r3"></param>
        public static bool ReadFileBinary<TStreamOut1, TStreamOut2, TStreamOut3>(string filePath, out TStreamOut1 r1, out TStreamOut2 r2, out TStreamOut3 r3)
        {
            r1 = default;
            r2 = default;
            r3 = default;
            if (filePath == null) return false;
            IFormatter formatter = new BinaryFormatter();
            using Stream stream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read);
            if (formatter.Deserialize(stream) is TStreamOut1 result1
                && formatter.Deserialize(stream) is TStreamOut2 result2
                && formatter.Deserialize(stream) is TStreamOut3 result3
                )
            {
                r1 = result1;
                r2 = result2;
                r3 = result3;
                return true;
            }
            return false;
        }

        /// <summary>
        /// Read File
        /// </summary>
        /// <typeparam name="TStreamOut1"></typeparam>
        /// <typeparam name="TStreamOut2"></typeparam>
        /// <typeparam name="TStreamOut3"></typeparam>
        /// <typeparam name="TStreamOut4"></typeparam>
        /// <param name="filePath"></param>
        /// <param name="r1"></param>
        /// <param name="r2"></param>
        /// <param name="r3"></param>
        /// <param name="r4"></param>
        public static bool ReadFileBinary<TStreamOut1, TStreamOut2, TStreamOut3, TStreamOut4>(string filePath, out TStreamOut1 r1, out TStreamOut2 r2, out TStreamOut3 r3, out TStreamOut4 r4)
        {
            r1 = default;
            r2 = default;
            r3 = default;
            r4 = default;
            if (filePath == null) return false;
            IFormatter formatter = new BinaryFormatter();
            using Stream stream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read);
            if (formatter.Deserialize(stream) is TStreamOut1 result1
                && formatter.Deserialize(stream) is TStreamOut2 result2
                && formatter.Deserialize(stream) is TStreamOut3 result3
                && formatter.Deserialize(stream) is TStreamOut4 result4
                )
            {
                r1 = result1;
                r2 = result2;
                r3 = result3;
                r4 = result4;
                return true;
            }
            return false;
        }

        /// <summary>
        /// Read File
        /// </summary>
        /// <typeparam name="TStreamOut1"></typeparam>
        /// <typeparam name="TStreamOut2"></typeparam>
        /// <typeparam name="TStreamOut3"></typeparam>
        /// <typeparam name="TStreamOut4"></typeparam>
        /// <typeparam name="TStreamOut5"></typeparam>
        /// <param name="filePath"></param>
        /// <param name="r1"></param>
        /// <param name="r2"></param>
        /// <param name="r3"></param>
        /// <param name="r4"></param>
        /// <param name="r5"></param>
        public static bool ReadFileBinary<TStreamOut1, TStreamOut2, TStreamOut3, TStreamOut4, TStreamOut5>(string filePath, out TStreamOut1 r1, out TStreamOut2 r2, out TStreamOut3 r3, out TStreamOut4 r4, out TStreamOut5 r5)
        {
            r1 = default;
            r2 = default;
            r3 = default;
            r4 = default;
            r5 = default;
            if (filePath == null) return false;
            IFormatter formatter = new BinaryFormatter();
            using Stream stream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read);
            if (formatter.Deserialize(stream) is TStreamOut1 result1
                && formatter.Deserialize(stream) is TStreamOut2 result2
                && formatter.Deserialize(stream) is TStreamOut3 result3
                && formatter.Deserialize(stream) is TStreamOut4 result4
                && formatter.Deserialize(stream) is TStreamOut5 result5
                )
            {
                r1 = result1;
                r2 = result2;
                r3 = result3;
                r4 = result4;
                r5 = result5;
                return true;
            }
            return false;
        }

        /// <summary>
        /// Read File
        /// </summary>
        /// <typeparam name="TStreamOut1"></typeparam>
        /// <typeparam name="TStreamOut2"></typeparam>
        /// <typeparam name="TStreamOut3"></typeparam>
        /// <typeparam name="TStreamOut4"></typeparam>
        /// <typeparam name="TStreamOut5"></typeparam>
        /// <typeparam name="TStreamOut6"></typeparam>
        /// <param name="filePath"></param>
        /// <param name="r1"></param>
        /// <param name="r2"></param>
        /// <param name="r3"></param>
        /// <param name="r4"></param>
        /// <param name="r5"></param>
        /// <param name="r6"></param>
        public static bool ReadFileBinary<TStreamOut1, TStreamOut2, TStreamOut3, TStreamOut4, TStreamOut5, TStreamOut6>(string filePath, out TStreamOut1 r1, out TStreamOut2 r2, out TStreamOut3 r3, out TStreamOut4 r4, out TStreamOut5 r5, out TStreamOut6 r6)
        {
            r1 = default;
            r2 = default;
            r3 = default;
            r4 = default;
            r5 = default;
            r6 = default;
            if (filePath == null) return false;
            IFormatter formatter = new BinaryFormatter();
            using Stream stream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read);
            if (formatter.Deserialize(stream) is TStreamOut1 result1
                && formatter.Deserialize(stream) is TStreamOut2 result2
                && formatter.Deserialize(stream) is TStreamOut3 result3
                && formatter.Deserialize(stream) is TStreamOut4 result4
                && formatter.Deserialize(stream) is TStreamOut5 result5
                && formatter.Deserialize(stream) is TStreamOut6 result6
                )
            {
                r1 = result1;
                r2 = result2;
                r3 = result3;
                r4 = result4;
                r5 = result5;
                r6 = result6;
                return true;
            }
            return false;
        }

        /// <summary>
        /// Read File
        /// </summary>
        /// <typeparam name="TStreamOut1"></typeparam>
        /// <typeparam name="TStreamOut2"></typeparam>
        /// <typeparam name="TStreamOut3"></typeparam>
        /// <typeparam name="TStreamOut4"></typeparam>
        /// <typeparam name="TStreamOut5"></typeparam>
        /// <typeparam name="TStreamOut6"></typeparam>
        /// <typeparam name="TStreamOut7"></typeparam>
        /// <param name="filePath"></param>
        /// <param name="r1"></param>
        /// <param name="r2"></param>
        /// <param name="r3"></param>
        /// <param name="r4"></param>
        /// <param name="r5"></param>
        /// <param name="r6"></param>
        /// <param name="r7"></param>
        public static bool ReadFileBinary<TStreamOut1, TStreamOut2, TStreamOut3, TStreamOut4, TStreamOut5, TStreamOut6, TStreamOut7>(string filePath, out TStreamOut1 r1, out TStreamOut2 r2, out TStreamOut3 r3, out TStreamOut4 r4, out TStreamOut5 r5, out TStreamOut6 r6, out TStreamOut7 r7)
        {
            r1 = default;
            r2 = default;
            r3 = default;
            r4 = default;
            r5 = default;
            r6 = default;
            r7 = default;
            if (filePath == null) return false;
            IFormatter formatter = new BinaryFormatter();
            using Stream stream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read);
            if (formatter.Deserialize(stream) is TStreamOut1 result1
                && formatter.Deserialize(stream) is TStreamOut2 result2
                && formatter.Deserialize(stream) is TStreamOut3 result3
                && formatter.Deserialize(stream) is TStreamOut4 result4
                && formatter.Deserialize(stream) is TStreamOut5 result5
                && formatter.Deserialize(stream) is TStreamOut6 result6
                && formatter.Deserialize(stream) is TStreamOut7 result7
                )
            {
                r1 = result1;
                r2 = result2;
                r3 = result3;
                r4 = result4;
                r5 = result5;
                r6 = result6;
                r7 = result7;
                return true;
            }
            return false;
        }

        /// <summary>
        /// Write File
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="filePath"></param>
        /// <param name="element"></param>
        public static void WriteFileBinary<T>(string filePath, T element)
        {
            if (filePath == null) return;
            IFormatter formatter = new BinaryFormatter();
            using Stream stream = new FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.None);
            formatter.Serialize(stream, element);
        }

        /// <summary>
        /// Serialize Objects into a single filename
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="elements"></param>
        public static void WriteFileBinary(string filePath, params object[] elements)
        {
            if (filePath == null) return;
            IFormatter formatter = new BinaryFormatter();
            using Stream stream = new FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.None);
            foreach (var element in elements)
            {
                formatter.Serialize(stream, element);
            }
        }
    }
}
