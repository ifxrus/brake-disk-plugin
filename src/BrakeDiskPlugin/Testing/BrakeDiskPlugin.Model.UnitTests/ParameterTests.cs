namespace BrakeDiskPlugin.Model.UnitTests
{
    using BrakeDiskPlugin.Model.Parameters;
    using NUnit.Framework;

    /// <summary>
    /// Unit tests for the <see cref="Parameter"/> class.
    /// </summary>
    [TestFixture]
    internal class ParameterTests
    {
        [Test]
        public void Parameter_Constructor_InitializesPropertiesCorrectly()
        {
            // Arrange
            var minValue = 0.0;
            var maxValue = 10.0;
            var value = 5.0;

            // Act
            var parameter = new Parameter(value, minValue, maxValue);

            // Assert
            Assert.AreEqual(
                minValue,
                parameter.MinValue,
                "Constructor should initialize MinValue correctly.");
            Assert.AreEqual(
                maxValue,
                parameter.MaxValue,
                "Constructor should initialize MaxValue correctly.");
            Assert.AreEqual(
                value,
                parameter.Value,
                "Constructor should initialize Value correctly.");
        }

        [Test]
        [TestCase(5, 10, 5, TestName = "Valid values")]
        [TestCase(5, 15, 10, TestName = "Invalid values")]
        public void Parameter_Constructor_ThrowsArgumentException(
            double value,
            double minValue,
            double maxValue)
        {
            // Act & Assert
            Assert.Throws<ArgumentException>(() => new Parameter(value, minValue, maxValue));
        }

        [TestCase(5.0, 0.0, 10.0, true, TestName = "SetValue sets Value within the valid range.")]
        [TestCase(
            15.0,
            0.0,
            10.0,
            false,
            TestName = "SetValue throws ArgumentException for value outside the range.")]
        // TODO: не используются minValue и maxValue
        public void SetValue_SetsValueCorrectly(
            double value,
            double minValue,
            double maxValue,
            bool isValidValue)
        {
            // Arrange
            var parameter = new Parameter(0.0, 0.0, 10.0);

            // Act & Assert
            if (isValidValue)
            {
                Assert.DoesNotThrow(
                    () => parameter.Value = value,
                    "SetValue should set Value without throwing an exception.");
                Assert.AreEqual(value, parameter.Value, "SetValue should set Value correctly.");
            }
            else
            {
                Assert.Throws<ArgumentException>(
                    () => parameter.Value = value,
                    "SetValue should throw ArgumentException for invalid value.");
            }
        }

        [TestCase(
            15.0,
            10.0,
            20.0,
            true,
            TestName = "Constructor initializes properties with valid values.")]
        [TestCase(
            9.0,
            10.0,
            15.0,
            false,
            TestName = "Constructor throws ArgumentException for invalid values.")]
        public void Constructor_InitializesPropertiesCorrectly(
            double value,
            double minValue,
            double maxValue,
            bool isValidValues)
        {
            // Act & Assert
            if (isValidValues)
            {
                Assert.DoesNotThrow(
                    () => new Parameter(value, minValue, maxValue),
                    "Constructor should not throw ArgumentException for valid values.");
            }
            else
            {
                Assert.Throws<ArgumentException>(
                    () => new Parameter(value, minValue, maxValue),
                    "Constructor should throw ArgumentException for invalid values.");
            }
        }
    }
}