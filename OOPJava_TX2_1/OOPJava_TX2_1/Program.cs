
using System;
using System.Collections.Generic;
using System.Linq;
public interface IEmployee
{
    int CalculateSalary();
    string GetName();
}

public abstract class Employee : IEmployee
{
    public string Name { get; set; }
    public int PaymentPerHour { get; set; }

    public Employee(string name, int paymentPerHour)
    {
        Name = name;
        PaymentPerHour = paymentPerHour;
    }

    public abstract int CalculateSalary();

    public string GetName()
    {
        return Name;
    }

    public override string ToString()
    {
        return $"Name: {Name}, Payment per hour: {PaymentPerHour}";
    }
}

public class FullTimeEmployee : Employee
{
    public FullTimeEmployee(string name, int paymentPerHour) : base(name, paymentPerHour) { }

    public override int CalculateSalary()
    {
        return 8 * PaymentPerHour;
    }
}

public class PartTimeEmployee : Employee
{
    public int WorkingHours { get; set; }

    public PartTimeEmployee(string name, int paymentPerHour, int workingHours) : base(name, paymentPerHour)
    {
        WorkingHours = workingHours;
    }

    public override int CalculateSalary()
    {
        return WorkingHours * PaymentPerHour;
    }
}

namespace Main
{
    public class Main
    {
        private List<Employee> employees = new List<Employee>();

        public void AddEmployee(Employee employee)
        {
            employees.Add(employee);
        }

        public Employee FindHighestPaid(bool isFullTime)
        {
            return employees.OfType<Employee>()
                .Where(e => (isFullTime && e is FullTimeEmployee) || (!isFullTime && e is PartTimeEmployee))
                .OrderByDescending(e => e.CalculateSalary())
                .FirstOrDefault();
        }

        public Employee FindByName(string name)
        {
            return employees.FirstOrDefault(e => e.GetName().Equals(name, StringComparison.OrdinalIgnoreCase));
        }

        public void InputEmployee()
        {
            Console.Write("Enter name: ");
            string name = Console.ReadLine();

            Console.Write("Enter payment per hour: ");
            int paymentPerHour;
            while (!int.TryParse(Console.ReadLine(), out paymentPerHour))
            {
                Console.Write("Invalid input. Enter payment per hour: ");
            }

            Console.Write("Is it a full-time employee? (true/false): ");
            bool isFullTime;
            while (!bool.TryParse(Console.ReadLine(), out isFullTime))
            {
                Console.Write("Invalid input. Is it a full-time employee? (true/false): ");
            }

            if (isFullTime)
            {
                Employee employee = new FullTimeEmployee(name, paymentPerHour);
                AddEmployee(employee);
            }
            else
            {
                Console.Write("Enter working hours: ");
                int workingHours;
                while (!int.TryParse(Console.ReadLine(), out workingHours))
                {
                    Console.Write("Invalid input. Enter working hours: ");
                }

                Employee employee = new PartTimeEmployee(name, paymentPerHour, workingHours);
                AddEmployee(employee);
            }
        }

        public static void Main(string[] args)
        {
            Main main = new Main();
            main.InputEmployee();
            main.InputEmployee();

            Employee highestPaidFullTimeEmployee = main.FindHighestPaid(true);
            Employee highestPaidPartTimeEmployee = main.FindHighestPaid(false);

            Console.WriteLine("Highest paid full-time employee: " + highestPaidFullTimeEmployee);
            Console.WriteLine("Highest paid part-time employee: " + highestPaidPartTimeEmployee);

            Console.Write("Enter name to search: ");
            string name = Console.ReadLine();
            Employee employee = main.FindByName(name);

            if (employee != null)
            {
                Console.WriteLine("Found employee: " + employee);
            }
            else
            {
                Console.WriteLine("Employee not found.");
            }
        }
    }
}