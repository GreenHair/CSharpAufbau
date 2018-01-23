using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.XPath;

namespace XPathNavigatorSample
{
    class Program
    {
        static void Main(string[] args)
        {
            XPathDocument doc = new XPathDocument(@"..\..\Personen.xml");
            XPathNavigator navi = doc.CreateNavigator();
            // Zum Stammknoten navigieren
            navi.MoveToRoot();
            Navigate(navi);
            Console.ReadLine();
        }


        // Methode, die durch die Knoten navigiert
        static void Navigate(XPathNavigator navi)
        {
            WriteNode(navi);
            // verschiebt den Cursor auf den ersten untergeordneten Knoten 
            if (navi.MoveToFirstChild())
            {
                // verschiebt den Cursor zum nächsten nebengeordneten Knoten
                do
                {
                    Navigate(navi);
                } while (navi.MoveToNext());
                navi.MoveToParent();
            }
        }


        // Methode zur Ausgabe an der Konsole
        static void WriteNode(XPathNavigator navi)
        {
            switch (navi.NodeType)
            {
                case XPathNodeType.Element:
                    if (navi.HasAttributes)
                    {
                        Console.Write("<" + navi.Name + " ");
                        navi.MoveToFirstAttribute();
                        do
                        {
                            Console.Write(navi.Name + "=" + navi.Value + " ");
                        } while (navi.MoveToNextAttribute());
                        Console.WriteLine(">");
                        navi.MoveToParent();
                    }
                    else
                    {
                        Console.WriteLine("<" + navi.Name + ">");
                    }
                    break;
                case XPathNodeType.Text:
                    Console.WriteLine(navi.Value);
                    break;
            }
        }

    }
 
}
