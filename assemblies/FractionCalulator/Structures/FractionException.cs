using System;
using System.Collections.Generic;
using System.Text;

namespace FractionCalulator.Structures
{
    public class FractionException : Exception
    {
        public FractionException() : base()
        { }

        public FractionException(string message) : base(message)
        { }

        public FractionException(string message, Exception innerException) : base(message, innerException)
        { }
    }
}
