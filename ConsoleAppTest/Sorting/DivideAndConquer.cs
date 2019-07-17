using System;
using System.Linq;

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
                arr[i] = random.Next(min, max);
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

        public void InsertionSort(int[] array)
        {
            for (int i = 1; i < array.Length; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (array[j] > array[i])
                    {
                        var temp = array[j];
                        array[j] = array[i];
                        array[i] = temp;
                    }
                }
            }
        }

        public void BubbleSort(int[] arr)
        {
            for (int j = 0; j <= arr.Length - 2; j++)
            {
                for (int i = 0; i <= arr.Length - 2; i++)
                {
                    if (arr[i] > arr[i + 1])
                    {
                        var temp = arr[i + 1];
                        arr[i + 1] = arr[i];
                        arr[i] = temp;
                    }
                }
            }
        }

        public string CheckArraySorted(int[] arr)
        {
            for (int i = 0; i < arr.Length - 1; i++)
            {
                if (arr[i] > arr[i + 1])
                {
                    return "ERROR!";
                }
            }

            return "E.I.O!";
        }

        public int FindMax(int[] array)
        {
            int result = 0;

            int findMax(int[] arr, int l, int h)
            {
                if (h - l == 0)
                {
                    return arr[h];
                }

                if (h - l == 1)
                {
                    return Math.Max(arr[h], arr[l]); /* arr[h];*/
                }

                int half = (h + l) / 2;

                return Math.Max(findMax(arr, l, half), findMax(arr, half + 1, h));
            }

            if (array is null)
            {
                throw new ArgumentNullException(nameof(array));
            }

            if (!array.Any())
            {
                throw new ArgumentException("Array is empty.");
            }

            if (array.Length == 1)
            {
                result = array[0];
            }
            else
            {
                result = findMax(array, 0, array.Length - 1);
            }

            return result;
        }

        public int[] SelectionSort(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                int minIndex = i;

                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[minIndex] > arr[j])
                    {
                        minIndex = j;
                    }
                }

                if (minIndex != i)
                {
                    var temp = arr[i];
                    arr[i] = arr[minIndex];
                    arr[minIndex] = temp;
                }
            }

            return arr;
        }

    }
}
