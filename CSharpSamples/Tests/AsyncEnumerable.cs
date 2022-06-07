using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace CSharpSamples.Tests
{
    public static class AsyncEnumerable
    {
        public static async Task AsyncTaskRead()
        {
            var lines = await ReadAsyncTask();
            foreach (var line in lines)
            {
                Console.WriteLine(line);
            }
        }

        public static async Task AsyncEnumerableRead()
        {
            var lines = ReadAsyncEnumerable();
            await foreach (var line in lines)
            {
                Console.WriteLine(line);
            }
        }

        private static async IAsyncEnumerable<string> ReadAsyncEnumerable()
        {
            var filePath = @"E:\Files\Documentos\TDCdotnet.txt";
            using (var fs = File.OpenRead(filePath))
            using (var reader = new StreamReader(fs))
            {
                while (true)
                {
                    var line = await reader.ReadLineAsync();
                    if (line is null) yield break;
                    yield return line;
                }
            }
        }

        private static async Task<IEnumerable<string>> ReadAsyncTask()
        {
            var list = new List<string>();
            var filePath = @"E:\Files\Documentos\TDCdotnet.txt";
            using (var fs = File.OpenRead(filePath))
            using (var reader = new StreamReader(fs))
            {
                while (true)
                {
                    var line = await reader.ReadLineAsync();
                    if (line is null) return list;
                    list.Add(line);
                }
            }
        }
    }
}
