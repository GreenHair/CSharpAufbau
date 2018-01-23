using System;
using System.Collections.Generic;
using System.Text;

namespace GeometricObjects
{
    [Serializable()]
    public class GraphicRectangle : Rectangle, IDraw
    {
        #region Konstruktoren 
        public GraphicRectangle() { }
        public GraphicRectangle(int length, int width) : base(length, width) { }
        public GraphicRectangle(int length, int width, double x, double y) : base(length, width, x, y) { }
        public GraphicRectangle(int length, int width, Point center) : base(length, width, center) { }
        #endregion

        #region Typspezifische Methode
        public virtual void Draw() => Console.WriteLine("Das Rechteck wird gezeichnet");
        #endregion
    }

}
