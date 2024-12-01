using System;
using EmployeeLib;

namespace Program15
{
    internal class Program
    {
        public static int Menu()
        {
            Console.WriteLine("\n0. Exit");
            Console.WriteLine("1. Add Employee");
            Console.WriteLine("2. Remove Employee");
            Console.WriteLine("3. Find Employee");
            Console.WriteLine("4. Display Company Info");
            Console.WriteLine("5. Display All Employees");
            Console.Write("Enter your choice: ");
            int ch = Convert.ToInt32(Console.ReadLine());
            return ch;
        }

        public static Employee EmpType()
        {
            Console.WriteLine("\n1. Add Manager");
            Console.WriteLine("2. Add Supervisor");
            Console.WriteLine("3. Add Wage Employee");
            Console.Write("Enter your choice: ");
            int ch = Convert.ToInt32(Console.ReadLine());

            if (ch == 1)
            {
                return new Manager();
            }
            else if (ch == 2)
            {
                return new Supervisor();
            }
            else if (ch == 3)
            {
                return new WageEmp();
            }

            return null;
        }

        static void Main(string[] args)
        {
            Company c = new Company();
            c.Accept();
            Employee e;
            int ch;

            do
            {
                ch = Menu();

                switch (ch)
                {
                    case 0:
                        Console.WriteLine("Thank You...");
                        break;

                    case 1:
                        {
                            Console.WriteLine();
                            e = EmpType();
                            e.Accept();
                            c.AddEmployee(e);
                            break;
                        }

                    case 2:
                        {
                            Console.Write("\nEnter emp id: ");
                            int id = Convert.ToInt32(Console.ReadLine());
                            bool flag = c.RemoveEmployee(id);
                            if (flag)
                            {
                                Console.WriteLine("Removed successfully...");
                            }
                            else
                            {
                                Console.WriteLine("Employee does not exist...");
                            }
                            break;
                        }

                    case 3:
                        {
                            Console.Write("\nEnter emp id: ");
                            int id = Convert.ToInt32(Console.ReadLine());
                            var trav = c.FindEmployee(id);
                            if (trav == null)
                            {
                                Console.WriteLine("Employee not found..");
                            }
                            else
                            {
                                e = trav.Value;
                                Console.WriteLine(e);
                            }
                            break;
                        }

                    case 4:
                        {
                            Console.WriteLine("\n" + c);
                            break;
                        }

                    case 5:
                        {
                            Console.WriteLine();
                            c.PrintEmployees();
                            break;
                        }

                    default:
                        Console.WriteLine("\nInvalid choice...");
                        break;
                }

            } while (ch != 0);
        }
    }
}
