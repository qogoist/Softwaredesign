using System;

namespace Aufgabe_6_Tree
{
    class Program
    {
        static void Main(string[] args)
        {
            var tree = new Tree<int>();
            var root = tree.CreateNode(0);
            var c1 = tree.CreateNode(1);
            var c2 = tree.CreateNode(2);
            root.AppendChild(c1);
            root.AppendChild(c2);

            var g1 = tree.CreateNode(1);
            var g2 = tree.CreateNode(2);
            var g3 = tree.CreateNode(3);
            var g4 = tree.CreateNode(4);
            c1.AppendChild(g1);
            c1.AppendChild(g2);
            c2.AppendChild(g3);
            c2.AppendChild(g4);

            tree.Print(root);
        }
    }
}
