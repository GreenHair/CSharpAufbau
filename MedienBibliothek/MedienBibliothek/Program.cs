using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedienBibliothek
{
    class Program
    {
        static void Main(string[] args)
        {
            Bibliothek myLib = new Bibliothek();
            //myLib.Bestand.Add(new Buch("Harry Mulisch", "De Bezige Bij", "De Ontdekking van de Hemel", 1992));
            //myLib.Bestand.Add(new MusikCD("ACDC", "Back in Black", 1984));
            //myLib.Bestand.Add(new FilmDVD("Humpfrey Bogart", "Gone With The Wind", 1938));
            //myLib.Bestand.Add(new Zeitschrift("Windows, Prozessoren", 12, "c't", 2016));
            
            myLib.Bestand = Datei.Laden();
            do
            {
                Console.Clear();
                Anzeigen(myLib.Bestand);
                Console.WriteLine("Neues Objekt hinzufügen? (y/n)");
                if(Console.ReadLine() == "y")
                {
                    myLib.Hinzufuegen(ObjektHinzufuegen());
                }
                Console.WriteLine("Weiter? (y/n)");                
            } while (Console.ReadLine() == "y");
                        
            Datei.Speichern(myLib.Bestand);
        }

        static void Anzeigen(List<Medien> bestand)
        {
            var sortiert = from medium in bestand group medium by medium.GetType();
            foreach(var item in sortiert)
            {
                foreach(var element in item)
                {
                    Console.WriteLine(element.Anzeigen(element));
                }
            }            
        }        

        static Medien ObjektHinzufuegen()
        {            
            Medien objekt = null;
            Console.WriteLine("1.Buch");
            Console.WriteLine("2.CD");
            Console.WriteLine("3.DVD");
            Console.WriteLine("4.Zeitschtift");
            Console.Write("Was möchten Sie hinzufügen? ");
            switch (Console.ReadLine())
            {
                case "1":
                    objekt = NeuesBuch();
                    break;
                case "2":
                    objekt = NeueCD();
                    break;
                case "3":
                    objekt = NeueDVD();
                    break;
                case "4":
                    objekt = NeuesZeitschrift();
                    break;
            }
            return objekt;
        }

        private static Buch NeuesBuch()
        {
            Console.Write("Titel? ");
            string titel = Console.ReadLine();
            Console.Write("Autor? ");
            string autor = Console.ReadLine();
            Console.Write("Verlag? ");
            string verlag = Console.ReadLine();
            Console.Write("Jahr? ");
            int jahr = Convert.ToInt32(Console.ReadLine());
            return new Buch(autor, verlag, titel, jahr);
        }

        private static MusikCD NeueCD()
        {
            Console.Write("Titel? ");
            string titel = Console.ReadLine();
            Console.Write("Interpret? ");
            string interpret = Console.ReadLine();
            Console.Write("Jahr? ");
            int jahr = Convert.ToInt32(Console.ReadLine());
            return new MusikCD(interpret, titel, jahr);
        }

        private static FilmDVD NeueDVD()
        {
            Console.Write("Titel? ");
            string titel = Console.ReadLine();
            Console.Write("Hauptdarsteller? ");
            string hauptdarsteller = Console.ReadLine();
            Console.Write("Jahr? ");
            int jahr = Convert.ToInt32(Console.ReadLine());
            return new FilmDVD(hauptdarsteller, titel, jahr);
        }

        private static Zeitschrift NeuesZeitschrift()
        {
            Console.Write("Titel? ");
            string titel = Console.ReadLine();
            Console.Write("Themen? ");
            string themen = Console.ReadLine();
            Console.Write("Nummer? ");
            int nr = Convert.ToInt32(Console.ReadLine());
            Console.Write("Jahr? ");
            int jahr = Convert.ToInt32(Console.ReadLine());
            return new Zeitschrift(themen, nr, titel, jahr);
        }
    }
}
