namespace BrakeDiskPlugin.Model.UnitTests
{
    using BrakeDiskPlugin.Model.Parameters;
    using NUnit.Framework;

    internal class BrakeDiskTests
    {
        [TestCase(
            ParameterType.BrakeDiskDiameter,
            300.0,
            TestName = "GetValue should return set value for BrakeDiskDiameter.")]
        public void GetValue_ReturnsSetValue_PositiveTest(
            ParameterType parameterType,
            double expectedValue)
        {
            // Arrange
            var brakeDisk = new BrakeDisk();

            // Act
            brakeDisk.SetValue(parameterType, expectedValue);
            var actualValue = brakeDisk.GetValue(parameterType);

            // Assert
            Assert.AreEqual(
                expectedValue,
                actualValue,
                $"GetValue should return set value for {parameterType}.");
        }

        [Test]
        [TestCase(
            ParameterType.BrakeDiskDiameter,
            300.0,
            TestName = "SetValue should set BrakeDiskDiameter within valid range.")]
        [TestCase(
            ParameterType.WidthWorkingSurface,
            20.0,
            TestName = "SetValue should set WidthWorkingSurface within valid range.")]
        [TestCase(
            ParameterType.LargerFastenerDiameter,
            120.0,
            TestName = "SetValue should set LargerFastenerDiameter within valid range.")]
        [TestCase(
            ParameterType.WidthLargerFastener,
            30.0,
            TestName = "SetValue should set WidthLargerFastener within valid range.")]
        [TestCase(
            ParameterType.CenteringDiameter,
            30.0,
            TestName = "SetValue should set CenteringDiameter within valid range.")]
        public void SetValue_SetsParameterValueWithinValidRange(
            ParameterType parameterType,
            double value)
        {
            // Arrange
            var brakeDisk = new BrakeDisk();

            // Act
            brakeDisk.SetValue(parameterType, value);

            // Assert
            var actualValue = brakeDisk.GetValue(parameterType);
            Assert.AreEqual(value, actualValue, $"SetValue should set {parameterType} to {value}.");
        }
    }
}