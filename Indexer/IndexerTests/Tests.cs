using System;
using NUnit.Framework;
using Indexer;

namespace IndexerTests
{
    [TestFixture]
    public class Tests
    {
        [Test]
        [TestCase(2, 1)]
        public void CreatingArrayWithWrongArgs_ThrowsException(int a, int b)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Array<int> array = new Array<int>(a, b);
            });

        }

        [Test]
        public void Add_AddingItem_ItemIsAdded()
        {
            var array = new Array<int>(0, 4);
            int[] result = new [] {1};
            
            array.Add(1);
            
            CollectionAssert.AreEqual(result, array);
            
        }

        [Test]
        public void Add_AddingNull_ExceptionThrown()
        {
            var array = new Array<string>(0, 4);

            Assert.Throws<ArgumentNullException>(() =>
            {
                array.Add(null);
            });
        }

        [Test]
        public void Remove_ItemContained_ReturnsTrue()
        {
            var array = new Array<int>(0, 4);
            array.Add(1);

            var result = array.Remove(1);

            Assert.IsTrue(result);


        }
        
        [Test]
        public void Remove_ItemIsNotContained_ReturnsFalse()
        {
            var array = new Array<int>(0, 4);
            array.Add(1);

            var result = array.Remove(2);

            Assert.IsFalse(result);
        }

        [Test]
        public void CopyTo_CopiesElementsOfArrayToNewArrayStartingFromIndex()
        {
            var array = new Array<int>(0, 3);
            var newarray = new int[3];
            array.Add(1);
            array.Add(12);
            array.Add(13);
            
            array.CopyTo(newarray, 0);
            
            CollectionAssert.AreEqual(array, newarray);
            
        }

        [Test]
        public void IndexerIsOurOfRange_ExceptionThrown()
        {
            var array = new Array<int>(0, 3);


            Assert.Throws<IndexOutOfRangeException>(() =>
            {
                Console.WriteLine(array[int.MaxValue]);
            });
        }

        [Test]
        public void ChangingItems_ArrayIsReadOnly_ExceptionThrown()
        {
            var array = new Array<int>(0, 3);
            array.IsReadOnly = true;

            Assert.Throws<InvalidOperationException>(() => 
                { array[0] = 1; });
        }
        
        [Test]
        public void ChangingItems_ArrayIsNotReadOnly_ItemChanged()
        {
            var array = new Array<int>(0, 3);
            var result = 1;
            
            array.Add(1);
            array[0] = result;
            
            Assert.AreEqual(result, array[0]);

        }

        
    }
}