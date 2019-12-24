using System;
    
namespace BinaryTree
{
    public class Student : IComparable
    {
        public string Name { get; set; }
        public string TestName { get; set; }
        public DateTime Date { get; set; }

        public int Mark { get; set; }

        public Student(string name, string testName, int mark)
        {
            Name = name;
            TestName = testName;
            Mark = mark;
            Date = DateTime.Now;
        }

        public int CompareTo(object obj)
        {
            Student student = (Student)obj;
            if (this.Mark > student.Mark)
            {
                return 1;
            }
            else if (this.Mark < student.Mark)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }
    }
}