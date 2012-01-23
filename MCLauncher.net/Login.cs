using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace MCLauncher.net
{
    public partial class Login : Form
    {
        private delegate void SetTextCallback(string text);
        private MainForm mf;
        public Login(MainForm mf)
        {
            this.mf = mf;
            InitializeComponent();
            userNameBox.Text = Properties.Settings.Default.username;
            rememberBox.Checked = Properties.Settings.Default.remember;
            this.AcceptButton = loginButton;
            String cryptedPass = Properties.Settings.Default.password;
            if (cryptedPass.Length > 0)
            {
                this.passwordBox.Text = Crypto.DecryptStringAES(cryptedPass, "imashark");
            }
        }
        private void UpdateStatusText(string text)
        {
            statusText.Text = text;
        }

        private void SetStatusTextInThread(string text)
        {
            SetTextCallback callback = new SetTextCallback(UpdateStatusText);
            this.Invoke(callback, new object[] { text });

        }
 
        private void button1_Click(object sender, EventArgs e)
        {
            if (loginWorker.IsBusy != true)
            {
                loginWorker.RunWorkerAsync();
                loginButton.Enabled = false;
            }
        }
        public void login(String userName, String password, BackgroundWorker worker)
        {
            worker.ReportProgress(10);
            Console.WriteLine("Checking for bans at mcbans.com...");
            SetStatusTextInThread("Checking MCBans...");
            Boolean hasBans = false;
            hasBans = lookup(userName);
            //String banned = "0";
            //if (hasBans) {
            //    banned = "1";
            //}
            SetStatusTextInThread("Logging in...");
            worker.ReportProgress(20);
            try
            {
                String parameters = "user=" + userName
                        + "&password=" + password
                        + "&version=" + 53;
                String result = Util.excutePost("https://login.minecraft.net/", parameters);
                if (result == null)
                {
                    Console.WriteLine("Can't conenct to login servers.");
                    showError("Can't connect to minecraft.net");
                    //loginForm.setNoNetwork();
                    return;
                }
                worker.ReportProgress(30);
                if (!result.Contains(":"))
                {
                    if (result.Trim().Equals("Bad login"))
                    {
                        showError("Login failed");
                    }
                    else if (result.Trim().Equals("Old version"))
                    {
                        //loginForm.setOutdated();
                        showError("Outdated launcher, contact jessenic@digiex.net");
                    }
                    else
                    {
                        showError(result);
                    }
                    //loginForm.setNoNetwork();
                    return;
                }
                worker.ReportProgress(40);
                SetStatusTextInThread("Processing MCBans...");
                if (hasBans)
                {
                    System.Diagnostics.Process.Start("http://mcbans.com/player/"
                            + userName + "/");
                    showError("You have too low ban REP! Check mcbans.com!");
                    return;

                }

                SetStatusTextInThread("Processing login...");
                worker.ReportProgress(50);
                //if (launcherFrame != null) {
                //    launcherFrame.setTitle("Digiex.net Minecraft Launcher - "
                //            + jarName);
                //    launcherFrame.validate();
                //}
                String[] values = result.Split(new Char[] { ':' });
                foreach (String s in values)
                {
                    Console.WriteLine("Split: " + s);
                }
                Properties.Settings.Default.remember = rememberBox.Checked;
                if (rememberBox.Checked)
                {
                    Properties.Settings.Default.username = values[2];
                    Properties.Settings.Default.password = Crypto.EncryptStringAES(passwordBox.Text, "imashark");
                }
                else
                {
                    Properties.Settings.Default.username = "";
                    Properties.Settings.Default.password = "";
                }
                Properties.Settings.Default.Save();
                mf.userName = values[2];
                mf.sessionId = values[3];
                mf.response = result;
                SetStatusTextInThread("Showing the main frame...");
                worker.ReportProgress(100);
                this.BeginInvoke(new MethodInvoker(Close));



            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                showError(e.Message);
                //loginForm.setNoNetwork();
            }
        }
        private static Boolean hasError = false;
        private void showError(String error)
        {
            hasError = true;
            Console.WriteLine("Error: " + error);
            SetStatusTextInThread("Error: "+error);
        }
        public Boolean lookup(String PlayerName)
        {
            Boolean banned = false;

            String result = Util.excuteGet("http://minecraft.digiex.org/mcbans.php", "username="
                    + PlayerName + "&version=3");
            using (StringReader reader = new StringReader(result))
            {
                int i = 0;
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    i++;
                    Console.WriteLine("[MCBans] " + line);
                    if (i == 1)
                    {
                        if (line.Contains("REP"))
                        {
                            String[] reps = line.Replace("REP ", "").Split(new Char[] { ' ', 'o', 'f', ' ' });
                            if (reps.Length == 2)
                            {
                                try
                                {
                                    if (Double.Parse(reps[0]) < Double.Parse(reps[1]))
                                    {
                                        banned = true;
                                    }
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine(ex.StackTrace);
                                }
                            }
                        }
                    }
                }
            }


            if (banned)
            {
                Console.WriteLine("Too low rep, sorry!");
                return true;
            }
            else
            {
                return false;
            }
        }

        private void loginWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            login(userNameBox.Text, passwordBox.Text, worker);

        }
        private void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if ((e.Cancelled == true))
            {
                Console.WriteLine("Cancelled!");
                statusText.Text = "Cancelled!";
                progressBar1.Value = 0;
            }

            else if (!(e.Error == null))
            {
                Console.WriteLine("Error: " + e.Error.Message);
                statusText.Text = "Error: "+e.Error.Message;
                progressBar1.Value = 0;
            }

            else
            {
                if (!hasError)
                {
                    Console.WriteLine("Done!");
                    statusText.Text = "Done!";
                }
                progressBar1.Value = 0;
            }
            loginButton.Enabled = true;
        }
        private void bw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        private void userNameBox_TextChanged(object sender, EventArgs e)
        {
            if (userNameBox.Text.Length < 1)
            {
                loginButton.Enabled = false;
            }
            else if (passwordBox.Text.Length > 0)
            {
                loginButton.Enabled = true;
            }
        }

        private void passwordBox_TextChanged(object sender, EventArgs e)
        {
            if (passwordBox.Text.Length < 1)
            {
                loginButton.Enabled = false;
            }
            else if (userNameBox.Text.Length > 0)
            {
                loginButton.Enabled = true;
            }

        }


    }

}