namespace BrakeDiskPlugin.Model.Parameters
{
    using System.ComponentModel;

    /// <summary>
    /// Enumeration listing brake disc parameter types.
    /// </summary>
    public enum ParameterType
    {
        /// <summary>
        /// Diameter of the brake disc.
        /// </summary>
        [Description("Диаметр тормозного диска.")]
        BrakeDiskDiameter,

        /// <summary>
        /// Diameter of the fastener.
        /// </summary>
        [Description("Диаметр крепежного элемента.")]
        FastenerDiameter,

        /// <summary>
        /// Diameter of the larger fastener.
        /// </summary>
        [Description("Диаметр более крупного крепежного элемента.")]
        LargerFastenerDiameter,

        /// <summary>
        /// Diameter of the smaller fastener.
        /// </summary>
        [Description("Диаметр меньшего крепежного элемента.")]
        SmallerFastenerDiameter,

        /// <summary>
        /// Diameter used for centering.
        /// </summary>
        [Description("Диаметр, используемый для центрирования.")]
        CenteringDiameter,

        /// <summary>
        /// Width of the working surface.
        /// </summary>
        [Description("Ширина рабочей поверхности.")]
        WidthWorkingSurface,

        /// <summary>
        /// Width of the larger fastener.
        /// </summary>
        [Description("Ширина более крупного крепежного элемента.")]
        WidthLargerFastener,

        /// <summary>
        /// Width of the smaller fastener.
        /// </summary>
        [Description("Ширина меньшего крепежного элемента.")]
        WidthSmallerFastener
    }
}