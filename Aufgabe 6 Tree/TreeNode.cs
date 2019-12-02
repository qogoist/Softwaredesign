using System;
using System.Collections.Generic;

namespace Aufgabe_6_Tree
{
    class TreeNode<T>
    {
        public TreeNode<T> parent;
        public List<TreeNode<T>> children;
        public T content;

        public TreeNode(T content)
        {
            this.content = content;
            this.parent = null;
            this.children = new List<TreeNode<T>> { };
        }

        public void AppendChild(TreeNode<T> node)
        {
            this.children.Add(node);
            node.parent = this;
        }

        public void RemoveChild(TreeNode<T> node)
        {
            this.children.Remove(node);
            node.parent = null;
        }

        override public string ToString()
        {
            return content.ToString();
        }
    }
}