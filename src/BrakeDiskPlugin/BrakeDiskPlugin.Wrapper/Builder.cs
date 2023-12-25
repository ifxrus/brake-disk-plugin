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
        /// <summary>
        /// The wrapper instance for interacting with the KOMPAS-3D API.
        /// </summary>
        private readonly Wrapper _wrapper = new ();

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

        /// <summary>
        /// Creates and extrudes the base sketch of the brake disk.
        /// </summary>
        /// <param name="rad">Radius of the base sketch.</param>
        /// <param name="largerDim">Larger dimension of the base sketch.</param>
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
        /// Creates and extrudes the sketch for the larger fastener of the brake disk.
        /// </summary>
        /// <param name="largerDim">Larger dimension of the fastener sketch.</param>
        /// <param name="smallerDim">Smaller dimension of the fastener sketch.</param>
        /// <param name="depth">Extrusion depth of the larger fastener sketch.</param>
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
        /// Creates and extrudes the sketch for the smaller fastener of the brake disk.
        /// </summary>
        /// <param name="smallerDim">Smaller dimension of the fastener sketch.</param>
        /// <param name="centeringDim">Centering dimension of the fastener sketch.</param>
        /// <param name="fastenerDim">Dimension of the fastener in the sketch.</param>
        /// <param name="smallerWidth">Width of the smaller fastener sketch.</param>
        private void CreateAndExtrudeSmallerFastener(
            double smallerDim,
            double centeringDim,
            double fastenerDim,
            double smallerWidth)
        {
            var fastenerPos = smallerDim / 2 * 0.75;

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

        /// <summary>
        /// Creates and extrudes the sketch for the extrude operation of the brake disk.
        /// </summary>
        /// <param name="smallerDim">Smaller dimension of the extrude sketch.</param>
        /// <param name="smallerWidth">Width of the smaller extrude sketch.</param>
        /// <param name="largerWidth">Width of the larger extrude sketch.</param>
        private void CreateAndExtrude(double smallerDim, double smallerWidth, double largerWidth)
        {
            var fastenerRad = smallerDim / 2 * 0.9;
            var brakeDiskWidth = smallerWidth + largerWidth - 15;

            var sketch = _wrapper.CreateSketch();
            var doc2d = (ksDocument2D)sketch.BeginEdit();
            doc2d.ksCircle(0, 0, fastenerRad, 1);
            sketch.EndEdit();
            _wrapper.CutMakeExtrusion(brakeDiskWidth);
        }
    }
}