using System;
using System.Collections.Generic;
using System.Linq;

namespace KtExtensions
{
    /// <summary>
    /// Extensions for type
    /// </summary>
    public static class TypesExtensions
    {
        /// <summary>
        /// Determine if a generic param is a Nullable type
        /// Reference: Traub, D. (2011, March 3). Determine if a generic param is a Nullable type [Online forum comment]. Message
        ///                 posted to https://stackoverflow.com/questions/5181494/determine-if-a-generic-param-is-a-nullable-type
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static bool IsNullable(this Type type)
        {
            if (type == null) throw new ArgumentNullException(nameof(type));
            return type.IsDerivedFromOpenGenericType(typeof(Nullable<>));
        }

        /// <summary>
        /// Determine if a type is derived from open generic type
        /// Reference: KallDrexx (2011, June 21). How can I use reflection to return all classes subclassing from a generic, without giving a specific generic type [Online forum comment]. Message
        ///                 posted to https://stackoverflow.com/questions/6426949/how-can-i-use-reflection-to-return-all-classes-subclassing-from-a-generic-witho/6427201#6427201
        /// </summary>
        /// <param name="type"></param>
        /// <param name="openGenericType"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public static bool IsDerivedFromOpenGenericType(this Type type, Type openGenericType)
        {
            if (type == null ) throw new ArgumentNullException(nameof(type));
            if (openGenericType == null) throw new ArgumentNullException(nameof(openGenericType));
            if (!openGenericType.IsGenericTypeDefinition) throw new ArgumentException("Second type is not a generic type");
            return type.GetTypeHierarchy().Where(t => t.IsGenericType).Select(t => t.GetGenericTypeDefinition()).Any(openGenericType.Equals);
        }

        /// <summary>
        /// Get all type derivation
        /// Reference: KallDrexx (2011, June 21). How can I use reflection to return all classes subclassing from a generic, without giving a specific generic type [Online forum comment]. Message
        ///                 posted to https://stackoverflow.com/questions/6426949/how-can-i-use-reflection-to-return-all-classes-subclassing-from-a-generic-witho/6427201#6427201
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static IEnumerable<Type> GetTypeHierarchy(this Type type)
        {
            if (type == null) throw new ArgumentNullException(nameof(type));
            return GetTypeHierarchyIterator();
            IEnumerable<Type> GetTypeHierarchyIterator()
            {
                Type currentType = type;
                while (currentType != null)
                {
                    yield return currentType;
                    currentType = currentType.BaseType;
                }
            }
        }
    }
}