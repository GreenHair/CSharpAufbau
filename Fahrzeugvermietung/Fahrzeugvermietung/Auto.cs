using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fahrzeugvermietung
{
    [Serializable]
    class Auto:Fahrzeug
    {
        int _anzTueren;

        public Auto() { }
        public Auto(string kennzeichen, int leistung, int anzTueren) : base(kennzeichen, leistung)
        {
            _anzTueren = anzTueren;
        }

        public int AnzTueren
        {
            get
            {
                return _anzTueren;
            }
            set
            {
                _anzTueren = value;
            }
        }
        public override string ToString()
        {
            return string.Format("PKW\nKennzeichen: {0}\tPS: {1}\tanz. Türen: {2}",
                Kennzeichen, Leistung, AnzTueren);
        }
    }
}
