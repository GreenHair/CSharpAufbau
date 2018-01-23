using System;

namespace GeometricObjects
{
    [Serializable()]
    public class Circle : GeometricObject, IDisposable
    {
        #region Felder
        private bool disposed;
        #endregion

        #region Eigenschaftsmethoden
        protected int _Radius;
        public virtual int Radius
        {
            get { return _Radius; }
            set
            {
                if (value >= 0)
                {
                    _Radius = value;
                    OnPropertyChanged(nameof(Radius));
                }
                else
                {
                    InvalidMeasureException ex = new InvalidMeasureException("Ein Radius von " + value + " ist nicht zulässig.");
                    ex.Data.Add("Time", DateTime.Now);
                    OnInvalidMeasure(new InvalidMeasureEventArgs(value, nameof(Radius), ex));
                }
            }
        }
        #endregion

        #region Klasseneigenschaft
        private static int _CountCircles;
        public static int CountCircles => _CountCircles;
        #endregion

        #region Konstruktoren 
        public Circle() : this(0, 0, 0) { }

        public Circle(int radius) : this(radius, 0, 0) { }

        public Circle(int radius, Point center)
        {
            Radius = radius;
            _Center = center;
            Circle._CountCircles++;
        }

        public Circle(int radius, double x, double y)
        {
            Radius = radius;
            _Center.X = x;
            _Center.Y = y;
            Circle._CountCircles++;
        }
        #endregion

        #region Instanzmethoden 
        public override double GetArea() => Math.Pow(Radius, 2) * Math.PI;

        public override double GetCircumference() => 2 * Radius * Math.PI;

        public virtual void Move(double dx, double dy, int dRadius)
        {
            MovingEventArgs e = new MovingEventArgs();
            // Moving-Ereignis
            OnMoving(e);
            if (e.Cancel == true) return;
            XCoordinate += dx;
            YCoordinate += dy;
            Radius += dRadius;
            // Moved-Ereignis
            OnMoved(new EventArgs());
        }

        public override string ToString() => nameof(Circle) + ", R=" + Radius + ",Fläche=" + GetArea();
        #endregion

        #region Klassenmethoden 
        public static double GetArea(int radius) => Math.Pow(radius, 2) * Math.PI;
        public static double GetCircumference(int radius) => 2 * radius * Math.PI;
        #endregion

        #region Finalisierung
        public void Dispose()
        {
            if (!disposed)
            {
                Circle._CountCircles--;
                GeometricObject._CountGeometricObjects--;
                GC.SuppressFinalize(this);
                disposed = true;
            }
        }

        ~Circle()
        {
            Dispose();
        }
        #endregion

        #region Benutzerdefinierte Konvertierung
        public static explicit operator Rectangle(Circle circle) => new Rectangle(2 * circle.Radius, 2 * circle.Radius, circle.XCoordinate - circle.Radius, circle.YCoordinate - circle.Radius);
        #endregion
    }
}
