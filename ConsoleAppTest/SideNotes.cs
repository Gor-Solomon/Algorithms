//using System;
//using System.Reflection;
//using System.Linq;
//using System.Collections;
//using System.Collections.Generic;
//using System.IO;

//class Program
//{
//    static int hourglassSum(int[][] arr)
//    {
//        int result = int.MinValue;

//        for (int i = 0; i < 4; i++)
//        {
//            for (int j = 0; j < 4; j++)
//            {
//                int temp = arr[i][j] + arr[i][j + 1] + arr[i][j + 2] +
//                                        arr[i + 1][j + 1] +
//                           arr[i + 2][j] + arr[i + 2][j + 1] + arr[i + 2][j + 2];
//                result = temp > result ? temp : result;
//            }
//        }

//        return result;
//    }

//    static int[] rotLeft(int[] a, int d)
//    {
//        int[] arr = new int[a.Length];

//        Array.Copy(a, d, arr, 0, a.Length - d);
//        Array.Copy(a, 0, arr, a.Length - d, a.Length - (a.Length - d));

//        return arr;
//    }

//    // Complete the minimumBribes function below.
//    public static void minimumBribes(int[] q)
//    {
//        int bribe = 0;
//        List<int> result = new List<int>(2);


//        for (int i = 0; i < q.Length; i++)
//        {
//            if (q[i] - (i + 1) > 2)
//            {
//                Console.WriteLine("Too chaotic");
//                return;
//            }
//            for (int j = Math.Max(0, q[i] - 2); j < i; j++)
//            {
//                if (q[j] > q[i])
//                    bribe++;
//            }
//        }

//        Console.WriteLine(bribe);
//    }

//    static int minimumSwaps(int[] arr)
//    {

//        int swaps = 0;


//        for (int index = 0; index < arr.Length - 1; index++)
//        {
//            if (arr[index] != (index + 1))
//            {
//                for (int swapIndex = index + 1; swapIndex < arr.Length; swapIndex++)
//                {
//                    if (arr[swapIndex] == (index + 1))
//                    {
//                        int aux = arr[swapIndex];
//                        arr[swapIndex] = arr[index];
//                        arr[index] = aux;
//                        swaps++;
//                        break;
//                    }
//                }
//            }
//        }

//        return swaps;
//    }

//    public static List<int> dynamicArray(int n, List<List<int>> queries)
//    {
//        List<int> result = new List<int>();
//        List<List<int>> sequences = new List<List<int>>(n);
//        for (int i = 0; i < n; i++)
//        {
//            sequences.Add(new List<int>(1));
//        }
//        int lastAnswer = 0;

//        for (int i = 0; i < queries.Count(); i++)
//        {
//            int index = (queries[i][1] ^ lastAnswer) % n;

//            if (queries[i][0] == 1)
//            {
//                sequences[index].Add(queries[i][2]);
//            }
//            else
//            {
//                int elementIndex = queries[i][2] % sequences[index].Count();
//                lastAnswer = sequences[index][elementIndex];
//                result.Add(lastAnswer);
//            }
//        }

//        return result;
//    }

//    public static void Main(string[] args)
//    {

//        //int[][] arr = new int[6][]
//        //{
//        //  new int[] { -9, -9, -9,  1, 1, 1, },
//        //  new int[] { 0, -9,  0,  4, 3, 2 },
//        //  new int[]{ -9, -9, -9,  1, 2, 3, },
//        //  new int[]{ 0,  0,  8,  6, 6, 0 },
//        //  new int[]{ 0,  0,  0, -2, 0, 0 },
//        //  new int[]{ 0,  0 , 1,  2, 4, 0 }
//        //};

//        //int[] arr = new int[] { 4, 3, 1, 2 };
//        //int[][] arr = new int[4][];

//        //arr[0] = (Console.ReadLine().TrimEnd().Split(' ').Select(arrTemp => Convert.ToInt32(arrTemp)).ToArray());

//        // var result = minimumSwaps(arr);

//        // Console.WriteLine(result);

//        //List<List<int>> lists = new List<List<int>>()
//        //{
//        //    new List<int> { 1,0,5},
//        //    new List<int> { 1,1,7},
//        //    new List<int> { 1,0,3},
//        //    new List<int> { 2,1,0},
//        //    new List<int> { 2,1,1}
//        //};

//        //foreach (var item in dynamicArray(lists.Count(),lists))
//        //{
//        //    Console.WriteLine(item);
//        //}

//        //foreach (var item in leftRotation2(new int[] { 41, 73, 89, 7, 10, 1, 59, 58, 84, 77, 77, 97, 58, 1, 86, 58, 26, 10, 86, 51 }, 10))
//        //{
//        //    Console.Write(item + " ");
//        //}

//        //SinglyLinkedListNode first = new SinglyLinkedListNode(1)
//        //{
//        //    next = new SinglyLinkedListNode(2) { next = new SinglyLinkedListNode(3) }
//        //};

//        //SinglyLinkedListNode second = new SinglyLinkedListNode(3)
//        //{
//        //    next = new SinglyLinkedListNode(4)
//        //};
//        //var temp = mergeLists(first, second);
//        //while (temp != null)
//        //{
//        //    Console.Write(temp.data + ", ");
//        //    temp = temp.next;
//        //}

//        //Console.WriteLine(isValidSherlockString("abcdefghhgfedecba"));
//        //var lines = File.ReadAllLines("TestCases.txt");

//        //for (int i = 1; i < int.Parse(lines[0]); i++)
//        //{
//        //    Console.WriteLine(isBalanced(lines[i]));
//        //}

//        Console.WriteLine(isBalanced("){[]()})}}]{}[}}})}{]{](]](()][{))])(}]}))(}[}{{)}{[[}[]"));
//        Console.ReadKey();
//    }

//    static string isBalanced(string s)
//    {

//        Stack<char> stack = new Stack<char>();

//        if (s.Length % 2 != 0)
//        {
//            return "NO";
//        }

//        for (int i = 0; i < s.Length; i++)
//        {
//            switch (s[i])
//            {
//                case '{':
//                    stack.Push('}');
//                    break;
//                case '[':
//                    stack.Push(']');
//                    break;
//                case '(':
//                    stack.Push(')');
//                    break;
//                default:
//                    if (stack.Count == 0 || stack.Pop() != s[i])
//                    {
//                        return "NO";
//                    }
//                    break;
//            }
//        }

//        return "YES";
//    }

//    static string isValidSherlockString(string s)
//    {
//        Dictionary<char, int> indexs = new Dictionary<char, int>();     
//        for (int i = 0; i < s.Length; i++)
//        {

//            if (indexs.ContainsKey(s[i]))
//            {
//                indexs[s[i]]++;
//            }
//            else
//            {
//                indexs.Add(s[i], 1);
//            }
//        }

//        var test = indexs.Where(x => x.Value != indexs.GroupBy(y => y.Value).Count());
//        var values = indexs.GroupBy(x => x.Value).Select(y => y.Key).ToList();

//        if (values.Count() > 2 || Math.Abs(values[0] - values[1]) > 1)
//        {
//            return "NO";
//        }

//        return "YES";
//    }

//    static int[] leftRotation2(int[] arr, int d)
//    {
//        int[] temp = new int[arr.Length];
//        int postIndex = (arr.Length - d);

//        for (int i = 0; i < arr.Length; i++)
//        {
//            if (i + d < arr.Length)
//            {
//                temp[i] = arr[i + d];
//            }

//            if (postIndex + i < arr.Length)
//            {
//                temp[postIndex + i] = arr[i];
//            }
//        }

//        return temp;
//    }

//    static int[] matchingStrings(string[] strings, string[] queries)
//    {
//        int[] result = new int[queries.Length];
//        object a = new object(); object b = new object();
//        object c = a ?? b;
//        for (int i = 0; i < strings.Length; i++)
//        {
//            for (int j = 0; j < queries.Length; j++)
//            {
//                if (strings[i] == queries[j])
//                {
//                    result[j] += 1;
//                    break;
//                }
//            }
//        }

//        return result;


//    }

//    class SinglyLinkedListNode
//    {
//        public int data;
//        public SinglyLinkedListNode next;

//        public SinglyLinkedListNode(int nodeData)
//        {
//            this.data = nodeData;
//            this.next = null;
//            SortedList<int, int> ss = new SortedList<int, int>();
//        }
//    }


//    static SinglyLinkedListNode mergeLists(SinglyLinkedListNode head1, SinglyLinkedListNode head2)
//    {

//        SinglyLinkedListNode newListHead = new SinglyLinkedListNode(0);
//        SinglyLinkedListNode newList = newListHead;

//        if (head1 == null ^ head2 == null)
//        {
//            return head1 ?? head2;
//        }

//        while (head1 != null || head2 != null)
//        {

//            if ((head1 != null && head2 == null) || ((head1 != null && head2 != null) && head1.data < head2.data))
//            {
//                newList.next = new SinglyLinkedListNode(head1.data);
//                head1 = head1.next;
//            }
//            else if ((head2 != null && head1 == null) || ((head2 != null && head1 != null) && head2.data < head1.data))
//            {
//                newList.next = new SinglyLinkedListNode(head2.data);
//                head2 = head2.next;
//            }
//            else
//            {
//                newList.next = new SinglyLinkedListNode(head1.data);
//                newList = newList.next;
//                newList.next = new SinglyLinkedListNode(head2.data);
//                head1 = head1.next;
//                head2 = head2.next;
//            }

//            newList = newList.next;
//        }

//        newList.next = null;

//        return newListHead.next;
//    }
//}


//class Solution
//{

//    public class MyStack
//    {
//        int max = int.MinValue;
//        List<KeyValuePair<int, int>> list;
//        int current = -1;

//        public MyStack(int length)
//        {
//            list = new List<KeyValuePair<int, int>>(length);
//        }

//        public void Push(int num)
//        {
//            max = Math.Max(max, num);
//            list.Add( new KeyValuePair<int, int>(num, max));
//        }

//        public void Pop()
//        {
//            if (list.Count > 0)
//            {
//                list.RemoveAt(list.Count - 1);
//                max = list.Count > 0 ?  list.Last().Value : int.MinValue;
//            }
//        }

//        public int GetMax()
//        {
//            return max;
//        }
//    }

//    static void Main2(String[] args)
//    {
//        /* Enter your code here. Read input from STDIN. Print output to STDOUT. Your class should be named Solution */
//        int length = int.Parse(Console.ReadLine());
//        MyStack stack = new MyStack(length);
//        int[] queries = new int[2];

//        for (int i = 0; i < length; i++)
//        {
//            queries = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
//            switch (queries[0])
//            {
//                case 1:
//                    stack.Push(queries[1]);
//                    break;
//                case 2:
//                    stack.Pop();
//                    break;
//                case 3:
//                    Console.WriteLine(stack.GetMax());
//                    break;

//            }
//        }
//    }
//}

//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Linq;

//class Solution
//{

//    /*
//     * Complete the equalStacks function below.
//     */
//    static int equalStacks(Stack<int> h1, Stack<int> h2, Stack<int> h3)
//    {
//        /*
//         * Write your code here.
//         */


//        while (true)
//        {
//            int h1Sum = h1.Sum();
//            int h2Sum = h2.Sum();
//            int h3Sum = h3.Sum();

//            if (h1Sum == h2Sum && h2Sum == h3Sum)
//            {
//                break;
//            }

//            if (h1Sum > h2Sum && h1Sum > h3Sum)
//            {
//                h1.Pop();
//            }
//            else if (h2Sum > h3Sum)
//            {
//                h2.Pop();
//            }
//            else
//            {
//                h3.Pop();
//            }
//        }

//        return h1.Sum();

//    }

//    static void Main(string[] args)
//    {

//        string[] n1N2N3 = Console.ReadLine().Split(' ');

//        int n1 = Convert.ToInt32(n1N2N3[0]);

//        int n2 = Convert.ToInt32(n1N2N3[1]);

//        int n3 = Convert.ToInt32(n1N2N3[2]);

//        int[] h1 = Array.ConvertAll(Console.ReadLine().Split(' '), h1Temp => Convert.ToInt32(h1Temp))
//        ;

//        int[] h2 = Array.ConvertAll(Console.ReadLine().Split(' '), h2Temp => Convert.ToInt32(h2Temp))
//        ;

//        int[] h3 = Array.ConvertAll(Console.ReadLine().Split(' '), h3Temp => Convert.ToInt32(h3Temp))
//        ; 
//        int result = equalStacks(new Stack<int>(h1.Reverse()), new Stack<int>(h2.Reverse()), new Stack<int>(h3.Reverse()));

//        Console.WriteLine(result);
//        Console.ReadKey();
//    }
//}