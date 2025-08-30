namespace DiablerieLoot
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.lblRepeat = new System.Windows.Forms.Label();
            this.lblChallengeRating = new System.Windows.Forms.Label();
            this.lblType = new System.Windows.Forms.Label();
            this.numRepeat = new System.Windows.Forms.NumericUpDown();
            this.numChallengeRating = new System.Windows.Forms.NumericUpDown();
            this.dropdownType = new System.Windows.Forms.ComboBox();
            this.checkVerbose = new System.Windows.Forms.CheckBox();
            this.checkManuel = new System.Windows.Forms.CheckBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnRoll = new System.Windows.Forms.Button();
            this.textLog = new System.Windows.Forms.RichTextBox();
            this.btnCopyContent = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnSaveToFile = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numRepeat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numChallengeRating)).BeginInit();
            this.SuspendLayout();
            // 
            // lblRepeat
            // 
            this.lblRepeat.AutoSize = true;
            this.lblRepeat.Location = new System.Drawing.Point(12, 9);
            this.lblRepeat.Name = "lblRepeat";
            this.lblRepeat.Size = new System.Drawing.Size(42, 13);
            this.lblRepeat.TabIndex = 0;
            this.lblRepeat.Text = "Repeat";
            // 
            // lblChallengeRating
            // 
            this.lblChallengeRating.AutoSize = true;
            this.lblChallengeRating.Location = new System.Drawing.Point(12, 35);
            this.lblChallengeRating.Name = "lblChallengeRating";
            this.lblChallengeRating.Size = new System.Drawing.Size(88, 13);
            this.lblChallengeRating.TabIndex = 1;
            this.lblChallengeRating.Text = "Challenge Rating";
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Location = new System.Drawing.Point(12, 62);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(31, 13);
            this.lblType.TabIndex = 3;
            this.lblType.Text = "Type";
            // 
            // numRepeat
            // 
            this.numRepeat.Location = new System.Drawing.Point(106, 7);
            this.numRepeat.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numRepeat.Name = "numRepeat";
            this.numRepeat.Size = new System.Drawing.Size(49, 20);
            this.numRepeat.TabIndex = 0;
            this.numRepeat.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numChallengeRating
            // 
            this.numChallengeRating.Location = new System.Drawing.Point(106, 33);
            this.numChallengeRating.Name = "numChallengeRating";
            this.numChallengeRating.Size = new System.Drawing.Size(49, 20);
            this.numChallengeRating.TabIndex = 1;
            // 
            // dropdownType
            // 
            this.dropdownType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.dropdownType.FormattingEnabled = true;
            this.dropdownType.Location = new System.Drawing.Point(106, 59);
            this.dropdownType.Name = "dropdownType";
            this.dropdownType.Size = new System.Drawing.Size(121, 21);
            this.dropdownType.TabIndex = 3;
            // 
            // checkVerbose
            // 
            this.checkVerbose.AutoSize = true;
            this.checkVerbose.Location = new System.Drawing.Point(162, 8);
            this.checkVerbose.Name = "checkVerbose";
            this.checkVerbose.Size = new System.Drawing.Size(65, 17);
            this.checkVerbose.TabIndex = 4;
            this.checkVerbose.Text = "Verbose";
            this.checkVerbose.UseVisualStyleBackColor = true;
            this.checkVerbose.CheckedChanged += new System.EventHandler(this.checkVerbose_CheckedChanged);
            // 
            // checkManuel
            // 
            this.checkManuel.AutoSize = true;
            this.checkManuel.Location = new System.Drawing.Point(162, 34);
            this.checkManuel.Name = "checkManuel";
            this.checkManuel.Size = new System.Drawing.Size(61, 17);
            this.checkManuel.TabIndex = 5;
            this.checkManuel.Text = "Manuel";
            this.checkManuel.UseVisualStyleBackColor = true;
            this.checkManuel.CheckedChanged += new System.EventHandler(this.checkManuel_CheckedChanged);
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnExit.Location = new System.Drawing.Point(12, 357);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 8;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnRoll
            // 
            this.btnRoll.Font = new System.Drawing.Font("Microsoft Sans Serif", 40F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRoll.Location = new System.Drawing.Point(15, 86);
            this.btnRoll.Name = "btnRoll";
            this.btnRoll.Size = new System.Drawing.Size(212, 88);
            this.btnRoll.TabIndex = 6;
            this.btnRoll.Text = "Roll";
            this.btnRoll.UseVisualStyleBackColor = true;
            this.btnRoll.Click += new System.EventHandler(this.btnRoll_Click);
            // 
            // textLog
            // 
            this.textLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textLog.Location = new System.Drawing.Point(233, 6);
            this.textLog.Name = "textLog";
            this.textLog.Size = new System.Drawing.Size(555, 345);
            this.textLog.TabIndex = 7;
            this.textLog.Text = "";
            // 
            // btnCopyContent
            // 
            this.btnCopyContent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCopyContent.Location = new System.Drawing.Point(233, 357);
            this.btnCopyContent.Name = "btnCopyContent";
            this.btnCopyContent.Size = new System.Drawing.Size(88, 23);
            this.btnCopyContent.TabIndex = 9;
            this.btnCopyContent.Text = "Copy content";
            this.btnCopyContent.UseVisualStyleBackColor = true;
            this.btnCopyContent.Click += new System.EventHandler(this.btnCopyContent_Click);
            // 
            // btnClear
            // 
            this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClear.Location = new System.Drawing.Point(713, 357);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 11;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnSaveToFile
            // 
            this.btnSaveToFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSaveToFile.Location = new System.Drawing.Point(327, 357);
            this.btnSaveToFile.Name = "btnSaveToFile";
            this.btnSaveToFile.Size = new System.Drawing.Size(88, 23);
            this.btnSaveToFile.TabIndex = 10;
            this.btnSaveToFile.Text = "Save to file";
            this.btnSaveToFile.UseVisualStyleBackColor = true;
            this.btnSaveToFile.Click += new System.EventHandler(this.btnSaveToFile_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 392);
            this.Controls.Add(this.btnSaveToFile);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnCopyContent);
            this.Controls.Add(this.textLog);
            this.Controls.Add(this.btnRoll);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.checkManuel);
            this.Controls.Add(this.checkVerbose);
            this.Controls.Add(this.dropdownType);
            this.Controls.Add(this.numChallengeRating);
            this.Controls.Add(this.numRepeat);
            this.Controls.Add(this.lblType);
            this.Controls.Add(this.lblChallengeRating);
            this.Controls.Add(this.lblRepeat);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(816, 431);
            this.Name = "Main";
            this.Text = "Diableriel Loot";
            ((System.ComponentModel.ISupportInitialize)(this.numRepeat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numChallengeRating)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblRepeat;
        private System.Windows.Forms.Label lblChallengeRating;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.NumericUpDown numRepeat;
        private System.Windows.Forms.NumericUpDown numChallengeRating;
        private System.Windows.Forms.ComboBox dropdownType;
        private System.Windows.Forms.CheckBox checkVerbose;
        private System.Windows.Forms.CheckBox checkManuel;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnRoll;
        private System.Windows.Forms.RichTextBox textLog;
        private System.Windows.Forms.Button btnCopyContent;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnSaveToFile;
    }
}

