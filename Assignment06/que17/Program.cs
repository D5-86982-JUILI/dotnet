using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using employeeLib;
//using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Security.Cryptography;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Runtime.Serialization.Formatters.Soap;
namespace que17
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
                Console.WriteLine("\n1.add employee  \n2.remove employee  \n3.find employee by id  \n4.display company info \n5.display all employee \n6.serialization \n7.deserialization \n8.end");

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
                        ArrayList employees = company.FindEmployee(id2);

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
                        company.employeeSerialize();
                        break;
                    case 7:
                        string filepath = "D:\\sunbeam assignment\\dotnet\\que17\\que17\\file.txt";
                        FileStream stream = new FileStream(filepath,FileMode.Open);
                        //BinaryFormatter bf = new BinaryFormatter();
                        SoapFormatter sf = new SoapFormatter();
                        object obj = sf.Deserialize(stream);
                        ArrayList al = (ArrayList)obj;
                        Console.WriteLine("File data: ");
                        foreach (Employee item in al)
                        {
                            item.Print();
                        }

                        break;
                    case 8:
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
