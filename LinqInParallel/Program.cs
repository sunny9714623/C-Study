using System;
using System.Diagnostics;
using System.Collections.Generic;
using static System.Console;
using System.Linq;

namespace LinqInParallel
{
    class Program
    {
        static void Main(string[] args)
        {
            var watch = Stopwatch.StartNew();
            Write("Press ENTER to start: ");
            ReadLine();
            watch.Start();
            IEnumerable<int> numbers = Enumerable.Range(1, 200000000);
            var squares = numbers.AsParallel().Select(number => number * number).ToArray();
            watch.Stop();
            WriteLine("{0:#,##0} elapsed milliseconds.", watch.ElapsedMilliseconds);
        }
    }
}
