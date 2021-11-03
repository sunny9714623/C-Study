using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
namespace Exercise02
{
    [XmlInclude(typeof(Circle))]
    [XmlInclude(typeof(Rectangle))]
    public abstract class Shape
    {
        public string Color { get; set; }
        public abstract double Area { get; }
    }
    public class Circle : Shape
    {
        public double Radius { get; set; }
        public override double Area { get { return Math.PI * Radius * Radius; } }
    }
    public class Rectangle : Shape
    {
        public double Height { get; set; }
        public double Width { get; set; }
        public override double Area => Height * Width;
    }
}
