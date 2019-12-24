using System;
using System.Collections.Generic;

namespace BinaryTree
{
    class Subscriber
    {
        public void AddedMethod(object source, EventArgs e)
        {
            Console.WriteLine("Item is added");
        }

        public void RemovedMethod(object source, EventArgs e)
        {
            Console.WriteLine("Item is removed");
        }
    }



    class Program
    {
        static void Main(string[] args)
        {
            Tree<Student> tree = new Tree<Student>();
            var sub = new Subscriber();

            tree.ItemAdded += sub.AddedMethod;
            tree.ItemRemoved += sub.RemovedMethod;

            for (int i = 0; i < 10; i++)
            {
                int val = i;
                tree.Add(new Student("Ivan", "Math", val));
            }


            foreach (var student in tree)
            {
                Console.WriteLine(student.Mark);
            }

            tree.Remove(new Student("Ivan", "Math", 5));



            foreach (var student in tree.PostOrder())
            {
                Console.WriteLine(student.Mark);
            }

            Student first = new Student("Vanya", "Math", 1);
            Student second = new Student("Mark", "Math", 2);
            Student third = new Student("Petya", "Math", 4);
            Student fourth = new Student("Serhii", "Math", 100);

            Tree<Student> megatree = new Tree<Student> {first, second, third, fourth};
            
            List<Student> list = new List<Student>() {first, fourth, third, second};

            foreach (var student in megatree.PreOrder())
            {
                Console.WriteLine(student.Mark);
            }

        }

    }
}
