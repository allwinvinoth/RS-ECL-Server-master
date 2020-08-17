using System;
using System.Collections.Generic;
using System.Linq;

namespace LIS.Common.Extensions
{
    public static class StringExtensions
    {
        public static bool IsNullOrEmpty(this string @this)
        {
            return string.IsNullOrEmpty(@this);
        }

        public static bool IsNotNullOrEmpty(this string @this)
        {
            return !@this.IsNullOrEmpty();
        }

        public static string NullIfEmpty(this string @this)
        {
            return @this == string.Empty ? null : @this;
        }

        public static IEnumerable<string> SplitAndTrim(this string @this, params char[] separators)
        {
            if (@this == null) throw new ArgumentNullException(nameof(@this));
            return @this.Trim().Split(separators, StringSplitOptions.RemoveEmptyEntries).Select(s => s.Trim());
        }

        public static bool Contains(this string @this, string input, StringComparison comparison)
        {
            if (@this == null) throw new ArgumentNullException(nameof(@this));

            return @this.IndexOf(input, comparison) >= 0;
        }

        public static bool IsValidDateFormat(this string @this)
        {
            DateTime dateTime;
            return DateTime.TryParse(@this, out dateTime);
        }
    }
}