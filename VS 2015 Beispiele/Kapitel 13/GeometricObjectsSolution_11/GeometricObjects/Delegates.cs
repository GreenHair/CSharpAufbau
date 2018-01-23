using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GeometricObjects
{
  // EventArgs-Klassen
  public class MovingEventArgs : EventArgs
  {
    public bool Cancel { get; set; }
  }

  public class InvalidMeasureEventArgs : EventArgs
  {
    // Felder
    private int _InvalidMeasure;
    private string _PropertyName = "[unkonwn]";
    private Exception _Error;

    // Eigenschaften
    public int InvalidMeasure
    {
      get { return _InvalidMeasure; }
    }

    public string PropertyName
    {
      get { return _PropertyName; }
    }

    public Exception Error
    {
      get { return _Error; }
    }

    // Konstruktor
    public InvalidMeasureEventArgs(int invalidMeasure, string propertyName, Exception error)
    {
      _InvalidMeasure = invalidMeasure;
      _Error = error;
      if (propertyName == "" || propertyName == null)
        _PropertyName = "[unknown]";
      else 
        _PropertyName = propertyName;
    }
  }
}
