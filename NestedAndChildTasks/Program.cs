﻿using System;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;
using static System.Console;

namespace NestedAndChildTasks
{
    class Program
    {
        static void Main(string[] args)
        {
            var outer = Task.Factory.StartNew(OuterMethod);
            outer.Wait();
            WriteLine("Console app is stopping.");
        }

        static void OuterMethod()
        {
            WriteLine("Outer method starting...");
            var inner = Task.Factory.StartNew(InnerMethod, TaskCreationOptions.AttachedToParent);
            // Output：
            //Outer method starting...
            //Outer method finished.
            //Inner method starting...
            //Inner method finished.
            //Console app is stopping.
            WriteLine("Outer method finished.");
        }

        static void InnerMethod()
        {
            WriteLine("Inner method starting...");
            Thread.Sleep(2000);
            WriteLine("Inner method finished.");
        }
    }
}
