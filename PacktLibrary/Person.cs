using System;
using System.Collections.Generic;
using static System.Console;

namespace Packt.Shared
{
    public class Person : Object
    {
        public string Name;
        public DateTime DateOfBirth;
        public List<Person> Children = new List<Person>();
        public void WriteToConsole()
        {
            WriteLine($"{Name} was born on a {DateOfBirth:dddd}");
        }
        public static Person Procreate(Person p1,Person p2)
        {
            var baby = new Person
            {
                Name = $"Baby of {p1.Name} and {p2.Name}"
            };
            p1.Children.Add(baby);
            p2.Children.Add(baby);
            return baby;
        }
        public Person ProcreateWith(Person partner)
        {
            return Procreate(this, partner);
        }
        public static Person operator *(Person p1,Person p2)
        {
            return Person.Procreate(p1, p2);
        }
        public WondersOfTheAncientWord BucketList;
        public const string Species = "Home Sapien";
        public readonly string HomePlanet = "Earth";
        public readonly DateTime Instantiated;
        public Person()
        {
            Name = "Unknown";
            Instantiated = DateTime.Now;
        }
        public Person(string initialName, string homePlanet)
        {
            Name = initialName;
            HomePlanet = homePlanet;
            Instantiated = DateTime.Now;
        }
        public string GetOrigin()
        {
            return $"{Name} was born on {HomePlanet} .";
        }
        public (string, int) GetFruit()
        {
            return ("Apples", 5);
        }
        public (string Name, int Number) GetNameFruit()
        {
            return (Name: "Apples", Number: 5);
        }
        public static int Factorial(int number)
        {
            if (number < 0)
            {
                throw new ArgumentException($"{nameof(number)} cannot be less than zero");
            }
            return localFactorial(number);
            int localFactorial(int localNumber)
            {
                if (localNumber < 1) return 1;
                return localNumber * localFactorial(localNumber - 1);
            }
        }
        public int MethodIWantToCall(string input)
        {
            return input.Length;
        }
    }
    public class BankAccount
    {
        public string AccountName;//instance member
        public decimal Balance;//instance member
        public static decimal InterestRate;
    }
}
