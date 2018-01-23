using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UebungPKW
{
    public class Auto
    {
        public static List<Auto> meinFuhrpark = new List<Auto>();
        int baujahr;
        int kmStand;
        int ps;

        public int Baujahr
        {
            get
            {
                return baujahr;
            }
        }

        public int KmStand
        {
            get
            {
                return kmStand;
            }
        }

        public int Ps
        {
            get
            {
                return ps;
            }            
        }

        public Auto() { }

        public Auto(int _bj, int _km, int _ps)
        {
            baujahr = _bj;
            kmStand = _km;
            ps = _ps;
        }
    }
}
