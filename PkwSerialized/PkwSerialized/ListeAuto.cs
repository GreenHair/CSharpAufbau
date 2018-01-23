using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klassenbibo
{
    /// <summary>
    /// 
    /// </summary>
    public class ListeAuto
    {
        /// <summary>
        /// 
        /// </summary>
        public List<Object> liste { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public ListeAuto()
        {
            liste = new List<Object>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="auto"></param>
        public void Hinzufuegen(Object auto)
        {
            liste.Add(auto);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Object SucheAuto (int id)
        {
            Object pkw = new Object();
            if (id > 0 && liste.Count >= id)
            {
                pkw = liste[id - 1];
            }
            else
            {
                pkw = null;
            }
            return pkw;
        }
    }
}
