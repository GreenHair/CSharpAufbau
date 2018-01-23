using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace Klassenbibo
{
    /// <summary>
    /// 
    /// </summary>
    public class Datei
    {
        /// <summary>
        /// Speichert die Liste in eine Datei
        /// </summary>
        /// <param name="pfad">absoluter Pfad zur Datei</param>
        /// <param name="liste">die Liste die gespeichert werden soll</param>
        public static void ListeSpeichern(string pfad, List<Object> liste)
        {
            FileStream fs = new FileStream(pfad, FileMode.Create);
            BinaryFormatter format = new BinaryFormatter();
            format.Serialize(fs, liste);
            fs.Close();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pfad">absoluter Pfad zur Datei</param>
        /// <returns>Liste mit den Inhalten der Datei</returns>
        public static List<Object> ListeEinlesen(string pfad)
        {
            List<Object> liste;
            if (File.Exists(pfad))
            {
                FileStream fs = new FileStream(pfad, FileMode.Open);
                BinaryFormatter format = new BinaryFormatter();
                liste = (List<Object>)format.Deserialize(fs);
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