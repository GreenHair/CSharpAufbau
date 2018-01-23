﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.XPath;

namespace SelectSample
{
    class Program
    {
        static void Main(string[] args)
        {
            string trenner = new string('-', 45);
            XPathDocument doc = new XPathDocument("..\\..\\Personen.xml");
            XPathNavigator navigator = doc.CreateNavigator();
            navigator.MoveToChild("Personen", "");
            navigator.MoveToChild("Person", "");

            // Alle untergeordneten Elemente einer 'Person'
            XPathNodeIterator descendant =
            navigator.SelectDescendants("", "", false);
            Console.WriteLine("Alle untergeordneten Elemente von 'Person':");
            Console.WriteLine(trenner);
            while (descendant.MoveNext())
            {
                Console.WriteLine(descendant.Current.Name);
            }

            // Alle direkt untergeordneten Elemente einer 'Person'
            XPathNodeIterator children = navigator.SelectChildren("", "");
            Console.WriteLine("\nDirekt untergeordnete Elemente von 'Person':");
            Console.WriteLine(trenner);
            while (children.MoveNext())
            {
                Console.WriteLine(children.Current.Name);
            }

            // Die übergeordneten Elemente von 'Zuname'
            navigator.MoveToChild("Zuname", "");
            XPathNodeIterator ancestors = navigator.SelectAncestors("", "", false);
            Console.WriteLine("\nÜbergeordnete Elemente von 'Zuname':");
            Console.WriteLine(trenner);
            while (ancestors.MoveNext())
            {
                Console.WriteLine(ancestors.Current.Name);
            }
            Console.ReadLine();
        }

    }
}
