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
        private static List<String> firstNames = new List<String>();
        private static List<String> lastNames = new List<String>();
        private static List<int> ages = new List<int>();
        private static List<int> numbers = new List<int>();

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
            Console.Clear();
            Console.WriteLine("List of employees:");
            foreach (var employee in employees)
            {
                employee.EmpStringMaker();
            }
            Console.WriteLine("=================================");
        }

        #region New Employee

        public static void Menu()
        {

            string line = "---------------------------------";
            string lines = "=================================";

            Console.WriteLine("What would you like to do? \n1. Make new employee \n2. List employee \n3. Edit employees \n9. Clear screen \n\n\n\n\nType 'Quit' if you want to close the program");
            Console.Write("Your selection: ");

            var selection = Console.ReadLine();
            while (selection != "1" && selection != "2" && selection != "3" && selection != "9" && selection != "quit")
            {
                Console.WriteLine(line + "\nInvalid selection! Please type '1', '2', '3', '9' or 'quit'.");
                Console.WriteLine("What would you like to do? \n1. Make new employee \n2. List employee \n3. Edit employees \n9. Clear screen \n\n\n\n\nType 'Quit' if you want to close the program");
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


                    firstNames.Add(newEmployee.FirstName);
                    lastNames.Add(lastName);
                    ages.Add(newEmployee.age);
                    numbers.Add(phoneNumber);


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
                    //Try to make a filter
                    //Pick employee
                    //Show employee details
                    //New menu for editing employee

                    //Listing employees
                    EmployeeList();

                    //Letting you chose how to search
                    Console.WriteLine("What would you like to do? \n1. Search by name \n2. Search by number \n3. Search by age");
                    Console.Write("Your selection: ");

                    var choice = Console.ReadLine();
                    while (choice != "1" && choice != "2" && choice != "3" && choice != "9" && choice != "quit")
                    {
                        Console.WriteLine(line + "\nInvalid selection!");
                        Console.WriteLine("What would you like to do? \n1. Search by name \n2. Search by number \n3. Search by age");
                        choice = Console.ReadLine();
                    }

                    switch (choice)
                    {
                        case "1":
                            Console.Clear();
                            Console.WriteLine("Search by \n1. Lastname \n2. Firstname");
                            var firstOrLastName = Console.ReadLine();

                            while (firstOrLastName != "1" &&  firstOrLastName != "2")
                            {
                                Console.WriteLine(line + "\nInvalid selection! Please press '1' or press '2'");
                                firstOrLastName = Console.ReadLine();
                            }

                            if (firstOrLastName == "1")
                            {
                                Console.WriteLine("Printing everything with the correct lastname!");
                                //What i must do: Get the list of employees named 'employees', make a target which will be a user input. The program will look through the list looking for the target. If the target(s) is/are fround it/they will be printed



                                //int target = ages[0];

                                //bool isExist = ages.Find(target);
                                //if (isExist)
                                //{
                                //    Console.WriteLine("Element found in the list");
                                //}
                            }

                            else
                            {
                                Console.WriteLine("Printing everything with the correct firstname!");
                            }
                            

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