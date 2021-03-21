using System.Collections.Generic;
using System.Linq;

namespace KtExtensions
{
    /// <summary>
    /// Comparer for Collection Unarranged
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class CollectionEqComparerUnarranged<T> : EqualityComparer<IEnumerable<T>>
    {
        /// <summary>
        /// Equality
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public override bool Equals(IEnumerable<T> x, IEnumerable<T> y) => x.All(y.Contains) && y.All(x.Contains);

        /// <summary>
        /// Hashcode
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override int GetHashCode(IEnumerable<T> obj) => unchecked(241.ChainHashCode(obj));
    }
}