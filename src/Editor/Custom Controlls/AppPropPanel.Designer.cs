namespace Editor
{
    partial class AppPropPanel
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
            this.lblApp = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblAppName = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbStartScreen = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbTexturesHeapSize = new System.Windows.Forms.TextBox();
            this.lblTxtHeapSize = new System.Windows.Forms.Label();
            this.tbTextsHeapSize = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbSpriteHeapSize = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbFPS = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblApp
            // 
            this.lblApp.AutoSize = true;
            this.lblApp.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblApp.Location = new System.Drawing.Point(26, 0);
            this.lblApp.Name = "lblApp";
            this.lblApp.Size = new System.Drawing.Size(90, 18);
            this.lblApp.TabIndex = 0;
            this.lblApp.Text = "Application";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "AppName";
            // 
            // lblAppName
            // 
            this.lblAppName.AutoSize = true;
            this.lblAppName.Location = new System.Drawing.Point(64, 36);
            this.lblAppName.Name = "lblAppName";
            this.lblAppName.Size = new System.Drawing.Size(0, 13);
            this.lblAppName.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "StartUpScreen";
            // 
            // tbStartScreen
            // 
            this.tbStartScreen.Location = new System.Drawing.Point(86, 56);
            this.tbStartScreen.Name = "tbStartScreen";
            this.tbStartScreen.Size = new System.Drawing.Size(54, 20);
            this.tbStartScreen.TabIndex = 4;
            this.tbStartScreen.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tbStartScreen_KeyUp);
            this.tbStartScreen.Leave += new System.EventHandler(this.tbStartScreen_Leave);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 86);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "TextureHeapSize";
            // 
            // tbTexturesHeapSize
            // 
            this.tbTexturesHeapSize.Location = new System.Drawing.Point(99, 82);
            this.tbTexturesHeapSize.Name = "tbTexturesHeapSize";
            this.tbTexturesHeapSize.Size = new System.Drawing.Size(23, 20);
            this.tbTexturesHeapSize.TabIndex = 6;
            this.tbTexturesHeapSize.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tbTexturesHeapSize_KeyUp);
            this.tbTexturesHeapSize.Leave += new System.EventHandler(this.tbTexturesHeapSize_Leave);
            // 
            // lblTxtHeapSize
            // 
            this.lblTxtHeapSize.AutoSize = true;
            this.lblTxtHeapSize.Location = new System.Drawing.Point(5, 113);
            this.lblTxtHeapSize.Name = "lblTxtHeapSize";
            this.lblTxtHeapSize.Size = new System.Drawing.Size(79, 13);
            this.lblTxtHeapSize.TabIndex = 7;
            this.lblTxtHeapSize.Text = "TextsHeapSize";
            // 
            // tbTextsHeapSize
            // 
            this.tbTextsHeapSize.Location = new System.Drawing.Point(99, 110);
            this.tbTextsHeapSize.Name = "tbTextsHeapSize";
            this.tbTextsHeapSize.Size = new System.Drawing.Size(23, 20);
            this.tbTextsHeapSize.TabIndex = 8;
            this.tbTextsHeapSize.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tbTextsHeapSize_KeyUp);
            this.tbTextsHeapSize.Leave += new System.EventHandler(this.tbTextsHeapSize_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 140);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "SpriteHeapSize";
            // 
            // tbSpriteHeapSize
            // 
            this.tbSpriteHeapSize.Location = new System.Drawing.Point(99, 137);
            this.tbSpriteHeapSize.Name = "tbSpriteHeapSize";
            this.tbSpriteHeapSize.Size = new System.Drawing.Size(23, 20);
            this.tbSpriteHeapSize.TabIndex = 10;
            this.tbSpriteHeapSize.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tbSpriteHeapSize_KeyUp);
            this.tbSpriteHeapSize.Leave += new System.EventHandler(this.tbSpriteHeapSize_Leave);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 166);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(27, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "FPS";
            // 
            // tbFPS
            // 
            this.tbFPS.Location = new System.Drawing.Point(99, 166);
            this.tbFPS.Name = "tbFPS";
            this.tbFPS.Size = new System.Drawing.Size(23, 20);
            this.tbFPS.TabIndex = 12;
            this.tbFPS.TextChanged += new System.EventHandler(this.tbFPS_TextChanged);
            // 
            // AppPropPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tbFPS);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbSpriteHeapSize);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbTextsHeapSize);
            this.Controls.Add(this.lblTxtHeapSize);
            this.Controls.Add(this.tbTexturesHeapSize);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbStartScreen);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblAppName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblApp);
            this.Name = "AppPropPanel";
            this.Size = new System.Drawing.Size(143, 194);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblApp;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblAppName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbStartScreen;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbTexturesHeapSize;
        private System.Windows.Forms.Label lblTxtHeapSize;
        private System.Windows.Forms.TextBox tbTextsHeapSize;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbSpriteHeapSize;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbFPS;
    }
}
