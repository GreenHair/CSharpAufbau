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

            //set
            //{
            //    _interpret = value;
            //}
        }
    }
}
