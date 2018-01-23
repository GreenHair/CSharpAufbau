using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedienBibliothek
{
    [Serializable]
    public class FilmDVD:Medien
    {
        string _hauptdarsteller;

        public FilmDVD(string hauptdarsteller, string titel, int jahr) : base(titel, jahr)
        {
            _hauptdarsteller = hauptdarsteller;
        }

        public string Hauptdarsteller
        {
            get
            {
                return _hauptdarsteller;
            }

            set
            {
                _hauptdarsteller = value;
            }
        }

        override public string Anzeigen(Medien DVD)
        {
            FilmDVD dvd = DVD as FilmDVD;
            string str = "DVD:\n";
            str += string.Format("Titel: {0}\tHauptdarsteller: {1}\tJahr: {2}", 
                dvd.Titel, dvd.Hauptdarsteller, dvd.Erscheinungsjahr);
            return str;
        }

        public override string ToString()
        {
            return string.Format("DVD:\nTitel: {0}\tHauptdarsteller: {1}\tJahr: {2}",
                Titel, Hauptdarsteller, Erscheinungsjahr);
        }
    }
}
