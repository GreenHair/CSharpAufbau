using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace XmlWriterSample
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
            writer.WriteStartElement("Personen");
            writer.WriteComment("Die Datei wurde mit XmlWriter erzeugt");
            
            // Starttag von 'Person'
            writer.WriteStartElement("Person");
            writer.WriteElementString("Zuname", "Kleynen");
            writer.WriteElementString("Vorname", "Peter");
            
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
