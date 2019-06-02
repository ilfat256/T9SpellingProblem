using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T9Library
{
    class T9ConverterException : Exception
    {
        public T9ConverterException(string message) : base(message)
        {
        }
    }
}
