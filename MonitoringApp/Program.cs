﻿using System;
using System.Linq;
using Packt.Shared;
using static System.Console;

namespace MonitoringApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //WriteLine("Processing. Please wait......");
            //Recorder.Start();

            //// simulate a process that requires some memory resources...
            //int[] largeArrayOfInts = Enumerable.Range(1, 10000).ToArray();

            //// ... and takes some time to complete
            //System.Threading.Thread.Sleep(new Random().Next(5, 10) * 1000);
            //Recorder.Stop();

            int[] numbers = Enumerable.Range(1, 50000).ToArray();
            Recorder.Start();
            WriteLine("Using string with +");
            string s = "";
            for(int i = 0; i < numbers.Length; i++)
            {
                s += numbers[i] + ", ";
            }
            Recorder.Stop();

            Recorder.Start();
            WriteLine("Using stringBuilder");
            var builder = new System.Text.StringBuilder();
            for(int i = 0; i < numbers.Length; i++)
            {
                builder.Append(numbers[i]);
                builder.Append(", ");
            }
            Recorder.Stop();
        }
    }
}
