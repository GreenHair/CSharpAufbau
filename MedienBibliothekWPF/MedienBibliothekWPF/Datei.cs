using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using MedienBibliothekWPF;

namespace MedienBibliothek
{
    public class Datei
    {
        static FileStream stream;
        static BinaryFormatter binFormatter;
        public static string pfad = @"D:\CSharp Aufbau\MedienBibliothekWPF\MedienBibliothekWPF\bestand.dat";

        public static void Speichern(List<Medien> bestandsliste)
        {
            stream = new FileStream(pfad, FileMode.Create);
            binFormatter = new BinaryFormatter();
            binFormatter.Serialize(stream, bestandsliste);
            stream.Close();
        }

        public static List<Medien> Laden()
        {
            List<Medien> temp = null;
            try
            {
                stream = new FileStream(pfad, FileMode.Open);
            }
            catch (IOException e)
            {
                MessageBox.Show(e.Message);
            }
            try
            {
                binFormatter = new BinaryFormatter();            
                temp = (List<Medien>)binFormatter.Deserialize(stream);
                stream.Close();
            }
            catch (SerializationException e)
            {
                MessageBox.Show(e.Message);
            }

            return temp;
        }
    }
}
