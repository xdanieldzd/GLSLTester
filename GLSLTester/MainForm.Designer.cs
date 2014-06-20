namespace GLSLTester
{
    partial class MainForm
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newWorkspaceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.openWorkspaceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveWorkspaceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setBackgroundToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this.vSyncToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openGLInformationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cdlgBackground = new System.Windows.Forms.ColorDialog();
            this.glControl1 = new Aglex.GLControl();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tsslStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.cmsNodeMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addNodeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeNodeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.editNodeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.treeViewEx1 = new GLSLTester.Controls.TreeViewEx();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.cmsNodeMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.optionsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(884, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newWorkspaceToolStripMenuItem,
            this.toolStripMenuItem2,
            this.openWorkspaceToolStripMenuItem,
            this.saveWorkspaceToolStripMenuItem,
            this.toolStripMenuItem3,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // newWorkspaceToolStripMenuItem
            // 
            this.newWorkspaceToolStripMenuItem.Name = "newWorkspaceToolStripMenuItem";
            this.newWorkspaceToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.newWorkspaceToolStripMenuItem.Size = new System.Drawing.Size(210, 22);
            this.newWorkspaceToolStripMenuItem.Text = "&New Workspace";
            this.newWorkspaceToolStripMenuItem.Click += new System.EventHandler(this.newWorkspaceToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(207, 6);
            // 
            // openWorkspaceToolStripMenuItem
            // 
            this.openWorkspaceToolStripMenuItem.Name = "openWorkspaceToolStripMenuItem";
            this.openWorkspaceToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openWorkspaceToolStripMenuItem.Size = new System.Drawing.Size(210, 22);
            this.openWorkspaceToolStripMenuItem.Text = "&Open Workspace";
            // 
            // saveWorkspaceToolStripMenuItem
            // 
            this.saveWorkspaceToolStripMenuItem.Name = "saveWorkspaceToolStripMenuItem";
            this.saveWorkspaceToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveWorkspaceToolStripMenuItem.Size = new System.Drawing.Size(210, 22);
            this.saveWorkspaceToolStripMenuItem.Text = "&Save Workspace...";
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(207, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(210, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.setBackgroundToolStripMenuItem,
            this.toolStripMenuItem4,
            this.vSyncToolStripMenuItem});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.optionsToolStripMenuItem.Text = "&Options";
            // 
            // setBackgroundToolStripMenuItem
            // 
            this.setBackgroundToolStripMenuItem.Name = "setBackgroundToolStripMenuItem";
            this.setBackgroundToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.setBackgroundToolStripMenuItem.Text = "Set &Background...";
            this.setBackgroundToolStripMenuItem.Click += new System.EventHandler(this.setBackgroundToolStripMenuItem_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(163, 6);
            // 
            // vSyncToolStripMenuItem
            // 
            this.vSyncToolStripMenuItem.CheckOnClick = true;
            this.vSyncToolStripMenuItem.Name = "vSyncToolStripMenuItem";
            this.vSyncToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.vSyncToolStripMenuItem.Text = "&VSync";
            this.vSyncToolStripMenuItem.Click += new System.EventHandler(this.vSyncToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openGLInformationToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // openGLInformationToolStripMenuItem
            // 
            this.openGLInformationToolStripMenuItem.Name = "openGLInformationToolStripMenuItem";
            this.openGLInformationToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.openGLInformationToolStripMenuItem.Text = "&OpenGL Information";
            this.openGLInformationToolStripMenuItem.Click += new System.EventHandler(this.openGLInformationToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.aboutToolStripMenuItem.Text = "&About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // cdlgBackground
            // 
            this.cdlgBackground.AnyColor = true;
            this.cdlgBackground.FullOpen = true;
            this.cdlgBackground.SolidColorOnly = true;
            // 
            // glControl1
            // 
            this.glControl1.BackColor = System.Drawing.Color.Black;
            this.glControl1.Camera = true;
            this.glControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.glControl1.Lighting = true;
            this.glControl1.Location = new System.Drawing.Point(200, 24);
            this.glControl1.Name = "glControl1";
            this.glControl1.ProjectionType = Aglex.ProjectionTypes.Perspective;
            this.glControl1.Size = new System.Drawing.Size(684, 516);
            this.glControl1.TabIndex = 2;
            this.glControl1.VSync = true;
            this.glControl1.Render += new System.EventHandler<System.EventArgs>(this.glControl1_Render);
            this.glControl1.Load += new System.EventHandler(this.glControl1_Load);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsslStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 540);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(884, 22);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tsslStatus
            // 
            this.tsslStatus.Name = "tsslStatus";
            this.tsslStatus.Size = new System.Drawing.Size(27, 17);
            this.tsslStatus.Text = "----";
            // 
            // cmsNodeMenu
            // 
            this.cmsNodeMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addNodeToolStripMenuItem,
            this.removeNodeToolStripMenuItem,
            this.toolStripMenuItem1,
            this.editNodeToolStripMenuItem});
            this.cmsNodeMenu.Name = "cmsNodeMenu";
            this.cmsNodeMenu.Size = new System.Drawing.Size(150, 76);
            // 
            // addNodeToolStripMenuItem
            // 
            this.addNodeToolStripMenuItem.Name = "addNodeToolStripMenuItem";
            this.addNodeToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.addNodeToolStripMenuItem.Text = "&Add Node";
            this.addNodeToolStripMenuItem.Click += new System.EventHandler(this.addNodeToolStripMenuItem_Click);
            // 
            // removeNodeToolStripMenuItem
            // 
            this.removeNodeToolStripMenuItem.Name = "removeNodeToolStripMenuItem";
            this.removeNodeToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.removeNodeToolStripMenuItem.Text = "&Remove Node";
            this.removeNodeToolStripMenuItem.Click += new System.EventHandler(this.removeNodeToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(146, 6);
            // 
            // editNodeToolStripMenuItem
            // 
            this.editNodeToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editNodeToolStripMenuItem.Name = "editNodeToolStripMenuItem";
            this.editNodeToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.editNodeToolStripMenuItem.Text = "&Edit Node";
            this.editNodeToolStripMenuItem.Click += new System.EventHandler(this.editNodeToolStripMenuItem_Click);
            // 
            // treeViewEx1
            // 
            this.treeViewEx1.Dock = System.Windows.Forms.DockStyle.Left;
            this.treeViewEx1.FullRowSelect = true;
            this.treeViewEx1.HideSelection = false;
            this.treeViewEx1.Location = new System.Drawing.Point(0, 24);
            this.treeViewEx1.Name = "treeViewEx1";
            this.treeViewEx1.Size = new System.Drawing.Size(200, 516);
            this.treeViewEx1.TabIndex = 1;
            this.treeViewEx1.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeViewEx1_NodeMouseDoubleClick);
            this.treeViewEx1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.treeViewEx1_MouseUp);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 562);
            this.Controls.Add(this.glControl1);
            this.Controls.Add(this.treeViewEx1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "----";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.cmsNodeMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Aglex.GLControl glControl1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setBackgroundToolStripMenuItem;
        private System.Windows.Forms.ColorDialog cdlgBackground;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tsslStatus;
        private System.Windows.Forms.ToolStripMenuItem openGLInformationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private Controls.TreeViewEx treeViewEx1;
        private System.Windows.Forms.ContextMenuStrip cmsNodeMenu;
        private System.Windows.Forms.ToolStripMenuItem addNodeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeNodeToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem editNodeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newWorkspaceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveWorkspaceToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem openWorkspaceToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem vSyncToolStripMenuItem;

    }
}

