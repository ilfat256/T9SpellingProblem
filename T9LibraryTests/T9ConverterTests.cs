using System;
using System.Collections.Generic;
using System.Linq;
using T9Library;
using Xunit;

namespace T9LibraryTests
{
    public class T9ConverterTests
    {
        [Fact]
        public void T9Converter_WhenDictionaryIsNull_ThrowsArgumentNullException()
        {
            Action act = () => new T9Converter(null);
            Assert.Throws<ArgumentNullException>("t9Dictionary", act);
        }

        [Fact]
        public void Translate_WhenInputEmpty_ReturnsEmpty()
        {
            var converter = new T9Converter(T9Dictionary);
            var result = converter.Translate(string.Empty);
            Assert.Equal(string.Empty, result);
        }

        [Theory]
        [InlineData("hi", "44 444")]
        [InlineData("yes", "999337777")]
        [InlineData("foo  bar", "333666 6660 022 2777")]
        [InlineData("hello world", "4433555 555666096667775553")]
        public void TranslateTheory(string message, string translatedMessage)
        {
            var converter = new T9Converter(T9Dictionary);
            var result = converter.Translate(message);
            Assert.Equal(translatedMessage, result);
        }

        [Theory]
        [MemberData(nameof(GetT9Dictionary))]
        public void Translate1(char symbol, string digitsRepresentation)
        {
            var converter = new T9Converter(T9Dictionary);
            var result = converter.Translate(symbol.ToString());
            Assert.Equal(digitsRepresentation, result);
        }

        public static IEnumerable<object[]> GetT9Dictionary()
        {
            //foreach (var item in T9Dictionary.Skip(scipCasesForDebugging))
                foreach (var item in T9Dictionary)
            {
                yield return new object[] { item.Key, item.Value };
            }
        }

        public static Dictionary<char, string> T9Dictionary = new Dictionary<char, string>
        {
            { 'a', "2" },
            { 'b', "22" },
            { 'c', "222" },
            { 'd', "3" },
            { 'e', "33" },
            { 'f', "333" },
            { 'g', "4" },
            { 'h', "44" },
            { 'i', "444" },
            { 'j', "5" },
            { 'k', "55" },
            { 'l', "555" },
            { 'm', "6" },
            { 'n', "66" },
            { 'o', "666" },
            { 'p', "7" },
            { 'q', "77" },
            { 'r', "777" },
            { 's', "7777" },
            { 't', "8" },
            { 'u', "88" },
            { 'v', "888" },
            { 'w', "9" },
            { 'x', "99" },
            { 'y', "999" },
            { 'z', "9999" },
            { ' ', "0" },
        };
    }
}
