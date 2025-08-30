namespace DiablerieLoot.Forms
{
    partial class DiceInputDialog
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
            this.numDiceRoll = new System.Windows.Forms.NumericUpDown();
            this.lblDice = new System.Windows.Forms.Label();
            this.btnRollForMe = new System.Windows.Forms.Button();
            this.btnAccept = new System.Windows.Forms.Button();
            this.lblRollType = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numDiceRoll)).BeginInit();
            this.SuspendLayout();
            // 
            // numDiceRoll
            // 
            this.numDiceRoll.Location = new System.Drawing.Point(12, 47);
            this.numDiceRoll.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.numDiceRoll.Minimum = new decimal(new int[] {
            999,
            0,
            0,
            -2147483648});
            this.numDiceRoll.Name = "numDiceRoll";
            this.numDiceRoll.Size = new System.Drawing.Size(75, 20);
            this.numDiceRoll.TabIndex = 0;
            // 
            // lblDice
            // 
            this.lblDice.AutoSize = true;
            this.lblDice.Location = new System.Drawing.Point(12, 9);
            this.lblDice.Name = "lblDice";
            this.lblDice.Size = new System.Drawing.Size(232, 13);
            this.lblDice.TabIndex = 1;
            this.lblDice.Text = "Roll a <X> sided dice and enter the result below";
            // 
            // btnRollForMe
            // 
            this.btnRollForMe.Location = new System.Drawing.Point(93, 44);
            this.btnRollForMe.Name = "btnRollForMe";
            this.btnRollForMe.Size = new System.Drawing.Size(162, 23);
            this.btnRollForMe.TabIndex = 1;
            this.btnRollForMe.Text = "Roll for me";
            this.btnRollForMe.UseVisualStyleBackColor = true;
            this.btnRollForMe.Click += new System.EventHandler(this.btnRollForMe_Click);
            // 
            // btnAccept
            // 
            this.btnAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAccept.Location = new System.Drawing.Point(12, 73);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(243, 23);
            this.btnAccept.TabIndex = 2;
            this.btnAccept.Text = "Accept";
            this.btnAccept.UseVisualStyleBackColor = true;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // lblRollType
            // 
            this.lblRollType.AutoSize = true;
            this.lblRollType.Location = new System.Drawing.Point(12, 31);
            this.lblRollType.Name = "lblRollType";
            this.lblRollType.Size = new System.Drawing.Size(71, 13);
            this.lblRollType.TabIndex = 3;
            this.lblRollType.Text = "<Type of roll>";
            // 
            // DiceInputDialog
            // 
            this.AcceptButton = this.btnAccept;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(277, 108);
            this.ControlBox = false;
            this.Controls.Add(this.lblRollType);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.btnRollForMe);
            this.Controls.Add(this.lblDice);
            this.Controls.Add(this.numDiceRoll);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximumSize = new System.Drawing.Size(283, 114);
            this.MinimumSize = new System.Drawing.Size(283, 114);
            this.Name = "DiceInputDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            ((System.ComponentModel.ISupportInitialize)(this.numDiceRoll)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown numDiceRoll;
        private System.Windows.Forms.Label lblDice;
        private System.Windows.Forms.Button btnRollForMe;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.Label lblRollType;
    }
}