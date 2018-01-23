using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GeometricObjects
{
    [Serializable()]
    public struct Point
    {
        // Felder
        private double _X;
        private double _Y;

        // Eigenschaften
        public double X
        {
            get { return _X; }
            set { _X = value; }
        }

        public double Y
        {
            get { return _Y; }
            set { _Y = value; }
        }

        // Konstruktor
        public Point(double x, double y)
        {
            _X = x;
            _Y = y;
        }
    }
}
