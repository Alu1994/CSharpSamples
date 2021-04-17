using System;
using System.Collections.Generic;
using System.Linq;

namespace CsharpSpanOfT
{
    class Program
    {
        static void Main(string[] args)
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

            Console.ReadLine();
        }
    }
}
