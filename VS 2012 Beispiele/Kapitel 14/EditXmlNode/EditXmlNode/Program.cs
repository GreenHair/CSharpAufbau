using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace EditXmlNode
{
    class Program
    {
        static void Main(string[] args) {
            XmlDocument doc = new XmlDocument();
            doc.Load(@"..\..\Personen.xml");
            XmlNode root = doc.DocumentElement;

            // Referenz auf das zu ändernde Element besorgen
            XmlNode node = root.SelectSingleNode("//Person[Zuname ='Meier']/Alter");
            if (node != null)
            {
                XmlNode nodeAlter = node.FirstChild;
                // Das Alter ändern
                nodeAlter.Value = "33";
                XmlNode parent = node.ParentNode;
                GetNodes(parent, 0);
                Console.ReadLine();
                return;
            }
            else
            {
                Console.WriteLine("Der angegebene Zuname existiert nicht.");
                Console.ReadLine();
            }
        } 

        static void GetNodes(XmlNode node, int level) {
            switch (node.NodeType) {
                // Prüfen, ob es sich um ein Element handelt
                case XmlNodeType.Element:
                    Console.Write(new string(' ', level * 2));
                    Console.Write("<{0}>", node.Name);
                    if (node.HasChildNodes)
                        foreach (XmlNode child in node.ChildNodes) {
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
