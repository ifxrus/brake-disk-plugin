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
        /// <summary>
        /// Represents a class member that holds an instance of the BrakeDisk class.
        /// </summary>
        private readonly BrakeDisk _brakeDisk = new ();

        /// <summary>
        /// Represents a dictionary that maps TextBox controls to their corresponding ParameterType values.
        /// </summary>
        private readonly Dictionary<TextBox, ParameterType> _textBoxParameters;

        /// <summary>
        /// Represents the flag indicating whether an error condition is currently active in the program.
        /// </summary>
        private bool _errorIsActive;

        /// <summary>
        /// Represents the TextBox control associated with the active error condition, or null if no error is currently active.
        /// </summary>
        private TextBox? _errorTextBox;

        /// <summary>
        /// The main method of the program interface.
        /// </summary>
        public MainForm()
        {
            InitializeComponent();

            _textBoxParameters = new Dictionary<TextBox, ParameterType>
            {
                {
                    LargerFastenerBrakeDiskDiameterTextBox, ParameterType.LargerFastenerDiameter
                },
                {
                    BrakeDiskDiameterTextBox, ParameterType.BrakeDiskDiameter
                },
                {
                    CenteringDiameterTextBox, ParameterType.CenteringDiameter
                },
                {
                    WidthWorkingSurfaceTextBox, ParameterType.WidthWorkingSurface
                },
                {
                    WidthLargerFastenerTextBox, ParameterType.WidthLargerFastener
                },
                {
                    FastenerDiameterTextBox, ParameterType.FastenerDiameter
                },
                {
                    SmallerFastenerBrakeDiskDiameterTextBox, ParameterType.SmallerFastenerDiameter
                },
                {
                    WidthSmallerFastenerTextBox, ParameterType.WidthSmallerFastener
                }
            };

            UpdateParameters();
        }

        /// <summary>
        /// Updates the values of text fields on the form based on corresponding brake disk parameters.
        /// </summary>
        private void UpdateParameters()
        {
            foreach (var kvp in _textBoxParameters)
            {
                UpdateTextBox(kvp.Key, kvp.Value);
            }
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
            var text = textBox.Text;

            try
            {
                if (double.TryParse(text, out var result))
                {
                    _brakeDisk.SetValue(parameterType, result);
                }
            }
            catch (ArgumentException exception)
            {
                var result = MessageBox.Show(
                    exception.Message + "\n\nВернуть последнее корректное значение?",
                    "Ошибка",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Error);

                if (result == DialogResult.No)
                {
                    SetTextBoxInactive(textBox);
                    textBox.BackColor = MainFormColors.ErrorTextBoxColor;
                    textBox.Text = text;
                    _errorIsActive = true;
                    return;
                }
            }

            if (textBox != _errorTextBox)
            {
                return;
            }

            _errorIsActive = false;
            _errorTextBox = null;
            SetTextBoxActive();
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
        /// Event handler for the TextBox leave event.
        /// This method is triggered when focus leaves a TextBox.
        /// It sets the value of the corresponding parameter based on the TextBox and updates the parameters.
        /// </summary>
        /// <param name="sender">The TextBox control that triggered the event.</param>
        /// <param name="e">The event arguments.</param>
        private void LeaveTextBox(object sender, EventArgs e)
        {
            SetValue(sender, _textBoxParameters[(TextBox)sender]);

            if (_errorIsActive)
            {
                return;
            }

            UpdateParameters();
        }

        /// <summary>
        /// Sets the state of a TextBox control including its enabled status and background color.
        /// </summary>
        /// <param name="textBox">The TextBox control to modify.</param>
        /// <param name="isEnabled">Specifies whether the TextBox should be enabled.</param>
        /// <param name="backgroundColor">The background color to set for the TextBox.</param>
        private void SetTextBoxState(TextBox textBox, bool isEnabled, Color backgroundColor)
        {
            textBox.ReadOnly = isEnabled;
            textBox.BackColor = backgroundColor;
        }

        /// <summary>
        /// Disables all TextBox controls in the dictionary except the specified one.
        /// </summary>
        /// <param name="currentTextBox">The TextBox to remain enabled.</param>
        private void SetTextBoxInactive(TextBox currentTextBox)
        {
            _errorTextBox = currentTextBox;
            foreach (var textBox in _textBoxParameters.Keys.Where(
                textBox => textBox != currentTextBox))
            {
                SetTextBoxState(textBox, true, MainFormColors.InactiveTextBoxColor);
            }
        }

        /// <summary>
        /// Enables all TextBox controls and sets their background color to the default active color.
        /// </summary>
        private void SetTextBoxActive()
        {
            foreach (var textBox in _textBoxParameters.Keys)
            {
                SetTextBoxState(textBox, false, MainFormColors.DefaultTextBoxColor);
            }
        }

        private void SetInfoTextBox(object sender, EventArgs e)
        {
            var textBox = (TextBox)sender;
            var description = ParameterTypeHelper.GetParameterTypeDescription(_textBoxParameters[textBox]);

            InfoTextBox.Enabled = true;
            InfoTextBox.Text = description;
        }
    }
}