using System;
using Packt.Shared;
using static System.Console;

namespace demo
{
    class Program
    {
        static void Main(string[] args)
        {
            var sam = new Person()
            {
                Name = "Sam",
                HomePlanet = "Planet",
                DateOfBirth = new DateTime(1972, 1, 27)
            };
            sam.FavoriteIceCream = "Chocolate Fudge";
            WriteLine($"Sam's favorite ice-cream flavor is {sam.FavoriteIceCream}");
            sam.FavoritePrimaryColor = "Red";
            WriteLine($"Sam's favorite primary color is {sam.FavoritePrimaryColor}.");
            sam.Children = new System.Collections.Generic.List<Person>();
            sam.Children.Add(new Person { Name = "Charlie" });
            sam.Children.Add(new Person { Name = "Ella" });
            WriteLine($"Sam's first child is {sam.Children[0].Name}");
            WriteLine($"Sam's second child is {sam.Children[1].Name}");
            WriteLine($"Sam's first child is {sam[0].Name}");
            WriteLine($"Sam's second child is {sam[1].Name}");
            WriteLine(sam.Origin);
            WriteLine(sam.Greeting);
            WriteLine(sam.Age);
        }
    }
}
