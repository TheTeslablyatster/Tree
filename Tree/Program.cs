using System;
using Tree.Properties;

namespace Tree
{
    class Program
    {
        static void Main()
        {
            var Tree = new Tree<int>();

            Tree.Add(8);
            Tree.Add(3);
            Tree.Add(10);
            Tree.Add(1);
            Tree.Add(6);
            Tree.Add(4);
            Tree.Add(7);
            Tree.Add(14);
            Tree.Add(16);
            Tree.Add(8);
            Tree.Add(45);
            Tree.Add(21);
            Tree.Add(2);
            Tree.Add(13);
            Tree.Add(11);
            Tree.Add(5);
            Tree.Add(9);
            Tree.Add(17);
            Tree.Add(21);
            Tree.Add(-15);
            Tree.Add(18);


            Tree.PrintTree();

            Console.WriteLine(new string('-', 100));
            Tree.Remove(17);
            Tree.PrintTree();

            Console.WriteLine(new string('-', 100));
            Tree.Remove(8);
            Tree.PrintTree();

            foreach (var node in Tree.TreeEnumerator(Tree.RootNode))
                Console.Write($"{node.ToString()} ");
            Console.ReadLine();
        }
    }
}
