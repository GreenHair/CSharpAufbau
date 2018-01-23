using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace XmlNodeSample
{
    class Program
    {
        static void Main(string[] args)
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml("<Person><Name Zuname='Müller'><Alter>34</Alter>" +
                      "Peter</Name></Person>");
            XmlNode root = doc.DocumentElement;

            // Eigenschaft 'Name'
            Console.WriteLine("Name:");
            Console.WriteLine("{0}\n", root.Name);

            // Eigenschaft 'OuterXml'
            Console.WriteLine("OuterXml:");
            Console.WriteLine("{0}\n", root.OuterXml);

            // Eigenschaft 'InnerXml'
            Console.WriteLine("InnerXml:");
            Console.WriteLine("{0}\n", root.InnerXml);

            // Eigenschaft 'Value'
            Console.Write("Value:");
            if (root.Value == null)
                Console.WriteLine("  <leer>\n");
            else
                Console.WriteLine("\n{0}\n", root.Value);

            // Eigenschaft 'InnerText'
            Console.WriteLine("InnerText:");
            Console.WriteLine("{0}", root.InnerText);
            Console.ReadLine();
        }

    }
}
