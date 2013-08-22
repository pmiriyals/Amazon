using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParseUnixPath
{
    class Program
    {
        static void Parse(string path)
        {
            string[] tokens = path.Split('\\');
            Stack<string> stk = new Stack<string>();

            foreach(string s in tokens)
            {
                switch(s)
                {
                    case ".": 
                        break;
                    case "..":
                        if(stk.Count > 0)
                            stk.Pop();
                        break;
                    default:
                        stk.Push(s);
                        break;
                }
            }

            string txt = "";
            while(stk.Count > 0)
            {
                txt = stk.Pop() + "\\" + txt;
            }
            Console.WriteLine(txt);
        }

        static void Main(string[] args)
        {
            string path = @"$\abc\.\def\..\.\.\hix";
            Parse(path);
            Console.ReadLine();
        }
    }
}
