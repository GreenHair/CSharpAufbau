using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klassenbibo
{
    [Serializable()]
    /// <summary>
    /// repräsentiert ein Auto-Objekt
    /// </summary>
    public class Auto
    {
        /// <summary>
        /// 
        /// </summary>
        public int baujahr { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int kmStand { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int leistung { get; set; }
        public string fahrgestell { get; set; }
    }
}
