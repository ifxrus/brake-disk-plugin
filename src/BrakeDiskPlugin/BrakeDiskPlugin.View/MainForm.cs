namespace BrakeDiskPlugin.View
{
    using System.Globalization;
    using BrakeDiskPlugin.Model;
    using BrakeDiskPlugin.Model.Parameters;
    using BrakeDiskPlugin.Model.Validators;

    /// <summary>
    /// The main class of the program interface.
    /// </summary>
    public partial class MainForm : Form
    {
        // TODO: XML
        private readonly BrakeDisk _brakeDisk = new ();

        /// <summary>
        /// The main method of the program interface.
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
            UpdateParameters();
        }

        /// <summary>
        /// Updates the values of text fields on the form based on corresponding brake disk parameters.
        /// </summary>
        private void UpdateParameters()
        {
            UpdateTextBox(BrakeDiskDiameterTextBox, ParameterType.BrakeDiskDiameter);
            UpdateTextBox(LargerFastenerBrakeDiskDiameterTextBox, ParameterType.LargerFastenerDiameter);
            UpdateTextBox(SmallerFastenerBrakeDiskDiameterTextBox, ParameterType.SmallerFastenerDiameter);
            UpdateTextBox(FastenerDiameterTextBox, ParameterType.FastenerDiameter);
            UpdateTextBox(CenteringDiameterTextBox, ParameterType.CenteringDiameter);
            UpdateTextBox(WidthLargerFastenerTextBox, ParameterType.WidthLargerFastener);
            UpdateTextBox(WidthSmallerFastenerTextBox, ParameterType.WidthSmallerFastener);
            UpdateTextBox(WidthWorkingSurfaceTextBox, ParameterType.WidthWorkingSurface);
        }

        /// <summary>
        /// Updates the text field with the value of the specified brake disk parameter.
        /// </summary>
        /// <param name="textBox">The text field to be updated.</param>
        /// <param name="parameterType">The type of the brake disk parameter.</param>
        private void UpdateTextBox(TextBox textBox, ParameterType parameterType)
        {
            textBox.Text = _brakeDisk.GetValue(parameterType)
                .ToString(CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Sets the value of a parameter in the Brake Disk instance based on the input from a TextBox.
        /// </summary>
        /// <param name="sender">The TextBox raising the event.</param>
        /// <param name="parameterType">The type of parameter to set.</param>
        private void SetValue(object sender, ParameterType parameterType)
        {
            var textBox = (TextBox)sender;

            try
            {
                var text = textBox.Text;
                if (double.TryParse(text, out double result))
                {
                    _brakeDisk.SetValue(parameterType, result);
                }
            }
            catch (ArgumentException exception)
            {
                // TODO.
            }
        }

        /// <summary>
        /// Handles the KeyPress event for the Brake Disk Diameter TextBox, restricting input to digits and control characters,
        /// and limiting the length of the text to a specified maximum (MainFormConstants.MaxInputLength).
        /// </summary>
        /// <param name="sender">The TextBox raising the event.</param>
        /// <param name="e">KeyPress event arguments.</param>
        // TODO: Дубль
        private void BrakeDiskDiameterTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            HandleKeyPress(sender, e);
        }

        /// <summary>
        /// Handles the KeyPress event for the Larger Fastener Brake Disk Diameter TextBox, restricting input to digits and control characters,
        /// and limiting the length of the text to a specified maximum (MainFormConstants.MaxInputLength).
        /// </summary>
        /// <param name="sender">The TextBox raising the event.</param>
        /// <param name="e">KeyPress event arguments.</param>
        private void LargerFastenerBrakeDiskDiameterTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            HandleKeyPress(sender, e);
        }

        /// <summary>
        /// Handles the KeyPress event for the Centering Diameter TextBox, restricting input to digits and control characters,
        /// and limiting the length of the text to a specified maximum (MainFormConstants.MaxInputLength).
        /// </summary>
        /// <param name="sender">The TextBox raising the event.</param>
        /// <param name="e">KeyPress event arguments.</param>
        private void CenteringDiameterTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            HandleKeyPress(sender, e);
        }

        /// <summary>
        /// Handles the KeyPress event for the Width Working Surface TextBox, restricting input to digits and control characters,
        /// and limiting the length of the text to a specified maximum (MainFormConstants.MaxInputLength).
        /// </summary>
        /// <param name="sender">The TextBox raising the event.</param>
        /// <param name="e">KeyPress event arguments.</param>
        private void WidthWorkingSurfaceTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            HandleKeyPress(sender, e);
        }

        /// <summary>
        /// Handles the KeyPress event for the Width Larger Fastener TextBox, restricting input to digits and control characters,
        /// and limiting the length of the text to a specified maximum (MainFormConstants.MaxInputLength).
        /// </summary>
        /// <param name="sender">The TextBox raising the event.</param>
        /// <param name="e">KeyPress event arguments.</param>
        private void WidthLargerFastenerTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            HandleKeyPress(sender, e);
        }

        /// <summary>
        /// Handles the common logic for KeyPress events on TextBoxes,
        /// restricting input to digits and control characters, and limiting the length of the text.
        /// </summary>
        /// <param name="sender">The TextBox raising the event.</param>
        /// <param name="e">KeyPress event arguments.</param>
        private void HandleKeyPress(object sender, KeyPressEventArgs e)
        {
            var textBox = (TextBox)sender;
            e.Handled = !InterfaceValidator.IsValidInput(
                e.KeyChar,
                textBox.Text,
                MainFormConstants.MaxInputLength);
        }

        /// <summary>
        /// Event handler for the Leave event of the Larger Fastener Brake Disk Diameter TextBox.
        /// Sets the value of the Larger Fastener Diameter parameter based on the TextBox input and updates parameters.
        /// </summary>
        /// <param name="sender">The TextBox raising the event.</param>
        /// <param name="e">Event arguments.</param>
        private void LargerFastenerBrakeDiskDiameterTextBox_Leave(object sender, EventArgs e)
        {
            SetValue(sender, ParameterType.LargerFastenerDiameter);
            UpdateParameters();
        }

        /// <summary>
        /// Event handler for the Leave event of the Brake Disk Diameter TextBox.
        /// Sets the value of the Brake Disk Diameter parameter based on the TextBox input and updates parameters.
        /// </summary>
        /// <param name="sender">The TextBox raising the event.</param>
        /// <param name="e">Event arguments.</param>
        // TODO: Дубль
        private void BrakeDiskDiameterTextBox_Leave(object sender, EventArgs e)
        {
            SetValue(sender, ParameterType.BrakeDiskDiameter);
            UpdateParameters();
        }

        /// <summary>
        /// Event handler for the Leave event of the Centering Diameter TextBox.
        /// Sets the value of the Centering Diameter parameter based on the TextBox input and updates parameters.
        /// </summary>
        /// <param name="sender">The TextBox raising the event.</param>
        /// <param name="e">Event arguments.</param>
        private void CenteringDiameterTextBox_Leave(object sender, EventArgs e)
        {
            SetValue(sender, ParameterType.CenteringDiameter);
            UpdateParameters();
        }

        /// <summary>
        /// Event handler for the Leave event of the Width Working Surface TextBox.
        /// Sets the value of the Width Working Surface parameter based on the TextBox input and updates parameters.
        /// </summary>
        /// <param name="sender">The TextBox raising the event.</param>
        /// <param name="e">Event arguments.</param>
        private void WidthWorkingSurfaceTextBox_Leave(object sender, EventArgs e)
        {
            SetValue(sender, ParameterType.WidthWorkingSurface);
            UpdateParameters();
        }

        /// <summary>
        /// Event handler for the MouseLeave event of the Width Larger Fastener TextBox.
        /// Sets the value of the Width Larger Fastener parameter based on the TextBox input and updates parameters.
        /// </summary>
        /// <param name="sender">The TextBox raising the event.</param>
        /// <param name="e">Event arguments.</param>
        private void WidthLargerFastenerTextBox_MouseLeave(object sender, EventArgs e)
        {
            SetValue(sender, ParameterType.WidthLargerFastener);
            UpdateParameters();
        }
    }
}