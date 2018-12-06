using MemoryList.Library;
using System;

namespace MemoryListUser
{
    class Program
    {
        static void Main(string[] args)
        {
            MemoryList<int> doesThisWork = new MemoryList<int>();

            doesThisWork.Add(5);
            doesThisWork.Add(12);
            doesThisWork.Add(7);
            doesThisWork.Remove(5);

            //Console.WriteLine(doesThisWork[1]);
            Console.WriteLine("list:");
            foreach(var item in doesThisWork)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
            Console.WriteLine("_memory:");
            foreach(var item in doesThisWork.Memory())
            {
                Console.WriteLine(item);
            }
        }
    }
}
