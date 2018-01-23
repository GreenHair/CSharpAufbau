using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace XmlWriterWithNamespaces
{
    class Program
    {
        static void Main(string[] args)
        {
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.IndentChars = "  "; // 2 Leerzeichen
            XmlWriter writer = XmlWriter.Create(@"D:\Personen.xml", settings);
            writer.WriteStartDocument();

            // Starttag des Stammelements
            writer.WriteStartElement("x", "Personen", "http://www.MyNS.de");
            writer.WriteAttributeString("xmlns", "http://www.MyDefaultNS.de");

            // Starttag von 'Person'
            writer.WriteStartElement("x", "Person", "http://www.MyNS.de");
            writer.WriteElementString("x", "Zuname", "http://www.MyNS.de", "Kleynen");
            string prefix = writer.LookupPrefix("http://www.MyNS.de");
            writer.WriteElementString(prefix, "Vorname", "http://www.MyNS.de", "Peter");

            // Element mit Attributen
            writer.WriteStartElement("Adresse");
            writer.WriteAttributeString("Ort", "Eifel");
            writer.WriteAttributeString("Strasse", "Am Wald 1");
            writer.WriteValue("Germany");
            writer.WriteEndElement();

            // Endtag von 'Person'
            writer.WriteEndElement();

            // Endtag des Stammelements
            writer.WriteEndElement();
            writer.WriteEndDocument();
            writer.Close();
            Console.WriteLine(@"Datei D:\Personen.xml erzeugt.");
            Console.ReadLine();

        }

    }
}
