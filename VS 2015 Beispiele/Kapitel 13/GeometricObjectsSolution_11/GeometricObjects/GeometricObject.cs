using System;
using System.ComponentModel;

namespace GeometricObjects
{
    [Serializable()]
    public abstract class GeometricObject : IComparable, INotifyPropertyChanged
    {
        #region Felder
        protected Point _Center = new Point();
        #endregion


        #region Ereignisse
        public event EventHandler<MovingEventArgs> Moving;
        public event EventHandler<EventArgs> Moved;
        public event EventHandler<InvalidMeasureEventArgs> InvalidMeasure;
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        protected virtual void OnMoving(MovingEventArgs e)
        {
            if (Moving != null)
                Moving(this, e);
        }

        protected virtual void OnMoved(EventArgs e)
        {
            if (Moved != null)
                Moved(this, e);
        }

        protected void OnInvalidMeasure(InvalidMeasureEventArgs e)
        {
            if (InvalidMeasure != null)
                InvalidMeasure(this, e);
            else
                throw e.Error;
        }
        #endregion

        #region Statische Eigenschaft
        protected static int _CountGeometricObjects;
        public static int CountGeometricObjects => _CountGeometricObjects;
        #endregion

        // Konstruktor
        protected GeometricObject()
        {
            GeometricObject._CountGeometricObjects++;
        }

        #region Eigenschaften
        public virtual double XCoordinate
        {
            get { return _Center.X; }
            set
            {
                _Center.X = value;
                OnPropertyChanged(nameof(XCoordinate));
            }
        }

        public virtual double YCoordinate
        {
            get { return _Center.Y; }
            set
            {
                _Center.Y = value;
                OnPropertyChanged(nameof(YCoordinate));
            }
        }
        #endregion

        #region Abstrakte Methoden
        public abstract double GetArea();
        public abstract double GetCircumference();
        #endregion

        #region Instanzmethoden
        public virtual int CompareTo(Object @object)
        {
            GeometricObject geoObject = @object as GeometricObject;
            if (geoObject != null)
            {
                if (GetArea() < geoObject.GetArea()) return -1;
                if (GetArea() == geoObject.GetArea()) return 0;
                return 1;
            }
            throw new ArgumentException("Ungültige Objektübergabe. Es wird der Typ 'GeometricObject' erwartet.");
        }


        public virtual void Move(double dx, double dy)
        {
            // Moving-Ereignis
            MovingEventArgs e = new MovingEventArgs();
            OnMoving(e);
            if (e.Cancel == true)
                return;
            XCoordinate += dx;
            YCoordinate += dy;
            // Moved-Ereignis
            OnMoved(new EventArgs());
        }

        public virtual void Move(Point center)
        {
            _Center = center;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        #endregion

        #region Klassenmethode
        public static int Bigger(GeometricObject object1, GeometricObject object2)
        {
            if (object1 == null && object2 == null) return 0;
            if (object1 == null) return -1;
            if (object2 == null) return 1;
            if (object1.GetArea() > object2.GetArea()) return 1;
            if (object1.GetArea() < object2.GetArea()) return -1;
            return 0;
        }
        #endregion

        #region Operatorüberladungen
        public static bool operator >(GeometricObject object1, GeometricObject object2)
        {
            if (object1 == null || object2 == null)
                throw new InvalidOperationException();
            return object1.GetArea() > object2.GetArea() ? true : false;
        }

        public static bool operator <(GeometricObject object1, GeometricObject object2)
        {
            if (object1 == null || object2 == null)
                throw new InvalidOperationException();
            return object1.GetArea() < object2.GetArea() ? true : false;
        }

        public override bool Equals(object @object)
        {
            if (@object == null) return false;
            if (GetArea() == ((GeometricObject)@object).GetArea()) return true;
            return false;
        }

        public static bool operator ==(GeometricObject obj1, GeometricObject obj2)
        {
            if (ReferenceEquals(obj1, obj2)) return true;
            if (ReferenceEquals(obj1, null)) return false;
            return obj1.Equals(obj2);
        }

        public static bool operator !=(GeometricObject obj1, GeometricObject obj2) => !(obj1 == obj2);

        public static bool operator >=(GeometricObject object1, GeometricObject object2)
        {
            if (object1 == null || object2 == null)
                throw new InvalidOperationException();
            return object1.GetArea() >= object2.GetArea() ? true : false;
        }

        public static bool operator <=(GeometricObject object1, GeometricObject object2)
        {
            if (object1 == null || object2 == null)
                throw new InvalidOperationException();
            return object1.GetArea() <= object2.GetArea() ? true : false;
        }
        #endregion
    }
}
