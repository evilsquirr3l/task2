using System;
using System.Collections.Generic;
using BinaryTree;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class Tests
    {
        [SetUp]
        public void SetUp()
        {
        }
        


        [Test]
        public void Add_AddingItems_ItemsAreAddedAndNumberOfElementsIsIncreasing()
        {
            var first = new Student("Vanya", "Math", 1);
            var second = new Student("Mark", "Math", 2);
            var third = new Student("Petya", "Math", 4);
            var fourth = new Student("Serhii", "Math", 100);

            var list = new List<Student> {first, second, third, fourth};

            var tree = new Tree<Student>();
            tree.Add(first);
            tree.Add(second);
            tree.Add(third);
            tree.Add(fourth);

            Assert.Multiple(() =>
            {
                CollectionAssert.AreEqual(list, tree);
                Assert.That(tree.Count == 4);
            });
        }

        [Test]
        public void Add_AddingNull_ExceptionThrown()
        {
            var tree = new Tree<Student>();

            Assert.Throws<ArgumentNullException>(() => { tree.Add(null); });
        }

        [Test]
        public void InOrder_WorksInForeach_OrderIsInorder()
        {
            
            var first = new Student("Vanya", "Math", 1);
            var second = new Student("Mark", "Math", 2);
            var third = new Student("Petya", "Math", 4);
            var fourth = new Student("Serhii", "Math", 100);

            var tree = new Tree<Student> {first, second, third, fourth};
            var list = new List<Student> {first, second, third, fourth};

            CollectionAssert.AreEqual(tree.InOrder(), list);
        }

        [Test]
        public void PostOrder_WorksInForeach_OrderIsPostOrder()
        {
            var first = new Student("Vanya", "Math", 1);
            var second = new Student("Mark", "Math", 2);
            var third = new Student("Petya", "Math", 4);
            var fourth = new Student("Serhii", "Math", 100);

            var tree = new Tree<Student>();
            tree.Add(first);
            tree.Add(second);
            tree.Add(third);
            tree.Add(fourth);
            var list = new List<Student> {fourth, third, second, first};
            CollectionAssert.AreEqual(tree.PostOrder(), list);
        }

        [Test]
        public void PreOrder_WorksInForeach_OrderIsPreorder()
        {
            var first = new Student("Vanya", "Math", 1);
            var second = new Student("Mark", "Math", 2);
            var third = new Student("Petya", "Math", 4);
            var fourth = new Student("Serhii", "Math", 100);

            var tree = new Tree<Student> {first, second, third, fourth};
            var list = new List<Student> {first, second, third, fourth};

            CollectionAssert.AreEqual(tree.PreOrder(), list);
        }

        [Test]
        public void Remove_ItemIsContained_ReturnsTrueAndContains3Items()
        {
            var first = new Student("Vanya", "Math", 1);
            var second = new Student("Mark", "Math", 2);
            var third = new Student("Petya", "Math", 4);
            var fourth = new Student("Serhii", "Math", 100);

            var tree = new Tree<Student> {first, second, third, fourth};

            var result = tree.Remove(fourth);

            Assert.Multiple(() =>
            {
                Assert.That(tree.Count == 3);
                Assert.IsTrue(result);
            });
        }

        [Test]
        public void Remove_ItemIsNotContained_ReturnsFalse()
        {
            var first = new Student("Vanya", "Math", 1);
            var second = new Student("Mark", "Math", 2);
            var third = new Student("Petya", "Math", 4);
            var fourth = new Student("Serhii", "Math", 100);

            var tree = new Tree<Student> {first, second, third};

            var result = tree.Remove(fourth);

            Assert.IsFalse(result);
        }
        
    }
}