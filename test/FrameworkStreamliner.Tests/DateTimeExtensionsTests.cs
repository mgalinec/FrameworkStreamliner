using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace FrameworkStreamliner.Tests
{
    public class DateTimeExtensionsTests
    {
        [Fact]
        public void ToInt_on_DateTime_example_works()
        {
            //Arrange
            var testDate = DateTime.Now;

            //Act
            var result = testDate.ToInt();

            //Assert
            result.ToString().Should().Contain(testDate.Year.ToString());
        }

        [Fact]
        public void EnumDays_on_two_given_DateTimes_example_works()
        {
            //Arrange
            var testDate = DateTime.Now;
            var toDate = testDate.AddDays(10);

            //Act
            var result = testDate.EnumDays(toDate);

            //Assert
            result.Count().Should().Be(11);
        }

        [Fact]
        public void EnumDays_on_two_same_given_DateTimes_should_return_only_that_DateTime()
        {
            //Arrange
            var testDate = DateTime.Now;
            var toDate = testDate;

            //Act
            var result = testDate.EnumDays(toDate);

            //Assert
            result.Should().BeEquivalentTo(testDate);
        }
    }
}
