using System;
using System.Collections.Generic;

namespace Aufgabe_6_Tree
{
    class Program
    {
        static void Main(string[] args)
        {
            var tree = new Tree<string>();
            var root = tree.CreateNode("root");
            var c1 = tree.CreateNode("child1");
            var c2 = tree.CreateNode("child2");
            root.AppendChild(c1);
            root.AppendChild(c2);

            var g1 = tree.CreateNode("grandchild1");
            var g2 = tree.CreateNode("grandchild2");
            var g3 = tree.CreateNode("grandchild3");
            var g4 = tree.CreateNode("grandchild4");
            c1.AppendChild(g1);
            c1.AppendChild(g2);
            c2.AppendChild(g3);
            c2.AppendChild(g4);

            tree.Print(root);

            root.ForEach(Func<string>);

        }

        static void Func<T>(TreeNode<T> node)
        {
            Console.Write(node + " | ");
        }
    }
}
