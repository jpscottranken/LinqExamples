using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeLINQ
{
    public class Employee
    {
        //  Instance variables
        private string _firstName;
        private string _lastName;
        private decimal _salary;

        //  Constructor
        public Employee(string firstName,
                        string lastName,
                        decimal salary)
        {
            _firstName = firstName;
            _lastName = lastName;
            _salary = salary;
        }

        //  Getters and Setters
        public string FirstName
        {
            get
            {
                return _firstName;
            }
            set
            {
                _firstName = value;
            }
        }

        public string LastName
        {
            get
            {
                return _lastName;
            }
            set
            {
                _lastName = value;
            }
        }

        public decimal Salary
        {
            get
            {
                return _salary;
            }
            set
            {
                _salary = value;
            }
        }

        public override string ToString()
        {
            return "\nFirst Name:\t" + FirstName + "\n" +
                   "Last  Name:\t" + LastName + "\n" +
                   "The Salary:\t" + Math.Abs(Salary).ToString("c");
        }

        public static List<Employee> GetAllEmployees()
        {
            List<Employee> employees = new List<Employee>()
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

            return employees;
        }
    }
}
