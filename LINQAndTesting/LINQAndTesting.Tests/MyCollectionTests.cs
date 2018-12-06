using LINQAndTesting.Library;
using System;
using System.Collections.Generic;
using Xunit;

namespace LINQAndTesting.Tests
{
    // Typically one test class to test each real class
    public class MyCollectionTests
    {
        // In XUnit, each unit test, to test one thing, should be a method with the "Fact" attribute

        [Fact]  // This kind of thing is called an 'attribute', a special kind of class that adds extra behavior to a class, method, property, etc
        public void EmptyCollectionShouldHaveZeroLength()
        {
            // Arrange (set up the situation to be tested)
            // 'sut' - Subject Under Test
            var sut = new MyCollection();
            // It's already empty

            // Act (run the method/behavior that we're specifically testing)
            var result = sut.Length();

            // Assert (define what the correct result is and check that we got it)
            Assert.Equal(0, result);
        }

        // [Fact] is for tests that don't take any parameters
        // [Theory] is a convinent way to run a parameterized test with more than one set of data

        [Theory]
        [InlineData(new string[] { "a", "ab" }, "ab")]
        [InlineData(new string[] { "ab", "b" }, "ab")]
        [InlineData(new string[] { "a"}, "a")]
        [InlineData(new string[] { }, null)]
        [InlineData(new string[] { "ab", "b2" }, "ab")]
        [InlineData(new string[] { "ab", null, "a" }, "ab")]
        [InlineData(new string[] { ""}, "")]

        public void LongestShouldReturnLongest(string[] items, string expected)
        {
            // Arrange
            var coll = new MyCollection();
            foreach (var item in items)
            {
                coll.Add(item);
            }

            // Act
            var actual = coll.Longest();

            // Assert
            Assert.Equal(expected, actual);
        }

        // Test-driven development:
        // Step 1: Write test(s) that fail
        // Step 2: Write the code to make the test(s) pass

        [Fact]

    }
}
