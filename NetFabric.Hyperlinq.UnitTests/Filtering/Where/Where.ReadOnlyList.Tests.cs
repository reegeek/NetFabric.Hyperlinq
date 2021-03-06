using NetFabric.Assertive;
using System;
using System.Linq;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests.Filtering.Where
{
    public class ReadOnlyListTests
    {
        [Theory]
        [MemberData(nameof(TestData.SkipTakePredicateEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipTakePredicateSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipTakePredicateMultiple), MemberType = typeof(TestData))]
        public void Where_With_ValidData_Must_Succeed(int[] source, int skip, int take, Func<int, bool> predicate)
        {
            // Arrange
            var wrapped = Wrap
                .AsReadOnlyList(source);
            var expected = source
                .Skip(skip)
                .Take(take)
                .Where(predicate);

            // Act
            var result = wrapped.AsValueEnumerable()
                .Skip(skip)
                .Take(take)
                .Where(predicate);


            // Assert
            _ = result.Must()
                .BeEnumerableOf<int>()
                .BeEqualTo(expected);
        }
        
        [Theory]
        [MemberData(nameof(TestData.SkipTakePredicateEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipTakePredicateSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipTakePredicateMultiple), MemberType = typeof(TestData))]
        public void Where_Sum_With_ValidData_Must_Succeed(int[] source, int skip, int take, Func<int, bool> predicate)
        {
            // Arrange
            var wrapped = Wrap
                .AsReadOnlyList(source);
            var expected = source
                .Skip(skip)
                .Take(take)
                .Where(predicate)
                .Sum();

            // Act
            var result = wrapped.AsValueEnumerable()
                .Skip(skip)
                .Take(take)
                .Where(predicate)
                .Sum();


            // Assert
            _ = result.Must()
                .BeEqualTo(expected);
        }
    }
}