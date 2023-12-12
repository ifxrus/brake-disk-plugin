namespace BrakeDiskPlugin.Model.Parameters
{
    /// <summary>
    /// Enumeration listing brake disc parameter types.
    /// </summary>
    public enum ParameterType
    {
        /// <summary>
        /// Diameter of the brake disc.
        /// </summary>
        BrakeDiskDiameter,

        /// <summary>
        /// Diameter of the fastener.
        /// </summary>
        FastenerDiameter,

        /// <summary>
        /// Diameter of the larger fastener.
        /// </summary>
        LargerFastenerDiameter,

        /// <summary>
        /// Diameter of the smaller fastener.
        /// </summary>
        SmallerFastenerDiameter,

        /// <summary>
        /// Diameter used for centering.
        /// </summary>
        CenteringDiameter,

        /// <summary>
        /// Width of the working surface.
        /// </summary>
        WidthWorkingSurface,

        /// <summary>
        /// Width of the larger fastener.
        /// </summary>
        WidthLargerFastener,

        /// <summary>
        /// Width of the smaller fastener.
        /// </summary>
        WidthSmallerFastener
    }
}