namespace BrakeDiskPlugin.Model.Validators
{
    /// <summary>
    /// Class responsible for interface validation.
    /// </summary>
    public static class InterfaceValidator
    {
        /// <summary>
        /// Validates whether a KeyPress event is valid based on the input character,
        /// the current text in the TextBox, and a specified maximum length.
        /// </summary>
        /// <param name="keyChar">The character being entered.</param>
        /// <param name="currentText">The current text in the TextBox.</param>
        /// <param name="maxLength">The maximum length allowed for the text.</param>
        /// <returns>True if the KeyPress event is valid; otherwise, false.</returns>
        public static bool IsValidInput(char keyChar, string currentText, int maxLength)
        {
            return (char.IsControl(keyChar) || char.IsDigit(keyChar))
                   && !(currentText.Length >= maxLength && !char.IsControl(keyChar));
        }
    }
}