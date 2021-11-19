using System;
using System.Linq;
using static System.Console;

namespace LinqWithArrayOfStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            LinqWithArrayOfStrings();
        }

        static void LinqWithArrayOfStrings()
        {
            var names = new string[] { "Michael", "Pam", "Jim", "Dwight", "Angela", "Kevin", "Toby", "Creed" };
            //var query = names.Where(new Func<string, bool>(NameLongerThanFour));
            //var query = names.Where(name => name.Length > 4).OrderBy(name => name.Length).ThenBy(t => t);
            var query = from name in names
                        where name.Length > 4
                        orderby name.Length, name
                        select name;
            foreach (string item in query)
            {
                WriteLine(item);
            }
        }

        static bool NameLongerThanFour(string name)
        {
            return name.Length > 4;
        }
    }
}
