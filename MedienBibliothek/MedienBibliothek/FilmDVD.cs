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
    }
}
