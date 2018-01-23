using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedienBibliothek
{
    [Serializable]
    public class Buch:Medien
    {
        string _verfasser;
        string _verlag;

        public Buch(string verfasser, string verlag, string titel, int jahr) : base (titel,jahr)
        {
            _verfasser = verfasser;
            _verlag = verlag;
        }
        public string Verfasser
        {
            get
            {
                return _verfasser;
            }

            set
            {
                _verfasser = value;
            }
        }

        public string Verlag
        {
            get
            {
                return _verlag;
            }

            set
            {
                _verlag = value;
            }
        }

        override public string Anzeigen(Medien Buch)
        {
            Buch buch = Buch as Buch;
            string str = "Buch:\n";
            str +=  string.Format("Titel: {0}\tAuthor: {1}\tVerlag: {2}\tJahr: {3}",
                buch.Titel, buch.Verfasser, buch.Verlag, buch.Erscheinungsjahr);
            return str;
        }

        public override string ToString()
        {
            return string.Format("Buch:\nTitel: {0}\tAuthor: {1}\tVerlag: {2}\tJahr: {3}",
                Titel,Verfasser,Verlag,Erscheinungsjahr);
        }
    }
}
