using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


namespace BinaryFormatterSample
{
    class Program
    {
        static BinaryFormatter formatter;
        static FileStream stream;

        static void Main(string[] args)
        {
            formatter = new BinaryFormatter();
            Person pers = new Person(67, "Fischer");
            SerializeObject(pers);
            Person oldPerson = DeserializeObject();
            Console.WriteLine("Ergebnis der Deserialisierung:");
            Console.WriteLine(oldPerson.Alter);
            Console.WriteLine(oldPerson.Name);
            Console.ReadLine();
        }


        // Objekt serialisieren  
        public static void SerializeObject(Object obj)
        {
            stream = new FileStream(@"D:\MyObject.dat", FileMode.Create);
            formatter.Serialize(stream, obj);
            stream.Close();
        }


        // Objekt deserialisieren
        public static Person DeserializeObject()
        {
            FileStream stream = new FileStream(@"D:\MyObject.dat", FileMode.Open);
            return (Person)formatter.Deserialize(stream);
        }
    }


    // binär serialisierbare klasse
    [Serializable()]
    class Person
    {
        private int _Alter;
        public string Name { get; set; }
        // Konstruktor
        public Person(int alter, string name)
        {
            Name = name;
            _Alter = alter;
        }
        public int Alter
        {
            get { return _Alter; }
        }
    }

}
