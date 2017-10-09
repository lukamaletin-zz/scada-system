namespace DatabaseManager
{
    partial class AlarmForm
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
            this.labelLowLimit = new System.Windows.Forms.Label();
            this.labelHighLimit = new System.Windows.Forms.Label();
            this.labelId = new System.Windows.Forms.Label();
            this.textBoxId = new System.Windows.Forms.TextBox();
            this.textBoxLowLimit = new System.Windows.Forms.TextBox();
            this.textBoxHighLimit = new System.Windows.Forms.TextBox();
            this.buttonDone = new System.Windows.Forms.Button();
            this.radioButtonZero = new System.Windows.Forms.RadioButton();
            this.radioButtonOne = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // labelLowLimit
            // 
            this.labelLowLimit.AutoSize = true;
            this.labelLowLimit.Location = new System.Drawing.Point(7, 78);
            this.labelLowLimit.Name = "labelLowLimit";
            this.labelLowLimit.Size = new System.Drawing.Size(51, 13);
            this.labelLowLimit.TabIndex = 0;
            this.labelLowLimit.Text = "Low Limit";
            // 
            // labelHighLimit
            // 
            this.labelHighLimit.AutoSize = true;
            this.labelHighLimit.Location = new System.Drawing.Point(5, 129);
            this.labelHighLimit.Name = "labelHighLimit";
            this.labelHighLimit.Size = new System.Drawing.Size(53, 13);
            this.labelHighLimit.TabIndex = 1;
            this.labelHighLimit.Text = "High Limit";
            // 
            // labelId
            // 
            this.labelId.AutoSize = true;
            this.labelId.Location = new System.Drawing.Point(11, 27);
            this.labelId.Name = "labelId";
            this.labelId.Size = new System.Drawing.Size(47, 13);
            this.labelId.TabIndex = 2;
            this.labelId.Text = "Alarm ID";
            // 
            // textBoxId
            // 
            this.textBoxId.Location = new System.Drawing.Point(64, 24);
            this.textBoxId.Name = "textBoxId";
            this.textBoxId.Size = new System.Drawing.Size(100, 20);
            this.textBoxId.TabIndex = 3;
            // 
            // textBoxLowLimit
            // 
            this.textBoxLowLimit.Location = new System.Drawing.Point(64, 75);
            this.textBoxLowLimit.Name = "textBoxLowLimit";
            this.textBoxLowLimit.Size = new System.Drawing.Size(100, 20);
            this.textBoxLowLimit.TabIndex = 4;
            // 
            // textBoxHighLimit
            // 
            this.textBoxHighLimit.Location = new System.Drawing.Point(64, 126);
            this.textBoxHighLimit.Name = "textBoxHighLimit";
            this.textBoxHighLimit.Size = new System.Drawing.Size(100, 20);
            this.textBoxHighLimit.TabIndex = 5;
            // 
            // buttonDone
            // 
            this.buttonDone.Location = new System.Drawing.Point(12, 169);
            this.buttonDone.Name = "buttonDone";
            this.buttonDone.Size = new System.Drawing.Size(210, 30);
            this.buttonDone.TabIndex = 6;
            this.buttonDone.Text = "Done";
            this.buttonDone.UseVisualStyleBackColor = true;
            this.buttonDone.Click += new System.EventHandler(this.buttonDone_Click);
            // 
            // radioButtonZero
            // 
            this.radioButtonZero.AutoSize = true;
            this.radioButtonZero.Location = new System.Drawing.Point(8, 76);
            this.radioButtonZero.Name = "radioButtonZero";
            this.radioButtonZero.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.radioButtonZero.Size = new System.Drawing.Size(76, 17);
            this.radioButtonZero.TabIndex = 7;
            this.radioButtonZero.TabStop = true;
            this.radioButtonZero.Text = "Constant 0";
            this.radioButtonZero.UseVisualStyleBackColor = true;
            // 
            // radioButtonOne
            // 
            this.radioButtonOne.AutoSize = true;
            this.radioButtonOne.Location = new System.Drawing.Point(8, 127);
            this.radioButtonOne.Name = "radioButtonOne";
            this.radioButtonOne.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.radioButtonOne.Size = new System.Drawing.Size(76, 17);
            this.radioButtonOne.TabIndex = 8;
            this.radioButtonOne.TabStop = true;
            this.radioButtonOne.Text = "Constant 1";
            this.radioButtonOne.UseVisualStyleBackColor = true;
            // 
            // AlarmForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(234, 211);
            this.Controls.Add(this.radioButtonOne);
            this.Controls.Add(this.radioButtonZero);
            this.Controls.Add(this.buttonDone);
            this.Controls.Add(this.textBoxHighLimit);
            this.Controls.Add(this.textBoxLowLimit);
            this.Controls.Add(this.textBoxId);
            this.Controls.Add(this.labelId);
            this.Controls.Add(this.labelHighLimit);
            this.Controls.Add(this.labelLowLimit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "AlarmForm";
            this.Text = "AlarmForm";
            this.Closing += AlarmForm_FormClosing;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelLowLimit;
        private System.Windows.Forms.Label labelHighLimit;
        private System.Windows.Forms.Label labelId;
        private System.Windows.Forms.TextBox textBoxId;
        private System.Windows.Forms.TextBox textBoxLowLimit;
        private System.Windows.Forms.TextBox textBoxHighLimit;
        private System.Windows.Forms.Button buttonDone;
        private System.Windows.Forms.RadioButton radioButtonZero;
        private System.Windows.Forms.RadioButton radioButtonOne;
    }
}