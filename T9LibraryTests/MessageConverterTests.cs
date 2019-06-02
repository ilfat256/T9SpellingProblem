using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace MessageLibrary
{
    public class MessageConverterTests
    {
        [Fact]
        public void MessageConverterWhenDictionaryIsNull_ThrowsArgumentNullException()
        {
            Action act = () => new MessageConverter(null);
            Assert.Throws<ArgumentNullException>("dictionary", act);
        }

        [Fact]
        public void MessageConverterWhenInputContains9_ThrowsT9ConverterException()
        {
            var converter = new MessageConverter(T9Dictionary);
            var message = "9";
            Action act = () => converter.Translate(message);

            Exception ex = Assert.Throws<MessageConverterException>(act);
            Assert.Equal($"Dictionary doesn't contain char '{message}'", ex.Message);
        }

        [Fact]
        public void Translate_WhenInputEmpty_ReturnsEmpty()
        {
            var converter = new MessageConverter(T9Dictionary);
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
            var converter = new MessageConverter(T9Dictionary);
            var result = converter.Translate(message);
            Assert.Equal(translatedMessage, result);
        }

        [Theory]
        [MemberData(nameof(GetT9Dictionary))]
        public void Translate1(char symbol, string digitsRepresentation)
        {
            var converter = new MessageConverter(T9Dictionary);
            var result = converter.Translate(symbol.ToString());
            Assert.Equal(digitsRepresentation, result);
        }

        public static IEnumerable<object[]> GetT9Dictionary()
        {
            foreach (var item in T9Dictionary)
            {
                yield return new object[] { item.Key, item.Value.ToString() };
            }
        }

        public static Dictionary<char, ButtonCombination> T9Dictionary = new Dictionary<char, ButtonCombination>
        {
            { 'a', ButtonCombination.CreateFromDigits(2) },
            { 'b', ButtonCombination.CreateFromDigits(2, 2) },
            { 'c', ButtonCombination.CreateFromDigits(2, 2, 2) },
            { 'd', ButtonCombination.CreateFromDigits(3) },
            { 'e', ButtonCombination.CreateFromDigits(3, 3) },
            { 'f', ButtonCombination.CreateFromDigits(3, 3, 3) },
            { 'g', ButtonCombination.CreateFromDigits(4) },
            { 'h', ButtonCombination.CreateFromDigits(4, 4) },
            { 'i', ButtonCombination.CreateFromDigits(4, 4, 4) },
            { 'j', ButtonCombination.CreateFromDigits(5) },
            { 'k', ButtonCombination.CreateFromDigits(5, 5) },
            { 'l', ButtonCombination.CreateFromDigits(5, 5, 5) },
            { 'm', ButtonCombination.CreateFromDigits(6) },
            { 'n', ButtonCombination.CreateFromDigits(6, 6) },
            { 'o', ButtonCombination.CreateFromDigits(6, 6, 6) },
            { 'p', ButtonCombination.CreateFromDigits(7) },
            { 'q', ButtonCombination.CreateFromDigits(7, 7) },
            { 'r', ButtonCombination.CreateFromDigits(7, 7, 7) },
            { 's', ButtonCombination.CreateFromDigits(7, 7, 7, 7) },
            { 't', ButtonCombination.CreateFromDigits(8) },
            { 'u', ButtonCombination.CreateFromDigits(8, 8) },
            { 'v', ButtonCombination.CreateFromDigits(8, 8, 8) },
            { 'w', ButtonCombination.CreateFromDigits(9) },
            { 'x', ButtonCombination.CreateFromDigits(9, 9) },
            { 'y', ButtonCombination.CreateFromDigits(9, 9, 9) },
            { 'z', ButtonCombination.CreateFromDigits(9, 9, 9, 9) },
            { ' ', ButtonCombination.CreateFromDigits(0) },
        };
    }
}
