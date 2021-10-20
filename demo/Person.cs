using System;
using System.Collections.Generic;
using System.Text;

namespace Packt.Shared
{
    public partial class Person
    {
        public string Name;
        public string HomePlanet="Earth";
        public List<Person> Children;
        public DateTime DateOfBirth;
    }
}
