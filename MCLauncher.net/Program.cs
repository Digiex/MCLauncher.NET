using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace MCLauncher.net
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Add the event handler for handling UI thread exceptions to the event.
            Application.ThreadException += new ThreadExceptionEventHandler(Application_ThreadException);

            // Set the unhandled exception mode to force all Windows Forms errors to go through
            // our handler.
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);

            // Add the event handler for handling non-UI thread exceptions to the event. 
            AppDomain.CurrentDomain.UnhandledException +=
                new UnhandledExceptionEventHandler(Application_UnhandledException);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
        // Handle the UI exceptions by showing a dialog box, and asking the user whether
        // or not they wish to abort execution.
        private static void Application_ThreadException(object sender, ThreadExceptionEventArgs t)
        {
            try
            {
                reportError(t.Exception);
            }
            catch (Exception) { }
            DialogResult result = DialogResult.Cancel;
            try
            {
                result = ShowThreadExceptionDialog("Windows Forms Error", t.Exception);
            }
            catch
            {
                try
                {
                    MessageBox.Show("Fatal Windows Forms Error",
                        "Fatal Windows Forms Error", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Stop);
                }
                finally
                {
                    Application.Exit();
                }
            }

            // Exits the program when the user clicks Abort.
            if (result == DialogResult.Abort)
                Application.Exit();
        }

        // Handle the UI exceptions by showing a dialog box, and asking the user whether
        // or not they wish to abort execution.
        // NOTE: This exception cannot be kept from terminating the application - it can only 
        // log the event, and inform the user about it. 
        private static void Application_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            try
            {
                reportError((Exception)e.ExceptionObject);
            }
            catch (Exception) { }
            try
            {
                Exception ex = (Exception)e.ExceptionObject;
                string errorMsg = "An fatal application error occurred. Please contact jessenic at digiex.net " +
                    "with the following information:\n\n";
                errorMsg = errorMsg + ex.Message + "\n\nStack Trace:\n" + ex.StackTrace;
                MessageBox.Show(errorMsg, "Fatal error", MessageBoxButtons.OK,
                    MessageBoxIcon.Stop);
                // Since we can't prevent the app from terminating, log this to the event log.
                //if (!EventLog.SourceExists("ThreadException"))
                {
                //    EventLog.CreateEventSource("ThreadException", "Application");
                }

                // Create an EventLog instance and assign its source.
                //EventLog myLog = new EventLog();
                //myLog.Source = "ThreadException";
                //myLog.WriteEntry(errorMsg + ex.Message + "\n\nStack Trace:\n" + ex.StackTrace);
            }
            catch (Exception exc)
            {
                try
                {
                    MessageBox.Show(
                        "Fatal Non-UI Error. Could not show the information messagebox. Reason: "
                        + exc.Message, "Fatal Non-UI Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                finally
                {
                    Application.Exit();
                }
            }
        }


        public static void reportError(Exception ex)
        {
            Thread oThread = new Thread(new ParameterizedThreadStart(reportErrorThread));
            oThread.Start(ex);
            
        }
        public static void reportErrorThread(object e)
        {
            Exception ex = (Exception)e;
            String response = Util.excutePost("http://minecraft.digiex.org/errorreport.php", "version="+ System.Reflection.Assembly.GetEntryAssembly().GetName().Version.ToString() +"&stacktrace=" + Util.EncodeTo64(ex.StackTrace) + "&message=" + Util.EncodeTo64(ex.Message));
            System.Console.WriteLine(response);
        }
        // Creates the error message and displays it.
        private static DialogResult ShowThreadExceptionDialog(string title, Exception e)
        {
            string errorMsg = "An application error occurred. Please contact jessenic at digiex.net " +
                "with the following information:\n\n";
            errorMsg = errorMsg + e.Message + "\n\nStack Trace:\n" + e.StackTrace;
            return MessageBox.Show(errorMsg, title, MessageBoxButtons.AbortRetryIgnore,
                MessageBoxIcon.Stop);
        }

    }
}
