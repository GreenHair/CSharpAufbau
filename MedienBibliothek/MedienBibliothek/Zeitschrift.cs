using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedienBibliothek
{
    [Serializable]
    public class Zeitschrift:Medien
    {
        string _themen;
        int _nr;

        public Zeitschrift(string themen, int nr, string titel, int jahr) : base(titel, jahr)
        {
            _themen = themen;
            _nr = nr;
        }

        public string Themen
        {
            get
            {
                return _themen;
            }

            //set
            //{
            //    _themen = value;
            //}
        }

        public int Nr
        {
            get
            {
                return _nr;
            }

            //set
            //{
            //    _nr = value;
            //}
        }
    }
}
