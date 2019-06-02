using MessageLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using T9Library;
using Xunit;

namespace T9LibraryTests
{
    public class MessageConverterTests
    {
        [Fact]
        public void Translate_WhenDictionaryIsNull_ThrowsArgumentNullException()
        {
            Action act = () => new MessageConverter(null);
            Assert.Throws<ArgumentNullException>("dictionary", act);
        }

        [Fact]
        public void Translate_WhenInputContains9_ThrowsMessageConverterException()
        {
            var converter = new MessageConverter(Dictionary);
            var message = "9";
            Action act = () => converter.Translate(message);

            Exception ex = Assert.Throws<MessageConverterException>(act);
            Assert.NotNull(ex.InnerException);
            Assert.Equal($"Translation of the message not completed correctly, check the inner exception", ex.Message);
        }

        [Fact]
        public void Translate_WhenInputEmpty_ReturnsEmpty()
        {
            var converter = new MessageConverter(Dictionary);
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
            var converter = new MessageConverter(Dictionary);
            var result = converter.Translate(message);
            Assert.Equal(translatedMessage, result);
        }

        [Theory]
        [MemberData(nameof(GetDictionary))]
        public void Translate_DictionarySymbols(char symbol, string digitsRepresentation)
        {
            var converter = new MessageConverter(Dictionary);
            var result = converter.Translate(symbol.ToString());
            Assert.Equal(digitsRepresentation, result);
        }

        public static IEnumerable<object[]> GetDictionary()
        {
            foreach (var item in Dictionary)
            {
                yield return new object[] { item.Key, item.Value.ToString() };
            }
        }

        public static T9Dictionary Dictionary = T9Dictionary.CreateFrom(new Dictionary<char, int[]>
        {
            { 'a', new int[] { 2 }},
            { 'b', new int[] { 2, 2 }},
            { 'c', new int[] { 2, 2, 2 }},
            { 'd', new int[] { 3 }},
            { 'e', new int[] { 3, 3 }},
            { 'f', new int[] { 3, 3, 3 }},
            { 'g', new int[] { 4 }},
            { 'h', new int[] { 4, 4 }},
            { 'i', new int[] { 4, 4, 4 }},
            { 'j', new int[] { 5 }},
            { 'k', new int[] { 5, 5 }},
            { 'l', new int[] { 5, 5, 5 }},
            { 'm', new int[] { 6 }},
            { 'n', new int[] { 6, 6 }},
            { 'o', new int[] { 6, 6, 6 }},
            { 'p', new int[] { 7 }},
            { 'q', new int[] { 7, 7 }},
            { 'r', new int[] { 7, 7, 7 }},
            { 's', new int[] { 7, 7, 7, 7 }},
            { 't', new int[] { 8 }},
            { 'u', new int[] { 8, 8 }},
            { 'v', new int[] { 8, 8, 8 }},
            { 'w', new int[] { 9 }},
            { 'x', new int[] { 9, 9 }},
            { 'y', new int[] { 9, 9, 9 }},
            { 'z', new int[] { 9, 9, 9, 9 }},
            { ' ', new int[] { 0 }},
        });
    }
}
