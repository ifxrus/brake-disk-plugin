namespace BrakeDiskPlugin.Model
{
    /// <summary>
    /// Defining constant values for brake disc parameters.
    /// </summary>
    public static class BrakeDiskConstants
    {
        /// <summary>
        /// Maximum diameter of the brake disc.
        /// </summary>
        public const double MaxBrakeDiskDiameter = 400;

        /// <summary>
        /// Minimum diameter of the brake disc.
        /// </summary>
        public const double MinBrakeDiskDiameter = 300;

        /// <summary>
        /// Maximum diameter of the larger fastener.
        /// </summary>
        public const double MaxLargerFastenerDiameter = 200;

        /// <summary>
        /// Minimum diameter of the larger fastener.
        /// </summary>
        public const double MinLargerFastenerDiameter = 120;

        /// <summary>
        /// Diameter of the smaller fastener.
        /// </summary>
        public const double SmallerFastenerDiameter = MinLargerFastenerDiameter - 10;

        /// <summary>
        /// Maximum centering diameter.
        /// </summary>
        public const double MaxCenteringDiameter = 0.5 * MinLargerFastenerDiameter;

        /// <summary>
        /// Minimum centering diameter.
        /// </summary>
        public const double MinCenteringDiameter = 0.25 * MinLargerFastenerDiameter;

        /// <summary>
        /// Diameter of the smaller fastener.
        /// </summary>
        public const double FastenerDiameter = MinCenteringDiameter / 5;

        /// <summary>
        /// Maximum width of working surface.
        /// </summary>
        public const double MaxWidthWorkingSurface = 40;

        /// <summary>
        /// Minimum width of working surface.
        /// </summary>
        public const double MinWidthWorkingSurface = 20;

        /// <summary>
        /// Maximum width of smaller fastener.
        /// </summary>
        public const double MaxWidthLargerFastener = 60;

        /// <summary>
        /// Minimum width of smaller fastener.
        /// </summary>
        public const double MinWidthLargerFastener = 30;

        /// <summary>
        /// Width of larger fastener.
        /// </summary>
        public const double WidthSmallerFastener = MinWidthLargerFastener;

        /// <summary>
        /// Constant representing the allowable difference between brake disk diameters.
        /// </summary>
        public const double DiffBetweenDiameters = 10;

        /// <summary>
        /// Constant representing the ratio of larger fastener diameter to brake disk diameter.
        /// </summary>
        public const double DiameterRatioFastener = 5;

        /// <summary>
        /// Constant representing the ratio of centering diameter to brake disk diameter for fasteners.
        /// </summary>
        public const double CenteringRatioFastener = 0.25;
    }
}