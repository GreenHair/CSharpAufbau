using Klassenbibo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace Aufgabe1
{
    class Program
    {
        private static ListeAuto liste = new ListeAuto();
        private static string pfad= @"D:\CSharp Aufbau\PKW_XMLSerialisiert\PKW_XMLSerialisiert\auto.xml";
        static void Main(string[] args)
        {
            liste = new ListeAuto();
            liste.Liste = (List<Auto>)Datei.ListeEinlesen(pfad, typeof(List<Auto>));
            do
            {
                Console.Clear();
                Console.WriteLine("Autos erfassen leicht gemacht.");
                Console.WriteLine(new string('-',30));
                Console.WriteLine("1. Auto erfassen");
                Console.WriteLine("2. alle Autos anzeigen");
                Console.WriteLine("3. ein Auto anzeigen");
                Console.WriteLine("4. speichern");
                Console.WriteLine("5. Beenden");
                Console.Write("Ihre Auswahl: ");
                int auswahl = Console.Read();
                Console.ReadLine();
                switch (auswahl)
                {
                    case '1':
                        liste.Hinzufuegen(AutoEingabe());
                        break;
                    case '2':
                        alleAnzeigen();
                        break;
                    case '3':
                        int id=AutoSuchenEingabe();
                        AutoAnzeigen(liste.SucheAuto(id), id);
                        break;
                    case '4':
                        Datei.ListeSpeichern(pfad, liste, typeof(ListeAuto));
                        break;
                    case '5':
                        Datei.ListeSpeichern(pfad, liste.Liste, typeof(List<Auto>));
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Falsche Eingabe!");
                        break;
                }
            }
            while(true);
        }

        private static Auto AutoEingabe()
        {
            Auto pkw = new Auto();
            Console.Clear();
            Console.WriteLine("Eingabe eines Autos.");
            Console.WriteLine(new string('-',30));
            Console.Write("Baujahr: ");
            pkw.baujahr = Convert.ToInt32(Console.ReadLine());
            Console.Write("Km-Stand: ");
            pkw.kmStand = Convert.ToInt32(Console.ReadLine());
            Console.Write("Leistung in PS: ");
            pkw.leistung = Convert.ToInt32(Console.ReadLine());
            Console.Write("Fahrgestellnummer: ");
            pkw.fahrgestell = Console.ReadLine();
            return pkw;
        }

        private static void alleAnzeigen()
        {
            Console.Clear();
            Console.WriteLine("Alle Fahrzeuge anzeigen");
            Console.WriteLine(new string('-', 30));
            for(int i=0;i<liste.Liste.Count;i++)
            {
                AutoAnzeigen(liste.Liste[i], i);
                Console.WriteLine(new string('/', 30));
            }
        }

        private static void AutoAnzeigen(Object pkw, int id)
        {
            if (pkw != null)
            {
                Auto pk = (Auto)pkw;
                Console.WriteLine("Fahrzeugnummer: " + id);
                Console.WriteLine("Baujahr: " + pk.baujahr);
                Console.WriteLine("Kilometerstand: " + pk.kmStand);
                Console.WriteLine("Leistung: " + pk.leistung);
                Console.WriteLine("Fahrgestellnr: " + pk.fahrgestell);
                Console.WriteLine("Weiter mit der ENTER-Taste");
            }
            else
            {
                Console.WriteLine("Fahrzeugnummer: " + id);
                Console.WriteLine("Nicht vorhanden!!");
            }
            Console.ReadLine();
        }

        private static int AutoSuchenEingabe()
        {
            Console.Clear();
            Console.WriteLine("Fahrzeug suchen");
            Console.WriteLine(new string('-',30));
            Console.Write("Welche Fahrzeug-ID wollen sie suchen: ");
            int id = Convert.ToInt32(Console.ReadLine());
            return id;
        }

    }
}
