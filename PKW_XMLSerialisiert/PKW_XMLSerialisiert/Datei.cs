using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Xml.Serialization;

namespace Klassenbibo
{ 
    public class Datei
    {        
        public static void ListeSpeichern(string pfad, object obj, Type type)
        {
            FileStream fs = new FileStream(pfad, FileMode.Create);
            XmlSerializer xmlDatei = new XmlSerializer(type);
            xmlDatei.Serialize(fs, obj);
            fs.Close();
        }
        
        public static object ListeEinlesen(string pfad, Type type)
        {
            object liste;
            if (File.Exists(pfad))
            {
                FileStream fs = new FileStream(pfad, FileMode.Open);
                XmlSerializer xmlDatei = new XmlSerializer(type);
                liste = xmlDatei.Deserialize(fs);
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