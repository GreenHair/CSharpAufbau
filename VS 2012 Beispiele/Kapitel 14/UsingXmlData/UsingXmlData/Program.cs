using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace UsingXmlData
{
    class Program
    {
        static void Main(string[] args)
        {
            XmlReader reader;
            reader = XmlReader.Create(@"..\..\Personen.xml");
            List<Person> liste = new List<Person>();
            Person person = null;
            Adresse adresse = null;
            while (reader.Read())
            {
                // prüfen, ob es sich aktuell um ein element handelt
                if (reader.NodeType == XmlNodeType.Element)
                {
                    // Alle relevanten Elemente untersuchen
                    switch (reader.Name)
                    {
                        case "Person":
                            // Neue Person erzeugen und in Liste eintragen
                            person = new Person();
                            liste.Add(person);
                            break;
                        case "Vorname":
                            person.Vorname = reader.ReadString();
                            break;
                        case "Zuname":
                            person.Zuname = reader.ReadString();
                            break;
                        case "Alter":
                            person.Alter = reader.ReadElementContentAsInt();
                            break;
                        case "Adresse":
                            // Neue Adresse erzeugen und der Person zuordnen
                            adresse = new Adresse();
                            person.Adresse = adresse;
                            if (reader.HasAttributes)
                            {
                                // Attributsliste durchlaufen
                                while (reader.MoveToNextAttribute())
                                {
                                    if (reader.Name == "Ort")
                                        adresse.Ort = reader.Value;
                                    else if (reader.Name == "Strasse")
                                        adresse.Strasse = reader.Value;
                                }
                            }
                            break;
                    }
                }
            }
            // Liste an der Konsole ausgeben
            GetList(liste);
            reader.Close();
            Console.ReadLine();
        }


        // Ausgabe der Listeneinträge
        static void GetList(List<Person> liste)
        {
            foreach (Person temp in liste)
            {
                Console.WriteLine("Vorname: {0}\nZuname: {1}\nAlter: {2}",
                        temp.Vorname, temp.Zuname, temp.Alter);
                Console.WriteLine("Ort: {0}\nStrasse: {1}\n",
                        temp.Adresse.Ort, temp.Adresse.Strasse);
            }
        }

    }

    // Klassendefinitionen
    class Person
    {
        public string Vorname { get; set; }
        public string Zuname { get; set; }
        public int Alter { get; set; }
        public Adresse Adresse { get; set; }
    }

    class Adresse
    {
        public string Ort { get; set; }
        public string Strasse { get; set; }
    }
}
