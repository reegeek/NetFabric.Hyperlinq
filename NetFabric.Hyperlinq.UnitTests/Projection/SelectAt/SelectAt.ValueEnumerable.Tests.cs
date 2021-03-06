using NetFabric.Assertive;
using System;
using System.Linq;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests.Projection.SelectAt
{
    public class ValueEnumerableTests
    {
        [Theory]
        [MemberData(nameof(TestData.SelectorAtEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SelectorAtSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SelectorAtMultiple), MemberType = typeof(TestData))]
        public void Select_With_ValidData_Must_Succeed(int[] source, Func<int, int, string> selector)
        {
            // Arrange
            var wrapped = Wrap.AsValueEnumerable(source);
            var expected = source
                .Select(selector);

            // Act
            var result = wrapped
                .Select<Wrap.ValueEnumerableWrapper<int>, Wrap.Enumerator<int>, int, string>(selector);

            // Assert
            _ = result.Must()
                .BeEnumerableOf<string>()
                .BeEqualTo(expected);
        }
        
        [Theory]
        [MemberData(nameof(TestData.Empty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Single), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Multiple), MemberType = typeof(TestData))]
        public void Select_Sum_With_ValidData_Must_Succeed(int[] source)
        {
            // Arrange
            var wrapped = Wrap.AsValueEnumerable(source);
            var expected = source
                .Select((item, _) => item)
                .Sum();

            // Act
            var result = wrapped
                .Select<Wrap.ValueEnumerableWrapper<int>, Wrap.Enumerator<int>, int, int>((item, _) => item)
                .Sum();

            // Assert
            _ = result.Must()
                .BeEqualTo(expected);
        }
    }
}