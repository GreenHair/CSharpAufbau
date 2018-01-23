using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace XmlNodeNavigation
{
    class Program
    {
        static void Main(string[] args)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(@"..\..\Personen.xml");
            XmlNode root = doc.DocumentElement;
            GetNodes(root, 0);
            Console.ReadLine();
        }

        static void GetNodes(XmlNode node, int level)
        {
            switch (node.NodeType)
            {
                // Prüfen, ob es sich um ein Element handelt
                case XmlNodeType.Element:
                    Console.Write(new string(' ', level * 2));
                    Console.Write("<{0}", node.Name);
                    // Prüfen, ob das aktuelle Element Attribute hat
                    if (node.Attributes != null)
                    {
                        foreach (XmlAttribute attr in node.Attributes)
                            Console.Write(" {0}='{1}'", attr.Name, attr.Value);
                    }
                    Console.Write(">");
                    // Prüfen, ob das aktuelle Element untergeordnete
                    // Elemente hat
                    if (node.HasChildNodes)
                        foreach (XmlNode child in node.ChildNodes)
                        {
                            if (child.NodeType != XmlNodeType.Text)
                                Console.WriteLine();
                            GetNodes(child, level + 1);
                        }
                    break;
                // Prüfen, ob es sich um auswertbate Daten handelt
                case XmlNodeType.Text:
                    Console.Write(node.Value);
                    break;
            }
        }
    }
}
