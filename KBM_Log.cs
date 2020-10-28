using UnityEngine;
using System.Collections;
using System.IO;
using System;
using System.Text;

namespace KBM
{
    public class Log
    {
        static string directory = @"log";
        static string LogPath = @"log/log.txt";
        //static string directory = @"C:\DebugLog" + "/Log";
        //static string LogPath = @"C:\DebugLog" + "/Log/log.txt";

        public static void log(string logmsg)
        {
            if (!System.IO.Directory.Exists(directory))
            {
                System.IO.Directory.CreateDirectory(directory);
            }

            FileStream fs = null;
            fs = new FileStream(LogPath, FileMode.Append);
            if (fs.Length > 2048000)
            {
                fs.Close();
                fs = new FileStream(LogPath, FileMode.Create, FileAccess.Write);
            }

            StreamWriter writer = new StreamWriter(fs);
            string logfrm = DateTime.Now.ToString("yyyyMMdd hh:mm:ss") + " " + logmsg;
            writer.WriteLine(logfrm);
            writer.Close();
            fs.Close();
        }

        public static string Read()
        {
            StreamReader file = File.OpenText(LogPath);
            bool end = file.EndOfStream;
            string temp = "";
            while (!end)
            {
                temp = file.ReadLine();
                end = file.EndOfStream;
            }
            file.Close();

            return temp;
        }
    }

}