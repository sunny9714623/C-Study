using System;
using Packt.Shared;
using static System.Console;

namespace PeopleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var bob = new Person();
            bob.Name = "Bob Smith";
            bob.DateOfBirth = new DateTime(1965, 12, 22);
            bob.BucketList = WondersOfTheAncientWord.HangingGardensOfBabylon|WondersOfTheAncientWord.MausoleumAtHalicarnassus;
            bob.Children.Add(new Person { Name = "Alfred" });
            bob.Children.Add(new Person { Name="zoe"});
            bob.WriteToConsole();
            (string fruitName,int fruitNumber) = bob.GetNameFruit();
            WriteLine($"Deconstructed:{fruitName},{fruitNumber}");
            WriteLine("-----------");
            (string, int) fruit = bob.GetFruit();
            WriteLine($"{fruit.Item1},{fruit.Item2} there are");
            WriteLine("--------------------------------");
            WriteLine($"{bob.Name} has {bob.Children.Count} childred,is a {Person.Species}");
            WriteLine($"{bob.Name} was born on {bob.HomePlanet}");
            //for(int child = 0; child < bob.Children.Count; child++)
            //{
            //    WriteLine($"{bob.Children[child].Name}");
            //}
            foreach(var child in bob.Children)
            {
                WriteLine($"{child.Name}");
            }
            WriteLine($"{bob.Name}'s bucket list is {bob.BucketList}");
            WriteLine(format: "{0} was born on {1:dddd, d MMMM yyyy}",arg0:bob.Name,arg1:bob.DateOfBirth);
            var alice = new Person()
            {
                Name = "Alice Jones",
                DateOfBirth = new DateTime(1998, 3, 7)
            };
            WriteLine(format:"{0} was born on {1:dd MM yy}",arg0:alice.Name,arg1:alice.DateOfBirth);

            BankAccount.InterestRate = 0.012M;//store a shared value
            var jonesAccount = new BankAccount();
            jonesAccount.AccountName = "Mrs. Jones";
            jonesAccount.Balance = 2400;
            WriteLine(format: "{0} earned {1:C} interest.", arg0: jonesAccount.AccountName, arg1: jonesAccount.Balance * BankAccount.InterestRate);
            var gerrierAccount = new BankAccount();
            gerrierAccount.AccountName = "Ms. Gerrier";
            gerrierAccount.Balance = 98;
            WriteLine(format: "{0} earned {1:C} interest.", arg0: gerrierAccount.AccountName, arg1: gerrierAccount.Balance * BankAccount.InterestRate);
            var blankPerson = new Person();
            WriteLine(format: "{0} of {1} was created at {2:hh:mm:ss} on a {2:dddd}.",
                arg0: blankPerson.Name,
                arg1: blankPerson.HomePlanet,
                arg2: blankPerson.Instantiated);

            var gunny = new Person("Gunny", "Mars");
            WriteLine(format:"{0} of {1} was created at {2:hh:mm:ss} on a {2:dddd}.",
                arg0:gunny.Name,
                arg1:gunny.HomePlanet,
                arg2:gunny.Instantiated);
            WriteLine("*****************");
            var thing1 = ("Neville", 4);
            WriteLine($"{thing1.Item1} has {thing1.Item2} children");

            var thing2 = (bob.Name,bob.Children.Count);
            WriteLine($"{thing2.Name} has {thing2.Count} children");
        }
    }
}
