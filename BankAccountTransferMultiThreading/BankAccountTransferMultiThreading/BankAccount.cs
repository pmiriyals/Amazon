using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace BankAccountTransferMultiThreading
{
    class BankAccount
    {
        public int acctID { get; set; }
        public decimal Amt { get; set; }
        private Object _lock = new object();
        private Mutex _lockMutex = new Mutex();

        public BankAccount(int acctID, decimal Amt)
        {
            this.acctID = acctID;
            this.Amt = Amt;
        }

        public void Credit(decimal val)
        {
            if (_lockMutex.WaitOne())
            {
                try
                {
                    decimal temp = Amt;
                    temp += val;
                    Thread.Sleep(1);
                    Amt = temp;
                }
                finally
                {
                    _lockMutex.ReleaseMutex();
                }
            }
        }

        public void Debit(decimal val)
        {
            this.Credit(-val);
        }

        public void Transfer(BankAccount otherAcct, decimal money)
        {
            Mutex[] mut = { this._lockMutex, otherAcct._lockMutex};
            Console.WriteLine("{3} Transfer {2:C0} from AccID: {0} to AccID: {1}", otherAcct.acctID, this.acctID, money, Thread.CurrentThread.Name);

            if (WaitHandle.WaitAll(mut)) 
            {
                try
                {
                    Thread.Sleep(100);
                    {
                        otherAcct.Debit(money);
                        this.Credit(money);
                    }
                }
                finally
                {
                    foreach (Mutex m in mut)
                    {
                        m.ReleaseMutex();
                    }
                }
            }
        }

        public void TransferUsingLockOrdering(BankAccount otherAcct, decimal money)
        {
            Object firstlock;
            Object secondlock;
            ChooseLocks(this, otherAcct, out firstlock, out secondlock);
            Console.WriteLine("{3} Transfer {2:C0} from AccID: {0} to AccID: {1}", otherAcct.acctID, this.acctID, money, Thread.CurrentThread.Name);
            lock (firstlock)
            {
                
                Thread.Sleep(100);
                lock (secondlock)
                {
                    otherAcct.Debit(money);
                    this.Credit(money);
                }
            }
        }

        private void ChooseLocks(BankAccount acctOne, BankAccount acctTwo, out object firstlock, out object secondlock)
        {
            if (acctOne.acctID < acctTwo.acctID)
            {
                firstlock = acctOne._lock;
                secondlock = acctTwo._lock;
            }
            else
            {
                firstlock = acctTwo._lock;
                secondlock = acctOne._lock;
            }
        }
    }
}
