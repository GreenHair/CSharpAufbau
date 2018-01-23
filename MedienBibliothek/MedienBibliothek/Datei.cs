using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace MedienBibliothek
{
    public class Datei
    {
        static FileStream stream;
        static BinaryFormatter binFormatter;

        public static void Speichern(List<Medien> bestandsliste)
        {
            stream = new FileStream(@"D:\CSharp Aufbau\MedienBibliothek\MedienBibliothek\bestand.dat", FileMode.Create);
            binFormatter = new BinaryFormatter();
            binFormatter.Serialize(stream, bestandsliste);
            stream.Close();
        }

        public static List<Medien> Laden()
        {
            List<Medien> temp;
            stream = new FileStream(@"D:\CSharp Aufbau\MedienBibliothek\MedienBibliothek\bestand.dat", FileMode.Open);
            binFormatter = new BinaryFormatter();
            temp = (List<Medien>)binFormatter.Deserialize(stream);
            return temp;
        }
    }
}
