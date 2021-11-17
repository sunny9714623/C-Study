using System;
using System.Linq;
using static System.Console;

namespace LinqWithArrayOfExceptions
{
    class Program
    {
        static void Main(string[] args)
        {
            LinqWithArrayOfExceptions();
        }
        static void LinqWithArrayOfExceptions()
        {
            var errors = new Exception[]
            {
                new ArgumentException(),
                new SystemException(),
                new IndexOutOfRangeException(),
                new InvalidOperationException(),
                new NullReferenceException(),
                new InvalidCastException(),
                new OverflowException(),
                new DivideByZeroException(),
                new ApplicationException()
            };
            var numberErrors = errors.OfType<ArithmeticException>();
            foreach(var error in numberErrors)
            {
                WriteLine(error);
            }
        }
    }
}
