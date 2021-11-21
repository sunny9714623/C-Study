using System;
using System.Diagnostics;
using static System.Console;
using static System.Diagnostics.Process;

namespace Packt.Shared
{
    public static class Recorder
    {
        static Stopwatch timer = new Stopwatch();
        static long bytesPhsicalBefore = 0;
        static long bytesVirtualBefore = 0;
        public static void Start()
        {
            // force two garbage collections to release memory that is
            // no longer refenrenced but has not been released yet.
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();

            // store the current physical and virtual memory use
            bytesPhsicalBefore = GetCurrentProcess().WorkingSet64;
            bytesVirtualBefore = GetCurrentProcess().VirtualMemorySize64;
            timer.Restart();
        }

        public static void Stop()
        {
            timer.Stop();
            long bytesPhysicalAfter = GetCurrentProcess().WorkingSet64;
            long bytesVirtualAfter = GetCurrentProcess().VirtualMemorySize64;
            WriteLine("{0:N0} physical bytes used.", bytesPhysicalAfter - bytesPhsicalBefore);
            WriteLine("{0:N0} virtual bytes used.", bytesVirtualAfter - bytesVirtualBefore);
            WriteLine("{0} time span ellapsed.", timer.Elapsed);
            WriteLine("{0:N0} total milliseconds ellapsed.", timer.ElapsedMilliseconds);
        }
    }
}
