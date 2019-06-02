using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageLibrary
{
    public class ConvertionDictionaryException : Exception
    {
        public ConvertionDictionaryException(string message) : base(message)
        {
        }
    }
}
