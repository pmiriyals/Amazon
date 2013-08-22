using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Net;
using System.IO;

namespace SpellChecker
{
    public sealed class DictionaryBase
    {
        private static volatile DictionaryBase dbInstance = null;
        private static Object syncRoot = new Object();
        private HashSet<string> dict = new HashSet<string>();
        private string url = @"http://andrew.cmu.edu/course/15-121/dictionary.txt";

        private DictionaryBase()
        {
            buildDictionary();
        }

        private void buildDictionary()
        {
            WebRequest req = WebRequest.Create(url);
            WebResponse resp = req.GetResponse();
            Stream data = resp.GetResponseStream();

            using (StreamReader sr = new StreamReader(data))
            {
                string txt;
                while ((txt = sr.ReadLine()) != null)
                {
                    if (!dict.Contains(txt))
                        dict.Add(txt);
                }
            }
        }

        public static DictionaryBase getInstance()
        {
            if (dbInstance == null)
            {
                lock (syncRoot)
                {
                    if (dbInstance == null)
                        dbInstance = new DictionaryBase();
                }
            }
            return dbInstance;
        }

        public bool hasWord(string word)
        {
            return dict.Contains(word);
        }

        public void WriteDictionaryToFile()
        {
            string path = @"C:\Praneeth\C#\TestSampleFiles\dictionary.txt";

            using (StreamWriter sw = new StreamWriter(path))
            {
                foreach (string s in dict)
                    sw.WriteLine(s);
            }
        }
    }
}
