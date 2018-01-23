using System;
using System.IO;
using System.Xml.Serialization;

namespace XMLSerialisierung
{

    class Program
    {
        static XmlSerializer serializer;
        static FileStream stream;
        static void Main(string[] args)
        {
            serializer = new XmlSerializer(typeof(Person));
            Person person = new Person("Jutta Speichel", 34);
            SerializeObject(person);
            Person oldPerson = DeserializeObject();
            Console.WriteLine("Name: " + oldPerson.Name);
            Console.WriteLine("Alter: " + oldPerson.Alter);
            Console.ReadLine();
        }

        // Objekt serialisieren
        public static void SerializeObject(object obj)
        {
            stream = new FileStream(@"D:\PersonData.xml", FileMode.Create);
            serializer.Serialize(stream, obj);
            stream.Close();
        }

        // Objekt deserialisieren
        public static Person DeserializeObject()
        {
            stream = new FileStream(@"D:\PersonData.xml", FileMode.Open);
            return (Person)serializer.Deserialize(stream);
        }
    }


    // Zu serialisierende Klasse
    public class Person
    {
        // Felder
        public int Alter { get; set; }
        private string _Name;

        // ----- Konstruktoren -----
        public Person() { }
        public Person(string name, int alter)
        {
            Name = name;
            Alter = alter;
        }

        // Eigenschaft
        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }
    }

}
