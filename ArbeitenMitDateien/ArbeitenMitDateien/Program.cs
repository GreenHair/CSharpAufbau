using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ArbeitenMitDateien
{
    class Program
    {
        static void Main(string[] args)
        {
            //FileStream stream = File.Open(@"D:\myText.txt", FileMode.Open, FileAccess.ReadWrite, FileShare.None);
            //stream.Close();

            //DirectoryInfo meinVerzeichnis = new DirectoryInfo(@"D:\verzeichnis");
            Program verzeichnistest = new Program();
            FileInfo meineDatei;

            //Benutzereingabe
            string pfad = verzeichnistest.Pfadeingabe();
            int laenge = pfad.Length;

            if (Directory.Exists(pfad))
            {
                string[] inhalt = Directory.GetFileSystemEntries(pfad);
                Console.WriteLine();
                Console.WriteLine("Ordner und Dateien im Verzeichnis {0}", pfad);
                Console.WriteLine(new string('-', 80));
                for(int i = 0; i <= inhalt.GetUpperBound(0); i++)
                {
                    //prüfen ob der eintrarg ein verzeichnis oder eine datei ist
                    if (0 == (File.GetAttributes(inhalt[i]) & FileAttributes.Directory))
                    {                    
                        meineDatei = new FileInfo(inhalt[i]);
                        string dateiAttribut = verzeichnistest.HoleDateiAttribute(meineDatei);
                        Console.WriteLine("{0,-30}{1,25}kB  {2,-10}", inhalt[i].Substring(laenge - 1), meineDatei.Length / 1024, dateiAttribut);
                    }
                    else
                    {
                        Console.WriteLine("{0,-30}{1,-15}", inhalt[i].Substring(laenge), "Dateiorder");
                    }
                }
            }
            Console.ReadLine();
        }

        string Pfadeingabe()
        {
            Console.WriteLine("Geben Sie den zu durchsuchenden Ordner an: ");
            string suchMuster = Console.ReadLine();

            //Wenn die Benutzereingabe als letztes Zeichen kein '\' enthält muss dieses angehängt werden
            if (suchMuster.Substring(suchMuster.Length - 1) != "\\")
            {
                suchMuster += "\\";
            }
            return suchMuster;
        }

        //Feststellung welche dateiattribute gesetzt sind
        string HoleDateiAttribute(FileInfo file)
        {
            string attribute;
            if(0!=(file.Attributes & FileAttributes.Archive))
            {
                attribute = "A ";
            }
            else
            {
                attribute = "  ";
            }
            if (0 != (file.Attributes & FileAttributes.Hidden))
            {
                attribute += "H ";
            }
            else
            {
                attribute += "  ";
            }
            if (0 != (file.Attributes & FileAttributes.ReadOnly))
            {
                attribute += "R ";
            }
            else
            {
                attribute += "  ";
            }
            return attribute;
        }
    }
}
