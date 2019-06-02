using MessageLibrary;
using System.Collections.Generic;

namespace T9Library
{
    public class T9Dictionary : IConvertionDictionary
    {
        private Dictionary<char, T9ButtonCombination> dictionary = new Dictionary<char, T9ButtonCombination>();
        private T9Dictionary() {}
        private const string pauseSymbol = " ";

        public static T9Dictionary CreateFrom(Dictionary<char, int[]> dict)
        {
            var t9Dictionary = new T9Dictionary();
            foreach (var item in dict)
            {
                t9Dictionary.Add(item.Key, T9ButtonCombination.CreateFromDigits(item.Value));
            }

            return t9Dictionary;
        }

        public void Add(char c, T9ButtonCombination buttons)
        {
            dictionary.Add(c, buttons);
        }

        public System.Collections.Generic.Dictionary<char, T9ButtonCombination>.Enumerator GetEnumerator()
        {
            return dictionary.GetEnumerator();
        }

        private T9ButtonCombination previousChar = null;
        public string GetValue(char c)
        {
            T9ButtonCombination combination;
            if (dictionary.TryGetValue(c, out combination))
            {
                string result = string.Empty;

                if (previousChar != null && previousChar.ShouldWaitPause(combination))
                    result += pauseSymbol;
                result += combination.ToString();

                previousChar = combination;
                return result;
            }
            else
            {
                throw new ConvertionDictionaryException($"Dictionary doesn't contain char '{c}'");
            }
        }

        public void Reset()
        {
            previousChar = null;
        }
    }
}
