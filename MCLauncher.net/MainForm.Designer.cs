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
            this.label9 = new System.Windows.Forms.Label();
            this.langSelect = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.selectJavaButton = new System.Windows.Forms.Button();
            this.javaInstallationPath = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
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
            this.javaInstallationSelect = new System.Windows.Forms.OpenFileDialog();
            this.windowSizeX = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.windowSizeY = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
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
            resources.ApplyResources(this.launchButton, "launchButton");
            this.launchButton.Name = "launchButton";
            this.launchButton.UseVisualStyleBackColor = true;
            this.launchButton.Click += new System.EventHandler(this.launchButton_Click);
            // 
            // userNameLabel
            // 
            resources.ApplyResources(this.userNameLabel, "userNameLabel");
            this.userNameLabel.Name = "userNameLabel";
            // 
            // tabControl
            // 
            resources.ApplyResources(this.tabControl, "tabControl");
            this.tabControl.Controls.Add(this.mainTab);
            this.tabControl.Controls.Add(this.settingsTab);
            this.tabControl.Controls.Add(this.jarManager);
            this.tabControl.Controls.Add(this.screenshotTab);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            // 
            // mainTab
            // 
            this.mainTab.Controls.Add(this.webBrowser1);
            resources.ApplyResources(this.mainTab, "mainTab");
            this.mainTab.Name = "mainTab";
            this.mainTab.UseVisualStyleBackColor = true;
            // 
            // webBrowser1
            // 
            resources.ApplyResources(this.webBrowser1, "webBrowser1");
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Url = new System.Uri("about:blank", System.UriKind.Absolute);
            this.webBrowser1.Navigating += new System.Windows.Forms.WebBrowserNavigatingEventHandler(this.webBrowser1_Navigating);
            // 
            // settingsTab
            // 
            this.settingsTab.Controls.Add(this.label11);
            this.settingsTab.Controls.Add(this.windowSizeY);
            this.settingsTab.Controls.Add(this.label10);
            this.settingsTab.Controls.Add(this.windowSizeX);
            this.settingsTab.Controls.Add(this.label9);
            this.settingsTab.Controls.Add(this.langSelect);
            this.settingsTab.Controls.Add(this.label8);
            this.settingsTab.Controls.Add(this.selectJavaButton);
            this.settingsTab.Controls.Add(this.javaInstallationPath);
            this.settingsTab.Controls.Add(this.label7);
            this.settingsTab.Controls.Add(this.saveButton);
            this.settingsTab.Controls.Add(this.label2);
            this.settingsTab.Controls.Add(this.memoryBox);
            this.settingsTab.Controls.Add(this.label1);
            resources.ApplyResources(this.settingsTab, "settingsTab");
            this.settingsTab.Name = "settingsTab";
            this.settingsTab.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            resources.ApplyResources(this.label9, "label9");
            this.label9.Name = "label9";
            // 
            // langSelect
            // 
            this.langSelect.FormattingEnabled = true;
            resources.ApplyResources(this.langSelect, "langSelect");
            this.langSelect.Name = "langSelect";
            // 
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.label8.Name = "label8";
            // 
            // selectJavaButton
            // 
            resources.ApplyResources(this.selectJavaButton, "selectJavaButton");
            this.selectJavaButton.Name = "selectJavaButton";
            this.selectJavaButton.UseVisualStyleBackColor = true;
            this.selectJavaButton.Click += new System.EventHandler(this.selectJavaButton_Click);
            // 
            // javaInstallationPath
            // 
            resources.ApplyResources(this.javaInstallationPath, "javaInstallationPath");
            this.javaInstallationPath.Name = "javaInstallationPath";
            this.javaInstallationPath.ReadOnly = true;
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            // 
            // saveButton
            // 
            resources.ApplyResources(this.saveButton, "saveButton");
            this.saveButton.Name = "saveButton";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // memoryBox
            // 
            resources.ApplyResources(this.memoryBox, "memoryBox");
            this.memoryBox.Name = "memoryBox";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
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
            resources.ApplyResources(this.jarManager, "jarManager");
            this.jarManager.Name = "jarManager";
            this.jarManager.UseVisualStyleBackColor = true;
            // 
            // downloadButton
            // 
            resources.ApplyResources(this.downloadButton, "downloadButton");
            this.downloadButton.Name = "downloadButton";
            this.downloadButton.UseVisualStyleBackColor = true;
            this.downloadButton.Click += new System.EventHandler(this.downloadButton_Click);
            // 
            // fileSizeLabel
            // 
            resources.ApplyResources(this.fileSizeLabel, "fileSizeLabel");
            this.fileSizeLabel.Name = "fileSizeLabel";
            // 
            // fileNameLabel
            // 
            resources.ApplyResources(this.fileNameLabel, "fileNameLabel");
            this.fileNameLabel.Name = "fileNameLabel";
            // 
            // saveNotes
            // 
            resources.ApplyResources(this.saveNotes, "saveNotes");
            this.saveNotes.Name = "saveNotes";
            this.saveNotes.UseVisualStyleBackColor = true;
            this.saveNotes.Click += new System.EventHandler(this.saveNotes_Click);
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // jarCommentBox
            // 
            resources.ApplyResources(this.jarCommentBox, "jarCommentBox");
            this.jarCommentBox.Name = "jarCommentBox";
            // 
            // groupBox1
            // 
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Controls.Add(this.modInstallerLabel);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            this.groupBox1.DragDrop += new System.Windows.Forms.DragEventHandler(this.groupBox1_DragDrop);
            this.groupBox1.DragEnter += new System.Windows.Forms.DragEventHandler(this.groupBox1_DragEnter);
            // 
            // modInstallerLabel
            // 
            resources.ApplyResources(this.modInstallerLabel, "modInstallerLabel");
            this.modInstallerLabel.Name = "modInstallerLabel";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // jarList
            // 
            this.jarList.AllowDrop = true;
            resources.ApplyResources(this.jarList, "jarList");
            this.jarList.Name = "jarList";
            this.jarList.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.jarList_AfterSelect);
            this.jarList.DragDrop += new System.Windows.Forms.DragEventHandler(this.jarList_DragDrop);
            this.jarList.DragEnter += new System.Windows.Forms.DragEventHandler(this.groupBox1_DragEnter);
            // 
            // screenshotTab
            // 
            this.screenshotTab.Controls.Add(this.refreshButton);
            this.screenshotTab.Controls.Add(this.screenshotView);
            resources.ApplyResources(this.screenshotTab, "screenshotTab");
            this.screenshotTab.Name = "screenshotTab";
            this.screenshotTab.UseVisualStyleBackColor = true;
            // 
            // refreshButton
            // 
            resources.ApplyResources(this.refreshButton, "refreshButton");
            this.refreshButton.Name = "refreshButton";
            this.refreshButton.UseVisualStyleBackColor = true;
            this.refreshButton.Click += new System.EventHandler(this.refreshButton_Click);
            // 
            // screenshotView
            // 
            resources.ApplyResources(this.screenshotView, "screenshotView");
            this.screenshotView.ContextMenuStrip = this.screenshotRightClick;
            this.screenshotView.Name = "screenshotView";
            this.screenshotView.UseCompatibleStateImageBehavior = false;
            this.screenshotView.DoubleClick += new System.EventHandler(this.screenshotView_DoubleClick);
            // 
            // screenshotRightClick
            // 
            this.screenshotRightClick.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.screenshotDelete});
            this.screenshotRightClick.Name = "screenshotRightClick";
            resources.ApplyResources(this.screenshotRightClick, "screenshotRightClick");
            // 
            // screenshotDelete
            // 
            this.screenshotDelete.Name = "screenshotDelete";
            resources.ApplyResources(this.screenshotDelete, "screenshotDelete");
            this.screenshotDelete.Click += new System.EventHandler(this.screenshotDelete_Click);
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            resources.ApplyResources(this.imageList1, "imageList1");
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // jarBox
            // 
            resources.ApplyResources(this.jarBox, "jarBox");
            this.jarBox.FormattingEnabled = true;
            this.jarBox.Name = "jarBox";
            // 
            // screenshotImageList
            // 
            this.screenshotImageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            resources.ApplyResources(this.screenshotImageList, "screenshotImageList");
            this.screenshotImageList.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // notifyIcon
            // 
            this.notifyIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            resources.ApplyResources(this.notifyIcon, "notifyIcon");
            this.notifyIcon.ContextMenuStrip = this.trayIconMenu;
            this.notifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseDoubleClick);
            // 
            // trayIconMenu
            // 
            this.trayIconMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.forceCloseMC,
            this.showButton,
            this.closeButton});
            this.trayIconMenu.Name = "trayIconMenu";
            resources.ApplyResources(this.trayIconMenu, "trayIconMenu");
            // 
            // forceCloseMC
            // 
            this.forceCloseMC.Name = "forceCloseMC";
            resources.ApplyResources(this.forceCloseMC, "forceCloseMC");
            this.forceCloseMC.Click += new System.EventHandler(this.forceCloseMC_Click);
            // 
            // showButton
            // 
            this.showButton.Name = "showButton";
            resources.ApplyResources(this.showButton, "showButton");
            this.showButton.Click += new System.EventHandler(this.showButton_Click);
            // 
            // closeButton
            // 
            this.closeButton.Name = "closeButton";
            resources.ApplyResources(this.closeButton, "closeButton");
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // javaThread
            // 
            this.javaThread.WorkerSupportsCancellation = true;
            this.javaThread.DoWork += new System.ComponentModel.DoWorkEventHandler(this.javaThread_DoWork);
            this.javaThread.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.javaThread_RunWorkerCompleted);
            // 
            // javaInstallationSelect
            // 
            resources.ApplyResources(this.javaInstallationSelect, "javaInstallationSelect");
            // 
            // windowSizeX
            // 
            resources.ApplyResources(this.windowSizeX, "windowSizeX");
            this.windowSizeX.Name = "windowSizeX";
            // 
            // label10
            // 
            resources.ApplyResources(this.label10, "label10");
            this.label10.Name = "label10";
            // 
            // windowSizeY
            // 
            resources.ApplyResources(this.windowSizeY, "windowSizeY");
            this.windowSizeY.Name = "windowSizeY";
            // 
            // label11
            // 
            resources.ApplyResources(this.label11, "label11");
            this.label11.Name = "label11";
            // 
            // MainForm
            // 
            this.AcceptButton = this.launchButton;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.userNameLabel);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.jarBox);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.launchButton);
            this.Name = "MainForm";
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
        private System.Windows.Forms.ComboBox langSelect;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox windowSizeY;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox windowSizeX;
        private System.Windows.Forms.Label label11;
    }
}

