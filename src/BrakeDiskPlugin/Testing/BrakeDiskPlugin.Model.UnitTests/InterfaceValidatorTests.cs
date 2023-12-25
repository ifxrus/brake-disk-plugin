namespace BrakeDiskPlugin.Model.UnitTests
{
    using BrakeDiskPlugin.Model.Validators;
    using NUnit.Framework;

    /// <summary>
    /// Unit tests for the <see cref="InterfaceValidator"/> class.
    /// </summary>
    [TestFixture]
    internal class InterfaceValidatorTests
    {
        [TestCase(
            '1',
            "123",
            5,
            true,
            TestName = "IsValidInput returns true for valid digit input.")]
        [TestCase(
            (char)8,
            "abc",
            5,
            true,
            TestName = "IsValidInput returns true for backspace.")]
        [TestCase(
            (char)13,
            "abc",
            5,
            true,
            TestName = "IsValidInput returns true for enter key.")]
        [TestCase(
            '!',
            "abc",
            5,
            false,
            TestName = "IsValidInput returns false for invalid character.")]
        [TestCase(
            'a',
            "123",
            5,
            false,
            TestName = "IsValidInput returns false for alphabetic character.")]
        public void IsValidInput_ReturnsExpectedResult(
            char keyChar,
            string currentText,
            int maxLength,
            bool expectedResult)
        {
            // Act
            var result = InterfaceValidator.IsValidInput(keyChar, currentText, maxLength);

            // Assert
            Assert.AreEqual(
                expectedResult,
                result,
                $"IsValidInput should return {expectedResult} for the given input.");
        }
    }
}