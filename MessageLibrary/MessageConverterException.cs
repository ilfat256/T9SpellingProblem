﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageLibrary
{
    public class MessageConverterException : Exception
    {
        public MessageConverterException(string message) : base(message) {}
        public MessageConverterException(string message, Exception exception) : base(message, exception) { }
    }
}
