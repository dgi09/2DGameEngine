namespace Editor
{
    partial class SpritePropPanel
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
            this.tbRotation = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tbnChooseTexture = new System.Windows.Forms.Button();
            this.tbTexture = new System.Windows.Forms.TextBox();
            this.chbToggleAnimation = new System.Windows.Forms.CheckBox();
            this.pnlAnimation = new System.Windows.Forms.Panel();
            this.pnlPlayAnim = new System.Windows.Forms.Panel();
            this.rbLoop = new System.Windows.Forms.RadioButton();
            this.rbOnce = new System.Windows.Forms.RadioButton();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnPlay = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.lbAnimations = new System.Windows.Forms.ListBox();
            this.tbFrameHeight = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tbFrameWidth = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.pnlAnimation.SuspendLayout();
            this.pnlPlayAnim.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(37, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Sprite";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 36);
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
            this.tbName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbName_KeyDown);
            this.tbName.Leave += new System.EventHandler(this.tbName_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 67);
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
            this.tbX.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbX_KeyDown);
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
            this.tbY.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbY_KeyDown);
            this.tbY.Leave += new System.EventHandler(this.tbY_Leave);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(4, 96);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "Rotation";
            // 
            // tbRotation
            // 
            this.tbRotation.Location = new System.Drawing.Point(60, 93);
            this.tbRotation.Name = "tbRotation";
            this.tbRotation.Size = new System.Drawing.Size(41, 20);
            this.tbRotation.TabIndex = 9;
            this.tbRotation.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbRotation_KeyDown);
            this.tbRotation.Leave += new System.EventHandler(this.tbRotation_Leave);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(4, 131);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(43, 13);
            this.label7.TabIndex = 10;
            this.label7.Text = "Texture";
            // 
            // tbnChooseTexture
            // 
            this.tbnChooseTexture.Location = new System.Drawing.Point(118, 126);
            this.tbnChooseTexture.Name = "tbnChooseTexture";
            this.tbnChooseTexture.Size = new System.Drawing.Size(22, 23);
            this.tbnChooseTexture.TabIndex = 11;
            this.tbnChooseTexture.Text = "...";
            this.tbnChooseTexture.UseVisualStyleBackColor = true;
            this.tbnChooseTexture.Click += new System.EventHandler(this.tbnChooseTexture_Click);
            // 
            // tbTexture
            // 
            this.tbTexture.Location = new System.Drawing.Point(46, 128);
            this.tbTexture.Name = "tbTexture";
            this.tbTexture.Size = new System.Drawing.Size(66, 20);
            this.tbTexture.TabIndex = 12;
            // 
            // chbToggleAnimation
            // 
            this.chbToggleAnimation.AutoSize = true;
            this.chbToggleAnimation.Location = new System.Drawing.Point(7, 164);
            this.chbToggleAnimation.Name = "chbToggleAnimation";
            this.chbToggleAnimation.Size = new System.Drawing.Size(72, 17);
            this.chbToggleAnimation.TabIndex = 13;
            this.chbToggleAnimation.Text = "Animation";
            this.chbToggleAnimation.UseVisualStyleBackColor = true;
            this.chbToggleAnimation.CheckedChanged += new System.EventHandler(this.chbToggleAnimation_CheckedChanged);
            // 
            // pnlAnimation
            // 
            this.pnlAnimation.AutoScroll = true;
            this.pnlAnimation.Controls.Add(this.pnlPlayAnim);
            this.pnlAnimation.Controls.Add(this.btnEdit);
            this.pnlAnimation.Controls.Add(this.btnRemove);
            this.pnlAnimation.Controls.Add(this.btnAdd);
            this.pnlAnimation.Controls.Add(this.lbAnimations);
            this.pnlAnimation.Controls.Add(this.tbFrameHeight);
            this.pnlAnimation.Controls.Add(this.label9);
            this.pnlAnimation.Controls.Add(this.tbFrameWidth);
            this.pnlAnimation.Controls.Add(this.label8);
            this.pnlAnimation.Location = new System.Drawing.Point(0, 187);
            this.pnlAnimation.Name = "pnlAnimation";
            this.pnlAnimation.Size = new System.Drawing.Size(143, 153);
            this.pnlAnimation.TabIndex = 14;
            this.pnlAnimation.Visible = false;
            // 
            // pnlPlayAnim
            // 
            this.pnlPlayAnim.Controls.Add(this.rbLoop);
            this.pnlPlayAnim.Controls.Add(this.rbOnce);
            this.pnlPlayAnim.Controls.Add(this.btnStop);
            this.pnlPlayAnim.Controls.Add(this.btnPlay);
            this.pnlPlayAnim.Enabled = false;
            this.pnlPlayAnim.Location = new System.Drawing.Point(7, 169);
            this.pnlPlayAnim.Name = "pnlPlayAnim";
            this.pnlPlayAnim.Size = new System.Drawing.Size(116, 61);
            this.pnlPlayAnim.TabIndex = 8;
            // 
            // rbLoop
            // 
            this.rbLoop.AutoSize = true;
            this.rbLoop.Location = new System.Drawing.Point(50, 34);
            this.rbLoop.Name = "rbLoop";
            this.rbLoop.Size = new System.Drawing.Size(49, 17);
            this.rbLoop.TabIndex = 3;
            this.rbLoop.TabStop = true;
            this.rbLoop.Text = "Loop";
            this.rbLoop.UseVisualStyleBackColor = true;
            // 
            // rbOnce
            // 
            this.rbOnce.AutoSize = true;
            this.rbOnce.Location = new System.Drawing.Point(50, 10);
            this.rbOnce.Name = "rbOnce";
            this.rbOnce.Size = new System.Drawing.Size(51, 17);
            this.rbOnce.TabIndex = 2;
            this.rbOnce.TabStop = true;
            this.rbOnce.Text = "Once";
            this.rbOnce.UseVisualStyleBackColor = true;
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(4, 34);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(40, 23);
            this.btnStop.TabIndex = 1;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnPlay
            // 
            this.btnPlay.Location = new System.Drawing.Point(4, 4);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(40, 23);
            this.btnPlay.TabIndex = 0;
            this.btnPlay.Text = "Play";
            this.btnPlay.UseVisualStyleBackColor = true;
            this.btnPlay.Click += new System.EventHandler(this.btnPlay_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Enabled = false;
            this.btnEdit.Location = new System.Drawing.Point(44, 140);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(27, 23);
            this.btnEdit.TabIndex = 7;
            this.btnEdit.Text = "E";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Enabled = false;
            this.btnRemove.Location = new System.Drawing.Point(77, 140);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(28, 23);
            this.btnRemove.TabIndex = 6;
            this.btnRemove.Text = "R";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(7, 140);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(32, 23);
            this.btnAdd.TabIndex = 5;
            this.btnAdd.Text = "A";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // lbAnimations
            // 
            this.lbAnimations.FormattingEnabled = true;
            this.lbAnimations.Location = new System.Drawing.Point(7, 54);
            this.lbAnimations.Name = "lbAnimations";
            this.lbAnimations.Size = new System.Drawing.Size(105, 82);
            this.lbAnimations.TabIndex = 4;
            this.lbAnimations.SelectedIndexChanged += new System.EventHandler(this.lbAnimations_SelectedIndexChanged);
            // 
            // tbFrameHeight
            // 
            this.tbFrameHeight.Location = new System.Drawing.Point(77, 28);
            this.tbFrameHeight.Name = "tbFrameHeight";
            this.tbFrameHeight.Size = new System.Drawing.Size(35, 20);
            this.tbFrameHeight.TabIndex = 3;
            this.tbFrameHeight.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tbFrameHeight_KeyUp);
            this.tbFrameHeight.Leave += new System.EventHandler(this.tbFrameHeight_Leave);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(4, 29);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(70, 13);
            this.label9.TabIndex = 2;
            this.label9.Text = "Frame Height";
            // 
            // tbFrameWidth
            // 
            this.tbFrameWidth.Location = new System.Drawing.Point(77, 1);
            this.tbFrameWidth.Name = "tbFrameWidth";
            this.tbFrameWidth.Size = new System.Drawing.Size(35, 20);
            this.tbFrameWidth.TabIndex = 1;
            this.tbFrameWidth.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tbFrameWidth_KeyUp);
            this.tbFrameWidth.Leave += new System.EventHandler(this.tbFrameWidth_Leave);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(4, 4);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(67, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "Frame Width";
            // 
            // SpritePropPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlAnimation);
            this.Controls.Add(this.chbToggleAnimation);
            this.Controls.Add(this.tbTexture);
            this.Controls.Add(this.tbnChooseTexture);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.tbRotation);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tbY);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbX);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "SpritePropPanel";
            this.Size = new System.Drawing.Size(143, 340);
            this.pnlAnimation.ResumeLayout(false);
            this.pnlAnimation.PerformLayout();
            this.pnlPlayAnim.ResumeLayout(false);
            this.pnlPlayAnim.PerformLayout();
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
        private System.Windows.Forms.TextBox tbRotation;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button tbnChooseTexture;
        private System.Windows.Forms.TextBox tbTexture;
        private System.Windows.Forms.CheckBox chbToggleAnimation;
        private System.Windows.Forms.Panel pnlAnimation;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ListBox lbAnimations;
        private System.Windows.Forms.TextBox tbFrameHeight;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tbFrameWidth;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Panel pnlPlayAnim;
        private System.Windows.Forms.RadioButton rbLoop;
        private System.Windows.Forms.RadioButton rbOnce;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnPlay;
    }
}
