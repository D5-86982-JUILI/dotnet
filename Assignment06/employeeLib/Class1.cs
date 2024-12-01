using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;
using System.Text;
using System.Threading.Tasks;

namespace employeeLib
{
    #region Date class

    [Serializable]
    public class Date
    {
        private int _day;

        public int Day
        {
            get { return _day; }
            set { _day = value; }
        }

        private int _month;

        public int Month
        {
            get { return _month; }
            set { _month = value; }
        }

        private int _year;

        public int Year
        {
            get { return _year; }
            set { _year = value; }
        }

        public Date()
        {
            _day = 1;
            _month = 1;
            _year = 1;
        }

        public Date(int day, int month, int year)
        {
            _day = day;
            _month = month;
            _year = year;
            if (!IsValid())
            {
                Console.WriteLine("Invalid date ...");
                _day = 1;
                _month = 1;
                _year = 1;
                Environment.Exit(0);
                return;
            }
        }

        public void AcceptDate()
        {
            Console.Write("Enter day: ");
            _day = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter month: ");
            _month = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter year: ");
            _year = Convert.ToInt32(Console.ReadLine());

            if (!IsValid())
            {
                Console.WriteLine("Invalid date ...");
                _day = 1;
                _month = 1;
                _year = 1;
                Environment.Exit(0);
                return;
            }
        }

        public void PrintDate()
        {
            Console.Write("date: " + _day);
            Console.Write("-" + _month);
            Console.Write("-" + _year);
        }


        public bool IsValid()
        {

            if (_day < 1 || _day > 31) return false;
            if (_month < 1 || _month > 12) return false;
            if (_year < 1 || _year > 9999) return false;
            return true;
        }


        public string ToString()
        {
            return "date: " + _day + "/" + _month + "/" + _year;
        }





        public static int operator -(Date date1, Date date2)
        {
            if (date1._year > date2._year) return -1;
            int age = date2._year - date1._year;
            if (date1._year == date2._year)
            {
                if (date1.Month > date2.Month) return -1;
                else if (date1.Month == date2.Month)
                {
                    if (date1.Day > date2.Day) return -1;
                }
            }
            if (date1._year < date2._year)
            {
                if (date1.Month > date2.Month) return age - 1;
                else if (date1.Month == date2.Month)
                {
                    if (date1.Day > date2.Day) return age - 1;
                }
            }
            return age;
        }
    }

    #endregion


    #region person class
    [Serializable]
    public class Person
    {
        public string name { get; set; }

        public bool gender { get; set; }

        public Date birth { get; set; }

        public string address { get; set; }

        public int age { get; set; }

        public Person()
        {
            name = "null";
            gender = false;
            birth = new Date();
            address = "null";
            age = 0;
        }

        public Person(string name, bool gender, int day, int month, int year, string address)
        {
            this.name = name;
            this.gender = gender;
            birth = new Date(day, month, year);
            this.address = address;
            DateTime now = DateTime.Now;
            Date cur = new Date(now.Day, now.Month, now.Year);
            age = birth - cur;

        }

        public void Accept()
        {
            Console.Write("Enter Name(string): ");
            name = Console.ReadLine();
            Console.Write("Enter Gender(bool): ");
            string gen = Console.ReadLine();
            if (gen == "true") gender = true;
            else gender = false;
            Console.WriteLine("Enter birth date");
            birth.AcceptDate();
            Console.Write("Enter address(str): ");
            address = Console.ReadLine();
            DateTime now = DateTime.Now;
            Date cur = new Date(now.Day, now.Month, now.Year);
            age = birth - cur;
        }


        public void Print()
        {
            Console.Write("Name: " + name + " Gender: " + gender + " ");
            birth.PrintDate();
            Console.Write(" address: " + address + " age: " + age + " ");
        }

        public string ToString()
        {
            return "Name: " + name + " Gender: " + gender + " " + birth.ToString() + " address: " + address + " age: " + age + " ";

        }





    }
    #endregion

    #region Employee class

    [Serializable]
    public class Employee : Person
    {

        private static int counter = 0;
        private int _id;

        public int id
        {
            get { return _id; }
        }

        public double salary { get; set; }
        public string designation { get; set; }

        public DepartmentType dept { get; set; }


        public Employee() : base()
        {
            counter++;
            _id = counter;
            salary = 0;
            designation = "Fresher";
            dept = new DepartmentType();
        }

        public Employee(string des) : base()
        {
            counter++;
            _id = counter;
            salary = 0;
            designation = des;
            dept = new DepartmentType();
        }

        public Employee(double sal, string des, DepartmentType dt, string name, bool gender, int day, int month, int year, string address) : base(name, gender, day, month, year, address)
        {

            counter++;
            _id = counter;
            salary = sal;
            designation = des;
            dept = dt;
        }

        public void Accept()
        {
            base.Accept();
            Console.Write("Enter Salary: ");
            salary = Convert.ToDouble(Console.ReadLine());
            Console.Write("Enter Dept(HR, IT, Finance, Sales, Marketing): ");
            DepartmentType dept = (DepartmentType)Enum.Parse(typeof(DepartmentType), Console.ReadLine());
        }


        public void Print()
        {
            base.Print();
            Console.WriteLine("id: " + id + " salary: " + salary + " Designation: " + designation + " DepartmentType: " + dept);
        }


        public string ToString()
        {
            return (base.ToString() + "id: " + id + " salary: " + salary + " Designation: " + designation + " DepartmentType: " + dept);
        }




    }

    #endregion


    #region department type enum
    public enum DepartmentType
    {
        HR, IT, Finance, Sales, Marketing

    }
    #endregion



    #region  class Manager

    public class Manager : Employee
    {
        public double bonus { get; set; }

        public Manager() : base("Manager")
        {
            bonus = 0;
        }

        public Manager(double bon, double sal, DepartmentType dt, string name, bool gender, int day, int month, int year, string address) : base(sal, "Manager", dt, name, gender, day, month, year, address)
        {
            bonus = bon;
        }

        public void accept()
        {
            base.Accept();
            Console.Write("Enter bonus(double): ");
            bonus = Convert.ToDouble(Console.ReadLine());
        }

        public void Print()
        {
            base.Print();
            Console.WriteLine(" bonus : " + bonus);
        }

        public string ToString()
        {
            return base.ToString() + " bonus : " + bonus;

        }
    }
    #endregion


    #region  class Supervisor

    public class Supervisor : Employee
    {
        public int subbordinates { get; set; }

        public Supervisor() : base("Supervisor")
        {
            subbordinates = 0;
        }

        public Supervisor(int sub, double sal, DepartmentType dt, string name, bool gender, int day, int month, int year, string address) : base(sal, "Supervisor", dt, name, gender, day, month, year, address)
        {
            subbordinates = sub;
        }

        public void accept()
        {
            base.Accept();
            Console.Write("Enter subordinate(int): ");
            subbordinates = Convert.ToInt32(Console.ReadLine());
        }

        public void Print()
        {
            base.Print();
            Console.Write(" subbordinates : " + subbordinates);
        }

        public string ToString()
        {
            return base.ToString() + " subbordinates : " + subbordinates;

        }
    }
    #endregion



    #region  class WageEmp

    public class WageEmp : Employee
    {
        public int hours { get; set; }
        public int rate { get; set; }

        public WageEmp() : base("Wage")
        {
            hours = 0;
            rate = 0;
        }

        public WageEmp(int hr, int r, double sal, DepartmentType dt, string name, bool gender, int day, int month, int year, string address) : base(sal, "Supervisor", dt, name, gender, day, month, year, address)
        {
            hours = hr;
            this.rate = r;
        }

        public void accept()
        {
            base.Accept();
            Console.Write("Enter hours(int): ");
            hours = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter rate(int): ");
            rate = Convert.ToInt32(Console.ReadLine());
        }

        public void Print()
        {
            base.Print();
            Console.Write(" Hours : " + hours);
            Console.Write(" Rate : " + rate);
        }

        public string ToString()
        {
            return base.ToString() + " Hours : " + hours + " Rate : " + rate;

        }
    }
    #endregion


    #region class Company

    public class Company
    {
        public string name { get; set; }

        public string address { get; set; }

        ArrayList list;
        public double salaryExpense { get; set; }


        public Company()
        {
            name = "null";
            address = "null";
            list = new ArrayList();
            salaryExpense = 0;
        }

        public Company(string name, string address, double salaryExpense)
        {
            this.name = name;
            this.address = address;
            list = new ArrayList();
            this.salaryExpense = salaryExpense;
        }

        public void Accept()
        {
            Console.Write("Enter company name(str): ");
            name = Console.ReadLine();
            Console.Write("Enter company address(str): ");
            address = Console.ReadLine();
        }


        public void Print()
        {
            Console.Write(" Company name: " + name + " Company address: " + address + " Company salary Expense: " + salaryExpense);
        }

        public void addEmployee(Employee emp)
        {
            salaryExpense += emp.salary;
            list.Add(emp);
            Console.WriteLine("Employee added...");
        }

        public bool removeEmployee(int id)
        {
            Employee toRemove = null;
            foreach (Employee emp in list)
            {
                if (emp.id == id)
                {
                    toRemove = emp;
                    break;
                }
            }
            if (toRemove == null)
            {
                Console.WriteLine("Employee not exist...");
                return false;
            }
            else
            {
                Console.WriteLine(toRemove.name + "is removed");
                list.Remove(toRemove);
                return true;
            }
        }

        public ArrayList FindEmployee(int id)
        {
            ArrayList newList = new ArrayList();
            foreach (Employee emp in list)
            {
                if (emp.id == id)
                {
                    newList.Add(emp);
                }
            }

            return newList;
        }

        public double CalculateSalaryExpense()
        {
            return salaryExpense;
        }


        public override string ToString()
        {
            return " Company name: " + name + " Company address: " + address + " Company salary Expense: " + salaryExpense;

        }

        public void PrintEmployees()
        {
            foreach (Employee emp in list)
            {
                emp.Print();
                Console.WriteLine();
            }

        }

        public void employeeSerialize()
        {
            string filepath = "D:\\sunbeam assignment\\dotnet\\que17\\que17\\file.txt";
            FileStream fs = null;
            if (File.Exists(filepath))
            {
                fs = new FileStream(filepath, FileMode.Truncate, FileAccess.Write);
                //BinaryFormatter bf = new BinaryFormatter();
                SoapFormatter sf = new SoapFormatter();
                sf.Serialize(fs, list);
            }
            else
            {
                fs = new FileStream(filepath, FileMode.Create, FileAccess.Write);
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(fs, list);

            }
            Console.WriteLine("Data added in file");
        }


    }

    #endregion

}
