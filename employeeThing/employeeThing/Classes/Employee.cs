using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace employeeThing.Classes
{
    public class Employee
    {

        public static List<Employee> SearchEmployeeByName(string searchTerm)
        {
            //Using language integrated query in order to look for something in the list that is made later on
            List<Employee> matchingEmployees = employees.Where(employee => employee.FirstName.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) || employee.LastName.Contains(searchTerm, StringComparison.OrdinalIgnoreCase)).ToList();

            return matchingEmployees;
        }

        private string lastName;
        private string firstName;
        private int age;
        private int phoneNumber;

        public string FirstName
        {
            get
            {
                return firstName;
            }
            set
            {
                firstName = value;
            }
        }
        public string LastName
        {
            get
            {
                return lastName;
            }
            set
            {
                lastName = value;
            }
        }
        public int Age
        {
            get
            {
                return age;
            }
            set
            {
                age = value;
            }
        }
        public int PhoneNumber
        {
            get
            {
                return phoneNumber;
            }
            set
            {
                phoneNumber = value;
            }


        }

        public Employee(string firstName, string lastName, int age, int phoneNumber)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            PhoneNumber = phoneNumber;
        }

        //List for employee objects
        private static List<Employee> employees = new List<Employee>();

        #region Write info

        public void EmpStringMaker()
        {
            Console.WriteLine($"\nFirstname: \t{FirstName} \nLastname: \t{LastName} \nAge: \t\t{Age} \n---------------------------------");
        }

        public void DisplayFullDetails()
        {
            Console.WriteLine($"\nFirstname: \t{FirstName} \nLastname: \t{LastName} \nAge: \t\t{Age} \nNumber: \t{PhoneNumber} \n---------------------------------");
        }

        #endregion

        //Method for listing employees, listing lastname, firstname and age
        public static void EmployeeList()
        {
            var i = 0;
            Console.Clear();
            Console.WriteLine("List of employees:");
            foreach (var employee in employees)
            {
                Console.WriteLine($"{i}. ");
                i++;
                employee.EmpStringMaker();
            }
            Console.WriteLine("=================================");
        }

        #region New Employee

        public static void Menu()
        {

            string line = "---------------------------------";
            string lines = "=================================";

            Console.WriteLine("What would you like to do? \n1. Make new employee \n2. List employees \n3. Edit employee \n9. Clear screen \n\n\n\n\nType 'Quit' if you want to close the program");
            Console.Write("Your selection: ");

            var selection = Console.ReadLine();
            while (selection != "1" && selection != "2" && selection != "3" && selection != "9" && selection != "quit")
            {
                Console.WriteLine(line + "\nInvalid selection! Please type '1', '2', '3', '9' or 'quit'.");
                Console.WriteLine("What would you like to do? \n1. Make new employee \n2. List employees \n3. Edit employee \n9. Clear screen \n\n\n\n\nType 'Quit' if you want to close the program");
                selection = Console.ReadLine();
            }

            Employee newEmployee = null;

            switch (selection)
            {
                case "1":
                    Console.Write("Enter firstname: ");
                    string firstName = Console.ReadLine();
                    Console.Write("Enter lastname: ");
                    string lastName = Console.ReadLine();
                    Console.Write("Enter age: ");
                    int age = int.Parse(Console.ReadLine());
                    Console.Write("Enter phone number: ");
                    int phoneNumber = int.Parse(Console.ReadLine());
                    Console.Write(line);
                    newEmployee = new Employee(firstName, lastName, age, phoneNumber);
                    employees.Add(newEmployee);
                    newEmployee.DisplayFullDetails();
                    Menu();
                    break;

                case "2":
                    //List all employees -Lastname, Firstname, age
                    EmployeeList();
                    Menu();
                    break;

                case "3":
                    //List employees
                    EmployeeList();

                    // Ask the user to select an action
                    Console.WriteLine("What would you like to do? \n1. Edit an employee \n2. Search for an employee");
                    Console.Write("Your selection: ");
                    var choice = Console.ReadLine();

                    switch (choice)
                    {
                        case "1":
                            //List employees
                            EmployeeList();

                            //Ask the user to select an employee to edit
                            Console.WriteLine("Select the index of the employee you want to edit:");
                            if (int.TryParse(Console.ReadLine(), out int selectedEmployeeIndex) && selectedEmployeeIndex >= 0 && selectedEmployeeIndex < employees.Count)
                            {
                                //Get the selected employee from the list
                                Employee selectedEmployee = employees[selectedEmployeeIndex];

                                //Ask for updated information for the employee
                                Console.Write("Enter updated firstname: ");
                                selectedEmployee.FirstName = Console.ReadLine();

                                Console.Write("Enter updated lastname: ");
                                selectedEmployee.LastName = Console.ReadLine();

                                Console.Write("Enter updated age: ");
                                selectedEmployee.Age = int.Parse(Console.ReadLine());

                                Console.Write("Enter updated phone number: ");
                                selectedEmployee.PhoneNumber = int.Parse(Console.ReadLine());

                                Console.WriteLine("Employee details updated successfully.");
                                selectedEmployee.DisplayFullDetails();
                            }
                            else
                            {
                                Console.WriteLine("Invalid employee index. Please select a valid index from the list.");
                            }

                            Menu();
                            break;

                        case "2":
                            //Search for an employee
                            Console.WriteLine("Search for an employee by name:");
                            string searchName = Console.ReadLine();

                            //Get matching employees
                            List<Employee> matchingEmployees = Employee.SearchEmployeeByName(searchName);

                            if (matchingEmployees.Count > 0)
                            {
                                Console.WriteLine("Matching employees:");
                                for (int i = 0; i < matchingEmployees.Count; i++)
                                {
                                    Console.WriteLine($"Index: {i}, Employee Details:");
                                    matchingEmployees[i].EmpStringMaker();
                                }
                            }
                            else
                            {
                                Console.WriteLine("No matching employees found.");
                            }

                            //Don't want it to break here because i'd like for it to continue questioning you after you've searched for the employee you want to edit.
                            break;

                        default:
                            Console.WriteLine("Invalid selection. Please select either 1 or 2.");
                            break;
                    }

                    Menu();
                    break;
                    

                case "9":
                    Console.Clear();
                    Menu();
                    break;

                case "quit":
                    quitting();
                    break;
            }

            //Console.WriteLine("Type lastname: ");
            //LastName = Console.ReadLine();
            //Console.WriteLine("Type firstname: ");
            //FirstName = Console.ReadLine();
            //Console.WriteLine("Type age: ");
            //Age = int.Parse(Console.ReadLine());


            //return Employee;

        }





        #endregion

        public static void quitting()
        {
            Random random = new Random();
            int i = random.Next(3, 10);

            for (int j = 0; j < i; j++)
            {
                Console.Clear();
                Console.Write("Quitting the program.");
                Thread.Sleep(300);
                Console.Write(".");
                Thread.Sleep(300);
                Console.Write(".");
                Thread.Sleep(300);
            }

            Console.WriteLine("\nPlease press enter");
            Console.ReadLine();
        }
    }
}