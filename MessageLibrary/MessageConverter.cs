using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MessageLibrary
{
    public class MessageConverter
    {
        private IConvertionDictionary dictionary;
        public MessageConverter(IConvertionDictionary dictionary)
        {
            this.dictionary = dictionary ?? throw new ArgumentNullException(nameof(dictionary));
        }

        public string Translate(string message)
        {
            try
            {
                if (string.IsNullOrEmpty(message))
                {
                    return string.Empty;
                }

                char[] chars = message.ToArray();
                StringBuilder result = new StringBuilder();
                foreach (var c in chars)
                {
                    result.Append(dictionary.GetValue(c));
                }
                dictionary.Reset();
                return result.ToString();
            }
            catch (ConvertionDictionaryException ex)
            {
                throw new MessageConverterException("Translation of the message not completed correctly, check the inner exception", ex);
            }
        }
    }
}
