using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharpSamples.Tests
{
    public static class SpanOfT
    {
        public static void Run()
        {
            var people = new List<Person>();
            Enumerable.Range(0, 5).ToList().ForEach(x => {
                people.Add(new Person { Name = "Matheus" });
            });

            var stringWithMatheus = "Clark,Matheus,Viviam,Lois";
            var resultTrue = people.ContainsRole(stringWithMatheus);
            Console.WriteLine($"List: {stringWithMatheus} \r\n \tHas Matheus?: {resultTrue}");

            Console.WriteLine();

            var stringWithoutMatheus = "Clark,Matheus2,Viviam,Lois";
            var resultFalse = people.ContainsRole(stringWithoutMatheus);
            Console.WriteLine($"List: {stringWithoutMatheus} \r\n \tHas Matheus?: {resultFalse}");
        }

        private static bool ContainsRole(this IEnumerable<Person> claims, ReadOnlySpan<char> allowedRoles)
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

        private class Person
        {
            public string Name { get; set; }
        }
    }
}
