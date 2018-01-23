using System;
using System.Collections.Generic;
using System.Text;

namespace GeometricObjects
{
    [Serializable()]
    public class GraphicCircle : Circle, IDraw
    {
        #region Konstruktoren
        public GraphicCircle() { }
        public GraphicCircle(int radius) : base(radius) { }
        public GraphicCircle(int radius, double x, double y) : base(radius, x, y) { }
        public GraphicCircle(int radius, Point center) : base(radius, center) { }
        #endregion

        #region Typspezifische Methode
        public virtual void Draw() => Console.WriteLine("Der Kreis wird gezeichnet");
        #endregion
    }
}
