using ConsoleAppTest;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

class Solution
{
    class Editor
    {
        static void Main(String[] args)
        {
            quickSortBootLoader();
            Console.Read();
        }

        static void quickSortBootLoader()
        {
            DivideAndConquer divideAndConquer = new DivideAndConquer();

            List<long> ma = null;
            List<long> ca = new List<long>();
            string m1 = null; string m2 = null;

            while (true)
            {
                var watch = new Stopwatch();

                int[] arr = divideAndConquer.GetRandomArray(1500000); /*new int[] { 1, 6, 1, 3, 9, 7 };*/
                int[] arr2 = new int[arr.Length]; arr.CopyTo(arr2, 0);

                watch.Start();
                divideAndConquer.QuickSort(arr);
                watch.Stop();

                if (ma is null)
                {
                    ma = new List<long>();
                }
                else
                {
                    ma.Add(watch.ElapsedTicks);
                    m1 = string.Format("Current Implementation Time : {0}, average time {1}", watch.ElapsedTicks, ma.Average());
                    m1 += "\n" + divideAndConquer.CheckArraySorted(arr);
                }

                watch = new Stopwatch();
                watch.Start();
                Array.Sort(arr2);
                watch.Stop();

                ca.Add(watch.ElapsedTicks);
                m2 = string.Format("C# Time : {0}, average time {1}", watch.ElapsedTicks, ca.Average());

                Console.Clear();
                Console.WriteLine(m1);
                Console.WriteLine(m2);

            }
        }
    }
}

