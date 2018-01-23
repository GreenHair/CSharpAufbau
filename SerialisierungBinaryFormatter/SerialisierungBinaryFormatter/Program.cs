using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace SerialisierungBinaryFormatter
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> plist = new List<Person>();
            Person pers = new Person("Fritz", 34);
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(@"D:\CSharp Aufbau\SerialisierungBinaryFormatter\SerialisierungBinaryFormatter\person.dat", FileMode.Create);
            formatter.Serialize(stream, pers);
            stream.Close();
        }
    }
}
