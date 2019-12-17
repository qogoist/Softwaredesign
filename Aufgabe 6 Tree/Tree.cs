using System;
using System.Collections;
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
            public delegate void EventHandler();

            public TreeNode parent;
            public List<TreeNode> children;
            public T content;
            private Dictionary<string, EventHandler> listeners;

            public TreeNode(T content)
            {
                this.content = content;
                this.parent = null;
                this.children = new List<TreeNode> { };
                this.listeners = new Dictionary<string, EventHandler> { };
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
                    EventHandler handler = listeners["AppendChild"];
                    handler();
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
                    EventHandler listener = listeners["RemoveChild"];
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

            public void AddListener(string listenerType, EventHandler handler)
            {
                if (listeners.ContainsKey(listenerType))
                {
                    Console.WriteLine("Added another handler to " + listenerType + ".");
                    listeners[listenerType] += handler;
                }
                else
                {
                    Console.WriteLine("Added a first handler to " + listenerType + ".");
                    listeners.Add(listenerType, handler);
                }
            }

            public void RemoveListener(string type, EventHandler handler)
            {
                if (listeners.ContainsKey(type))
                {
                    if (listeners[type].Method == handler.Method)
                    {
                        Console.WriteLine("Removing handler from " + type + ".");
                        listeners[type] -= handler;
                    }                    
                }
            }

            public IEnumerator<TreeNode> GetEnumerator()
            {
                yield return this;
                foreach (var childNode in this.children)
                    foreach(var child in childNode)
                        yield return child; 
            }
        }
    }
}