namespace BrakeDiskPlugin.Model.Validators
{
    /// <summary>
    /// Class responsible for parameters validation.
    /// </summary>
    public static class ParametersValidator
    {
        /// <summary>
        /// Checks if the value belongs to the range between <see cref="minValue"/> and <see cref="maxValue"/>.
        /// </summary>
        /// <param name="value">The value to be checked.</param>
        /// <param name="minValue">The minimum possible value.</param>
        /// <param name="maxValue">The maximum possible value.</param>
        /// <returns>True if the validation is successful.</returns>
        public static bool ValidateRangeCompliance(double value, double minValue, double maxValue)
        {
            return value >= minValue && value <= maxValue;
        }

        /// <summary>
        /// Checks if the values are stored correctly <see cref="minValue"/> and <see cref="maxValue"/>.
        /// </summary>
        /// <param name="minValue">The minimum possible value.</param>
        /// <param name="maxValue">The maximum possible value.</param>
        /// <returns>True if the validation is successful.</returns>
        public static bool ValidateValueLower(double minValue, double maxValue)
        {
            return minValue <= maxValue;
        }
    }
}