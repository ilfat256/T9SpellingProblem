using T9Library;
using Xunit;

namespace T9LibraryTests
{
    public class T9ConverterTests
    {
        [Fact]
        public void Translate_WhenInputEmpty_ReturnsEmpty()
        {
            var converter = new T9Converter();
            var result = converter.Translate(string.Empty);
            Assert.Equal(string.Empty, result);
        }

        [Theory]
        [InlineData("hi", "44 444")]
        public void Translate(string message, string translatedMessage)
        {
            var converter = new T9Converter();
            var result = converter.Translate(message);
            Assert.Equal(translatedMessage, result);
        }
    }
}
