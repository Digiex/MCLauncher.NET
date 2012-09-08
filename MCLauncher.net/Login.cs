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
using MCLauncher.net.Properties;
using System.Collections;

namespace MCLauncher.net
{
    public partial class Login : Form
    {
        private delegate void SetTextCallback(string text);
        private delegate void ShowErrorCallback(string text);
        private MainForm mf;
        public Login(MainForm mf)
        {
            this.mf = mf;
            if (Settings.Default.lastusers == null)
            {
                Settings.Default.lastusers = new MCLauncherLibrary.SerializableStringDictionary();
                Settings.Default.Save();
            }
            InitializeComponent();
            rememberBox.Checked = Settings.Default.remember;
            this.AcceptButton = loginButton;
            foreach (String key in Settings.Default.lastusers.Keys)
            {
                userNameBox.AutoCompleteCustomSource.Add(key);
                userNameBox.Items.Add(key);
            }
            if (userNameBox.Items.Contains(Settings.Default.username))
            {
                userNameBox.SelectedItem = Settings.Default.username;
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
            SetStatusTextInThread(Util.langNode("loggingin"));
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
                    ShowErrorInThread(Util.langNode("cantconnectmcnet"));
                    return;
                }
                worker.ReportProgress(30);
                if (!result.Contains(":"))
                {
                    Boolean debug = false;
                    if (Debugger.IsAttached)
                    {
                        if (MessageBox.Show("Login Failed. Do you want to play offline?", "Login Failed", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            debug = true;
                            result = "123:123:Player:123:123:123:123";
                        }
                    }
                    if (!debug)
                    {
                        if (result.Trim().Equals("Bad login"))
                        {
                            ShowErrorInThread(Util.langNode("loginfailed"));
                        }
                        else if (result.Trim().Equals("Old version"))
                        {
                            ShowErrorInThread(Util.langNode("outdatedlauncher"));
                        }
                        else
                        {
                            ShowErrorInThread(result);
                        }
                        return;
                    }
                }
                worker.ReportProgress(40);

                SetStatusTextInThread(Util.langNode("processinglogin"));
                worker.ReportProgress(50);
                String[] values = result.Split(new Char[] { ':' });
                Settings.Default.remember = rememberBox.Checked;
                if (Settings.Default.lastusers.ContainsKey(userName))
                {
                    Settings.Default.lastusers.Remove(userName);
                }
                if (rememberBox.Checked)
                {
                    Settings.Default.username = userName;
                    Settings.Default.lastusers.Add(userName, Crypto.EncryptStringAES(password, Environment.UserName + "isashark"));
                }
                else
                {
                    if (Settings.Default.username == userName)
                    {
                        Settings.Default.username = "";
                    }
                }
                Settings.Default.Save();
                mf.userName = values[2];
                mf.sessionId = values[3];
                mf.response = result;
                SetStatusTextInThread(Util.langNode("showingmainframe"));
                worker.ReportProgress(100);
                this.BeginInvoke(new MethodInvoker(Close));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                ShowErrorInThread(e.Message);
            }
        }
        private static Boolean hasError = false;
        private void ShowErrorInThread(String error)
        {

            SetTextCallback callback = new SetTextCallback(ShowError);
            this.Invoke(callback, new object[] { error });
        }
        private void ShowError(String error)
        {
            hasError = true;
            Console.WriteLine("Error: " + error);
            SetStatusTextInThread(Util.langNode("error") + ": " + error);
            MessageBox.Show(this, error, Util.langNode("error"), MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
        }

        private void loginWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            string username = "";
            this.Invoke((MethodInvoker)delegate()
            {
                username = userNameBox.Text;
            });
            login(username, passwordBox.Text, worker);

        }
        private void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if ((e.Cancelled == true))
            {
                Console.WriteLine("Cancelled!");
                statusText.Text = Util.langNode("cancelled");
                progressBar1.Value = 0;
            }

            else if (!(e.Error == null))
            {
                Console.WriteLine("Error: " + e.Error.Message);
                statusText.Text = Util.langNode("error") + ": " + e.Error.Message;
                progressBar1.Value = 0;
            }

            else
            {
                if (!hasError)
                {
                    Console.WriteLine("Done!");
                    statusText.Text = Util.langNode("done");
                }
                progressBar1.Value = 0;
            }
            loginButton.Enabled = true;
        }
        private void bw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if(progressBar1 != null)
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

        private void userNameBox_SelectedValueChanged(object sender, EventArgs e)
        {
            if (Settings.Default.lastusers.ContainsKey(userNameBox.Text))
            {
                String cryptedPass = Settings.Default.lastusers[userNameBox.Text];
                if (cryptedPass.Length > 0)
                {
                    try
                    {
                        this.passwordBox.Text = Crypto.DecryptStringAES(cryptedPass, Environment.UserName + "isashark");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Could not decrypt the password: " + ex.Message);
                    }
                }
            }
            else
            {
                this.passwordBox.Text = "";
            }
        }


    }

}