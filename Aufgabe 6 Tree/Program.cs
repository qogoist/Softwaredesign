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

            root.AddListener("AppendChild", HandleAppendChild);
            root.AddListener("AppendChild", HandleAppendChild);

            var c1 = tree.CreateNode("child1");
            var c2 = tree.CreateNode("child2");
            root.AppendChild(c1);
            root.RemoveListener("AppendChild", HandleAppendChild);
            root.AppendChild(c2);

            var g1 = tree.CreateNode("grandchild1");
            var g2 = tree.CreateNode("grandchild2");
            var g3 = tree.CreateNode("grandchild3");
            var g4 = tree.CreateNode("grandchild4");
            c1.AppendChild(g1);
            c1.AppendChild(g2);
            c2.AppendChild(g3);
            c2.AppendChild(g4);
            //g4.AppendChild(root);

            tree.Print(root);

            //root.ForEach(Func);

        }

        static void Func<T>(Tree<T>.TreeNode node)
        {
            Console.Write(node + " | ");
        }

        static void HandleAppendChild()
        {
            Console.WriteLine("Child added");
        }
        static void HandleRemoveChild()
        {
            Console.WriteLine("Child removed");
        }
    }
}
