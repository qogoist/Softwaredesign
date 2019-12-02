using System;

namespace Aufgabe_6_Tree
{
    class Tree<T>
    {
        public TreeNode<T> CreateNode(T input)
        {
            return new TreeNode<T>(input);
        }

        public void Print(TreeNode<T> node, string indent = "")
        {
            Console.WriteLine(indent + node.ToString());
            indent += "/";

            foreach (var child in node.children)
            {   
                this.Print(child, indent);
            }
        }
    }
}