using System;
using System.Collections;
using System.Collections.Generic;

namespace EmployeeLib
{
    public class Date
    {
        private int day;
        private int month;
        private int year;

        public Date()
        {
            this.day = 0;
            this.month = 0;
            this.year = 0;
        }

        public Date(int day, int month, int year)
        {
            this.day = day;
            this.month = month;
            this.year = year;
        }

        public int Day
        {
            get { return day; }
            set { day = value; }
        }

        public int Month
        {
            get { return month; }
            set { month = value; }
        }

        public int Year
        {
            get { return year; }
            set 
            { year = value; }
        }

        public void AcceptDate()
        {
            Console.Write("Enter day: ");
            Day = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter month: ");
            Month = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter year: ");
            Year = Convert.ToInt32(Console.ReadLine());
        }

        public void PrintDate()
        {
            Console.WriteLine($"Date: {Day}/{Month}/{Year}");
        }

        public bool isValid()
        {
            if (Year < 1 || Month < 1 || Month > 12 || Day < 1 || Day > 31) 
            { 
                return false; 
            }
            if ((Month == 4 || Month == 6 || Month == 9 || Month == 11) && Day > 30) 
            {
                return false; 
            }

            return true;
        }

        public static Date operator -(Date d1, Date d2)
        {
            Date d = new Date();
            d.Day = d1.Day - d2.Day;
            d.Month = d1.Month - d2.Month;
            d.Year = d1.Year - d2.Year;
            return d;
        }

        public static void Age(Date birth) 
        { 
            DateTime today = DateTime.Today; 
            int age = today.Year - birth.Year;
            Console.WriteLine($"Age is {age}");  
        }

        public override string ToString()
        {
            return $"Date [Day={Day} Month={Month} Year={Year}]";
        }
    }

    public class Person
    {
        private string name;
        private string gender;
        private string address;
        private Date birth;

        public Person()
        {
            this.name = "";
            this.gender = "";
            this.address = "";
            this.birth = new Date();
        }

        public Person(string name, string gender, string address, Date birth)
        {
            this.name = name;
            this.gender = gender;
            this.address = address;
            this.birth = birth;
        }

        public Date Birth
        {
            get { return birth; }
        }

        public string Address
        {
            get { return address; }
        }


        public string Gender
        {
            get { return gender; }
        }


        public string Name
        {
            get { return name; }
        }

        public virtual void Accept()
        {
            Console.Write("Enter name: ");
            name = Console.ReadLine();
            Console.Write("Enter gender: ");
            gender = Console.ReadLine();
            Console.Write("Enter address: ");
            address = Console.ReadLine();
            Console.WriteLine("Enter DOB:");
            birth = new Date();
            birth.AcceptDate();
        }

        public virtual void Print()
        {
            Console.WriteLine("Name: " + name);
            Console.WriteLine("Gender: " + gender);
            Console.WriteLine("Address: " + address);
            Console.WriteLine("DOB:");
            birth.PrintDate();
            Date.Age(birth);
        }

        public override string ToString()
        {
            return $"Name={name}, Gender={gender}, Address={address}";
        }
    }

    public class Employee: Person
    {
        public enum DepartmentType 
        {
            IT, HR, Sales, Marketing
        }

        private int id;
        private double salary;
        private string designation;
        private DepartmentType dept;
        private static int autoGenerate = 0;

        public Employee() : base()
        {
            this.id = ++autoGenerate;
            this.salary = 0.0; 
            this.designation = ""; 
            this.dept = DepartmentType.IT;
        }

        public Employee(string name, string gender, string address, Date birth, double salary, string designation, DepartmentType dept) : base(name, gender, address, birth)
        {
            id = ++autoGenerate;
            this.salary = salary;
            this.designation = designation;
            this.dept = dept;
        }

        public DepartmentType Dept
        {
            get { return dept; }
            set { dept = value; }
        }

        public string Designation
        {
            get { return designation; }
            set { designation = value; }
        }

        public double Salary
        {
            get { return salary; }
            set { salary = value; }
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public override void Accept()
        {
            base.Accept();
            Console.Write("Enter emp salary: ");
            Salary = Convert.ToDouble(Console.ReadLine());
            Console.Write("Enter emp designation: ");
            Designation= Console.ReadLine();
            Console.Write("Enter Department (IT, HR, Sales, Marketing): "); 
            dept = (DepartmentType)Enum.Parse(typeof(DepartmentType), Console.ReadLine(), true);
        }

        public override void Print()
        {
            base.Print();
            Console.WriteLine("Id: " + Id); 
            Console.WriteLine("Salary: " + Salary); 
            Console.WriteLine("Designation: " + Designation); 
            Console.WriteLine("Department: " + Dept);
        }

        public override string ToString()
        {
            return $"{base.ToString()}, Id={Id}, Salary={Salary}, Designation={Designation}, Dept={Dept}";
        }
    }

    public class Manager : Employee
    {
        private double bonus;

        public Manager() : base()
        {
            this.bonus = 0.0;
            Designation = "Manager";
        }

        public Manager(string name, string gender, string address, Date birth, double salary, string designation, DepartmentType dept, double bonus) : base(name, gender, address, birth, salary, "Manager", dept)
        {
            this.bonus = bonus;
        }

        public double Bonus
        {
            get { return bonus; }
            set { bonus = value; }
        }

        public override void Accept()
        {
            base.Accept();
            Console.Write("Enter bonus: ");
            Bonus = Convert.ToDouble(Console.ReadLine());
        }

        public override void Print()
        {
            base.Print();
            Console.WriteLine("Bonus: " + Bonus);
        }

        public override string ToString()
        {
            return $"{base.ToString()}, Bonus={Bonus}";
        }
    }

    public class Supervisor : Employee
    {
        private int subbordinates;

        public Supervisor() : base()
        {
            this.subbordinates = 0;
            Designation = "Supervisor";
        }

        public Supervisor(string name, string gender, string address, Date birth, double salary, string designation, DepartmentType dept, int subbordinates) : base(name, gender, address, birth, salary, "Supervisor", dept)
        {
            this.subbordinates = subbordinates;
        }
        public int Subbordinates
        {
            get { return subbordinates; }
            set { subbordinates = value; }
        }

        public override void Accept()
        {
            base.Accept();
            Console.Write("Enter subbordinates: ");
            Subbordinates = Convert.ToInt32(Console.ReadLine());
        }

        public override void Print()
        {
            base.Print();
            Console.WriteLine("Subbordinates: " + Subbordinates);
        }

        public override string ToString()
        {
            return $"{base.ToString()}, Subbordinates={Subbordinates}";
        }
    }

    public class WageEmp : Employee
    {
        private int hours;
        private int rate;

        public WageEmp() : base()
        {
            this.hours = 0;
            this.rate = 0;
            Designation = "Wage";
        }

        public WageEmp(string name, string gender, string address, Date birth, double salary, string designation, DepartmentType dept, int hours, int rate) : base(name, gender, address, birth, salary, "Wage", dept)
        {
            this.hours = hours;
            this.rate = rate;
        }

        public int Rate
        {
            get { return rate; }
            set { rate = value; }
        }

        public int Hours
        {
            get { return hours; }
            set { hours = value; }
        }

        public override void Accept()
        {
            base.Accept();
            Console.Write("Enter hours: ");
            Hours = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter rate: ");
            Rate = Convert.ToInt32(Console.ReadLine());
        }

        public override void Print()
        {
            base.Print();
            Console.WriteLine("Hours: " + Hours);
            Console.WriteLine("Rate: " + Rate);
        }

        public override string ToString()
        {
            return $"{base.ToString()}, Hours={Hours}, Rate={Rate}";
        }
    }

    public class Company
    {
        private string name;
        private string address;
        private LinkedList<Employee> empList;
        private double salaryExpense;

        public Company()
        {
            this.name = "";
            this.address = "";
            this.empList = new LinkedList<Employee>();
            this.salaryExpense = 0.0;
        }

        public Company(string name, string address, double salaryExpense)
        {
            this.name = name;
            this.address = address;
            this.empList = new LinkedList<Employee>();
            this.salaryExpense = salaryExpense;
        }

        public double SalaryExpense
        {
            get { return salaryExpense; }
            set { salaryExpense = value; }
        }


        public LinkedList<Employee> EmpList
        {
            get { return empList; }
            set { empList = value; }
        }

        public string Address
        {
            get { return address; }
            set { address = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public void Accept()
        {
            Console.Write("Enter company name: ");
            Name = Console.ReadLine();
            Console.Write("Enter company address: ");
            Address = Console.ReadLine();
        }

        public void Print()
        {
            Console.WriteLine("Company name: " + Name);
            Console.WriteLine("Company address: " + Address);
            PrintEmployees();
            Console.WriteLine("Salary Expense: " + SalaryExpense);
        }

        public void CalculateSalaryExpense()
        {
            salaryExpense = 0;
            foreach (Employee e in empList)
            {
                salaryExpense += e.Salary;
            }
        }

        public void AddEmployee(Employee e)
        {
            empList.AddLast(e);
            CalculateSalaryExpense();
        }

        public LinkedListNode<Employee> FindEmployee(int id) 
        {
            var trav = empList.First;
            while (trav != null) 
            { 
                if (trav.Value.Id == id) 
                { 
                    return trav; 
                } 
                trav = trav.Next; 
            }
            return null; 
        }

        public bool RemoveEmployee(int id) 
        { 
            var trav = FindEmployee(id); 
            if (trav != null) 
            { 
                empList.Remove(trav); 
                CalculateSalaryExpense(); 
                return true; 
            } 
            
            return false; 
        }

        public void PrintEmployees() 
        {
            Console.WriteLine("Employees:"); 
            foreach (var e in empList) 
            { 
                Console.WriteLine(e); 
            } 
        }

        public override string ToString() 
        { 
            return $"Company Name: {name}, Company Address: {address}, Total Salary Expense: {salaryExpense}"; 
        }
    }
}

