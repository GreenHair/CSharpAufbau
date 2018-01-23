using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klassenbibo
{
    public class ListeAuto
    {
        public List<Auto> Liste = new List<Auto>();
        
        public ListeAuto() { }
        
        public void Hinzufuegen(Auto auto)
        {
            Liste.Add(auto);
        }
        
        public Object SucheAuto (int id)
        {
            Object pkw = new Object();
            if (id > 0 && Liste.Count >= id)
            {
                pkw = Liste[id - 1];
            }
            else
            {
                pkw = null;
            }
            return pkw;
        }
    }
}
