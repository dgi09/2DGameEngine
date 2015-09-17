namespace Editor
{
    partial class ColorPickerDialog
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
            this.pbColor = new System.Windows.Forms.PictureBox();
            this.er = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.sldrRed = new System.Windows.Forms.HScrollBar();
            this.sldrGreen = new System.Windows.Forms.HScrollBar();
            this.sldrBlue = new System.Windows.Forms.HScrollBar();
            ((System.ComponentModel.ISupportInitialize)(this.pbColor)).BeginInit();
            this.SuspendLayout();
            // 
            // pbColor
            // 
            this.pbColor.BackColor = System.Drawing.Color.Black;
            this.pbColor.Location = new System.Drawing.Point(34, 22);
            this.pbColor.Name = "pbColor";
            this.pbColor.Size = new System.Drawing.Size(247, 23);
            this.pbColor.TabIndex = 0;
            this.pbColor.TabStop = false;
            // 
            // er
            // 
            this.er.AutoSize = true;
            this.er.Location = new System.Drawing.Point(34, 72);
            this.er.Name = "er";
            this.er.Size = new System.Drawing.Size(27, 13);
            this.er.TabIndex = 1;
            this.er.Text = "Red";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(34, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Green";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(34, 124);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(28, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Blue";
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(66, 155);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 4;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(176, 155);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // sldrRed
            // 
            this.sldrRed.Location = new System.Drawing.Point(89, 68);
            this.sldrRed.Maximum = 255;
            this.sldrRed.Name = "sldrRed";
            this.sldrRed.Size = new System.Drawing.Size(143, 17);
            this.sldrRed.TabIndex = 6;
            this.sldrRed.ValueChanged += new System.EventHandler(this.sldr_ValueChanged);
            // 
            // sldrGreen
            // 
            this.sldrGreen.Location = new System.Drawing.Point(89, 95);
            this.sldrGreen.Maximum = 255;
            this.sldrGreen.Name = "sldrGreen";
            this.sldrGreen.Size = new System.Drawing.Size(143, 17);
            this.sldrGreen.TabIndex = 7;
            this.sldrGreen.ValueChanged += new System.EventHandler(this.sldr_ValueChanged);
            // 
            // sldrBlue
            // 
            this.sldrBlue.Location = new System.Drawing.Point(89, 120);
            this.sldrBlue.Maximum = 255;
            this.sldrBlue.Name = "sldrBlue";
            this.sldrBlue.Size = new System.Drawing.Size(143, 17);
            this.sldrBlue.TabIndex = 8;
            this.sldrBlue.ValueChanged += new System.EventHandler(this.sldr_ValueChanged);
            // 
            // ColorPickerDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(316, 180);
            this.ControlBox = false;
            this.Controls.Add(this.sldrBlue);
            this.Controls.Add(this.sldrGreen);
            this.Controls.Add(this.sldrRed);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.er);
            this.Controls.Add(this.pbColor);
            this.Name = "ColorPickerDialog";
            this.Text = "Choose Color";
            this.Load += new System.EventHandler(this.ColorPickerDialog_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbColor)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbColor;
        private System.Windows.Forms.Label er;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.HScrollBar sldrRed;
        private System.Windows.Forms.HScrollBar sldrGreen;
        private System.Windows.Forms.HScrollBar sldrBlue;
    }
}