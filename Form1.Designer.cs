namespace DiceRoller
{
    partial class Form1
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            custom_button = new Button();
            button_d4 = new Button();
            button_d6 = new Button();
            button_d8 = new Button();
            button1 = new Button();
            button_d10 = new Button();
            button_d12 = new Button();
            button_d20 = new Button();
            button_d100 = new Button();
            label9 = new Label();
            numberdice = new NumericUpDown();
            buttonstats = new Button();
            label10 = new Label();
            plusamount = new NumericUpDown();
            label11 = new Label();
            customroll = new TextBox();
            resultsbox = new RichTextBox();
            tooltip = new ToolTip(components);
            ((System.ComponentModel.ISupportInitialize)numberdice).BeginInit();
            ((System.ComponentModel.ISupportInitialize)plusamount).BeginInit();
            SuspendLayout();
            // 
            // custom_button
            // 
            custom_button.BackgroundImage = (Image)resources.GetObject("custom_button.BackgroundImage");
            custom_button.BackgroundImageLayout = ImageLayout.Zoom;
            custom_button.FlatStyle = FlatStyle.Flat;
            custom_button.Location = new Point(12, 12);
            custom_button.Name = "custom_button";
            custom_button.Size = new Size(50, 50);
            custom_button.TabIndex = 0;
            tooltip.SetToolTip(custom_button, "About Dice Roller\r\nclick to get information.");
            custom_button.UseVisualStyleBackColor = true;
            custom_button.Click += AboutIt;
            custom_button.MouseClick += HandleCustomBtn;
            // 
            // button_d4
            // 
            button_d4.BackgroundImage = (Image)resources.GetObject("button_d4.BackgroundImage");
            button_d4.BackgroundImageLayout = ImageLayout.Zoom;
            button_d4.FlatStyle = FlatStyle.Flat;
            button_d4.Location = new Point(68, 12);
            button_d4.Name = "button_d4";
            button_d4.Size = new Size(50, 50);
            button_d4.TabIndex = 1;
            tooltip.SetToolTip(button_d4, "d4\r\nclick to roll d4.");
            button_d4.UseVisualStyleBackColor = true;
            button_d4.Click += Do_d4;
            // 
            // button_d6
            // 
            button_d6.BackgroundImage = (Image)resources.GetObject("button_d6.BackgroundImage");
            button_d6.BackgroundImageLayout = ImageLayout.Zoom;
            button_d6.FlatStyle = FlatStyle.Flat;
            button_d6.Location = new Point(124, 12);
            button_d6.Name = "button_d6";
            button_d6.Size = new Size(50, 50);
            button_d6.TabIndex = 1;
            tooltip.SetToolTip(button_d6, "d6\r\nclick to roll d6");
            button_d6.UseVisualStyleBackColor = true;
            button_d6.Click += Do_d6;
            // 
            // button_d8
            // 
            button_d8.BackgroundImage = (Image)resources.GetObject("button_d8.BackgroundImage");
            button_d8.BackgroundImageLayout = ImageLayout.Zoom;
            button_d8.FlatStyle = FlatStyle.Flat;
            button_d8.Location = new Point(180, 12);
            button_d8.Name = "button_d8";
            button_d8.Size = new Size(50, 50);
            button_d8.TabIndex = 1;
            tooltip.SetToolTip(button_d8, "d8\r\nclick to roll d8");
            button_d8.UseVisualStyleBackColor = true;
            button_d8.Click += Do_d8;
            // 
            // button1
            // 
            button1.BackgroundImage = (Image)resources.GetObject("button1.BackgroundImage");
            button1.BackgroundImageLayout = ImageLayout.Zoom;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Location = new Point(236, 12);
            button1.Name = "button1";
            button1.Size = new Size(50, 50);
            button1.TabIndex = 1;
            button1.UseVisualStyleBackColor = true;
            // 
            // button_d10
            // 
            button_d10.BackgroundImage = (Image)resources.GetObject("button_d10.BackgroundImage");
            button_d10.BackgroundImageLayout = ImageLayout.Zoom;
            button_d10.FlatStyle = FlatStyle.Flat;
            button_d10.Location = new Point(236, 12);
            button_d10.Name = "button_d10";
            button_d10.Size = new Size(50, 50);
            button_d10.TabIndex = 1;
            tooltip.SetToolTip(button_d10, "d10\r\nclick to roll d10");
            button_d10.UseVisualStyleBackColor = true;
            button_d10.Click += Do_d10;
            // 
            // button_d12
            // 
            button_d12.BackgroundImage = (Image)resources.GetObject("button_d12.BackgroundImage");
            button_d12.BackgroundImageLayout = ImageLayout.Zoom;
            button_d12.FlatStyle = FlatStyle.Flat;
            button_d12.Location = new Point(292, 12);
            button_d12.Name = "button_d12";
            button_d12.Size = new Size(50, 50);
            button_d12.TabIndex = 1;
            tooltip.SetToolTip(button_d12, "d12\r\nclick to roll d12");
            button_d12.UseVisualStyleBackColor = true;
            button_d12.Click += Do_d12;
            // 
            // button_d20
            // 
            button_d20.BackgroundImage = (Image)resources.GetObject("button_d20.BackgroundImage");
            button_d20.BackgroundImageLayout = ImageLayout.Zoom;
            button_d20.FlatStyle = FlatStyle.Flat;
            button_d20.Location = new Point(348, 12);
            button_d20.Name = "button_d20";
            button_d20.Size = new Size(50, 50);
            button_d20.TabIndex = 1;
            tooltip.SetToolTip(button_d20, "d20\r\nclick to roll d20");
            button_d20.UseVisualStyleBackColor = true;
            button_d20.Click += Do_d20;
            // 
            // button_d100
            // 
            button_d100.BackgroundImage = (Image)resources.GetObject("button_d100.BackgroundImage");
            button_d100.BackgroundImageLayout = ImageLayout.Zoom;
            button_d100.FlatStyle = FlatStyle.Flat;
            button_d100.Location = new Point(404, 12);
            button_d100.Name = "button_d100";
            button_d100.Size = new Size(50, 50);
            button_d100.TabIndex = 1;
            button_d100.UseVisualStyleBackColor = true;
            button_d100.Click += Do_d100;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.ForeColor = Color.White;
            label9.Location = new Point(12, 70);
            label9.Name = "label9";
            label9.Size = new Size(55, 20);
            label9.TabIndex = 3;
            label9.Text = "# Dice:";
            // 
            // numberdice
            // 
            numberdice.Location = new Point(73, 68);
            numberdice.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numberdice.Name = "numberdice";
            numberdice.Size = new Size(77, 27);
            numberdice.TabIndex = 4;
            tooltip.SetToolTip(numberdice, "# dice\r\nAdjust number of dice rolled.\r\n(0 - 99)");
            numberdice.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // buttonstats
            // 
            buttonstats.Location = new Point(170, 67);
            buttonstats.Name = "buttonstats";
            buttonstats.Size = new Size(110, 27);
            buttonstats.TabIndex = 5;
            buttonstats.Text = "Ability Scores";
            tooltip.SetToolTip(buttonstats, "Ability Scores\r\nclick to roll stats");
            buttonstats.UseVisualStyleBackColor = true;
            buttonstats.Click += DoStats;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.ForeColor = Color.White;
            label10.Location = new Point(292, 68);
            label10.Name = "label10";
            label10.Size = new Size(79, 20);
            label10.TabIndex = 3;
            label10.Text = "+ Amount:";
            // 
            // plusamount
            // 
            plusamount.Location = new Point(377, 68);
            plusamount.Minimum = new decimal(new int[] { 100, 0, 0, int.MinValue });
            plusamount.Name = "plusamount";
            plusamount.Size = new Size(77, 27);
            plusamount.TabIndex = 6;
            tooltip.SetToolTip(plusamount, "+ Amount\r\nadjust added amount to dice roll\r\n(-100 to 100)");
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.ForeColor = Color.White;
            label11.Location = new Point(12, 104);
            label11.Name = "label11";
            label11.Size = new Size(92, 20);
            label11.TabIndex = 7;
            label11.Text = "Custom Roll:";
            // 
            // customroll
            // 
            customroll.BackColor = Color.Black;
            customroll.ForeColor = Color.White;
            customroll.Location = new Point(110, 101);
            customroll.Name = "customroll";
            customroll.PlaceholderText = "Enter custom roll formula here.";
            customroll.Size = new Size(344, 27);
            customroll.TabIndex = 8;
            tooltip.SetToolTip(customroll, "Custom Roll Formula\r\ndouble click to get help about formulae");
            customroll.DoubleClick += ShowCustomRollHelp;
            customroll.KeyUp += CustomKey;
            // 
            // resultsbox
            // 
            resultsbox.BackColor = Color.Black;
            resultsbox.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            resultsbox.ForeColor = Color.White;
            resultsbox.Location = new Point(12, 134);
            resultsbox.Name = "resultsbox";
            resultsbox.Size = new Size(442, 640);
            resultsbox.TabIndex = 9;
            resultsbox.Text = "";
            tooltip.SetToolTip(resultsbox, "Results Area\r\nDouble click to clear previolus  results");
            resultsbox.DoubleClick += ClearResults;
            // 
            // tooltip
            // 
            tooltip.BackColor = Color.Yellow;
            tooltip.ForeColor = Color.Black;
            tooltip.IsBalloon = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(15, 15, 15);
            ClientSize = new Size(465, 786);
            Controls.Add(resultsbox);
            Controls.Add(customroll);
            Controls.Add(label11);
            Controls.Add(plusamount);
            Controls.Add(buttonstats);
            Controls.Add(numberdice);
            Controls.Add(label10);
            Controls.Add(label9);
            Controls.Add(button_d100);
            Controls.Add(button_d20);
            Controls.Add(button_d12);
            Controls.Add(button_d10);
            Controls.Add(button1);
            Controls.Add(button_d8);
            Controls.Add(button_d6);
            Controls.Add(button_d4);
            Controls.Add(custom_button);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form1";
            Text = "Dice Roller";
            ((System.ComponentModel.ISupportInitialize)numberdice).EndInit();
            ((System.ComponentModel.ISupportInitialize)plusamount).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button custom_button;
        private Button button_d4;
        private Button button_d6;
        private Button button_d8;
        private Button button1;
        private Button button_d10;
        private Button button_d12;
        private Button button_d20;
        private Button button_d100;
        private Label label9;
        private NumericUpDown numberdice;
        private Button buttonstats;
        private Label label10;
        private NumericUpDown plusamount;
        private Label label11;
        private TextBox customroll;
        private RichTextBox resultsbox;
        private ToolTip tooltip;
    }
}