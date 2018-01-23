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

            //set
            //{
            //    _verfasser = value;
            //}
        }

        public string Verlag
        {
            get
            {
                return _verlag;
            }

            //set
            //{
            //    _verlag = value;
            //}
        }
    }
}
