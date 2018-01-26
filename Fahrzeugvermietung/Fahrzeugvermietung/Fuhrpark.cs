using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fahrzeugvermietung
{
    [Serializable]
    class Fuhrpark
    {
        public List<Fahrzeug> AlleFahrzeuge { get; set; }
        public Fuhrpark()
        {
            AlleFahrzeuge = new List<Fahrzeug>();
        }
    }
}
