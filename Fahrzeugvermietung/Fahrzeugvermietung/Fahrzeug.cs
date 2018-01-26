using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fahrzeugvermietung
{
    [Serializable]
    class Fahrzeug
    {
        protected string _kennzeichen;
        protected int _leistung;

        public Fahrzeug() { }
        public Fahrzeug(string kennzeichen, int leistung)
        {
            _kennzeichen = kennzeichen;
            _leistung = leistung;
        }

        public string Kennzeichen
        {
            get
            {
                return _kennzeichen;
            }
            set
            {
                _kennzeichen = value;
            }
        }

        public int Leistung
        {
            get
            {
                return _leistung;
            }
            set
            {
                _leistung = value;
            }
        }
    }
}
