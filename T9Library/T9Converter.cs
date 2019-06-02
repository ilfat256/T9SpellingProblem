using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T9Library
{
    public class T9Converter
    {
        private Dictionary<char, string> t9Dictionary;
        public T9Converter(Dictionary<char, string> t9Dictionary)
        {
            this.t9Dictionary = t9Dictionary ?? throw new ArgumentNullException(nameof(t9Dictionary));
        }

        public string Translate(string message)
        {
            if (string.IsNullOrWhiteSpace(message))
            {
                return string.Empty;
            }

            char[] chars = message.ToArray();
            StringBuilder result = new StringBuilder();
            foreach (var c in chars)
            {
                string digits;
                if (t9Dictionary.TryGetValue(c, out digits))
                {
                    result.Append(digits);
                }
                else
                {
                    new T9ConverterException($"Dictionary doesn't contain char '{c}'");
                }
            }

            return result.ToString();
        }
    }
}
