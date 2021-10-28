using System;

namespace UserInterface
{
    //The ":" syntax is used to indicate that you will inherit another class, interface, or abstract class
    public class MainMenu : IMenu
    {
    
        public void Menu()
        {
           
            Console.WriteLine("Welcome to Wanderlust Outfitters!");
            Console.WriteLine("How can we help you?");
            Console.WriteLine("====================");
            Console.WriteLine("[1] - Show Excursions");
            Console.WriteLine("[2] - Show Products");
            Console.WriteLine("[3] - Show Clothing");
            Console.WriteLine("====================");
            Console.WriteLine("[4] - Log in");
            Console.WriteLine("[5] - Create Account");
            Console.WriteLine("====================");
            Console.WriteLine("[0] - Exit");
        }

        
        public MenuType UserChoice()
        {
            string userChoice = Console.ReadLine();
            switch (userChoice)
            {
                case "1": 
                    return MenuType.ShowExcursions;
                case "2": 
                    return MenuType.ShowProducts;
                case "3": 
                    return MenuType.ShowClothing;
                // case "4": 
                //     return MenuType.LogIn;
                case "5": 
                    return MenuType.AddCustomer;
                case "0":
                    return MenuType.Exit;
                default:
                    Console.WriteLine("Please input a valid response!");
                    Console.WriteLine("Press Enter to continue");
                    Console.ReadLine();
                    return MenuType.MainMenu;
            }
        }
    }
}