using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Exceptions
{
    public class ContinentException : Exception
    {
        public ContinentException(string message) : base(message) { }
    }
}
