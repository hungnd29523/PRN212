using System;
using System.Collections.Generic;

public abstract class Person
{
    // Properties
    public string Name { get; set; }
    public string Address { get; set; }

    // Constructor
    public Person(string name, string address)
    {
        this.Name = name;
        this.Address = address;
    }

    // Abstract method
    public abstract void Display();
}

public class Employee : Person
{
    // Additional property
    public int Salary { get; }

    // Constructor
    public Employee(string name, string address, int salary) : base(name, address)
    {
        this.Salary = salary;
    }

    // Override Display method
    public override void Display()
    {
        Console.WriteLine($"Employee Name: {this.Name}");
        Console.WriteLine($"Employee Address: {this.Address}");
        Console.WriteLine($"Employee Salary: {this.Salary}");
    }
}

public class Customer : Person
{
    // Additional property
    public int Balance { get; }

    // Constructor
    public Customer(string name, string address, int balance) : base(name, address)
    {
        this.Balance = balance;
    }

    // Override Display method
    public override void Display()
    {
        Console.WriteLine($"Customer Name: {this.Name}");
        Console.WriteLine($"Customer Address: {this.Address}");
        Console.WriteLine($"Customer Balance: {this.Balance}");
    }
}

public class MainClass
{
    // Create dynamic arrays for Employee and Customer
    private static List<Employee> employees = new List<Employee>();
    private static List<Customer> customers = new List<Customer>();

    public static void Main(string[] args)
    {
        bool exit = false;

        while (!exit)
        {
            Console.WriteLine("\nMain Menu:");
            Console.WriteLine("1. Add Employee");
            Console.WriteLine("2. Add Customer");
            Console.WriteLine("3. Display Employee with Highest Salary");
            Console.WriteLine("4. Display Customer with Lowest Balance");
            Console.WriteLine("5. Find Employee by Name");
            Console.WriteLine("6. Exit");
            Console.Write("Enter your choice: ");

            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    AddEmployee();
                    break;
                case 2:
                    AddCustomer();
                    break;
                case 3:
                    DisplayEmployeeWithHighestSalary();
                    break;
                case 4:
                    DisplayCustomerWithLowestBalance();
                    break;
                case 5:
                    FindEmployeeByName();
                    break;
                case 6:
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }

    private static void AddEmployee()
    {
        Console.Write("Enter employee name: ");
        string name = Console.ReadLine();
        Console.Write("Enter employee address: ");
        string address = Console.ReadLine();
        Console.Write("Enter employee salary: ");
        int salary = Convert.ToInt32(Console.ReadLine());

        Employee employee = new Employee(name, address, salary);
        employees.Add(employee);
        Console.WriteLine("Employee added successfully.");
    }

    private static void AddCustomer()
    {
        Console.Write("Enter customer name: ");
        string name = Console.ReadLine();
        Console.Write("Enter customer address: ");
        string address = Console.ReadLine();
        Console.Write("Enter customer balance: ");
        int balance = Convert.ToInt32(Console.ReadLine());

        Customer customer = new Customer(name, address, balance);
        customers.Add(customer);
        Console.WriteLine("Customer added successfully.");
    }

    private static void DisplayEmployeeWithHighestSalary()
    {
        Employee empWithHighestSalary = FindEmployeeWithHighestSalary();
        if (empWithHighestSalary != null)
        {
            empWithHighestSalary.Display();
        }
        else
        {
            Console.WriteLine("No employees found.");
        }
    }

    private static void DisplayCustomerWithLowestBalance()
    {
        Customer custWithLowestBalance = FindCustomerWithLowestBalance();
        if (custWithLowestBalance != null)
        {
            custWithLowestBalance.Display();
        }
        else
        {
            Console.WriteLine("No customers found.");
        }
    }

    private static void FindEmployeeByName()
    {
        Console.Write("Enter employee name to search: ");
        string name = Console.ReadLine();

        bool found = false;
        foreach (Employee employee in employees)
        {
            if (employee.Name.Equals(name, StringComparison.OrdinalIgnoreCase))
            {
                employee.Display();
                found = true;
                break;
            }
        }

        if (!found)
        {
            Console.WriteLine("Employee not found.");
        }
    }

    // Helper method to find the employee with the highest salary
    private static Employee FindEmployeeWithHighestSalary()
    {
        Employee empWithHighestSalary = employees[0];
        foreach (Employee employee in employees)
        {
            if (employee.Salary > empWithHighestSalary.Salary)
            {
                empWithHighestSalary = employee;
            }
        }
        return empWithHighestSalary;
    }

    // Helper method to find the customer with the lowest balance
    private static Customer FindCustomerWithLowestBalance()
    {
        Customer custWithLowestBalance = customers[0];
        foreach (Customer customer in customers)
        {
            if (customer.Balance < custWithLowestBalance.Balance)
            {
                custWithLowestBalance = customer;
            }
        }
        return custWithLowestBalance;
    }
}