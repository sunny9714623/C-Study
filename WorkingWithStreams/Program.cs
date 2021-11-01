using System;
using System.IO;
using System.Xml;
using System.IO.Compression;
using static System.Console;
using static System.Environment;
using static System.IO.Path;

namespace WorkingWithStreams
{
    class Program
    {
        static string[] callsigns = new string[] { "Husker", "Starbuck", "Apollo", "Boomer", "Bulldog", "Athena", "Helo", "RaceTrack" };
        static void WorkWithText()
        {
            string textFile = Combine(CurrentDirectory, "streams.txt");

            // create a text file and return a helper writer
            StreamWriter text = File.CreateText(textFile);
            foreach(string item in callsigns)
            {
                text.WriteLine(item);
            }
            text.Close();

            //output
            WriteLine("{0} contains {1:N0} bytes.", textFile, new FileInfo(textFile).Length);

            WriteLine(File.ReadAllText(textFile));
        }
        static void Main(string[] args)
        {
            //WorkWithText();
            //WorkWithXml();
            //WorkWithCompression();
            WorkWithCompression();
            WorkWithCompression(useBrotli: false);
            Console.ReadLine();
        }

        static void WorkWithXml()
        {
            FileStream xmlFileStream = null;
            XmlWriter xml = null;
            try
            {
                // a file to write to
                string xmlFile = Combine(CurrentDirectory, "streams.xml");

                // create a file stream
                xmlFileStream = File.Create(xmlFile);
                xml = XmlWriter.Create(xmlFileStream, new XmlWriterSettings { Indent = true });

                // write the XML declaration 
                xml.WriteStartDocument();
                // write a root element
                xml.WriteStartElement("callsigns");
                foreach (string item in callsigns)
                {
                    xml.WriteElementString("callsign", item);
                }

                xml.WriteEndElement();
                //close helper and stream
                xml.Close();
                xmlFileStream.Close();

                //output
                WriteLine("{0} contains {1:N0} bytes.", xmlFile, new FileInfo(xmlFile).Length);

                WriteLine(File.ReadAllText(xmlFile));
            }
            catch(Exception ex)
            {
                // if the path doesn't exist the exception will be caught
                WriteLine($"{ex.GetType()} says {ex.Message}");
            }
            finally
            {
                if (xml != null)
                {
                    xml.Dispose();
                    WriteLine("The XML writer's unmanaged resources have been disposed.");
                }
                if (xmlFileStream != null)
                {
                    xmlFileStream.Dispose();
                    WriteLine("The file stream's numanaged resources have been disposed.");
                }
            }
            //using (FileStream file2 = File.OpenWrite(Path.Combine(path1, "file2.txt")))
            //{
            //    using(StreamWriter writer2=new StreamWriter(file2))
            //    {
            //        try
            //        {
            //            writer2.WriteLine("Welcome, .Net Core!");
            //        }
            //        catch(Exception ex)
            //        {
            //            WriteLine($"{ex.GetType()} says {ex.Message}");
            //        }
            //    }//automatically calls Dispose if the object is not null
            //}
        }
        static void WorkWithCompression(bool useBrotli=true)
        {
            string fileExt = useBrotli ? "brotli" : "gzip";
            // compress the XMl output
            string filePath = Combine(CurrentDirectory, $"streams.{fileExt}");
            FileStream file = File.Create(filePath);
            Stream compressor;
            if (useBrotli)
            {
                compressor = new BrotliStream(file, CompressionMode.Compress);
            }
            else
            {
                compressor = new GZipStream(file, CompressionMode.Compress);
            }
            using(compressor)
            {
                using(XmlWriter xml = XmlWriter.Create(compressor))
                {
                    xml.WriteStartDocument();
                    xml.WriteStartElement("callsigns"); 
                    foreach(string item in callsigns)
                    {
                        xml.WriteElementString("callsign", item);
                    }
                    // the normal call to writeendelement is not necessary
                    //because when the XmlWriter disposes,it will automatically end any elements of any depth
                }
            }

            // output all the comtents of the compressed file
            WriteLine("{0} contains {1:N0} bytes.", filePath, new FileInfo(filePath).Length);

            WriteLine($"The compressed contents:");
            WriteLine(File.ReadAllText(filePath));

            //read a compressed file
            WriteLine("Reading the compressed XML file:");
            file = File.Open(filePath, FileMode.Open);
            Stream decompressor;
            if (useBrotli)
            {
                decompressor = new BrotliStream(file, CompressionMode.Decompress);
            }
            else
            {
                decompressor = new GZipStream(file, CompressionMode.Decompress);
            }
            using(decompressor)
            {
                using(XmlReader reader = XmlReader.Create(decompressor))
                {
                    while (reader.Read())
                    {
                        if (reader.NodeType == XmlNodeType.Element && reader.Name == "callsign")
                        {
                            reader.Read();//Move to the text inside element
                            WriteLine($"{reader.Value}");
                        }
                    }
                }
            }
        }
    }
}
