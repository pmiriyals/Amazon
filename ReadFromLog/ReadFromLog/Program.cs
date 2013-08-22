using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Net;

namespace ReadFromLog
{
    public class LogFile
    {
        public string path { get; set; }
        private const string defaultpath = @"C:\Praneeth\C#\Amazon\SpellChecker\log.txt";
        public string url = "http://www.careercup.com/page?pid=amazon-interview-questions&topic=hash-table-interview-questions";

        public LogFile() : this("") { }
        public LogFile(string path)
        {
            this.path = path;
        }

        public void WriteToLog()
        {
            using (StreamWriter sw = new StreamWriter(path == "" ? defaultpath : path))
            {
                using (StreamReader sr = new StreamReader(WebRequest.Create(url).GetResponse().GetResponseStream()))
                {
                    sw.Write(sr.ReadToEnd());
                }
            }

        }

        public void ReadFromLog()
        {
            int count = 0;
            using (StreamReader sr = new StreamReader(path == "" ? defaultpath : path))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    if (line.Contains("United States"))
                        count++;
                }
            }
            Console.WriteLine("{0} questions in US", count);
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            LogFile log = new LogFile();
            log.WriteToLog();
            log.ReadFromLog();
            Console.ReadLine();

        }
    }
}
