using PacktLibrary.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;

namespace Packt.Shared
{
    public partial class Person
    {
        public string Origin
        {
            get
            {
                return $"{Name} was born on {HomePlanet}";
            }
        }
        public string Greeting => $"{Name} says 'Hello!'";
        public int Age => System.DateTime.Today.Year - DateOfBirth.Year;
        public string FavoriteIceCream { get; set; }
        private string favoritePrimaryColor;
        public string FavoritePrimaryColor
        {
            get
            {
                return favoritePrimaryColor;
            }
            set
            {
                switch (value.ToLower())
                {
                    case "red":
                    case "green":
                    case "blue":
                        favoritePrimaryColor = value;
                        break;
                    default:
                        throw new System.ArgumentException($"{value} is not a primary color."+"Choose from: red, green, blue");
                }
            }
        }
        public Person this[int index]
        {
            get
            {
                return Children[index];
            }
            set
            {
                Children[index] = value;
            }
        }
        //Event delegate field
        public event EventHandler Shout;

        //data field
        public int AngerLevel;
        public void Poke()
        {
            AngerLevel++;
            if (AngerLevel >= 3)
            {
                //if something is listening
                //if (Shout != null)
                //{
                //    //then call the delegate
                //    Shout(this,EventArgs.Empty);
                //}
                Shout?.Invoke(this, EventArgs.Empty);
            }
        }
        public void WriteToConsole()
        {
            Console.WriteLine($"{Name} was born on a {DateOfBirth:dd/yyyy/}");
        }
        public override string ToString()
        {
            return $"{Name} is a {base.ToString()}";
        }
        public void TimeTravel(DateTime when)
        {
            if(when <= DateOfBirth)
            {
                throw new PersonException("If you travel back in time to a date earlier than your own birth, when the universe will explode!");
            }
            else
            {
                WriteLine($"Welcome to {when:yyyy}!");
            }
        }
    }
}
