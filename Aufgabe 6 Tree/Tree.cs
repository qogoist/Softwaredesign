using System;

namespace Aufgabe_6_Tree
{
    class Tree<T>
    {
        public TreeNode<T> CreateNode(T content)
        {
            return new TreeNode<T>(content);
        }

        public void Print(TreeNode<T> node, string indent = "")
        {
            string output = node.ToString();
            Console.WriteLine(indent + output);
            indent += "/";

            foreach (var child in node.children)
            {   
                this.Print(child, indent);
            }
        }
    }
}