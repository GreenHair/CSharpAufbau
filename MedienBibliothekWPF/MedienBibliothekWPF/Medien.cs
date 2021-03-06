﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedienBibliothek
{
    [Serializable]
    public class Medien
    {
        string _titel;
        int _erscheinungsjahr;

        public Medien() { }

        public Medien(string titel, int jahr)
        {
            _titel = titel;
            _erscheinungsjahr = jahr;
        }

        public string Titel
        {
            get
            {
                return _titel;
            }

            set
            {
                _titel = value;
            }
        }

        public int Erscheinungsjahr
        {
            get
            {
                return _erscheinungsjahr;
            }

            set
            {
                _erscheinungsjahr = value;
            }
        }

        virtual public string Anzeigen(Medien medium)
        {
            string str = "Medium:\n";
            str += String.Format("Titel: {0}\tJahr: {1}", medium.Titel, medium.Erscheinungsjahr);
            return str;
        }
    }
}
