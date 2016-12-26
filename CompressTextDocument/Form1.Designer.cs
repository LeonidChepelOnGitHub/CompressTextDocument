namespace CompressTextDocument
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.CompressionProgress = new System.Windows.Forms.ProgressBar();
            this.OpenAfterCompressionCheckBox = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.OpenBtn = new System.Windows.Forms.Button();
            this.OpenTextBox = new System.Windows.Forms.TextBox();
            this.DestinationTextBox = new System.Windows.Forms.TextBox();
            this.DestinationBtn = new System.Windows.Forms.Button();
            this.CompressBtn = new System.Windows.Forms.Button();
            this.DictSizeTextBox = new System.Windows.Forms.TextBox();
            this.MaxLengthTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // CompressionProgress
            // 
            this.CompressionProgress.Location = new System.Drawing.Point(12, 182);
            this.CompressionProgress.Name = "CompressionProgress";
            this.CompressionProgress.Size = new System.Drawing.Size(494, 23);
            this.CompressionProgress.TabIndex = 0;
            // 
            // OpenAfterCompressionCheckBox
            // 
            this.OpenAfterCompressionCheckBox.AutoSize = true;
            this.OpenAfterCompressionCheckBox.Checked = true;
            this.OpenAfterCompressionCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.OpenAfterCompressionCheckBox.Location = new System.Drawing.Point(285, 65);
            this.OpenAfterCompressionCheckBox.Name = "OpenAfterCompressionCheckBox";
            this.OpenAfterCompressionCheckBox.Size = new System.Drawing.Size(221, 17);
            this.OpenAfterCompressionCheckBox.TabIndex = 1;
            this.OpenAfterCompressionCheckBox.Text = "Open destination folder after compression";
            this.OpenAfterCompressionCheckBox.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 155);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(162, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Compression/Extraction progress";
            // 
            // OpenBtn
            // 
            this.OpenBtn.Location = new System.Drawing.Point(416, 9);
            this.OpenBtn.Name = "OpenBtn";
            this.OpenBtn.Size = new System.Drawing.Size(90, 23);
            this.OpenBtn.TabIndex = 3;
            this.OpenBtn.Text = "Open File";
            this.OpenBtn.UseVisualStyleBackColor = true;
            this.OpenBtn.Click += new System.EventHandler(this.OpenBtn_Click);
            // 
            // OpenTextBox
            // 
            this.OpenTextBox.Location = new System.Drawing.Point(12, 12);
            this.OpenTextBox.Name = "OpenTextBox";
            this.OpenTextBox.Size = new System.Drawing.Size(385, 20);
            this.OpenTextBox.TabIndex = 4;
            // 
            // DestinationTextBox
            // 
            this.DestinationTextBox.Location = new System.Drawing.Point(12, 39);
            this.DestinationTextBox.Name = "DestinationTextBox";
            this.DestinationTextBox.Size = new System.Drawing.Size(385, 20);
            this.DestinationTextBox.TabIndex = 5;
            // 
            // DestinationBtn
            // 
            this.DestinationBtn.Location = new System.Drawing.Point(416, 36);
            this.DestinationBtn.Name = "DestinationBtn";
            this.DestinationBtn.Size = new System.Drawing.Size(90, 23);
            this.DestinationBtn.TabIndex = 6;
            this.DestinationBtn.Text = "Set destination";
            this.DestinationBtn.UseVisualStyleBackColor = true;
            this.DestinationBtn.Click += new System.EventHandler(this.DestinationBtn_Click);
            // 
            // CompressBtn
            // 
            this.CompressBtn.Location = new System.Drawing.Point(336, 88);
            this.CompressBtn.Name = "CompressBtn";
            this.CompressBtn.Size = new System.Drawing.Size(170, 69);
            this.CompressBtn.TabIndex = 7;
            this.CompressBtn.Text = "COMPRESS/EXTRACT";
            this.CompressBtn.UseVisualStyleBackColor = true;
            this.CompressBtn.Click += new System.EventHandler(this.CompressBtn_Click);
            // 
            // DictSizeTextBox
            // 
            this.DictSizeTextBox.Location = new System.Drawing.Point(121, 95);
            this.DictSizeTextBox.Name = "DictSizeTextBox";
            this.DictSizeTextBox.Size = new System.Drawing.Size(100, 20);
            this.DictSizeTextBox.TabIndex = 8;
            this.DictSizeTextBox.Text = "5";
            this.DictSizeTextBox.TextChanged += new System.EventHandler(this.DictSizeTextBox_TextChanged);
            // 
            // MaxLengthTextBox
            // 
            this.MaxLengthTextBox.Location = new System.Drawing.Point(121, 122);
            this.MaxLengthTextBox.Name = "MaxLengthTextBox";
            this.MaxLengthTextBox.Size = new System.Drawing.Size(100, 20);
            this.MaxLengthTextBox.TabIndex = 9;
            this.MaxLengthTextBox.Text = "7";
            this.MaxLengthTextBox.TextChanged += new System.EventHandler(this.MaxLengthTextBox_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Dictionary size:";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 122);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Max word length:";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(12, 65);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(102, 17);
            this.checkBox1.TabIndex = 12;
            this.checkBox1.Text = "From min to max";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Checked = true;
            this.checkBox2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox2.Location = new System.Drawing.Point(121, 65);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(154, 17);
            this.checkBox2.TabIndex = 13;
            this.checkBox2.Text = "Compress symbol repeating";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Checked = true;
            this.checkBox3.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox3.Location = new System.Drawing.Point(241, 95);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(87, 17);
            this.checkBox3.TabIndex = 14;
            this.checkBox3.Text = "Debug mode";
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(518, 217);
            this.Controls.Add(this.checkBox3);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.MaxLengthTextBox);
            this.Controls.Add(this.DictSizeTextBox);
            this.Controls.Add(this.CompressBtn);
            this.Controls.Add(this.DestinationBtn);
            this.Controls.Add(this.DestinationTextBox);
            this.Controls.Add(this.OpenTextBox);
            this.Controls.Add(this.OpenBtn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.OpenAfterCompressionCheckBox);
            this.Controls.Add(this.CompressionProgress);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(534, 256);
            this.MinimumSize = new System.Drawing.Size(534, 256);
            this.Name = "Form1";
            this.Text = "TextArchiver by Leonid";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar CompressionProgress;
        private System.Windows.Forms.CheckBox OpenAfterCompressionCheckBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button OpenBtn;
        private System.Windows.Forms.TextBox OpenTextBox;
        private System.Windows.Forms.TextBox DestinationTextBox;
        private System.Windows.Forms.Button DestinationBtn;
        private System.Windows.Forms.Button CompressBtn;
        private System.Windows.Forms.TextBox DictSizeTextBox;
        private System.Windows.Forms.TextBox MaxLengthTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox3;
    }
}

