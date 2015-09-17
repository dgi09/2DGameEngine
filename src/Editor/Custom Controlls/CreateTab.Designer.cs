namespace Editor
{
    partial class CreateTab
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
            this.btnScreen = new System.Windows.Forms.Button();
            this.btnSprite = new System.Windows.Forms.Button();
            this.btnText = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnScreen
            // 
            this.btnScreen.Location = new System.Drawing.Point(30, 3);
            this.btnScreen.Name = "btnScreen";
            this.btnScreen.Size = new System.Drawing.Size(84, 23);
            this.btnScreen.TabIndex = 0;
            this.btnScreen.Text = "GameScreen";
            this.btnScreen.UseVisualStyleBackColor = true;
            this.btnScreen.Click += new System.EventHandler(this.btnScreen_Click);
            // 
            // btnSprite
            // 
            this.btnSprite.Location = new System.Drawing.Point(30, 32);
            this.btnSprite.Name = "btnSprite";
            this.btnSprite.Size = new System.Drawing.Size(84, 23);
            this.btnSprite.TabIndex = 1;
            this.btnSprite.Text = "Sprite";
            this.btnSprite.UseVisualStyleBackColor = true;
            this.btnSprite.Click += new System.EventHandler(this.btnSprite_Click);
            // 
            // btnText
            // 
            this.btnText.Location = new System.Drawing.Point(30, 61);
            this.btnText.Name = "btnText";
            this.btnText.Size = new System.Drawing.Size(84, 23);
            this.btnText.TabIndex = 2;
            this.btnText.Text = "Text";
            this.btnText.UseVisualStyleBackColor = true;
            this.btnText.Click += new System.EventHandler(this.btnText_Click);
            // 
            // CreateTab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnText);
            this.Controls.Add(this.btnSprite);
            this.Controls.Add(this.btnScreen);
            this.Name = "CreateTab";
            this.Size = new System.Drawing.Size(148, 165);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnScreen;
        private System.Windows.Forms.Button btnSprite;
        private System.Windows.Forms.Button btnText;
    }
}
