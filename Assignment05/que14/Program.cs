using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmplyoeeLib;

namespace que14
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool end = false;
            Company company = new Company();
            Console.WriteLine("Enter company data");
            company.Accept();
            while (!end)
            {
                Console.WriteLine("\n1.add employee  \n2.remove employee  \n3.find employee by id  \n4.display company info \n 5.display all employee");

                Console.Write("Enter choice: ");
                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Employee e = new Employee();
                        e.Accept();
                        company.addEmployee(e);
                        break;                  
                    case 2:
                        Console.Write("Enter id: ");
                        int id = Convert.ToInt32(Console.ReadLine());
                        company.removeEmployee(id);
                        break;
                    case 3:
                        Console.Write("Enter id: ");
                        int id2 = Convert.ToInt32(Console.ReadLine());
                        LinkedList<Employee> employees = company.FindEmployee(id2);

                        foreach (Employee emp in employees)
                        {
                                emp.Print();
                        }
                        break;
                    case 4:
                        company.Print();
                        break;
                    case 5:
                        company.PrintEmployees();
                        break;
                    case 6:
                           end = true;
                        Console.WriteLine("Thanks for using our program");
                        break;

                    default:
                        Console.WriteLine("Case not match try again");
                        break;
                }

            }
        }
    }
}
