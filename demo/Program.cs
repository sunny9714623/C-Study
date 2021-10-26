using System;
using demo.Extensions;
using Packt.Shared;
using PacktLibrary.Exceptions;
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

            //Person[] people =
            //{
            //    new Person{Name="Simon"},
            //    new Person{Name="Jenny"},
            //    new Person{Name="Adam"},
            //    new Person{Name="Richard"}
            //};
            //WriteLine("Initial list of People:");
            //foreach(var person in people)
            //{
            //    WriteLine($"{person.Name}");
            //}
            //WriteLine("Use Person's IComparable implementation to sort:");
            //Array.Sort(people);
            //foreach(var person in people)
            //{
            //    WriteLine($"{person.Name}");
            //}
            //WriteLine("Use PersonComparer's IComparer implementation to sort:");
            //Array.Sort(people,new PersonComparer());
            //foreach (var person in people)
            //{
            //    WriteLine($"{person.Name}");
            //}
            //WriteLine("@@@@@@@@@@@@@@@@@");
            //IPlayable dvd = new DvdPlayer();
            //dvd.Pause();
            //dvd.Stop();

            //WriteLine("------------------");
            //var t1 = new Thing();
            //t1.Data = 42;
            //WriteLine($"Thing with an integer:{t1.Process(42)}");
            //var t2 = new Thing();
            //t2.Data = "apple";
            //WriteLine($"Thing with a stirng:{t2.Process("apple")}");
            //var gt1 = new GenericThing<int>();
            //gt1.Data = 42;
            //WriteLine($"GenericThing with an integer:{gt1.Process(42)}");
            //var gt2 = new GenericThing<string>();
            //gt2.Data = "apple";
            //WriteLine($"GenericThing with an string:{gt2.Process("apple")}");

            //string number1 = "4";
            //WriteLine("{0} squared is {1}",arg0:number1,arg1:Squarer.Square<string>(number1));

            //byte number2 = 3;


            //WriteLine("{0} squared is {1}", arg0: number2, arg1: Squarer.Square(number2));

            var dv1 = new DisplaeementVector(3, 5);
            var dv2 = new DisplaeementVector(-2, 7);
            var dv3 = dv1 + dv2;
            WriteLine($"({dv1.X},{dv2.X})+({dv1.Y},{dv2.Y})=({dv3.X},{dv3.Y})");

            Employee john = new Employee
            {
                Name = "John Jones",
                DateOfBirth = new DateTime(1990, 7, 28)
            };
            john.EmployeeCode = "JJ001";
            john.HireDate = new DateTime(2014, 11, 23);
            WriteLine($"{john.Name} was hired on {john.HireDate:dd/MM/yy}");
            john.WriteToConsole();
            WriteLine(john.ToString());
            Employee aliceInEmployee = new Employee { Name = "Alice", EmployeeCode = "AA123", DateOfBirth = new DateTime(1999, 3, 17) };
            Person aliceInPerson = aliceInEmployee;
            WriteLine("-----------------------");
            aliceInEmployee.WriteToConsole();
            aliceInPerson.WriteToConsole();
            //Employee explicitAlice = (Employee)aliceInPerson;
            if(aliceInPerson is Employee)
            {
                WriteLine($"{nameof(aliceInPerson)} IS an Employee");
                Employee explicitALice = (Employee)aliceInPerson;
            }
            WriteLine(aliceInEmployee.ToString());
            WriteLine(aliceInPerson.ToString());
            Employee aliceAsEmployee = aliceInPerson as Employee;
            if (aliceAsEmployee != null)
            {
                WriteLine($"{nameof(aliceInPerson)} AS an Employe");
                // do something with aliceAsEmployee
            }
            try
            {
                john.TimeTravel(new DateTime(1999, 12, 31));
                john.TimeTravel(new DateTime(1950, 12, 25));
            }
            catch(PersonException ex)
            {
                WriteLine(ex.Message);
            }
            string email1 = "pamela@test.com";
            string email2 = "ian&test.com";
            WriteLine("{0} is a valid e-mail address : {1}",
                arg0: email1,
                arg1: StringExtensions.IsValidEmail(email1));
            WriteLine("{0} is a valid e-mail address : {1}",
                arg0: email2,
                arg1: StringExtensions.IsValidEmail(email2));
            WriteLine("{0} is a valid e-mail address : {1}",
                arg0: email1,
                arg1: email1.IsValidEmail());
            WriteLine("{0} is a valid e-mail address : {1}",
                arg0: email2,
                arg1: email2.IsValidEmail());
        }
        private static void Harry_Shout(object sender,EventArgs e)
        {
            Person p = (Person)sender;
            WriteLine($"{p.Name} is this angry: {p.AngerLevel}");
        }
    }
}
