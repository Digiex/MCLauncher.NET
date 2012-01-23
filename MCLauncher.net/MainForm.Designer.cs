namespace MCLauncher.net
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.launchButton = new System.Windows.Forms.Button();
            this.userNameLabel = new System.Windows.Forms.Label();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.mainTab = new System.Windows.Forms.TabPage();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.settingsTab = new System.Windows.Forms.TabPage();
            this.saveButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.memoryBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.jarManager = new System.Windows.Forms.TabPage();
            this.downloadButton = new System.Windows.Forms.Button();
            this.fileSizeLabel = new System.Windows.Forms.Label();
            this.fileNameLabel = new System.Windows.Forms.Label();
            this.saveNotes = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.jarCommentBox = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.modInstallerLabel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.jarList = new System.Windows.Forms.TreeView();
            this.screenshotTab = new System.Windows.Forms.TabPage();
            this.refreshButton = new System.Windows.Forms.Button();
            this.screenshotView = new System.Windows.Forms.ListView();
            this.screenshotRightClick = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.screenshotDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.jarBox = new System.Windows.Forms.ComboBox();
            this.screenshotImageList = new System.Windows.Forms.ImageList(this.components);
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.trayIconMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.forceCloseMC = new System.Windows.Forms.ToolStripMenuItem();
            this.showButton = new System.Windows.Forms.ToolStripMenuItem();
            this.closeButton = new System.Windows.Forms.ToolStripMenuItem();
            this.javaThread = new System.ComponentModel.BackgroundWorker();
            this.label7 = new System.Windows.Forms.Label();
            this.javaInstallationSelect = new System.Windows.Forms.OpenFileDialog();
            this.javaInstallationPath = new System.Windows.Forms.TextBox();
            this.selectJavaButton = new System.Windows.Forms.Button();
            this.tabControl.SuspendLayout();
            this.mainTab.SuspendLayout();
            this.settingsTab.SuspendLayout();
            this.jarManager.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.screenshotTab.SuspendLayout();
            this.screenshotRightClick.SuspendLayout();
            this.trayIconMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // launchButton
            // 
            this.launchButton.Location = new System.Drawing.Point(711, 417);
            this.launchButton.Name = "launchButton";
            this.launchButton.Size = new System.Drawing.Size(75, 23);
            this.launchButton.TabIndex = 0;
            this.launchButton.Text = "Launch!";
            this.launchButton.UseVisualStyleBackColor = true;
            this.launchButton.Click += new System.EventHandler(this.launchButton_Click);
            // 
            // userNameLabel
            // 
            this.userNameLabel.AutoSize = true;
            this.userNameLabel.Location = new System.Drawing.Point(9, 430);
            this.userNameLabel.Name = "userNameLabel";
            this.userNameLabel.Size = new System.Drawing.Size(73, 13);
            this.userNameLabel.TabIndex = 1;
            this.userNameLabel.Text = "Not logged in!";
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.mainTab);
            this.tabControl.Controls.Add(this.settingsTab);
            this.tabControl.Controls.Add(this.jarManager);
            this.tabControl.Controls.Add(this.screenshotTab);
            this.tabControl.Location = new System.Drawing.Point(12, 12);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(774, 399);
            this.tabControl.TabIndex = 2;
            // 
            // mainTab
            // 
            this.mainTab.Controls.Add(this.webBrowser1);
            this.mainTab.Location = new System.Drawing.Point(4, 22);
            this.mainTab.Name = "mainTab";
            this.mainTab.Padding = new System.Windows.Forms.Padding(3);
            this.mainTab.Size = new System.Drawing.Size(766, 373);
            this.mainTab.TabIndex = 0;
            this.mainTab.Text = "News";
            this.mainTab.UseVisualStyleBackColor = true;
            // 
            // webBrowser1
            // 
            this.webBrowser1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser1.Location = new System.Drawing.Point(3, 3);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(760, 367);
            this.webBrowser1.TabIndex = 0;
            this.webBrowser1.Url = new System.Uri("about:blank", System.UriKind.Absolute);
            // 
            // settingsTab
            // 
            this.settingsTab.Controls.Add(this.selectJavaButton);
            this.settingsTab.Controls.Add(this.javaInstallationPath);
            this.settingsTab.Controls.Add(this.label7);
            this.settingsTab.Controls.Add(this.saveButton);
            this.settingsTab.Controls.Add(this.label2);
            this.settingsTab.Controls.Add(this.memoryBox);
            this.settingsTab.Controls.Add(this.label1);
            this.settingsTab.Location = new System.Drawing.Point(4, 22);
            this.settingsTab.Name = "settingsTab";
            this.settingsTab.Padding = new System.Windows.Forms.Padding(3);
            this.settingsTab.Size = new System.Drawing.Size(766, 373);
            this.settingsTab.TabIndex = 1;
            this.settingsTab.Text = "Advanced Settings";
            this.settingsTab.UseVisualStyleBackColor = true;
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(685, 347);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 3;
            this.saveButton.Text = "Save settings";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(205, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(22, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Mb";
            // 
            // memoryBox
            // 
            this.memoryBox.Location = new System.Drawing.Point(98, 15);
            this.memoryBox.Name = "memoryBox";
            this.memoryBox.Size = new System.Drawing.Size(100, 20);
            this.memoryBox.TabIndex = 1;
            this.memoryBox.Text = "256";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Maximum memory";
            // 
            // jarManager
            // 
            this.jarManager.Controls.Add(this.downloadButton);
            this.jarManager.Controls.Add(this.fileSizeLabel);
            this.jarManager.Controls.Add(this.fileNameLabel);
            this.jarManager.Controls.Add(this.saveNotes);
            this.jarManager.Controls.Add(this.label5);
            this.jarManager.Controls.Add(this.jarCommentBox);
            this.jarManager.Controls.Add(this.groupBox1);
            this.jarManager.Controls.Add(this.label4);
            this.jarManager.Controls.Add(this.label3);
            this.jarManager.Controls.Add(this.jarList);
            this.jarManager.Location = new System.Drawing.Point(4, 22);
            this.jarManager.Name = "jarManager";
            this.jarManager.Padding = new System.Windows.Forms.Padding(3);
            this.jarManager.Size = new System.Drawing.Size(766, 373);
            this.jarManager.TabIndex = 2;
            this.jarManager.Text = "JAR Manager";
            this.jarManager.UseVisualStyleBackColor = true;
            // 
            // downloadButton
            // 
            this.downloadButton.Location = new System.Drawing.Point(7, 346);
            this.downloadButton.Name = "downloadButton";
            this.downloadButton.Size = new System.Drawing.Size(201, 27);
            this.downloadButton.TabIndex = 9;
            this.downloadButton.Text = "Download more versions";
            this.downloadButton.UseVisualStyleBackColor = true;
            this.downloadButton.Click += new System.EventHandler(this.downloadButton_Click);
            // 
            // fileSizeLabel
            // 
            this.fileSizeLabel.AutoSize = true;
            this.fileSizeLabel.Location = new System.Drawing.Point(271, 24);
            this.fileSizeLabel.Name = "fileSizeLabel";
            this.fileSizeLabel.Size = new System.Drawing.Size(81, 13);
            this.fileSizeLabel.TabIndex = 8;
            this.fileSizeLabel.Text = "No Jar selected";
            // 
            // fileNameLabel
            // 
            this.fileNameLabel.AutoSize = true;
            this.fileNameLabel.Location = new System.Drawing.Point(271, 7);
            this.fileNameLabel.Name = "fileNameLabel";
            this.fileNameLabel.Size = new System.Drawing.Size(81, 13);
            this.fileNameLabel.TabIndex = 7;
            this.fileNameLabel.Text = "No Jar selected";
            // 
            // saveNotes
            // 
            this.saveNotes.Enabled = false;
            this.saveNotes.Location = new System.Drawing.Point(685, 345);
            this.saveNotes.Name = "saveNotes";
            this.saveNotes.Size = new System.Drawing.Size(75, 23);
            this.saveNotes.TabIndex = 6;
            this.saveNotes.Text = "Save Notes";
            this.saveNotes.UseVisualStyleBackColor = true;
            this.saveNotes.Click += new System.EventHandler(this.saveNotes_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(214, 91);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Notes:";
            // 
            // jarCommentBox
            // 
            this.jarCommentBox.Enabled = false;
            this.jarCommentBox.Location = new System.Drawing.Point(214, 111);
            this.jarCommentBox.Multiline = true;
            this.jarCommentBox.Name = "jarCommentBox";
            this.jarCommentBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.jarCommentBox.Size = new System.Drawing.Size(545, 228);
            this.jarCommentBox.TabIndex = 4;
            this.jarCommentBox.Text = "No Jar selected!";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.modInstallerLabel);
            this.groupBox1.Location = new System.Drawing.Point(560, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 100);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Mod Installer";
            this.groupBox1.DragDrop += new System.Windows.Forms.DragEventHandler(this.groupBox1_DragDrop);
            this.groupBox1.DragEnter += new System.Windows.Forms.DragEventHandler(this.groupBox1_DragEnter);
            // 
            // modInstallerLabel
            // 
            this.modInstallerLabel.AutoSize = true;
            this.modInstallerLabel.Location = new System.Drawing.Point(34, 42);
            this.modInstallerLabel.Name = "modInstallerLabel";
            this.modInstallerLabel.Size = new System.Drawing.Size(121, 13);
            this.modInstallerLabel.TabIndex = 0;
            this.modInstallerLabel.Text = "Select a Jar from the left";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(215, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(27, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Size";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(215, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Filename";
            // 
            // jarList
            // 
            this.jarList.AllowDrop = true;
            this.jarList.Location = new System.Drawing.Point(3, 6);
            this.jarList.Name = "jarList";
            this.jarList.Size = new System.Drawing.Size(205, 333);
            this.jarList.TabIndex = 0;
            this.jarList.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.jarList_AfterSelect);
            this.jarList.DragDrop += new System.Windows.Forms.DragEventHandler(this.jarList_DragDrop);
            this.jarList.DragEnter += new System.Windows.Forms.DragEventHandler(this.groupBox1_DragEnter);
            // 
            // screenshotTab
            // 
            this.screenshotTab.Controls.Add(this.refreshButton);
            this.screenshotTab.Controls.Add(this.screenshotView);
            this.screenshotTab.Location = new System.Drawing.Point(4, 22);
            this.screenshotTab.Name = "screenshotTab";
            this.screenshotTab.Padding = new System.Windows.Forms.Padding(3);
            this.screenshotTab.Size = new System.Drawing.Size(766, 373);
            this.screenshotTab.TabIndex = 3;
            this.screenshotTab.Text = "Screenshots";
            this.screenshotTab.UseVisualStyleBackColor = true;
            // 
            // refreshButton
            // 
            this.refreshButton.Location = new System.Drawing.Point(685, 344);
            this.refreshButton.Name = "refreshButton";
            this.refreshButton.Size = new System.Drawing.Size(75, 23);
            this.refreshButton.TabIndex = 1;
            this.refreshButton.Text = "Refresh";
            this.refreshButton.UseVisualStyleBackColor = true;
            this.refreshButton.Click += new System.EventHandler(this.refreshButton_Click);
            // 
            // screenshotView
            // 
            this.screenshotView.ContextMenuStrip = this.screenshotRightClick;
            this.screenshotView.Location = new System.Drawing.Point(4, 4);
            this.screenshotView.Name = "screenshotView";
            this.screenshotView.Size = new System.Drawing.Size(756, 342);
            this.screenshotView.TabIndex = 0;
            this.screenshotView.UseCompatibleStateImageBehavior = false;
            this.screenshotView.DoubleClick += new System.EventHandler(this.screenshotView_DoubleClick);
            // 
            // screenshotRightClick
            // 
            this.screenshotRightClick.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.screenshotDelete});
            this.screenshotRightClick.Name = "screenshotRightClick";
            this.screenshotRightClick.Size = new System.Drawing.Size(132, 26);
            // 
            // screenshotDelete
            // 
            this.screenshotDelete.Name = "screenshotDelete";
            this.screenshotDelete.ShortcutKeys = System.Windows.Forms.Keys.Delete;
            this.screenshotDelete.Size = new System.Drawing.Size(131, 22);
            this.screenshotDelete.Text = "Delete";
            this.screenshotDelete.Click += new System.EventHandler(this.screenshotDelete_Click);
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(518, 420);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "Select JAR";
            // 
            // jarBox
            // 
            this.jarBox.FormattingEnabled = true;
            this.jarBox.Location = new System.Drawing.Point(584, 417);
            this.jarBox.Name = "jarBox";
            this.jarBox.Size = new System.Drawing.Size(121, 21);
            this.jarBox.TabIndex = 3;
            // 
            // screenshotImageList
            // 
            this.screenshotImageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.screenshotImageList.ImageSize = new System.Drawing.Size(16, 16);
            this.screenshotImageList.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // notifyIcon
            // 
            this.notifyIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyIcon.BalloonTipText = "You can show the launcher by right clicking this icon.";
            this.notifyIcon.BalloonTipTitle = "Digiex .NET Minecraft Launcher is still running!";
            this.notifyIcon.ContextMenuStrip = this.trayIconMenu;
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "Digiex .NET Minecraft Launcher";
            this.notifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseDoubleClick);
            // 
            // trayIconMenu
            // 
            this.trayIconMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.forceCloseMC,
            this.showButton,
            this.closeButton});
            this.trayIconMenu.Name = "trayIconMenu";
            this.trayIconMenu.Size = new System.Drawing.Size(188, 70);
            // 
            // forceCloseMC
            // 
            this.forceCloseMC.Name = "forceCloseMC";
            this.forceCloseMC.Size = new System.Drawing.Size(187, 22);
            this.forceCloseMC.Text = "Force close minecraft";
            this.forceCloseMC.Click += new System.EventHandler(this.forceCloseMC_Click);
            // 
            // showButton
            // 
            this.showButton.Name = "showButton";
            this.showButton.Size = new System.Drawing.Size(187, 22);
            this.showButton.Text = "Show";
            this.showButton.Click += new System.EventHandler(this.showButton_Click);
            // 
            // closeButton
            // 
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(187, 22);
            this.closeButton.Text = "Close";
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // javaThread
            // 
            this.javaThread.WorkerSupportsCancellation = true;
            this.javaThread.DoWork += new System.ComponentModel.DoWorkEventHandler(this.javaThread_DoWork);
            this.javaThread.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.javaThread_RunWorkerCompleted);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(4, 49);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(82, 13);
            this.label7.TabIndex = 4;
            this.label7.Text = "Java installation";
            // 
            // javaInstallationSelect
            // 
            this.javaInstallationSelect.DefaultExt = "exe";
            this.javaInstallationSelect.FileName = "javaw.exe";
            this.javaInstallationSelect.Filter = "Javaw|javaw.exe";
            this.javaInstallationSelect.InitialDirectory = "%programfiles%";
            this.javaInstallationSelect.Title = "Select Java Installation";
            // 
            // javaInstallationPath
            // 
            this.javaInstallationPath.Location = new System.Drawing.Point(98, 49);
            this.javaInstallationPath.Name = "javaInstallationPath";
            this.javaInstallationPath.ReadOnly = true;
            this.javaInstallationPath.Size = new System.Drawing.Size(591, 20);
            this.javaInstallationPath.TabIndex = 5;
            this.javaInstallationPath.Text = "No java found!";
            // 
            // selectJavaButton
            // 
            this.selectJavaButton.Location = new System.Drawing.Point(691, 49);
            this.selectJavaButton.Name = "selectJavaButton";
            this.selectJavaButton.Size = new System.Drawing.Size(75, 23);
            this.selectJavaButton.TabIndex = 6;
            this.selectJavaButton.Text = "Browse";
            this.selectJavaButton.UseVisualStyleBackColor = true;
            this.selectJavaButton.Click += new System.EventHandler(this.selectJavaButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(798, 452);
            this.Controls.Add(this.userNameLabel);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.jarBox);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.launchButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "Digiex .NET Minecraft Launcher";
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.MainForm_DragEnter);
            this.tabControl.ResumeLayout(false);
            this.mainTab.ResumeLayout(false);
            this.settingsTab.ResumeLayout(false);
            this.settingsTab.PerformLayout();
            this.jarManager.ResumeLayout(false);
            this.jarManager.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.screenshotTab.ResumeLayout(false);
            this.screenshotRightClick.ResumeLayout(false);
            this.trayIconMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button launchButton;
        private System.Windows.Forms.Label userNameLabel;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage mainTab;
        private System.Windows.Forms.TabPage settingsTab;
        private System.Windows.Forms.TabPage jarManager;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox memoryBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.TabPage screenshotTab;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label modInstallerLabel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ListView screenshotView;
        private System.Windows.Forms.ImageList screenshotImageList;
        private System.Windows.Forms.Button refreshButton;
        private System.Windows.Forms.ContextMenuStrip screenshotRightClick;
        private System.Windows.Forms.ToolStripMenuItem screenshotDelete;
        private System.Windows.Forms.Button saveNotes;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox jarCommentBox;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.ContextMenuStrip trayIconMenu;
        private System.Windows.Forms.ToolStripMenuItem forceCloseMC;
        private System.Windows.Forms.ToolStripMenuItem showButton;
        private System.Windows.Forms.ToolStripMenuItem closeButton;
        private System.ComponentModel.BackgroundWorker javaThread;
        private System.Windows.Forms.Label fileSizeLabel;
        private System.Windows.Forms.Label fileNameLabel;
        private System.Windows.Forms.Button downloadButton;
        public System.Windows.Forms.TreeView jarList;
        public System.Windows.Forms.ComboBox jarBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button selectJavaButton;
        private System.Windows.Forms.TextBox javaInstallationPath;
        private System.Windows.Forms.OpenFileDialog javaInstallationSelect;
    }
}

