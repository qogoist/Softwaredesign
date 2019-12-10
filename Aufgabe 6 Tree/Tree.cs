using System;
using System.Collections.Generic;

namespace Aufgabe_6_Tree
{
    class Tree<T>
    {
        public TreeNode CreateNode(T content)
        {
            return new TreeNode(content);
        }

        public void Print(TreeNode node, string indent = "")
        {
            string output = node.ToString();
            Console.WriteLine(indent + output);
            indent += "/";

            foreach (var child in node.children)
            {
                this.Print(child, indent);
            }
        }

        public class TreeNode
        {
            public delegate void Listener();

            public TreeNode parent;
            public List<TreeNode> children;
            public T content;
            private Dictionary<string, Listener> listeners;

            public TreeNode(T content)
            {
                this.content = content;
                this.parent = null;
                this.children = new List<TreeNode> { };
                this.listeners = new Dictionary<string, Listener> { };
            }

            public void AppendChild(TreeNode child)
            {
                if (this.IsAncestor(child))
                {
                    Console.WriteLine("Invalid action: tried to append an element to its descendant.");
                    return;
                }

                if (listeners.ContainsKey("AppendChild"))
                {
                    Listener listener = listeners["AppendChild"];
                    listener();
                }

                if (child.parent != null)
                    child.parent.RemoveChild(child);

                this.children.Add(child);
                child.parent = this;
            }

            private bool IsAncestor(TreeNode node)
            {
                if (this.parent == null)
                {
                    return false;
                }
                else if (this.parent == node)
                {
                    return true;
                }
                else
                {
                    return this.parent.IsAncestor(node);
                }
            }

            public void RemoveChild(TreeNode child)
            {
                this.children.Remove(child);
                child.parent = null;

                if (listeners.ContainsKey("RemoveChild"))
                {
                    Listener listener = listeners["RemoveChild"];
                    listener();
                }
            }

            override public string ToString()
            {
                return content.ToString();
            }

            public void ForEach(Action<TreeNode> func)
            {
                func(this);
                foreach (var child in children)
                {
                    child.ForEach(func);
                }
            }

            public TreeNode FindRoot()
            {
                if (parent == null)
                    return this;
                else
                    return parent.FindRoot();
            }


            public void AddListener(string type, Listener handler)
            {
                if (listeners.ContainsKey(type))
                {
                    Console.WriteLine("Added another handler to " + type + ".");
                    listeners[type] += handler;
                }
                else
                {
                    Console.WriteLine("Added a first handler to " + type + ".");
                    listeners.Add(type, handler);
                }
            }
        }
    }
}