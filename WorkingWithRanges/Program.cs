using System;

namespace WorkingWithRanges
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = "Samantha Jones";
            int lengthOfFirst = name.IndexOf(' ');
            int lengthOfLast = name.Length - name.IndexOf(' ') - 1;
            string firstName = name.Substring(0, lengthOfFirst);
            string lastName = name.Substring(name.Length - lengthOfLast, lengthOfLast);
            Console.WriteLine($"First Name:{firstName}, Last Name:{lastName}");
            ReadOnlySpan<char> nameAsSpan = name.AsSpan();
            var firstNameSpan = nameAsSpan[0..lengthOfFirst];
            var lastNameSpan = nameAsSpan[^lengthOfLast..^0];
            Console.WriteLine("First name:{0}, Last name:{1}", firstNameSpan.ToString(), lastNameSpan.ToString());
        }
    }
}
