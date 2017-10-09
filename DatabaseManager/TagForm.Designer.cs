namespace DatabaseManager
{
    partial class TagForm
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
            this.textBoxId = new System.Windows.Forms.TextBox();
            this.textBoxDescription = new System.Windows.Forms.TextBox();
            this.textBoxAddress = new System.Windows.Forms.TextBox();
            this.textBoxScanTime = new System.Windows.Forms.TextBox();
            this.checkBoxOnScan = new System.Windows.Forms.CheckBox();
            this.checkBoxAutoMode = new System.Windows.Forms.CheckBox();
            this.textBoxInitialValue = new System.Windows.Forms.TextBox();
            this.textBoxLowLimit = new System.Windows.Forms.TextBox();
            this.textBoxHighLimit = new System.Windows.Forms.TextBox();
            this.textBoxUnits = new System.Windows.Forms.TextBox();
            this.comboBoxTagType = new System.Windows.Forms.ComboBox();
            this.labelTagType = new System.Windows.Forms.Label();
            this.labelId = new System.Windows.Forms.Label();
            this.labelDescription = new System.Windows.Forms.Label();
            this.labelAddress = new System.Windows.Forms.Label();
            this.labelInitialValue = new System.Windows.Forms.Label();
            this.labelScanTime = new System.Windows.Forms.Label();
            this.labelLowLimit = new System.Windows.Forms.Label();
            this.labelHighLimit = new System.Windows.Forms.Label();
            this.labelUnits = new System.Windows.Forms.Label();
            this.buttonDone = new System.Windows.Forms.Button();
            this.labelFunction = new System.Windows.Forms.Label();
            this.labelValue = new System.Windows.Forms.Label();
            this.textBoxValue = new System.Windows.Forms.TextBox();
            this.comboBoxFunction = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // textBoxId
            // 
            this.textBoxId.Location = new System.Drawing.Point(78, 39);
            this.textBoxId.Name = "textBoxId";
            this.textBoxId.Size = new System.Drawing.Size(100, 20);
            this.textBoxId.TabIndex = 3;
            // 
            // textBoxDescription
            // 
            this.textBoxDescription.Location = new System.Drawing.Point(78, 65);
            this.textBoxDescription.Name = "textBoxDescription";
            this.textBoxDescription.Size = new System.Drawing.Size(100, 20);
            this.textBoxDescription.TabIndex = 5;
            // 
            // textBoxAddress
            // 
            this.textBoxAddress.Location = new System.Drawing.Point(78, 91);
            this.textBoxAddress.Name = "textBoxAddress";
            this.textBoxAddress.Size = new System.Drawing.Size(100, 20);
            this.textBoxAddress.TabIndex = 7;
            // 
            // textBoxScanTime
            // 
            this.textBoxScanTime.Location = new System.Drawing.Point(284, 39);
            this.textBoxScanTime.Name = "textBoxScanTime";
            this.textBoxScanTime.Size = new System.Drawing.Size(100, 20);
            this.textBoxScanTime.TabIndex = 11;
            // 
            // checkBoxOnScan
            // 
            this.checkBoxOnScan.AutoSize = true;
            this.checkBoxOnScan.Location = new System.Drawing.Point(473, 39);
            this.checkBoxOnScan.Name = "checkBoxOnScan";
            this.checkBoxOnScan.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.checkBoxOnScan.Size = new System.Drawing.Size(68, 17);
            this.checkBoxOnScan.TabIndex = 18;
            this.checkBoxOnScan.Text = "On Scan";
            this.checkBoxOnScan.UseVisualStyleBackColor = true;
            // 
            // checkBoxAutoMode
            // 
            this.checkBoxAutoMode.AutoSize = true;
            this.checkBoxAutoMode.Location = new System.Drawing.Point(463, 65);
            this.checkBoxAutoMode.Name = "checkBoxAutoMode";
            this.checkBoxAutoMode.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.checkBoxAutoMode.Size = new System.Drawing.Size(78, 17);
            this.checkBoxAutoMode.TabIndex = 19;
            this.checkBoxAutoMode.Text = "Auto Mode";
            this.checkBoxAutoMode.UseVisualStyleBackColor = true;
            this.checkBoxAutoMode.CheckedChanged += new System.EventHandler(this.checkBoxAutoMode_CheckedChanged);
            // 
            // textBoxInitialValue
            // 
            this.textBoxInitialValue.Location = new System.Drawing.Point(78, 117);
            this.textBoxInitialValue.Name = "textBoxInitialValue";
            this.textBoxInitialValue.Size = new System.Drawing.Size(100, 20);
            this.textBoxInitialValue.TabIndex = 9;
            // 
            // textBoxLowLimit
            // 
            this.textBoxLowLimit.Location = new System.Drawing.Point(284, 66);
            this.textBoxLowLimit.Name = "textBoxLowLimit";
            this.textBoxLowLimit.Size = new System.Drawing.Size(100, 20);
            this.textBoxLowLimit.TabIndex = 13;
            // 
            // textBoxHighLimit
            // 
            this.textBoxHighLimit.Location = new System.Drawing.Point(284, 91);
            this.textBoxHighLimit.Name = "textBoxHighLimit";
            this.textBoxHighLimit.Size = new System.Drawing.Size(100, 20);
            this.textBoxHighLimit.TabIndex = 15;
            // 
            // textBoxUnits
            // 
            this.textBoxUnits.Location = new System.Drawing.Point(284, 118);
            this.textBoxUnits.Name = "textBoxUnits";
            this.textBoxUnits.Size = new System.Drawing.Size(100, 20);
            this.textBoxUnits.TabIndex = 17;
            // 
            // comboBoxTagType
            // 
            this.comboBoxTagType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTagType.FormattingEnabled = true;
            this.comboBoxTagType.Items.AddRange(new object[] {
            "Analog Input",
            "Analog Output",
            "Digital Input",
            "Digital Output"});
            this.comboBoxTagType.Location = new System.Drawing.Point(78, 12);
            this.comboBoxTagType.Name = "comboBoxTagType";
            this.comboBoxTagType.Size = new System.Drawing.Size(121, 21);
            this.comboBoxTagType.TabIndex = 1;
            this.comboBoxTagType.SelectedIndexChanged += new System.EventHandler(this.comboBoxTagType_SelectedIndexChanged);
            // 
            // labelTagType
            // 
            this.labelTagType.AutoSize = true;
            this.labelTagType.Location = new System.Drawing.Point(19, 15);
            this.labelTagType.Name = "labelTagType";
            this.labelTagType.Size = new System.Drawing.Size(53, 13);
            this.labelTagType.TabIndex = 0;
            this.labelTagType.Text = "Tag Type";
            // 
            // labelId
            // 
            this.labelId.AutoSize = true;
            this.labelId.Location = new System.Drawing.Point(54, 42);
            this.labelId.Name = "labelId";
            this.labelId.Size = new System.Drawing.Size(18, 13);
            this.labelId.TabIndex = 2;
            this.labelId.Text = "ID";
            // 
            // labelDescription
            // 
            this.labelDescription.AutoSize = true;
            this.labelDescription.Location = new System.Drawing.Point(12, 68);
            this.labelDescription.Name = "labelDescription";
            this.labelDescription.Size = new System.Drawing.Size(60, 13);
            this.labelDescription.TabIndex = 4;
            this.labelDescription.Text = "Description";
            // 
            // labelAddress
            // 
            this.labelAddress.AutoSize = true;
            this.labelAddress.Location = new System.Drawing.Point(8, 94);
            this.labelAddress.Name = "labelAddress";
            this.labelAddress.Size = new System.Drawing.Size(64, 13);
            this.labelAddress.TabIndex = 6;
            this.labelAddress.Text = "I/O Address";
            // 
            // labelInitialValue
            // 
            this.labelInitialValue.AutoSize = true;
            this.labelInitialValue.Location = new System.Drawing.Point(11, 120);
            this.labelInitialValue.Name = "labelInitialValue";
            this.labelInitialValue.Size = new System.Drawing.Size(61, 13);
            this.labelInitialValue.TabIndex = 8;
            this.labelInitialValue.Text = "Initial Value";
            // 
            // labelScanTime
            // 
            this.labelScanTime.AutoSize = true;
            this.labelScanTime.Location = new System.Drawing.Point(220, 42);
            this.labelScanTime.Name = "labelScanTime";
            this.labelScanTime.Size = new System.Drawing.Size(58, 13);
            this.labelScanTime.TabIndex = 10;
            this.labelScanTime.Text = "Scan Time";
            // 
            // labelLowLimit
            // 
            this.labelLowLimit.AutoSize = true;
            this.labelLowLimit.Location = new System.Drawing.Point(227, 69);
            this.labelLowLimit.Name = "labelLowLimit";
            this.labelLowLimit.Size = new System.Drawing.Size(51, 13);
            this.labelLowLimit.TabIndex = 12;
            this.labelLowLimit.Text = "Low Limit";
            // 
            // labelHighLimit
            // 
            this.labelHighLimit.AutoSize = true;
            this.labelHighLimit.Location = new System.Drawing.Point(225, 95);
            this.labelHighLimit.Name = "labelHighLimit";
            this.labelHighLimit.Size = new System.Drawing.Size(53, 13);
            this.labelHighLimit.TabIndex = 14;
            this.labelHighLimit.Text = "High Limit";
            // 
            // labelUnits
            // 
            this.labelUnits.AutoSize = true;
            this.labelUnits.Location = new System.Drawing.Point(247, 121);
            this.labelUnits.Name = "labelUnits";
            this.labelUnits.Size = new System.Drawing.Size(31, 13);
            this.labelUnits.TabIndex = 16;
            this.labelUnits.Text = "Units";
            // 
            // buttonDone
            // 
            this.buttonDone.Location = new System.Drawing.Point(502, 169);
            this.buttonDone.Name = "buttonDone";
            this.buttonDone.Size = new System.Drawing.Size(170, 30);
            this.buttonDone.TabIndex = 24;
            this.buttonDone.Text = "Done";
            this.buttonDone.UseVisualStyleBackColor = true;
            this.buttonDone.Click += new System.EventHandler(this.buttonDone_Click);
            // 
            // labelFunction
            // 
            this.labelFunction.AutoSize = true;
            this.labelFunction.Location = new System.Drawing.Point(473, 95);
            this.labelFunction.Name = "labelFunction";
            this.labelFunction.Size = new System.Drawing.Size(48, 13);
            this.labelFunction.TabIndex = 20;
            this.labelFunction.Text = "Function";
            // 
            // labelValue
            // 
            this.labelValue.AutoSize = true;
            this.labelValue.Location = new System.Drawing.Point(487, 122);
            this.labelValue.Name = "labelValue";
            this.labelValue.Size = new System.Drawing.Size(34, 13);
            this.labelValue.TabIndex = 22;
            this.labelValue.Text = "Value";
            // 
            // textBoxValue
            // 
            this.textBoxValue.Location = new System.Drawing.Point(527, 119);
            this.textBoxValue.Name = "textBoxValue";
            this.textBoxValue.Size = new System.Drawing.Size(100, 20);
            this.textBoxValue.TabIndex = 23;
            // 
            // comboBoxFunction
            // 
            this.comboBoxFunction.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxFunction.FormattingEnabled = true;
            this.comboBoxFunction.Items.AddRange(new object[] {
            "Sine",
            "Cosine",
            "Ramp",
            "Triangle",
            "Rectangle"});
            this.comboBoxFunction.Location = new System.Drawing.Point(527, 92);
            this.comboBoxFunction.Name = "comboBoxFunction";
            this.comboBoxFunction.Size = new System.Drawing.Size(121, 21);
            this.comboBoxFunction.TabIndex = 21;
            // 
            // TagForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 211);
            this.Controls.Add(this.comboBoxFunction);
            this.Controls.Add(this.textBoxValue);
            this.Controls.Add(this.labelValue);
            this.Controls.Add(this.labelFunction);
            this.Controls.Add(this.buttonDone);
            this.Controls.Add(this.labelUnits);
            this.Controls.Add(this.labelHighLimit);
            this.Controls.Add(this.labelLowLimit);
            this.Controls.Add(this.labelScanTime);
            this.Controls.Add(this.labelInitialValue);
            this.Controls.Add(this.labelAddress);
            this.Controls.Add(this.labelDescription);
            this.Controls.Add(this.labelId);
            this.Controls.Add(this.labelTagType);
            this.Controls.Add(this.comboBoxTagType);
            this.Controls.Add(this.textBoxUnits);
            this.Controls.Add(this.textBoxHighLimit);
            this.Controls.Add(this.textBoxLowLimit);
            this.Controls.Add(this.textBoxInitialValue);
            this.Controls.Add(this.checkBoxAutoMode);
            this.Controls.Add(this.checkBoxOnScan);
            this.Controls.Add(this.textBoxScanTime);
            this.Controls.Add(this.textBoxAddress);
            this.Controls.Add(this.textBoxDescription);
            this.Controls.Add(this.textBoxId);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "TagForm";
            this.Text = "TagForm";
            this.Closing += TagForm_FormClosing;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxId;
        private System.Windows.Forms.TextBox textBoxDescription;
        private System.Windows.Forms.TextBox textBoxAddress;
        private System.Windows.Forms.TextBox textBoxScanTime;
        private System.Windows.Forms.CheckBox checkBoxOnScan;
        private System.Windows.Forms.CheckBox checkBoxAutoMode;
        private System.Windows.Forms.TextBox textBoxInitialValue;
        private System.Windows.Forms.TextBox textBoxLowLimit;
        private System.Windows.Forms.TextBox textBoxHighLimit;
        private System.Windows.Forms.TextBox textBoxUnits;
        private System.Windows.Forms.ComboBox comboBoxTagType;
        private System.Windows.Forms.Label labelTagType;
        private System.Windows.Forms.Label labelId;
        private System.Windows.Forms.Label labelDescription;
        private System.Windows.Forms.Label labelAddress;
        private System.Windows.Forms.Label labelInitialValue;
        private System.Windows.Forms.Label labelScanTime;
        private System.Windows.Forms.Label labelLowLimit;
        private System.Windows.Forms.Label labelHighLimit;
        private System.Windows.Forms.Label labelUnits;
        private System.Windows.Forms.Button buttonDone;
        private System.Windows.Forms.Label labelFunction;
        private System.Windows.Forms.Label labelValue;
        private System.Windows.Forms.TextBox textBoxValue;
        private System.Windows.Forms.ComboBox comboBoxFunction;
    }
}