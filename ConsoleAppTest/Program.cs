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
            //int[] arr = new int[] { 5, 1, 6, 2, 7, 3, 4 };
            //test(arr);
            //Console.WriteLine(string.Join(", " , arr));
            Console.Read();
        }

        static void test(int[] arr)
        {
            int il = 0;
            int ir = arr.Length -1;

            for (var i = 0; i <= (il + ir) / 2; i++)
            {

                int iMin = il + i;
                int iMax = ir - i;

                for (int j = iMin; j <= ir - i; j++)
                {
                    if (arr[j] > arr[iMax])
                    {
                        iMax = j;
                    }

                    if (arr[j] < arr[iMin])
                    {
                        iMin = j;
                    }
                }

                int temp = arr[iMax];
                arr[iMax] = arr[ir - i];
                arr[ir - i] = temp;

                temp = arr[iMin];
                arr[iMin] = arr[il + i];
                arr[il + i] = temp;
            }
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

                int[] arr = divideAndConquer.GetRandomArray(65536); /*new int[] { 1, 6, 1, 3, 9, 7 };*/
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

                //Console.ReadLine();
                System.Threading.Thread.Sleep(100);
                Console.Clear();
                Console.WriteLine(m1);
                Console.WriteLine(m2);

            }
        }
    }
}

