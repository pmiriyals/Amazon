using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace BankAccountTransferMultiThreading
{
    class SimulationProperties
    {
        public static int NumberOfAccounts = 10;
        public static int NumberOfThreads = 5;
        public static int SimulationLength = 10000;
        public static int MIN_TRANSFER_AMT = 25;
        public static int MAX_TRANSFER_AMT = 500;
        public static decimal INITIAL_AMT = 1000;
        public static int ThreadSleep = 100;
    }
    
    class Simulator
    {
        static BankAccount[] accounts = new BankAccount[SimulationProperties.NumberOfAccounts];
        static bool IsSimulationOver = false;

        public static void driver()
        {
            

            for (int i = 1; i <= accounts.Length; i++)
            {
                accounts[i-1] = new BankAccount(i, SimulationProperties.INITIAL_AMT);
            }

            Thread[] threads = new Thread[SimulationProperties.NumberOfThreads];
            ThreadStart threadProc = new ThreadStart(Simulate);
            for (int i = 1; i <= threads.Length; i++)
            {
                threads[i - 1] = new Thread(threadProc);
                threads[i - 1].Name = String.Format("TX-{0}", i);
                threads[i - 1].Start();
            }

            Thread.Sleep(SimulationProperties.SimulationLength);
            IsSimulationOver = true;

            for (int i = 0; i < threads.Length; i++)
            {
                threads[i].Join();
            }
            VerifyAccoutns();
        }

        public static int GetRandomAcctIndex()
        {
            Random r = new Random();
            return r.Next(0, SimulationProperties.NumberOfThreads);
        }

        public static decimal GetRandomAmt()
        {
            Random r = new Random();
            return (decimal)r.Next(SimulationProperties.MIN_TRANSFER_AMT, SimulationProperties.MAX_TRANSFER_AMT + 1);
        }

        public static bool VerifyAccoutns()
        { 
            decimal sum = 0.0m;
            for (int i = 0; i < accounts.Length; i++)
                sum += accounts[i].Amt;
            Console.WriteLine("Total money before simulation = {0}", accounts.Length * SimulationProperties.INITIAL_AMT);
            Console.WriteLine("Total money after simulation = {0}", sum);
            if (sum == (accounts.Length * SimulationProperties.INITIAL_AMT))
            {
                Console.WriteLine("No errors. All valid transfers");
                return true;
            }
            else
            {
                Console.WriteLine("Inconsistent transfer.");
                return false;
            }
        }

        public static void Simulate()
        {
            while (!IsSimulationOver)
            {

                int debitAcct = GetRandomAcctIndex();
                int creditAcct = GetRandomAcctIndex();

                while (debitAcct == creditAcct)
                {
                    creditAcct = GetRandomAcctIndex();
                }

                decimal amt = GetRandomAmt();

                accounts[creditAcct].Transfer(accounts[debitAcct], amt);
                Thread.Sleep(SimulationProperties.ThreadSleep);
            }
        }
        
    }
}
