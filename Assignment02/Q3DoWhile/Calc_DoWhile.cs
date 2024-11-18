using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CalcLib;

namespace Q2SwitchCase
{
    internal class Calc
    {
        static void Main(string[] args)
        {
            Maths maths = new Maths();
            Double x;
            Double y;
            Double c = -1;
            double result = 0;


            Console.WriteLine("Calculator!!");
           

            do
            {
                
                Console.WriteLine("Enter the operation :");
                Console.WriteLine("1.Addition");
                Console.WriteLine("2.Substration");
                Console.WriteLine("3.Multiplication");
                Console.WriteLine("4.Division");
                Console.WriteLine("Enter your choice");
                c = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Enter any two numbers");

                x = Convert.ToDouble(Console.ReadLine());
                y = Convert.ToDouble(Console.ReadLine());
                switch (c)
                {
             
                      
                    case 1:
                        result = maths.Add(x, y);
                        break;

                    case 2:
                        result = maths.Sub(x, y);
                        break;

                    case 3:
                        result = maths.Mul(x, y);
                        break;

                    case 4:
                        if (x != 0)
                        {
                            result = maths.Div(x, y);
                        }
                        else
                        {
                            Console.WriteLine("Division by zero is not allowed.");
                            return;
                        }
                        break;

                    default:
                        Console.WriteLine("Invalid operation.");
                        return;
                }

                Console.WriteLine("Result = " + result);
                Console.WriteLine("Want to continue? (1/0)");
                c= Convert.ToDouble(Console.ReadLine());
            } while(c != 0);

        }
    }
}
