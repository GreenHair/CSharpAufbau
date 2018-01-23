using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedienBibliothek
{
    [Serializable]
    public class MusikCD:Medien
    {
        string _interpret;

        public MusikCD(string interpret, string titel, int jahr) : base(titel, jahr)
        {
            _interpret = interpret;
        }

        public string Interpret
        {
            get
            {
                return _interpret;
            }

            set
            {
                _interpret = value;
            }
        }

        override public string Anzeigen(Medien CD)
        {
            MusikCD cd = CD as MusikCD;
            string str = "CD:\n";
            str += string.Format("Titel: {0}\tInterpret: {1}\tJahr: {2}", cd.Titel, cd.Interpret, cd.Erscheinungsjahr);
            return str;
        }

        public override string ToString()
        {
            return string.Format("CD:\nTitel: {0}\tInterpret: {1}\tJahr: {2}", Titel, Interpret, Erscheinungsjahr);
        }
    }
}
