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
            myLib.Bestand.Add(new Buch("Harry Mulisch", "De Bezige Bij", "De Ontdekking van de Hemel", 1992));
            myLib.Bestand.Add(new MusikCD("ACDC", "Back in Black", 1984));
            myLib.Bestand.Add(new FilmDVD("Humpfrey Bogart", "Gone With The Wind", 1938));
            myLib.Bestand.Add(new Zeitschrift("Windows, Prozessoren", 12, "c't", 2016));

            Datei.Speichern(myLib.Bestand);
            Bibliothek myOtherLib = new Bibliothek();
            myOtherLib.Bestand = Datei.Laden();

            Anzeigen(myLib.Bestand);

            Console.ReadLine();

            Anzeigen(myOtherLib.Bestand);

            Console.ReadLine();
        }

        static void Anzeigen(List<Medien> bestand)
        {
            foreach(var item in bestand)
            {
                Buch buch = item as Buch;
                MusikCD cd = item as MusikCD;
                FilmDVD dvd = item as FilmDVD;
                Zeitschrift mag = item as Zeitschrift;
                if(buch != null)
                {
                    zeigeBuch(buch);
                }                            
                if(cd != null)
                {
                    zeigeCD(cd);
                }
                if(dvd != null)
                {
                    zeigeDVD(dvd);
                }
                if (mag != null)
                {
                    zeigeZeitschrift(mag);
                }
                
            }
        }

        private static void zeigeBuch(Buch buch)
        {
            Console.WriteLine("Buch:");
            Console.WriteLine("Titel: {0}\tAuthor: {1}\tVerlag: {2}\tJahr: {3}",
                buch.Titel, buch.Verfasser, buch.Verlag, buch.Erscheinungsjahr);
        }

        private static void zeigeCD(MusikCD cd)
        {
            Console.WriteLine("CD:");
            Console.WriteLine("Titel: {0}\tInterpret: {1}\tJahr: {2}", cd.Titel, cd.Interpret, cd.Erscheinungsjahr);
        }

        private static void zeigeDVD(FilmDVD dvd)
        {
            Console.WriteLine("DVD:");
            Console.WriteLine("Titel: {0}\tHauptdarsteller: {1}\tJahr: {2}", dvd.Titel, dvd.Hauptdarsteller, dvd.Erscheinungsjahr);
        }

        private static void zeigeZeitschrift(Zeitschrift mag)
        {
            Console.WriteLine("Zeitschrift:");
            Console.WriteLine("Titel: {0}\tThemen: {1}\tNummer: {2}\tJahr: {3}", mag.Titel, mag.Themen, mag.Nr, mag.Erscheinungsjahr);
        }

        
    }
}
