namespace Editor
{
    partial class MainForm
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
            this.pbDraw = new DrawPanel();//new System.Windows.Forms.Panel();
            this.mainTab = new System.Windows.Forms.TabControl();
            this.createTab = new System.Windows.Forms.TabPage();
            this.ctPanel = new Editor.CreateTab();
            this.objectsTab = new System.Windows.Forms.TabPage();
            this.propPanel = new System.Windows.Forms.Panel();
            this.btnRun = new System.Windows.Forms.Button();
            this.btnCompile = new System.Windows.Forms.Button();
            this.objectsTree = new System.Windows.Forms.TreeView();
            this.mainTab.SuspendLayout();
            this.createTab.SuspendLayout();
            this.objectsTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // pbDraw
            // 
            this.pbDraw.BackColor = System.Drawing.Color.Transparent;
            this.pbDraw.Location = new System.Drawing.Point(0, 0);
            this.pbDraw.Name = "pbDraw";
            this.pbDraw.Size = new System.Drawing.Size(600, 600);
            this.pbDraw.TabIndex = 0;
            // 
            // mainTab
            // 
            this.mainTab.Controls.Add(this.createTab);
            this.mainTab.Controls.Add(this.objectsTab);
            this.mainTab.Location = new System.Drawing.Point(599, 0);
            this.mainTab.Name = "mainTab";
            this.mainTab.SelectedIndex = 0;
            this.mainTab.Size = new System.Drawing.Size(156, 191);
            this.mainTab.TabIndex = 1;
            // 
            // createTab
            // 
            this.createTab.Controls.Add(this.ctPanel);
            this.createTab.Location = new System.Drawing.Point(4, 22);
            this.createTab.Name = "createTab";
            this.createTab.Padding = new System.Windows.Forms.Padding(3);
            this.createTab.Size = new System.Drawing.Size(148, 165);
            this.createTab.TabIndex = 0;
            this.createTab.Text = "Create";
            this.createTab.UseVisualStyleBackColor = true;
            // 
            // ctPanel
            // 
            this.ctPanel.Location = new System.Drawing.Point(0, 0);
            this.ctPanel.Name = "ctPanel";
            this.ctPanel.Size = new System.Drawing.Size(148, 165);
            this.ctPanel.TabIndex = 0;
            // 
            // objectsTab
            // 
            this.objectsTab.Controls.Add(this.objectsTree);
            this.objectsTab.Location = new System.Drawing.Point(4, 22);
            this.objectsTab.Name = "objectsTab";
            this.objectsTab.Padding = new System.Windows.Forms.Padding(3);
            this.objectsTab.Size = new System.Drawing.Size(148, 165);
            this.objectsTab.TabIndex = 1;
            this.objectsTab.Text = "Objects";
            this.objectsTab.UseVisualStyleBackColor = true;
            // 
            // propPanel
            // 
            this.propPanel.AutoScroll = true;
            this.propPanel.Location = new System.Drawing.Point(600, 192);
            this.propPanel.Name = "propPanel";
            this.propPanel.Size = new System.Drawing.Size(155, 340);
            this.propPanel.TabIndex = 2;
            // 
            // btnRun
            // 
            this.btnRun.Location = new System.Drawing.Point(606, 538);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(56, 23);
            this.btnRun.TabIndex = 3;
            this.btnRun.Text = "Run";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += btnRun_Click;
            // 
            // btnCompile
            // 
            this.btnCompile.Location = new System.Drawing.Point(686, 538);
            this.btnCompile.Name = "btnCompile";
            this.btnCompile.Size = new System.Drawing.Size(57, 23);
            this.btnCompile.TabIndex = 4;
            this.btnCompile.Text = "Compile";
            this.btnCompile.UseVisualStyleBackColor = true;
            this.btnCompile.Click += btnCompile_Click;
            // 
            // objectsTree
            // 
            this.objectsTree.Location = new System.Drawing.Point(3, 0);
            this.objectsTree.Name = "objectsTree";
            this.objectsTree.Size = new System.Drawing.Size(145, 165);
            this.objectsTree.TabIndex = 0;

            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.ClientSize = new System.Drawing.Size(755, 562);
            this.Controls.Add(this.btnCompile);
            this.Controls.Add(this.btnRun);
            this.Controls.Add(this.propPanel);
            this.Controls.Add(this.mainTab);
            this.Controls.Add(this.pbDraw);
            this.DoubleBuffered = true;
            this.Name = "Form1";
            this.Text = "EngineEditor";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.mainTab.ResumeLayout(false);
            this.createTab.ResumeLayout(false);
            this.objectsTab.ResumeLayout(false);
            this.ResumeLayout(false);

        }


        #endregion

        CreateTab ctPanel;
        private System.Windows.Forms.TabControl mainTab;
        private System.Windows.Forms.TabPage createTab;
        private System.Windows.Forms.TabPage objectsTab;
        private System.Windows.Forms.Panel propPanel;
        private DrawPanel pbDraw;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.Button btnCompile;
        private System.Windows.Forms.TreeView objectsTree;
        

    }
}

