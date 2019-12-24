using System;

namespace BinaryTree
{
    public class Node<T> where T : IComparable
    {
        private T value;

        public T Value
        {
            get => value;
            private set => this.value = value;
        }


        public Node<T> LeftNode { get; set; }
        public Node<T> RightNode { get; set; }

        public Node(T value)
        {
            this.value = value;
        }

        public int CompareTo(T other)
        {
            return Value.CompareTo(other);
        }
        
        

    }
}