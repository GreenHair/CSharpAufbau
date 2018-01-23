using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedienBibliothek
{
    [Serializable]
    public class Zeitschrift:Medien
    {
        string _themen;
        int _nr;

        public Zeitschrift(string themen, int nr, string titel, int jahr) : base(titel, jahr)
        {
            _themen = themen;
            _nr = nr;
        }

        public string Themen
        {
            get
            {
                return _themen;
            }

            set
            {
                _themen = value;
            }
        }

        public int Nr
        {
            get
            {
                return _nr;
            }

            set
            {
                _nr = value;
            }
        }

        override public string Anzeigen(Medien Mag)
        {
            Zeitschrift mag = Mag as Zeitschrift;
            string str = "Zeitschrift:\n";
            str += string.Format("Titel: {0}\tThemen: {1}\tNummer: {2}\tJahr: {3}",
                mag.Titel, mag.Themen, mag.Nr, mag.Erscheinungsjahr);
            return str;
        }

        public override string ToString()
        {
            return string.Format("Zeitschrift:\nTitel: {0}\tThemen: {1}\tNummer: {2}\tJahr: {3}",
                Titel, Themen, Nr, Erscheinungsjahr);
        }
    }
}
