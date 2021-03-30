using bedste_boligoverblik.core.Extensions;
using Xunit;

namespace bedste_boligoverblik.core.test.Extensions
{
    public class StringExtensionsTest
    {
        private const string VALUE_NULL = null;
        private const string VALUE_NO_DECIMALS = "3616362";
        private const string VALUE_MANY_DECIMALS = "3616362.68123456205182004719972610473632812512345";
        private const string VALUE_FEWER_DECIMALS = "3616362.6";


        [Fact]
        public void ToDecimal_Should_Return_Value_When_Null()
        {
            // Arrange 
            const decimal expected = 0m;

            // Act
            var actual = VALUE_NULL.ToDecimal();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ToDecimal_Should_Return_Value_When_No_Decimals()
        {
            // Arrange 
            const decimal expected = 3616362.00m;

            // Act
            var actual = VALUE_NO_DECIMALS.ToDecimal();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ToDecimal_Should_Return_Value_When_Many_Decimals()
        {
            // Arrange 
            const decimal expected = 3616362.68m;

            // Act
            var actual = VALUE_MANY_DECIMALS.ToDecimal();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ToDecimal_Should_Return_Value_When_Many_Fewer_Decimals()
        {
            // Arrange 
            const decimal expected = 3616362.60m;

            // Act
            var actual = VALUE_FEWER_DECIMALS.ToDecimal();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ToDecimal_Should_Return_Value_When_Decimals_Specified_With_Many_decimals()
        {
            // Arrange 
            const decimal expected = 3616362.681m;

            // Act
            var actual = VALUE_MANY_DECIMALS.ToDecimal(3);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ToDecimal_Should_Return_Value_When_Decimals_Specified_With_Fewer_decimals()
        {
            // Arrange 
            const decimal expected = 3616362.600m;

            // Act
            var actual = VALUE_FEWER_DECIMALS.ToDecimal(3);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}