using System;
using System.Collections.Generic;
using System.Linq;
using static System.Console;

namespace EmployeeLINQ
{
    internal class Program
    {
        //  Create Global Array Of Employee Objects
       static  Employee[] employees =
       {
            new Employee("John", "Jones", 55555m),
            new Employee("Kate", "Smith", 78900m),
            new Employee("Kent", "Black", 45500m),
            new Employee("Gwen", "White", 74999m),
            new Employee("Fred", "Green", 34500m),
            new Employee("Jane", "Brown", 17500m),
            new Employee("Jeff", "Creed", 87431m),
            new Employee("Jean", "Jones", 67500m),
            new Employee("Mark", "Bryan", 75001m),
            new Employee("Kris", "Kelly", 102500m),
       };

        static void Main(string[] args)
        {
            //  Display all Employee objects
            //displayAllEmployees();

            //  Display only employees making 50K - 75K
            //display50KTo75KSalaryEmployees();

            //  Display all employees sorted by
            //  last name, first name
            //displayAllEmployeesSortedByName();

            //  Display distinct employee last names
            //displayDistinctEmployeeLastNames();

            //  Additional LINQ Methods shown Page 603
            displayAdditionalLinqMethods();

            ReadLine();
        }

        static void displayAllEmployees()
        {
            WriteLine("All Employees Listing:");
            foreach(var e in employees)
            {
                WriteLine(e);
            }
        }

        static void display50KTo75KSalaryEmployees()
        {
            //  Calculate those employees making 50K to 75K
            var between50KAnd75K =
                from e in employees
                where e.Salary >= 50000m && e.Salary <= 75000M
                select e;

            //  Display those employees making 50K to 75K
            WriteLine("\n\nThose Employees Making 50K - 75K:");
            foreach (var b in between50KAnd75K)
            {
                WriteLine(b);
            }
        }

        static void displayAllEmployeesSortedByName()
        {
            var sortedEmployees =
                from e in employees
                orderby e.LastName, e.FirstName
                select e;

            //  Display all employees in alphabetical order
            WriteLine("\n\nAll Employees in Alphabetical Order:");
            foreach (var s in sortedEmployees)
            {
                WriteLine(s);
            }
        }

        static void displayDistinctEmployeeLastNames()
        {
            var sortedLastNames =
                from e in employees
                orderby e.LastName descending
                select e.LastName;

            WriteLine("Distinct Employee Last Names Descending");
            foreach (var s in sortedLastNames.Distinct())
            {
                WriteLine(s);
            }
        }

        static void displayAdditionalLinqMethods()
        {
            /*
             *      Total Number of Employees   (Count)
             *      Sum of Employee Salaries    (Sum)
             *      Average Employee Salary     (Average)
             *      Maximum Employee Salary     (Max)
             *      Minimum Employee Salary     (Min)
             *      First Employee Salary       (First)
             *      FirstOrDefault Salary       (FirstOrDefault)
             *      Single Name Jean            (Single)
             *      SingleOrDefault Name Jean   (SingleOrDefault)
             *      Skip Employee Salary > 50K  (Skip first 3 employees)
             *      Take                        (Show only first 3 employees)
             *      ToList
             */

            //  Based of the material at the following URL:
            //  https://www.csharp-examples.net/linq-aggregation-methods/

            //  Query #1 - Count (total number of employers)
            int empCount = (from x in employees select x).Count();
            WriteLine("Total Number Of Employees: " + empCount.ToString());

            //  https://www.csharp-console-examples.com/collection/linq/calculate-the-sum-of-salaries-of-all-the-employees-in-c-usinq-linq/
            //  Query #2a - Sum (total salary with Method Syntax)
            var totalSalaryMS = Employee.GetAllEmployees()
                              .Sum(emp => emp.Salary);
            WriteLine("\nTotal Employee Salary Method Syntax: " +
                                totalSalaryMS.ToString("c"));

            //  Query #2b - Sum (total salary with Query Syntax)
            var totalSalaryQS = (from emp in Employee.GetAllEmployees()
                                 select emp).Sum(e => e.Salary);
            WriteLine("\nTotal Employee Salary Query  Syntax: " +
                                totalSalaryQS.ToString("c"));

            //  Query #3 - Average (average employee salary)
            var avgSalary = employees.Select(x => x.Salary).Average();
            WriteLine("\nAverage Employee Salary: " +
                                avgSalary.ToString("c"));

            //  Query #4 - Maximum (highest employee salary)
            var highSalary = employees.Select(x => x.Salary).Max();
            WriteLine("\nHighest Employee Salary: " +
                                highSalary.ToString("c"));

            //  Query #5 - Minimum (lowest  employee salary)
            var lowSalary = employees.Select(x => x.Salary).Min();
            WriteLine("\nLowest Employee Salary: " +
                                lowSalary.ToString("c"));

            //  Query #6 - First (first employee salary)
            var firstSalaryOver75K = Employee.GetAllEmployees()
                                .Where(x => x.Salary > 75000m).First();
            WriteLine("\nFirst Salary Over 75K: " +
                                firstSalaryOver75K.ToString());

            //  https://www.c-sharpcorner.com/article/linq-fundamental-first-and-firstordefault/
            //  Query #7 - FirstOrDefault (first/default employee salary)
            var firstSalaryOver1MB = Employee.GetAllEmployees()
                                .Where(x => x.Salary > 1000000m).FirstOrDefault();
            if (firstSalaryOver1MB == null)
            {
                WriteLine("\nFirst Salary Over 1MB: " +
                                "NONE MEET CRITERIA");
            }

            //  Query #7 - Single (single employee salary)
            var singleSalaryOf55555 = Employee.GetAllEmployees()
                                .Where(x => x.Salary == 55555m).Single();
            WriteLine("\nFirst Salary Over 75K: " +
                                singleSalaryOf55555.ToString());

            //  Query #8 - SingleOrDefault (single employee salary)
            var singleSalaryOf1MB = Employee.GetAllEmployees()
                                .Where(x => x.Salary > 1000000m).SingleOrDefault();
            if (singleSalaryOf1MB == null)
            {
                WriteLine("\nSingle Salary Over 1MB: " +
                                "NONE MEET CRITERIA");
            }

            //  Query #9 - Skip (Skip showing first 3 employees only)
            var skipFirst3Employees = (from emp in employees
                                       select emp)
                                      .Skip(3);
            WriteLine("\nSkipping first 3 Employees In List: ");
            foreach (var e in skipFirst3Employees)
            {
                WriteLine(e);
            }

            //  Query #10 - Take (Show just first 3 employees)
            var first3Employees = (from emp in employees
                                   select emp)
                                    .Take(3);
            WriteLine("\nFirst 3 Employees In List: ");
            foreach (var e in first3Employees)
            {
                WriteLine(e);
            }

            //  Query #11 - ToList (Create a new list)
            string[] midWest = { "Missouri", "Illinois", "Iowa", "Wisconsin"};

            //  midWest.ToList() convert the collection of data into the list.  
            List<string> result = midWest.ToList();

            WriteLine("\nThe states in the midWest list:");
            //  foreach loop is used to print the name of each state  
            foreach (string s in result)
            {
                WriteLine(s);
            }
        }
    }
}
