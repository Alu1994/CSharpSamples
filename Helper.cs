using System;
using System.Collections.Generic;
using System.Linq;

namespace CsharpSpanOfT
{
    public static class SpanExtensions
    {
        public static bool ContainsRole(this IEnumerable<Person> claims, ReadOnlySpan<char> allowedRoles)
        {
            ReadOnlySpan<char> prefix = "";
            ReadOnlySpan<char> suffix = ",";

            foreach (var userRole in claims)
            {
                for (var startIndex = 0; startIndex < allowedRoles.Length;)
                {
                    var value = allowedRoles[startIndex..];
                    var prefixIndex = value.IndexOf(prefix);
                    var postPrefixPosition = prefixIndex > -1 ? prefixIndex + prefix.Length : 0;

                    var sourceAfterPrefix = value[postPrefixPosition..];

                    var suffixIndex = sourceAfterPrefix.IndexOf(suffix);
                    var suffixPosition = suffixIndex > -1
                        ? suffixIndex
                        : sourceAfterPrefix.Length;

                    var currentRole = sourceAfterPrefix[..suffixPosition];

                    if (currentRole.SequenceEqual(userRole.Name))
                        return true;

                    startIndex += suffixPosition + prefix.Length + suffix.Length;
                }
            }

            return false;
        }
    }
}
