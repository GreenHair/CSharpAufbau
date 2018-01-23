using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace BinärStreamDatei
{
    class Program
    {
        static void Main(string[] args)
        {
            // eine Datei erzeugen und einen int Wert in die Datei schreiben
            FileStream stream = new FileStream(@"D:\CSharp Aufbau\bindatei.dat", FileMode.Create);
            BinaryWriter writer = new BinaryWriter(stream);
            int zahl = 500;
            writer.Write(zahl);
            writer.Close();

            // Datei öffnen und den Inhalt Byteweise auslesen
            FileInfo fi = new FileInfo(@"D:\CSharp Aufbau\bindatei.dat");
            FileStream fs = new FileStream(@"D:\CSharp Aufbau\bindatei.dat", FileMode.Open);
            byte[] byteArr = new byte[fi.Length];
            fs.Read(byteArr, 0, (int)fi.Length);

            Console.WriteLine("Interpretation als byte-array");
        }
    }
}
