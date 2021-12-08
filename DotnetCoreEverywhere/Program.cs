using System;
using System.Collections.Generic;
using System.Linq;
using static System.Console;

namespace DotnetCoreEverywhere
{
    class Program
    {
        // class类型返回的是引用类型，这样可以直接更改。
        static void Main(string[] args)
        {
            List<Student> abc = new List<Student>() { new Student { ID = 5, Name = "George" }, new Student { ID = 7, Name = "Simon" } };
            var a = abc.Where(t => t.ID==5).FirstOrDefault();
            a.Name = "123";
            foreach (var item in abc)
            {
                Console.WriteLine(item.Name);
            }
        }
    }
}
