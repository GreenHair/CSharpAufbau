using System;
using System.Xml.Linq;
using System.Collections.Generic;
using System.Linq;

namespace NavigationSamples
{
    class Program
    {
        static void Main(string[] args)
        {
            XElement root = XElement.Load(@"..\..\Personen.xml");

            // die Methode 'Element'
            XElement element = root.Element("Person");
            Console.WriteLine(" ---------- Methode 'Element' -----------");
            Console.WriteLine(element + "\n\n");

            // die Methode 'Elements'
            IEnumerable<XElement> elements = root.Elements("Person");
            Console.WriteLine(" ---------- Methode 'Elements' -----------");
            foreach (XElement item in elements)
                Console.WriteLine(item);
            Console.WriteLine("\n\n");

            // die Methode 'Attribute'
            XElement element1 = root.Element("Person");
            XElement address = element1.Element("Adresse");
            XAttribute attr = address.Attribute("Strasse");
            Console.WriteLine(" ---------- Methode 'Attribute' -----------");
            Console.WriteLine(attr + "\n\n");

            // die Methode 'Descendants'
            XElement element2 = root.Element("Person");
            IEnumerable<XElement> elements1 = element2.Descendants();
            Console.WriteLine(" ---------- Methode 'Descendants' -----------");
            foreach (XElement item in elements1)
                Console.WriteLine(item);
            Console.WriteLine("\n\n");

            // die Methode 'Ancestors'
            XElement person = root.Descendants("Name")
                      .Where(pers => (string)pers == "Meier")
                      .First();
            var elemts = person.Ancestors("Person");
            Console.WriteLine(" ---------- Methode 'Ancestors' -----------");
            foreach (var item in elemts.Elements())
                if (item.HasAttributes)
                {
                    foreach (var temp in item.Attributes())
                        Console.WriteLine((string)temp);
                }
                else
                    Console.WriteLine((string)item);
            Console.WriteLine("\n\n");

            Console.ReadLine();
        }
    }
}
