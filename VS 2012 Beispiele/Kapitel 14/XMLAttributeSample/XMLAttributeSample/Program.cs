using System;
using System.Xml.Serialization;
using System.IO;

namespace XMLAttributeSample
{
    class Program
    {
        static void Main(string[] args)
        {
            PersonenListe catalog = new PersonenListe("Teilnehmerliste");
            catalog.Listenname = "Teilnehmerliste";
            Person[] persons = new Person[2];
            // Personen erzeugen
            persons[0] = new Person("Peter", "Berlin", 45, "117");
            persons[1] = new Person();
            persons[1].Zuname = "Franz-Josef";
            persons[1].Ort = "Aschaffenburg";
            catalog.Personen = persons;
            // serialisieren
            XmlSerializer serializer = new XmlSerializer(typeof(PersonenListe));
            FileStream fs = new FileStream("Personenliste.xml", FileMode.Create);
            serializer.Serialize(fs, catalog);
            fs.Close();
            catalog = null;
            // deserialisieren
            fs = new FileStream("Personenliste.xml", FileMode.Open);
            catalog = (PersonenListe)serializer.Deserialize(fs);
            serializer.Serialize(Console.Out, catalog);
            Console.ReadLine();
        }
    }


    [XmlRoot("PersonenListe")]
    public class PersonenListe
    {
        [XmlElement("Listenbezeichner")]
        public string Listenname;

        [XmlArray("PersonenArray")]
        [XmlArrayItem("PersonObjekt")]
        public Person[] Personen;

        // Konstruktoren
        public PersonenListe() { }

        public PersonenListe(string name)
        {
            this.Listenname = name;
        }
    }



    public class Person
    {
        [XmlElement("Name")]
        public string Zuname;

        [XmlElement("Wohnort")]
        public string Ort;

        [XmlElement("Alter")]
        public int Lebensalter;

        [XmlAttribute("PersID", DataType = "string")]
        public string ID;

        // Konstruktoren
        public Person() { }

        public Person(string zuname, string ort, int alter, string id)
        {
            this.Zuname = zuname;
            this.Ort = ort;
            this.Lebensalter = alter;
            this.ID = id;
        }
    }

}
