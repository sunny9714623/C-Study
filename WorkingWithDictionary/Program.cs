using System;
using System.Collections.Generic;

namespace WorkingWithDictionary
{
    class Program
    {
        static void Main(string[] args)
        {
            var keywords = new Dictionary<string, string>();
            keywords.Add("int", "32-bit integer data type");
            keywords.Add("long", "64-bit integer data type");
            keywords.Add("float", "Single precision floating point number");
            Console.WriteLine("Keywords and their definitions");
            foreach(KeyValuePair<string,string> item in keywords)
            {
                Console.WriteLine($"{item.Key}:{item.Value}");
            }
            Console.WriteLine($"The definition of long is {keywords["long"]}");
        }
    }
}
