using MessageLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using T9Library;
using Xunit;

namespace T9LibraryTests
{
    public class T9DictionaryTests
    {
        [Fact]
        public void GetValue9_ThrowsT9ConverterException()
        {
            var dict = T9Dictionary.CreateFrom(dictionary);
            var c = '9';
            Action act = () => dict.GetValue(c);

            Exception ex = Assert.Throws<ConvertionDictionaryException>(act);
            Assert.Equal($"Dictionary doesn't contain char '{c}'", ex.Message);
        }

        public static Dictionary<char, int[]> dictionary = new Dictionary<char, int[]>
        {
            { 'a', new int[] { 2 }},
            { 'b', new int[] { 2, 2 }},
        };
    }
}
