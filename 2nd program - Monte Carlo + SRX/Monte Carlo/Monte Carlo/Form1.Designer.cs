namespace Monte_Carlo
{
    partial class Form1
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.sizexTextBox = new System.Windows.Forms.TextBox();
            this.sizeyTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.nucleonsAmountNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.numberOfIterationsTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.startButton = new System.Windows.Forms.Button();
            this.startCAButton = new System.Windows.Forms.Button();
            this.probabilityTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.CARadioButton = new System.Windows.Forms.RadioButton();
            this.MCRadioButton = new System.Windows.Forms.RadioButton();
            this.label6 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.nucleonsToDualPhaseNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.resetButton = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label8 = new System.Windows.Forms.Label();
            this.selectBordersBTN = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.energyDistributionComboBox = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.energyInsideTextbox = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.energyOnEdgesTextbox = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.NucleationRateTextbox = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.nucleonsPlacementCombobox = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.nucleationTypeCombobox = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.nucleonsOnStartTextbox = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.srxIterationsTextbox = new System.Windows.Forms.TextBox();
            this.startSRXBtn = new System.Windows.Forms.Button();
            this.label17 = new System.Windows.Forms.Label();
            this.stopConditionTextbox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nucleonsAmountNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nucleonsToDualPhaseNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.pictureBox1.Location = new System.Drawing.Point(12, 83);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(500, 500);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // sizexTextBox
            // 
            this.sizexTextBox.Location = new System.Drawing.Point(12, 42);
            this.sizexTextBox.Name = "sizexTextBox";
            this.sizexTextBox.Size = new System.Drawing.Size(92, 20);
            this.sizexTextBox.TabIndex = 1;
            // 
            // sizeyTextBox
            // 
            this.sizeyTextBox.Location = new System.Drawing.Point(110, 42);
            this.sizeyTextBox.Name = "sizeyTextBox";
            this.sizeyTextBox.Size = new System.Drawing.Size(100, 20);
            this.sizeyTextBox.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Size X";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(107, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Size Y";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(213, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Nucleons Amount";
            // 
            // nucleonsAmountNumericUpDown
            // 
            this.nucleonsAmountNumericUpDown.Location = new System.Drawing.Point(216, 43);
            this.nucleonsAmountNumericUpDown.Name = "nucleonsAmountNumericUpDown";
            this.nucleonsAmountNumericUpDown.Size = new System.Drawing.Size(120, 20);
            this.nucleonsAmountNumericUpDown.TabIndex = 6;
            // 
            // numberOfIterationsTextBox
            // 
            this.numberOfIterationsTextBox.Location = new System.Drawing.Point(342, 43);
            this.numberOfIterationsTextBox.Name = "numberOfIterationsTextBox";
            this.numberOfIterationsTextBox.Size = new System.Drawing.Size(100, 20);
            this.numberOfIterationsTextBox.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(339, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Number of Iterations";
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(564, 13);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(109, 23);
            this.startButton.TabIndex = 9;
            this.startButton.Text = "START MC";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // startCAButton
            // 
            this.startCAButton.Location = new System.Drawing.Point(564, 42);
            this.startCAButton.Name = "startCAButton";
            this.startCAButton.Size = new System.Drawing.Size(109, 23);
            this.startCAButton.TabIndex = 10;
            this.startCAButton.Text = "START CA";
            this.startCAButton.UseVisualStyleBackColor = true;
            this.startCAButton.Click += new System.EventHandler(this.startCAButton_Click);
            // 
            // probabilityTextBox
            // 
            this.probabilityTextBox.Location = new System.Drawing.Point(448, 43);
            this.probabilityTextBox.Name = "probabilityTextBox";
            this.probabilityTextBox.Size = new System.Drawing.Size(100, 20);
            this.probabilityTextBox.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(448, 27);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(93, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Probability (for CA)";
            // 
            // CARadioButton
            // 
            this.CARadioButton.AutoSize = true;
            this.CARadioButton.Checked = true;
            this.CARadioButton.Location = new System.Drawing.Point(682, 29);
            this.CARadioButton.Name = "CARadioButton";
            this.CARadioButton.Size = new System.Drawing.Size(39, 17);
            this.CARadioButton.TabIndex = 13;
            this.CARadioButton.TabStop = true;
            this.CARadioButton.Text = "CA";
            this.CARadioButton.UseVisualStyleBackColor = true;
            // 
            // MCRadioButton
            // 
            this.MCRadioButton.AutoSize = true;
            this.MCRadioButton.Location = new System.Drawing.Point(727, 29);
            this.MCRadioButton.Name = "MCRadioButton";
            this.MCRadioButton.Size = new System.Drawing.Size(41, 17);
            this.MCRadioButton.TabIndex = 14;
            this.MCRadioButton.Text = "MC";
            this.MCRadioButton.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(679, 13);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(101, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "Dual Phase Method";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(913, 13);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(121, 40);
            this.button1.TabIndex = 16;
            this.button1.Text = "START DUAL PHASE";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // nucleonsToDualPhaseNumericUpDown
            // 
            this.nucleonsToDualPhaseNumericUpDown.Location = new System.Drawing.Point(786, 29);
            this.nucleonsToDualPhaseNumericUpDown.Name = "nucleonsToDualPhaseNumericUpDown";
            this.nucleonsToDualPhaseNumericUpDown.Size = new System.Drawing.Size(121, 20);
            this.nucleonsToDualPhaseNumericUpDown.TabIndex = 17;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(786, 13);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(121, 13);
            this.label7.TabIndex = 18;
            this.label7.Text = "Nucleons Amount to DP";
            // 
            // resetButton
            // 
            this.resetButton.Location = new System.Drawing.Point(521, 552);
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(118, 31);
            this.resetButton.TabIndex = 19;
            this.resetButton.Text = "RESET";
            this.resetButton.UseVisualStyleBackColor = true;
            this.resetButton.Click += new System.EventHandler(this.resetButton_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.SystemColors.ControlDark;
            this.pictureBox2.Location = new System.Drawing.Point(655, 83);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(500, 500);
            this.pictureBox2.TabIndex = 20;
            this.pictureBox2.TabStop = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(518, 83);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(89, 13);
            this.label8.TabIndex = 21;
            this.label8.Text = "Monte Carlo SRX";
            // 
            // selectBordersBTN
            // 
            this.selectBordersBTN.Location = new System.Drawing.Point(518, 99);
            this.selectBordersBTN.Name = "selectBordersBTN";
            this.selectBordersBTN.Size = new System.Drawing.Size(118, 35);
            this.selectBordersBTN.TabIndex = 22;
            this.selectBordersBTN.Text = "SELECT BORDRES";
            this.selectBordersBTN.UseVisualStyleBackColor = true;
            this.selectBordersBTN.Click += new System.EventHandler(this.selectBordersBTN_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(518, 137);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(95, 13);
            this.label9.TabIndex = 23;
            this.label9.Text = "Energy Distribution";
            // 
            // energyDistributionComboBox
            // 
            this.energyDistributionComboBox.FormattingEnabled = true;
            this.energyDistributionComboBox.Items.AddRange(new object[] {
            "Homogenous",
            "Heterogenous"});
            this.energyDistributionComboBox.Location = new System.Drawing.Point(518, 153);
            this.energyDistributionComboBox.Name = "energyDistributionComboBox";
            this.energyDistributionComboBox.Size = new System.Drawing.Size(121, 21);
            this.energyDistributionComboBox.TabIndex = 24;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(518, 177);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(71, 13);
            this.label10.TabIndex = 25;
            this.label10.Text = "Energy Inside";
            // 
            // energyInsideTextbox
            // 
            this.energyInsideTextbox.Location = new System.Drawing.Point(518, 193);
            this.energyInsideTextbox.Name = "energyInsideTextbox";
            this.energyInsideTextbox.Size = new System.Drawing.Size(121, 20);
            this.energyInsideTextbox.TabIndex = 26;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(518, 216);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(88, 13);
            this.label11.TabIndex = 27;
            this.label11.Text = "Energy on Edges";
            // 
            // energyOnEdgesTextbox
            // 
            this.energyOnEdgesTextbox.Location = new System.Drawing.Point(521, 232);
            this.energyOnEdgesTextbox.Name = "energyOnEdgesTextbox";
            this.energyOnEdgesTextbox.Size = new System.Drawing.Size(118, 20);
            this.energyOnEdgesTextbox.TabIndex = 28;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(518, 255);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(84, 13);
            this.label12.TabIndex = 29;
            this.label12.Text = "Nucleation Rate";
            // 
            // NucleationRateTextbox
            // 
            this.NucleationRateTextbox.Location = new System.Drawing.Point(521, 271);
            this.NucleationRateTextbox.Name = "NucleationRateTextbox";
            this.NucleationRateTextbox.Size = new System.Drawing.Size(118, 20);
            this.NucleationRateTextbox.TabIndex = 30;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(518, 294);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(105, 13);
            this.label13.TabIndex = 31;
            this.label13.Text = "Nucleons Placement";
            // 
            // nucleonsPlacementCombobox
            // 
            this.nucleonsPlacementCombobox.FormattingEnabled = true;
            this.nucleonsPlacementCombobox.Items.AddRange(new object[] {
            "Edges",
            "Anywhere"});
            this.nucleonsPlacementCombobox.Location = new System.Drawing.Point(521, 310);
            this.nucleonsPlacementCombobox.Name = "nucleonsPlacementCombobox";
            this.nucleonsPlacementCombobox.Size = new System.Drawing.Size(118, 21);
            this.nucleonsPlacementCombobox.TabIndex = 32;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(518, 334);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(85, 13);
            this.label14.TabIndex = 33;
            this.label14.Text = "Nucleation Type";
            // 
            // nucleationTypeCombobox
            // 
            this.nucleationTypeCombobox.FormattingEnabled = true;
            this.nucleationTypeCombobox.Items.AddRange(new object[] {
            "Constant",
            "Increasing"});
            this.nucleationTypeCombobox.Location = new System.Drawing.Point(521, 350);
            this.nucleationTypeCombobox.Name = "nucleationTypeCombobox";
            this.nucleationTypeCombobox.Size = new System.Drawing.Size(118, 21);
            this.nucleationTypeCombobox.TabIndex = 34;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(518, 374);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(92, 13);
            this.label15.TabIndex = 35;
            this.label15.Text = "Nucleons on Start";
            // 
            // nucleonsOnStartTextbox
            // 
            this.nucleonsOnStartTextbox.Location = new System.Drawing.Point(521, 390);
            this.nucleonsOnStartTextbox.Name = "nucleonsOnStartTextbox";
            this.nucleonsOnStartTextbox.Size = new System.Drawing.Size(118, 20);
            this.nucleonsOnStartTextbox.TabIndex = 36;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(518, 413);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(50, 13);
            this.label16.TabIndex = 37;
            this.label16.Text = "Iterations";
            // 
            // srxIterationsTextbox
            // 
            this.srxIterationsTextbox.Location = new System.Drawing.Point(521, 429);
            this.srxIterationsTextbox.Name = "srxIterationsTextbox";
            this.srxIterationsTextbox.Size = new System.Drawing.Size(118, 20);
            this.srxIterationsTextbox.TabIndex = 38;
            // 
            // startSRXBtn
            // 
            this.startSRXBtn.Location = new System.Drawing.Point(521, 509);
            this.startSRXBtn.Name = "startSRXBtn";
            this.startSRXBtn.Size = new System.Drawing.Size(118, 37);
            this.startSRXBtn.TabIndex = 39;
            this.startSRXBtn.Text = "START SRX";
            this.startSRXBtn.UseVisualStyleBackColor = true;
            this.startSRXBtn.Click += new System.EventHandler(this.startSRXBtn_Click);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(518, 452);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(76, 13);
            this.label17.TabIndex = 40;
            this.label17.Text = "Stop Condition";
            // 
            // stopConditionTextbox
            // 
            this.stopConditionTextbox.Location = new System.Drawing.Point(521, 468);
            this.stopConditionTextbox.Name = "stopConditionTextbox";
            this.stopConditionTextbox.Size = new System.Drawing.Size(100, 20);
            this.stopConditionTextbox.TabIndex = 41;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1171, 594);
            this.Controls.Add(this.stopConditionTextbox);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.startSRXBtn);
            this.Controls.Add(this.srxIterationsTextbox);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.nucleonsOnStartTextbox);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.nucleationTypeCombobox);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.nucleonsPlacementCombobox);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.NucleationRateTextbox);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.energyOnEdgesTextbox);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.energyInsideTextbox);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.energyDistributionComboBox);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.selectBordersBTN);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.resetButton);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.nucleonsToDualPhaseNumericUpDown);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.MCRadioButton);
            this.Controls.Add(this.CARadioButton);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.probabilityTextBox);
            this.Controls.Add(this.startCAButton);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.numberOfIterationsTextBox);
            this.Controls.Add(this.nucleonsAmountNumericUpDown);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.sizeyTextBox);
            this.Controls.Add(this.sizexTextBox);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "Monte Carlo";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nucleonsAmountNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nucleonsToDualPhaseNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox sizexTextBox;
        private System.Windows.Forms.TextBox sizeyTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nucleonsAmountNumericUpDown;
        private System.Windows.Forms.TextBox numberOfIterationsTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Button startCAButton;
        private System.Windows.Forms.TextBox probabilityTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RadioButton CARadioButton;
        private System.Windows.Forms.RadioButton MCRadioButton;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.NumericUpDown nucleonsToDualPhaseNumericUpDown;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button resetButton;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button selectBordersBTN;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox energyDistributionComboBox;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox energyInsideTextbox;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox energyOnEdgesTextbox;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox NucleationRateTextbox;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox nucleonsPlacementCombobox;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox nucleationTypeCombobox;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox nucleonsOnStartTextbox;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox srxIterationsTextbox;
        private System.Windows.Forms.Button startSRXBtn;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox stopConditionTextbox;
    }
}

