namespace BrakeDiskPlugin.Model
{
    using BrakeDiskPlugin.Model.Parameters;

    /// <summary>
    /// Class responsible for processing the brake disc.
    /// </summary>
    public class BrakeDisk
    {
        /// <summary>
        /// Dictionary to store parameters of different types along with their respective limits.
        /// Key represents the type of parameter, and the value is an instance of the Parameter class.
        /// </summary>
        private readonly Dictionary<ParameterType, Parameter> _parameters =
            new ()
            {
                {
                    ParameterType.BrakeDiskDiameter, new Parameter(
                        BrakeDiskConstants.MinBrakeDiskDiameter,
                        BrakeDiskConstants.MinBrakeDiskDiameter,
                        BrakeDiskConstants.MaxBrakeDiskDiameter)
                },
                {
                    ParameterType.LargerFastenerDiameter, new Parameter(
                        BrakeDiskConstants.MinLargerFastenerDiameter,
                        BrakeDiskConstants.MinLargerFastenerDiameter,
                        BrakeDiskConstants.MaxLargerFastenerDiameter)
                },
                {
                    ParameterType.CenteringDiameter, new Parameter(
                        BrakeDiskConstants.MinCenteringDiameter,
                        BrakeDiskConstants.MinCenteringDiameter,
                        BrakeDiskConstants.MaxCenteringDiameter)
                },
                {
                    ParameterType.FastenerDiameter, new Parameter(
                        BrakeDiskConstants.FastenerDiameter,
                        BrakeDiskConstants.FastenerDiameter,
                        BrakeDiskConstants.FastenerDiameter)
                },
                {
                    ParameterType.SmallerFastenerDiameter, new Parameter(
                        BrakeDiskConstants.SmallerFastenerDiameter,
                        BrakeDiskConstants.SmallerFastenerDiameter,
                        BrakeDiskConstants.SmallerFastenerDiameter)
                },
                {
                    ParameterType.WidthWorkingSurface, new Parameter(
                        BrakeDiskConstants.MinWidthWorkingSurface,
                        BrakeDiskConstants.MinWidthWorkingSurface,
                        BrakeDiskConstants.MaxWidthWorkingSurface)
                },
                {
                    ParameterType.WidthLargerFastener, new Parameter(
                        BrakeDiskConstants.MinWidthLargerFastener,
                        BrakeDiskConstants.MinWidthLargerFastener,
                        BrakeDiskConstants.MaxWidthLargerFastener)
                },
                {
                    ParameterType.WidthSmallerFastener, new Parameter(
                        BrakeDiskConstants.WidthSmallerFastener,
                        BrakeDiskConstants.WidthSmallerFastener,
                        BrakeDiskConstants.WidthSmallerFastener)
                },
                {
                    ParameterType.NumberOfFasteners, new Parameter(
                        BrakeDiskConstants.MinNumberOfFasteners,
                        BrakeDiskConstants.MinNumberOfFasteners,
                        BrakeDiskConstants.MaxNumberOfFasteners)
                }
            };

        /// <summary>
        /// Flag indicating whether reconciliation of brake disk parameters has been performed.
        /// </summary>
        private bool _isReconciled;

        /// <summary>
        /// Class BrakeDisk constructor.
        /// </summary>
        public BrakeDisk() { }

        /// <summary>
        /// Set the value of the parameter.
        /// </summary>
        /// <param name="parameterType">The type of the parameter.</param>
        /// <param name="value">The value of the parameter.</param>
        public void SetValue(ParameterType parameterType, double value)
        {
            var minValue = _parameters[parameterType].MinValue;
            var maxValue = _parameters[parameterType].MaxValue;

            switch (parameterType)
            {
                case ParameterType.BrakeDiskDiameter:
                case ParameterType.WidthWorkingSurface:
                case ParameterType.LargerFastenerDiameter:
                case ParameterType.WidthLargerFastener:
                case ParameterType.NumberOfFasteners:
                {
                    _isReconciled = false;
                    break;
                }

                case ParameterType.SmallerFastenerDiameter:
                {
                    minValue = _parameters[ParameterType.LargerFastenerDiameter].Value
                               - BrakeDiskConstants.DiffBetweenDiameters;
                    maxValue = _parameters[ParameterType.LargerFastenerDiameter].Value
                               - BrakeDiskConstants.DiffBetweenDiameters;
                    value = _parameters[ParameterType.LargerFastenerDiameter].Value
                            - BrakeDiskConstants.DiffBetweenDiameters;
                    _isReconciled = true;
                    break;
                }

                case ParameterType.FastenerDiameter:
                {
                    minValue = _parameters[ParameterType.CenteringDiameter].Value
                               / BrakeDiskConstants.DiameterRatioFastener;
                    maxValue = _parameters[ParameterType.CenteringDiameter].Value
                               / BrakeDiskConstants.DiameterRatioFastener;
                    value = _parameters[ParameterType.CenteringDiameter].Value
                            / BrakeDiskConstants.DiameterRatioFastener;
                    _isReconciled = true;
                    break;
                }

                case ParameterType.CenteringDiameter:
                {
                    minValue = _parameters[ParameterType.LargerFastenerDiameter].MinValue
                               * BrakeDiskConstants.CenteringRatioFastener;
                    maxValue = _parameters[ParameterType.LargerFastenerDiameter].MaxValue
                               * BrakeDiskConstants.CenteringRatioFastener;
                    break;
                }

                case ParameterType.WidthSmallerFastener:
                {
                    minValue = _parameters[ParameterType.WidthLargerFastener].Value;
                    maxValue = _parameters[ParameterType.WidthLargerFastener].Value;
                    value = _parameters[ParameterType.WidthLargerFastener].Value;
                    _isReconciled = true;
                    break;
                }
            }

            _parameters[parameterType].MinValue = minValue;
            _parameters[parameterType].MaxValue = maxValue;
            _parameters[parameterType].Value = value;

            if (_isReconciled)
            {
                return;
            }

            ReconcileParameters();
        }

        /// <summary>
        /// Get the value of a parameter.
        /// </summary>
        /// <param name="parameterType">The type of the parameter.</param>
        /// <returns>The value of the parameter.</returns>
        public double GetValue(ParameterType parameterType)
        {
            return _parameters[parameterType].Value;
        }

        /// <summary>
        /// Coordinates parameters whose values ​​are strictly tied to other parameters.
        /// </summary>
        private void ReconcileParameters()
        {
            SetValue(
                ParameterType.SmallerFastenerDiameter,
                _parameters[ParameterType.LargerFastenerDiameter].Value);
            SetValue(
                ParameterType.FastenerDiameter,
                _parameters[ParameterType.CenteringDiameter].Value);
            SetValue(
                ParameterType.WidthSmallerFastener,
                _parameters[ParameterType.WidthLargerFastener].Value);
        }
    }
}