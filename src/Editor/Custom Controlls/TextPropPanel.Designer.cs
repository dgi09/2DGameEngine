namespace Editor
{
    partial class TextPropPanel
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tbX = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbY = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbText = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tbCharSize = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tbFont = new System.Windows.Forms.TextBox();
            this.btnFont = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.tbCharOffset = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.btnColor = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(37, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Text";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Name";
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(46, 33);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(94, 20);
            this.tbName.TabIndex = 2;
            this.tbName.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tbName_KeyUp);
            this.tbName.Leave += new System.EventHandler(this.tbName_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Position";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(49, 67);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "X:";
            // 
            // tbX
            // 
            this.tbX.Location = new System.Drawing.Point(63, 64);
            this.tbX.Name = "tbX";
            this.tbX.Size = new System.Drawing.Size(23, 20);
            this.tbX.TabIndex = 5;
            this.tbX.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tbX_KeyUp);
            this.tbX.Leave += new System.EventHandler(this.tbX_Leave);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(92, 67);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(17, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Y:";
            // 
            // tbY
            // 
            this.tbY.Location = new System.Drawing.Point(105, 64);
            this.tbY.Name = "tbY";
            this.tbY.Size = new System.Drawing.Size(24, 20);
            this.tbY.TabIndex = 7;
            this.tbY.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tbY_KeyUp);
            this.tbY.Leave += new System.EventHandler(this.tbY_Leave);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 96);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(28, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "Text";
            // 
            // tbText
            // 
            this.tbText.Location = new System.Drawing.Point(46, 93);
            this.tbText.Name = "tbText";
            this.tbText.Size = new System.Drawing.Size(94, 20);
            this.tbText.TabIndex = 9;
            this.tbText.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tbText_KeyUp);
            this.tbText.Leave += new System.EventHandler(this.tbText_Leave);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 154);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(52, 13);
            this.label7.TabIndex = 10;
            this.label7.Text = "Char Size";
            // 
            // tbCharSize
            // 
            this.tbCharSize.Location = new System.Drawing.Point(59, 151);
            this.tbCharSize.Name = "tbCharSize";
            this.tbCharSize.Size = new System.Drawing.Size(25, 20);
            this.tbCharSize.TabIndex = 11;
            this.tbCharSize.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tbCharSize_KeyUp);
            this.tbCharSize.Leave += new System.EventHandler(this.tbCharSize_Leave);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(3, 125);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(28, 13);
            this.label8.TabIndex = 12;
            this.label8.Text = "Font";
            // 
            // tbFont
            // 
            this.tbFont.Location = new System.Drawing.Point(46, 122);
            this.tbFont.Name = "tbFont";
            this.tbFont.Size = new System.Drawing.Size(63, 20);
            this.tbFont.TabIndex = 13;
            // 
            // btnFont
            // 
            this.btnFont.Location = new System.Drawing.Point(115, 120);
            this.btnFont.Name = "btnFont";
            this.btnFont.Size = new System.Drawing.Size(24, 23);
            this.btnFont.TabIndex = 14;
            this.btnFont.Text = "..";
            this.btnFont.UseVisualStyleBackColor = true;
            this.btnFont.Click += new System.EventHandler(this.btnFont_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(3, 183);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(59, 13);
            this.label9.TabIndex = 15;
            this.label9.Text = "CharOffSet";
            // 
            // tbCharOffset
            // 
            this.tbCharOffset.Location = new System.Drawing.Point(68, 180);
            this.tbCharOffset.Name = "tbCharOffset";
            this.tbCharOffset.Size = new System.Drawing.Size(33, 20);
            this.tbCharOffset.TabIndex = 16;
            this.tbCharOffset.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tbCharOffset_KeyUp);
            this.tbCharOffset.Leave += new System.EventHandler(this.tbCharOffset_Leave);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(3, 212);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(31, 13);
            this.label10.TabIndex = 17;
            this.label10.Text = "Color";
            // 
            // btnColor
            // 
            this.btnColor.BackColor = System.Drawing.Color.Black;
            this.btnColor.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnColor.FlatAppearance.BorderSize = 0;
            this.btnColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnColor.Location = new System.Drawing.Point(41, 207);
            this.btnColor.Name = "btnColor";
            this.btnColor.Size = new System.Drawing.Size(25, 23);
            this.btnColor.TabIndex = 18;
            this.btnColor.UseVisualStyleBackColor = false;
            this.btnColor.Click += new System.EventHandler(this.btnColor_Click);
            // 
            // TextPropPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnColor);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.tbCharOffset);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.btnFont);
            this.Controls.Add(this.tbFont);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.tbCharSize);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.tbText);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tbY);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbX);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "TextPropPanel";
            this.Size = new System.Drawing.Size(143, 340);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbX;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbY;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbText;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbCharSize;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbFont;
        private System.Windows.Forms.Button btnFont;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tbCharOffset;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnColor;
    }
}
