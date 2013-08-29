using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BankAccountTransferMultiThreading
{
    class Program
    {
        static void Main(string[] args)
        {
            Simulator.driver();
            Console.ReadLine();
        }
    }
}
