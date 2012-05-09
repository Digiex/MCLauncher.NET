using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Globalization;
using System.Windows.Forms;
using System.Drawing;

namespace MCLauncher.net
{
    class Util
    {
        public enum OS
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
        public static OS getPlatform()
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

        public static String getWorkingDirectory()
        {
            if (workDir == null)
            {
                workDir = getWorkingDirectory("minecraft");
            }
            createSubdirs(workDir);
            return workDir;
        }

        public static String getWorkingDirectory(String applicationName)
        {
            String userHome = Environment.GetEnvironmentVariable("home");
            String workingDirectory;
            switch (getPlatform())
            {
                case OS.linux:
                case OS.solaris:
                    workingDirectory = userHome + Path.DirectorySeparatorChar + "." + applicationName;
                    break;
                case OS.windows:
                    String applicationData = Environment.GetEnvironmentVariable("appdata");
                    if (applicationData != null)
                    {
                        workingDirectory = applicationData + Path.DirectorySeparatorChar + "." + applicationName;
                    }
                    else
                    {
                        workingDirectory = userHome + Path.DirectorySeparatorChar + "." + applicationName;
                    }
                    break;
                case OS.macos:
                    workingDirectory = userHome + Path.DirectorySeparatorChar + "Library" + Path.DirectorySeparatorChar + "Application Support" + Path.DirectorySeparatorChar + applicationName;
                    break;
                default:
                    workingDirectory = userHome + Path.DirectorySeparatorChar + applicationName;
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
            if (!Directory.Exists(dir + Path.DirectorySeparatorChar + "bin"))
            {
                try
                {
                    Directory.CreateDirectory(dir + Path.DirectorySeparatorChar + "bin");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Bin directory " + dir + Path.DirectorySeparatorChar + "bin cannot be created!");
                    Console.WriteLine(ex.StackTrace);
                    return;
                }
            }
            if (!Directory.Exists(dir + Path.DirectorySeparatorChar + "bin" + Path.DirectorySeparatorChar + "natives"))
            {
                try
                {
                    Directory.CreateDirectory(dir + Path.DirectorySeparatorChar + "bin" + Path.DirectorySeparatorChar + "natives");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Natives directory " + dir + Path.DirectorySeparatorChar + "bin" + Path.DirectorySeparatorChar + "natives cannot be created!");
                    Console.WriteLine(ex.StackTrace);
                    return;
                }
            }
        }

        public static string GetJavaExecutableName()
        {
            switch (getPlatform())
            {
                case OS.windows:
                    return "javaw.exe";
                default:
                    return "java";
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
                javaExec = GetFullPath(GetJavaExecutableName());
                if (File.Exists(javaExec))
                {
                    return javaExec;
                }
                string environmentPath = Environment.GetEnvironmentVariable("JAVA_HOME");
                if (!string.IsNullOrEmpty(environmentPath))
                {
                    javaExec = environmentPath + Path.DirectorySeparatorChar + "bin" + Path.DirectorySeparatorChar + GetJavaExecutableName();
                    if (File.Exists(javaExec))
                    {
                        return javaExec;
                    }
                }
                if (getPlatform() == OS.windows)
                {
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
        public static string langNode(String node)
        {
            String lang = Properties.Settings.Default.lang;
            if (string.IsNullOrEmpty(lang))
            {
                return Properties.Resources.ResourceManager.GetString(node);
            }
            return Properties.Resources.ResourceManager.GetString(node, new CultureInfo(lang));
        }
        public static string BytesToFileSize(int source)
        {
            return BytesToFileSize(Convert.ToInt64(source));
        }

        public static string BytesToFileSize(long source)
        {
            const int byteConversion = 1024;
            double bytes = Convert.ToDouble(source);

            if (bytes >= Math.Pow(byteConversion, 3)) //GB Range
            {
                return string.Concat(Math.Round(bytes / Math.Pow(byteConversion, 3), 2), " " + Util.langNode("GB"));
            }
            else if (bytes >= Math.Pow(byteConversion, 2)) //MB Range
            {
                return string.Concat(Math.Round(bytes / Math.Pow(byteConversion, 2), 2), " " + Util.langNode("MB"));
            }
            else if (bytes >= byteConversion) //KB Range
            {
                return string.Concat(Math.Round(bytes / byteConversion, 2), " " + Util.langNode("KB"));
            }
            else //Bytes
            {
                return string.Concat(bytes, " " + Util.langNode("bytes"));
            }
        }
        public static Image DownloadImage(string _URL)
        {
            Image _tmpImage = null;

            try
            {
                // Open a connection
                System.Net.HttpWebRequest _HttpWebRequest = (System.Net.HttpWebRequest)System.Net.HttpWebRequest.Create(_URL);

                _HttpWebRequest.AllowWriteStreamBuffering = true;

                // You can also specify additional header values like the user agent or the referer: (Optional)
                _HttpWebRequest.UserAgent = "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 5.1)";
                _HttpWebRequest.Referer = "http://www.google.com/";

                // set timeout for 20 seconds (Optional)
                _HttpWebRequest.Timeout = 20000;

                // Request response:
                System.Net.WebResponse _WebResponse = _HttpWebRequest.GetResponse();

                // Open data stream:
                System.IO.Stream _WebStream = _WebResponse.GetResponseStream();

                // convert webstream to image
                _tmpImage = Image.FromStream(_WebStream);

                // Cleanup
                _WebStream.Close();
                _WebResponse.Close();
                _WebStream.Dispose();
            }
            catch (Exception _Exception)
            {
                // Error
                Console.WriteLine("Exception caught in process: {0}", _Exception.ToString());
                return null;
            }

            return _tmpImage;
        }
        public static bool ExistsOnPath(string fileName)
        {
            if (GetFullPath(fileName) != null)
                return true;
            return false;
        }

        public static string GetFullPath(string fileName)
        {
            if (File.Exists(fileName))
                return Path.GetFullPath(fileName);

            var values = Environment.GetEnvironmentVariable("PATH");
            foreach (var path in values.Split(Path.PathSeparator))
            {
                var fullPath = Path.Combine(path, fileName);
                if (File.Exists(fullPath))
                    return fullPath;
            }
            return null;
        }
    }
}
