﻿using System;
using System.IO;
using System.Xml.Serialization;
using System.Collections.Generic;
using static System.IO.Path;
using static System.Environment;
using static System.Console;

namespace Exercise02
{
    class Program
    {
        static void Main(string[] args)
        {
            // create a list of Shapes
            var listOfShapes = new List<Shape>
            {
                new Circle{Color="Red",Radius=2.5},
                new Rectangle{Color="Blue",Height=20.0,Width=10.0},
                new Circle{Color="Green",Radius=8.0},
                new Circle{Color="Purple",Radius=12.3},
                new Rectangle{Color="Blue",Height=45.0,Width=18.0}
            };
            var serializerXml = new XmlSerializer(typeof(List<Shape>));
            string filePath = Path.Combine(CurrentDirectory, "shape.xml");
            using(FileStream stream = File.Create(filePath))
            {
                serializerXml.Serialize(stream, listOfShapes);
            }
            WriteLine("Written {0:N0} bytes of XML to {1}", new FileInfo(filePath).Length, filePath);
            WriteLine();

            // display the serialized object graph
            WriteLine(File.ReadAllText(filePath));
            using (FileStream fileXml = File.Open(filePath, FileMode.Open))
            {
                List<Shape> loadedShapesXml = serializerXml.Deserialize(fileXml) as List<Shape>;
                foreach(Shape item in loadedShapesXml)
                {
                    WriteLine("{0} is {1} and has an area of {2:N2}", item.GetType().Name, item.Color, item.Area);
                }
            }
        }
    }
}
