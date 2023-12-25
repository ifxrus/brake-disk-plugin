namespace BrakeDiskPlugin.Model.UnitTests
{
    using BrakeDiskPlugin.Model.Validators;
    using NUnit.Framework;

    /// <summary>
    /// Unit tests for the <see cref="ParametersValidator"/> class.
    /// </summary>
    [TestFixture]
    internal class ParametersValidatorTests
    {
        [TestCase(
            5.0,
            0.0,
            10.0,
            true,
            TestName = "ValidateRangeCompliance returns true for value within the range.")]
        [TestCase(
            15.0,
            0.0,
            10.0,
            false,
            TestName = "ValidateRangeCompliance returns false for value outside the range.")]
        [TestCase(
            5.0,
            0.0,
            5.0,
            true,
            TestName = "ValidateRangeCompliance returns true for value equal to maxValue.")]
        [TestCase(
            0.0,
            0.0,
            5.0,
            true,
            TestName = "ValidateRangeCompliance returns true for value equal to minValue.")]
        public void ValidateRangeCompliance_ReturnsExpectedResult(
            double value,
            double minValue,
            double maxValue,
            bool expectedResult)
        {
            // Act
            var result = ParametersValidator.ValidateRangeCompliance(value, minValue, maxValue);

            // Assert
            Assert.AreEqual(
                expectedResult,
                result,
                $"ValidateRangeCompliance should return {expectedResult} for the given input.");
        }

        [TestCase(
            0.0,
            5.0,
            true,
            TestName =
                "ValidateValueLower returns true for minValue less than or equal to maxValue.")]
        [TestCase(
            10.0,
            5.0,
            false,
            TestName = "ValidateValueLower returns false for minValue greater than maxValue.")]
        public void ValidateValueLower_ReturnsExpectedResult(
            double minValue,
            double maxValue,
            bool expectedResult)
        {
            // Act
            var result = ParametersValidator.ValidateValueLower(minValue, maxValue);

            // Assert
            Assert.AreEqual(
                expectedResult,
                result,
                $"ValidateValueLower should return {expectedResult} for the given input.");
        }
    }
}