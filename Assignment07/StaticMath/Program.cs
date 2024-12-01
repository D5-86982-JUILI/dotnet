using System;
using System.Collections.Generic;
using System.Text;

namespace StaticMath
{
    internal class Program
    {
        static void Main(string[] args)
        { 
            operation op = new operation(Math.Sum);
            Console.WriteLine("Unicast");
            op(10, 5);
            op += new operation(Math.Subtract);
            op += new operation(Math.Multiply);
            op += new operation(Math.Divide);
            Console.WriteLine("\nMulticast");
            op(15, 3);
        }
    }

    public delegate void operation(int num1, int num2);

    public static class Math
    {
        public static void Sum(int num1, int num2)
        {
            Console.WriteLine("Addition: " + (num1 + num2));
        }

        public static void Subtract(int num1, int num2)
        {
            Console.WriteLine("Subtraction: " + (num1 - num2));
        }

        public static void Multiply(int num1, int num2)
        {
            Console.WriteLine("Multiplication: " + (num1 * num2));
        }

        public static void Divide(int num1, int num2)
        {
            Console.WriteLine("Division: " + (num1 / num2));
        }




    }
}
