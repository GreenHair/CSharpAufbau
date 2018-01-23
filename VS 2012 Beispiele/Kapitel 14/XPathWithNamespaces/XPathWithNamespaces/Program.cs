using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.XPath;

namespace XPathWithNamespaces
{
    class Program
    {
        static void Main(string[] args)
        {
            XPathDocument xPathDoc = new XPathDocument(@"..\..\Personen.xml");
            XPathNavigator navigator = xPathDoc.CreateNavigator();

            // XmlNamespaceManager instanziieren
            XmlNamespaceManager mgr =
                        new XmlNamespaceManager(new NameTable());
            navigator.MoveToRoot();
            if (navigator.MoveToChild(XPathNodeType.Element))
            {
                foreach (KeyValuePair<string, string> temp in
                    navigator.GetNamespacesInScope(XmlNamespaceScope.All))
                    // Namespaces zum XmlNamespaceManager hinzufügen
                    if (temp.Key == "")
                        mgr.AddNamespace("default", temp.Value);
                    else
                        mgr.AddNamespace(temp.Key, temp.Value);
            }
            // Ausgabe aller Person-Elemente, die dem durch 'x'  
            // beschriebenen Namespace zugeordnet werden
            XPathNodeIterator iterator = navigator.Select("//x:Person", mgr);
            while (iterator.MoveNext())
            {
                Console.WriteLine(iterator.Current.Value);
            }
            Console.ReadLine();
        }

    }
}
