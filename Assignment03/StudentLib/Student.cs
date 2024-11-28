using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentLib
{
    public class Student
    {
        public struct student
        {
            private string _Name;
            private bool _Gender;
            private int _Age;
            private int _Std;
            private char _Div;
            private double _Marks;



            public student(string name, bool gender, int age, int std, char div, double marks)
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
    }
}
