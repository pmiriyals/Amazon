using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace SpellChecker
{
    class Program
    {
        static void driverTrie()
        {
            string path = @"C:\Praneeth\C#\TestSampleFiles\trie.txt";
            List<string> words = new List<string>();

            using (StreamReader sr = new StreamReader(path))
            {
                string word;
                while ((word = sr.ReadLine()) != null)
                {
                    words.Add(word);
                }
            }

            TrieDataStructure trie = new TrieDataStructure(words);

            Console.WriteLine("Is prefix = {0}", trie.validatePrefix("olivi"));
            trie.T9Dictionary("olivarty");
        }
        
        static void Main(string[] args)
        {
            //DictionaryBase dict = DictionaryBase.getInstance();
            //dict.WriteDictionaryToFile();
            driverTrie();
            Console.ReadLine();
        }
    }
}
