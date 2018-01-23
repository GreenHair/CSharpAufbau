using System;
using System.Runtime.Serialization;

namespace GeometricObjects
{
  [Serializable]
  public class InvalidMeasureException : Exception
  {
    public InvalidMeasureException() { }
    public InvalidMeasureException(string message) : base(message) { }
    public InvalidMeasureException(string message, Exception inner) : base(message, inner) { }
    protected InvalidMeasureException(SerializationInfo info, StreamingContext context) : base(info, context) { }
  }   
}
