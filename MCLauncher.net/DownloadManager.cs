using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace MCLauncher.net
{
    public partial class DownloadManager : Form
    {
        // The thread inside which the download happens
        private Thread thrDownload;
        // The stream of data retrieved from the web server
        private Stream strResponse;
        // The stream of data that we write to the harddrive
        private Stream strLocal;
        // The request to the web server for file information
        private HttpWebRequest webRequest;
        // The response from the web server containing information about the file
        private HttpWebResponse webResponse;
        // The progress of the download in percentage
        private static int PercentProgress;
        private string url;
        // The delegate which we will call from the thread to update the form
        private delegate void UpdateProgessCallback(Int64 BytesRead, Int64 TotalBytes);
        private delegate void DownloadCompleteCallback();


        MainForm mf;
        public DownloadManager(MainForm mf)
        {
            InitializeComponent();
            this.mf = mf;
            Dictionary<string, string> list = new Dictionary<string, string>();

            String result = Util.excutePost("http://minecraft.digiex.org/jars.php", "net=true");
            if (result == null)
            {
                Console.WriteLine("Can't get the jar list");
                //loginForm.setNoNetwork();
                //return;
            }
            else
            {
                String[] lines = result.Split(new Char[] { '\n' });
                foreach (String line in lines)
                {
                    String[] values = line.Split(new Char[] { '|' });
                    list.Add(values[0], values[1]);
                }
            }
            listBox1.DataSource = new BindingSource(list, null);
            listBox1.DisplayMember = "Value";
            listBox1.ValueMember = "Key";
            saveFileDialog1.InitialDirectory = MainForm.mcDir + @"\bin\";
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            if (thrDownload == null || !thrDownload.IsAlive)
            {
                if (saveFileDialog1.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                {
                    return;
                }
                listBox1.Enabled = false;
                downloadButton.Text = Util.langNode("stop");
                // Let the user know we are connecting to the server
                statusLabel.Text = Util.langNode("dlstarting");
                // Create a new thread that calls the Download() method
                thrDownload = new Thread(Download);
                // Start the thread, and thus call Download()
                thrDownload.Start();
            }
            else
            {
                // Abort the thread that's downloading
                thrDownload.Abort();
                // Close the web response and the streams
                webResponse.Close();
                strResponse.Close();
                strLocal.Close();
                // Set the progress bar back to 0 and the label
                toolStripProgressBar1.Value = 0;
                statusLabel.Text = Util.langNode("dlstopped");
                listBox1.Enabled = true;
                downloadButton.Text = Util.langNode("startdl");
            }
        }
        private void DownloadComplete()
        {
            String outfile = saveFileDialog1.FileName;
            File.Move(outfile + ".tmp", outfile);
            listBox1.Enabled = true;
            downloadButton.Text = Util.langNode("startdl");
            toolStripProgressBar1.Value = 0;
            statusLabel.Text = Util.langNode("dlfinished");
            TreeNode node = new TreeNode();
            node.ImageIndex = 0;
            node.Name = outfile;
            if (!mf.jarList.Nodes.Contains(node))
            {
                mf.jarList.Nodes.Add(node);
            }
            if (!mf.jarBox.Items.Contains(Path.GetFileName(outfile)))
            {
                mf.jarBox.Items.Add(Path.GetFileName(outfile));
            }

        }
        private void UpdateProgress(Int64 BytesRead, Int64 TotalBytes)
        {
            // Calculate the download progress in percentages
            PercentProgress = Convert.ToInt32((BytesRead * 100) / TotalBytes);
            // Make progress on the progress bar
            toolStripProgressBar1.Value = PercentProgress;
            // Display the current progress on the form
            statusLabel.Text = String.Format(Util.langNode("downloadedoutof"), Util.BytesToFileSize(BytesRead), Util.BytesToFileSize(TotalBytes), PercentProgress);
        }

        private void Download()
        {
            using (WebClient wcDownload = new WebClient())
            {
                try
                {
                    // Create a request to the file we are downloading
                    webRequest = (HttpWebRequest)WebRequest.Create(url);
                    // Set default authentication for retrieving the file
                    webRequest.Credentials = CredentialCache.DefaultCredentials;
                    // Retrieve the response from the server
                    webResponse = (HttpWebResponse)webRequest.GetResponse();
                    // Ask the server for the file size and store it
                    Int64 fileSize = webResponse.ContentLength;

                    // Open the URL for download 
                    strResponse = wcDownload.OpenRead(url);
                    // Create a new file stream where we will be saving the data (local drive)
                    strLocal = new FileStream(saveFileDialog1.FileName + ".tmp", FileMode.Create, FileAccess.Write, FileShare.None);

                    // It will store the current number of bytes we retrieved from the server
                    int bytesSize = 0;
                    // A buffer for storing and writing the data retrieved from the server
                    byte[] downBuffer = new byte[2048];

                    // Loop through the buffer until the buffer is empty
                    while ((bytesSize = strResponse.Read(downBuffer, 0, downBuffer.Length)) > 0)
                    {
                        // Write the data from the buffer to the local hard drive
                        strLocal.Write(downBuffer, 0, bytesSize);
                        // Invoke the method that updates the form's label and progress bar
                        this.Invoke(new UpdateProgessCallback(this.UpdateProgress), new object[] { strLocal.Length, fileSize });
                    }
                }
                catch (Exception) { }
                finally
                {
                    try
                    {
                        // When the above code has ended, close the streams
                        webResponse.Close();
                        strResponse.Close();
                        strLocal.Close();
                        this.Invoke(new DownloadCompleteCallback(this.DownloadComplete), new object[] { });
                    }
                    catch (Exception) { }
                }
            }
        }


        private void DownloadManager_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (thrDownload != null)
            {
                if (thrDownload.IsAlive)
                {
                    if (DialogResult.Yes != MessageBox.Show(

                        Util.langNode("dlmanclose"),

                        Util.langNode("dlmanclosetitle"),

                         MessageBoxButtons.YesNo,

                         MessageBoxIcon.Question,

                         MessageBoxDefaultButton.Button2))
                    {

                        e.Cancel = true;

                    }
                    else
                    {
                        // Abort the thread that's downloading
                        thrDownload.Abort();
                        // Close the web response and the streams
                        webResponse.Close();
                        strResponse.Close();
                        strLocal.Close();
                    }
                }
            }

        }

        private void listBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedItems.Count > 0)
            {
                saveFileDialog1.FileName = Path.GetFileName(listBox1.SelectedValue.ToString());
                downloadButton.Enabled = true;
                url = listBox1.SelectedValue.ToString();
            }
            else
            {
                downloadButton.Enabled = false;
                url = "";
            }
        }
    }
}
