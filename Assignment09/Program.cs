using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program18
{
    public static class Math 
    { 
        public static int Sum(int a, int b) 
        { 
            return a + b; 
        } 
        public static int Subtract(int a, int b) 
        {
            return a - b; 
        } 
        public static int Multiply(int a, int b) 
        {
            return a * b;
        } 
        public static int Divide(int a, int b) 
        { 
            return a / b; 
        } 
    }

    internal class Program
    {
        public delegate int Operation(int a, int b);
        static void Main(string[] args)
        {
            int a = 20;
            int b = 10;

            Operation sumOp = new Operation(Math.Sum);
            Operation subtractOp = new Operation(Math.Subtract);
            Operation mulOp = new Operation(Math.Multiply);
            Operation divOp = new Operation(Math.Divide);

            Console.WriteLine("Uni-cast delegates:");
            Console.WriteLine("Sum: " + sumOp(a,b));
            Console.WriteLine("Subtract: " + subtractOp(a, b));
            Console.WriteLine("Multiply: " + mulOp(a, b));
            Console.WriteLine("Divide: " + divOp(a, b));

            Operation multiOperation = sumOp;
            multiOperation += subtractOp;
            multiOperation += mulOp;
            multiOperation += divOp;

            Console.WriteLine("\nMulticast delegates");
            foreach(Operation op in multiOperation.GetInvocationList())
            {
                Console.WriteLine($"{op.Method.Name}: {op(a, b)}");
            }
        }
    }
}
