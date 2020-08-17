using System;
using System.Collections.Generic;
using System.Linq;

namespace LIS.Common.Extensions
{
    public static class EnumerableExtensions
    {
        public static bool IsEmpty<T>(this IEnumerable<T> @this)
        {
            if (@this == null) throw new ArgumentNullException(nameof(@this));

            return !@this.Any();
        }

        public static bool IsNotEmpty<T>(this IEnumerable<T> @this)
        {
            if (@this == null) throw new ArgumentNullException(nameof(@this));

            return @this.Any();
        }

        public static bool IsNullOrEmpty<T>(this IEnumerable<T> @this)
        {
            return @this == null || !@this.Any();
        }

        public static bool IsNotNullOrEmpty<T>(this IEnumerable<T> @this)
        {
            return @this != null && @this.Any();
        }

        public static string StringJoin<T>(this IEnumerable<T> @this, string separator)
        {
            if (@this == null) throw new ArgumentNullException(nameof(@this));

            return string.Join(separator, @this);
        }

        public static string StringJoin<T>(this IEnumerable<T> @this, char separator)
        {
            if (@this == null) throw new ArgumentNullException(nameof(@this));

            return string.Join(separator.ToString(), @this);
        }
    }
}