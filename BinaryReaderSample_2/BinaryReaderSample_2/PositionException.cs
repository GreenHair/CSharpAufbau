﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BinaryReaderSample_2
{
    public class PositionException : Exception
    {
        public PositionException() { }
        public PositionException(string message) : base(message) { }
        public PositionException(string message, Exception inner)
            : base(message, inner) { }
    }

}
