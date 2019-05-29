using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace FrameworkStreamliner.Tests
{
    public class StringExtensionsTests
    {
        [Fact]
        public void IsAllUpper_with_string_input_example_works()
        {
            //Arrange
            var testString = "This is a test string!";

            //Act
            var result = testString.IsAllUpper();

            //Assert
            result.Should().Be(false);
        }
        [Fact]
        public void IsAllUpper_ignores_special_characters()
        {
            //Arrange
            var testString = "TEST!#";

            //Act
            var result = testString.IsAllUpper();

            //Assert
            result.Should().Be(true);
        }

        [Fact]
        public void IsAllUpper_ignores_whitespaces()
        {
            //Arrange
            var testString = "  TEST    ";

            //Act
            var result = testString.IsAllUpper();

            //Assert
            result.Should().Be(true);
        }

        [Fact]
        public void ExtractSubstring_on_String_example_works()
        {
            //Arrange
            var testString = "This is a test string!";

            //Act
            var result = testString.ExtractSubstring(start: "This is a test ", end: "!", addToStart: "This is a test ".Count());

            //Assert
            result.Should().Be("string");
        }

        [Fact]
        public void UrlEncode_on_String_example_works()
        {
            //Arrange
            var testString = "This is a test string?";

            //Act
            var result = testString.UrlEncode();

            //Assert
            result.Should().Contain("%3F");
        }

        [Fact]
        public void UrlDecode_on_String_example_works()
        {
            //Arrange
            var testString = "This%20is%20a%20test%20string%3F";

            //Act
            var result = testString.UrlDecode();

            //Assert
            result.Should().Contain("?");
        }

        [Fact]
        public void HtmlEncode_on_String_example_works()
        {
            //Arrange
            var testString = "you > me";

            //Act
            var result = testString.HtmlEncode();

            //Assert
            result.Should().Contain("&gt;");
        }

        [Fact]
        public void HtmlDecode_on_String_example_works()
        {
            //Arrange
            var testString = "you &gt; me";

            //Act
            var result = testString.HtmlDecode();

            //Assert
            result.Should().Contain(">");
        }

        [Fact]
        public void EscapeDataString_on_String_example_works()
        {
            //Arrange
            var testString = "This is a test string +";

            //Act
            var result = testString.EscapeDataString();

            //Assert
            result.Should().Contain("%2B");
        }

        [Fact]
        public void EscapeUriString_on_String_example_works()
        {
            //Arrange
            var testString = "test\\";

            //Act
            var result = testString.EscapeUriString();

            //Assert
            result.Should().Contain("%5C");
        }

        [Fact]
        public void IsNullOrEmpty_on_String_example_works()
        {
            //Arrange
            var testString = "";

            //Act
            var result = testString.IsNullOrEmpty();

            //Assert
            result.Should().BeTrue();
        }

        [Fact]
        public void IsNullOrWhiteSpace_on_String_example_works()
        {
            //Arrange
            var testString = " ";

            //Act
            var result = testString.IsNullOrWhiteSpace();

            //Assert
            result.Should().BeTrue();
        }

        [Fact]
        public void FromBase64String_on_String_example_works()
        {
            //Arrange
            var testString = "AgQGCAoMDhASFA==";

            //Act
            var result = testString.FromBase64String();

            //Assert
            result.Count().Should().Be(10);
            result.First().Should().Be(2);
        }

        [Fact]
        public void GetUTF8Bytes_on_String_example_works()
        {
            //Arrange
            var testString = "string";

            //Act
            var result = testString.GetUTF8Bytes();

            //Assert
            result.Count().Should().Be(6);
            result.First().Should().Be(115);
        }

        [Fact]
        public void TryParseInt_on_String_example_works()
        {
            //Arrange
            var testString = "1234";

            //Act
            var result = testString.TryParseInt();

            //Assert
            result.Should().Be(1234);
        }

        [Fact]
        public void TryParseLong_on_String_example_works()
        {
            //Arrange
            var testString = "1234";

            //Act
            var result = testString.TryParseLong();

            //Assert
            result.Should().Be(1234);
        }

        [Fact]
        public void Ellipsize_on_String_example_works()
        {
            //Arrange
            var testString = "This is a test string!";
            int maxLen = 14;

            //Act
            var result = testString.Ellipsize(maxLen);

            //Assert
            result.Length.Should().Be(14);
            result.Should().Contain("...");
        }

        [Fact]
        public void AddNow_on_String_example_works()
        {
            //Arrange
            var testString = "This is a test string!";

            //Act
            var result = testString.AddNow();

            //Assert
            result.Length.Should().BeGreaterThan(testString.Length);
        }
    }
}
