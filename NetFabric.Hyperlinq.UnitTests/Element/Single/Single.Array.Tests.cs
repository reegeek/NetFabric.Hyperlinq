using NetFabric.Assertive;
using System;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests
{
    public class SingleArrayTests
    {
        [Theory]
        [MemberData(nameof(TestData.Empty), MemberType = typeof(TestData))]
        public void Single_With_Empty_Should_Throw(int[] source)
        {
            // Arrange

            // Act
            Action action = () => 
                Array.Single<int>(source);

            // Assert
            action.Must()
                .Throw<InvalidOperationException>()
                .EvaluateTrue(exception => exception.Message == "Sequence contains no elements");
        }

        [Theory]
        [MemberData(nameof(TestData.SinglePredicateEmpty), MemberType = typeof(TestData))]
        public void SinglePredicate_With_Empty_Should_Throw(int[] source, Predicate<int> predicate)
        {
            // Arrange

            // Act
            Action action = () => 
                Array.Single<int>(source, predicate);

            // Assert
            action.Must()
                .Throw<InvalidOperationException>()
                .EvaluateTrue(exception => exception.Message == "Sequence contains no elements");
        }

        [Theory]
        [MemberData(nameof(TestData.Single), MemberType = typeof(TestData))]
        public void Single_With_ValidData_Should_Succeed(int[] source)
        {
            // Arrange
            var expected = 
                System.Linq.Enumerable.Single(source);

            // Act
            var result = Array
                .Single<int>(source);

            // Assert
            result.Must()
                .BeEqualTo(expected);
        }

        [Theory]
        [MemberData(nameof(TestData.SinglePredicateSingle), MemberType = typeof(TestData))]
        public void SinglePredicate_With_ValidData_Should_Succeed(int[] source, Predicate<int> predicate)
        {
            // Arrange
            var expected = 
                System.Linq.Enumerable.Single(source, predicate.AsFunc());

            // Act
            var result = Array
                .Single<int>(source, predicate);

            // Assert
            result.Must()
                .BeEqualTo(expected);
        }

        [Theory]
        [MemberData(nameof(TestData.Multiple), MemberType = typeof(TestData))]
        public void Single_With_Multiple_Should_Throw(int[] source)
        {
            // Arrange

            // Act
            Action action = () => 
                Array.Single<int>(source);

            // Assert
            action.Must()
                .Throw<InvalidOperationException>()
                .EvaluateTrue(exception => exception.Message == "Sequence contains more than one element");
        }

        [Theory]
        [MemberData(nameof(TestData.SinglePredicateMultiple), MemberType = typeof(TestData))]
        public void SinglePredicate_With_Multiple_Should_Throw(int[] source, Predicate<int> predicate)
        {
            // Arrange

            // Act
            Action action = () => 
                Array.Single<int>(source, predicate);

            // Assert
            action.Must()
                .Throw<InvalidOperationException>()
                .EvaluateTrue(exception => exception.Message == "Sequence contains more than one element");
        }
    }
}