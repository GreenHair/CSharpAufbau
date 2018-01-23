using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UebungPKW
{
    class Program
    {
        static bool weiter = true;
        static void Main(string[] args)
        {
            AutoReader.GetAllCars();
            while (weiter)
            {
                int auswahl;

                Console.WriteLine("Wilkommen bei der Fahrzeug verwaltung.");
                Console.WriteLine("Was möchten Sie tun?");
                Console.WriteLine(" 1. Neues Fahrzeug hinzufügen");
                Console.WriteLine(" 2. Bestimmtes Fahrzeug anzeigen");
                Console.WriteLine(" 3. Alle Fahrzeuge anzeigen");
                Console.WriteLine(" 4. Programm verlassen");

                if(int.TryParse(Console.ReadLine(),out auswahl))
                {
                    switch (auswahl)
                    {
                        case 1: AddCar(); break;
                        case 2: BestimmtesAutoAnzeigen(); break;
                        case 3: ShowAllCars(); break;
                        case 4: Ende(); break;
                        default: Console.WriteLine("Fehler bei der Eingabe"); break;
                    }
                }
                else
                {
                    Console.WriteLine("Fehler bei der Eingabe");
                }
            }
            Console.ReadLine();
        }

        static void AddCar()
        {
            int bj, km, ps;
            Console.Write("Baujahr? ");
            int.TryParse(Console.ReadLine(), out bj);
            Console.Write("Kilometerstand? ");
            int.TryParse(Console.ReadLine(), out km);
            Console.Write("Leistung in ps? ");
            int.TryParse(Console.ReadLine(), out ps);
            if(bj != 0 && ps != 0)
            {
                Auto.meinFuhrpark.Add(new Auto(bj, km, ps));
            }
            else
            {
                Console.WriteLine("Fehler bei der Eingabe.\n Bitte nur Ganzzahlen angeben, Baujahr und PS dürfen nicht 0 sein.");
            }
        }

        private static void BestimmtesAutoAnzeigen()
        {
            int i;
            Console.Write("Welches Fahrzeug möchten Sie sehen?\nFahrzeug Nr. : ");
            int.TryParse(Console.ReadLine(), out i);
            //Auto a = AutoReader.ShowCar(i);
            Auto a = AutoReader.GetFromFile(i);            
            if (a != null)
            {
                Console.WriteLine("Baujahr\tKilometerstand\tLeistung in PS");
                Console.WriteLine(a.Baujahr + "\t" + a.KmStand + "\t\t" + a.Ps);
            }
        }

        static void ShowAllCars()
        {
            Console.WriteLine("Baujahr\tKilometerstand\tLeistung in PS");
            foreach(Auto a in Auto.meinFuhrpark)
            {
                //Console.WriteLine(a.Baujahr + "\t" + a.KmStand + "\t\t" + a.Ps);
                Console.WriteLine(String.Format("{0,-10}{1,15}{2,5}PS", a.Baujahr, a.KmStand, a.Ps));
            }
            Console.WriteLine();
        }

        static void Ende()
        {
            AutoReader.SaveAllCars();
            weiter = false;
            Console.WriteLine("Tschüss");
        }
    }
}
