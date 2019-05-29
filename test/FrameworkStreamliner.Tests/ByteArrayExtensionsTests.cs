using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace FrameworkStreamliner.Tests
{
    public class ByteArrayExtensionsTests
    {
        [Fact]
        public void ToBase64String_example_works()
        {
            //Act
            var testBytes = new byte[] { 1, 2, 1, 3, 4 };
            var resultString = testBytes.ToBase64String();

            //Assert
            resultString.Should().Be("AQIBAwQ=");
        }

        [Fact]
        public void ToBase64String_should_return_Base64String()
        {
            //Arrange
            var testBytes = new byte[] { 1, 2, 1, 3, 4 };

            //Act
            var resultString = testBytes.ToBase64String();

            //Assert
            resultString.Should().Be(Convert.ToBase64String(testBytes));
        }

        [Fact]
        public void ToBase64String_should_return_null_given_null()
        {
            //Arrange
            byte[] testBytes = null;

            //Act
            var resultString = testBytes.ToBase64String();

            //Assert
            resultString.Should().Be(null);
        }

        [Fact]
        public void ToBase64String_should_return_null_given_empty_array()
        {
            //Arrange
            byte[] testBytes = new byte[0];

            //Act
            var resultString = testBytes.ToBase64String();

            //Assert
            resultString.Should().Be(null);
        }

        [Fact]
        public void CompressGZip_example_works()
        {
            //Act
            byte[] testBytes = Encoding.UTF8.GetBytes("This string will be compressed using gz compression.");
            var resultBytes = testBytes.CompressGZip();
            var resultString = Encoding.UTF8.GetString(resultBytes);
            //Assert
            resultString.Should().Equals("\u001f�\b\0\0\0\0\0\u0004\0\v��,V(.)��KW(���QHJUH��-(J-.NMQ(-\u0006I�W��2���\0�\u0016\u000354\0\0\0");
        }

        [Fact]
        public void DecompressGZip_should_return_same_utf8byte_string_that_is_compressed_with_CompressGZip()
        {
            //Arrange          
            byte[] testBytes = Encoding.UTF8.GetBytes("Test kompresije");
            var compress = testBytes.CompressGZip();

            //Act
            var decompress = compress.DecompressGZip();

            //Assert
            decompress.Should().Equal(testBytes);
        }

        [Fact]
        public void DecompressGZip_example_works()
        {
            //Act
            byte[] testBytes = Encoding.UTF8.GetBytes("This string will be compressed using gz compression.");
            var compressedBytes = testBytes.CompressGZip();
            var compressedString = Encoding.UTF8.GetString(compressedBytes);
            var resultBytes = compressedBytes.DecompressGZip();
            var resultString = Encoding.UTF8.GetString(resultBytes);

            //Assert
            resultString.Should().Equals("This string will be compressed using gz compression.");
            compressedString.Should().Equals("\u001f�\b\0\0\0\0\0\u0004\0\v��,V(.)��KW(���QHJUH��-(J-.NMQ(-\u0006I�W��2���\0�\u0016\u000354\0\0\0");
        }

        [Theory]
        [InlineData("test")]
        [InlineData(null)]
        [InlineData("\"")]
        [InlineData("")]
        public void GetUTF8String_should_return_UTF8String(string testString)
        {
            byte[] testBytes = null;
            if (testString != null)
            {
                testBytes = Encoding.UTF8.GetBytes(testString);
            }

            var resultString = testBytes.GetUTF8String();

            resultString.Should().Be(testString);
        }

        [Fact]
        public void GetUTF8String_example_works()
        {
            //Act
            byte[] testBytes = Encoding.UTF8.GetBytes("test");
            var resultBytes = testBytes.GetUTF8String();
            var resultString = Encoding.UTF8.GetString(testBytes);

            //Assert
            /// while resultBytes equals 
            resultString.Should().Equals("test");
            resultBytes.Should().Equals(new byte[] { 116, 101, 115, 116 });
        }

    }
}
