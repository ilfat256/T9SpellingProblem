using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T9Library
{
    public class MessageConverter
    {
        private Dictionary<char, ButtonCombination> dictionary;
        public MessageConverter(Dictionary<char, ButtonCombination> t9Dictionary)
        {
            this.dictionary = t9Dictionary ?? throw new ArgumentNullException(nameof(t9Dictionary));
        }

        public string Translate(string message)
        {
            if (string.IsNullOrEmpty(message))
            {
                return string.Empty;
            }

            char[] chars = message.ToArray();
            StringBuilder result = new StringBuilder();
            foreach (var c in chars)
            {
                result.Append(GetStringPresentationOfChar(c));
            }

            return result.ToString();
        }

        private string GetStringPresentationOfChar(char c)
        {
            ButtonCombination combination;
            if (dictionary.TryGetValue(c, out combination))
            {
                return combination.ToString();
            }
            else
            {
                throw new MessageConverterException($"Dictionary doesn't contain char '{c}'");
            }
        }
    }
}
