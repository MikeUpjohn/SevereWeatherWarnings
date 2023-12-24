using SevereWeatherWarnings.Library.Extensions;

namespace SevereWeatherWarnings.Library.Tests.Extensions
{
    public class StringExtensionsTests
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void GivenEmptyOrNullString_WhenToDisplayFormat_ThenResultIsNotNull(string text)
        {
            var result = text.ToHtmlTrimmedString();

            Assert.NotNull(result);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void GivenEmptyOrNullString_WhenToDisplayFormat_ThenResultIsEmptyString(string text)
        {
            var result = text.ToHtmlTrimmedString();

            var expected = string.Empty;
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("The quick brown fox jumps over the lazy dog")]
        [InlineData("The quick brown fox jumps over the lazy dog ")]
        [InlineData(" The quick brown fox jumps over the lazy dog")]
        [InlineData(" The quick brown fox jumps over the lazy dog ")]
        public void GivenStringWithWhitespace_WhenToDisplayFormat_ThenResultIsTrimmed(string text)
        {
            var result = text.ToHtmlTrimmedString();

            var expected = "The quick brown fox jumps over the lazy dog";
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("The quick brown fox jumps over the lazy dog\n", "The quick brown fox jumps over the lazy dog<br />")]
        [InlineData("\nThe quick brown fox jumps over the lazy dog", "<br />The quick brown fox jumps over the lazy dog")]
        [InlineData("\nThe quick brown fox jumps over the lazy dog\n", "<br />The quick brown fox jumps over the lazy dog<br />")]
        [InlineData("\nThe quick brown fox\njumps over the lazy dog\n", "<br />The quick brown fox<br />jumps over the lazy dog<br />")]
        public void GivenStringWithNewLines_WhenToDisplayFormat_ThenResultContainsHtmlBRTag(string text, string expected)
        {
            var result = text.ToHtmlTrimmedString();

            Assert.Equal(expected, result);
        }
    }
}
