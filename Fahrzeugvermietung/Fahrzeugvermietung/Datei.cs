using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Fahrzeugvermietung
{
    class Datei
    {
        public static void ListeSpeichern(string pfad, List<Fahrzeug> liste)
        {
            FileStream fs = new FileStream(pfad, FileMode.Create);
            BinaryFormatter format = new BinaryFormatter();
            format.Serialize(fs, liste);
            fs.Close();
        }
        
        public static List<Fahrzeug> ListeEinlesen(string pfad)
        {
            List<Fahrzeug> liste;
            if (File.Exists(pfad))
            {
                FileStream fs = new FileStream(pfad, FileMode.Open);
                BinaryFormatter format = new BinaryFormatter();
                liste = (List<Fahrzeug>)format.Deserialize(fs);
                fs.Close();
            }
            else
            {
                liste = null;
            }

            return liste;
        }
    }
}
