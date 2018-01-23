using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Punkte
{
    class Program
    {
        static void Main(string[] args)
        {
            Point[] pArr = new Point[2];
            pArr[0].XPos = 10;
            pArr[0].YPos = 20;
            pArr[0].color = 310;
            pArr[1].XPos = 40;
            pArr[1].YPos = 50;
            pArr[1].color = 110;

            SchreibInDatei(@"D:\CSharp Aufbau\punkte.dat", pArr);

            Point[] neuesArr = HolePunkte(@"D:\CSharp Aufbau\punkte.dat");

            foreach(Point p in neuesArr)
            {
                Console.WriteLine("Point)
            }
        }

        static void SchreibInDatei(string path, Point[] array)
        {
            FileStream fs = new FileStream(path, FileMode.Create);
            BinaryWriter binSchreiber = new BinaryWriter(fs);
            binSchreiber.Write(array.Length);
            for(int i = 0; i < array.Length; i++)
            {
                binSchreiber.Write(array[i].XPos);
                binSchreiber.Write(array[i].YPos);
                binSchreiber.Write(array[i].color);
            }
            binSchreiber.Close();
        }

        static Point[] HolePunkte(string pfad)
        {
            FileStream fs = new FileStream(pfad, FileMode.Open);
            BinaryReader binLeser = new BinaryReader(fs);

            int anzahl = binLeser.ReadInt32();

            Point[] arrPoint = new Point[anzahl];
            for(int i = 0; i < anzahl; i++)
            {
                arrPoint[i].XPos = binLeser.ReadInt32();
                arrPoint[i].YPos = binLeser.ReadInt32();
                arrPoint[i].color = binLeser.ReadInt64();
            }
            binLeser.Close();
            return arrPoint;
        }

        struct Point
        {
            public int XPos;
            public int YPos;
            public long color;
        }
    }
}
