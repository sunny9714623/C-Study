using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;

namespace Packt.Shared
{
    public class Person : Object
    {
        // fields
        public string Name;
        public DateTime DateOfBirth;
        public WondersOfTheAncientWord BucketList;
        public const string Species = "Home Sapien";
        public readonly string HomePlanet = "Earth";
        public readonly DateTime Instantiated;
        public List<Person> Children = new List<Person>();
        public Person()
        {
            Name = "Unknown";
            Instantiated = DateTime.Now;
        }
        public Person(string initialName,string homePlanet)
        {
            Name = initialName;
            HomePlanet = homePlanet;
            Instantiated = DateTime.Now;
        }
        public void WriteToConsole()
        {
            WriteLine($"{Name} was born on a {DateOfBirth:dddd}.");
        }
        public string GetOrigin()
        {
            return $"{Name} was born on {HomePlanet} .";
        }
        public (string,int) GetFruit()
        {
            return ("Apples", 5);
        }
        public (string Name, int Number) GetNameFruit()
        {
            return (Name: "Apples", Number: 5);
        }
    }
    public class BankAccount
    {
        public string AccountName;//instance member
        public decimal Balance;//instance member
        public static decimal InterestRate;
    }
}


