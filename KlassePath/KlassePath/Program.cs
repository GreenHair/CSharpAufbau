using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace KlassePath
{
    class Program
    {
        static void Main(string[] args)
        {
            string pfad = @"C:\Windows\System32\kernel32.dll";
            Console.WriteLine(Path.GetDirectoryName(pfad));
            Console.WriteLine(Path.GetFileNameWithoutExtension(pfad));
            Console.WriteLine(Path.GetTempPath());
            string tempDatei = Path.GetTempFileName();
            Console.WriteLine(tempDatei);
            File.Delete(tempDatei);

            DriveInfo laufwerk = new DriveInfo("c");
            Console.WriteLine(laufwerk.AvailableFreeSpace/1024);
            Console.WriteLine(laufwerk.TotalFreeSpace/1024);
            Console.WriteLine(laufwerk.IsReady);
            Console.ReadLine();
        }
    }
}
