using System;
using System.Linq;

namespace Indexer
{
    class Program
    {
        static void Main(string[] args)
        {

            int lowIndex = -10;
            int highIndex = 0;

            Array<int> arr = new Array<int>(lowIndex, highIndex);

            for (int i = lowIndex; i < highIndex; i++)
            {
                arr.Add(i);
            }

            arr.Show();

            arr.Remove(-5);

            Console.WriteLine(" ");

            foreach (var item in arr)
            {
                Console.WriteLine(item);
            }


            Console.WriteLine("Number at -5 index is " + arr[-5]);


        }
    }
}
