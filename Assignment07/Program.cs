using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using EmployeeLib1;

namespace Program16
{
    internal class Program
    {
        private static string path = "D:\\Study\\PG\\Assignments\\dotNET\\companyData.txt";

        public static int Menu()
        {
            Console.WriteLine("\n0. Exit");
            Console.WriteLine("1. Add Employee");
            Console.WriteLine("2. Remove Employee");
            Console.WriteLine("3. Find Employee");
            Console.WriteLine("4. Display Company Info");
            Console.WriteLine("5. Display All Employees");
            Console.WriteLine("6. Save Employees into file");
            Console.WriteLine("7. Load Employess from file");
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

        public static void WriteData(LinkedList<Employee> empList)
        {
            FileStream fWrite = null;
            if(File.Exists(path))
            {
                fWrite = new FileStream(path, FileMode.Open, FileAccess.Write);
            }
            else
            {
                fWrite = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write);
            }

            BinaryFormatter helper = new BinaryFormatter();
            foreach(Employee e in empList)
            {
                helper.Serialize(fWrite, e);
            }
            helper = null;
            fWrite.Close();
            Console.WriteLine("Data written successfully...");
        }

        public static LinkedList<Employee> ReadData()
        {
            LinkedList<Employee> empList = new LinkedList<Employee>();
            FileStream fRead = null;
            if (File.Exists(path))
            {
                fRead = new FileStream(path, FileMode.Open, FileAccess.Read);
                BinaryFormatter helper = new BinaryFormatter();
                while(fRead.Position < fRead.Length)
                {
                    var obj = helper.Deserialize(fRead);

                    if(obj is Employee)
                    {
                        Employee e = (Employee)obj;
                        empList.AddLast(e);
                    }
                }

                helper = null;
                fRead.Close();
            }
            else
            {
                Console.WriteLine("File does not exists...");
            }

            Console.WriteLine("Data read successfully...");
            return empList;
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

                    case 6:
                        {
                            Console.WriteLine();
                            WriteData(c.EmpList);
                            break;
                        }

                    case 7:
                        {
                            Console.WriteLine();
                            c.EmpList.Clear();
                            c.EmpList = ReadData();
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
