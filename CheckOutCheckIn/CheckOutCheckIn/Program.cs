using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CheckOutCheckIn
{
    //1. Maintaining 1 big heap is inefficient
    //2. Maintain a dictionary with values as a linked list
    //3. If no items checked in, return next and increment it. O(1)
    //4. If dictionary count > 0, then return key at head and remove KV from dict, O(1)
    //5. Checkin: add K if not present, do insertion sort for values (linked list), O(n): number of items currently checked in
    //6. Hence Checkout is always O(1) operation
    //7. Checkin worst case is O(n), where n is the number of values currently checked in (linear time)
    
    class NumberPool
    {
        private long max;
        byte[] pool;
        private long next;
        private List<long> heap = new List<long>();

        public NumberPool(long max = long.MaxValue)
        {
            this.max = max;            
            pool = new byte[long.MaxValue];
            next = 0;
        }
        
        public long CheckOut()
        {            
            long cur;
            if (heap.Count == 0)
            {
                pool[next] = 1;
                cur = next;
                next++;
            }
            return cur;
        }

        public void Checkin(long val)
        {

        }
    }
    
    class Program
    {   
        static void Main(string[] args)
        {
            Console.WriteLine(long.MaxValue);
            Console.ReadLine();
        }
    }
}
