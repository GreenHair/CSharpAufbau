using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace UebungPKW
{
    public class AutoReader
    {
        static string path = @"D:\CSharp Aufbau\UebungPKW\UebungPKW\auto.dat";

        public static void SaveAllCars()
        {
            FileStream fs = new FileStream(path, FileMode.Create);
            BinaryWriter bw = new BinaryWriter(fs);
            bw.Write(Auto.meinFuhrpark.Count);
            foreach(Auto pkw in Auto.meinFuhrpark)
            {
                bw.Write(pkw.Baujahr);
                bw.Write(pkw.KmStand);
                bw.Write(pkw.Ps);
            }
            bw.Close();
        }

        internal static Auto ShowCar(int i)
        {
            if(i <= Auto.meinFuhrpark.Count && i > 0)
            {
                return Auto.meinFuhrpark[i - 1];
            }
            else
            {
                Console.WriteLine("Das Fahrzeug konnte nicht gefunden worden");
                return null;
            }
        }

        public static Auto GetFromFile(int i)
        {
            try
            {
                FileStream fs = new FileStream(path, FileMode.Open);
                BinaryReader br = new BinaryReader(fs);
                int anzahl = br.ReadInt32();

                if (i <= anzahl && i > 0)
                {
                    int pos = 4 + (i - 1) * 12;
                    fs.Seek(pos, SeekOrigin.Begin);
                    br.Close();
                    return new Auto(br.ReadInt32(), br.ReadInt32(), br.ReadInt32());
                }
                else
                {
                    Console.WriteLine("Das Fahrzeug konnte nicht gefunden worden");
                    return null;
                }
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine(e.Message);                
                return null;
            }
        }

        public static void GetAllCars()
        {
            try
            {
                FileStream fs = new FileStream(path, FileMode.Open);
                BinaryReader br = new BinaryReader(fs);
                int anzahl = br.ReadInt32();
                for (int i = 0; i < anzahl; i++)
                {
                    int bj = br.ReadInt32();
                    int km = br.ReadInt32();
                    int ps = br.ReadInt32();
                    Auto.meinFuhrpark.Add(new Auto(bj, km, ps));
                }
                br.Close();
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Sie wurde vielleicht verschoben oder gelöscht\n");
            }
        }
    }
}
