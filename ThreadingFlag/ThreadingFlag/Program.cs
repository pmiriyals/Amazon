using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ThreadingFlag
{
    class Program
    {
        //Thread exits, static variable belongs to the class and shared by both Main and the new thread
        static bool IsStop = false;
        
        static void Main(string[] args)
        {
            Program prog = new Program();
            Thread t = new Thread(new ThreadStart(prog.ThreadProc));
            t.Name = "Test";
            t.Start();
            Thread.Sleep(1000);
            IsStop = true;
            t.Join();
            Console.WriteLine("This is Main thread exiting");
            Console.ReadLine();
        }

        void ThreadProc()
        {
            int cnt = 0;
            while (!IsStop)
                Console.WriteLine("Thread {0} running: {1}", Thread.CurrentThread.Name, cnt++);
        }
    }
}
