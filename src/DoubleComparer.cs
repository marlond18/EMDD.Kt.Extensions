using System;
using System.Collections.Generic;

namespace KtExtensions
{
    /// <summary>
    /// Compare double data type
    /// </summary>
    internal class DoubleComparer : IEqualityComparer<double>
    {
        /// <summary>Determines whether the specified objects are equal.</summary>
        /// <returns>true if the specified objects are equal; otherwise, false.</returns>
        /// <param name="x">The first object of type <paramref>
        ///         <name>double</name>
        ///     </paramref>
        ///     to compare.</param>
        /// <param name="y">The second object of type <paramref>
        ///         <name>double</name>
        ///     </paramref>
        ///     to compare.</param>
        public bool Equals(double x, double y) => x.NearEqual(y);

        /// <summary>Returns a hash code for the specified object.</summary>
        /// <returns>A hash code for the specified object.</returns>
        /// <param name="obj">The <see cref="T:System.Object" /> for which a hash code is to be returned.</param>
        /// <exception cref="T:System.ArgumentNullException">The type of <paramref name="obj" /> is a reference type and <paramref name="obj" /> is null.</exception>
        public int GetHashCode(double obj) => Math.Round(obj, 12).GetHashCode();
    }
}