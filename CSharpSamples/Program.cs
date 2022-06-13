using CSharpSamples.Tests;
using System;
using System.Reflection;
using System.Threading.Tasks;

namespace CSharpSamples
{
    class Program
    {
        static async Task Main(string[] args)
        {
            ExecuteTest(RecordsCsharp10.ReadonlyRecordStruct);
            ExecuteTest(RecordsCsharp10.RecordClass);
            ExecuteTest(SpanOfT.Run);
            await ExecuteTest(AsyncEnumerable.AsyncTaskRead);
            await ExecuteTest(AsyncEnumerable.AsyncEnumerableRead);
        }

        static void ExecuteTest(Action run)
        {
            WriteTitle(run.Method);
            run();
            FinishWrite();
        }

        static async Task ExecuteTest(Func<Task> run)
        {
            WriteTitle(run.Method);
            await run();
            FinishWrite();
        }

        static void WriteTitle(MethodInfo methodInfo)
        {
            string typeName = methodInfo.DeclaringType.Name, methodName = methodInfo.Name;
            Console.WriteLine($"Test {typeName}.{methodName}()");
            Console.WriteLine("======================");
            Console.WriteLine(Environment.NewLine);
        }

        static void FinishWrite()
        {
            Console.ReadKey();
            Console.Clear();
        }
    }
}
