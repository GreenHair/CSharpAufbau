using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DateiFileStream
{
    class Program
    {
        static void Main(string[] args)
        {
            FileStream fs = new FileStream(@"D:\CSharp Aufbau\datei.dat", FileMode.OpenOrCreate);
            byte[] array = { 10, 20, 30, 40, 50, 60, 70, 80, 90, 100 };
            //byte[] array = { (byte)'D',(byte)'a',(byte)'s' };
            fs.Write(array,4, array.Length-4);

            fs.Position = 0;
            byte[] arrayRead = new byte[10];
            fs.Read(arrayRead, 0, 10);
            for(int i = 0; i < arrayRead.Length; i++)
            {
                Console.WriteLine(arrayRead[i]);
            }

            fs.Close();
            Console.ReadLine();
        }
    }
}
