using employeeThing.Classes;
using System.ComponentModel.Design;

PrintWelcome();
Employee.Menu();


static void PrintWelcome()
{

    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("╔╦╦╦═╦╗╔═╦═╦══╦═╗\r\n║║║║╩╣╚╣═╣║║║║║╩╣\r\n╚══╩═╩═╩═╩═╩╩╩╩═╝ \nPress enter to continue.");

    Console.ResetColor();

    Console.ReadLine();

    Console.Clear();
}