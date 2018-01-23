using System;
using System.IO;

namespace BinaryReaderSample_2
{
    public class PointReader
    {

        public static void WriteToFile(string path, Point[] array)
        {
            FileStream fileStr = new FileStream(path, FileMode.Create);
            BinaryWriter binWriter = new BinaryWriter(fileStr);
            // Anzahl der Punkte in die Datei schreiben
            binWriter.Write(array.Length);
            // die Point-Daten in die Datei schreiben
            for (int i = 0; i < array.Length; i++)
            {
                binWriter.Write(array[i].XPos);
                binWriter.Write(array[i].YPos);
                binWriter.Write(array[i].Color);
            }
            binWriter.Close();
        }

        public static Point[] GetFromFile(string path)
        {
            FileStream fs = new FileStream(path, FileMode.Open);
            BinaryReader br = new BinaryReader(fs);
            // liest die ersten 4 Bytes aus der Datei, die die Anzahl der
            // Point-Objekte enthält
            int anzahl = br.ReadInt32();
            // einlesen der Daten in der Datei
            Point[] arrPoint = new Point[anzahl];
            for (int i = 0; i < anzahl; i++)
            {
                arrPoint[i].XPos = br.ReadInt32();
                arrPoint[i].YPos = br.ReadInt32();
                arrPoint[i].Color = br.ReadInt64();
            }
            br.Close();
            return arrPoint;
        }

        public static Point GetPoint(string path, int pointNo)
        {
            FileStream fs = new FileStream(path, FileMode.Open);
            int pos = 4 + (pointNo - 1) * 16;
            BinaryReader br = new BinaryReader(fs);
            // hat der Anwender eine gültige Position angegeben?
            if (pointNo > br.ReadInt32() || pointNo == 0)
            {
                string message = "Unter der angegebenen Position ist";
                message += " kein \nPoint-Objekt gespeichert.";
                throw new PositionException(message);
            }
            // den Zeiger positionieren
            fs.Seek(pos, SeekOrigin.Begin);
            // Daten des gewünschten Points einlesen
            Point savedPoint = new Point();
            savedPoint.XPos = br.ReadInt32();
            savedPoint.YPos = br.ReadInt32();
            savedPoint.Color = br.ReadInt64();
            br.Close();
            return savedPoint;
        }
    }
}
