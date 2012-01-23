using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;

namespace MCLauncher.net
{
    class Util
    {
        private enum OS
        {
            linux, solaris, windows, macos, unknown
        }
        public static String workDir;
        public static String excutePost(String targetURL, String urlParameters)
        {
            // create a request
            HttpWebRequest request = (HttpWebRequest)
            WebRequest.Create(targetURL); request.KeepAlive = false;
            request.ProtocolVersion = HttpVersion.Version10;
            request.Method = "POST";

            // turn our request string into a byte stream
            byte[] postBytes = Encoding.ASCII.GetBytes(urlParameters);

            // this is important - make sure you specify type this way
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = postBytes.Length;
            Stream requestStream = request.GetRequestStream();

            // now send it
            requestStream.Write(postBytes, 0, postBytes.Length);
            requestStream.Close();

            // grab te response and print it out to the console along with the status code
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            return new StreamReader(response.GetResponseStream()).ReadToEnd();
        }
        public static String excuteGet(String targetURL, String urlParameters)
        {
            // create a request
            HttpWebRequest request = (HttpWebRequest)
            WebRequest.Create(targetURL + "?" + urlParameters); request.KeepAlive = false;
            request.ProtocolVersion = HttpVersion.Version10;
            request.Method = "GET";

            // turn our request string into a byte stream
            //byte[] postBytes = Encoding.ASCII.GetBytes(urlParameters);

            // this is important - make sure you specify type this way
            request.ContentType = "application/x-www-form-urlencoded";
            //request.ContentLength = postBytes.Length;
            //Stream requestStream = request.GetRequestStream();

            // now send it
            //requestStream.Write(postBytes, 0, postBytes.Length);
            //requestStream.Close();

            // grab te response and print it out to the console along with the status code
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            return new StreamReader(response.GetResponseStream()).ReadToEnd();
        }
        /**
          * Checks the operating system
          * 
         * @return OS (enum)
          */
        private static OS getPlatform()
        {
            System.OperatingSystem osInfo = System.Environment.OSVersion;
            switch (osInfo.Platform)
            {
                case PlatformID.Win32NT:
                case PlatformID.Win32S:
                case PlatformID.Win32Windows:
                    return OS.windows;
                case PlatformID.MacOSX:
                    return OS.macos;
                case PlatformID.Unix:
                    return OS.linux;
                default:
                    return OS.unknown;
            }
        }

        /**
          * Gets the working firectory
          * 
         * @return File working directory
          */
        public static String getWorkingDirectory()
        {
            if (workDir == null)
            {
                workDir = getWorkingDirectory("minecraft");
            }
            createSubdirs(workDir);
            return workDir;
        }

        /**
          * Gets the default working directory
          * 
         * @param applicationName
          *            Always "minecraft" for this app
          * @return File working directory
          */
        public static String getWorkingDirectory(String applicationName)
        {
            String userHome = Environment.GetEnvironmentVariable("home");
            String workingDirectory;
            switch (getPlatform())
            {
                case OS.linux:
                case OS.solaris:
                    workingDirectory = userHome + "\\." + applicationName;
                    break;
                case OS.windows:
                    String applicationData = Environment.GetEnvironmentVariable("appdata");
                    if (applicationData != null)
                    {
                        workingDirectory = applicationData + "\\." + applicationName;
                    }
                    else
                    {
                        workingDirectory = userHome + "\\." + applicationName;
                    }
                    break;
                case OS.macos:
                    workingDirectory = userHome + "\\Library\\Application Support\\" + applicationName;
                    break;
                default:
                    workingDirectory = userHome + "\\" + applicationName;
                    break;
            }
            createSubdirs(workingDirectory);
            return workingDirectory;
        }
        private static void createSubdirs(string dir)
        {
            if (!Directory.Exists(dir))
            {
                try
                {
                    Directory.CreateDirectory(dir);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Working directory " + dir + " cannot be created!");
                    Console.WriteLine(ex.StackTrace);
                    return;
                }
            }
            if (!Directory.Exists(dir + "\\bin"))
            {
                try
                {
                    Directory.CreateDirectory(dir + "\\bin");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Bin directory " + dir + "\\bin cannot be created!");
                    Console.WriteLine(ex.StackTrace);
                    return;
                }
            }
            if (!Directory.Exists(dir + "\\bin\\natives"))
            {
                try
                {
                    Directory.CreateDirectory(dir + "\\bin\\natives");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Natives directory " + dir + "\\bin\\natives cannot be created!");
                    Console.WriteLine(ex.StackTrace);
                    return;
                }
            }
        }
        public static string GetJavaExecutable()
        {
            try
            {
                String javaExec = Properties.Settings.Default.javaExecutable;
                if (!string.IsNullOrEmpty(javaExec))
                {
                    if (File.Exists(javaExec))
                    {
                        return javaExec;
                    }

                }
                string environmentPath = Environment.GetEnvironmentVariable("JAVA_HOME");
                if (!string.IsNullOrEmpty(environmentPath))
                {
                    javaExec = environmentPath + @"\bin\javaw.exe";
                    if (File.Exists(javaExec))
                    {
                        return javaExec;
                    }
                }

                string javaKey = "SOFTWARE\\JavaSoft\\Java Runtime Environment\\";

                using (Microsoft.Win32.RegistryKey rk = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(javaKey))
                {
                    string currentVersion = rk.GetValue("CurrentVersion").ToString();
                    using (Microsoft.Win32.RegistryKey key = rk.OpenSubKey(currentVersion))
                    {
                        javaExec = key.GetValue("JavaHome").ToString() + @"\bin\javaw.exe";
                        if (File.Exists(javaExec))
                        {
                            return javaExec;
                        }
                    }
                }
            }
            catch (Exception)
            {
                return null;
            }
            return null;
        }
        static public string EncodeTo64(string toEncode)
        {

            byte[] toEncodeAsBytes

                  = System.Text.ASCIIEncoding.ASCII.GetBytes(toEncode);

            string returnValue

                  = System.Convert.ToBase64String(toEncodeAsBytes);

            return returnValue;

        }

    }
}
