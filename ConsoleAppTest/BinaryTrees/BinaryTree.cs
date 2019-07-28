using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppTest.BinaryTrees
{
    public class Node<T>
    {
        public Node<T> Left { get; set; }
        public Node<T> Right { get; set; }
        public T Value { get; set; }
        public int Hd { get; set; }
    }

    public class BinaryTree<T>
    {
        Node<T> _root;

        public BinaryTree(Node<T> root)
        {
            _root = root;
        }

        public void LevelOrderTraversal()
        {
            void levelOrderTraversal(Node<T> node)
            {
                Queue<Node<T>> hs = new Queue<Node<T>>();
                hs.Enqueue(node);
                hs.Enqueue(null);

                while (hs.Any())
                {
                    var item = hs.Dequeue();

                    if (item is null)
                    {
                        Console.WriteLine();

                        if (hs.Count > 1)
                        {
                            hs.Enqueue(null);
                        }

                    }
                    else
                    {
                        Console.Write(item.Value + " ");

                        if (item.Left != null)
                        {
                            hs.Enqueue(item.Left);
                        }

                        if (item.Right != null)
                        {
                            hs.Enqueue(item.Right);
                        }

                    }
                }
            }

            levelOrderTraversal(_root);
        }

        public void VerticalOrderTraversal()
        {
            void verticalOrderTraversalIterative(Node<T> node, int hd, Dictionary<int, List<Node<T>>> dic)
            {
                if (node is null)
                {
                    return;
                }

                if (!dic.ContainsKey(hd))
                {
                    dic.Add(hd, new List<Node<T>>());
                }

                dic[hd].Add(node);

                verticalOrderTraversalIterative(node.Left, hd - 1, dic);
                verticalOrderTraversalIterative(node.Right, hd + 1, dic);
            }

            void verticalOrderTraversal(Node<T> root)
            {
                Dictionary<int, List<Node<T>>> dic = new Dictionary<int, List<Node<T>>>();
                dic.Add(0, new List<Node<T>>() { root });

                Queue<Node<T>> queue = new Queue<Node<T>>();
                queue.Enqueue(root);

                while (queue.Any())
                {
                    var item = queue.Dequeue();

                    if (item.Left != null)
                    {
                        item.Left.Hd = item.Hd - 1;

                        if (!dic.ContainsKey(item.Left.Hd))
                        {
                            dic.Add(item.Left.Hd, new List<Node<T>>());
                        }

                        dic[item.Left.Hd].Add(item.Left);
                        queue.Enqueue(item.Left);
                    }

                    if (item.Right != null)
                    {
                        item.Right.Hd = item.Hd + 1;

                        if (!dic.ContainsKey(item.Right.Hd))
                        {
                            dic.Add(item.Right.Hd, new List<Node<T>>());
                        }
                        
                        dic[item.Right.Hd].Add(item.Right);
                        queue.Enqueue(item.Right);
                    }
                }

                dic = dic.OrderBy(x => x.Key).ToDictionary(e => e.Key, s => s.Value);

                foreach (var item in dic)
                {
                    Console.WriteLine("Hd " + item.Key + ": " + string.Join(", ", item.Value.Select(x => x.Value)));
                }
            }

            verticalOrderTraversal(_root);
        }
    }
}
