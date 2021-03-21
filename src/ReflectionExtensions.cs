using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace KtExtensions
{
    /// <summary>
    /// Reflection extensions
    /// </summary>
    public static class ReflectionExtensions
    {
        /// <summary>
        /// Search all property names, get their values, and store them into a dictionary of string/object generic type
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static IDictionary<string, object> GetPropertyValues(this object obj)
        {
            var newdictionary = new Dictionary<string, object>();
            foreach (var propertyName in obj.GetType().GetProperties().Select(p => p.Name))
            {
                newdictionary.Add(propertyName, obj.GetPropertyValue(propertyName));
            }
            return newdictionary;
        }

        /// <summary>
        /// Search all property names, get their values, and store them into a dictionary of string/object generic type
        /// </summary>
        /// <param name="objs"></param>
        /// <returns></returns>
        public static (string[] headers, object[,] content) GetPropertyValues<T>(this IEnumerable<T> objs)
        {
            var propertyNames = typeof(T).GetProperties().Select(p => p.Name).ToArray();
            var propertyCount = propertyNames.Length;
            if (propertyCount <= 0) return (propertyNames, null);
            var objectCount = objs.Count();
            if (objectCount <= 0) return (propertyNames, null);
            var tempContent = new object[objectCount, propertyCount];
            var objsList = objs.ToList();
            for (int i = 0; i < objsList.Count; i++)
            {
                for (int i2 = 0; i2 < propertyNames.Length; i2++)
                {
                    tempContent[i, i2] = objsList[i].GetPropertyValue(propertyNames[i2]);
                }
            }
            return (propertyNames, tempContent);
        }

        /// <summary>
        /// The the value of the runtime property of name <paramref name="pName"/>
        /// </summary>
        /// <param name="o"></param>
        /// <param name="pName"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static object GetPropertyValue(this object o, string pName)
        {
            return string.IsNullOrEmpty(pName)
                ? throw new ArgumentNullException(nameof(pName))
                : (o.GetType().GetRuntimeProperty(pName)?.GetValue(o));
        }

        /// <summary>
        /// Get the property value cascaded to its subproperties
        /// </summary>
        /// <param name="o"></param>
        /// <param name="pNames"></param>
        /// <returns></returns>
        public static object GetCascadedPropertyValue(this object o, params string[] pNames)
        {
            var temp = o;
            if (pNames is null) return temp;
            foreach (var name in pNames)
            {
                var result = temp.GetPropertyValue(name);
                if (result is null) return result;
                temp = result;
            }
            return temp;
        }

        /// <summary>
        /// Get the property value cascaded to its subproperties
        /// </summary>
        /// <param name="o"></param>
        /// <param name="name"></param>
        public static object GetCascadedPropertyValue(this object o, string name) =>
            name.IsNullOrEmpty() ? o : o.GetCascadedPropertyValue(name.Split('.').Select(s => s.Trim()).ToArray());

        /// <summary>
        /// Get the value of Property and cast it to it's proper type
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        public static T GetPropertyValue<T>(this object obj, string propertyName)
        {
            var retval = GetPropertyValue(obj, propertyName);
            if (retval == null) { return default; }
            if (retval is not T val) throw new ArgumentException($"{typeof(T)} cannot be recognized as type of property value");
            return val;
        }

        /// <summary>
        /// Get value of object
        /// </summary>
        /// <param name="o"></param>
        /// <param name="pName"></param>
        /// <returns></returns>
        public static string PropertyValueString(this object o, string pName) => o == null ? "" : InnerGetStringValOfProperty(o.GetPropertyValue(pName));

        private static string InnerGetStringValOfProperty(this object oo) => oo is null ? "" : oo.ToString();
    }
}