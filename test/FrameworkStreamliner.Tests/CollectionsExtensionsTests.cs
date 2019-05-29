using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace FrameworkStreamliner.Tests
{
    public class CollectionsExtensionsTests
    {
        [Fact]
        public void RandomItem_on_list_should_return_at_least_two_different_items_from_five_tries()
        {
            //Arrange
            var testList = new List<int> { 1, 2, 3, 4, 5 };

            //Act
            var result1 = testList.RandomItem();
            var result2 = testList.RandomItem();
            var result3 = testList.RandomItem();
            var result4 = testList.RandomItem();
            var result5 = testList.RandomItem();

            //Assert
            testList.Should().Contain(result1);
            testList.Should().Contain(result2);
            testList.Should().Contain(result3);
            testList.Should().Contain(result4);
            testList.Should().Contain(result5);
            (result1 != result2 || result1 != result3 || result1 != result4 || result1 != result5
                || result2 != result3 || result2 != result4 || result2 != result5 || result3 != result4 || result3 != result5 || result4 != result5).Should().BeTrue();
        }

        [Fact]
        public void RandomItem_on_ienumerable_example_works()
        {
            //Act
            var testIEnumerable = new List<int>() { 1, 2, 1, 3, 4 };
            var result = testIEnumerable.RandomItem();

            //Assert
            result.Should().BeOneOf(1, 2, 3, 4);
        }

        [Fact]
        public void Sample_on_ilist_example_works()
        {
            //Act
            var testIList = new List<int>() { 1, 2, 1, 3, 4 };
            int count = 2;
            var result = testIList.Sample(count);

            //Assert
            result.Should().BeSubsetOf(testIList);
        }

        [Fact]
        public void Randomize_on_ilist_example_works()
        {
            //Arrange
            var testList = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };

            //Act
            var resultList1 = testList.ToList().Randomize();

            //Assert
            resultList1.SequenceEqual(testList).Should().BeFalse();

        }

        [Fact]
        public void NullableSequenceEqual_on_two_null_sequences_should_return_true()
        {
            //Arrange
            List<int> firstSequence = null;
            List<int> secondSequence = null;
            //Act
            var result = firstSequence.NullableSequenceEqual(secondSequence);

            //Assert
            result.Should().BeTrue();

        }

        [Fact]
        public void NullableSequenceEqual_on_two_same_sequences_should_return_true()
        {
            //Arrange
            List<int> firstSequence = new List<int> { 1, 2, 3 };
            List<int> secondSequence = new List<int> { 1, 2, 3 };
            //Act
            var result = firstSequence.NullableSequenceEqual(secondSequence);

            //Assert
            result.Should().BeTrue();

        }

        [Fact]
        public void NullableSequenceEqual_on_two_different_sequences_should_return_false()
        {
            //Arrange
            List<int> firstSequence = new List<int> { 3, 1, 2 };
            List<int> secondSequence = new List<int> { 1, 2, 3 };
            //Act
            var result = firstSequence.NullableSequenceEqual(secondSequence);

            //Assert
            result.Should().BeFalse();

        }
    }
}
