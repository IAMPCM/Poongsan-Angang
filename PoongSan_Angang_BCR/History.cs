using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PoongSan_Angang_BCR
{
    public class History
    {
        public Form1 frm1;
        public Log Log;
        public Log AlarmLog;
        public Log ProcessLog;

        public History(Form1 frm)
        {
            frm1 = frm;
            Log = new Log("Log");
            AlarmLog = new Log("AlarmLog");
            ProcessLog = new Log("ProcessLog");
        }
    }

    public class Log
    {
        // 실행 파일 기준 경로 (Define.HistoryPath 사용 — 하드코딩 없음)
        private string staticPath = "";

        private string logPath = @"@yyyy@MM@dd\@HH.txt";
        public Log(string sLogFolder)
        {
            Initialize(sLogFolder);
        }

        public void Initialize(string sLogFolder)
        {
            // 실행 파일 위치 기준: [exe]\History\{sLogFolder}\
            staticPath = System.IO.Path.Combine(Define.HistoryPath, sLogFolder) + "\\";

            logPath = @"@yyyy@MM@dd\@HH.txt";
            string tmp = string.Empty;

            foreach (string path in staticPath.Split('\\'))
            {
                if (path != string.Empty)
                {
                    tmp += path + "\\";
                }

                if (!Directory.Exists(tmp))
                {
                    Directory.CreateDirectory(tmp);
                }
            }
        }

        public void Add(DateTime dt, string message, [CallerFilePath] string file = "", [CallerMemberName] string method = "", [CallerLineNumber] int num = 0)
        {
            try
            {
                if (dt == null)
                {
                    dt = DateTime.Now;
                }

                string text = string.Empty;
                string time = dt.ToString("HH:mm:ss");
                string File = file.Split('\\').Last();
                string line = "0x" + num.ToString().PadLeft(7, '0');
                string tab = "\t";

                string path = GetPath(dt);

                text = time + tab + File + tab + method + tab + line + tab + message;

                using (StreamWriter logFile = new StreamWriter(path, true, Encoding.Default))
                {
                    logFile.WriteLine(text);
                }

                object item = new object[] { time, File, line, method, message };
            }
            catch
            {
                return;
            }
        }

        private string GetPath(DateTime dt)
        {
            string tmpPath = logPath;

            tmpPath = tmpPath.Replace("@yyyy", dt.ToString("yyyy"));
            tmpPath = tmpPath.Replace("@MM", dt.ToString("MM"));
            tmpPath = tmpPath.Replace("@dd", dt.ToString("dd"));
            tmpPath = tmpPath.Replace("@HH", dt.ToString("HH"));

            while (tmpPath.Contains("\\\\"))
            {
                tmpPath = tmpPath.Replace("\\\\", "\\");
            }

            while (tmpPath.Contains("__"))
            {
                tmpPath = tmpPath.Replace("__", "_");
            }

            string fullPath = string.Empty;
            string[] splitPath = (staticPath + tmpPath).Split('\\');

            for (int i = 0; i < splitPath.Count(); i++)
            {
                fullPath += splitPath[i];

                if (i < splitPath.Count() - 1)
                {
                    fullPath += "\\";

                    if (!Directory.Exists(fullPath))
                    {
                        Directory.CreateDirectory(fullPath);
                    }
                }
            }

            return fullPath;
        }
    }
}
