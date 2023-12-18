namespace BrakeDiskPlugin.Model
{
    using BrakeDiskPlugin.Model.Parameters;

    /// <summary>
    /// Class responsible for processing the brake disc.
    /// </summary>
    public class BrakeDisk
    {
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
                }
            };

        private bool _isReconciled = false;

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
                {
                    _isReconciled = false;
                    break;
                }

                case ParameterType.SmallerFastenerDiameter:
                {
                    // TODO: магические числа
                    minValue = _parameters[ParameterType.LargerFastenerDiameter].Value - 10;
                    maxValue = _parameters[ParameterType.LargerFastenerDiameter].Value - 10;
                    value = _parameters[ParameterType.LargerFastenerDiameter].Value - 10;
                    _isReconciled = true;
                    break;
                }

                case ParameterType.FastenerDiameter:
                {
                    minValue = _parameters[ParameterType.CenteringDiameter].Value / 5;
                    maxValue = _parameters[ParameterType.CenteringDiameter].Value / 5;
                    value = _parameters[ParameterType.CenteringDiameter].Value / 5;
                    _isReconciled = true;
                    break;
                }

                case ParameterType.CenteringDiameter:
                {
                    minValue = _parameters[ParameterType.LargerFastenerDiameter].MinValue * 0.25;
                    maxValue = _parameters[ParameterType.LargerFastenerDiameter].MaxValue * 0.5;
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