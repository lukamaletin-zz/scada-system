namespace DatabaseManager
{
    partial class DbForm
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
            System.Windows.Forms.ColumnHeader columnHeader4;
            this.listViewTags = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label1 = new System.Windows.Forms.Label();
            this.buttonAddTag = new System.Windows.Forms.Button();
            this.buttonRemoveTag = new System.Windows.Forms.Button();
            this.buttonUpdateTag = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.listViewAlarms = new System.Windows.Forms.ListView();
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.buttonAddAlarm = new System.Windows.Forms.Button();
            this.buttonRemoveAlarm = new System.Windows.Forms.Button();
            columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // columnHeader4
            // 
            columnHeader4.Text = "ID";
            columnHeader4.Width = 156;
            // 
            // listViewTags
            // 
            this.listViewTags.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.listViewTags.FullRowSelect = true;
            this.listViewTags.Location = new System.Drawing.Point(12, 25);
            this.listViewTags.MultiSelect = false;
            this.listViewTags.Name = "listViewTags";
            this.listViewTags.Size = new System.Drawing.Size(480, 464);
            this.listViewTags.TabIndex = 0;
            this.listViewTags.UseCompatibleStateImageBehavior = false;
            this.listViewTags.View = System.Windows.Forms.View.Details;
            this.listViewTags.SelectedIndexChanged += new System.EventHandler(this.listViewTags_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "ID";
            this.columnHeader1.Width = 156;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Description";
            this.columnHeader2.Width = 160;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "I/O Address";
            this.columnHeader3.Width = 160;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Tags";
            // 
            // buttonAddTag
            // 
            this.buttonAddTag.Location = new System.Drawing.Point(12, 495);
            this.buttonAddTag.Name = "buttonAddTag";
            this.buttonAddTag.Size = new System.Drawing.Size(156, 30);
            this.buttonAddTag.TabIndex = 2;
            this.buttonAddTag.Text = "Add";
            this.buttonAddTag.UseVisualStyleBackColor = true;
            this.buttonAddTag.Click += new System.EventHandler(this.buttonAddTag_Click);
            // 
            // buttonRemoveTag
            // 
            this.buttonRemoveTag.Location = new System.Drawing.Point(174, 495);
            this.buttonRemoveTag.Name = "buttonRemoveTag";
            this.buttonRemoveTag.Size = new System.Drawing.Size(156, 30);
            this.buttonRemoveTag.TabIndex = 3;
            this.buttonRemoveTag.Text = "Remove";
            this.buttonRemoveTag.UseVisualStyleBackColor = true;
            this.buttonRemoveTag.Click += new System.EventHandler(this.buttonRemoveTag_Click);
            // 
            // buttonUpdateTag
            // 
            this.buttonUpdateTag.Location = new System.Drawing.Point(336, 495);
            this.buttonUpdateTag.Name = "buttonUpdateTag";
            this.buttonUpdateTag.Size = new System.Drawing.Size(156, 30);
            this.buttonUpdateTag.TabIndex = 4;
            this.buttonUpdateTag.Text = "Update";
            this.buttonUpdateTag.UseVisualStyleBackColor = true;
            this.buttonUpdateTag.Click += new System.EventHandler(this.buttonUpdateTag_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(513, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Alarms";
            // 
            // listViewAlarms
            // 
            this.listViewAlarms.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            columnHeader4,
            this.columnHeader5,
            this.columnHeader6});
            this.listViewAlarms.FullRowSelect = true;
            this.listViewAlarms.Location = new System.Drawing.Point(516, 25);
            this.listViewAlarms.Name = "listViewAlarms";
            this.listViewAlarms.Size = new System.Drawing.Size(480, 464);
            this.listViewAlarms.TabIndex = 7;
            this.listViewAlarms.UseCompatibleStateImageBehavior = false;
            this.listViewAlarms.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Low Limit";
            this.columnHeader5.Width = 160;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "High Limit";
            this.columnHeader6.Width = 160;
            // 
            // buttonAddAlarm
            // 
            this.buttonAddAlarm.Location = new System.Drawing.Point(516, 495);
            this.buttonAddAlarm.Name = "buttonAddAlarm";
            this.buttonAddAlarm.Size = new System.Drawing.Size(237, 30);
            this.buttonAddAlarm.TabIndex = 8;
            this.buttonAddAlarm.Text = "Add";
            this.buttonAddAlarm.UseVisualStyleBackColor = true;
            this.buttonAddAlarm.Click += new System.EventHandler(this.buttonAddAlarm_Click);
            // 
            // buttonRemoveAlarm
            // 
            this.buttonRemoveAlarm.Location = new System.Drawing.Point(759, 495);
            this.buttonRemoveAlarm.Name = "buttonRemoveAlarm";
            this.buttonRemoveAlarm.Size = new System.Drawing.Size(237, 30);
            this.buttonRemoveAlarm.TabIndex = 9;
            this.buttonRemoveAlarm.Text = "Remove";
            this.buttonRemoveAlarm.UseVisualStyleBackColor = true;
            this.buttonRemoveAlarm.Click += new System.EventHandler(this.buttonRemoveAlarm_Click);
            // 
            // DbForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 537);
            this.Controls.Add(this.buttonRemoveAlarm);
            this.Controls.Add(this.buttonAddAlarm);
            this.Controls.Add(this.listViewAlarms);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.buttonUpdateTag);
            this.Controls.Add(this.buttonRemoveTag);
            this.Controls.Add(this.buttonAddTag);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listViewTags);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "DbForm";
            this.Text = "DbForm";
            this.Closing += DbForm_FormClosing;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listViewTags;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonAddTag;
        private System.Windows.Forms.Button buttonRemoveTag;
        private System.Windows.Forms.Button buttonUpdateTag;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListView listViewAlarms;
        private System.Windows.Forms.Button buttonAddAlarm;
        private System.Windows.Forms.Button buttonRemoveAlarm;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
    }
}

