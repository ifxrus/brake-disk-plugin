namespace BrakeDiskPlugin.View
{
    /// <summary>
    /// Provides color constants for the main form elements.
    /// </summary>
    internal class MainFormColors
    {
        /// <summary>
        /// The color of the TextBox when an error occurs.
        /// </summary>
        public static Color ErrorTextBoxColor { get; } = Color.LightPink;

        /// <summary>
        /// The default color of the TextBox.
        /// </summary>
        public static Color DefaultTextBoxColor { get; } = Color.White;

        /// <summary>
        /// The color of the TextBox when it is inactive.
        /// </summary>
        public static Color InactiveTextBoxColor { get; } = Color.WhiteSmoke;
    }
}