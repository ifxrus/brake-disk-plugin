namespace BrakeDiskPlugin.Model.Parameters
{
    using BrakeDiskPlugin.Model.Validators;

    /// <summary>
    /// The class responsible for processing the parameter.
    /// </summary>
    public class Parameter
    {
        /// <summary>
        /// Defines the parameter value.
        /// </summary>
        private double _value;

        /// <summary>
        /// Constructor Parameter class.
        /// </summary>
        /// <param name="value">The current value.</param>
        /// <param name="minValue">The minimum value.</param>
        /// <param name="maxValue">The maximum value.</param>
        public Parameter(double value, double minValue, double maxValue)
        {
            ValidateAndSet(value, minValue, maxValue);
        }

        /// <summary>
        /// Defines the maximum parameter value property.
        /// </summary>
        public double MinValue { get; set; }

        /// <summary>
        /// Defines the minimum parameter value property.
        /// </summary>
        public double MaxValue { get; set; }

        /// <summary>
        /// Returns and sets the value of a parameter.
        /// </summary>
        public double Value
        {
            get => _value;
            set => ValidateAndSet(value);
        }

        /// <summary>
        /// Validates the specified value against the range and sets it if valid.
        /// </summary>
        /// <param name="newValue">The new value to be validated and set.</param>
        /// <exception cref="ArgumentException">
        /// Thrown when the value out of range.
        /// </exception>
        private void ValidateAndSet(double newValue)
        {
            if (!ParametersValidator.ValidateRangeCompliance(newValue, MinValue, MaxValue))
            {
                throw new ArgumentException(
                    $"Значение не попадает в диапазон {MinValue} — {MaxValue}");
            }

            _value = newValue;
        }

        /// <summary>
        /// Validates the specified value against the range and sets it if valid.
        /// </summary>
        /// <param name="value">The minimum value.</param>
        /// <param name="minValue">The maximum value.</param>
        /// <param name="maxValue">The parameter value.</param>
        /// <exception cref="ArgumentException">
        /// Checks values for correctness.
        /// </exception>
        private void ValidateAndSet(double value, double minValue, double maxValue)
        {
            if (!ParametersValidator.ValidateValueLower(minValue, maxValue))
            {
                throw new ArgumentException(
                    "Минимальное значение больше максимального значения.");
            }

            MinValue = minValue;
            MaxValue = maxValue;
            Value = value;
        }
    }
}