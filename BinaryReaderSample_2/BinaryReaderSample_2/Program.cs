using System;
using System.IO;

namespace BinaryReaderSample_2
{
    public class Program
    {
        static void Main(string[] args)
        {
            // Point-Array erzeugen
            Point[] pArr = new Point[2];
            pArr[0].XPos = 10;
            pArr[0].YPos = 20;
            pArr[0].Color = 310;
            pArr[1].XPos = 40;
            pArr[1].YPos = 50;
            pArr[1].Color = 110;

            // Point-Array speichern
            PointReader.WriteToFile(@"D:\Test.pot", pArr);

            // gespeicherte Informationen aus der Datei wieder einlesen
            Point[] x = PointReader.GetFromFile(@"D:\Test.pot");

            // alle eingelesenen Point-Daten ausgeben
            for (int i = 0; i < 2; i++)
            {
                Console.WriteLine("Point-Objekt-Nr.{0}", i + 1);
                Console.WriteLine();
                Console.WriteLine("p[{0}].XPos = {1}", i, x[i].XPos);
                Console.WriteLine("p[{0}].YPos = {1}", i, x[i].YPos);
                Console.WriteLine("p[{0}].Color = {1}", i, x[i].Color);
                Console.WriteLine(new string('=', 30));
            }

            // einen bestimmten Point einlesen
            Console.Write("\nWelchen Punkt möchten Sie einlesen? ");
            int position = Convert.ToInt32(Console.ReadLine());
            try
            {
                Point myPoint = PointReader.GetPoint(@"D:\Test.pot", position);
                Console.WriteLine("p.XPos = {0}", myPoint.XPos);
                Console.WriteLine("p.YPos = {0}", myPoint.YPos);
                Console.WriteLine("p.Color = {0}", myPoint.Color);
            }
            catch (PositionException e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadLine();
        }
    }

}
