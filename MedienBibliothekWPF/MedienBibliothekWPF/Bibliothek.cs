using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedienBibliothek
{
    public class Bibliothek
    {
        ObservableCollection<Medien> _bestand;

        public Bibliothek()
        {
            _bestand = new ObservableCollection<Medien>();
        }

        public ObservableCollection<Medien> Bestand
        {
            get
            {
                return _bestand;
            }

            set
            {
                _bestand = value;
            }
        }

        internal void Hinzufuegen(Medien medien)
        {
            if (medien != null)
            {
                _bestand.Add(medien);
            }
        }

        public ObservableCollection<Medien> SortiertNachTyp()
        {
            ObservableCollection<Medien> sortList = new ObservableCollection<Medien>();            
            var sortiert = from medium in _bestand group medium by medium.GetType();
            foreach (var item in sortiert)
            {
                foreach (var element in item)
                {
                    sortList.Add(element);
                }
            }
            return sortList;
        }

        public List<Medien> SortiertNachTypListe()
        {
            List<Medien> sortList = new List<Medien>();
            var sortiert = from medium in _bestand group medium by medium.GetType();
            foreach (var item in sortiert)
            {
                foreach (var element in item)
                {
                    sortList.Add(element);
                }
            }
            return sortList;
        }
    }
}
