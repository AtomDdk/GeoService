using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Exceptions
{
    public class CityException : Exception
    {
        public CityException(string message) : base(message) { }
    }
}
