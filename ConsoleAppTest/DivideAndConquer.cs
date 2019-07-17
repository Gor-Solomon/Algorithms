using System;

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
                    int pivot = arr[(left + right) / 2];

                    while (true)
                    {
                        while (arr[il] < pivot) il++;

                        while (arr[ir] > pivot) ir--;

                        if (il >= ir)
                        {
                            break;
                        }

                        var temp = arr[ir];
                        arr[ir] = arr[il];
                        arr[il] = temp;

                        il++;
                        ir--;
                    }

                    if (left < ir)
                    {
                        quickSort(arr, left, ir);
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

    }
}
