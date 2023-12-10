namespace BrakeDiskPlugin.View
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            MainLayoutPanel = new TableLayoutPanel();
            ParametersPanel = new Panel();
            FastenerDiameterTextBox = new TextBox();
            CenteringDiameterTextBox = new TextBox();
            LowerBrakeDiskDiameterTextBox = new TextBox();
            HigherBrakeDiskDiameterTextBox = new TextBox();
            BrakeDiskDiameterTextBox = new TextBox();
            WidthLowerFastenerTextBox = new TextBox();
            WidthHigherFastenerTextBox = new TextBox();
            WidthWorkingSurfaceTextBox = new TextBox();
            BuildingPanel = new TableLayoutPanel();
            InfoPanel = new Panel();
            InfoTextBox = new TextBox();
            ActionsPanel = new Panel();
            ActionsLayoutPanel = new TableLayoutPanel();
            OptionsPanel = new Panel();
            FeatureСheckBox = new CheckBox();
            NewFigureCheckBox = new CheckBox();
            Optionslabel = new Label();
            ButtonPanel = new Panel();
            BuildButton = new Button();
            MainLayoutPanel.SuspendLayout();
            ParametersPanel.SuspendLayout();
            BuildingPanel.SuspendLayout();
            InfoPanel.SuspendLayout();
            ActionsPanel.SuspendLayout();
            ActionsLayoutPanel.SuspendLayout();
            OptionsPanel.SuspendLayout();
            ButtonPanel.SuspendLayout();
            SuspendLayout();
            // 
            // MainLayoutPanel
            // 
            MainLayoutPanel.ColumnCount = 2;
            MainLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 70F));
            MainLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            MainLayoutPanel.Controls.Add(ParametersPanel, 0, 0);
            MainLayoutPanel.Controls.Add(BuildingPanel, 1, 0);
            MainLayoutPanel.Dock = DockStyle.Fill;
            MainLayoutPanel.Location = new Point(0, 0);
            MainLayoutPanel.Name = "MainLayoutPanel";
            MainLayoutPanel.RowCount = 1;
            MainLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            MainLayoutPanel.Size = new Size(884, 384);
            MainLayoutPanel.TabIndex = 0;
            // 
            // ParametersPanel
            // 
            ParametersPanel.BackgroundImage = Properties.Resources.MainFormBackImage;
            ParametersPanel.BackgroundImageLayout = ImageLayout.Stretch;
            ParametersPanel.BorderStyle = BorderStyle.FixedSingle;
            ParametersPanel.Controls.Add(FastenerDiameterTextBox);
            ParametersPanel.Controls.Add(CenteringDiameterTextBox);
            ParametersPanel.Controls.Add(LowerBrakeDiskDiameterTextBox);
            ParametersPanel.Controls.Add(HigherBrakeDiskDiameterTextBox);
            ParametersPanel.Controls.Add(BrakeDiskDiameterTextBox);
            ParametersPanel.Controls.Add(WidthLowerFastenerTextBox);
            ParametersPanel.Controls.Add(WidthHigherFastenerTextBox);
            ParametersPanel.Controls.Add(WidthWorkingSurfaceTextBox);
            ParametersPanel.Dock = DockStyle.Fill;
            ParametersPanel.Location = new Point(0, 0);
            ParametersPanel.Margin = new Padding(0);
            ParametersPanel.Name = "ParametersPanel";
            ParametersPanel.Size = new Size(618, 384);
            ParametersPanel.TabIndex = 0;
            // 
            // FastenerDiameterTextBox
            // 
            FastenerDiameterTextBox.BackColor = Color.White;
            FastenerDiameterTextBox.BorderStyle = BorderStyle.FixedSingle;
            FastenerDiameterTextBox.Location = new Point(368, 286);
            FastenerDiameterTextBox.Name = "FastenerDiameterTextBox";
            FastenerDiameterTextBox.Size = new Size(47, 22);
            FastenerDiameterTextBox.TabIndex = 100;
            FastenerDiameterTextBox.TabStop = false;
            // 
            // CenteringDiameterTextBox
            // 
            CenteringDiameterTextBox.BackColor = Color.White;
            CenteringDiameterTextBox.BorderStyle = BorderStyle.FixedSingle;
            CenteringDiameterTextBox.Location = new Point(193, 333);
            CenteringDiameterTextBox.Name = "CenteringDiameterTextBox";
            CenteringDiameterTextBox.Size = new Size(52, 22);
            CenteringDiameterTextBox.TabIndex = 100;
            CenteringDiameterTextBox.TabStop = false;
            // 
            // LowerBrakeDiskDiameterTextBox
            // 
            LowerBrakeDiskDiameterTextBox.BackColor = Color.White;
            LowerBrakeDiskDiameterTextBox.BorderStyle = BorderStyle.FixedSingle;
            LowerBrakeDiskDiameterTextBox.Location = new Point(534, 333);
            LowerBrakeDiskDiameterTextBox.Name = "LowerBrakeDiskDiameterTextBox";
            LowerBrakeDiskDiameterTextBox.Size = new Size(56, 22);
            LowerBrakeDiskDiameterTextBox.TabIndex = 100;
            LowerBrakeDiskDiameterTextBox.TabStop = false;
            // 
            // HigherBrakeDiskDiameterTextBox
            // 
            HigherBrakeDiskDiameterTextBox.BackColor = Color.White;
            HigherBrakeDiskDiameterTextBox.BorderStyle = BorderStyle.FixedSingle;
            HigherBrakeDiskDiameterTextBox.Location = new Point(535, 10);
            HigherBrakeDiskDiameterTextBox.Name = "HigherBrakeDiskDiameterTextBox";
            HigherBrakeDiskDiameterTextBox.ShortcutsEnabled = false;
            HigherBrakeDiskDiameterTextBox.Size = new Size(56, 22);
            HigherBrakeDiskDiameterTextBox.TabIndex = 100;
            HigherBrakeDiskDiameterTextBox.TabStop = false;
            // 
            // BrakeDiskDiameterTextBox
            // 
            BrakeDiskDiameterTextBox.BackColor = Color.White;
            BrakeDiskDiameterTextBox.BorderStyle = BorderStyle.FixedSingle;
            BrakeDiskDiameterTextBox.Location = new Point(194, 10);
            BrakeDiskDiameterTextBox.Name = "BrakeDiskDiameterTextBox";
            BrakeDiskDiameterTextBox.Size = new Size(56, 22);
            BrakeDiskDiameterTextBox.TabIndex = 100;
            BrakeDiskDiameterTextBox.TabStop = false;
            // 
            // WidthLowerFastenerTextBox
            // 
            WidthLowerFastenerTextBox.BackColor = Color.White;
            WidthLowerFastenerTextBox.BorderStyle = BorderStyle.FixedSingle;
            WidthLowerFastenerTextBox.Location = new Point(88, 263);
            WidthLowerFastenerTextBox.Name = "WidthLowerFastenerTextBox";
            WidthLowerFastenerTextBox.Size = new Size(56, 22);
            WidthLowerFastenerTextBox.TabIndex = 100;
            WidthLowerFastenerTextBox.TabStop = false;
            // 
            // WidthHigherFastenerTextBox
            // 
            WidthHigherFastenerTextBox.BackColor = Color.White;
            WidthHigherFastenerTextBox.BorderStyle = BorderStyle.FixedSingle;
            WidthHigherFastenerTextBox.Location = new Point(89, 121);
            WidthHigherFastenerTextBox.Name = "WidthHigherFastenerTextBox";
            WidthHigherFastenerTextBox.Size = new Size(56, 22);
            WidthHigherFastenerTextBox.TabIndex = 100;
            WidthHigherFastenerTextBox.TabStop = false;
            // 
            // WidthWorkingSurfaceTextBox
            // 
            WidthWorkingSurfaceTextBox.BackColor = Color.White;
            WidthWorkingSurfaceTextBox.BorderStyle = BorderStyle.FixedSingle;
            WidthWorkingSurfaceTextBox.Location = new Point(88, 35);
            WidthWorkingSurfaceTextBox.Name = "WidthWorkingSurfaceTextBox";
            WidthWorkingSurfaceTextBox.Size = new Size(56, 22);
            WidthWorkingSurfaceTextBox.TabIndex = 100;
            WidthWorkingSurfaceTextBox.TabStop = false;
            // 
            // BuildingPanel
            // 
            BuildingPanel.BackColor = Color.WhiteSmoke;
            BuildingPanel.ColumnCount = 1;
            BuildingPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            BuildingPanel.Controls.Add(InfoPanel, 0, 0);
            BuildingPanel.Controls.Add(ActionsPanel, 0, 1);
            BuildingPanel.Dock = DockStyle.Fill;
            BuildingPanel.Location = new Point(618, 0);
            BuildingPanel.Margin = new Padding(0);
            BuildingPanel.Name = "BuildingPanel";
            BuildingPanel.RowCount = 2;
            BuildingPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 80F));
            BuildingPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            BuildingPanel.Size = new Size(266, 384);
            BuildingPanel.TabIndex = 1;
            // 
            // InfoPanel
            // 
            InfoPanel.BackColor = Color.WhiteSmoke;
            InfoPanel.BackgroundImageLayout = ImageLayout.None;
            InfoPanel.BorderStyle = BorderStyle.FixedSingle;
            InfoPanel.Controls.Add(InfoTextBox);
            InfoPanel.Dock = DockStyle.Fill;
            InfoPanel.Location = new Point(0, 0);
            InfoPanel.Margin = new Padding(0);
            InfoPanel.Name = "InfoPanel";
            InfoPanel.Size = new Size(266, 307);
            InfoPanel.TabIndex = 0;
            // 
            // InfoTextBox
            // 
            InfoTextBox.BackColor = Color.WhiteSmoke;
            InfoTextBox.Enabled = false;
            InfoTextBox.Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point);
            InfoTextBox.Location = new Point(3, 3);
            InfoTextBox.Multiline = true;
            InfoTextBox.Name = "InfoTextBox";
            InfoTextBox.ReadOnly = true;
            InfoTextBox.Size = new Size(258, 298);
            InfoTextBox.TabIndex = 0;
            InfoTextBox.Text = "Выберите параметр для отображения информации";
            // 
            // ActionsPanel
            // 
            ActionsPanel.BorderStyle = BorderStyle.FixedSingle;
            ActionsPanel.Controls.Add(ActionsLayoutPanel);
            ActionsPanel.Dock = DockStyle.Fill;
            ActionsPanel.Location = new Point(0, 307);
            ActionsPanel.Margin = new Padding(0);
            ActionsPanel.Name = "ActionsPanel";
            ActionsPanel.Size = new Size(266, 77);
            ActionsPanel.TabIndex = 1;
            // 
            // ActionsLayoutPanel
            // 
            ActionsLayoutPanel.ColumnCount = 2;
            ActionsLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 70F));
            ActionsLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            ActionsLayoutPanel.Controls.Add(OptionsPanel, 0, 0);
            ActionsLayoutPanel.Controls.Add(ButtonPanel, 1, 0);
            ActionsLayoutPanel.Dock = DockStyle.Fill;
            ActionsLayoutPanel.Location = new Point(0, 0);
            ActionsLayoutPanel.Name = "ActionsLayoutPanel";
            ActionsLayoutPanel.RowCount = 1;
            ActionsLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            ActionsLayoutPanel.Size = new Size(264, 75);
            ActionsLayoutPanel.TabIndex = 0;
            // 
            // OptionsPanel
            // 
            OptionsPanel.Controls.Add(FeatureСheckBox);
            OptionsPanel.Controls.Add(NewFigureCheckBox);
            OptionsPanel.Controls.Add(Optionslabel);
            OptionsPanel.Dock = DockStyle.Fill;
            OptionsPanel.Location = new Point(3, 3);
            OptionsPanel.Name = "OptionsPanel";
            OptionsPanel.Size = new Size(178, 69);
            OptionsPanel.TabIndex = 1;
            // 
            // FeatureСheckBox
            // 
            FeatureСheckBox.AutoSize = true;
            FeatureСheckBox.Location = new Point(7, 45);
            FeatureСheckBox.Name = "FeatureСheckBox";
            FeatureСheckBox.Size = new Size(74, 18);
            FeatureСheckBox.TabIndex = 2;
            FeatureСheckBox.Text = "Опция 2";
            FeatureСheckBox.UseVisualStyleBackColor = true;
            // 
            // NewFigureCheckBox
            // 
            NewFigureCheckBox.AutoSize = true;
            NewFigureCheckBox.Location = new Point(7, 22);
            NewFigureCheckBox.Name = "NewFigureCheckBox";
            NewFigureCheckBox.Size = new Size(74, 18);
            NewFigureCheckBox.TabIndex = 1;
            NewFigureCheckBox.Text = "Опция 1";
            NewFigureCheckBox.UseVisualStyleBackColor = true;
            // 
            // Optionslabel
            // 
            Optionslabel.AutoSize = true;
            Optionslabel.Location = new Point(3, 3);
            Optionslabel.Margin = new Padding(3);
            Optionslabel.Name = "Optionslabel";
            Optionslabel.Size = new Size(48, 14);
            Optionslabel.TabIndex = 0;
            Optionslabel.Text = "Опции:";
            // 
            // ButtonPanel
            // 
            ButtonPanel.Controls.Add(BuildButton);
            ButtonPanel.Dock = DockStyle.Fill;
            ButtonPanel.Location = new Point(185, 1);
            ButtonPanel.Margin = new Padding(1);
            ButtonPanel.Name = "ButtonPanel";
            ButtonPanel.Size = new Size(78, 73);
            ButtonPanel.TabIndex = 0;
            // 
            // BuildButton
            // 
            BuildButton.BackColor = Color.WhiteSmoke;
            BuildButton.BackgroundImageLayout = ImageLayout.None;
            BuildButton.Dock = DockStyle.Fill;
            BuildButton.FlatAppearance.BorderColor = Color.Black;
            BuildButton.FlatAppearance.BorderSize = 0;
            BuildButton.FlatAppearance.MouseDownBackColor = Color.Transparent;
            BuildButton.FlatStyle = FlatStyle.Flat;
            BuildButton.Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point);
            BuildButton.Image = Properties.Resources.BuldButtonIcon;
            BuildButton.Location = new Point(0, 0);
            BuildButton.Margin = new Padding(1);
            BuildButton.Name = "BuildButton";
            BuildButton.Size = new Size(78, 73);
            BuildButton.TabIndex = 0;
            BuildButton.UseVisualStyleBackColor = false;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 14F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(884, 384);
            Controls.Add(MainLayoutPanel);
            Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MaximumSize = new Size(900, 423);
            MinimumSize = new Size(900, 423);
            Name = "MainForm";
            SizeGripStyle = SizeGripStyle.Hide;
            Text = "Brake Disk Plugin";
            MainLayoutPanel.ResumeLayout(false);
            ParametersPanel.ResumeLayout(false);
            ParametersPanel.PerformLayout();
            BuildingPanel.ResumeLayout(false);
            InfoPanel.ResumeLayout(false);
            InfoPanel.PerformLayout();
            ActionsPanel.ResumeLayout(false);
            ActionsLayoutPanel.ResumeLayout(false);
            OptionsPanel.ResumeLayout(false);
            OptionsPanel.PerformLayout();
            ButtonPanel.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel MainLayoutPanel;
        private Panel ParametersPanel;
        private TextBox WidthWorkingSurfaceTextBox;
        private TextBox WidthLowerFastenerTextBox;
        private TextBox WidthHigherFastenerTextBox;
        private TextBox CenteringDiameterTextBox;
        private TextBox LowerBrakeDiskDiameterTextBox;
        private TextBox HigherBrakeDiskDiameterTextBox;
        private TextBox BrakeDiskDiameterTextBox;
        private TextBox FastenerDiameterTextBox;
        private TableLayoutPanel BuildingPanel;
        private Panel InfoPanel;
        private Panel ActionsPanel;
        private TableLayoutPanel ActionsLayoutPanel;
        private Panel ButtonPanel;
        private Button BuildButton;
        private Panel OptionsPanel;
        private Label Optionslabel;
        private CheckBox NewFigureCheckBox;
        private CheckBox FeatureСheckBox;
        private TextBox InfoTextBox;
    }
}