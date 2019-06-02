using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MessageLibrary
{
    public class MessageConverter
    {
        private Dictionary<char, ButtonCombination> dictionary;
        public MessageConverter(Dictionary<char, ButtonCombination> dictionary)
        {
            this.dictionary = dictionary ?? throw new ArgumentNullException(nameof(dictionary));
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
