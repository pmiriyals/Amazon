using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SortMillionIntegers
{
    //Sort 100 million 10-bit integers (use count sort)

    //If we are given only bits for each number and asked to find the missing number between 1 to n, then check the LSB, if count(1) >= count(0) then the missing LSB is 0, else its 1. Recursively check for each bit.
    // findMissing(arr, column) << 1 | (0 if 0 is missing or 1 if 1 is missing);

    //Find duplicates between 1 to n, we can use bit vector and set each bit corresponding to a number. For 1 to 32000, declare array of arr[1000], each integer is 4 bytes that is 32 bits, so we can represent 
    // each bit to a corresponding number. Thus if we find a bit already set then we found a duplicate.

    //Find duplicates between 1 to n, use an array and set a[a[0]] to negative value. If an element at an index is already negative then we found a duplicate.
        
    class Program
    {
        static void ToDecimal(int n, int b)
        {
            int val = 0;
            int x;

            while (n > 0)
            {
                x = n % 10;
                val = (val * b) + x;
                n /= 10;
            }
            Console.WriteLine(val);
        }
        
        static void Main(string[] args)
        {
            ToDecimal(1111111111, 2);
            Console.ReadLine();
        }
    }
}
