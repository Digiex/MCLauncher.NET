using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using ICSharpCode.SharpZipLib.Zip;

namespace MCLauncher.net
{
    public partial class MainForm : Form
    {
        public String userName;
        public String sessionId;
        public String response;
        private String jarName = "minecraft.jar";
        public static String mcDir = Util.getWorkingDirectory();
        string[] jars = Directory.GetFiles(mcDir + Path.DirectorySeparatorChar + "bin" + Path.DirectorySeparatorChar, "*.jar");
        public MainForm()
        {
            if (!String.IsNullOrEmpty(Properties.Settings.Default.lang))
            {
                System.Threading.Thread.CurrentThread.CurrentUICulture = new CultureInfo(Properties.Settings.Default.lang);
            }
            InitializeComponent();
            if (userName == null || sessionId == null || response == null)
            {
                Login l = new Login(this);
                l.ShowDialog();
                if (userName == null || sessionId == null || response == null)
                {
                    Environment.Exit(0);
                }
                l.Dispose();
            }
            userNameLabel.Text = userName;
            initJarMan();
            groupBox1.AllowDrop = true;
            foreach (String jar in jars)
            {
                String jarname = System.IO.Path.GetFileName(jar);
                if (jarname == "jinput.jar" || jarname == "lwjgl.jar" || jarname == "lwjgl_util.jar")
                {
                    continue;
                }
                jarBox.Items.Add(jarname);
            }
            jarBox.SelectedItem = Properties.Settings.Default.lastjar;

            if (!screens_loaded)
            {
                loadScreenshots();
            }
            string CommitID = "unknown";
            if (File.Exists("commitid.txt"))
            {
                CommitID = File.ReadAllText("commitid.txt").Substring(0, 40);
                System.Console.WriteLine("Commit ID is " + CommitID);
            }
            webBrowser1.Url = new Uri("http://minecraft.digiex.org/intool.php?net=true&version=" + Assembly.GetEntryAssembly().GetName().Version.ToString() + "&lang=" + CultureInfo.CurrentUICulture + "&commit=" + CommitID);
            String javaExec = Util.GetJavaExecutable();
            String javaExecName = Util.GetJavaExecutableName();
            javaInstallationSelect.FileName = javaExecName;
            javaInstallationSelect.Filter = javaExecName + "|" + javaExecName + "|All Files|*";
            try
            {
                javaInstallationSelect.DefaultExt = Path.GetExtension(javaExecName);
            }
            catch (Exception) { }
            if (Util.getPlatform() == Util.OS.windows)
            {
                javaInstallationSelect.InitialDirectory = "%programfiles%";
            }
            if (javaExec != null && File.Exists(javaExec))
            {
                javaInstallationPath.Text = javaExec;
                javaInstallationSelect.InitialDirectory = Path.GetDirectoryName(javaExec);
            }
            else
            {
                if (MessageBox.Show(Util.langNode("javanotfounddesc"), Util.langNode("javanotfound"), MessageBoxButtons.YesNo) == DialogResult.Yes)
                {

                    if (javaInstallationSelect.ShowDialog() == DialogResult.OK && javaInstallationSelect.FileName != null)
                    {
                        javaInstallationPath.Text = javaExec;
                        javaExec = javaInstallationSelect.FileName;
                        Properties.Settings.Default.javaExecutable = javaExec;
                        Properties.Settings.Default.Save();
                    }
                    else
                    {
                        System.Diagnostics.Process.Start("http://java.com/");
                        Environment.Exit(0);
                    }
                }
                else
                {
                    System.Diagnostics.Process.Start("http://java.com/");
                    Environment.Exit(0);
                }
            }
            langSelect.Items.Clear();
            langSelect.Items.Add("fi");
            langSelect.Items.Add("en");
            string currentlang = System.Threading.Thread.CurrentThread.CurrentUICulture.TwoLetterISOLanguageName;
            if (langSelect.Items.Contains(currentlang))
            {
                langSelect.SelectedItem = currentlang;
            }
        }
        public void runMinecraft()
        {
            if (javaThread.IsBusy != true)
            {
                javaThread.RunWorkerAsync();
            }
        }
        public void DataReceived(object sender, DataReceivedEventArgs e)
        {
            // e.Data is the line which was written to standard output
            System.Console.WriteLine(e.Data);
        }

        private void launchButton_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.lastjar = (string)jarBox.SelectedItem;

            Properties.Settings.Default.Save();
            jarName = (string)jarBox.SelectedItem;
            runMinecraft();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.maxmem = memoryBox.Text + "M";
            Properties.Settings.Default.javaExecutable = javaInstallationPath.Text;
            string selectedlang = (string)langSelect.SelectedItem;
            if (selectedlang != null)
            {
                if (langSelect.Items.Contains(selectedlang) && Properties.Settings.Default.lang != selectedlang)
                {
                    Properties.Settings.Default.lang = selectedlang;
                    MessageBox.Show(Util.langNode("langwillchangeinfo"), Util.langNode("langwillchangetitle"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    System.Threading.Thread.CurrentThread.CurrentUICulture = new CultureInfo(selectedlang);
                }
            }
            Properties.Settings.Default.Save();
        }
        private void initJarMan()
        {
            //imageList1.Images.Add(System.Drawing.Icon.ExtractAssociatedIcon(jars[1]));
            try
            {
                imageList1.Images.Add(Image.FromFile("images" + Path.DirectorySeparatorChar + "jarformat.ico"));
            }
            catch (Exception)
            {
                try
                {
                    imageList1.Images.Add(System.Drawing.Icon.ExtractAssociatedIcon(jars[1]));
                }
                catch (Exception) { }
            }
            jarList.ImageList = imageList1;

            foreach (String jar in jars)
            {
                String jarname = System.IO.Path.GetFileName(jar);
                if (jarname == "jinput.jar" || jarname == "lwjgl.jar" || jarname == "lwjgl_util.jar")
                {
                    continue;
                }
                TreeNode node = new TreeNode();
                node.Text = jarname;
                node.ImageIndex = 0;
                node.Name = jar;
                jarList.Nodes.Add(node);
            }
        }


        private void jarList_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (!File.Exists(e.Node.Name))
            {
                jarList.Nodes.Remove(e.Node);
                jarBox.Items.Remove(System.IO.Path.GetFileName(e.Node.Name));
                return;
            }
            modInstallerLabel.Text = Util.langNode("dragfileshere");
            saveNotes.Enabled = true;
            jarCommentBox.Enabled = true;
            fileNameLabel.Text = System.IO.Path.GetFileName(e.Node.Name);
            fileSizeLabel.Text = Util.BytesToFileSize((new FileInfo(e.Node.Name)).Length);
            ZipFile zf = null;
            try
            {
                FileStream fs = File.OpenRead(e.Node.Name);
                zf = new ZipFile(fs);
                jarCommentBox.Text = zf.ZipFileComment;
                fs.Close();
                fs.Dispose();
            }
            catch (Exception ex)
            {
                jarCommentBox.Text = Util.langNode("couldnotreadjar") + " " + ex.Message + "\r\n" + ex.StackTrace;
            }
            finally
            {
                if (zf != null)
                {
                    zf.IsStreamOwner = true; // Makes close also shut the underlying stream
                    zf.Close(); // Ensure we release resources
                }
            }

        }

        private void groupBox1_DragDrop(object sender, DragEventArgs e)
        {
            try
            {
                modInstallerLabel.Text = Util.langNode("adding");
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                ZipFile zf = new ZipFile(jarList.SelectedNode.Name);
                String comment = zf.ZipFileComment + "\r\n--- " + DateTime.Now + " " + Util.langNode("addedthesefiles") + " ---\r\n";
                zf.BeginUpdate();
                int i = 0;
                foreach (string file in files)
                {
                    Console.WriteLine("Adding " + file);
                    if (((File.GetAttributes(file) & FileAttributes.Directory) == FileAttributes.Directory))
                    {

                        System.Console.WriteLine("It is a directory!");
                        //zf.AddDirectory(dirname);
                        string[] filesindir = Directory.GetFiles(file, "*", SearchOption.AllDirectories);

                        // Display all the files.
                        foreach (string fileindir in filesindir)
                        {
                            Console.WriteLine("Adding " + fileindir.Replace(Directory.GetParent(file).FullName, ""));
                            zf.Add(fileindir, fileindir.Replace(Directory.GetParent(file).FullName, ""));
                            comment += fileindir.Replace(Directory.GetParent(file).FullName, "") + "\r\n";
                            i++;
                        }

                    }
                    else
                    {
                        zf.Add(file, System.IO.Path.GetFileName(file));
                        comment += System.IO.Path.GetFileName(file) + "\r\n";
                        i++;
                    }
                }
                ZipEntry mi = zf.GetEntry("META-INF");
                if (mi != null)
                {
                    zf.Delete(mi);
                    comment += String.Format(Util.langNode("removedfile"), "META-INF") + "\r\n";
                }
                zf.SetComment(comment);
                jarCommentBox.Text = comment;
                zf.CommitUpdate();
                zf.Close();
                modInstallerLabel.Text = String.Format(Util.langNode("addedfiles"), i);
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Could not write: " + ex.Message + "\r\n" + ex.StackTrace);
                modInstallerLabel.Text = String.Format(Util.langNode("errordetail"), ex.Message);
            }

        }

        private void groupBox1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Copy;
        }

        private void MainForm_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.None;
        }
        private Boolean screens_loaded = false;

        private void loadScreenshots()
        {
            screens_loaded = true;
            DirectoryInfo dir = new DirectoryInfo(mcDir + Path.DirectorySeparatorChar + "screenshots");
            int i = 0;
            if (dir.Exists && dir.GetFiles().Length > 0)
            {
                foreach (FileInfo file in dir.GetFiles())
                {

                    try
                    {
                        System.IO.FileStream fs;
                        fs = new System.IO.FileStream(file.FullName,
                       System.IO.FileMode.Open, System.IO.FileAccess.Read);

                        this.screenshotImageList.Images.Add(System.Drawing.Image.FromStream(fs));
                        fs.Close();
                        fs.Dispose();

                        ListViewItem item = new ListViewItem();
                        item.Name = file.FullName;
                        item.Text = file.Name;
                        item.ImageIndex = i;

                        this.screenshotView.Items.Add(item);
                        i++;

                    }

                    catch
                    {

                        Console.WriteLine(file.Name + " is not an image file");

                    }

                }
            }
            this.screenshotView.View = View.LargeIcon;

            this.screenshotImageList.ImageSize = new Size(200, 128);

            this.screenshotView.LargeImageList = this.screenshotImageList;
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            this.screenshotView.Items.Clear();
            this.screenshotImageList.Images.Clear();
            loadScreenshots();
        }

        private void screenshotView_DoubleClick(object sender, EventArgs e)
        {
            foreach (ListViewItem item in screenshotView.SelectedItems)
            {
                System.Diagnostics.Process.Start(item.Name);
            }
        }

        private void screenshotDelete_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in screenshotView.SelectedItems)
            {
                try
                {
                    File.Delete(item.Name);
                    screenshotView.Items.Remove(item);
                }
                catch (Exception ex)
                {
                    System.Console.WriteLine("Could not delete: " + ex.Message + ex.StackTrace);
                }
            }
        }

        private void saveNotes_Click(object sender, EventArgs e)
        {
            try
            {
                ZipFile zf = new ZipFile(jarList.SelectedNode.Name);
                zf.BeginUpdate();
                zf.SetComment(jarCommentBox.Text);
                zf.CommitUpdate();
                zf.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, Util.langNode("couldnotsavenotes") + " " + ex.Message + "\n" + ex.StackTrace, Util.langNode("errorwhilesavingnotes"), MessageBoxButtons.OK);
            }
        }

        private void showButton_Click(object sender, EventArgs e)
        {
            this.Show();
            notifyIcon.Visible = false;
        }

        private void forceCloseMC_Click(object sender, EventArgs e)
        {
            System.Console.WriteLine("Force-closing minecraft!");
            try
            {
                proc.Kill();
            }
            catch (Exception)
            {
            }
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
        System.Diagnostics.Process proc;
        private void javaThread_DoWork(object sender, DoWorkEventArgs e)
        {
            String javaExec = Util.GetJavaExecutable();
            Console.WriteLine("Java found at " + javaExec);
            Boolean exists = File.Exists(Util.getWorkingDirectory()
                    + Path.DirectorySeparatorChar + "bin" + Path.DirectorySeparatorChar + jarName);
            if (!exists)
            {
                Console.WriteLine("Jar (" + Util.getWorkingDirectory()
                    + Path.DirectorySeparatorChar + "bin" + Path.DirectorySeparatorChar + jarName
                        + ") not found!");
                MessageBox.Show(String.Format(Util.langNode("jarnotfoundat"), Util.getWorkingDirectory()
                    + Path.DirectorySeparatorChar + "bin" + Path.DirectorySeparatorChar + jarName), Util.langNode("jarnotfound"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            proc = new System.Diagnostics.Process();
            proc.EnableRaisingEvents = false;
            proc.StartInfo.FileName = Util.GetJavaExecutable();
            proc.StartInfo.Arguments = "-Xmx" + Properties.Settings.Default.maxmem + " -cp launcher Launcher \"" + response + "\" \"" + jarName + "\"";
            proc.StartInfo.RedirectStandardError = true;
            proc.StartInfo.RedirectStandardInput = false;
            proc.StartInfo.RedirectStandardOutput = true;
            proc.StartInfo.UseShellExecute = false;
            proc.OutputDataReceived += DataReceived;
            proc.ErrorDataReceived += DataReceived;
            ShowNotifyIconInThread(true);
            ShowInThread(false);
            proc.Start();
            proc.BeginOutputReadLine();
            proc.WaitForExit();
            ShowInThread(true);
            ShowNotifyIconInThread(false);
        }
        private delegate void ShowCallback(bool visible);
        private void ShowInThread(bool visible)
        {
            ShowCallback callback = new ShowCallback(ShowHide);
            this.Invoke(callback, new object[] { visible });

        }
        private delegate void ShowNotifyIconCallback(bool visible);
        private void ShowNotifyIconInThread(bool visible)
        {
            ShowNotifyIconCallback callback = new ShowNotifyIconCallback(NotifyIconVisible);
            this.Invoke(callback, new object[] { visible });

        }
        private void NotifyIconVisible(bool visible)
        {
            this.notifyIcon.Visible = visible;
            if (visible)
            {
                notifyIcon.ShowBalloonTip(500);
            }
        }
        private void ShowHide(bool visible)
        {
            if (visible)
            {
                this.Show();
            }
            else
            {
                this.Hide();
            }
        }
        private void javaThread_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

        }

        private void notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
            notifyIcon.Visible = false;
        }

        private void jarList_DragDrop(object sender, DragEventArgs e)
        {
            try
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                foreach (String file in files)
                {
                    System.Console.WriteLine("Dropped " + file);
                    if (Path.GetExtension(file) == ".jar")
                    {
                        System.Console.WriteLine("Copying " + file);
                        File.Copy(file, mcDir + Path.DirectorySeparatorChar + "bin" + Path.DirectorySeparatorChar + Path.GetFileName(file));
                        TreeNode node = new TreeNode();
                        node.Text = Path.GetFileName(file);
                        node.ImageIndex = 0;
                        node.Name = file;
                        if (!jarList.Nodes.Contains(node))
                        {
                            jarList.Nodes.Add(node);
                        }
                        if (!jarBox.Items.Contains(Path.GetFileName(file)))
                        {
                            jarBox.Items.Add(Path.GetFileName(file));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Error: " + ex.Message + "\r\n" + ex.StackTrace);
            }
        }
        private void downloadButton_Click(object sender, EventArgs e)
        {
            DownloadManager dlman = new DownloadManager(this);
            dlman.ShowDialog();
            dlman.Close();
            dlman.Dispose();
        }

        private void selectJavaButton_Click(object sender, EventArgs e)
        {
            if (javaInstallationSelect.ShowDialog() == DialogResult.OK && javaInstallationSelect.FileName != null)
            {
                javaInstallationPath.Text = javaInstallationSelect.FileName;
            }
        }

        private void webBrowser1_Navigating(object sender, WebBrowserNavigatingEventArgs e)
        {
            if (e.Url.Host != "minecraft.digiex.org" || e.Url.ToString().Contains("openinbrowser"))
            {
                System.Diagnostics.Process.Start(e.Url.ToString());
                e.Cancel = true;
            }
        }


    }
}
