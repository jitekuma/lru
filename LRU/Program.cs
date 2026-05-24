using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LRU
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the cache size: ");
            int size = int.Parse(Console.ReadLine());
            LRU<int> lru = new LRU<int>(size);
            int currentnumber;
            do
            {
                string input = Console.ReadLine();
                if (int.TryParse(input, out currentnumber))
                {
                    lru.Add(currentnumber);
                }
                else if(string.Equals(input, "print", StringComparison.OrdinalIgnoreCase))
                {
                    IList<int> currentValues = lru.GetItems();
                    foreach(int val in currentValues)
                    {
                        Console.Write($"{val} ");
                    }
                    Console.WriteLine();
                }
                else
                {
                    break;
                }
            } while (true);
        }
    }
}
