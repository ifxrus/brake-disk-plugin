namespace BrakeDiskPlugin.Model.UnitTests
{
    using BrakeDiskPlugin.Model.Parameters;
    using NUnit.Framework;

    [TestFixture]
    public class ParameterTypeHelperTests
    {
        [Test]
        [TestCase(
            ParameterType.BrakeDiskDiameter,
            "Диаметр тормозного диска.",
            TestName =
                "GetParameterTypeDescription returns attribute description for BrakeDiskDiameter.")]
        [TestCase(
            ParameterType.FastenerDiameter,
            "Диаметр крепежного элемента.",
            TestName =
                "GetParameterTypeDescription returns attribute description for FastenerDiameter.")]
        [TestCase(
            ParameterType.LargerFastenerDiameter,
            "Диаметр более крупного крепежного элемента.",
            TestName =
                "GetParameterTypeDescription returns attribute description for LargerFastenerDiameter.")]
        [TestCase(
            ParameterType.SmallerFastenerDiameter,
            "Диаметр меньшего крепежного элемента.",
            TestName =
                "GetParameterTypeDescription returns attribute description for SmallerFastenerDiameter.")]
        [TestCase(
            ParameterType.CenteringDiameter,
            "Диаметр, используемый для центрирования.",
            TestName =
                "GetParameterTypeDescription returns attribute description for CenteringDiameter.")]
        [TestCase(
            ParameterType.WidthWorkingSurface,
            "Ширина рабочей поверхности.",
            TestName =
                "GetParameterTypeDescription returns attribute description for WidthWorkingSurface.")]
        [TestCase(
            ParameterType.WidthLargerFastener,
            "Ширина более крупного крепежного элемента.",
            TestName =
                "GetParameterTypeDescription returns attribute description for WidthLargerFastener.")]
        [TestCase(
            ParameterType.WidthSmallerFastener,
            "Ширина меньшего крепежного элемента.",
            TestName =
                "GetParameterTypeDescription returns attribute description for WidthSmallerFastener.")]
        public void GetParameterTypeDescription_ReturnsExpectedResult(
            ParameterType parameterType,
            string expectedDescription)
        {
            // Act
            var description = ParameterTypeHelper.GetParameterTypeDescription(parameterType);

            // Assert
            Assert.AreEqual(
                expectedDescription,
                description,
                $"GetParameterTypeDescription should return the expected description for {parameterType}.");
        }
    }
}