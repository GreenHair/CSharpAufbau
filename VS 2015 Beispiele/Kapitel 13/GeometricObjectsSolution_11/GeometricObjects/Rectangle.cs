using System;

namespace GeometricObjects
{
    [Serializable]
    public class Rectangle : GeometricObject, IDisposable
    {
        #region Feld 
        private bool disposed;
        #endregion

        #region Konstruktoren 
        public Rectangle() : this(0, 0, 0, 0) { }

        public Rectangle(int length, int width) : this(length, width, 0, 0) { }

        public Rectangle(int length, int width, double x, double y)
        {
            Length = length;
            Width = width;
            _Center.X = x;
            _Center.Y = y;
            Rectangle._CountRectangles++;
        }

        public Rectangle(int length, int width, Point center)
        {
            Length = length;
            Width = width;
            _Center = center;
            Rectangle._CountRectangles++;
        }
        #endregion

        #region Eigenschaften 
        protected int _Length;
        public virtual int Length
        {
            get { return _Length; }
            set
            {
                if (value >= 0)
                {
                    _Length = value;
                    OnPropertyChanged(nameof(Length));
                }
                else
                {
                    InvalidMeasureException ex = new InvalidMeasureException("Eine Length von " + value + " ist nicht zulässig.");
                    ex.Data.Add("Time", DateTime.Now);
                    OnInvalidMeasure(new InvalidMeasureEventArgs(value, nameof(Length), ex));
                }
            }
        }

        protected int _Width;
        public virtual int Width
        {
            get { return _Width; }
            set
            {
                if (value >= 0)
                {
                    _Width = value;
                    OnPropertyChanged(nameof(Width));
                }
                else
                {
                    InvalidMeasureException ex = new InvalidMeasureException("Eine Width von " + value + " ist nicht zulässig.");
                    ex.Data.Add("Time", DateTime.Now);
                    OnInvalidMeasure(new InvalidMeasureEventArgs(value, nameof(Width), ex));
                }
            }
        }
        #endregion

        #region Klasseneigenschaft
        protected static int _CountRectangles;
        public static int CountRectangles => _CountRectangles;
        #endregion

        #region Instanzmethoden
        public override double GetArea() => Length * Width;

        public override double GetCircumference() => 2 * (Length + Width);

        public virtual void Move(double dx, double dy, int dWidth, int dLength)
        {
            MovingEventArgs e = new MovingEventArgs();
            // Moving-Ereignis
            OnMoving(e);
            if (e.Cancel == true) return;
            XCoordinate += dx;
            YCoordinate += dy;
            Width += dWidth;
            Length += dLength;
            // Moved-Ereignis
            OnMoved(new EventArgs());
        }

        public override string ToString() => nameof(Rectangle) + ", L=" + Length + ",B=" + Width + ",Fläche=" + GetArea();
        #endregion

        #region Klassenmethoden 
        public static double GetArea(int length, int width) => length * width;

        public static double GetCircumference(int length, int width) => 2 * (length + width);
        #endregion

        #region Finalisierung
        public void Dispose()
        {
            if (!disposed)
            {
                Rectangle._CountRectangles--;
                GeometricObject._CountGeometricObjects--;
                GC.SuppressFinalize(this);
                disposed = true;
            }
        }

        ~Rectangle()
        {
            Dispose();
        }
        #endregion

        #region Benutzerdefinierte Konvertierung
        public static explicit operator Circle(Rectangle rect)
        {
            int radius = (int)Math.Sqrt(rect.GetArea() / Math.PI);
            return new Circle(radius, rect.Length / 2, rect.Width / 2);
        }
        #endregion
    }
}
