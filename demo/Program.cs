using System;
using Packt.Shared;
using static System.Console;

namespace demo
{
    class Program
    {
        static void Main(string[] args)
        {
            //var sam = new Person()
            //{
            //    Name = "Sam",
            //    HomePlanet = "Planet",
            //    DateOfBirth = new DateTime(1972, 1, 27)
            //};
            //sam.FavoriteIceCream = "Chocolate Fudge";
            //WriteLine($"Sam's favorite ice-cream flavor is {sam.FavoriteIceCream}");
            //sam.FavoritePrimaryColor = "Red";
            //WriteLine($"Sam's favorite primary color is {sam.FavoritePrimaryColor}.");
            //sam.Children = new System.Collections.Generic.List<Person>();
            //sam.Children.Add(new Person { Name = "Charlie" });
            //sam.Children.Add(new Person { Name = "Ella" });
            //WriteLine($"Sam's first child is {sam.Children[0].Name}");
            //WriteLine($"Sam's second child is {sam.Children[1].Name}");
            //WriteLine($"Sam's first child is {sam[0].Name}");
            //WriteLine($"Sam's second child is {sam[1].Name}");
            //WriteLine(sam.Origin);
            //WriteLine(sam.Greeting);
            //WriteLine(sam.Age);
            //var harry = new Person { Name = "Harry" };
            //harry.Shout += Harry_Shout;
            //harry.Poke();
            //harry.Poke();
            //harry.Poke();
            //harry.Poke();

            Person[] people =
            {
                new Person{Name="Simon"},
                new Person{Name="Jenny"},
                new Person{Name="Adam"},
                new Person{Name="Richard"}
            };
            WriteLine("Initial list of People:");
            foreach(var person in people)
            {
                WriteLine($"{person.Name}");
            }
            WriteLine("Use Person's IComparable implementation to sort:");
            Array.Sort(people);
            foreach(var person in people)
            {
                WriteLine($"{person.Name}");
            }
        }
        private static void Harry_Shout(object sender,EventArgs e)
        {
            Person p = (Person)sender;
            WriteLine($"{p.Name} is this angry: {p.AngerLevel}");
        }
    }
}
