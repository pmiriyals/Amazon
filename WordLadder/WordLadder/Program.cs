using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.IO;
using System.Net;

namespace WordLadder
{
    class Program
    {
        static void getWords()
        {
            string url = @"http://www.andrew.cmu.edu/course/15-121/dictionary.txt";
            WebRequest wr = WebRequest.Create(url);
            WebResponse resp = wr.GetResponse();
            string path = @"C:\Praneeth\C#\TestSampleFiles\dictionary.txt";
            using (StreamReader sr = new StreamReader(resp.GetResponseStream()))
            {
                string line = "";
                using (StreamWriter sw = new StreamWriter(path))
                {
                    while ((line = sr.ReadLine()) != null)
                    {
                        sw.WriteLine(line);
                        Console.WriteLine(line);
                    }
                }
            }
        }
        
        static void Main(string[] args)
        {
            //getWords();
            //Ladder.driver();
            GraphLadder.driver();
            Console.ReadLine();
        }
    }
}
