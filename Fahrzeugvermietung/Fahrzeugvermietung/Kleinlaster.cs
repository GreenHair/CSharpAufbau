using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fahrzeugvermietung
{
    [Serializable]
    class Kleinlaster:Fahrzeug
    {
        double _nutzlast;

        public Kleinlaster() { }
        public Kleinlaster(string kennzeichen, int leistung, double nutzlast) : base(kennzeichen, leistung)
        {
            _nutzlast = nutzlast;
        }

        public double Nutzlast
        {
            get
            {
                return _nutzlast;
            }
            set
            {
                _nutzlast = value;
            }
        }

        public override string ToString()
        {
            return string.Format("LKW\nKennzeichen: {0}\tPS: {1}\tNutzlast: {2}",
                Kennzeichen, Leistung, Nutzlast);
        }
    }
}
