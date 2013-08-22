using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace WordLadder
{
    class DictionaryWords
    {
        private static Dictionary<string, bool> dict = new Dictionary<string, bool>();
        public static volatile DictionaryWords dw = null;
        private string path = @"C:\Praneeth\C#\TestSampleFiles\dictionary.txt";
        private static Object syncRoot = new Object();

        private DictionaryWords(int len)
        {
            using (StreamReader sr = new StreamReader(path))
            {
                string line = "";
                while ((line = sr.ReadLine()) != null)
                {                    
                    if(line.Length == len)
                        dict.Add(line.ToLower(), false);
                }
            }
        }

        public static DictionaryWords getInstance(int length)
        {
            if (dw == null)
            {
                lock (syncRoot)
                {
                    if (dw == null)
                    {
                        dw = new DictionaryWords(length);
                    }
                }
            }
            return dw;
        }

        public Dictionary<string, bool> getDict()
        {
            return dict;
        }

    }
}
