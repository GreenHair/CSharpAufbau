using System;
using System;
using System.Xml;

namespace ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            XmlReader reader = XmlReader.Create(@"..\..\Lieferung.xml");

            while (reader.Read())
            {
                switch (reader.NodeType)
                {
                    case XmlNodeType.Element:
                        Console.WriteLine("{0,-30}{1}", "<" + reader.Name + ">", reader.NamespaceURI);
                        if (reader.HasAttributes)
                        {
                            for (int i = 0; i < reader.AttributeCount; i++)
                            {
                                while (reader.MoveToNextAttribute())
                                {
                                    Console.WriteLine("  {0,-28}{1}", reader.Name, reader.NamespaceURI);
                                }
                            }
                        }
                        break;
                    case XmlNodeType.EndElement:
                        Console.WriteLine("{0,-30}{1}", "</" + reader.Name + ">", reader.NamespaceURI);
                        break;
                }
            }
            Console.ReadLine();
        }
    }
}