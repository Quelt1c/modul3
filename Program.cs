using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.IO;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8; 

        bool exit = false;

        while (!exit)
        {
            Console.WriteLine("Оберіть опцію:");
            Console.WriteLine("1. Завантажити та відсортувати працівників");
            Console.WriteLine("2. Вийти");

            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    LoadAndSortEmployees();
                    break;
                case 2:
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Невірний вибір. Спробуйте ще раз.");
                    break;
            }
        }
    }

    static void LoadAndSortEmployees()
    {
        XDocument employees = XDocument.Load("employees.xml");

        List<Employee> employeeList = employees.Descendants("Employee")
            .Select(employee => new Employee(
                employee.Element("Name").Value,
                employee.Element("Position").Value,
                DateTime.Parse(employee.Element("HireDate").Value)
            ))
            .ToList();

        var sortedEmployees = employeeList.OrderBy(employee => employee.HireDate);

        var sortedEmployeesXml = new XDocument(
            new XElement("Employees",
                sortedEmployees.Select(employee => new XElement("Employee",
                    new XElement("Name", employee.Name),
                    new XElement("Position", employee.Position),
                    new XElement("HireDate", employee.HireDate.ToString("yyyy-MM-dd"))
                ))
            )
        );

        sortedEmployeesXml.Save("sorted_employees.xml");

        using (StreamWriter writer = new StreamWriter("employees.txt", false, Encoding.UTF8)) 
        {
            foreach (var employee in sortedEmployees)
            {
                writer.WriteLine($"Name: {employee.Name} Position: {employee.Position} HireDate: {employee.HireDate.ToString("yyyy-MM-dd")}");
            }
        }
    }
}

