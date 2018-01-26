using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fahrzeugvermietung
{
    [Serializable]
    class Kraftrad:Fahrzeug
    {
        bool _hatBeiwagen;

        public Kraftrad() { }
        public Kraftrad(string kennzeichen, int leistung,bool hatBeiwagen) : base(kennzeichen, leistung)
        {
            _hatBeiwagen = hatBeiwagen;
        }

        public bool HatBeiwagen
        {
            get
            {
                return _hatBeiwagen;
            }
            set
            {
                _hatBeiwagen = value;
            }
        }

        public override string ToString()
        {
            return string.Format("Motorrad\nKennzeichen: {0}\tPS: {1}\tBeiwagen: {2}",
                Kennzeichen, Leistung, HatBeiwagen);
        }
    }
}
