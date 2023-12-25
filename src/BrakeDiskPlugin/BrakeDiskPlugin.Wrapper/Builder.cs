namespace BrakeDiskPlugin.Wrapper
{
    using BrakeDiskPlugin.Model;
    using BrakeDiskPlugin.Model.Parameters;
    using Kompas6API5;

    /// <summary>
    /// Represents a builder class responsible for constructing a 3D brake disk using the KOMPAS-3D API.
    /// </summary>
    public class Builder
    {
        // TODO: Магические числа

        /// <summary>
        /// The wrapper instance for interacting with the KOMPAS-3D API.
        /// </summary>
        private readonly Wrapper _wrapper = new ();

        /// <summary>
        /// Factor determining the position of the smaller fastener relative to its diameter.
        /// </summary>
        private const double FastenerPositionFactor = 0.75;

        /// <summary>
        /// Factor determining the radius of the smaller fastener relative to its diameter.
        /// </summary>
        private const double FastenerRadiusFactor = 0.9;

        /// <summary>
        /// Adjustment value for the brake disk width.
        /// </summary>
        private const double BrakeDiskWidthAdjustment = 15;

        /// <summary>
        /// Builds a brake disk by connecting to CAD, creating a 3D document, and constructing various
        /// components.
        /// </summary>
        /// <param name="brakeDisk">The brake disk configuration.</param>
        public void BuildBrakeDisk(BrakeDisk brakeDisk)
        {
            _wrapper.ConnectToCad();
            _wrapper.CreateDocument3D();

            CreateAndExtrudeBase(
                brakeDisk.GetValue(ParameterType.BrakeDiskDiameter),
                brakeDisk.GetValue(ParameterType.LargerFastenerDiameter));

            CreateAndExtrudeLargerFastener(
                brakeDisk.GetValue(ParameterType.LargerFastenerDiameter),
                brakeDisk.GetValue(ParameterType.SmallerFastenerDiameter),
                brakeDisk.GetValue(ParameterType.WidthSmallerFastener));

            CreateAndExtrudeSmallerFastener(
                brakeDisk.GetValue(ParameterType.SmallerFastenerDiameter),
                brakeDisk.GetValue(ParameterType.CenteringDiameter),
                brakeDisk.GetValue(ParameterType.FastenerDiameter),
                brakeDisk.GetValue(ParameterType.WidthSmallerFastener));

            CreateAndExtrude(
                brakeDisk.GetValue(ParameterType.SmallerFastenerDiameter),
                brakeDisk.GetValue(ParameterType.WidthSmallerFastener),
                brakeDisk.GetValue(ParameterType.WidthLargerFastener));
        }

        private void CreateAndExtrudeBase(double rad, double largerDim)
        {
            var sketch = _wrapper.CreateSketch();
            var doc2d = (ksDocument2D)sketch.BeginEdit();
            doc2d.ksCircle(0, 0, rad / 2, 1);
            doc2d.ksCircle(0, 0, largerDim / 2, 1);
            sketch.EndEdit();
            _wrapper.MakeExtrusion(5);
        }

        private void CreateAndExtrudeLargerFastener(
            double largerDim,
            double smallerDim,
            double depth)
        {
            var sketch = _wrapper.CreateSketch();
            var doc2d = (ksDocument2D)sketch.BeginEdit();
            doc2d.ksCircle(0, 0, largerDim / 2, 1);
            doc2d.ksCircle(0, 0, smallerDim / 2, 1);
            sketch.EndEdit();
            _wrapper.MakeExtrusion(depth, false);
        }

        private void CreateAndExtrudeSmallerFastener(
            double smallerDim,
            double centeringDim,
            double fastenerDim,
            double smallerWidth)
        {
            var fastenerPos = smallerDim / 2 * FastenerPositionFactor;

            var sketch = _wrapper.CreateSketch();
            var doc2d = (ksDocument2D)sketch.BeginEdit();
            doc2d.ksCircle(0, 0, smallerDim / 2, 1);
            doc2d.ksCircle(0, 0, centeringDim / 2, 1);
            doc2d.ksCircle(fastenerPos, 0, fastenerDim / 2, 1);
            doc2d.ksCircle(-fastenerPos, 0, fastenerDim / 2, 1);
            doc2d.ksCircle(0, -fastenerPos, fastenerDim / 2, 1);
            doc2d.ksCircle(0, fastenerPos, fastenerDim / 2, 1);
            sketch.EndEdit();
            _wrapper.MakeExtrusion(smallerWidth * 2, false);
        }

        private void CreateAndExtrude(double smallerDim, double smallerWidth, double largerWidth)
        {
            var fastenerRad = smallerDim / 2 * FastenerRadiusFactor;
            var brakeDiskWidth = smallerWidth + largerWidth - BrakeDiskWidthAdjustment;

            var sketch = _wrapper.CreateSketch();
            var doc2d = (ksDocument2D)sketch.BeginEdit();
            doc2d.ksCircle(0, 0, fastenerRad, 1);
            sketch.EndEdit();
            _wrapper.CutMakeExtrusion(brakeDiskWidth);
        }
    }
}
