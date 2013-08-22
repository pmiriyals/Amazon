using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PrintMostFreqIntTillCurIndex
{
    class Program
    {
        //1. Using a dictionary
        //2. Bitvector will not track freq count, hence not useful
        //3. We need to track freq of each element and compare against maxFreqTillHere
        //4. To do that we can use a dictionary or create a struct/class with data and freq fields in it and place it in max heap
        //by freq, that will takes O(n) time and more space if we use dictionary or more time, hence this approach is inefficient
        //5. Thus tracking frequency through dictionary is the only approach that makes sense and can be done in O(n)
        
        //Time: O(n), Space: O(n)
        static void printMostFreq(int[] arr)
        {
            Dictionary<int, int> dict = new Dictionary<int, int>();
            int max = 1;
            int num = arr[0];
            dict.Add(arr[0], 1);
            for (int i = 1; i < arr.Length; i++)
            {
                if (dict.ContainsKey(arr[i]))
                {
                    dict[arr[i]] += 1;
                    if (dict[arr[i]] > max)
                    {
                        max = dict[arr[i]];
                        num = arr[i];
                    }
                }
                else
                    dict.Add(arr[i], 1);
                Console.WriteLine("{0} --> {1} ", arr[i], num);
            }
        }

        static void Main(string[] args)
        {
            int[] arr = { 1, 5, 2, 3, 1, 6, 1, 3, 4, 3, 3, 3, 1, 2, 9};
            printMostFreq(arr);
            Console.ReadLine();
        }
    }
}
