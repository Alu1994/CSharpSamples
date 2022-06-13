using System;

namespace CSharpSamples.Tests
{
    public static class RecordsCsharp10
    {
        public static void RecordClass()
        {
            var dRC1 = new DerivedExampleR 
            {
                FirstName = "Phil",
                LastName = "Collings",
                CompleteName = "Phil Collings Vol. 2"
            };
            var dRC2 = new DerivedExampleR
            {
                FirstName = "Phil",
                LastName = "Collings",
                CompleteName = "Phil Collings Vol. 2"
            };
            var dRC3 = dRC1;
            Console.WriteLine(dRC1.ToString());
            Console.WriteLine($"{nameof(dRC1)} {{ FirstName = {dRC1.FirstName}, LastName = {dRC1.LastName}, CompleteName = {dRC1.CompleteName} }} // new object");
            Console.WriteLine($"{nameof(dRC2)} {{ FirstName = {dRC2.FirstName}, LastName = {dRC2.LastName}, CompleteName = {dRC2.CompleteName} }} // new object");
            Console.WriteLine($"{nameof(dRC3)} {{ FirstName = {dRC3.FirstName}, LastName = {dRC3.LastName}, CompleteName = {dRC3.CompleteName} }} // Copied From dRC1");
            Console.WriteLine($"{nameof(dRC1)} == {nameof(dRC2)}: {dRC1 == dRC2}");
            Console.WriteLine($"{nameof(dRC1)} == {nameof(dRC3)}: {dRC1 == dRC3}");
            Console.WriteLine($"{nameof(dRC1)} ReferenceEquals() {nameof(dRC2)}: {ReferenceEquals(dRC1, dRC2)}");
            Console.WriteLine($"{nameof(dRC1)} ReferenceEquals() {nameof(dRC3)}: {ReferenceEquals(dRC1, dRC3)}");
        }

        public static void ReadonlyRecordStruct()
        {
            var rRS1 = new ExampleRS 
            { 
                Name = "Bruce",
                LastName = "Dickson"
            };
            var rRS2 = new ExampleRS
            {
                Name = "Bruce",
                LastName = "Dickson"
            };
            var rRS3 = rRS1;
            Console.WriteLine(rRS1.ToString());
            Console.WriteLine(rRS2.ToString());
            Console.WriteLine(rRS3.ToString());
            Console.WriteLine($"{nameof(rRS1)} == {nameof(rRS2)}: {rRS1 == rRS2}");
            Console.WriteLine($"{nameof(rRS1)} == {nameof(rRS3)}: {rRS1 == rRS3}");
            Console.WriteLine($"{nameof(rRS1)} ReferenceEquals() {nameof(rRS2)}: {ReferenceEquals(rRS1, rRS2)}");
            Console.WriteLine($"{nameof(rRS1)} ReferenceEquals() {nameof(rRS3)}: {ReferenceEquals(rRS1, rRS3)}");
        }
    }

    public record class BaseExampleR
    {
        public string FirstName { get; init; }
        public string LastName { get; init; }

        // use 'sealed' keyword to preserve the base override
        // when implement in other record
        public override string ToString()
        {
            return "BaseExampleR";
        }
    }

    public record class DerivedExampleR : BaseExampleR
    {
        public string CompleteName { get; init; }

        public override string ToString()
        {
            return $"{base.ToString()} + DerivedExampleR";
        }
    }

    public readonly record struct ExampleRS(string Name, string LastName);
}
