using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Exceptions
{
    public class CountryException : Exception
    {
        public CountryException(string message) : base(message) { }
    }
}
