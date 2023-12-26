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
                brakeDisk.GetValue(ParameterType.WidthSmallerFastener),
                brakeDisk.GetValue(ParameterType.NumberOfFasteners));

            CreateAndExtrude(
                brakeDisk.GetValue(ParameterType.SmallerFastenerDiameter),
                brakeDisk.GetValue(ParameterType.WidthSmallerFastener),
                brakeDisk.GetValue(ParameterType.WidthLargerFastener));
        }

        /// <summary>
        /// Creates a base with two circles and performs extrusion.
        /// </summary>
        /// <param name="rad">Radius of the smaller circle.</param>
        /// <param name="largerDim">Diameter of the larger circle.</param>
        private void CreateAndExtrudeBase(double rad, double largerDim)
        {
            var sketch = _wrapper.CreateSketch();
            var doc2d = (ksDocument2D)sketch.BeginEdit();
            doc2d.ksCircle(0, 0, rad / 2, 1);
            doc2d.ksCircle(0, 0, largerDim / 2, 1);
            sketch.EndEdit();
            _wrapper.MakeExtrusion(5);
        }

        /// <summary>
        /// Creates a larger fastener with two circles and performs extrusion.
        /// </summary>
        /// <param name="largerDim">Diameter of the larger circle.</param>
        /// <param name="smallerDim">Diameter of the smaller circle.</param>
        /// <param name="depth">Depth of the extrusion.</param>
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

        /// <summary>
        /// Creates a smaller fastener with circles and an array of points and performs extrusion.
        /// </summary>
        /// <param name="smallerDim">Diameter of the smaller circle.</param>
        /// <param name="centeringDim">Diameter of the centering circle.</param>
        /// <param name="fastenerDim">Diameter of the fastener circles.</param>
        /// <param name="smallerWidth">Width of the smaller fastener.</param>
        /// <param name="numberOfPoints">Number of points to create in the array of fastener circles.</param>
        private void CreateAndExtrudeSmallerFastener(
            double smallerDim,
            double centeringDim,
            double fastenerDim,
            double smallerWidth,
            double numberOfPoints)
        {
            var fastenerPos = smallerDim / 2 * FastenerPositionFactor;

            var sketch = _wrapper.CreateSketch();
            var doc2d = (ksDocument2D)sketch.BeginEdit();
            doc2d.ksCircle(0, 0, smallerDim / 2, 1);
            doc2d.ksCircle(0, 0, centeringDim / 2, 1);

            for (var i = 0; i < numberOfPoints; i++)
            {
                var angle = 2 * Math.PI * i / numberOfPoints;
                var x = fastenerPos * Math.Cos(angle);
                var y = fastenerPos * Math.Sin(angle);

                doc2d.ksCircle(x, y, fastenerDim / 2, 1);
            }

            sketch.EndEdit();
            _wrapper.MakeExtrusion(smallerWidth * 2, false);
        }

        /// <summary>
        /// Creates a brake disk with a single circle and performs extrusion.
        /// </summary>
        /// <param name="smallerDim">Diameter of the smaller circle.</param>
        /// <param name="smallerWidth">Width of the smaller fastener.</param>
        /// <param name="largerWidth">Width of the larger fastener.</param>
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
