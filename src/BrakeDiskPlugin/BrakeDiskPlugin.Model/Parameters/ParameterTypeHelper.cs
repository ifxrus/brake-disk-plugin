namespace BrakeDiskPlugin.Model.Parameters
{
    using System.ComponentModel;

    /// <summary>
    /// Class with a static method for obtaining the description of the ParameterType enumeration.
    /// </summary>
    public static class ParameterTypeHelper
    {
        /// <summary>
        /// Gets the description for a given ParameterType enumeration value.
        /// </summary>
        /// <param name="value">The ParameterType enumeration value.</param>
        /// <returns>The description of the enumeration value.</returns>
        public static string GetParameterTypeDescription(ParameterType value)
        {
            var field = value.GetType().GetField(value.ToString());

            if (field is not null)
            {
                var attribute =
                    (DescriptionAttribute?)Attribute.GetCustomAttribute(
                        field,
                        typeof(DescriptionAttribute));

                if (attribute != null)
                {
                    return attribute.Description ?? value.ToString();
                }
            }

            return value.ToString();
        }
    }
}