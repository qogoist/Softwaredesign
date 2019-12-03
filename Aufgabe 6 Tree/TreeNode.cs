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

        public void AppendChild(TreeNode<T> child)
        {
            TreeNode<T> root = this.FindRoot();

            if (child.Equals(root))
                return;

            if (child.parent != null)
                child.parent.RemoveChild(child);

            this.children.Add(child);
            child.parent = this;
        }

        public void RemoveChild(TreeNode<T> child)
        {
            this.children.Remove(child);
            child.parent = null;
        }

        override public string ToString()
        {
            return content.ToString();
        }

        public void ForEach(Action<TreeNode<T>> func)
        {
            func(this);
            foreach (var child in children)
            {
                child.ForEach(func);
            }
        }

        public TreeNode<T> FindRoot()
        {
            if (parent == null)
                return this;
            else
                return parent.FindRoot();
        }
    }
}