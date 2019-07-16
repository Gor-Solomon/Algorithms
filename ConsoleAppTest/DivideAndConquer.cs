using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppTest
{
    class DivideAndConquer
    {
        public int[] GetRandomArray(int s, int min = int.MinValue, int max = int.MaxValue)
        {
            int[] arr = new int[s];
            Random random = new Random();

            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = random.Next();
            }

            return arr;
        }

        public void QuickSort(int[] array)
        {
            void quickSort(int[] arr, int left, int right)
            {
                if (left < right)
                {

                    int il = left;
                    int ir = right;
                    int pivot = arr[left];

                    for (; il < ir; il++)
                    {
                        if (arr[il] > pivot && arr[il] != arr[ir])
                        {
                            var temp = arr[ir];
                            arr[ir] = arr[il];
                            arr[il] = temp;
                            ir--;
                        }
                    }

                    if (ir > 1)
                    {
                        quickSort(arr, left, ir - 1);
                    }

                    if (ir + 1 < right)
                    {
                        quickSort(arr, ir + 1, right);
                    }
                }
            }

            quickSort(array, 0, array.Length - 1);
        }

        internal void CheckArraySorted(int[] arr)
        {
            for (int i = 0; i < arr.Length - 1; i++)
            {
                if (arr[i] > arr[i + 1])
                {
                    Console.WriteLine("Error!");
                    return;
                }
            }

            Console.WriteLine("E.I.O");
        }

        public  void Quick_Sort(int[] array, int left, int right)
        {
            //  http://csharpexamples.com/c-quick-sort-algorithm-implementation/

            void QuickSort(int[] arr, int start, int end)
            {
                int i;
                if (start < end)
                {
                    i = Partition(arr, start, end);

                    QuickSort(arr, start, i - 1);
                    QuickSort(arr, i + 1, end);
                }
            }

             int Partition(int[] arr, int start, int end)
            {
                int temp;
                int p = arr[end];
                int i = start - 1;

                for (int j = start; j <= end - 1; j++)
                {
                    if (arr[j] <= p)
                    {
                        i++;
                        temp = arr[i];
                        arr[i] = arr[j];
                        arr[j] = temp;
                    }
                }

                temp = arr[i + 1];
                arr[i + 1] = arr[end];
                arr[end] = temp;
                return i + 1;
            }

            QuickSort(array, 0, array.Length - 1);
        }

    
    }
}
