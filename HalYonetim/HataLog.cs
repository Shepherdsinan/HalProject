using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading;

namespace HalYonetim
{
    public class HataLog
    {
        private HataLog()
        {

        }

        private static HataLog _instance;

        public static HataLog Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new HataLog();
                return HataLog._instance;
            }
        }

        public string _Path
        {
            get
            {
                return Path.Combine(Environment.CurrentDirectory, "Hata.txt");
            }
        }
        public void HataLogYaz(ThreadExceptionEventArgs exception)
        {
            try
            {
                string filename = _instance._Path + "\\Hata.txt";
                FileMode fm = FileMode.Append;
                if (File.Exists(filename))
                {
                    FileInfo fi = new FileInfo(filename);
                    double a = fi.Length;
                    a = (a / 1024f) / 1024f;
                    if (a > 100000L)
                    {
                        File.Delete(filename);
                    }
                }
                if (!File.Exists(filename))
                    fm = FileMode.Create;
                StringBuilder sb = new StringBuilder();
                FileStream fs = new FileStream(filename, fm);
                sb.Append(DateTime.Now.ToString());
                sb.Append(Environment.NewLine);
                sb.Append("---------------------------------------------------------");
                sb.Append(Environment.NewLine);
                sb.Append(exception.ToString());
                sb.Append(Environment.NewLine);
                sb.Append("---------------------------------------------------------");
                sb.Append(Environment.NewLine);
                string s = sb.ToString();
                Byte[] byt = Encoding.ASCII.GetBytes(s);
                fs.Write(byt, 0, byt.Length);
                fs.Close();

            }
            catch
            {
            }
        }
        public void HataLogYaz(Exception exception)
        {
            try
            {
                string filename = _instance._Path;
                FileMode fm = FileMode.Append;
                if (File.Exists(filename))
                {
                    FileInfo fi = new FileInfo(filename);
                    double a = fi.Length;
                    a = (a / 1024f) / 1024f;
                    if (a > 100000L)
                    {
                        File.Delete(filename);
                    }
                }
                if (!File.Exists(filename))
                    fm = FileMode.Create;
                StringBuilder sb = new StringBuilder();
                FileStream fs = new FileStream(filename, fm);
                sb.Append(DateTime.Now.ToString());
                sb.Append(Environment.NewLine);
                sb.Append("---------------------------------------------------------");
                sb.Append(Environment.NewLine);
                sb.Append(exception.ToString());
                sb.Append(Environment.NewLine);
                sb.Append("---------------------------------------------------------");
                sb.Append(Environment.NewLine);
                string s = sb.ToString();
                Byte[] byt = Encoding.ASCII.GetBytes(s);
                fs.Write(byt, 0, byt.Length);
                fs.Close();

            }
            catch
            {
            }
        }
        public void HataLogYaz(Exception exception, string extramesaj)
        {
            try
            {

                FileMode fm = FileMode.Append;

                if (!File.Exists(_Path))
                    fm = FileMode.Create;
                StringBuilder sb = new StringBuilder();
                FileStream fs = new FileStream(_Path, fm);
                sb.Append(DateTime.Now.ToString());
                sb.Append(Environment.NewLine);
                sb.Append("---------------------------------------------------------");
                sb.Append(Environment.NewLine);
                sb.Append(exception.ToString());
                sb.Append(Environment.NewLine);
                sb.Append(extramesaj + Environment.NewLine);
                sb.Append("---------------------------------------------------------");
                sb.Append(Environment.NewLine);
                string s = sb.ToString();
                Byte[] byt = Encoding.ASCII.GetBytes(s);
                fs.Write(byt, 0, byt.Length);
                fs.Close();

            }
            catch
            {
            }
        }

        public void HataLogYaz(string extramesaj)
        {
            try
            {

                FileMode fm = FileMode.Append;

                if (!File.Exists(_Path))
                    fm = FileMode.Create;
                StringBuilder sb = new StringBuilder();
                FileStream fs = new FileStream(_Path, fm);
                sb.Append(DateTime.Now.ToString());
                sb.Append(Environment.NewLine);
                sb.Append("---------------------------------------------------------");
                sb.Append(Environment.NewLine);
                sb.Append(extramesaj + Environment.NewLine);
                sb.Append("---------------------------------------------------------");
                sb.Append(Environment.NewLine);
                string s = sb.ToString();
                Byte[] byt = Encoding.ASCII.GetBytes(s);
                fs.Write(byt, 0, byt.Length);
                fs.Close();

            }
            catch
            {
            }
        }
    }
}
