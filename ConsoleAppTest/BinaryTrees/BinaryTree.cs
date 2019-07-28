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
            levelOrderTraversal(_root);
        }

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
    }
}
