namespace Editor
{
    partial class ScreenPropPanel
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
            this.lblScriptName = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnColor = new System.Windows.Forms.Button();
            this.tbName = new System.Windows.Forms.MaskedTextBox();
            this.tbScript = new System.Windows.Forms.MaskedTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lbSprites = new System.Windows.Forms.ListBox();
            this.btnRemoveLSprite = new System.Windows.Forms.Button();
            this.btnPlaceOnScreen = new System.Windows.Forms.Button();
            this.btnEditScript = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name";
            // 
            // lblScriptName
            // 
            this.lblScriptName.AutoSize = true;
            this.lblScriptName.Location = new System.Drawing.Point(3, 45);
            this.lblScriptName.Name = "lblScriptName";
            this.lblScriptName.Size = new System.Drawing.Size(34, 13);
            this.lblScriptName.TabIndex = 2;
            this.lblScriptName.Text = "Script";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Backgound Color";
            // 
            // btnColor
            // 
            this.btnColor.BackColor = System.Drawing.Color.Black;
            this.btnColor.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnColor.FlatAppearance.BorderSize = 0;
            this.btnColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnColor.Location = new System.Drawing.Point(98, 74);
            this.btnColor.Name = "btnColor";
            this.btnColor.Size = new System.Drawing.Size(25, 23);
            this.btnColor.TabIndex = 5;
            this.btnColor.UseVisualStyleBackColor = false;
            this.btnColor.Click += new System.EventHandler(this.btnColor_Click);
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(44, 14);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(96, 20);
            this.tbName.TabIndex = 6;
            this.tbName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbName_KeyDown);
            this.tbName.Leave += new System.EventHandler(this.tbName_Leave);
            // 
            // tbScript
            // 
            this.tbScript.Location = new System.Drawing.Point(44, 45);
            this.tbScript.Name = "tbScript";
            this.tbScript.Size = new System.Drawing.Size(96, 20);
            this.tbScript.TabIndex = 7;
            this.tbScript.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbScript_KeyDown);
            this.tbScript.Leave += new System.EventHandler(this.tbScript_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(13, 113);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 20);
            this.label3.TabIndex = 8;
            this.label3.Text = "Library Sprites";
            // 
            // lbSprites
            // 
            this.lbSprites.FormattingEnabled = true;
            this.lbSprites.Location = new System.Drawing.Point(6, 136);
            this.lbSprites.Name = "lbSprites";
            this.lbSprites.Size = new System.Drawing.Size(134, 95);
            this.lbSprites.TabIndex = 9;
            this.lbSprites.SelectedIndexChanged += new System.EventHandler(this.lbSprites_SelectedIndexChanged);
            // 
            // btnRemoveLSprite
            // 
            this.btnRemoveLSprite.Enabled = false;
            this.btnRemoveLSprite.Location = new System.Drawing.Point(6, 237);
            this.btnRemoveLSprite.Name = "btnRemoveLSprite";
            this.btnRemoveLSprite.Size = new System.Drawing.Size(60, 23);
            this.btnRemoveLSprite.TabIndex = 10;
            this.btnRemoveLSprite.Text = "Remove";
            this.btnRemoveLSprite.UseVisualStyleBackColor = true;
            this.btnRemoveLSprite.Click += new System.EventHandler(this.btnRemoveLSprite_Click);
            // 
            // btnPlaceOnScreen
            // 
            this.btnPlaceOnScreen.Enabled = false;
            this.btnPlaceOnScreen.Location = new System.Drawing.Point(89, 237);
            this.btnPlaceOnScreen.Name = "btnPlaceOnScreen";
            this.btnPlaceOnScreen.Size = new System.Drawing.Size(51, 23);
            this.btnPlaceOnScreen.TabIndex = 11;
            this.btnPlaceOnScreen.Text = "Place";
            this.btnPlaceOnScreen.UseVisualStyleBackColor = true;
            this.btnPlaceOnScreen.Click += new System.EventHandler(this.btnPlaceOnScreen_Click);
            // 
            // btnEditScript
            // 
            this.btnEditScript.Location = new System.Drawing.Point(6, 290);
            this.btnEditScript.Name = "btnEditScript";
            this.btnEditScript.Size = new System.Drawing.Size(75, 23);
            this.btnEditScript.TabIndex = 12;
            this.btnEditScript.Text = "Edit Script";
            this.btnEditScript.UseVisualStyleBackColor = true;
            this.btnEditScript.Click += new System.EventHandler(this.btnEditScript_Click);
            // 
            // ScreenPropPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Controls.Add(this.btnEditScript);
            this.Controls.Add(this.btnPlaceOnScreen);
            this.Controls.Add(this.btnRemoveLSprite);
            this.Controls.Add(this.lbSprites);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbScript);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.btnColor);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblScriptName);
            this.Controls.Add(this.label1);
            this.ForeColor = System.Drawing.Color.Black;
            this.Name = "ScreenPropPanel";
            this.Size = new System.Drawing.Size(143, 340);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblScriptName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnColor;
        private System.Windows.Forms.MaskedTextBox tbName;
        private System.Windows.Forms.MaskedTextBox tbScript;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox lbSprites;
        private System.Windows.Forms.Button btnRemoveLSprite;
        private System.Windows.Forms.Button btnPlaceOnScreen;
        private System.Windows.Forms.Button btnEditScript;
    }
}
