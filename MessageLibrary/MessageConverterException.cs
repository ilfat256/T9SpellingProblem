using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T9Library
{
    public class MessageConverterException : Exception
    {
        public MessageConverterException(string message) : base(message)
        {
        }
    }
}
