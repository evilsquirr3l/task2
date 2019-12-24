using System;
using System.Collections;
using System.Collections.Generic;

namespace BinaryTree
{
    public class Tree<T> : IEnumerable where T : IComparable
    {
        private Node<T> head;
        private int count;


        public delegate void TreeOperationEventHandler(object source, EventArgs args); //eventargs

        public event TreeOperationEventHandler ItemAdded;
        public event TreeOperationEventHandler ItemRemoved;


        protected virtual void OnItemAdded()
        {
            if (ItemAdded != null)
            {
                ItemAdded(this, EventArgs.Empty);
            }
        }

        protected virtual void OnItemRemoved()
        {
            if (ItemRemoved != null)
            {
                ItemRemoved(this, EventArgs.Empty);
            }
        }

        public int Count
        {
            get => count;
            private set => count = value;
        }

        public void Add(T value)
        {
            if (value == null)
            {
                throw new ArgumentNullException();
            }

            if (head == null)
            {
                head = new Node<T>(value);
            }
            else
            {
                AddTo(head, value);
            }

            count++;

            OnItemAdded();
        }


        private void AddTo(Node<T> node, T value)
        {
            if (value.CompareTo(node.Value) < 0)
            {
                if (node.LeftNode == null)
                {
                    node.LeftNode = new Node<T>(value);
                }
                else
                {
                    AddTo(node.LeftNode, value);
                }
            }
            else
            {
                if (node.RightNode == null)
                {
                    node.RightNode = new Node<T>(value);
                }
                else
                {
                    AddTo(node.RightNode, value);
                }
            }
        }

        private Node<T> Search(T value, Node<T> node)
        {
            if (value.CompareTo(node.Value) == 0)
            {
                return node;
            }
            else if (node.LeftNode != null && value.CompareTo(node) < 0)
            {
                return Search(value, node.LeftNode);
            }
            else if (node.RightNode != null && value.CompareTo(node) > 0)
            {
                return Search(value, node.RightNode);
            }
            else return null;
        }

        private Node<T> Find(T value)
        {
            if (head == null)
            {
                return null;
            }
            else
            {
                return Search(value, head);
            }
        }

        public IEnumerable<T> InOrder()
        {
            if (head == null)
            {
                yield break;
            }

            var stack = new Stack<Node<T>>();
            var node = head;

            while (stack.Count > 0 || node != null)
            {
                if (node == null)
                {
                    node = stack.Pop();
                    yield return node.Value;
                    node = node.RightNode;
                }
                else
                {
                    stack.Push(node);
                    node = node.LeftNode;
                }
            }
        }

        public IEnumerable<T> PreOrder()
        {
            if (head == null)
            {
                yield break;
            }

            var stack = new Stack<Node<T>>();
            stack.Push(head);

            while (stack.Count > 0)
            {
                var node = stack.Pop();
                yield return node.Value;

                if (node.RightNode != null)
                {
                    stack.Push(node.RightNode);
                }

                if (node.LeftNode != null)
                {
                    stack.Push(node.LeftNode);
                }
            }
        }

        public IEnumerable<T> PostOrder()
        {
            if (head == null)
            {
                yield break;
            }

            var stack = new Stack<Node<T>>();
            var node = head;

            while (stack.Count > 0 || node != null)
            {
                if (node == null)
                {
                    node = stack.Pop();
                    if (stack.Count > 0 && node.RightNode == stack.Peek())
                    {
                        stack.Pop();
                        stack.Push(node);
                        node = node.RightNode;
                    }
                    else
                    {
                        yield return node.Value;
                        node = null;
                    }
                }
                else
                {
                    if (node.RightNode != null)
                    {
                        stack.Push(node.RightNode);
                    }

                    stack.Push(node);
                    node = node.LeftNode;
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }


        public IEnumerator<T> GetEnumerator()
        {
            return InOrder().GetEnumerator();
        }


        public bool Remove(T item)
        {
            if (head == null)
            {
                return false;
            }

            Node<T> current = head;
            Node<T> parent = null;

            do
            {
                if (item.CompareTo(current.Value) < 0)
                {
                    parent = current;
                    current = current.LeftNode;
                }
                else if (item.CompareTo(current.Value) > 0)
                {
                    parent = current;
                    current = current.RightNode;
                }

                if (current == null)
                {
                    return false;
                }
            } while (item.CompareTo(current.Value) != 0);

            if (current.RightNode == null)
            {
                if (current == head)
                {
                    head = current.LeftNode;
                }

                else
                {
                    if (current.CompareTo(parent.Value) < 0)
                    {
                        parent.LeftNode = current.LeftNode;
                    }
                    else
                    {
                        parent.RightNode = current.LeftNode;
                    }
                }
            }
            else if (current.RightNode.LeftNode == null)
            {
                current.RightNode.LeftNode = current.LeftNode;
                if (current == head)
                {
                    head = current.RightNode;
                }
                else
                {
                    if (current.Value.CompareTo(parent.Value) < 0)
                    {
                        parent.LeftNode = current.RightNode;
                    }
                    else
                    {
                        parent.RightNode = current.RightNode;
                    }
                }
            }
            else
            {
                Node<T> min = current.RightNode.LeftNode;
                Node<T> prev = current.RightNode;

                while (min.LeftNode != null)
                {
                    prev = min;
                    min = min.LeftNode;
                }

                prev.LeftNode = min.RightNode;
                min.LeftNode = current.LeftNode;
                min.RightNode = current.RightNode;

                if (current == head)
                {
                    head = min;
                }
                else
                {
                    if (current.Value.CompareTo(parent.Value) < 0)
                    {
                        parent.LeftNode = min;
                    }
                    else
                    {
                        parent.RightNode = min;
                    }
                }
            }

            --count;

            OnItemRemoved();
            return true;
        }
    }
}