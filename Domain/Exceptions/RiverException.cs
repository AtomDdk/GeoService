using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Exceptions
{
    public class RiverException : Exception
    {
        public RiverException(string message) : base(message) { }
    }
}
