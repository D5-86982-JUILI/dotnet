using System;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.Text;

namespace Math
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Math m = new Math();
            operation op = new operation(m.Sum);
            Console.WriteLine("Unicast");
            op(10, 5);
            op += new operation(m.Subtract);
            op += new operation(m.Multiply);
            op += new operation(m.Divide);
            Console.WriteLine("\nMulticast");
            op(15, 3);
        }
    }

    public delegate void operation(int num1, int num2);

    public class Math
    {
        public void Sum(int num1, int num2)
        {
            Console.WriteLine("Addition: "+ (num1 + num2));
        }

        public void Subtract(int num1, int num2)
        {
            Console.WriteLine("Subtraction: " + (num1 - num2));
        }

        public void Multiply(int num1, int num2)
        {
            Console.WriteLine("Multiplication: " + (num1 * num2));
        }

        public void Divide(int num1, int num2)
        {
            Console.WriteLine("Division: " + (num1 / num2));
        }




    }
}
