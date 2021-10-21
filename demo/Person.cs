using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Packt.Shared
{
    public partial class Person : IComparable<Person>
    {
        public string Name;
        public string HomePlanet="Earth";
        public List<Person> Children;
        public DateTime DateOfBirth;

        public int CompareTo([AllowNull] Person other)
        {
            return Name.CompareTo(other.Name);
        }
    }
}
