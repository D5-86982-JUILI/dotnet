using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentLib;

namespace Q4Structure
{
    internal class Q5StudentArray
    {
        public class Student
        {
            private string _Name;
            private bool _Gender;
            private int _Age;
            private int _Std;
            private char _Div;
            private double _Marks;

            public Student()
            {
                
            }



            public Student(string name, bool gender, int age, int std, char div, double marks)
            {
                _Name = name;
                _Gender = gender;
                _Age = age;
                _Std = std;
                _Div = div;
                _Marks = marks;
            }


            public int Age
            {
                get { return _Age; }
                set { _Age = value; }
            }

            public string Name
            {
                get { return _Name; }
                set { _Name = value; }
            }
            public bool gender
            {
                get { return _Gender; }
                set { _Gender = value; }
            }
            public int std
            {
                get { return _Std; }
                set { _Std = value; }
            }
            public char div
            {
                get { return _Div; }
                set { _Div = value; }
            }
            public double marks
            {
                get { return _Marks; }
                set { _Marks = value; }
            }

            public void accept()
            {
                Console.WriteLine("Enter Name:");
                Name = Console.ReadLine();
                Console.WriteLine("Enter gender:");
                char genderChar = Convert.ToChar(Console.ReadLine());
                gender = (genderChar == 'M' || genderChar == 'F');
                Console.WriteLine("Enter Age:");
                Age = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter std:");
                std = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter div:");
                div = Convert.ToChar(Console.ReadLine());
                Console.WriteLine("Enter marks:");
                marks = Convert.ToDouble(Console.ReadLine());
            }

            public void display()
            {
                Console.WriteLine("Name : " + Name);
                Console.WriteLine("Gender : " + gender);
                Console.WriteLine("Age : " + Age);
                Console.WriteLine("standard:" + std);
                Console.WriteLine("div:" + div);
                Console.WriteLine("Marks :" + marks);
            }

        }
        public static void Main(string[] args)
        {
            Student[] students;
            students = CreateArray();
            AcceptInfo(students);
            Console.WriteLine("Original Array:");
            PrintInfo(students);

            Student[] reversedStudents = new Student[students.Length];
            ReverseArray(students, reversedStudents);
            Console.WriteLine("Reversed Array:");
            PrintInfo(reversedStudents);
        }

        
        static Student[] CreateArray()
        {
            Console.WriteLine("Enter the number of students:");
            int size = Convert.ToInt32(Console.ReadLine());
            return new Student[size];
        }

        static void AcceptInfo(Student[] students)
        {
            for (int i = 0; i < students.Length; i++)
            {
                students[i] = new Student();
                Console.WriteLine("Enter details for student:",i + 1);
                Console.Write("Name: ");
                students[i].Name = Console.ReadLine();
                Console.Write("Age: ");
                students[i].Age = Convert.ToInt32(Console.ReadLine());
                Console.Write("Div: ");
                students[i].div = Convert.ToChar(Console.ReadLine());
                Console.Write("Marks: ");
                students[i].marks = Convert.ToInt32(Console.ReadLine());
            }
        }

        static void PrintInfo(Student[] students)
        {
            foreach (var student in students)
            {
                Console.WriteLine($"Name: {student.Name}, Age: {student.Age}, Grade: {student.div}");
            }
        }

        static void ReverseArray(Student[] original, Student[] reversed)
        {
            int j = 0;
            for (int i = original.Length - 1; i >= 0; i--)
            {
                reversed[j] = original[i];
                j++;
            }
        }
}










}
    
 

