using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedienBibliothek
{
    public class Bibliothek
    {
        List<Medien> _bestand;

        public Bibliothek()
        {
            _bestand = new List<Medien>();
        }

        public List<Medien> Bestand
        {
            get
            {
                return _bestand;
            }

            set
            {
                _bestand = value;
            }
        }
    }
}
